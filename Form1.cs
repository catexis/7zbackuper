using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;

namespace _004_backuper
{
    public partial class MainForm : Form
    {
        bool flagPathZip = false;
        bool flagPathFrom = false;
        bool flagPathTo = false;
        IniData iniData = new IniData();

        public MainForm()
        {
            InitializeComponent();
            this.IniCheck();
            this.OptionsCheck();
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
        }

        private void btnChecksRescan_Click(object sender, EventArgs e)
        {
            this.OptionsCheck();
        }

        private void ChecksFolders7Zip()
        {
            IniData data = this.IniCheck();
            if ( System.IO.File.Exists( data["folders"]["7zip"] ) ) {
                lblCheck7Zip.Text = "✔ 7Zip is ok";
                lblCheck7Zip.ForeColor = System.Drawing.Color.Green;
                this.flagPathZip = true;
            } else {
                lblCheck7Zip.Text = "✘ Set path to 7Zip";
                lblCheck7Zip.ForeColor = System.Drawing.Color.Red;
                this.flagPathZip = false;
            }
        }

        private void ChecksFoldersFrom()
        {
            IniData data = this.IniCheck();
            if (System.IO.Directory.Exists(data["folders"]["from"]))
            {
                lblCheckFolderFrom.Text = "✔ Folder 'from' is ok";
                lblCheckFolderFrom.ForeColor = System.Drawing.Color.Green;
                this.flagPathFrom = true;
            }
            else
            {
                lblCheckFolderFrom.Text = "✘ Set path for backup";
                lblCheckFolderFrom.ForeColor = System.Drawing.Color.Red;
                this.flagPathFrom = false;
            }
        }

        private void ChecksFoldersTo()
        {
            IniData data = this.IniCheck();
            if (System.IO.Directory.Exists(data["folders"]["to"]))
            {
                lblCheckFolderTo.Text = "✔ Folder 'to' is ok";
                lblCheckFolderTo.ForeColor = System.Drawing.Color.Green;
                this.flagPathTo = true;
            }
            else
            {
                lblCheckFolderTo.Text = "✘ Set path to backup";
                lblCheckFolderTo.ForeColor = System.Drawing.Color.Red;
                this.flagPathTo = false;
            }
        }

        private void btnFolders7Zip_Click(object sender, EventArgs e)
        {
            IniData data = this.IniCheck();
            if (!this.flagPathZip)
            {
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
                    data["folders"]["7zip"] = dialog.FileName;
                    parser.WriteFile("options.ini", data);
                    this.ChecksFolders7Zip();
                }
            }
        }

        private void btnFoldersFrom_Click(object sender, EventArgs e)
        {
            IniData data = this.IniCheck();
            if (!this.flagPathFrom)
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                DialogResult dialogResult = dialog.ShowDialog();
                if (dialogResult == DialogResult.OK && System.IO.Directory.Exists(dialog.SelectedPath))
                {
                    var parser = new FileIniDataParser();
                    data["folders"]["from"] = dialog.SelectedPath;
                    parser.WriteFile("options.ini", data);
                    this.ChecksFoldersFrom();
                }
            }
        }
    }
}
