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

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeServer();
            DisplayUrl();
            server.Start();
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

            server.WebSocketConnected += (i) => Console.WriteLine("{0} Connected", i);
            server.WebSocketDisconnected += (i) => Console.WriteLine("{0} Disconnected", i);
            server.WebSocketMessageReceived += (i, m) => Console.WriteLine("{0} sent: {1}", i, m);
        }

        private void DisplayUrl()
        {
            lblAddress.Text = server.GetUrl();
        }
    }
}
