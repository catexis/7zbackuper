using System;
using System.Timers;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;


namespace _004_backuper
{
    public partial class MainForm : Form
    {
        IniData iniData = new IniData();
        private static System.Timers.Timer aTimer;
        private System.Windows.Forms.Timer timer1;
        private int runEvery = 0;
        private bool serviceStatus = false;

        public MainForm()
        {
            InitializeComponent();
            this.IniCheck();
            this.OptionsCheck();
            this.GetLastBackupFile();
        }

        private string GetLastBackupFile()
        {
            IniData data = this.IniCheck();
            DateTime fileDateTimeCreationNewest = new DateTime(1970, 1, 1);
            string fileBackupNewest = "";
            string pathTo = data["folders"]["to"];
            if (System.IO.Directory.Exists(pathTo))
            {
                string[] filePaths = System.IO.Directory.GetFiles(pathTo, "*.zip");
                if (filePaths.Length == 0)
                {
                    lblBackupFileName.Text = "No backups yet";
                    lblBackupFileTime.Text = "";
                    lblBackupFilesTotal.Text = "Total: 0";
                }
                else
                {
                    lblBackupFilesTotal.Text = String.Format("Total: {0}", filePaths.Length);
                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        DateTime fileDateTimeCreationCurrent = System.IO.File.GetCreationTime(filePaths[i]);
                        if (fileDateTimeCreationCurrent > fileDateTimeCreationNewest)
                        {
                            fileBackupNewest = filePaths[i];
                            fileDateTimeCreationNewest = fileDateTimeCreationCurrent;
                        }
                    }
                    lblBackupFileName.Text = System.IO.Path.GetFileName(fileBackupNewest);
                    lblBackupFileTime.Text = fileDateTimeCreationNewest.ToString("yyyy'/'MM'/'dd HH:mm");
                }
            }
            else
            {
                MessageBox.Show(
                    "Задан неверный путь к папке КУДА надо делать backup",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                fileBackupNewest = "";
            }
            return fileBackupNewest;
        }

