#pragma once

#include <msclr/marshal.h>
#include <map>

using namespace System;
using namespace System::Threading;
using namespace msclr::interop;

struct mg_server;

class WebSocketConnection
{
public:
	WebSocketConnection(int num, mg_connection *con) { connectionNumber = num; connection = con; }
	int connectionNumber;
	mg_connection *connection;
};

public ref class WebServer
{
public:
	WebServer();
	~WebServer();

	String ^GetOption(String ^option);
	String ^SetOption(String ^option, String ^value);
	
	void Start();
	void Stop();

	int HandleEvent(mg_connection *conn, enum mg_event ev);
	static WebServer ^Instance;

	delegate void ConnectionDelegate(int);
	event ConnectionDelegate^ WebSocketConnected;
	event ConnectionDelegate^ WebSocketDisconnected;

	delegate void MessageDelegate(int, String ^);
	event MessageDelegate ^WebSocketMessageReceived;

	void SendWebSocketMessage(int connection, String ^message);
	String ^GetUrl();
private:
	void Poll();
	String ^GetLocalIP();
	const char *MakeCString(String ^string);

	marshal_context ^context;
	mg_server *server;

	std::map<int, WebSocketConnection*> *connections;
	int nextConnectionID;

	Thread ^pollThread;
};
