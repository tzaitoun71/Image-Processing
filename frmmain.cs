using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

// Tariq Zaitoun
// 25/10/2019
// Image Processing
// An image processing program that can take any image and manipulate it based on the effects provided in the user interface. eg: flipx, flipy, rotate, mirror, invert, etc.
// The Enhancements:
// Undo button 0.5, limited to 5 due to memory but can easily be changed
// Pixelated effect 0.25
// Tints 0.5

namespace Image_Processing
{
    public partial class frmMain : Form
    {
        private ImageManipulator imageManipulator;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {


                OpenFileDialog fd = new OpenFileDialog();

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    this.imageManipulator = new ImageManipulator(fd.FileName);
                    ImageBox.Image = this.imageManipulator.getOriginalBmp();
                    processToolStripMenuItem.Enabled = true;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error loading image");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ImageBox.Image = this.imageManipulator.reset();
            btnUndo.Enabled = false;
        }

        private void btnGreyScale_Click(object sender, EventArgs e)
        {         
            ImageBox.Image = this.imageManipulator.greyscale();
            btnUndo.Enabled = !this.imageManipulator.isUndoEmpty();
        }

        private void btnInvert_Click(object sender, EventArgs e)
        {        
            ImageBox.Image = this.imageManipulator.invert();
            btnUndo.Enabled = !this.imageManipulator.isUndoEmpty();
        }

        private void btnDarken_Click(object sender, EventArgs e)
        {
            ImageBox.Image = this.imageManipulator.darken();
            btnUndo.Enabled = !this.imageManipulator.isUndoEmpty();
        }

        private void btnWhiten_Click(object sender, EventArgs e)
        {         
            ImageBox.Image = this.imageManipulator.whiten();
            btnUndo.Enabled = !this.imageManipulator.isUndoEmpty();
        }

        private void btnFlipX_Click(object sender, EventArgs e) 
        {
            ImageBox.Image = this.imageManipulator.flipX();
            btnUndo.Enabled = !this.imageManipulator.isUndoEmpty();
        }

        private void btnFlipY_Click(object sender, EventArgs e)
        {
            ImageBox.Image = this.imageManipulator.flipY();
            btnUndo.Enabled = !this.imageManipulator.isUndoEmpty();
        }

        private void btnMirrorHoriztonal_Click(object sender, EventArgs e)
        {
            ImageBox.Image = this.imageManipulator.horizontalMirror();
            btnUndo.Enabled = !this.imageManipulator.isUndoEmpty();
        }

        private void btnMirrorVertical_Click(object sender, EventArgs e)
        {
            ImageBox.Image = this.imageManipulator.verticalMirror();
            btnUndo.Enabled = !this.imageManipulator.isUndoEmpty();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            Bitmap bmp = this.imageManipulator.undo();
            ImageBox.Image = bmp;
            btnUndo.Enabled = !this.imageManipulator.isUndoEmpty();
        }

        private void btnScale50_Click(object sender, EventArgs e) //CONTINUE FIXING
        {
            ImageBox.Image = this.imageManipulator.scale50(true);
            btnUndo.Enabled = !this.imageManipulator.isUndoEmpty();
        }

        private void btnScale200_Click(object sender, EventArgs e)
        {
            ImageBox.Image = this.imageManipulator.scale200(true);
            btnUndo.Enabled = !this.imageManipulator.isUndoEmpty();
        }
        private void btnPixelate_Click(object sender, EventArgs e)
        {
            ImageBox.Image = this.imageManipulator.pixelate();
            btnUndo.Enabled = !this.imageManipulator.isUndoEmpty();
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            ImageBox.Image = this.imageManipulator.tint("red");
            btnUndo.Enabled = !this.imageManipulator.isUndoEmpty();
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            ImageBox.Image = this.imageManipulator.tint("blue");
            btnUndo.Enabled = !this.imageManipulator.isUndoEmpty();
        }
      
        private void btnPink_Click(object sender, EventArgs e)
        {
            ImageBox.Image = this.imageManipulator.tint("pink");
            btnUndo.Enabled = !this.imageManipulator.isUndoEmpty();
        }

        private void BtnGreen_Click(object sender, EventArgs e)
        {
            ImageBox.Image = this.imageManipulator.tint("green");
            btnUndo.Enabled = !this.imageManipulator.isUndoEmpty();
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            ImageBox.Image = this.imageManipulator.tint("yellow");
            btnUndo.Enabled = !this.imageManipulator.isUndoEmpty();
        }

        private void btnAqua_Click(object sender, EventArgs e)
        {
            ImageBox.Image = this.imageManipulator.tint("aqua");
            btnUndo.Enabled = !this.imageManipulator.isUndoEmpty();
        }

        private void btnBlur_Click(object sender, EventArgs e)
        {
            ImageBox.Image = this.imageManipulator.blur();
            btnUndo.Enabled = !this.imageManipulator.isUndoEmpty();
        }

        private void btnRotation_Click(object sender, EventArgs e)
        {
            ImageBox.Image = this.imageManipulator.rotate();
            btnUndo.Enabled = !this.imageManipulator.isUndoEmpty();
        }
    }
}   
