using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_1_Othello
{
    public partial class Form1 : Form
    {
        public PictureBox[,] picbox2DArr = new PictureBox[12, 8];
        public int whitePiece = 43;
        public int blackPiece = 43;
        public int wOnB = 2;
        public int bOnB = 2;
        public bool blackTurn = true;

        public bool dontAutoTurn = true;
        /**
         * the corresponding 2d int arr
         */
        public int [,] check = new int[8, 8];


        public Form1()
        {
            InitializeComponent();
            /**
             * initialize int 2d arr.
             */
            ini2Darr();
            /**
             * put all the picture box into an array.
             */
            picBox2Arr();

            /**
             * add black to left, white to right.
             */
            add2Pile();
            
            /**
             * drag and drop
             */
            drag_drop();

            
            
            /**
             * the visibility of the Turn button based on the blackTurn value.
             */
            changeTurnButtonVisibility();

            engagePicBoxClick();

        }

        private void picBox2Arr(){
            picbox2DArr[0, 0] = pictureBox1;
            picbox2DArr[0, 1] = pictureBox2;
            picbox2DArr[0, 2] = pictureBox3;
            picbox2DArr[0, 3] = pictureBox4;
            picbox2DArr[0, 4] = pictureBox5;
            picbox2DArr[0, 5] = pictureBox6;
            picbox2DArr[0, 6] = pictureBox7;
            picbox2DArr[0, 7] = pictureBox8;
            picbox2DArr[1, 0] = pictureBox9;
            picbox2DArr[1, 1] = pictureBox10;
            picbox2DArr[1, 2] = pictureBox11;
            picbox2DArr[1, 3] = pictureBox12;
            picbox2DArr[1, 4] = pictureBox13;
            picbox2DArr[1, 5] = pictureBox14;
            picbox2DArr[1, 6] = pictureBox15;
            picbox2DArr[1, 7] = pictureBox16;
            picbox2DArr[2, 0] = pictureBox17;
            picbox2DArr[2, 1] = pictureBox18;
            picbox2DArr[2, 2] = pictureBox19;
            picbox2DArr[2, 3] = pictureBox20;
            picbox2DArr[2, 4] = pictureBox21;
            picbox2DArr[2, 5] = pictureBox22;
            picbox2DArr[2, 6] = pictureBox23;
            picbox2DArr[2, 7] = pictureBox24;
            picbox2DArr[3, 0] = pictureBox25;
            picbox2DArr[3, 1] = pictureBox26;
            picbox2DArr[3, 2] = pictureBox27;
            picbox2DArr[3, 3] = pictureBox28;
            picbox2DArr[3, 4] = pictureBox29;
            picbox2DArr[3, 5] = pictureBox30;
            picbox2DArr[3, 6] = pictureBox31;
            picbox2DArr[3, 7] = pictureBox32;
            picbox2DArr[4, 0] = pictureBox33;
            picbox2DArr[4, 1] = pictureBox34;
            picbox2DArr[4, 2] = pictureBox35;
            picbox2DArr[4, 3] = pictureBox36;
            picbox2DArr[4, 4] = pictureBox37;
            picbox2DArr[4, 5] = pictureBox38;
            picbox2DArr[4, 6] = pictureBox39;
            picbox2DArr[4, 7] = pictureBox40;
            picbox2DArr[5, 0] = pictureBox41;
            picbox2DArr[5, 1] = pictureBox42;
            picbox2DArr[5, 2] = pictureBox43;
            picbox2DArr[5, 3] = pictureBox44;
            picbox2DArr[5, 4] = pictureBox45;
            picbox2DArr[5, 5] = pictureBox46;
            picbox2DArr[5, 6] = pictureBox47;
            picbox2DArr[5, 7] = pictureBox48;
            picbox2DArr[6, 0] = pictureBox49;
            picbox2DArr[6, 1] = pictureBox50;
            picbox2DArr[6, 2] = pictureBox51;
            picbox2DArr[6, 3] = pictureBox52;
            picbox2DArr[6, 4] = pictureBox53;
            picbox2DArr[6, 5] = pictureBox54;
            picbox2DArr[6, 6] = pictureBox55;
            picbox2DArr[6, 7] = pictureBox56;
            picbox2DArr[7, 0] = pictureBox57;
            picbox2DArr[7, 1] = pictureBox58;
            picbox2DArr[7, 2] = pictureBox59;
            picbox2DArr[7, 3] = pictureBox60;
            picbox2DArr[7, 4] = pictureBox61;
            picbox2DArr[7, 5] = pictureBox62;
            picbox2DArr[7, 6] = pictureBox63;
            picbox2DArr[7, 7] = pictureBox64;

            picbox2DArr[8, 0] = pictureBox65;
            picbox2DArr[8, 1] = pictureBox66;
            picbox2DArr[8, 2] = pictureBox67;
            picbox2DArr[8, 3] = pictureBox68;
            picbox2DArr[8, 4] = pictureBox69;
            picbox2DArr[8, 5] = pictureBox70;
            picbox2DArr[8, 6] = pictureBox71;
            picbox2DArr[8, 7] = pictureBox72;
            picbox2DArr[9, 0] = pictureBox73;
            picbox2DArr[9, 1] = pictureBox74;
            picbox2DArr[9, 2] = pictureBox75;
            picbox2DArr[9, 3] = pictureBox76;
            picbox2DArr[9, 4] = pictureBox77;
            picbox2DArr[9, 5] = pictureBox78;
            picbox2DArr[9, 6] = pictureBox79;
            picbox2DArr[9, 7] = pictureBox80;

            picbox2DArr[10, 0] = pictureBox81;
            picbox2DArr[10, 1] = pictureBox82;
            picbox2DArr[10, 2] = pictureBox83;
            picbox2DArr[10, 3] = pictureBox84;
            picbox2DArr[10, 4] = pictureBox85;
            picbox2DArr[10, 5] = pictureBox86;
            picbox2DArr[10, 6] = pictureBox87;
            picbox2DArr[10, 7] = pictureBox88;
            picbox2DArr[11, 0] = pictureBox89;
            picbox2DArr[11, 1] = pictureBox90;
            picbox2DArr[11, 2] = pictureBox91;
            picbox2DArr[11, 3] = pictureBox92;
            picbox2DArr[11, 4] = pictureBox93;
            picbox2DArr[11, 5] = pictureBox94;
            picbox2DArr[11, 6] = pictureBox95;
            picbox2DArr[11, 7] = pictureBox96;
            /**
             * all size mode is central
             */
            int heightL = 25;
            int heightR = 25;
            for (int i = 0; i <= 11; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    picbox2DArr[i, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                    /**
                      * location of left and right pile.
                      */
                    if ((i == 8|| i == 9 ) && j >= 1)
                    {
                        //419 is the biggest
                        picbox2DArr[i, j].Location = new System.Drawing.Point(34, 419 - heightL);
                        heightL += 25;
                        //picbox2DArr[i, j].BringToFront();

                    }else if(i > 9 && j >= 1){
                        picbox2DArr[i, j].Location = new System.Drawing.Point(607, 419 - heightR);
                        heightR += 25;
                        //picbox2DArr[i, j].BringToFront();
                    }
                }
            }
            /**
             * bring all the left right pile picbox to front.
             */
            for (int i = 11; i >= 8 ; i--)
            {
                for (int j = 7; j >= 0; j--)
                {
                    picbox2DArr[i, j].BringToFront();
                }
            }
            
            
            //pictureBox65.Location = new System.Drawing.Point(34, 419);
            //pictureBox81.Location = new System.Drawing.Point(607, 423);
        }

        private void add2Pile()
        {
            for (int i = 11; i >= 8; i--)
            {
                for (int j = 7; j >= 0; j--)
                {
                    if (i == 8 || i == 9)
                        picbox2DArr[i, j].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    else
                        picbox2DArr[i, j].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    picbox2DArr[i, j].BringToFront();
                }
            }
        }

        private void drag_drop()
        {
            /**
            * Regarding the picturebox Drag Drop Events
            */
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    picbox2DArr[i, j].AllowDrop = true;
                    //set the size mode
                    picbox2DArr[i, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                }
            }

            picbox2DArr[0, 0].DragEnter += picbox2DArr00_DragEnter;
            picbox2DArr[0, 0].DragDrop += picbox2DArr00_DragDrop;

            picbox2DArr[0, 1].DragEnter += picbox2DArr01_DragEnter;
            picbox2DArr[0, 1].DragDrop += picbox2DArr01_DragDrop;

            picbox2DArr[0, 2].DragEnter += picbox2DArr02_DragEnter;
            picbox2DArr[0, 2].DragDrop += picbox2DArr02_DragDrop;

            picbox2DArr[0, 3].DragEnter += picbox2DArr03_DragEnter;
            picbox2DArr[0, 3].DragDrop += picbox2DArr03_DragDrop;

            picbox2DArr[0, 4].DragEnter += picbox2DArr04_DragEnter;
            picbox2DArr[0, 4].DragDrop += picbox2DArr04_DragDrop;

            picbox2DArr[0, 5].DragEnter += picbox2DArr05_DragEnter;
            picbox2DArr[0, 5].DragDrop += picbox2DArr05_DragDrop;

            picbox2DArr[0, 6].DragEnter += picbox2DArr06_DragEnter;
            picbox2DArr[0, 6].DragDrop += picbox2DArr06_DragDrop;

            picbox2DArr[0, 7].DragEnter += picbox2DArr07_DragEnter;
            picbox2DArr[0, 7].DragDrop += picbox2DArr07_DragDrop;

            picbox2DArr[1, 0].DragEnter += picbox2DArr10_DragEnter;
            picbox2DArr[1, 0].DragDrop += picbox2DArr10_DragDrop;

            picbox2DArr[1, 1].DragEnter += picbox2DArr11_DragEnter;
            picbox2DArr[1, 1].DragDrop += picbox2DArr11_DragDrop;

            picbox2DArr[1, 2].DragEnter += picbox2DArr12_DragEnter;
            picbox2DArr[1, 2].DragDrop += picbox2DArr12_DragDrop;

            picbox2DArr[1, 3].DragEnter += picbox2DArr13_DragEnter;
            picbox2DArr[1, 3].DragDrop += picbox2DArr13_DragDrop;

            picbox2DArr[1, 4].DragEnter += picbox2DArr14_DragEnter;
            picbox2DArr[1, 4].DragDrop += picbox2DArr14_DragDrop;

            picbox2DArr[1, 5].DragEnter += picbox2DArr15_DragEnter;
            picbox2DArr[1, 5].DragDrop += picbox2DArr15_DragDrop;

            picbox2DArr[1, 6].DragEnter += picbox2DArr16_DragEnter;
            picbox2DArr[1, 6].DragDrop += picbox2DArr16_DragDrop;

            picbox2DArr[1, 7].DragEnter += picbox2DArr17_DragEnter;
            picbox2DArr[1, 7].DragDrop += picbox2DArr17_DragDrop;

            picbox2DArr[2, 0].DragEnter += picbox2DArr20_DragEnter;
            picbox2DArr[2, 0].DragDrop += picbox2DArr20_DragDrop;

            picbox2DArr[2, 1].DragEnter += picbox2DArr21_DragEnter;
            picbox2DArr[2, 1].DragDrop += picbox2DArr21_DragDrop;

            picbox2DArr[2, 2].DragEnter += picbox2DArr22_DragEnter;
            picbox2DArr[2, 2].DragDrop += picbox2DArr22_DragDrop;

            picbox2DArr[2, 3].DragEnter += picbox2DArr23_DragEnter;
            picbox2DArr[2, 3].DragDrop += picbox2DArr23_DragDrop;

            picbox2DArr[2, 4].DragEnter += picbox2DArr24_DragEnter;
            picbox2DArr[2, 4].DragDrop += picbox2DArr24_DragDrop;

            picbox2DArr[2, 5].DragEnter += picbox2DArr25_DragEnter;
            picbox2DArr[2, 5].DragDrop += picbox2DArr25_DragDrop;

            picbox2DArr[2, 6].DragEnter += picbox2DArr26_DragEnter;
            picbox2DArr[2, 6].DragDrop += picbox2DArr26_DragDrop;

            picbox2DArr[2, 7].DragEnter += picbox2DArr27_DragEnter;
            picbox2DArr[2, 7].DragDrop += picbox2DArr27_DragDrop;

            picbox2DArr[3, 0].DragEnter += picbox2DArr30_DragEnter;
            picbox2DArr[3, 0].DragDrop += picbox2DArr30_DragDrop;

            picbox2DArr[3, 1].DragEnter += picbox2DArr31_DragEnter;
            picbox2DArr[3, 1].DragDrop += picbox2DArr31_DragDrop;

            picbox2DArr[3, 2].DragEnter += picbox2DArr32_DragEnter;
            picbox2DArr[3, 2].DragDrop += picbox2DArr32_DragDrop;

            picbox2DArr[3, 3].DragEnter += picbox2DArr33_DragEnter;
            picbox2DArr[3, 3].DragDrop += picbox2DArr33_DragDrop;

            picbox2DArr[3, 4].DragEnter += picbox2DArr34_DragEnter;
            picbox2DArr[3, 4].DragDrop += picbox2DArr34_DragDrop;

            picbox2DArr[3, 5].DragEnter += picbox2DArr35_DragEnter;
            picbox2DArr[3, 5].DragDrop += picbox2DArr35_DragDrop;

            picbox2DArr[3, 6].DragEnter += picbox2DArr36_DragEnter;
            picbox2DArr[3, 6].DragDrop += picbox2DArr36_DragDrop;

            picbox2DArr[3, 7].DragEnter += picbox2DArr37_DragEnter;
            picbox2DArr[3, 7].DragDrop += picbox2DArr37_DragDrop;

            picbox2DArr[4, 0].DragEnter += picbox2DArr40_DragEnter;
            picbox2DArr[4, 0].DragDrop += picbox2DArr40_DragDrop;

            picbox2DArr[4, 1].DragEnter += picbox2DArr41_DragEnter;
            picbox2DArr[4, 1].DragDrop += picbox2DArr41_DragDrop;

            picbox2DArr[4, 2].DragEnter += picbox2DArr42_DragEnter;
            picbox2DArr[4, 2].DragDrop += picbox2DArr42_DragDrop;

            picbox2DArr[4, 3].DragEnter += picbox2DArr43_DragEnter;
            picbox2DArr[4, 3].DragDrop += picbox2DArr43_DragDrop;

            picbox2DArr[4, 4].DragEnter += picbox2DArr44_DragEnter;
            picbox2DArr[4, 4].DragDrop += picbox2DArr44_DragDrop;

            picbox2DArr[4, 5].DragEnter += picbox2DArr45_DragEnter;
            picbox2DArr[4, 5].DragDrop += picbox2DArr45_DragDrop;

            picbox2DArr[4, 6].DragEnter += picbox2DArr46_DragEnter;
            picbox2DArr[4, 6].DragDrop += picbox2DArr46_DragDrop;

            picbox2DArr[4, 7].DragEnter += picbox2DArr47_DragEnter;
            picbox2DArr[4, 7].DragDrop += picbox2DArr47_DragDrop;

            picbox2DArr[5, 0].DragEnter += picbox2DArr50_DragEnter;
            picbox2DArr[5, 0].DragDrop += picbox2DArr50_DragDrop;

            picbox2DArr[5, 1].DragEnter += picbox2DArr51_DragEnter;
            picbox2DArr[5, 1].DragDrop += picbox2DArr51_DragDrop;

            picbox2DArr[5, 2].DragEnter += picbox2DArr52_DragEnter;
            picbox2DArr[5, 2].DragDrop += picbox2DArr52_DragDrop;

            picbox2DArr[5, 3].DragEnter += picbox2DArr53_DragEnter;
            picbox2DArr[5, 3].DragDrop += picbox2DArr53_DragDrop;

            picbox2DArr[5, 4].DragEnter += picbox2DArr54_DragEnter;
            picbox2DArr[5, 4].DragDrop += picbox2DArr54_DragDrop;

            picbox2DArr[5, 5].DragEnter += picbox2DArr55_DragEnter;
            picbox2DArr[5, 5].DragDrop += picbox2DArr55_DragDrop;

            picbox2DArr[5, 6].DragEnter += picbox2DArr56_DragEnter;
            picbox2DArr[5, 6].DragDrop += picbox2DArr56_DragDrop;

            picbox2DArr[5, 7].DragEnter += picbox2DArr57_DragEnter;
            picbox2DArr[5, 7].DragDrop += picbox2DArr57_DragDrop;

            picbox2DArr[6, 0].DragEnter += picbox2DArr60_DragEnter;
            picbox2DArr[6, 0].DragDrop += picbox2DArr60_DragDrop;

            picbox2DArr[6, 1].DragEnter += picbox2DArr61_DragEnter;
            picbox2DArr[6, 1].DragDrop += picbox2DArr61_DragDrop;

            picbox2DArr[6, 2].DragEnter += picbox2DArr62_DragEnter;
            picbox2DArr[6, 2].DragDrop += picbox2DArr62_DragDrop;

            picbox2DArr[6, 3].DragEnter += picbox2DArr63_DragEnter;
            picbox2DArr[6, 3].DragDrop += picbox2DArr63_DragDrop;

            picbox2DArr[6, 4].DragEnter += picbox2DArr64_DragEnter;
            picbox2DArr[6, 4].DragDrop += picbox2DArr64_DragDrop;

            picbox2DArr[6, 5].DragEnter += picbox2DArr65_DragEnter;
            picbox2DArr[6, 5].DragDrop += picbox2DArr65_DragDrop;

            picbox2DArr[6, 6].DragEnter += picbox2DArr66_DragEnter;
            picbox2DArr[6, 6].DragDrop += picbox2DArr66_DragDrop;

            picbox2DArr[6, 7].DragEnter += picbox2DArr67_DragEnter;
            picbox2DArr[6, 7].DragDrop += picbox2DArr67_DragDrop;

            picbox2DArr[7, 0].DragEnter += picbox2DArr70_DragEnter;
            picbox2DArr[7, 0].DragDrop += picbox2DArr70_DragDrop;

            picbox2DArr[7, 1].DragEnter += picbox2DArr71_DragEnter;
            picbox2DArr[7, 1].DragDrop += picbox2DArr71_DragDrop;

            picbox2DArr[7, 2].DragEnter += picbox2DArr72_DragEnter;
            picbox2DArr[7, 2].DragDrop += picbox2DArr72_DragDrop;

            picbox2DArr[7, 3].DragEnter += picbox2DArr73_DragEnter;
            picbox2DArr[7, 3].DragDrop += picbox2DArr73_DragDrop;

            picbox2DArr[7, 4].DragEnter += picbox2DArr74_DragEnter;
            picbox2DArr[7, 4].DragDrop += picbox2DArr74_DragDrop;

            picbox2DArr[7, 5].DragEnter += picbox2DArr75_DragEnter;
            picbox2DArr[7, 5].DragDrop += picbox2DArr75_DragDrop;

            picbox2DArr[7, 6].DragEnter += picbox2DArr76_DragEnter;
            picbox2DArr[7, 6].DragDrop += picbox2DArr76_DragDrop;

            picbox2DArr[7, 7].DragEnter += picbox2DArr77_DragEnter;
            picbox2DArr[7, 7].DragDrop += picbox2DArr77_DragDrop;




            picbox2DArr[8, 0].MouseDown += picbox2DArr80_MouseDown;
            picbox2DArr[8, 0].DragEnter += picbox2DArr80_DragEnter;

            picbox2DArr[10, 0].MouseDown += picbox2DArr100_MouseDown;
            picbox2DArr[10, 0].DragEnter += picbox2DArr100_DragEnter;



        }


        private void picbox2DArr80_MouseDown(object sender, MouseEventArgs e)
        {
            if (blackTurn)
            {
                var img = picbox2DArr[8, 0].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    for (int i = 0; i <= 6; i++)
                    {
                        if (picbox2DArr[8, i + 1].Image != null)
                        {
                            picbox2DArr[8, i].Image = picbox2DArr[8, i + 1].Image;

                        }
                        if (i == 6 && blackPiece >= 16)
                            picbox2DArr[8, 7].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                        else if (i == 6 && blackPiece < 16)
                            picbox2DArr[8, 7].Image = null;
                    }




                    //picboxBitmapList[0, 0].RemoveAt(picboxBitmapList[0, 0].Count - 1);
                    //if (picboxBitmapList[0, 0].Count != 0)
                    //    picbox2DArr[0, 0].Image = picboxBitmapList[0, 0][(picboxBitmapList[0, 0].Count - 1)];
                    //else
                    //    picbox2DArr[0, 0].Image = null;
                }
                blackPiece--;
                bOnB++;
                labelBAmt.Text = blackPiece.ToString();
                labelBlackAmt.Text = bOnB.ToString();





            }//if
        }
        void picbox2DArr80_DragEnter(object sender, DragEventArgs e)
        {
            if (blackTurn)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }


        private void picbox2DArr100_MouseDown(object sender, MouseEventArgs e)
        {
            if (!blackTurn)
            {
                var img = picbox2DArr[10, 0].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    for (int i = 0; i <= 6; i++)
                    {
                        if (picbox2DArr[10, i + 1].Image != null)
                        {
                            picbox2DArr[10, i].Image = picbox2DArr[10, i + 1].Image;

                        }
                        if (i == 6 && whitePiece >= 16)
                            picbox2DArr[10, 7].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                        else if (i == 6 && whitePiece < 16)
                            picbox2DArr[10, 7].Image = null;
                    }
                }
                whitePiece--;
                wOnB++;
                labelWAmt.Text = whitePiece.ToString();
                labelWhiteAmt.Text = wOnB.ToString();
            }
        }
        void picbox2DArr100_DragEnter(object sender, DragEventArgs e)
        {
            if (!blackTurn)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }





        /**
         * DragEnter
         * 00 - 77
         */
        void picbox2DArr00_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr01_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr02_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr03_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr04_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr05_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr06_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr07_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr10_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr11_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr12_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr13_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr14_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr15_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr16_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr17_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr20_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr21_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr22_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr23_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr24_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr25_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr26_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr27_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr30_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr31_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr32_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr33_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr34_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr35_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr36_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr37_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr40_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr41_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr42_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr43_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr44_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr45_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr46_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr47_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr50_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr51_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr52_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr53_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr54_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr55_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr56_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr57_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr60_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr61_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr62_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr63_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr64_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr65_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr66_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr67_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr70_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr71_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr72_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr73_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr74_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr75_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr76_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }
        void picbox2DArr77_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }






        private void flipPiece(int r, int c)
        {
            
                if (blackTurn)
                {
                    //Console.WriteLine("if...");
                    check[r, c] = 1;
                    /**
                     * check row
                     */
                    //row -> left
                    if (c >= 2)
                        for (int i = c - 1; i >= 0; i--)
                        {

                            if (check[r, i] == 1)
                            {
                                //Console.WriteLine("for...");
                                for (int j = i + 1; j <= c - 1; j++)
                                {
                                    check[r, j] = 1;
                                    //picbox2DArr[r, j].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                                    //Console.WriteLine("forfor...");
                                }
                                break;
                            }
                        }//for

                    //row -> right
                    if (c <= 5)
                        for (int i = c + 1; i <= 7; i++)
                        {

                            if (check[r, i] == 1)
                            {
                                //Console.WriteLine("for...");
                                for (int j = i - 1; j >= c + 1; j--)
                                {
                                    check[r, j] = 1;
                                    //picbox2DArr[r, j].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                                    //Console.WriteLine("forfor...");
                                }
                                break;
                            }
                        }//for

                    //col -> up
                    if (r >= 2)
                        for (int i = r - 1; i >= 0; i--)
                        {

                            if (check[i, c] == 1)
                            {
                                //Console.WriteLine("for...");
                                for (int j = i + 1; j <= r - 1; j++)
                                {
                                    check[j, c] = 1;
                                    //picbox2DArr[j, c].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                                    //Console.WriteLine("forfor...");
                                }
                                break;
                            }
                        }//for
                    //col -> down
                    if (r <= 5)
                        for (int i = r + 1; i <= 7; i++)
                        {

                            if (check[i, c] == 1)
                            {
                                //Console.WriteLine("for...");
                                for (int j = i - 1; j >= r + 1; j--)
                                {
                                    check[j, c] = 1;
                                    //picbox2DArr[j, c].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                                    //Console.WriteLine("forfor...");
                                }
                                break;
                            }
                        }//for

                    //"pie" up have problem
                    if (r >= 2 && c <= 5)
                    {
                        //test
                        //check[5, 2] = 0;


                        int cc = c + 1;
                        int rr = r - 1;
                        while (cc <= 7 && rr >= 0)
                        {
                            Console.WriteLine("while...");
                            if (check[rr, cc] == 1)
                            {
                                //cc modify
                                int ccM = cc - 1;
                                int rrM = rr + 1;
                                while (ccM > cc && rrM < rr)
                                {
                                    Console.WriteLine("ccM...");
                                    check[rrM, ccM] = 1;
                                    //picbox2DArr[rrM, ccM].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                                    ccM--;
                                    rrM++;
                                }
                            }//if
                            rr--;
                            cc++;
                        }
                    }



                    //"na"

                    
                    bOnB++;
                    labelBlackAmt.Text = bOnB.ToString(); 

                }//blackTurn
                else if (!blackTurn)
                {
                    //Console.WriteLine("if...");
                    check[r, c] = 0;
                    /**
                     * check row
                     */
                    //row -> left
                    if (c >= 2)
                        for (int i = c - 1; i >= 0; i--)
                        {

                            if (check[r, i] == 0)
                            {
                                //Console.WriteLine("for...");
                                for (int j = i + 1; j <= c - 1; j++)
                                {
                                    check[r, j] = 0;
                                    //picbox2DArr[r, j].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                                    //Console.WriteLine("forfor...");
                                }
                                break;
                            }
                        }//for

                    //row -> right
                    if (c <= 5)
                        for (int i = c + 1; i <= 7; i++)
                        {

                            if (check[r, i] == 0)
                            {
                                //Console.WriteLine("for...");
                                for (int j = i - 1; j >= c + 1; j--)
                                {
                                    check[r, j] = 0;
                                    //picbox2DArr[r, j].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                                    //Console.WriteLine("forfor...");
                                }
                                break;
                            }
                        }//for

                    //col -> up
                    if (r >= 2)
                        for (int i = r - 1; i >= 0; i--)
                        {

                            if (check[i, c] == 0)
                            {
                                //Console.WriteLine("for...");
                                for (int j = i + 1; j <= r - 1; j++)
                                {
                                    check[j, c] = 0;
                                    //picbox2DArr[j, c].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                                    //Console.WriteLine("forfor...");
                                }
                                break;
                            }
                        }//for
                    //col -> down
                    if (r <= 5)
                        for (int i = r + 1; i <= 7; i++)
                        {

                            if (check[i, c] == 0)
                            {
                                //Console.WriteLine("for...");
                                for (int j = i - 1; j >= r + 1; j--)
                                {
                                    check[j, c] = 0;
                                    //picbox2DArr[j, c].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                                    //Console.WriteLine("forfor...");
                                }
                                break;
                            }
                        }//for

                    wOnB++;
                    labelWhiteAmt.Text = wOnB.ToString();
                }//white Turn
        }


        /**
         * DragDrop
         * 00 - 77
         */
        void picbox2DArr00_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[0, 0].Image = bmp;
            flipPiece(0, 0);
        }
        void picbox2DArr01_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[0, 1].Image = bmp;
            flipPiece(0, 1);
        }
        void picbox2DArr02_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[0, 2].Image = bmp;
            flipPiece(0, 2);
        }
        void picbox2DArr03_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[0, 3].Image = bmp;
            flipPiece(0, 3);
        }
        void picbox2DArr04_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[0, 4].Image = bmp;
            flipPiece(0, 4);
        }
        void picbox2DArr05_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[0, 5].Image = bmp;
            flipPiece(0, 5);
        }
        void picbox2DArr06_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[0, 6].Image = bmp;
            flipPiece(0, 6);
        }
        void picbox2DArr07_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[0, 7].Image = bmp;
            flipPiece(0, 7);
        }
        void picbox2DArr10_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[1, 0].Image = bmp;
            flipPiece(1, 0);
        }
        void picbox2DArr11_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[1, 1].Image = bmp;
            flipPiece(1, 1);
        }
        void picbox2DArr12_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[1, 2].Image = bmp;
            flipPiece(1, 2);
        }
        void picbox2DArr13_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[1, 3].Image = bmp;
            flipPiece(1, 3);
        }
        void picbox2DArr14_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[1, 4].Image = bmp;
            flipPiece(1, 4);
        }
        void picbox2DArr15_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[1, 5].Image = bmp;
            flipPiece(1, 5);
        }
        void picbox2DArr16_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[1, 6].Image = bmp;
            flipPiece(1, 6);
        }
        void picbox2DArr17_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[1, 7].Image = bmp;
            flipPiece(1, 7);
        }
        void picbox2DArr20_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[2, 0].Image = bmp;
            flipPiece(2, 0);
        }
        void picbox2DArr21_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[2, 1].Image = bmp;
            flipPiece(2, 1);
        }
        void picbox2DArr22_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[2, 2].Image = bmp;
            flipPiece(2, 2);
        }
        void picbox2DArr23_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[2, 3].Image = bmp;
            flipPiece(2, 3);
        }
        void picbox2DArr24_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[2, 4].Image = bmp;
            flipPiece(2, 4);
        }
        void picbox2DArr25_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[2, 5].Image = bmp;
            flipPiece(2, 5);
        }
        void picbox2DArr26_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[2, 6].Image = bmp;
            flipPiece(2, 6);
        }
        void picbox2DArr27_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[2, 7].Image = bmp;
            flipPiece(2, 7);
        }
        void picbox2DArr30_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[3, 0].Image = bmp;
            flipPiece(3, 0);
        }
        void picbox2DArr31_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[3, 1].Image = bmp;
            flipPiece(3, 1);
        }
        void picbox2DArr32_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[3, 2].Image = bmp;
            flipPiece(3, 2);
        }
        void picbox2DArr33_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[3, 3].Image = bmp;
            flipPiece(3, 3);
        }
        void picbox2DArr34_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[3, 4].Image = bmp;
            flipPiece(3, 4);
        }
        void picbox2DArr35_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[3, 5].Image = bmp;
            flipPiece(3, 5);
        }
        void picbox2DArr36_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[3, 6].Image = bmp;
            flipPiece(3, 6);
        }
        void picbox2DArr37_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[3, 7].Image = bmp;
            flipPiece(3, 7);
        }
        void picbox2DArr40_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[4, 0].Image = bmp;
            flipPiece(4, 0);
        }
        void picbox2DArr41_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[4, 1].Image = bmp;
            flipPiece(4, 1);
        }
        void picbox2DArr42_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[4, 2].Image = bmp;
            flipPiece(4, 2);
        }
        void picbox2DArr43_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[4, 3].Image = bmp;
            flipPiece(4, 3);
        }
        void picbox2DArr44_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[4, 4].Image = bmp;
            flipPiece(4, 4);
        }
        void picbox2DArr45_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[4, 5].Image = bmp;
            flipPiece(4, 5);
        }
        void picbox2DArr46_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[4, 6].Image = bmp;
            flipPiece(4, 6);
        }
        void picbox2DArr47_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[4, 7].Image = bmp;
            flipPiece(4, 7);
        }
        void picbox2DArr50_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[5, 0].Image = bmp;
            flipPiece(5, 0);
        }
        void picbox2DArr51_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[5, 1].Image = bmp;
            flipPiece(5, 1);
        }
        void picbox2DArr52_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[5, 2].Image = bmp;
            flipPiece(5, 2);
        }
        void picbox2DArr53_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[5, 3].Image = bmp;
            flipPiece(5, 3);
        }
        void picbox2DArr54_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[5, 4].Image = bmp;
            flipPiece(5, 4);
        }
        void picbox2DArr55_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[5, 5].Image = bmp;
            flipPiece(5, 5);
        }
        void picbox2DArr56_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[5, 6].Image = bmp;
            flipPiece(5, 6);
        }
        void picbox2DArr57_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[5, 7].Image = bmp;
            flipPiece(5, 7);
        }
        void picbox2DArr60_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[6, 0].Image = bmp;
            flipPiece(6, 0);
        }
        void picbox2DArr61_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[6, 1].Image = bmp;
            flipPiece(6, 1);
        }
        void picbox2DArr62_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[6, 2].Image = bmp;
            flipPiece(6, 2);
        }
        void picbox2DArr63_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[6, 3].Image = bmp;
            flipPiece(6, 3);
        }
        void picbox2DArr64_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[6, 4].Image = bmp;
            flipPiece(6, 4);
        }
        void picbox2DArr65_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[6, 5].Image = bmp;
            flipPiece(6, 5);
        }
        void picbox2DArr66_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[6, 6].Image = bmp;
            flipPiece(6, 6);
        }
        void picbox2DArr67_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[6, 7].Image = bmp;
            flipPiece(6, 7);
        }
        void picbox2DArr70_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[7, 0].Image = bmp;
            flipPiece(7, 0);
        }
        void picbox2DArr71_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[7, 1].Image = bmp;
            flipPiece(7, 1);
        }
        void picbox2DArr72_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[7, 2].Image = bmp;
            flipPiece(7, 2);
        }
        void picbox2DArr73_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[7, 3].Image = bmp;
            flipPiece(7, 3);
        }
        void picbox2DArr74_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[7, 4].Image = bmp;
            flipPiece(7, 4);
        }
        void picbox2DArr75_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[7, 5].Image = bmp;
            flipPiece(7, 5);
        }
        void picbox2DArr76_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[7, 6].Image = bmp;
            flipPiece(7, 6);
        }
        void picbox2DArr77_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picbox2DArr[7, 7].Image = bmp;
            flipPiece(7, 7);
        }






      /**
             * initialize int 2d arr.
             */
            private void ini2Darr(){
                
                for (int i = 0; i <= 7; i++)
                {
                    for (int j = 0; j <= 7; j++)
                    {
                        check[i, j] = -1;
                    }
                }
                check[3, 3] = 0;
                check[4, 4] = 0;

                check[3, 4] = 1;
                check[4, 3] = 1;
            }

            private void changeTurnButtonVisibility()
            {
                if (blackTurn)
                {
                    buttonBT.Visible = false;
                    buttonWT.Visible = true;
                }
                else
                {
                    buttonWT.Visible = false;
                    buttonBT.Visible = true;
                }
            }

            private void buttonBT_Click(object sender, EventArgs e)
            {
                blackTurn = true;
                changeTurnButtonVisibility();
            }

            private void buttonWT_Click(object sender, EventArgs e)
            {
                blackTurn = false;
                changeTurnButtonVisibility();
            }

            /**
             * manual turn
             */

            private void pictureBox1_Click(object sender, EventArgs e)
            {
                if (check[0, 0] == 1)
                {
                    picbox2DArr[0, 0].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[0, 0] = 0;
                }
                else if (check[0, 0] == 0)
                {
                    picbox2DArr[0, 0].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[0, 0] = 1;
                }
            }

            private void pictureBox2_Click(object sender, EventArgs e)
            {
                if (check[0, 1] == 1)
                {
                    picbox2DArr[0, 1].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[0, 1] = 0;
                }
                else if (check[0, 1] == 0)
                {
                    picbox2DArr[0, 1].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[0, 1] = 1;
                }
            }

            private void pictureBox3_Click(object sender, EventArgs e)
            {
                if (check[0, 2] == 1)
                {
                    picbox2DArr[0, 2].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[0, 2] = 0;
                }
                else if (check[0, 2] == 0)
                {
                    picbox2DArr[0, 2].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[0, 2] = 1;
                }
            }

            private void pictureBox4_Click(object sender, EventArgs e)
            {
                if (check[0, 3] == 1)
                {
                    picbox2DArr[0, 3].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[0, 3] = 0;
                }
                else if (check[0, 3] == 0)
                {
                    picbox2DArr[0, 3].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[0, 3] = 1;
                }
            }

            private void pictureBox5_Click(object sender, EventArgs e)
            {
                if (check[0, 4] == 1)
                {
                    picbox2DArr[0, 4].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[0, 4] = 0;
                }
                else if (check[0, 4] == 0)
                {
                    picbox2DArr[0, 4].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[0, 4] = 1;
                }
            }

            private void pictureBox6_Click(object sender, EventArgs e)
            {
                if (check[0, 5] == 1)
                {
                    picbox2DArr[0, 5].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[0, 5] = 0;
                }
                else if (check[0, 5] == 0)
                {
                    picbox2DArr[0, 5].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[0, 5] = 1;
                }
            }

            private void pictureBox7_Click(object sender, EventArgs e)
            {
                if (check[0, 6] == 1)
                {
                    picbox2DArr[0, 6].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[0, 6] = 0;
                }
                else if (check[0, 6] == 0)
                {
                    picbox2DArr[0, 6].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[0, 6] = 1;
                }
            }

            private void pictureBox8_Click(object sender, EventArgs e)
            {
                if (check[0, 7] == 1)
                {
                    picbox2DArr[0, 7].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[0, 7] = 0;
                }
                else if (check[0, 7] == 0)
                {
                    picbox2DArr[0, 7].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[0, 7] = 1;
                }
            }

            private void pictureBox9_Click(object sender, EventArgs e)
            {
                if (check[1, 0] == 1)
                {
                    picbox2DArr[1, 0].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[1, 0] = 0;
                }
                else if (check[1, 0] == 0)
                {
                    picbox2DArr[1, 0].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[1, 0] = 1;
                }
            }

            private void pictureBox10_Click(object sender, EventArgs e)
            {
                if (check[1, 1] == 1)
                {
                    picbox2DArr[1, 1].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[1, 1] = 0;
                }
                else if (check[1, 1] == 0)
                {
                    picbox2DArr[1, 1].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[1, 1] = 1;
                }
            }

            private void pictureBox11_Click(object sender, EventArgs e)
            {
                if (check[1, 2] == 1)
                {
                    picbox2DArr[1, 2].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[1, 2] = 0;
                }
                else if (check[1, 2] == 0)
                {
                    picbox2DArr[1, 2].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[1, 2] = 1;
                }
            }

            private void pictureBox12_Click(object sender, EventArgs e)
            {
                if (check[1, 3] == 1)
                {
                    picbox2DArr[1, 3].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[1, 3] = 0;
                }
                else if (check[1, 3] == 0)
                {
                    picbox2DArr[1, 3].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[1, 3] = 1;
                }
            }

            private void pictureBox13_Click(object sender, EventArgs e)
            {
                if (check[1, 4] == 1)
                {
                    picbox2DArr[1, 4].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[1, 4] = 0;
                }
                else if (check[1, 4] == 0)
                {
                    picbox2DArr[1, 4].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[1, 4] = 1;
                }
            }

            private void pictureBox14_Click(object sender, EventArgs e)
            {
                if (check[1, 5] == 1)
                {
                    picbox2DArr[1, 5].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[1, 5] = 0;
                }
                else if (check[1, 5] == 0)
                {
                    picbox2DArr[1, 5].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[1, 5] = 1;
                }
            }

            private void pictureBox15_Click(object sender, EventArgs e)
            {
                if (check[1, 6] == 1)
                {
                    picbox2DArr[1, 6].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[1, 6] = 0;
                }
                else if (check[1, 6] == 0)
                {
                    picbox2DArr[1, 6].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[1, 6] = 1;
                }
            }

            private void pictureBox16_Click(object sender, EventArgs e)
            {
                if (check[1, 7] == 1)
                {
                    picbox2DArr[1, 7].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[1, 7] = 0;
                }
                else if (check[1, 7] == 0)
                {
                    picbox2DArr[1, 7].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[1, 7] = 1;
                }
            }

            private void pictureBox17_Click(object sender, EventArgs e)
            {
                if (check[2, 0] == 1)
                {
                    picbox2DArr[2, 0].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[2, 0] = 0;
                }
                else if (check[2, 0] == 0)
                {
                    picbox2DArr[2, 0].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[2, 0] = 1;
                }
            }

            private void pictureBox18_Click(object sender, EventArgs e)
            {
                if (check[2, 1] == 1)
                {
                    picbox2DArr[2, 1].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[2, 1] = 0;
                }
                else if (check[2, 1] == 0)
                {
                    picbox2DArr[2, 1].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[2, 1] = 1;
                }
            }

            private void pictureBox19_Click(object sender, EventArgs e)
            {
                if (check[2, 2] == 1)
                {
                    picbox2DArr[2, 2].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[2, 2] = 0;
                }
                else if (check[2, 2] == 0)
                {
                    picbox2DArr[2, 2].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[2, 2] = 1;
                }
            }

            private void pictureBox20_Click(object sender, EventArgs e)
            {
                if (check[2, 3] == 1)
                {
                    picbox2DArr[2, 3].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[2, 3] = 0;
                }
                else if (check[2, 3] == 0)
                {
                    picbox2DArr[2, 3].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[2, 3] = 1;
                }
            }

            private void pictureBox21_Click(object sender, EventArgs e)
            {
                if (check[2, 4] == 1)
                {
                    picbox2DArr[2, 4].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[2, 4] = 0;
                }
                else if (check[2, 4] == 0)
                {
                    picbox2DArr[2, 4].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[2, 4] = 1;
                }
            }

            private void pictureBox22_Click(object sender, EventArgs e)
            {
                if (check[2, 5] == 1)
                {
                    picbox2DArr[2, 5].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[2, 5] = 0;
                }
                else if (check[2, 5] == 0)
                {
                    picbox2DArr[2, 5].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[2, 5] = 1;
                }
            }

            private void pictureBox23_Click(object sender, EventArgs e)
            {
                if (check[2, 6] == 1)
                {
                    picbox2DArr[2, 6].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[2, 6] = 0;
                }
                else if (check[2, 6] == 0)
                {
                    picbox2DArr[2, 6].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[2, 6] = 1;
                }
            }

            private void pictureBox24_Click(object sender, EventArgs e)
            {
                if (check[2, 7] == 1)
                {
                    picbox2DArr[2, 7].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[2, 7] = 0;
                }
                else if (check[2, 7] == 0)
                {
                    picbox2DArr[2, 7].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[2, 7] = 1;
                }
            }

            private void pictureBox25_Click(object sender, EventArgs e)
            {
                if (check[3, 0] == 1)
                {
                    picbox2DArr[3, 0].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[3, 0] = 0;
                }
                else if (check[3, 0] == 0)
                {
                    picbox2DArr[3, 0].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[3, 0] = 1;
                }
            }

            private void pictureBox26_Click(object sender, EventArgs e)
            {
                if (check[3, 1] == 1)
                {
                    picbox2DArr[3, 1].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[3, 1] = 0;
                }
                else if (check[3, 1] == 0)
                {
                    picbox2DArr[3, 1].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[3, 1] = 1;
                }
            }

            private void pictureBox27_Click(object sender, EventArgs e)
            {
                if (check[3, 2] == 1)
                {
                    picbox2DArr[3, 2].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[3, 2] = 0;
                }
                else if (check[3, 2] == 0)
                {
                    picbox2DArr[3, 2].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[3, 2] = 1;
                }
            }

            private void pictureBox28_Click(object sender, EventArgs e)
            {
                if (check[3, 3] == 1)
                {
                    picbox2DArr[3, 3].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[3, 3] = 0;
                }
                else if (check[3, 3] == 0)
                {
                    picbox2DArr[3, 3].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[3, 3] = 1;
                }
            }

            private void pictureBox29_Click(object sender, EventArgs e)
            {
                if (check[3, 4] == 1)
                {
                    picbox2DArr[3, 4].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[3, 4] = 0;
                }
                else if (check[3, 4] == 0)
                {
                    picbox2DArr[3, 4].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[3, 4] = 1;
                }
            }

            private void pictureBox30_Click(object sender, EventArgs e)
            {
                if (check[3, 5] == 1)
                {
                    picbox2DArr[3, 5].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[3, 5] = 0;
                }
                else if (check[3, 5] == 0)
                {
                    picbox2DArr[3, 5].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[3, 5] = 1;
                }
            }

            private void pictureBox31_Click(object sender, EventArgs e)
            {
                if (check[3, 6] == 1)
                {
                    picbox2DArr[3, 6].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[3, 6] = 0;
                }
                else if (check[3, 6] == 0)
                {
                    picbox2DArr[3, 6].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[3, 6] = 1;
                }
            }

            private void pictureBox32_Click(object sender, EventArgs e)
            {
                if (check[3, 7] == 1)
                {
                    picbox2DArr[3, 7].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[3, 7] = 0;
                }
                else if (check[3, 7] == 0)
                {
                    picbox2DArr[3, 7].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[3, 7] = 1;
                }
            }

            private void pictureBox33_Click(object sender, EventArgs e)
            {
                if (check[4, 0] == 1)
                {
                    picbox2DArr[4, 0].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[4, 0] = 0;
                }
                else if (check[4, 0] == 0)
                {
                    picbox2DArr[4, 0].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[4, 0] = 1;
                }
            }

            private void pictureBox34_Click(object sender, EventArgs e)
            {
                if (check[4, 1] == 1)
                {
                    picbox2DArr[4, 1].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[4, 1] = 0;
                }
                else if (check[4, 1] == 0)
                {
                    picbox2DArr[4, 1].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[4, 1] = 1;
                }
            }

            private void pictureBox35_Click(object sender, EventArgs e)
            {
                if (check[4, 2] == 1)
                {
                    picbox2DArr[4, 2].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[4, 2] = 0;
                }
                else if (check[4, 2] == 0)
                {
                    picbox2DArr[4, 2].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[4, 2] = 1;
                }
            }

            private void pictureBox36_Click(object sender, EventArgs e)
            {
                if (check[4, 3] == 1)
                {
                    picbox2DArr[4, 3].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[4, 3] = 0;
                }
                else if (check[4, 3] == 0)
                {
                    picbox2DArr[4, 3].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[4, 3] = 1;
                }
            }

            private void pictureBox37_Click(object sender, EventArgs e)
            {
                if (check[4, 4] == 1)
                {
                    picbox2DArr[4, 4].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[4, 4] = 0;
                }
                else if (check[4, 4] == 0)
                {
                    picbox2DArr[4, 4].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[4, 4] = 1;
                }
            }

            private void pictureBox38_Click(object sender, EventArgs e)
            {
                if (check[4, 5] == 1)
                {
                    picbox2DArr[4, 5].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[4, 5] = 0;
                }
                else if (check[4, 5] == 0)
                {
                    picbox2DArr[4, 5].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[4, 5] = 1;
                }
            }

            private void pictureBox39_Click(object sender, EventArgs e)
            {
                if (check[4, 6] == 1)
                {
                    picbox2DArr[4, 6].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[4, 6] = 0;
                }
                else if (check[4, 6] == 0)
                {
                    picbox2DArr[4, 6].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[4, 6] = 1;
                }
            }

            private void pictureBox40_Click(object sender, EventArgs e)
            {
                if (check[4, 7] == 1)
                {
                    picbox2DArr[4, 7].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[4, 7] = 0;
                }
                else if (check[4, 7] == 0)
                {
                    picbox2DArr[4, 7].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[4, 7] = 1;
                }
            }

            private void pictureBox41_Click(object sender, EventArgs e)
            {
                if (check[5, 0] == 1)
                {
                    picbox2DArr[5, 0].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[5, 0] = 0;
                }
                else if (check[5, 0] == 0)
                {
                    picbox2DArr[5, 0].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[5, 0] = 1;
                }
            }

            private void pictureBox42_Click(object sender, EventArgs e)
            {
                if (check[5, 1] == 1)
                {
                    picbox2DArr[5, 1].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[5, 1] = 0;
                }
                else if (check[5, 1] == 0)
                {
                    picbox2DArr[5, 1].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[5, 1] = 1;
                }
            }

            private void pictureBox43_Click(object sender, EventArgs e)
            {
                if (check[5, 2] == 1)
                {
                    picbox2DArr[5, 2].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[5, 2] = 0;
                }
                else if (check[5, 2] == 0)
                {
                    picbox2DArr[5, 2].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[5, 2] = 1;
                }
            }

            private void pictureBox44_Click(object sender, EventArgs e)
            {
                if (check[5, 3] == 1)
                {
                    picbox2DArr[5, 3].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[5, 3] = 0;
                }
                else if (check[5, 3] == 0)
                {
                    picbox2DArr[5, 3].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[5, 3] = 1;
                }
            }

            private void pictureBox45_Click(object sender, EventArgs e)
            {
                if (check[5, 4] == 1)
                {
                    picbox2DArr[5, 4].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[5, 4] = 0;
                }
                else if (check[5, 4] == 0)
                {
                    picbox2DArr[5, 4].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[5, 4] = 1;
                }
            }

            private void pictureBox46_Click(object sender, EventArgs e)
            {
                if (check[5, 5] == 1)
                {
                    picbox2DArr[5, 5].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[5, 5] = 0;
                }
                else if (check[5, 5] == 0)
                {
                    picbox2DArr[5, 5].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[5, 5] = 1;
                }
            }

            private void pictureBox47_Click(object sender, EventArgs e)
            {
                if (check[5, 6] == 1)
                {
                    picbox2DArr[5, 6].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[5, 6] = 0;
                }
                else if (check[5, 6] == 0)
                {
                    picbox2DArr[5, 6].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[5, 6] = 1;
                }
            }

            private void pictureBox48_Click(object sender, EventArgs e)
            {
                if (check[5, 7] == 1)
                {
                    picbox2DArr[5, 7].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[5, 7] = 0;
                }
                else if (check[5, 7] == 0)
                {
                    picbox2DArr[5, 7].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[5, 7] = 1;
                }
            }

            private void pictureBox49_Click(object sender, EventArgs e)
            {
                if (check[6, 0] == 1)
                {
                    picbox2DArr[6, 0].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[6, 0] = 0;
                }
                else if (check[6, 0] == 0)
                {
                    picbox2DArr[6, 0].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[6, 0] = 1;
                }
            }

            private void pictureBox50_Click(object sender, EventArgs e)
            {
                if (check[6, 1] == 1)
                {
                    picbox2DArr[6, 1].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[6, 1] = 0;
                }
                else if (check[6, 1] == 0)
                {
                    picbox2DArr[6, 1].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[6, 1] = 1;
                }
            }

            private void pictureBox51_Click(object sender, EventArgs e)
            {
                if (check[6, 2] == 1)
                {
                    picbox2DArr[6, 2].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[6, 2] = 0;
                }
                else if (check[6, 2] == 0)
                {
                    picbox2DArr[6, 2].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[6, 2] = 1;
                }
            }

            private void pictureBox52_Click(object sender, EventArgs e)
            {
                if (check[6, 3] == 1)
                {
                    picbox2DArr[6, 3].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[6, 3] = 0;
                }
                else if (check[6, 3] == 0)
                {
                    picbox2DArr[6, 3].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[6, 3] = 1;
                }
            }

            private void pictureBox53_Click(object sender, EventArgs e)
            {
                if (check[6, 4] == 1)
                {
                    picbox2DArr[6, 4].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[6, 4] = 0;
                }
                else if (check[6, 4] == 0)
                {
                    picbox2DArr[6, 4].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[6, 4] = 1;
                }
            }

            private void pictureBox54_Click(object sender, EventArgs e)
            {
                if (check[6, 5] == 1)
                {
                    picbox2DArr[6, 5].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[6, 5] = 0;
                }
                else if (check[6, 5] == 0)
                {
                    picbox2DArr[6, 5].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[6, 5] = 1;
                }
            }

            private void pictureBox55_Click(object sender, EventArgs e)
            {
                if (check[6, 6] == 1)
                {
                    picbox2DArr[6, 6].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[6, 6] = 0;
                }
                else if (check[6, 6] == 0)
                {
                    picbox2DArr[6, 6].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[6, 6] = 1;
                }
            }

            private void pictureBox56_Click(object sender, EventArgs e)
            {
                if (check[6, 7] == 1)
                {
                    picbox2DArr[6, 7].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[6, 7] = 0;
                }
                else if (check[6, 7] == 0)
                {
                    picbox2DArr[6, 7].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[6, 7] = 1;
                }
            }

            private void pictureBox57_Click(object sender, EventArgs e)
            {
                if (check[7, 0] == 1)
                {
                    picbox2DArr[7, 0].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[7, 0] = 0;
                }
                else if (check[7, 0] == 0)
                {
                    picbox2DArr[7, 0].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[7, 0] = 1;
                }
            }

            private void pictureBox58_Click(object sender, EventArgs e)
            {
                if (check[7, 1] == 1)
                {
                    picbox2DArr[7, 1].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[7, 1] = 0;
                }
                else if (check[7, 1] == 0)
                {
                    picbox2DArr[7, 1].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[7, 1] = 1;
                }
            }

            private void pictureBox59_Click(object sender, EventArgs e)
            {
                if (check[7, 2] == 1)
                {
                    picbox2DArr[7, 2].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[7, 2] = 0;
                }
                else if (check[7, 2] == 0)
                {
                    picbox2DArr[7, 2].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[7, 2] = 1;
                }
            }

            private void pictureBox60_Click(object sender, EventArgs e)
            {
                if (check[7, 3] == 1)
                {
                    picbox2DArr[7, 3].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[7, 3] = 0;
                }
                else if (check[7, 3] == 0)
                {
                    picbox2DArr[7, 3].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[7, 3] = 1;
                }
            }

            private void pictureBox61_Click(object sender, EventArgs e)
            {
                if (check[7, 4] == 1)
                {
                    picbox2DArr[7, 4].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[7, 4] = 0;
                }
                else if (check[7, 4] == 0)
                {
                    picbox2DArr[7, 4].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[7, 4] = 1;
                }
            }

            private void pictureBox62_Click(object sender, EventArgs e)
            {
                if (check[7, 5] == 1)
                {
                    picbox2DArr[7, 5].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[7, 5] = 0;
                }
                else if (check[7, 5] == 0)
                {
                    picbox2DArr[7, 5].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[7, 5] = 1;
                }
            }

            private void pictureBox63_Click(object sender, EventArgs e)
            {
                if (check[7, 6] == 1)
                {
                    picbox2DArr[7, 6].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[7, 6] = 0;
                }
                else if (check[7, 6] == 0)
                {
                    picbox2DArr[7, 6].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[7, 6] = 1;
                }
            }

            private void pictureBox64_Click(object sender, EventArgs e)
            {
                if (check[7, 7] == 1)
                {
                    picbox2DArr[7, 7].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("white") as Image);
                    wOnB++;
                    bOnB--;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[7, 7] = 0;
                }
                else if (check[7, 7] == 0)
                {
                    picbox2DArr[7, 7].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("black") as Image);
                    wOnB--;
                    bOnB++;
                    labelWhiteAmt.Text = wOnB.ToString(); labelBlackAmt.Text = bOnB.ToString(); check[7, 7] = 1;
                }
            }



            private void engagePicBoxClick()
            {
                pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
                pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
                pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
                pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
                pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
                pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
                pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
                pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
                pictureBox9.Click += new System.EventHandler(this.pictureBox9_Click);
                pictureBox10.Click += new System.EventHandler(this.pictureBox10_Click);
                pictureBox11.Click += new System.EventHandler(this.pictureBox11_Click);
                pictureBox12.Click += new System.EventHandler(this.pictureBox12_Click);
                pictureBox13.Click += new System.EventHandler(this.pictureBox13_Click);
                pictureBox14.Click += new System.EventHandler(this.pictureBox14_Click);
                pictureBox15.Click += new System.EventHandler(this.pictureBox15_Click);
                pictureBox16.Click += new System.EventHandler(this.pictureBox16_Click);
                pictureBox17.Click += new System.EventHandler(this.pictureBox17_Click);
                pictureBox18.Click += new System.EventHandler(this.pictureBox18_Click);
                pictureBox19.Click += new System.EventHandler(this.pictureBox19_Click);
                pictureBox20.Click += new System.EventHandler(this.pictureBox20_Click);
                pictureBox21.Click += new System.EventHandler(this.pictureBox21_Click);
                pictureBox22.Click += new System.EventHandler(this.pictureBox22_Click);
                pictureBox23.Click += new System.EventHandler(this.pictureBox23_Click);
                pictureBox24.Click += new System.EventHandler(this.pictureBox24_Click);
                pictureBox25.Click += new System.EventHandler(this.pictureBox25_Click);
                pictureBox26.Click += new System.EventHandler(this.pictureBox26_Click);
                pictureBox27.Click += new System.EventHandler(this.pictureBox27_Click);
                pictureBox28.Click += new System.EventHandler(this.pictureBox28_Click);
                pictureBox29.Click += new System.EventHandler(this.pictureBox29_Click);
                pictureBox30.Click += new System.EventHandler(this.pictureBox30_Click);
                pictureBox31.Click += new System.EventHandler(this.pictureBox31_Click);
                pictureBox32.Click += new System.EventHandler(this.pictureBox32_Click);
                pictureBox33.Click += new System.EventHandler(this.pictureBox33_Click);
                pictureBox34.Click += new System.EventHandler(this.pictureBox34_Click);
                pictureBox35.Click += new System.EventHandler(this.pictureBox35_Click);
                pictureBox36.Click += new System.EventHandler(this.pictureBox36_Click);
                pictureBox37.Click += new System.EventHandler(this.pictureBox37_Click);
                pictureBox38.Click += new System.EventHandler(this.pictureBox38_Click);
                pictureBox39.Click += new System.EventHandler(this.pictureBox39_Click);
                pictureBox40.Click += new System.EventHandler(this.pictureBox40_Click);
                pictureBox41.Click += new System.EventHandler(this.pictureBox41_Click);
                pictureBox42.Click += new System.EventHandler(this.pictureBox42_Click);
                pictureBox43.Click += new System.EventHandler(this.pictureBox43_Click);
                pictureBox44.Click += new System.EventHandler(this.pictureBox44_Click);
                pictureBox45.Click += new System.EventHandler(this.pictureBox45_Click);
                pictureBox46.Click += new System.EventHandler(this.pictureBox46_Click);
                pictureBox47.Click += new System.EventHandler(this.pictureBox47_Click);
                pictureBox48.Click += new System.EventHandler(this.pictureBox48_Click);
                pictureBox49.Click += new System.EventHandler(this.pictureBox49_Click);
                pictureBox50.Click += new System.EventHandler(this.pictureBox50_Click);
                pictureBox51.Click += new System.EventHandler(this.pictureBox51_Click);
                pictureBox52.Click += new System.EventHandler(this.pictureBox52_Click);
                pictureBox53.Click += new System.EventHandler(this.pictureBox53_Click);
                pictureBox54.Click += new System.EventHandler(this.pictureBox54_Click);
                pictureBox55.Click += new System.EventHandler(this.pictureBox55_Click);
                pictureBox56.Click += new System.EventHandler(this.pictureBox56_Click);
                pictureBox57.Click += new System.EventHandler(this.pictureBox57_Click);
                pictureBox58.Click += new System.EventHandler(this.pictureBox58_Click);
                pictureBox59.Click += new System.EventHandler(this.pictureBox59_Click);
                pictureBox60.Click += new System.EventHandler(this.pictureBox60_Click);
                pictureBox61.Click += new System.EventHandler(this.pictureBox61_Click);
                pictureBox62.Click += new System.EventHandler(this.pictureBox62_Click);
                pictureBox63.Click += new System.EventHandler(this.pictureBox63_Click);
                pictureBox64.Click += new System.EventHandler(this.pictureBox64_Click);

            }




    }//public partial class Form1 : Form
}
