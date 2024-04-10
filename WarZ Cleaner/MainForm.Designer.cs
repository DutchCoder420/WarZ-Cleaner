namespace WarZ_Cleaner
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(components);
            btnClean = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            lblHeaderTitle = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            btnMinimize = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            lblPatreon = new LinkLabel();
            lblDiscord = new LinkLabel();
            SuspendLayout();
            // 
            // kryptonPalette1
            // 
            kryptonPalette1.ButtonStyles.ButtonForm.StateCommon.Content.ShortText.Color1 = Color.Black;
            kryptonPalette1.ButtonStyles.ButtonForm.StateCommon.Content.ShortText.Color2 = Color.Black;
            kryptonPalette1.ButtonStyles.ButtonForm.StateCommon.Content.ShortText.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            kryptonPalette1.Common.StateCommon.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right;
            kryptonPalette1.Common.StateCommon.Border.Rounding = 6;
            kryptonPalette1.Common.StateCommon.Content.ShortText.Font = new Font("Arial", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color1 = Color.FromArgb(250, 252, 252);
            kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color2 = Color.FromArgb(250, 252, 252);
            kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Color1 = Color.FromArgb(250, 252, 252);
            kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Color2 = Color.FromArgb(250, 252, 252);
            kryptonPalette1.FormStyles.FormMain.StateCommon.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right;
            kryptonPalette1.FormStyles.FormMain.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.None;
            kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Rounding = 12;
            kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = Color.FromArgb(250, 252, 252);
            kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = Color.FromArgb(250, 252, 252);
            kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Border.Color1 = Color.FromArgb(250, 252, 252);
            kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Border.Color2 = Color.FromArgb(250, 252, 252);
            kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right;
            kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Content.Padding = new Padding(10, -1, -1, -1);
            // 
            // btnClean
            // 
            btnClean.Location = new Point(366, 420);
            btnClean.Margin = new Padding(4, 3, 4, 3);
            btnClean.Name = "btnClean";
            btnClean.Palette = kryptonPalette1;
            btnClean.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            btnClean.Size = new Size(200, 38);
            btnClean.StateCommon.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right;
            btnClean.StateCommon.Border.Rounding = 13;
            btnClean.StateCommon.Content.ShortText.Color1 = Color.Black;
            btnClean.StateCommon.Content.ShortText.Color2 = Color.Black;
            btnClean.StateCommon.Content.ShortText.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClean.TabIndex = 0;
            btnClean.Values.Text = "Clean";
            btnClean.Click += btnClean_Click;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.Location = new Point(16, 6);
            lblHeaderTitle.Margin = new Padding(4, 3, 4, 3);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(114, 22);
            lblHeaderTitle.StateCommon.ShortText.Color1 = Color.White;
            lblHeaderTitle.StateCommon.ShortText.Color2 = Color.White;
            lblHeaderTitle.StateCommon.ShortText.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHeaderTitle.TabIndex = 3;
            lblHeaderTitle.Values.ImageTransparentColor = Color.Red;
            lblHeaderTitle.Values.Text = "WarZ Cleaner";
            // 
            // btnMinimize
            // 
            btnMinimize.Location = new Point(873, 7);
            btnMinimize.Margin = new Padding(4, 3, 4, 3);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(18, 17);
            btnMinimize.StateCommon.Back.Color1 = Color.Lime;
            btnMinimize.StateCommon.Back.Color2 = Color.Lime;
            btnMinimize.StateCommon.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right;
            btnMinimize.StateCommon.Border.Rounding = 50;
            btnMinimize.TabIndex = 5;
            btnMinimize.TabStop = false;
            btnMinimize.Values.Text = "2";
            btnMinimize.Click += btnMinimize_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(897, 7);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(18, 17);
            btnClose.StateCommon.Back.Color1 = Color.Red;
            btnClose.StateCommon.Back.Color2 = Color.Red;
            btnClose.StateCommon.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right;
            btnClose.StateCommon.Border.Rounding = 50;
            btnClose.StateDisabled.Back.Color1 = Color.Red;
            btnClose.StateDisabled.Back.Color2 = Color.Red;
            btnClose.StateNormal.Back.Color1 = Color.Red;
            btnClose.StateNormal.Back.Color2 = Color.Red;
            btnClose.StatePressed.Back.Color1 = Color.Red;
            btnClose.StatePressed.Back.Color2 = Color.Red;
            btnClose.StateTracking.Back.Color1 = Color.Red;
            btnClose.StateTracking.Back.Color2 = Color.Red;
            btnClose.TabIndex = 6;
            btnClose.TabStop = false;
            btnClose.Values.Text = "2";
            btnClose.Click += btnClose_Click;
            // 
            // lblPatreon
            // 
            lblPatreon.AutoSize = true;
            lblPatreon.BackColor = Color.Transparent;
            lblPatreon.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPatreon.LinkColor = Color.White;
            lblPatreon.Location = new Point(13, 494);
            lblPatreon.Margin = new Padding(4, 0, 4, 0);
            lblPatreon.Name = "lblPatreon";
            lblPatreon.Size = new Size(137, 16);
            lblPatreon.TabIndex = 8;
            lblPatreon.TabStop = true;
            lblPatreon.Text = "Support us on Patreon";
            lblPatreon.LinkClicked += lblPatreon_LinkClicked;
            // 
            // lblDiscord
            // 
            lblDiscord.AutoSize = true;
            lblDiscord.BackColor = Color.Transparent;
            lblDiscord.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDiscord.LinkColor = Color.White;
            lblDiscord.Location = new Point(822, 494);
            lblDiscord.Margin = new Padding(4, 0, 4, 0);
            lblDiscord.Name = "lblDiscord";
            lblDiscord.Size = new Size(100, 16);
            lblDiscord.TabIndex = 9;
            lblDiscord.TabStop = true;
            lblDiscord.Text = "Join our Discord";
            lblDiscord.LinkClicked += lblDiscord_LinkClicked;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 252, 252);
            BackgroundImage = Properties.Resources.Multiartwork;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(933, 519);
            Controls.Add(lblDiscord);
            Controls.Add(lblPatreon);
            Controls.Add(btnClose);
            Controls.Add(btnMinimize);
            Controls.Add(lblHeaderTitle);
            Controls.Add(btnClean);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "MainForm";
            Palette = kryptonPalette1;
            PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            StateCommon.Border.Color1 = Color.Transparent;
            StateCommon.Border.Color2 = Color.Transparent;
            StateCommon.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.ExpertSquareHighlight2;
            StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            StateCommon.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right;
            StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.None;
            StateCommon.Border.ImageAlign = ComponentFactory.Krypton.Toolkit.PaletteRectangleAlign.Local;
            StateCommon.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.TopLeft;
            StateCommon.Border.Rounding = 20;
            StateCommon.Header.Content.Image.Effect = ComponentFactory.Krypton.Toolkit.PaletteImageEffect.Normal;
            StateCommon.OverlayHeaders = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            Text = " ";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClean;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblHeaderTitle;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnMinimize;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private System.Windows.Forms.LinkLabel lblPatreon;
        private System.Windows.Forms.LinkLabel lblDiscord;
    }
}

