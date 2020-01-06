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
        public MainForm()
        {
            this.IniCheck();
            InitializeComponent();
        }

        private void IniCheck()
        {
            try
            {
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile("options.ini");

                string pathZip = data["folders"]["7zip"];
                string pathFrom = data["folders"]["from"];
                string pathTo = data["folders"]["to"];

                if (pathZip !="")
                {
                    Console.WriteLine("Zip not empty");
                }
                else
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

                    }
                    bool debug_point = true;
                };

            }
            catch (IniParser.Exceptions.ParsingException)
            {
                var result = MessageBox.Show(
                        "Отсутствует конфигурационный файл options.ini",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                System.Environment.Exit(1);
            };
        }

        private void btnFolders7Zip_Click(object sender, EventArgs e)
        {
            lblCheck7Zip.Text = "7-Zip checked!";
        }
    }
}
