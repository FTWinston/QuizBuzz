#include "stdafx.h"
#include "Mongoose.h"
#include "Wrapper.h"
#include <msclr\marshal.h>


int EventReceived(mg_connection *conn, enum mg_event ev)
{
	return WebServer::Instance->HandleEvent(conn, ev);
}

WebServer::WebServer()
{
	context = gcnew marshal_context();
	Instance = this;
	pollThread = nullptr;
	connections = new std::map<int, WebSocketConnection*>();
	server = mg_create_server(0, EventReceived);
}

WebServer::~WebServer()
{
	Stop();
	delete connections;
	auto tmp = server;
	mg_destroy_server(&tmp);
	Instance = nullptr;
}

const char *WebServer::MakeCString(String ^string)
{
	return context->marshal_as<const char*>(string);
}

String ^WebServer::GetOption(String ^option)
{
	return gcnew String(mg_get_option(server, MakeCString(option)));
}

String ^WebServer::SetOption(String ^option, String ^value)
{
	return gcnew String(mg_set_option(server, MakeCString(option), MakeCString(value)));
}

void WebServer::Start()
{
	if (pollThread != nullptr)
		return;

	pollThread = gcnew Thread(gcnew System::Threading::ThreadStart(this, &WebServer::Poll));
	pollThread->Start();
}

void WebServer::Stop()
{
	if (pollThread != nullptr)
		pollThread->Abort();
}

void WebServer::Poll()
{
	while (true)
		mg_poll_server(server, 0);
}

int WebServer::HandleEvent(mg_connection *conn, enum mg_event ev)
{
	switch (ev)
	{
	case MG_AUTH:
		return MG_TRUE;
	case MG_REQUEST:
		if (conn->is_websocket)
		{
			auto connection = (WebSocketConnection*)conn->connection_param;
			auto message = gcnew String(conn->content, 0, conn->content_len);

			WebSocketMessageReceived(connection->connectionNumber, message);
			return MG_TRUE;
		}
		return MG_FALSE;
	case MG_WS_CONNECT:
	{
		auto connection = new WebSocketConnection(nextConnectionID++, conn);
		conn->connection_param = connection;
		connections->insert(std::make_pair(connection->connectionNumber, connection));
		WebSocketConnected(connection->connectionNumber);
		return MG_FALSE;
	}
	case MG_CLOSE:
		if (conn->is_websocket)
		{
			auto connection = (WebSocketConnection*)conn->connection_param;
			connections->erase(connection->connectionNumber);
			WebSocketDisconnected(connection->connectionNumber);
			delete connection;
		}
		return MG_TRUE;
	default:
		return MG_FALSE;
	}
}

bool WebServer::SendWebSocketMessage(int recipient, String ^message)
{
	auto it = connections->find(recipient);
	if (it != connections->end())
	{
		mg_websocket_printf(it->second->connection, WEBSOCKET_OPCODE_TEXT, MakeCString(message));
		return true;
	}
	return false;
}

String ^WebServer::GetUrl()
{
	const char *port = mg_get_option(server, "listening_port");
	bool showPort = strcmp(port, "80") != 0;

	String ^url = GetLocalIP();

	if (showPort)
	{
		url += ":";
		url += gcnew String(port);
	}

	return url;
}


String ^WebServer::GetLocalIP()
{
#ifdef WIN32
	WSADATA wsaData;
	WORD wVersionRequested = MAKEWORD(2, 0); // previously was 1, 1

	if (::WSAStartup(wVersionRequested, &wsaData) != 0)
		return gcnew String("ERROR_NO_WINSOCK");

	char hostname[255];
	if (gethostname(hostname, sizeof(hostname)) == SOCKET_ERROR)
	{
		WSACleanup();
		return gcnew String("ERROR_GET_HOST");
	}

	struct hostent *host = gethostbyname(hostname);

	if (!host)
	{
		WSACleanup();
		return gcnew String("ERROR_NO_HOST");
	}

	char *ip = inet_ntoa(*(struct in_addr *)host->h_addr);

	WSACleanup();

	return gcnew String(ip);
#else
	return gcnew String("ERROR_NO_WIN32");
#endif
}