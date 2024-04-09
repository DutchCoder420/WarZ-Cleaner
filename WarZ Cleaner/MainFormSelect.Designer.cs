namespace WarZ_Cleaner
{
    partial class MainFormSelect
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
            btnScan = new Button();
            btnClose = new Button();
            checkedListBoxAppdata = new CheckedListBox();
            btnDeleteLogs = new Button();
            checkedListBoxProfiles = new CheckedListBox();
            checkBoxGamePath = new CheckBox();
            SuspendLayout();
            // 
            // btnScan
            // 
            btnScan.Location = new Point(12, 389);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(220, 49);
            btnScan.TabIndex = 0;
            btnScan.Text = "Scan Files";
            btnScan.UseVisualStyleBackColor = true;
            btnScan.Click += btnScan_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(568, 389);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(220, 49);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click_1;
            // 
            // checkedListBoxAppdata
            // 
            checkedListBoxAppdata.FormattingEnabled = true;
            checkedListBoxAppdata.Location = new Point(12, 12);
            checkedListBoxAppdata.Name = "checkedListBoxAppdata";
            checkedListBoxAppdata.Size = new Size(220, 364);
            checkedListBoxAppdata.TabIndex = 2;
            checkedListBoxAppdata.SelectedIndexChanged += checkedListBoxAppData_SelectedIndexChanged;
            // 
            // btnDeleteLogs
            // 
            btnDeleteLogs.Location = new Point(12, 389);
            btnDeleteLogs.Name = "btnDeleteLogs";
            btnDeleteLogs.Size = new Size(220, 49);
            btnDeleteLogs.TabIndex = 3;
            btnDeleteLogs.Text = "Clean Selected";
            btnDeleteLogs.UseVisualStyleBackColor = true;
            btnDeleteLogs.Click += btnDeleteLogs_Click;
            // 
            // checkedListBoxProfiles
            // 
            checkedListBoxProfiles.FormattingEnabled = true;
            checkedListBoxProfiles.Location = new Point(238, 48);
            checkedListBoxProfiles.Name = "checkedListBoxProfiles";
            checkedListBoxProfiles.Size = new Size(550, 328);
            checkedListBoxProfiles.TabIndex = 4;
            checkedListBoxProfiles.SelectedIndexChanged += checkedListBoxProfiles_SelectedIndexChanged;
            // 
            // checkBoxGamePath
            // 
            checkBoxGamePath.AutoSize = true;
            checkBoxGamePath.Location = new Point(238, 12);
            checkBoxGamePath.Name = "checkBoxGamePath";
            checkBoxGamePath.Size = new Size(81, 19);
            checkBoxGamePath.TabIndex = 5;
            checkBoxGamePath.Text = "Gamepath";
            checkBoxGamePath.UseVisualStyleBackColor = true;
            checkBoxGamePath.CheckedChanged += checkBoxGamePath_CheckedChanged;
            // 
            // MainFormSelect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.MainFormBackground;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(800, 450);
            Controls.Add(checkBoxGamePath);
            Controls.Add(checkedListBoxProfiles);
            Controls.Add(btnDeleteLogs);
            Controls.Add(checkedListBoxAppdata);
            Controls.Add(btnClose);
            Controls.Add(btnScan);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainFormSelect";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnScan;
        private Button btnClose;
        private CheckedListBox checkedListBoxAppdata;
        private Button btnDeleteLogs;
        private CheckedListBox checkedListBoxProfiles;
        private CheckBox checkBoxGamePath;
    }
}