using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuizBuzz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        WebServer server;
        SortedList<int, ConnectionInfo> connections;

        private void Form1_Load(object sender, EventArgs e)
        {
            connections = new SortedList<int, ConnectionInfo>();
            InitializeServer();
            DisplayUrl();
            server.Start();
            colSound.DataSource = GetSounds();
            canBuzzIn = true;

            connections.Add(1, new ConnectionInfo() { Name = "blah" });
            connections.Add(2, new ConnectionInfo() { Name = "blah2" });

            gridBuzzers.AutoGenerateColumns = false;
            var bindingSource = new BindingSource();
            bindingSource.DataSource = connections.Values;
            gridBuzzers.DataSource = bindingSource;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            server.Stop();
        }

        private void InitializeServer()
        {
            server = new WebServer();
#if DEBUG
            server.SetOption("document_root", "../../../WebRoot");
#else
            server.SetOption("document_root", "WebRoot");
#endif
            if (!string.IsNullOrEmpty(server.SetOption("listening_port", "80"))
             && !string.IsNullOrEmpty(server.SetOption("listening_port", "8080")))
                server.SetOption("listening_port", "0"); // auto-allocate a port

            server.WebSocketConnected += server_WebSocketConnected;
            server.WebSocketDisconnected += server_WebSocketDisconnected;
            server.WebSocketMessageReceived += server_WebSocketMessageReceived;
        }

        void server_WebSocketConnected(int id)
        {
            Console.WriteLine("{0} Connected", id);
            connections.Add(id, new ConnectionInfo());
        }

        void server_WebSocketDisconnected(int id)
        {
            Console.WriteLine("{0} Disconnected", id);
            connections.Remove(id);
        }

        bool canBuzzIn;
        void server_WebSocketMessageReceived(int id, string message)
        {
            Console.WriteLine("{0} sent: {1}", id, message);

            if (message.StartsWith("name "))
            {
                connections[id].Name = message.Substring(5).Trim();
            }
            else if (message == "buzz" && canBuzzIn)
            {
                canBuzzIn = false;
                foreach (var conn in connections)
                    server.SendWebSocketMessage(conn.Key, conn.Key == id ? "win" : "lose");

                var timer = new Timer();
                timer.Interval = 5000; // TODO: add a "quick" mode or other way of having this reduced, for introductory purposes. Also have a "manual" mode, with a button to re-allow.
                timer.Tick += (o, e) =>
                {
                    AllowBuzzIn();
                    timer.Stop();
                };
                timer.Start();
            }
        }

        private void AllowBuzzIn()
        {
            foreach (var conn in connections)
                server.SendWebSocketMessage(conn.Key, "ready");
            canBuzzIn = true;
        }

        private void DisplayUrl()
        {
            lblAddress.Text = server.GetUrl();
        }

        private IList<string> GetSounds()
        {
            var sounds = new List<string>();
            sounds.Add("Sound 1");
            sounds.Add("Sound 2");
            sounds.Add("Sound 3");
            return sounds;
        }
    }
}
