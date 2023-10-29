using System.Configuration;
using OBSWebsocketDotNet;

namespace CHOSS
{
    public partial class CHOSS : Form
    {

        protected OBSWebsocket obs;
        bool stayConnected = false;
        string ip = "";
        string port = "4455";
        string password = "";
        string csTxtPath;
        long oldTxtSize = 0;
        long csTxtSize = 0;
        private CancellationTokenSource keepAliveTokenSource;
        private readonly int keepAliveInterval = 500;

        public CHOSS()
        {
            InitializeComponent();

            obs = new OBSWebsocket();

            obs.Connected += onConnect;
            obs.Disconnected += onDisconnect;

        }

        private void FileChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                var info = new FileInfo(e.FullPath);
                csTxtSize = info.Length;

                if (csTxtSize > 0 && obs.IsConnected)
                {
                    obs.SetCurrentProgramScene(gameSceneBox.Text);
                }
                else if (obs.IsConnected)
                {
                    obs.SetCurrentProgramScene(menuSceneBox.Text);
                }
            }
        }

        private void onConnect(object sender, EventArgs e)
        {
            keepAliveTokenSource = new CancellationTokenSource();
            CancellationToken keepAliveToken = keepAliveTokenSource.Token;

            btnStartStop.Text = "Disconnect";
            btnStartStop.Enabled = true;

            
            if (File.Exists(csTxtPath))
            {
                oldTxtSize = csTxtSize;
            }

            Task statPollKeepAlive = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(keepAliveInterval);

                    if (keepAliveToken.IsCancellationRequested)
                    {
                        break;
                    }
                }
            }, keepAliveToken, TaskCreationOptions.LongRunning, TaskScheduler.Default);

            FileInfo info;
            Task txtWatcher = Task.Factory.StartNew(() =>
            {
                while (obs.IsConnected)
                {
                    info = new FileInfo(csTxtPath);
                    csTxtSize = info.Length;

                    if (csTxtSize != oldTxtSize)
                    {
                        if (csTxtSize > 0)
                        {
                            obs.SetCurrentProgramScene(gameSceneBox.Text);
                        }
                        else
                        {
                            Thread.Sleep(650); // Wait for Clone Hero to fade to black
                            obs.SetCurrentProgramScene(menuSceneBox.Text);
                        }
                        oldTxtSize = csTxtSize;
                    }
                    Thread.Sleep(100);
                }
            });
        }
        private void onDisconnect(object sender, OBSWebsocketDotNet.Communication.ObsDisconnectionInfo e)
        {
            BeginInvoke((MethodInvoker)(() =>
            {
                if (keepAliveTokenSource != null)
                {
                    keepAliveTokenSource.Cancel();
                }

            }));
            btnStartStop.Text = "Connect";
            btnStartStop.Enabled = true;
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            DialogResult result = currentsongFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                currentsongTxtPathBox.Text = currentsongFileDialog.FileName;
            }
        }

        private void configSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (configSelectBox.SelectedIndex > 0)
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                // Console.WriteLine(configSelectBox.SelectedItem + " : " + configSelectBox.SelectedIndex.ToString());

                // Load `currentsong.txt` path from config
                var songTxtPaths = config.AppSettings.Settings["songTxtPaths"].Value;

                if (songTxtPaths != null)
                {
                    var paths = songTxtPaths.Split(new char[] { ';' });
                    if (paths.Length > configSelectBox.SelectedIndex)
                    {
                        currentsongTxtPathBox.Text = paths[configSelectBox.SelectedIndex];
                        currentsongFileDialog.InitialDirectory = paths[configSelectBox.SelectedIndex].Replace("currentsong.txt", "", StringComparison.OrdinalIgnoreCase);
                    }
                }

                // Save config
                config.AppSettings.Settings["selectedConfig"].Value = configSelectBox.Text;
                config.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private void CHOSS_Load(object sender, EventArgs e)
        {
            // Load configuration from last time the program was loaded
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var selectedConfigTxt = config.AppSettings.Settings["selectedConfig"].Value;
            if (selectedConfigTxt != null)
            {
                configSelectBox.Text = selectedConfigTxt;
            }
            // Load websocket settings
            var wsIP = config.AppSettings.Settings["websocketIP"].Value;
            var wsPort = config.AppSettings.Settings["websocketPort"].Value;
            if (wsIP != null && wsPort != null)
            {
                ipBox.Text = wsIP;
                portBox.Text = wsPort;
                var wsPass = config.AppSettings.Settings["websocketPass"].Value;
                if (wsPass != null)
                    passBox.Text = wsPass;
            }
            // Load scene names
            var gameScene = config.AppSettings.Settings["gameScene"].Value;
            var menuScene = config.AppSettings.Settings["menuScene"].Value;
            if ((gameScene != null) && (menuScene != null))
            {
                gameSceneBox.Text = gameScene;
                menuSceneBox.Text = menuScene;
            }
        }

        private void saveConfigButton_Click(object sender, EventArgs e)
        {
            if (configSelectBox.SelectedIndex > 0)
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                // Console.WriteLine(configSelectBox.SelectedItem + " : " + configSelectBox.SelectedIndex.ToString());

                // Load `currentsong.txt` path from config
                var songTxtPaths = config.AppSettings.Settings["songTxtPaths"].Value;

                if (songTxtPaths != null)
                {
                    var paths = songTxtPaths.Split(new char[] { ';' });
                    string newPaths = "";
                    for (int i = 0; i < paths.Length; i++)
                    {
                        if (i == configSelectBox.SelectedIndex)
                        {
                            newPaths += currentsongTxtPathBox.Text + ";";
                        }
                        else
                        {
                            newPaths += paths[i] + ";";
                        }
                    }
                    newPaths = newPaths.Substring(0, newPaths.Length - 1);
                    if (newPaths.Length != 0)
                    {
                        // Save config
                        config.AppSettings.Settings["songTxtPaths"].Value = newPaths;
                        config.AppSettings.Settings["websocketIP"].Value = ipBox.Text;
                        config.AppSettings.Settings["websocketPort"].Value = portBox.Text;
                        config.AppSettings.Settings["websocketPass"].Value = passBox.Text;
                        config.AppSettings.Settings["gameScene"].Value = gameSceneBox.Text;
                        config.AppSettings.Settings["menuScene"].Value = menuSceneBox.Text;
                        config.Save();
                        ConfigurationManager.RefreshSection("appSettings");
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(((LinkLabel)sender).Text);
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            csTxtPath = Path.GetFullPath(currentsongTxtPathBox.Text);
            if (btnStartStop.Enabled && csTxtPath != "")
            {
                if (File.Exists(csTxtPath))
                {
                    if (!obs.IsConnected)
                    {
                        ip = ipBox.Text;
                        port = portBox.Text;
                        password = passBox.Text;
                        wsGroupBox.Enabled = false;
                        btnStartStop.Text = "Connecting...";
                        obs.ConnectAsync("ws://" + ip + ":" + port, password);
                    }
                    else
                    {
                        obs.Disconnect();
                        wsGroupBox.Enabled = true;
                        btnStartStop.Enabled = true;
                    }
                }
                else if (!obs.IsConnected)
                {
                    MessageBox.Show("The specified currentsong.txt file couldn't be found.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    obs.Disconnect();
                }
            }
        }

    }
}