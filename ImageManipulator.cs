using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Image_Processing
{
    class ImageManipulator
    {
        private static int Darken = 100; // Setting the constant value for Darken to 100
        private static int Whiten = 100; // Setting the constant value for Whiten to 100

        private Bitmap originalBmp; // A bitmap to keep track of the Original size of the bitmap
        private Color[,] originalImage; // A 2D Color array to keep track of the Original image 

        private Color[,] transformedImage; // A 2D color array to manipulate and stack the transformed Image
        private Bitmap bmp; // A Bitmap to manipulate and stack the transformed image

        private Bitmap[] undoBitmapBuffer = new Bitmap[5]; // The undo bitmap array that allows up to 5 redos in the bitmap
        private Color[][,] undoTransformedImageBuffer = new Color[5][,];  // A color array and 2d array that allows up to 5 redos of the image itself
        private int undoIndex = 0; // keeping track of the amount of undos

        // this code could be easily changed to increase the amount of undos, but i limited it due to memory
        public ImageManipulator(String fileName) // Method that takes the string of the filename
        {
            this.originalBmp = new Bitmap(fileName); // Gives the original Bmp the bitmap of the file
            this.originalImage = new Color[this.originalBmp.Width, this.originalBmp.Height]; // the  original 2d color array that we keep track of takes the values of the values of the bitmap 

            this.bmp = new Bitmap(fileName); // does the same but to the manipulated bitmap
            this.transformedImage = new Color[this.bmp.Width, this.bmp.Height]; // does the same but to the manipulated 2d array called Transformed Image

            for (int x = 0; x < this.originalBmp.Width; x++)
            {
                for (int y = 0; y < this.originalBmp.Height; y++)
                {
                    this.originalImage[x, y] = this.originalBmp.GetPixel(x, y); // gives the original 2d array the values of the original bitmap pixels
                    this.transformedImage[x, y] = this.originalBmp.GetPixel(x, y); // does the same to the transformed image
                }
            }
        }

        public Bitmap getOriginalBmp() // method for original bitmap
        {
            return this.originalBmp; // Returns original bitmap
        }

        public Bitmap reset() // Method for reset
        {
            this.transformedImage = new Color[this.originalImage.GetLength(0), this.originalImage.GetLength(1)]; // resets the transformed image color array to the original color values

            for (int x = 0; x < this.originalImage.GetLength(0); x++)
            {
                for (int y = 0; y < this.originalImage.GetLength(1); y++)
                {
                    this.transformedImage[x, y] = this.originalImage[x, y]; // resets the transformed image array values into the original values
                }
            }

            this.bmp = (Bitmap) this.originalBmp.Clone(); // resets the manipulated bitmap to the original bitmap
            this.undoIndex = 0; // resets the undo index to 0 
            return this.bmp; // returns the bitmap
        }

        public Bitmap greyscale() // method for greyscale
        {
            for (int x = 0; x < this.transformedImage.GetLength(0); x++)
            {
                for (int y = 0; y < this.transformedImage.GetLength(1); y++)
                {
                    int a = this.transformedImage[x, y].A; // an integer that takes the transparency, red, green, blue from the transformed image
                    int r = this.transformedImage[x, y].R;
                    int g = this.transformedImage[x, y].G;
                    int b = this.transformedImage[x, y].B;
                    int Avg = (r + g + b) / 3; // takes the average of RGB and divides it by 3 in order to grey scale
                    this.bmp.SetPixel(x, y, Color.FromArgb(a, Avg, Avg, Avg)); // sets the pixels and colors 
                    this.transformedImage[x, y] = this.bmp.GetPixel(x, y); // gives the bmp values to transformed image to continue stacking
                }
            }

            this.addToUndoQueue(); // adds to the undo count
            return this.bmp; // returns bitmap
        }

        public Bitmap invert() // method for invert
        {
            for (int x = 0; x < this.transformedImage.GetLength(0); x++)
            {
                for (int y = 0; y < this.transformedImage.GetLength(1); y++)
                {
                    int a = this.transformedImage[x, y].A; // an integer that takes the transparency, red, green, blue from the transformed image
                    int r = this.transformedImage[x, y].R;
                    int g = this.transformedImage[x, y].G;
                    int b = this.transformedImage[x, y].B;
                    this.bmp.SetPixel(x, y, Color.FromArgb(b, g, r, a)); // sets the pixels in inverted order
                    this.transformedImage[x, y] = this.bmp.GetPixel(x, y); // gives the bmp values to transformed image to continue stacking
                }
            }

            this.addToUndoQueue(); // adds onto undo count
            return this.bmp; // returns bitmap
        }

        public Bitmap darken() // method for darken
        {
            for (int x = 0; x < this.transformedImage.GetLength(0); x++)
            {
                for (int y = 0; y < this.transformedImage.GetLength(1); y++)
                {
                    int a = this.transformedImage[x, y].A; // assigns an integer to take the transparency of the transformed image
                    int r, g, b;

                    if (this.transformedImage[x, y].R - ImageManipulator.Darken > 0) r = this.transformedImage[x, y].R - ImageManipulator.Darken; // checks if each color subtracted by darken if its greater than 0, and if it isnt its equal to 0
                    else r = 0;

                    if (this.transformedImage[x, y].G - ImageManipulator.Darken > 0) g = this.transformedImage[x, y].G - ImageManipulator.Darken;
                    else g = 0;

                    if (this.transformedImage[x, y].B - ImageManipulator.Darken > 0) b = this.transformedImage[x, y].B - ImageManipulator.Darken;
                    else b = 0;

                    this.bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                    this.transformedImage[x, y] = this.bmp.GetPixel(x, y);
                }
            }

            this.addToUndoQueue();
            return this.bmp;
        }

        public Bitmap whiten()
        {
            for (int x = 0; x < this.transformedImage.GetLength(0); x++)
            {
                for (int y = 0; y < this.transformedImage.GetLength(1); y++)
                {
                    int a = this.transformedImage[x, y].A;
                    int r, g, b;

                    if (this.transformedImage[x, y].R + ImageManipulator.Whiten < 255) r = this.transformedImage[x, y].R + ImageManipulator.Whiten; // Check if each color is less than 255 when added by the static whiten value and if it isnt it is then equal to 255
                    else r = 255;

                    if (this.transformedImage[x, y].G + ImageManipulator.Whiten < 255) g = this.transformedImage[x, y].G + ImageManipulator.Whiten;
                    else g = 255;

                    if (this.transformedImage[x, y].B + ImageManipulator.Whiten < 255) b = this.transformedImage[x, y].B + ImageManipulator.Whiten;
                    else b = 255;

                    this.bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                    this.transformedImage[x, y] = this.bmp.GetPixel(x, y);
                }
            }

            this.addToUndoQueue();
            return this.bmp;
        }

        public Bitmap flipX()
        {
            Color[,] temp = new Color[this.transformedImage.GetLength(0), this.transformedImage.GetLength(1)]; // a temp 2d array is made and takes the x,y  color values of the transformed image

            for (int x = 0; x < this.transformedImage.GetLength(0); x++)
            {
                for (int y = 0; y < this.transformedImage.GetLength(1); y++)
                {
                    temp[x, y] = this.transformedImage[x, y]; // a loop that will give the temp x,y values the transformed image values
                }
            }

            for (int x = 0; x < this.transformedImage.GetLength(0); x++)
            {
                for (int y = 0; y < this.transformedImage.GetLength(1); y++)
                {
                    this.transformedImage[x, y] = temp[temp.GetLength(0) - 1 - x, y]; // the transformed image is then looped and changed to equal to temp when temp's X is substracted by 1 and the iteration, and y remains the same
                    int a = this.transformedImage[x, y].A; // self explanatory
                    int r = this.transformedImage[x, y].R;
                    int g = this.transformedImage[x, y].G;
                    int b = this.transformedImage[x, y].B;
                    this.bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }

            this.addToUndoQueue();
            return this.bmp;
        }

        public Bitmap flipY()
        {
            Color[,] temp = new Color[this.transformedImage.GetLength(0), this.transformedImage.GetLength(1)]; // temp 2d color array is made. Exactly like flipx but just one difference

            for (int x = 0; x < this.transformedImage.GetLength(0); x++)
            {
                for (int y = 0; y < this.transformedImage.GetLength(1); y++)
                {
                    temp[x, y] = this.transformedImage[x, y];
                }
            }

            for (int x = 0; x < this.transformedImage.GetLength(0); x++)
            {
                for (int y = 0; y < this.transformedImage.GetLength(1); y++)
                {
                    this.transformedImage[x, y] = temp[x, temp.GetLength(1) - 1 - y]; // y values are instead subtracted by 1 and the iterated value instead of the X
                    int a = this.transformedImage[x, y].A; // self explanatory
                    int r = this.transformedImage[x, y].R;
                    int g = this.transformedImage[x, y].G;
                    int b = this.transformedImage[x, y].B;
                    this.bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }

            this.addToUndoQueue();
            return this.bmp;
        }

        public Bitmap horizontalMirror()
        {
            int bottomHalfStartIndex = 0; // an integer to start off from the bottom half
            if (this.transformedImage.GetLength(1) % 2 == 0) bottomHalfStartIndex = this.transformedImage.GetLength(1) / 2; // if statement to check if the image has even dimensions
            else bottomHalfStartIndex = (this.transformedImage.GetLength(1) / 2) + 1; // else, it will add 1 to make it even

            for (int x = 0; x < this.transformedImage.GetLength(0); x++)
            {
                for (int y = this.transformedImage.GetLength(1) - 1; y >= bottomHalfStartIndex; y--) // it'll loop as long as its greater than or equal to the bottom half integer
                {
                    this.transformedImage[x, y] = this.transformedImage[x, this.transformedImage.GetLength(1) - 1 - y]; // Now that we are on the bottom half, the y values are subtracted by 1 and the iteration to mirror the horizontal

                    int a = this.transformedImage[x, y].A; // self explanatory
                    int r = this.transformedImage[x, y].R;
                    int g = this.transformedImage[x, y].G;
                    int b = this.transformedImage[x, y].B;
                    this.bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }

            this.addToUndoQueue();
            return this.bmp;
        }

        public Bitmap verticalMirror() // vertical mirror method
        {
            int RightHalfStartIndex = 0; // int value for the right half 
            if (this.transformedImage.GetLength(0) % 2 == 0) RightHalfStartIndex = this.transformedImage.GetLength(0) / 2; // checks if its even and if it itll divide the length of the X's by 2
            else RightHalfStartIndex = (this.transformedImage.GetLength(0) / 2) + 1; // if not, it will divide the length of the x's by 2 then add 1 

            for (int x = this.transformedImage.GetLength(0) - 1; x >= RightHalfStartIndex; x--) // loops and subtracts length by 1 until its greater than or equal to the righthalf
            {
                for (int y = 0; y < this.transformedImage.GetLength(1); y++)
                {
                    this.transformedImage[x, y] = this.transformedImage[this.transformedImage.GetLength(0) - 1 - x, y]; // the new transformed image will have it's X's subtracted by 1 and the iterated amount

                    int a = this.transformedImage[x, y].A; // self explanatory
                    int r = this.transformedImage[x, y].R;
                    int g = this.transformedImage[x, y].G;
                    int b = this.transformedImage[x, y].B;
                    this.bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }

            this.addToUndoQueue();
            return this.bmp;
        }

        public Bitmap scale50(bool addToQueue) // scale50 method
        {
            this.bmp = new Bitmap(this.transformedImage.GetLength(0) / 2, this.transformedImage.GetLength(1) / 2); // the manipulated bitmap is divided by 2 on both X and Y
            Color[,] temp = this.transformedImage; // gives the 2d color arrat temp the value of the transformed image
            this.transformedImage = new Color[this.transformedImage.GetLength(0) / 2, this.transformedImage.GetLength(1) / 2]; // divides the x and y colors of the transformed image by 2

            for (int x = 0; x < temp.GetLength(0) - 1; x++) // subtracts the temp x length array by 1 and loops through it
            {
                for (int y = 0; y < temp.GetLength(1) - 1; y++) // same with the y 
                {
                    this.transformedImage[x / 2, y / 2] = temp[x, y]; // the temp image coordinates are equal to the transformed image coordinates divided by 2
                    int a = this.transformedImage[x / 2, y / 2].A; // transparency coordinates divided by 2
                    int r = this.transformedImage[x / 2, y / 2].R; // red coordinates divided by 2
                    int g = this.transformedImage[x / 2, y / 2].G; // green coordinates divided by 2
                    int b = this.transformedImage[x / 2, y / 2].B; // blue coordinates divided by 2 

                    this.bmp.SetPixel(x / 2, y / 2, Color.FromArgb(a, r, g, b)); // sets the bitmap with the pixels divided by 2 and with the colors
                }
            }

            if (addToQueue) this.addToUndoQueue();
            return this.bmp;
        }

        public Bitmap scale200(bool addToQueue) // scale 200 method
        {
            this.bmp = new Bitmap(this.transformedImage.GetLength(0) * 2, this.transformedImage.GetLength(1) * 2); // the bitmap takes the values of the transformed image and multiples them by 2
            Color[,] temp = this.transformedImage;
            this.transformedImage = new Color[this.transformedImage.GetLength(0) * 2, this.transformedImage.GetLength(1) * 2]; // the transformed image's colors is multipled by two

            for (int x = 0; x < this.transformedImage.GetLength(0); x++)
            {
                for (int y = 0; y < this.transformedImage.GetLength(1); y++)
                {
                    this.transformedImage[x, y] = temp[x / 2, y / 2]; // transformed image is equal to the temp image divided by 2 
                    int a = this.transformedImage[x, y].A; // self explanatory
                    int r = this.transformedImage[x, y].R;
                    int g = this.transformedImage[x, y].G;
                    int b = this.transformedImage[x, y].B;

                    this.bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }

            if (addToQueue) this.addToUndoQueue();
            return this.bmp;
        }

        public Bitmap pixelate() // method for pixels
        {
            this.scale50(false); // Scales it to 50 3 times
            this.scale50(false);
            this.scale50(false);
            this.scale200(false); // scales it to 200 3 times then displays 
            this.scale200(false);
            this.scale200(false);
            this.addToUndoQueue();
            return this.bmp;
        }

        public Bitmap tint(String color) // method for tint
        {
            for (int x = 0; x < this.transformedImage.GetLength(0); x++)
            {
                for (int y = 0; y < this.transformedImage.GetLength(1); y++)
                {
                    int a = this.transformedImage[x, y].A;
                    int r = this.transformedImage[x, y].R;
                    int g = this.transformedImage[x, y].G;
                    int b = this.transformedImage[x, y].B;

                    if (color.Equals("red")) r = 255; // if statement that accepts a string parameter to determine the required values from the series of if statements
                    else if (color.Equals("blue")) b = 255;
                    else if (color.Equals("green")) g = 255;
                    else if (color.Equals("pink"))
                    {
                        r = 255;
                        b = 255;
                    }
                    else if (color.Equals("yellow"))
                    {
                        g = 255;
                        r = 255;
                    }
                    else if (color.Equals("aqua"))
                    {
                        g = 255;
                        b = 255;
                    }

                    this.bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                    this.transformedImage[x, y] = this.bmp.GetPixel(x, y);
                }
            }

            this.addToUndoQueue();
            return this.bmp;
        }

        public Bitmap blur() // Method for blur
        {
            int blur = 5; // sets the blur to 5 to make it at a decent strength

            for (int x = blur; x < this.transformedImage.GetLength(0) - blur; x++) // the starting iteration starts of with the value of blur which is 5 and it loops as the length is subtracted by 5
            {
                for (int y = blur; y < this.transformedImage.GetLength(1) - blur; y++)
                {
                    if (x > 0 && x < this.transformedImage.GetLength(0) - 1 && y > 0 && y < this.transformedImage.GetLength(1) - 1)
                    {
                        Color prevX = this.transformedImage[x - blur, y]; // color variables that take record of the value of an x thats before and after a certain pixel
                        Color NextX = this.transformedImage[x + blur, y];
                        Color PrevY = this.transformedImage[x, y - blur];
                        Color NextY = this.transformedImage[x, y + blur];

                        int a = this.transformedImage[x, y].A;
                        int avgR = ((prevX.R + NextX.R + PrevY.R + NextY.R) / 4); // takes the average of all 3 colors with their previous and next X and Y values dividing them by the total amount which is 4
                        int avgG = ((prevX.G + NextX.G + PrevY.G + NextY.G) / 4);
                        int avgB = ((prevX.B + NextX.B + PrevY.B + NextY.B) / 4);
                        this.bmp.SetPixel(x, y, Color.FromArgb(a, avgR, avgG, avgB)); // displays the image with the regular transparency and the manipulated Average of pixels which give the image a blurring effect
                        this.transformedImage[x, y] = this.bmp.GetPixel(x, y); // sets the transformed image values from the bitmap values to continue stacking
                    }
                }
            }

            this.addToUndoQueue();
            return this.bmp;
        }

        public Bitmap rotate() // method for rotate
        {
            Color[,] temp = new Color[this.transformedImage.GetLength(0), this.transformedImage.GetLength(1)]; // temp 2d color array that takes the color values of transformed image

            for (int x = 0; x < this.transformedImage.GetLength(0); x++)
            {
                for (int y = 0; y < this.transformedImage.GetLength(1); y++)
                {
                    temp[x, y] = this.transformedImage[x, y];
                }
            }

            this.transformedImage = new Color[temp.GetLength(1), temp.GetLength(0)]; // Transformed image  takes the values of the temp colors but X and Y are swapped in order to flip it 90 degrees
            this.bmp = new Bitmap(temp.GetLength(1), temp.GetLength(0)); // bit map takes the value of the temp X and Y
            int NewRow = 0; // int variable initalized at 0
            int NewColumn = 0; 

            for (int x = temp.GetLength(1) - 1; x >= 0; x--)
            {
                NewColumn = 0;
                for (int y = 0; y < temp.GetLength(0); y++) // loops the y depending the length of the temp x
                {
                    this.transformedImage[NewRow, NewColumn] = temp[y, x]; // transformed image array gives its parameters newrow and new coloumn the temp y and x
                    int a = this.transformedImage[NewRow, NewColumn].A;
                    int r = this.transformedImage[NewRow, NewColumn].R;
                    int g = this.transformedImage[NewRow, NewColumn].G;
                    int b = this.transformedImage[NewRow, NewColumn].B;
                    this.bmp.SetPixel(NewRow, NewColumn, Color.FromArgb(a, r, g, b));
                    NewColumn++; // new column is ++ during iteration
                }

                NewRow++; // new row is ++ during outer iteration
            }

            this.addToUndoQueue();
            return this.bmp;
        }

        public Bitmap undo() // method for undo
        {
            this.undoIndex--; // the index is subracted
            int restoredIndex = this.undoIndex - 1; // local int restroyed index is set to the global undo index subtracted by 1
            if (restoredIndex < 0) return this.reset(); // if the restroyed index is less than 0 then it will return the reset

            this.bmp = this.undoBitmapBuffer[restoredIndex]; // the bitmap is set to the undo bitmap array with the restrored index amount as the parameter
            this.transformedImage = this.undoTransformedImageBuffer[restoredIndex]; // the transformed image is given the undo transformed image array value
            this.undoBitmapBuffer[this.undoIndex] = null; // resets memory
            this.undoTransformedImageBuffer[this.undoIndex] = null; // resets memory
            return this.bmp; // returns bitmap
        }

        public bool isUndoEmpty() // Method for empty undo
        {
            if (this.undoIndex <= 0) return true; // if the undo index is less than or = zero then it will return true if not it will return false
            return false;
        }

        private void addToUndoQueue() // method for adding to undo Queue
        {
            Bitmap bitmapCopy = (Bitmap) this.bmp.Clone(); // new bitmap copy that is given the value of the bitmap clone
            Color[,] transformedImageCopy = new Color[this.transformedImage.GetLength(0), this.transformedImage.GetLength(1)]; // transforme dimage copy that is given the color values of the  stacked transformed image

            for (int x = 0; x < this.transformedImage.GetLength(0); x++)
            {
                for (int y = 0; y < this.transformedImage.GetLength(1); y++)
                {
                    transformedImageCopy[x, y] = this.transformedImage[x, y]; // it is looped to give the transformed image copy the values of the transformed image
                }
            }

            if (this.undoIndex < this.undoBitmapBuffer.GetLength(0)) // if the undo index is less than the amount of rows in the undobitmap array then it will set the array to bitmap copy and set the transformed image array into the transformed image copy
            {
                this.undoBitmapBuffer[this.undoIndex] = bitmapCopy;
                this.undoTransformedImageBuffer[this.undoIndex] = transformedImageCopy;
                this.undoIndex++; // the undo index iterates
            } 
            else
            {
                for (int i = 0; i < this.undoBitmapBuffer.GetLength(0) - 1; i++) // loop for the length of the X of undobitmap array - 1
                {
                    this.undoBitmapBuffer[i] = this.undoBitmapBuffer[i + 1]; // yhe undo bitmap value is increased by 1 during every iteration
                    this.undoTransformedImageBuffer[i] = this.undoTransformedImageBuffer[i + 1]; // the undotransformed image  value is increased by 1 during every iteration
                }

                this.undoBitmapBuffer[this.undoBitmapBuffer.GetLength(0) - 1] = bitmapCopy; // this will set the undobitmap array value by the value of the bitmap copy subracted by 1
                this.undoTransformedImageBuffer[this.undoBitmapBuffer.GetLength(0) - 1] = transformedImageCopy;
            }
        }
    }
}
