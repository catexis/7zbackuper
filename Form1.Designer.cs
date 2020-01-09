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
            this.btnFoldersToEdit = new System.Windows.Forms.Button();
            this.btnFoldersToOpen = new System.Windows.Forms.Button();
            this.lblCheckFolderTo = new System.Windows.Forms.Label();
            this.btnFoldersFromEdit = new System.Windows.Forms.Button();
            this.btnFoldersFromOpen = new System.Windows.Forms.Button();
            this.lblCheckFolderFrom = new System.Windows.Forms.Label();
            this.btnFolders7ZipEdit = new System.Windows.Forms.Button();
            this.btnFolders7ZipOpen = new System.Windows.Forms.Button();
            this.lblCheck7Zip = new System.Windows.Forms.Label();
            this.grpLastBackup = new System.Windows.Forms.GroupBox();
            this.lblBackupFileTime = new System.Windows.Forms.Label();
            this.lblBackupFileName = new System.Windows.Forms.Label();
            this.grpAsService = new System.Windows.Forms.GroupBox();
            this.lblCommingSoon = new System.Windows.Forms.Label();
            this.btnBackupRun = new System.Windows.Forms.Button();
            this.btnChecksRescan = new System.Windows.Forms.Button();
            this.lblBackupFilesTotal = new System.Windows.Forms.Label();
            this.grpChecks.SuspendLayout();
            this.grpLastBackup.SuspendLayout();
            this.grpAsService.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpChecks
            // 
            this.grpChecks.Controls.Add(this.btnFoldersToEdit);
            this.grpChecks.Controls.Add(this.btnFoldersToOpen);
            this.grpChecks.Controls.Add(this.lblCheckFolderTo);
            this.grpChecks.Controls.Add(this.btnFoldersFromEdit);
            this.grpChecks.Controls.Add(this.btnFoldersFromOpen);
            this.grpChecks.Controls.Add(this.lblCheckFolderFrom);
            this.grpChecks.Controls.Add(this.btnFolders7ZipEdit);
            this.grpChecks.Controls.Add(this.btnFolders7ZipOpen);
            this.grpChecks.Controls.Add(this.lblCheck7Zip);
            this.grpChecks.Location = new System.Drawing.Point(12, 12);
            this.grpChecks.Margin = new System.Windows.Forms.Padding(5);
            this.grpChecks.Name = "grpChecks";
            this.grpChecks.Size = new System.Drawing.Size(373, 100);
            this.grpChecks.TabIndex = 0;
            this.grpChecks.TabStop = false;
            this.grpChecks.Text = "Folders and paths";
            // 
            // btnFoldersToEdit
            // 
            this.btnFoldersToEdit.Location = new System.Drawing.Point(340, 66);
            this.btnFoldersToEdit.Margin = new System.Windows.Forms.Padding(5);
            this.btnFoldersToEdit.Name = "btnFoldersToEdit";
            this.btnFoldersToEdit.Size = new System.Drawing.Size(25, 25);
            this.btnFoldersToEdit.TabIndex = 2;
            this.btnFoldersToEdit.Text = "✎";
            this.btnFoldersToEdit.UseVisualStyleBackColor = true;
            this.btnFoldersToEdit.Click += new System.EventHandler(this.btnFoldersToEdit_Click);
            // 
            // btnFoldersToOpen
            // 
            this.btnFoldersToOpen.Location = new System.Drawing.Point(305, 66);
            this.btnFoldersToOpen.Margin = new System.Windows.Forms.Padding(5);
            this.btnFoldersToOpen.Name = "btnFoldersToOpen";
            this.btnFoldersToOpen.Size = new System.Drawing.Size(25, 25);
            this.btnFoldersToOpen.TabIndex = 2;
            this.btnFoldersToOpen.Text = "📂";
            this.btnFoldersToOpen.UseVisualStyleBackColor = true;
            this.btnFoldersToOpen.Click += new System.EventHandler(this.btnFoldersToOpen_Click);
            // 
            // lblCheckFolderTo
            // 
            this.lblCheckFolderTo.Location = new System.Drawing.Point(3, 66);
            this.lblCheckFolderTo.Margin = new System.Windows.Forms.Padding(5);
            this.lblCheckFolderTo.Name = "lblCheckFolderTo";
            this.lblCheckFolderTo.Size = new System.Drawing.Size(292, 25);
            this.lblCheckFolderTo.TabIndex = 2;
            this.lblCheckFolderTo.Text = "Folder \'to\'";
            this.lblCheckFolderTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFoldersFromEdit
            // 
            this.btnFoldersFromEdit.Location = new System.Drawing.Point(340, 41);
            this.btnFoldersFromEdit.Margin = new System.Windows.Forms.Padding(5);
            this.btnFoldersFromEdit.Name = "btnFoldersFromEdit";
            this.btnFoldersFromEdit.Size = new System.Drawing.Size(25, 25);
            this.btnFoldersFromEdit.TabIndex = 1;
            this.btnFoldersFromEdit.Text = "✎";
            this.btnFoldersFromEdit.UseVisualStyleBackColor = true;
            this.btnFoldersFromEdit.Click += new System.EventHandler(this.btnFoldersFromEdit_Click);
            // 
            // btnFoldersFromOpen
            // 
            this.btnFoldersFromOpen.Location = new System.Drawing.Point(305, 41);
            this.btnFoldersFromOpen.Margin = new System.Windows.Forms.Padding(5);
            this.btnFoldersFromOpen.Name = "btnFoldersFromOpen";
            this.btnFoldersFromOpen.Size = new System.Drawing.Size(25, 25);
            this.btnFoldersFromOpen.TabIndex = 1;
            this.btnFoldersFromOpen.Text = "📂";
            this.btnFoldersFromOpen.UseVisualStyleBackColor = true;
            this.btnFoldersFromOpen.Click += new System.EventHandler(this.btnFoldersFromOpen_Click);
            // 
            // lblCheckFolderFrom
            // 
            this.lblCheckFolderFrom.Location = new System.Drawing.Point(3, 41);
            this.lblCheckFolderFrom.Margin = new System.Windows.Forms.Padding(5);
            this.lblCheckFolderFrom.Name = "lblCheckFolderFrom";
            this.lblCheckFolderFrom.Size = new System.Drawing.Size(292, 25);
            this.lblCheckFolderFrom.TabIndex = 1;
            this.lblCheckFolderFrom.Text = "Folder \'from\'";
            this.lblCheckFolderFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFolders7ZipEdit
            // 
            this.btnFolders7ZipEdit.Location = new System.Drawing.Point(340, 16);
            this.btnFolders7ZipEdit.Margin = new System.Windows.Forms.Padding(5);
            this.btnFolders7ZipEdit.Name = "btnFolders7ZipEdit";
            this.btnFolders7ZipEdit.Size = new System.Drawing.Size(25, 25);
            this.btnFolders7ZipEdit.TabIndex = 0;
            this.btnFolders7ZipEdit.Text = "✎";
            this.btnFolders7ZipEdit.UseVisualStyleBackColor = true;
            this.btnFolders7ZipEdit.Click += new System.EventHandler(this.btnFolders7ZipEdit_Click);
            // 
            // btnFolders7ZipOpen
            // 
            this.btnFolders7ZipOpen.Location = new System.Drawing.Point(305, 16);
            this.btnFolders7ZipOpen.Margin = new System.Windows.Forms.Padding(5);
            this.btnFolders7ZipOpen.Name = "btnFolders7ZipOpen";
            this.btnFolders7ZipOpen.Size = new System.Drawing.Size(25, 25);
            this.btnFolders7ZipOpen.TabIndex = 0;
            this.btnFolders7ZipOpen.Text = "📂";
            this.btnFolders7ZipOpen.UseVisualStyleBackColor = true;
            this.btnFolders7ZipOpen.Click += new System.EventHandler(this.btnFolders7ZipOpen_Click);
            // 
            // lblCheck7Zip
            // 
            this.lblCheck7Zip.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCheck7Zip.Location = new System.Drawing.Point(3, 16);
            this.lblCheck7Zip.Margin = new System.Windows.Forms.Padding(5);
            this.lblCheck7Zip.Name = "lblCheck7Zip";
            this.lblCheck7Zip.Size = new System.Drawing.Size(292, 25);
            this.lblCheck7Zip.TabIndex = 0;
            this.lblCheck7Zip.Text = "7-Zip";
            this.lblCheck7Zip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpLastBackup
            // 
            this.grpLastBackup.Controls.Add(this.lblBackupFilesTotal);
            this.grpLastBackup.Controls.Add(this.lblBackupFileTime);
            this.grpLastBackup.Controls.Add(this.lblBackupFileName);
            this.grpLastBackup.Location = new System.Drawing.Point(200, 120);
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
            this.grpAsService.Controls.Add(this.lblCommingSoon);
            this.grpAsService.Location = new System.Drawing.Point(12, 226);
            this.grpAsService.Name = "grpAsService";
            this.grpAsService.Size = new System.Drawing.Size(373, 100);
            this.grpAsService.TabIndex = 3;
            this.grpAsService.TabStop = false;
            this.grpAsService.Text = "As service";
            // 
            // lblCommingSoon
            // 
            this.lblCommingSoon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCommingSoon.Enabled = false;
            this.lblCommingSoon.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblCommingSoon.Location = new System.Drawing.Point(3, 16);
            this.lblCommingSoon.Name = "lblCommingSoon";
            this.lblCommingSoon.Size = new System.Drawing.Size(367, 81);
            this.lblCommingSoon.TabIndex = 0;
            this.lblCommingSoon.Text = "Comming soon ...";
            this.lblCommingSoon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBackupRun
            // 
            this.btnBackupRun.Location = new System.Drawing.Point(12, 151);
            this.btnBackupRun.Name = "btnBackupRun";
            this.btnBackupRun.Size = new System.Drawing.Size(182, 69);
            this.btnBackupRun.TabIndex = 4;
            this.btnBackupRun.Text = "Run backup";
            this.btnBackupRun.UseVisualStyleBackColor = true;
            this.btnBackupRun.Click += new System.EventHandler(this.btnBackupRun_Click);
            // 
            // btnChecksRescan
            // 
            this.btnChecksRescan.Location = new System.Drawing.Point(12, 120);
            this.btnChecksRescan.Name = "btnChecksRescan";
            this.btnChecksRescan.Size = new System.Drawing.Size(182, 25);
            this.btnChecksRescan.TabIndex = 5;
            this.btnChecksRescan.Text = "Rescan checks";
            this.btnChecksRescan.UseVisualStyleBackColor = true;
            this.btnChecksRescan.Click += new System.EventHandler(this.btnChecksRescan_Click);
            // 
            // lblBackupFilesTotal
            // 
            this.lblBackupFilesTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBackupFilesTotal.Location = new System.Drawing.Point(3, 66);
            this.lblBackupFilesTotal.Margin = new System.Windows.Forms.Padding(5);
            this.lblBackupFilesTotal.Name = "lblBackupFilesTotal";
            this.lblBackupFilesTotal.Size = new System.Drawing.Size(179, 25);
            this.lblBackupFilesTotal.TabIndex = 2;
            this.lblBackupFilesTotal.Text = "Total backups";
            this.lblBackupFilesTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(393, 336);
            this.Controls.Add(this.btnChecksRescan);
            this.Controls.Add(this.btnBackupRun);
            this.Controls.Add(this.grpAsService);
            this.Controls.Add(this.grpLastBackup);
            this.Controls.Add(this.grpChecks);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "7-Zip Backuper";
            this.grpChecks.ResumeLayout(false);
            this.grpLastBackup.ResumeLayout(false);
            this.grpAsService.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpChecks;
        private System.Windows.Forms.Label lblCheckFolderTo;
        private System.Windows.Forms.Label lblCheckFolderFrom;
        private System.Windows.Forms.Label lblCheck7Zip;
        private System.Windows.Forms.Button btnFoldersToOpen;
        private System.Windows.Forms.Button btnFoldersFromOpen;
        private System.Windows.Forms.Button btnFolders7ZipOpen;
        private System.Windows.Forms.GroupBox grpLastBackup;
        private System.Windows.Forms.Label lblBackupFileTime;
        private System.Windows.Forms.Label lblBackupFileName;
        private System.Windows.Forms.GroupBox grpAsService;
        private System.Windows.Forms.Button btnBackupRun;
        private System.Windows.Forms.Button btnChecksRescan;
        private System.Windows.Forms.Button btnFoldersToEdit;
        private System.Windows.Forms.Button btnFoldersFromEdit;
        private System.Windows.Forms.Button btnFolders7ZipEdit;
        private System.Windows.Forms.Label lblCommingSoon;
        private System.Windows.Forms.Label lblBackupFilesTotal;
    }
}

