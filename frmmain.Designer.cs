namespace Image_Processing
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.processToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReset = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGreyScale = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInvert = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDarken = new System.Windows.Forms.ToolStripMenuItem();
            this.btnWhiten = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFlipX = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFlipY = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMirrorHoriztonal = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMirrorVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.btnScale50 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnScale200 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPixelate = new System.Windows.Forms.ToolStripMenuItem();
            this.tintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRed = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnGreen = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPink = new System.Windows.Forms.ToolStripMenuItem();
            this.btnYellow = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAqua = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBlur = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRotation = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.processToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1323, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoad,
            this.btnExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // btnLoad
            // 
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 22);
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 22);
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // processToolStripMenuItem
            // 
            this.processToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReset,
            this.btnUndo,
            this.btnGreyScale,
            this.btnInvert,
            this.btnDarken,
            this.btnWhiten,
            this.btnFlipX,
            this.btnFlipY,
            this.btnMirrorHoriztonal,
            this.btnMirrorVertical,
            this.btnScale50,
            this.btnScale200,
            this.btnPixelate,
            this.tintToolStripMenuItem,
            this.btnBlur,
            this.btnRotation});
            this.processToolStripMenuItem.Enabled = false;
            this.processToolStripMenuItem.Name = "processToolStripMenuItem";
            this.processToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.processToolStripMenuItem.Text = "Process";
            // 
            // btnReset
            // 
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(180, 22);
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Enabled = false;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(180, 22);
            this.btnUndo.Text = "Undo";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnGreyScale
            // 
            this.btnGreyScale.Name = "btnGreyScale";
            this.btnGreyScale.Size = new System.Drawing.Size(180, 22);
            this.btnGreyScale.Text = "Grey Scale";
            this.btnGreyScale.Click += new System.EventHandler(this.btnGreyScale_Click);
            // 
            // btnInvert
            // 
            this.btnInvert.Name = "btnInvert";
            this.btnInvert.Size = new System.Drawing.Size(180, 22);
            this.btnInvert.Text = "Invert";
            this.btnInvert.Click += new System.EventHandler(this.btnInvert_Click);
            // 
            // btnDarken
            // 
            this.btnDarken.Name = "btnDarken";
            this.btnDarken.Size = new System.Drawing.Size(180, 22);
            this.btnDarken.Text = "Darken";
            this.btnDarken.Click += new System.EventHandler(this.btnDarken_Click);
            // 
            // btnWhiten
            // 
            this.btnWhiten.Name = "btnWhiten";
            this.btnWhiten.Size = new System.Drawing.Size(180, 22);
            this.btnWhiten.Text = "Whiten";
            this.btnWhiten.Click += new System.EventHandler(this.btnWhiten_Click);
            // 
            // btnFlipX
            // 
            this.btnFlipX.Name = "btnFlipX";
            this.btnFlipX.Size = new System.Drawing.Size(180, 22);
            this.btnFlipX.Text = "Flip X";
            this.btnFlipX.Click += new System.EventHandler(this.btnFlipX_Click);
            // 
            // btnFlipY
            // 
            this.btnFlipY.Name = "btnFlipY";
            this.btnFlipY.Size = new System.Drawing.Size(180, 22);
            this.btnFlipY.Text = "Flip Y";
            this.btnFlipY.Click += new System.EventHandler(this.btnFlipY_Click);
            // 
            // btnMirrorHoriztonal
            // 
            this.btnMirrorHoriztonal.Name = "btnMirrorHoriztonal";
            this.btnMirrorHoriztonal.Size = new System.Drawing.Size(180, 22);
            this.btnMirrorHoriztonal.Text = "Mirror Horizontal";
            this.btnMirrorHoriztonal.Click += new System.EventHandler(this.btnMirrorHoriztonal_Click);
            // 
            // btnMirrorVertical
            // 
            this.btnMirrorVertical.Name = "btnMirrorVertical";
            this.btnMirrorVertical.Size = new System.Drawing.Size(180, 22);
            this.btnMirrorVertical.Text = "Mirror Vertical";
            this.btnMirrorVertical.Click += new System.EventHandler(this.btnMirrorVertical_Click);
            // 
            // btnScale50
            // 
            this.btnScale50.Name = "btnScale50";
            this.btnScale50.Size = new System.Drawing.Size(180, 22);
            this.btnScale50.Text = "Scale 50";
            this.btnScale50.Click += new System.EventHandler(this.btnScale50_Click);
            // 
            // btnScale200
            // 
            this.btnScale200.Name = "btnScale200";
            this.btnScale200.Size = new System.Drawing.Size(180, 22);
            this.btnScale200.Text = "Scale 200";
            this.btnScale200.Click += new System.EventHandler(this.btnScale200_Click);
            // 
            // btnPixelate
            // 
            this.btnPixelate.Name = "btnPixelate";
            this.btnPixelate.Size = new System.Drawing.Size(180, 22);
            this.btnPixelate.Text = "Pixelate";
            this.btnPixelate.Click += new System.EventHandler(this.btnPixelate_Click);
            // 
            // tintToolStripMenuItem
            // 
            this.tintToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRed,
            this.btnBlue,
            this.BtnGreen,
            this.btnPink,
            this.btnYellow,
            this.btnAqua});
            this.tintToolStripMenuItem.Name = "tintToolStripMenuItem";
            this.tintToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tintToolStripMenuItem.Text = "Tint";
            // 
            // btnRed
            // 
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(108, 22);
            this.btnRed.Text = "Red";
            this.btnRed.Click += new System.EventHandler(this.btnRed_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(108, 22);
            this.btnBlue.Text = "Blue";
            this.btnBlue.Click += new System.EventHandler(this.btnBlue_Click);
            // 
            // BtnGreen
            // 
            this.BtnGreen.Name = "BtnGreen";
            this.BtnGreen.Size = new System.Drawing.Size(108, 22);
            this.BtnGreen.Text = "Green";
            this.BtnGreen.Click += new System.EventHandler(this.BtnGreen_Click);
            // 
            // btnPink
            // 
            this.btnPink.Name = "btnPink";
            this.btnPink.Size = new System.Drawing.Size(108, 22);
            this.btnPink.Text = "Pink";
            this.btnPink.Click += new System.EventHandler(this.btnPink_Click);
            // 
            // btnYellow
            // 
            this.btnYellow.Name = "btnYellow";
            this.btnYellow.Size = new System.Drawing.Size(108, 22);
            this.btnYellow.Text = "Yellow";
            this.btnYellow.Click += new System.EventHandler(this.btnYellow_Click);
            // 
            // btnAqua
            // 
            this.btnAqua.Name = "btnAqua";
            this.btnAqua.Size = new System.Drawing.Size(108, 22);
            this.btnAqua.Text = "Aqua";
            this.btnAqua.Click += new System.EventHandler(this.btnAqua_Click);
            // 
            // btnBlur
            // 
            this.btnBlur.Name = "btnBlur";
            this.btnBlur.Size = new System.Drawing.Size(180, 22);
            this.btnBlur.Text = "Blur";
            this.btnBlur.Click += new System.EventHandler(this.btnBlur_Click);
            // 
            // btnRotation
            // 
            this.btnRotation.Name = "btnRotation";
            this.btnRotation.Size = new System.Drawing.Size(180, 22);
            this.btnRotation.Text = "Rotate";
            this.btnRotation.Click += new System.EventHandler(this.btnRotation_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // ImageBox
            // 
            this.ImageBox.Location = new System.Drawing.Point(12, 27);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(1299, 723);
            this.ImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ImageBox.TabIndex = 1;
            this.ImageBox.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 752);
            this.Controls.Add(this.ImageBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Tarobe Photoshop";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnLoad;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem processToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnReset;
        private System.Windows.Forms.ToolStripMenuItem btnUndo;
        private System.Windows.Forms.ToolStripMenuItem btnGreyScale;
        private System.Windows.Forms.ToolStripMenuItem btnInvert;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.PictureBox ImageBox;
        private System.Windows.Forms.ToolStripMenuItem btnDarken;
        private System.Windows.Forms.ToolStripMenuItem btnWhiten;
        private System.Windows.Forms.ToolStripMenuItem btnFlipX;
        private System.Windows.Forms.ToolStripMenuItem btnFlipY;
        private System.Windows.Forms.ToolStripMenuItem btnMirrorHoriztonal;
        private System.Windows.Forms.ToolStripMenuItem btnMirrorVertical;
        private System.Windows.Forms.ToolStripMenuItem btnScale50;
        private System.Windows.Forms.ToolStripMenuItem btnScale200;
        private System.Windows.Forms.ToolStripMenuItem btnPixelate;
        private System.Windows.Forms.ToolStripMenuItem tintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnRed;
        private System.Windows.Forms.ToolStripMenuItem btnBlue;
        private System.Windows.Forms.ToolStripMenuItem BtnGreen;
        private System.Windows.Forms.ToolStripMenuItem btnPink;
        private System.Windows.Forms.ToolStripMenuItem btnYellow;
        private System.Windows.Forms.ToolStripMenuItem btnAqua;
        private System.Windows.Forms.ToolStripMenuItem btnBlur;
        private System.Windows.Forms.ToolStripMenuItem btnRotation;
    }
}

