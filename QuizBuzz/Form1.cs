using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delay = System.Tuple<string, int>;

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
        WMPLib.WindowsMediaPlayer wplayer;
        string defaultSound;

#if DEBUG
        readonly string soundDir = new FileInfo(Application.ExecutablePath).Directory + "/../../sounds";
#else
        readonly string soundDir = new FileInfo(Application.ExecutablePath).Directory + "/sounds";
#endif

        private void Form1_Load(object sender, EventArgs e)
        {
            connections = new SortedList<int, ConnectionInfo>();
            InitializeServer();
            DisplayUrl();
            server.Start();
            colSound.DataSource = GetSounds();
            canBuzzIn = true;

            wplayer = new WMPLib.WindowsMediaPlayer();

            ddlBuzzDelay.Items.Add(new Delay("1 second", 1000));
            ddlBuzzDelay.Items.Add(new Delay("3 seconds", 3000));
            ddlBuzzDelay.Items.Add(new Delay("5 seconds", 5000));
            ddlBuzzDelay.Items.Add(new Delay("7 seconds", 5000));
            ddlBuzzDelay.Items.Add(new Delay("10 seconds", 10000));
            ddlBuzzDelay.Items.Add(new Delay("indefinite (manual)", 0));
            ddlBuzzDelay.SelectedIndex = 2;

            gridBuzzers.AutoGenerateColumns = false;
            ShowConnections();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            server.Stop();
        }

        private void InitializeServer()
        {
            server = new WebServer();
#if DEBUG
            server.SetOption("document_root", "../..");
#else
            server.SetOption("document_root", ".");
#endif
            if (!string.IsNullOrEmpty(server.SetOption("listening_port", "80"))
             && !string.IsNullOrEmpty(server.SetOption("listening_port", "8080")))
                server.SetOption("listening_port", "0"); // auto-allocate a port

            server.WebSocketConnected += server_WebSocketConnected;
            server.WebSocketDisconnected += server_WebSocketDisconnected;
            server.WebSocketMessageReceived += server_WebSocketMessageReceived;
        }

        delegate void EmptyDelegate();
        private void ShowConnections()
        {
            if (gridBuzzers.InvokeRequired)
            {
                gridBuzzers.Invoke(new EmptyDelegate(ShowConnections));
                return;
            }

            var bindingSource = new BindingSource();
            bindingSource.DataSource = connections.Values;
            gridBuzzers.DataSource = bindingSource;
        }

        void server_WebSocketConnected(int id)
        {
            Console.WriteLine("{0} Connected", id);
            connections.Add(id, new ConnectionInfo(defaultSound));
            ShowConnections();
        }

        void server_WebSocketDisconnected(int id)
        {
            Console.WriteLine("{0} Disconnected", id);
            connections.Remove(id);
            ShowConnections();
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
                HandleBuzz(id);
            }
        }

        delegate void buzzDelegate(int id);

        private void HandleBuzz(int id)
        {
            if (ddlBuzzDelay.InvokeRequired)
            {
                ddlBuzzDelay.Invoke(new buzzDelegate(HandleBuzz), id);
                return;
            }

            foreach (var conn in connections)
                server.SendWebSocketMessage(conn.Key, conn.Key == id ? "win" : "lose");

            // actually play sound
            var path = soundDir + "/" + connections[id].SoundName;
            wplayer.URL = new FileInfo(path).FullName;
            wplayer.controls.play();
            
            lnkAllowBuzzing.Visible = true; // always allow resetting early

            var delay = (ddlBuzzDelay.SelectedItem as Delay).Item2;
            if (delay > 0)
            {
                var timer = new Timer();
                timer.Interval = delay;
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
            lnkAllowBuzzing.Visible = false;
        }

        private void DisplayUrl()
        {
            lblAddress.Text = server.GetUrl();
        }

        private IList<string> GetSounds()
        {
            var sounds = new List<string>();
            DirectoryInfo di = new DirectoryInfo(soundDir);
            var files = di.GetFiles();

            foreach (var file in files)
                sounds.Add(file.Name);

            defaultSound = sounds.First();
            return sounds;
        }

        private void lnkAllowBuzzing_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AllowBuzzIn();
        }
    }
}
