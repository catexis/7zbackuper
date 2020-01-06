namespace _004_backuper
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpChecks = new System.Windows.Forms.GroupBox();
            this.lblCheckFolderTo = new System.Windows.Forms.Label();
            this.lblCheckFolderFrom = new System.Windows.Forms.Label();
            this.lblCheck7Zip = new System.Windows.Forms.Label();
            this.grpFolders = new System.Windows.Forms.GroupBox();
            this.btnFoldersTo = new System.Windows.Forms.Button();
            this.btnFoldersFrom = new System.Windows.Forms.Button();
            this.btnFolders7Zip = new System.Windows.Forms.Button();
            this.grpLastBackup = new System.Windows.Forms.GroupBox();
            this.lblBackupFileTime = new System.Windows.Forms.Label();
            this.lblBackupFileName = new System.Windows.Forms.Label();
            this.grpAsService = new System.Windows.Forms.GroupBox();
            this.btnBackupRun = new System.Windows.Forms.Button();
            this.grpChecks.SuspendLayout();
            this.grpFolders.SuspendLayout();
            this.grpLastBackup.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpChecks
            // 
            this.grpChecks.Controls.Add(this.lblCheckFolderTo);
            this.grpChecks.Controls.Add(this.lblCheckFolderFrom);
            this.grpChecks.Controls.Add(this.lblCheck7Zip);
            this.grpChecks.Location = new System.Drawing.Point(12, 12);
            this.grpChecks.Name = "grpChecks";
            this.grpChecks.Size = new System.Drawing.Size(185, 100);
            this.grpChecks.TabIndex = 0;
            this.grpChecks.TabStop = false;
            this.grpChecks.Text = "Checks";
            // 
            // lblCheckFolderTo
            // 
            this.lblCheckFolderTo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCheckFolderTo.Location = new System.Drawing.Point(3, 66);
            this.lblCheckFolderTo.Margin = new System.Windows.Forms.Padding(5);
            this.lblCheckFolderTo.Name = "lblCheckFolderTo";
            this.lblCheckFolderTo.Size = new System.Drawing.Size(179, 25);
            this.lblCheckFolderTo.TabIndex = 2;
            this.lblCheckFolderTo.Text = "Folder \'to\'";
            this.lblCheckFolderTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCheckFolderFrom
            // 
            this.lblCheckFolderFrom.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCheckFolderFrom.Location = new System.Drawing.Point(3, 41);
            this.lblCheckFolderFrom.Margin = new System.Windows.Forms.Padding(5);
            this.lblCheckFolderFrom.Name = "lblCheckFolderFrom";
            this.lblCheckFolderFrom.Size = new System.Drawing.Size(179, 25);
            this.lblCheckFolderFrom.TabIndex = 1;
            this.lblCheckFolderFrom.Text = "Folder \'from\'";
            this.lblCheckFolderFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCheck7Zip
            // 
            this.lblCheck7Zip.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCheck7Zip.Location = new System.Drawing.Point(3, 16);
            this.lblCheck7Zip.Margin = new System.Windows.Forms.Padding(5);
            this.lblCheck7Zip.Name = "lblCheck7Zip";
            this.lblCheck7Zip.Size = new System.Drawing.Size(179, 25);
            this.lblCheck7Zip.TabIndex = 0;
            this.lblCheck7Zip.Text = "7-Zip";
            this.lblCheck7Zip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpFolders
            // 
            this.grpFolders.Controls.Add(this.btnFoldersTo);
            this.grpFolders.Controls.Add(this.btnFoldersFrom);
            this.grpFolders.Controls.Add(this.btnFolders7Zip);
            this.grpFolders.Location = new System.Drawing.Point(203, 12);
            this.grpFolders.Name = "grpFolders";
            this.grpFolders.Size = new System.Drawing.Size(185, 100);
            this.grpFolders.TabIndex = 1;
            this.grpFolders.TabStop = false;
            this.grpFolders.Text = "Folders";
            // 
            // btnFoldersTo
            // 
            this.btnFoldersTo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFoldersTo.Location = new System.Drawing.Point(3, 66);
            this.btnFoldersTo.Margin = new System.Windows.Forms.Padding(5);
            this.btnFoldersTo.Name = "btnFoldersTo";
            this.btnFoldersTo.Size = new System.Drawing.Size(179, 25);
            this.btnFoldersTo.TabIndex = 2;
            this.btnFoldersTo.Text = "To";
            this.btnFoldersTo.UseVisualStyleBackColor = true;
            // 
            // btnFoldersFrom
            // 
            this.btnFoldersFrom.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFoldersFrom.Location = new System.Drawing.Point(3, 41);
            this.btnFoldersFrom.Margin = new System.Windows.Forms.Padding(5);
            this.btnFoldersFrom.Name = "btnFoldersFrom";
            this.btnFoldersFrom.Size = new System.Drawing.Size(179, 25);
            this.btnFoldersFrom.TabIndex = 1;
            this.btnFoldersFrom.Text = "From";
            this.btnFoldersFrom.UseVisualStyleBackColor = true;
            // 
            // btnFolders7Zip
            // 
            this.btnFolders7Zip.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFolders7Zip.Location = new System.Drawing.Point(3, 16);
            this.btnFolders7Zip.Margin = new System.Windows.Forms.Padding(5);
            this.btnFolders7Zip.Name = "btnFolders7Zip";
            this.btnFolders7Zip.Size = new System.Drawing.Size(179, 25);
            this.btnFolders7Zip.TabIndex = 0;
            this.btnFolders7Zip.Text = "7-Zip";
            this.btnFolders7Zip.UseVisualStyleBackColor = true;
            this.btnFolders7Zip.Click += new System.EventHandler(this.btnFolders7Zip_Click);
            // 
            // grpLastBackup
            // 
            this.grpLastBackup.Controls.Add(this.lblBackupFileTime);
            this.grpLastBackup.Controls.Add(this.lblBackupFileName);
            this.grpLastBackup.Location = new System.Drawing.Point(203, 118);
            this.grpLastBackup.Name = "grpLastBackup";
            this.grpLastBackup.Size = new System.Drawing.Size(185, 100);
            this.grpLastBackup.TabIndex = 2;
            this.grpLastBackup.TabStop = false;
            this.grpLastBackup.Text = "Last backup";
            // 
            // lblBackupFileTime
            // 
            this.lblBackupFileTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBackupFileTime.Location = new System.Drawing.Point(3, 41);
            this.lblBackupFileTime.Margin = new System.Windows.Forms.Padding(5);
            this.lblBackupFileTime.Name = "lblBackupFileTime";
            this.lblBackupFileTime.Size = new System.Drawing.Size(179, 25);
            this.lblBackupFileTime.TabIndex = 1;
            this.lblBackupFileTime.Text = "File time";
            this.lblBackupFileTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBackupFileName
            // 
            this.lblBackupFileName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBackupFileName.Location = new System.Drawing.Point(3, 16);
            this.lblBackupFileName.Margin = new System.Windows.Forms.Padding(5);
            this.lblBackupFileName.Name = "lblBackupFileName";
            this.lblBackupFileName.Size = new System.Drawing.Size(179, 25);
            this.lblBackupFileName.TabIndex = 0;
            this.lblBackupFileName.Text = "File name";
            this.lblBackupFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpAsService
            // 
            this.grpAsService.Location = new System.Drawing.Point(12, 224);
            this.grpAsService.Name = "grpAsService";
            this.grpAsService.Size = new System.Drawing.Size(376, 100);
            this.grpAsService.TabIndex = 3;
            this.grpAsService.TabStop = false;
            this.grpAsService.Text = "As service";
            // 
            // btnBackupRun
            // 
            this.btnBackupRun.Location = new System.Drawing.Point(12, 118);
            this.btnBackupRun.Name = "btnBackupRun";
            this.btnBackupRun.Size = new System.Drawing.Size(182, 100);
            this.btnBackupRun.TabIndex = 4;
            this.btnBackupRun.Text = "Run backup";
            this.btnBackupRun.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(399, 333);
            this.Controls.Add(this.btnBackupRun);
            this.Controls.Add(this.grpAsService);
            this.Controls.Add(this.grpLastBackup);
            this.Controls.Add(this.grpFolders);
            this.Controls.Add(this.grpChecks);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "7-Zip Backuper";
            this.grpChecks.ResumeLayout(false);
            this.grpFolders.ResumeLayout(false);
            this.grpLastBackup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpChecks;
        private System.Windows.Forms.GroupBox grpFolders;
        private System.Windows.Forms.Label lblCheckFolderTo;
        private System.Windows.Forms.Label lblCheckFolderFrom;
        private System.Windows.Forms.Label lblCheck7Zip;
        private System.Windows.Forms.Button btnFoldersTo;
        private System.Windows.Forms.Button btnFoldersFrom;
        private System.Windows.Forms.Button btnFolders7Zip;
        private System.Windows.Forms.GroupBox grpLastBackup;
        private System.Windows.Forms.Label lblBackupFileTime;
        private System.Windows.Forms.Label lblBackupFileName;
        private System.Windows.Forms.GroupBox grpAsService;
        private System.Windows.Forms.Button btnBackupRun;
    }
}

