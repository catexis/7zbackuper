﻿using System;
using System.Timers;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;


namespace _backuper
{
    public partial class MainForm : Form
    {
        IniData iniData = new IniData();
        // Timers
        private static System.Timers.Timer aTimer;
        private System.Windows.Forms.Timer countdownTimer;
        private System.Windows.Forms.Timer archiveWatchDogTimer;
        // Options
        private Int32 runEvery = 0;
        private bool serviceStatus = false;
        private bool pathStatus7z = false;
        private bool pathStatusFrom = false;
        private bool pathStatusTo = false;

        public MainForm()
        {
            InitializeComponent();
            this.IniCheck();
            this.OptionsCheck();
            this.OptionsWatchDogRun();
        }

        private string GetLastBackupFile()
        {
            IniData data = this.IniCheck();
            DateTime fileDateTimeCreationNewest = new DateTime(1970, 1, 1);
            string fileBackupNewest = "";
            string pathTo = data["folders"]["to"];
            if (System.IO.Directory.Exists(pathTo))
            {
                string[] filePaths = System.IO.Directory.GetFiles(pathTo, "*.7z");
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
                    long fileLengthBytes = new System.IO.FileInfo(fileBackupNewest).Length;
                    decimal fileLengthMb = fileLengthBytes / 1024 / 1024;
                    lblBackupSize.Text = String.Format("Size: {0}Mb", Math.Round(fileLengthMb, 1));
                }
            }
            else
            {
                MessageBox.Show(
                    "Can not get last backup file. Check folder 'to'.",
                    "Error",
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
                    "There is no options.ini file",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                DialogResult result = MessageBox.Show(
                    "Create file options.ini for you?",
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
                    data["cleanup"]["countofarchive"] = "3"; // Count of archive in folder 'to'
                    // a - archiving
                    // ssw - archive even files open
                    // mx5 - compression rate
                    data["zip_command"]["zip_args"] = "a -ssw -mx7";

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
            if (!serviceStatus)
            { 
                this.ChecksServiceRunEvery();
            }
            if (this.pathStatus7z && this.pathStatusFrom && this.pathStatusTo)
            {
                this.GetLastBackupFile();
            }
        }

        private void btnChecksRescan_Click(object sender, EventArgs e)
        {
            this.OptionsCheck();
        }

        private void ChecksServiceRunEvery()
        {
            IniData data = this.IniCheck();
            string runEveryFromIni = data["service"]["every"];
            if (!String.IsNullOrEmpty(runEveryFromIni))
            {
                lblServiceRunEveryValue.Text = runEveryFromIni;
                runEvery = Int32.Parse(runEveryFromIni) * 60000; // In milliseconds
            }
            else
            {
                var parser = new FileIniDataParser();
                data["service"]["every"] = "10";
                parser.WriteFile("options.ini", data);
                this.iniData = data;
            }
        }

        private void ChecksFolders7Zip()
        {
            IniData data = this.IniCheck();
            if ( System.IO.Directory.Exists(data["folders"]["7zip"])) {
                lblCheck7Zip.Text = "✔ 7Zip is ok";
                lblCheck7Zip.ForeColor = System.Drawing.Color.Green;
                this.pathStatus7z = true;
            } else {
                lblCheck7Zip.Text = "✘ Set path to 7Zip";
                lblCheck7Zip.ForeColor = System.Drawing.Color.Red;
                this.pathStatus7z = false;
            }
        }

        private void ChecksFoldersFrom()
        {
            IniData data = this.IniCheck();
            if (System.IO.Directory.Exists(data["folders"]["from"]))
            {
                lblCheckFolderFrom.Text = "✔ Folder 'from' is ok";
                lblCheckFolderFrom.ForeColor = System.Drawing.Color.Green;
                this.pathStatusFrom = true;
            }
            else
            {
                lblCheckFolderFrom.Text = "✘ Set path for backup";
                lblCheckFolderFrom.ForeColor = System.Drawing.Color.Red;
                this.pathStatusFrom = false;
            }
        }

        private void ChecksFoldersTo()
        {
            IniData data = this.IniCheck();
            if (System.IO.Directory.Exists(data["folders"]["to"]))
            {
                lblCheckFolderTo.Text = "✔ Folder 'to' is ok";
                lblCheckFolderTo.ForeColor = System.Drawing.Color.Green;
                this.pathStatusTo = true;
            }
            else
            {
                lblCheckFolderTo.Text = "✘ Set path to backup";
                lblCheckFolderTo.ForeColor = System.Drawing.Color.Red;
                this.pathStatusTo = false;
            }
        }

        private void btnFolders7ZipOpen_Click(object sender, EventArgs e)
        {
            try
            {
                IniData data = this.IniCheck();
                string pathZip = data["folders"]["7zip"];
                if (!String.IsNullOrEmpty(pathZip) && System.IO.Directory.Exists(pathZip))
                {
                    System.Diagnostics.Process.Start("explorer.exe", pathZip);
                }
                else
                {
                    MessageBox.Show(
                        "Wrong path to archiver",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch
            {
                MessageBox.Show(
                    "Wrong path to archiver",
                    "Error",
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
                    "Wrong path to archiver",
                    "Error",
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
                    if (!String.IsNullOrEmpty(pathFrom) && System.IO.Directory.Exists(pathFrom))
                    {
                        System.Diagnostics.Process.Start("explorer.exe", pathFrom);
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Wrong path. Check folder 'from'.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch
            {
                MessageBox.Show(
                    "Wrong path. Check folder 'from'.",
                    "Error",
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
                    "Wrong path. Check folder 'from'.",
                    "Error",
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
                if (!String.IsNullOrEmpty(pathTo) && System.IO.Directory.Exists(pathTo))
                {
                    System.Diagnostics.Process.Start("explorer.exe", pathTo.ToString());
                }
                else
                {
                    MessageBox.Show(
                        "Wrong path. Check folder 'to'.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch
            {
                MessageBox.Show(
                    "Wrong path. Check folder 'to'.",
                    "Error",
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
                this.ChecksFoldersTo();
            }
            if (!System.IO.Directory.Exists(dialog.SelectedPath))
            {
                MessageBox.Show(
                    "Wrong path. Check folder 'to'.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private string BackupCreate()
        {
            
            string fileNewArchiveName = String.Format("{0}.7z", DateTime.Now.ToString("yyyy'_'MM'_'dd'_'HH'_'mm'_'ss"));
            string fileArchiveFullPath = "";
            IniData data = this.IniCheck();
            try
            {
                string zipArgs = data["zip_command"]["zip_args"];
                if (zipArgs == null || zipArgs == "")
                {
                    var parser = new FileIniDataParser();
                    data["zip_command"]["zip_args"] = "a -ssw -mx7";
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
                    "Fail for backup creation. Check options.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return fileArchiveFullPath;
        }

        private void btnBackupRun_Click(object sender, EventArgs e)
        {
            this.OptionsCheck();
            if (this.pathStatus7z && this.pathStatusFrom && this.pathStatusTo)
            {
                bool successBackupCreation = false;            
                btnBackupRun.Enabled = false;
                try
                {
                    this.BackupCreate();
                    successBackupCreation = true;
                }
                catch
                {
                    Console.WriteLine("Fail for backup creation.");
                }
                if (successBackupCreation)
                {
                    this.CleanUp();
                }
                btnBackupRun.Enabled = true;
                this.OptionsCheck();
            }
            else
            {
                MessageBox.Show(
                    "Fail for run backup operation. Check options.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void SetTimer()
        {
            IniData data = this.IniCheck();
            this.ChecksServiceRunEvery();
            aTimer = new System.Timers.Timer(runEvery);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            this.BackupCreate();
            this.CleanUp();
            icnTrayIcon.BalloonTipIcon = ToolTipIcon.Info;
            icnTrayIcon.BalloonTipText = "New backup created!";
            icnTrayIcon.BalloonTipTitle = "New backup";
            icnTrayIcon.ShowBalloonTip(2000);
        }

        private void OptionsWatchDogRun()
        {
            archiveWatchDogTimer = new System.Windows.Forms.Timer();
            archiveWatchDogTimer.Tick += new EventHandler(archiveWatchDogTimer_Tick);
            archiveWatchDogTimer.Interval = 5000;
            archiveWatchDogTimer.Start();
        }

        private void btnServiceRun_Click(object sender, EventArgs e)
        {
            this.OptionsCheck();
            if (this.pathStatus7z && this.pathStatusFrom && this.pathStatusTo)
            {
                if (!this.serviceStatus)
                {
                    SetTimer();
                    btnServiceRun.Text = "Service stop";
                    lblServiceStatus.Text = "running";
                    lblServiceStatus.ForeColor = System.Drawing.Color.Green;
                    this.serviceStatus = true;

                    countdownTimer = new System.Windows.Forms.Timer();
                    countdownTimer.Tick += new EventHandler(timer1_Tick);
                    countdownTimer.Interval = 1000; // 1 second
                    countdownTimer.Start();
                    TimeSpan ts = TimeSpan.FromMilliseconds(runEvery);
                    lblServiceCoutdownValue.Text = String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
                    lblServiceCoutdownValue.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    aTimer.Stop();
                    countdownTimer.Stop();
                    btnServiceRun.Text = "Service run";
                    lblServiceStatus.Text = "stoped";
                    lblServiceStatus.ForeColor = System.Drawing.Color.Gray;
                    lblServiceCoutdownValue.Text = runEvery.ToString();
                    lblServiceCoutdownValue.ForeColor = System.Drawing.Color.Gray;
                    this.serviceStatus = false;
                    this.ChecksServiceRunEvery();
                    TimeSpan ts = TimeSpan.FromMilliseconds(runEvery);
                    lblServiceCoutdownValue.Text = String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
                }
            }
            else
            {
                MessageBox.Show(
                    "Fail for run backup service. Check options.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // runEvery in milliseconds
            runEvery = runEvery - 1000;
            if (runEvery == 0) { 
                countdownTimer.Stop();
                this.OptionsCheck();
                this.ChecksServiceRunEvery();
                countdownTimer.Start();
            }
            TimeSpan ts = TimeSpan.FromMilliseconds(runEvery);
            lblServiceCoutdownValue.Text = String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
        }

        private void archiveWatchDogTimer_Tick(object sender, EventArgs e)
        {
            this.OptionsCheck();
        }

        private void CleanUp()
        {
            IniData data = this.IniCheck();
            Int32 archiveCount = 0;
            string[] fileNamesOldFiles = new string[0];
            if (!String.IsNullOrEmpty(data["cleanup"]["countofarchive"]))
            {
                archiveCount = Int32.Parse(data["cleanup"]["countofarchive"]);
            }
            else
            {
                var parser = new FileIniDataParser();
                data["cleanup"]["countofarchive"] = "3";
                parser.WriteFile("options.ini", data);
                archiveCount = Int32.Parse(data["cleanup"]["countofarchive"]);
            }
            string pathTo = data["folders"]["to"];
            string[] fileNames = System.IO.Directory.GetFiles(pathTo, "*.7z");
            DateTime[] creationTimes = new DateTime[fileNames.Length];
            for (int i = 0; i < fileNames.Length; i++)
            {
                creationTimes[i] = new System.IO.FileInfo(fileNames[i]).CreationTime;
            }
            Array.Sort(creationTimes, fileNames);
            Array.Reverse(fileNames);
            if (fileNames.Length > archiveCount)
            {
                fileNamesOldFiles = new string[fileNames.Length - archiveCount];
                for (int i=archiveCount; i<fileNames.Length; i++)
                {
                    fileNamesOldFiles[i - archiveCount] = fileNames[i];
                }
            }
            if (fileNamesOldFiles.Length > 0)
            {
                for (int i=0; i<fileNamesOldFiles.Length; i++)
                {
                    System.IO.File.Delete(fileNamesOldFiles[i]);
                }
            }
        }

        private void btnIniOpen_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("options.ini");
        }
    }
}