        private IniData IniCheck()
        {
            try
            {
                var parser = new FileIniDataParser();
                this.iniData = parser.ReadFile("options.ini");
            }
            catch (IniParser.Exceptions.ParsingException)
            {
                MessageBox.Show(
                    "Отсутствует конфигурационный файл options.ini",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                DialogResult result = MessageBox.Show(
                    "Создать конфигурационный файл options.ini?",
                    "options.ini",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes) {
                    var parser = new FileIniDataParser();
                    IniData data = new IniData();
                    data["folders"]["7zip"] = "";
                    data["folders"]["from"] = "";
                    data["folders"]["to"] = "";
                    data["service"]["every"] = "10";
                    // a - archiving
                    // tzip - to zip format
                    // ssw - archive even files open
                    // mx5 - compression rate
                    data["zip_command"]["zip_args"] = "a -tzip -ssw -mx5";

                    parser.WriteFile("options.ini", data);
                    this.iniData = data;
                } else {
                    System.Environment.Exit(1);
                }
            };
            return this.iniData;
        }

        private void OptionsCheck()
        {
            this.ChecksFolders7Zip();
            this.ChecksFoldersFrom();
            this.ChecksFoldersTo();
            this.ChecksServiceRunEvery();
            this.GetLastBackupFile();
        }

        private void btnChecksRescan_Click(object sender, EventArgs e)
        {
            this.OptionsCheck();
        }

        private void ChecksServiceRunEvery()
        {
            IniData data = this.IniCheck();
            string runEveryFromIni = data["service"]["every"];
            lblServiceRunEveryValue.Text = runEveryFromIni;
            runEvery = Int16.Parse(runEveryFromIni);
        }

        private void ChecksFolders7Zip()
        {
            IniData data = this.IniCheck();
            if ( System.IO.Directory.Exists(data["folders"]["7zip"])) {
                lblCheck7Zip.Text = "✔ 7Zip is ok";
                lblCheck7Zip.ForeColor = System.Drawing.Color.Green;
            } else {
                lblCheck7Zip.Text = "✘ Set path to 7Zip";
                lblCheck7Zip.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ChecksFoldersFrom()
        {
            IniData data = this.IniCheck();
            if (System.IO.Directory.Exists(data["folders"]["from"]))
            {
                lblCheckFolderFrom.Text = "✔ Folder 'from' is ok";
                lblCheckFolderFrom.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblCheckFolderFrom.Text = "✘ Set path for backup";
                lblCheckFolderFrom.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ChecksFoldersTo()
        {
            IniData data = this.IniCheck();
            if (System.IO.Directory.Exists(data["folders"]["to"]))
            {
                lblCheckFolderTo.Text = "✔ Folder 'to' is ok";
                lblCheckFolderTo.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblCheckFolderTo.Text = "✘ Set path to backup";
                lblCheckFolderTo.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnFolders7ZipOpen_Click(object sender, EventArgs e)
        {
            try
            {
                IniData data = this.IniCheck();
                string pathZip = data["folders"]["7zip"];
                if (System.IO.File.Exists(pathZip))
                {
                    System.Diagnostics.Process.Start("explorer.exe", "/select," + pathZip);
                }
            }
            catch
            {
                MessageBox.Show(
                    "Задан неверный путь к архиватору",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnFolders7ZipEdit_Click(object sender, EventArgs e)
        {
            IniData data = this.IniCheck();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select 7-Zip executable file";
            dialog.FileName = "7z";
            dialog.DefaultExt = "exe";
            dialog.Filter = "7z.exe (*.exe)|*.exe";
            dialog.InitialDirectory = @"C:\Program Files\";
            DialogResult dialogResult = dialog.ShowDialog();
            if (dialogResult == DialogResult.OK && dialog.CheckFileExists)
            {
                var parser = new FileIniDataParser();
                data["folders"]["7zip"] = System.IO.Path.GetDirectoryName(dialog.FileName);
                parser.WriteFile("options.ini", data);
                this.ChecksFolders7Zip();
            }
            if (!dialog.CheckFileExists)
            {
                MessageBox.Show(
                    "Задан неверный путь к архиватору",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnFoldersFromOpen_Click(object sender, EventArgs e)
        {
            try
            {
                IniData data = this.IniCheck();
                string pathFrom = data["folders"]["from"];
                if (pathFrom != "")
                {
                    if (System.IO.Directory.Exists(pathFrom))
                    {
                        System.Diagnostics.Process.Start("explorer.exe", pathFrom);
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Задан неверный путь к папке ОТКУДА надо делать backup",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch
            {
                MessageBox.Show(
                    "Задан неверный путь к папке ОТКУДА надо делать backup",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnFoldersFromEdit_Click(object sender, EventArgs e)
        {
            IniData data = this.IniCheck();
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult dialogResult = dialog.ShowDialog();
            if (dialogResult == DialogResult.OK && System.IO.Directory.Exists(dialog.SelectedPath))
            {
                var parser = new FileIniDataParser();
                data["folders"]["from"] = dialog.SelectedPath;
                parser.WriteFile("options.ini", data);
                this.ChecksFoldersFrom();
            }
            if (!System.IO.Directory.Exists(dialog.SelectedPath))
            {
                MessageBox.Show(
                    "Задан неверный путь к папке ОТКУДА надо делать backup",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void btnFoldersToOpen_Click(object sender, EventArgs e)
        {
            try
            {
                IniData data = this.IniCheck();
                string pathTo = data["folders"]["to"];
                if (pathTo != "")
                {
                    if (System.IO.Directory.Exists(pathTo))
                    {
                        System.Diagnostics.Process.Start("explorer.exe", pathTo.ToString());
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Задан неверный путь к папке КУДА надо делать backup",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch
            {
                MessageBox.Show(
                    "Задан неверный путь к папке КУДА надо делать backup",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        
        private void btnFoldersToEdit_Click(object sender, EventArgs e)
        {
            IniData data = this.IniCheck();
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult dialogResult = dialog.ShowDialog();
            if (dialogResult == DialogResult.OK && System.IO.Directory.Exists(dialog.SelectedPath))
            {
                var parser = new FileIniDataParser();
                data["folders"]["to"] = dialog.SelectedPath;
                parser.WriteFile("options.ini", data);
                this.ChecksFoldersFrom();
            }
            if (!System.IO.Directory.Exists(dialog.SelectedPath))
            {
                MessageBox.Show(
                    "Задан неверный путь к папке КУДА надо делать backup",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private string BackupCreate()
        {
            
            string fileNewArchiveName = String.Format("{0}.zip", DateTime.Now.ToString("yyyy'_'MM'_'dd'_'HH'_'mm'_'ss"));
            string fileArchiveFullPath = "";
            IniData data = this.IniCheck();
            try
            {
                string zipArgs = data["zip_command"]["zip_args"];
                if (zipArgs == null || zipArgs == "")
                {
                    var parser = new FileIniDataParser();
                    data["zip_command"]["zip_args"] = "a -tzip -ssw -mx5";
                    parser.WriteFile("options.ini", data);
                    zipArgs = data["zip_command"]["zip_args"];
                }
                else
                {
                    string pathZip = data["folders"]["7zip"];
                    string pathFrom = data["folders"]["from"];
                    string pathTo = data["folders"]["to"];
                    fileArchiveFullPath = '\"' + pathTo + '\\' + fileNewArchiveName + '\"';
                    System.Diagnostics.ProcessStartInfo processInfo = new System.Diagnostics.ProcessStartInfo();
                    processInfo.FileName = pathZip + "\\7z.exe";
                    processInfo.Arguments = zipArgs + " " + fileArchiveFullPath + " " + '\"' + pathFrom + '\"';
                    processInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    System.Diagnostics.Process archiveResult = System.Diagnostics.Process.Start(processInfo);
                    archiveResult.WaitForExit();
                    return fileArchiveFullPath;
                }
            }
            catch
            {
                MessageBox.Show(
                    "С архивированием что-то пошло не так",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return fileArchiveFullPath;
        }

        private void btnBackupRun_Click(object sender, EventArgs e)
        {
            btnBackupRun.Enabled = false;
            this.BackupCreate();
            btnBackupRun.Enabled = true;
            this.OptionsCheck();
        }

        private void SetTimer()
        {
            IniData data = this.IniCheck();
            // Create a timer with time in millisesonds.
            int runEvery = Int16.Parse(data["service"]["every"]);
            #if DEBUG
                aTimer = new System.Timers.Timer(10000);
            #else
                aTimer = new System.Timers.Timer(runEvery*60000);
            #endif
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            this.BackupCreate();
            icnTrayIcon.BalloonTipIcon = ToolTipIcon.Info;
            icnTrayIcon.BalloonTipText = "New backup created!";
            icnTrayIcon.BalloonTipTitle = "New backup";
            icnTrayIcon.ShowBalloonTip(2000);
        }

        private void btnServiceRun_Click(object sender, EventArgs e)
        {
            if (!this.serviceStatus)
            {
                SetTimer();
                btnServiceRun.Text = "Service stop";
                lblServiceStatus.Text = "running";
                lblServiceStatus.ForeColor = System.Drawing.Color.Green;
                this.serviceStatus = true;

                timer1 = new System.Windows.Forms.Timer();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 1000; // 1 second
                timer1.Start();
                lblServiceCoutdownValue.Text = runEvery.ToString();
                lblServiceCoutdownValue.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                aTimer.Stop();
                btnServiceRun.Text = "Service run";
                lblServiceStatus.Text = "stoped";
                lblServiceStatus.ForeColor = System.Drawing.Color.Gray;
                lblServiceCoutdownValue.Text = runEvery.ToString();
                lblServiceCoutdownValue.ForeColor = System.Drawing.Color.Gray;
                this.serviceStatus = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            runEvery--;
            if (runEvery == 0)
                timer1.Stop();
            lblServiceCoutdownValue.Text = runEvery.ToString();
        }
    }
}
