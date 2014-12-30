using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_1_Solitaire
{
    public partial class Form1 : Form
    {

        public PictureBox[,] picbox2DArr = new PictureBox[22, 7];

        //  picture file named as 101, 102.. meaning card 10, 1st and 2nd color.
        public int[] picName = new int[52];

        public List<Bitmap>[,] picboxBitmapList = new List<Bitmap>[22, 7];

        public int DisAnimationTime = 0;// 200;

        public int shuffleAnimationTime = 0;// 50;

        public int mainDeckCardNum = 28, mainDeckActuralNum = 28;








        //public int showLoop = 1;


        public Form1()
        {
            InitializeComponent();//ok

            initilizePicboxArr_makePicboxInvisible();//ok

            picNameArr();//ok

            addBitmapToMainDeck();//ok

            makeDropable_Draggable();//ok




            

             

        }//form 1

        public void initilizePicboxArr_makePicboxInvisible()
        {
            /*
            * Make reference to all the pictureBoxs.
            * 
            * row 0 ~ 19: rows
            * row 20: 4
            * row 21: 5 + 1
            *      
            * Col: every col in the board.
            * 
            */
            picbox2DArr[0, 0] = pictureBox1;
            picbox2DArr[1, 0] = pictureBox2;
            picbox2DArr[2, 0] = pictureBox3;
            picbox2DArr[3, 0] = pictureBox4;
            picbox2DArr[4, 0] = pictureBox5;
            picbox2DArr[5, 0] = pictureBox6;
            picbox2DArr[6, 0] = pictureBox7;
            picbox2DArr[7, 0] = pictureBox8;
            picbox2DArr[8, 0] = pictureBox9;
            picbox2DArr[9, 0] = pictureBox10;
            picbox2DArr[10, 0] = pictureBox11;
            picbox2DArr[11, 0] = pictureBox12;
            picbox2DArr[12, 0] = pictureBox13;
            picbox2DArr[13, 0] = pictureBox14;
            picbox2DArr[14, 0] = pictureBox15;
            picbox2DArr[15, 0] = pictureBox16;
            picbox2DArr[16, 0] = pictureBox17;
            picbox2DArr[17, 0] = pictureBox18;
            picbox2DArr[18, 0] = pictureBox19;
            picbox2DArr[19, 0] = pictureBox20;

            picbox2DArr[0, 1] = pictureBox40;
            picbox2DArr[1, 1] = pictureBox39;
            picbox2DArr[2, 1] = pictureBox38;
            picbox2DArr[3, 1] = pictureBox37;
            picbox2DArr[4, 1] = pictureBox36;
            picbox2DArr[5, 1] = pictureBox35;
            picbox2DArr[6, 1] = pictureBox34;
            picbox2DArr[7, 1] = pictureBox33;
            picbox2DArr[8, 1] = pictureBox32;
            picbox2DArr[9, 1] = pictureBox31;
            picbox2DArr[10, 1] = pictureBox30;
            picbox2DArr[11, 1] = pictureBox29;
            picbox2DArr[12, 1] = pictureBox28;
            picbox2DArr[13, 1] = pictureBox27;
            picbox2DArr[14, 1] = pictureBox26;
            picbox2DArr[15, 1] = pictureBox25;
            picbox2DArr[16, 1] = pictureBox24;
            picbox2DArr[17, 1] = pictureBox23;
            picbox2DArr[18, 1] = pictureBox22;
            picbox2DArr[19, 1] = pictureBox21;

            picbox2DArr[0, 2] = pictureBox60;
            picbox2DArr[1, 2] = pictureBox59;
            picbox2DArr[2, 2] = pictureBox58;
            picbox2DArr[3, 2] = pictureBox57;
            picbox2DArr[4, 2] = pictureBox56;
            picbox2DArr[5, 2] = pictureBox55;
            picbox2DArr[6, 2] = pictureBox54;
            picbox2DArr[7, 2] = pictureBox53;
            picbox2DArr[8, 2] = pictureBox52;
            picbox2DArr[9, 2] = pictureBox51;
            picbox2DArr[10, 2] = pictureBox50;
            picbox2DArr[11, 2] = pictureBox49;
            picbox2DArr[12, 2] = pictureBox48;
            picbox2DArr[13, 2] = pictureBox47;
            picbox2DArr[14, 2] = pictureBox46;
            picbox2DArr[15, 2] = pictureBox45;
            picbox2DArr[16, 2] = pictureBox44;
            picbox2DArr[17, 2] = pictureBox43;
            picbox2DArr[18, 2] = pictureBox42;
            picbox2DArr[19, 2] = pictureBox41;

            picbox2DArr[0, 3] = pictureBox80;
            picbox2DArr[1, 3] = pictureBox79;
            picbox2DArr[2, 3] = pictureBox78;
            picbox2DArr[3, 3] = pictureBox77;
            picbox2DArr[4, 3] = pictureBox76;
            picbox2DArr[5, 3] = pictureBox75;
            picbox2DArr[6, 3] = pictureBox74;
            picbox2DArr[7, 3] = pictureBox73;
            picbox2DArr[8, 3] = pictureBox72;
            picbox2DArr[9, 3] = pictureBox71;
            picbox2DArr[10, 3] = pictureBox70;
            picbox2DArr[11, 3] = pictureBox69;
            picbox2DArr[12, 3] = pictureBox68;
            picbox2DArr[13, 3] = pictureBox67;
            picbox2DArr[14, 3] = pictureBox66;
            picbox2DArr[15, 3] = pictureBox65;
            picbox2DArr[16, 3] = pictureBox64;
            picbox2DArr[17, 3] = pictureBox63;
            picbox2DArr[18, 3] = pictureBox62;
            picbox2DArr[19, 3] = pictureBox61;

            picbox2DArr[0, 4] = pictureBox100;
            picbox2DArr[1, 4] = pictureBox99;
            picbox2DArr[2, 4] = pictureBox98;
            picbox2DArr[3, 4] = pictureBox97;
            picbox2DArr[4, 4] = pictureBox96;
            picbox2DArr[5, 4] = pictureBox95;
            picbox2DArr[6, 4] = pictureBox94;
            picbox2DArr[7, 4] = pictureBox93;
            picbox2DArr[8, 4] = pictureBox92;
            picbox2DArr[9, 4] = pictureBox91;
            picbox2DArr[10, 4] = pictureBox90;
            picbox2DArr[11, 4] = pictureBox89;
            picbox2DArr[12, 4] = pictureBox88;
            picbox2DArr[13, 4] = pictureBox87;
            picbox2DArr[14, 4] = pictureBox86;
            picbox2DArr[15, 4] = pictureBox85;
            picbox2DArr[16, 4] = pictureBox84;
            picbox2DArr[17, 4] = pictureBox83;
            picbox2DArr[18, 4] = pictureBox82;
            picbox2DArr[19, 4] = pictureBox81;

            picbox2DArr[0, 5] = pictureBox120;
            picbox2DArr[1, 5] = pictureBox119;
            picbox2DArr[2, 5] = pictureBox118;
            picbox2DArr[3, 5] = pictureBox117;
            picbox2DArr[4, 5] = pictureBox116;
            picbox2DArr[5, 5] = pictureBox115;
            picbox2DArr[6, 5] = pictureBox114;
            picbox2DArr[7, 5] = pictureBox113;
            picbox2DArr[8, 5] = pictureBox112;
            picbox2DArr[9, 5] = pictureBox111;
            picbox2DArr[10, 5] = pictureBox110;
            picbox2DArr[11, 5] = pictureBox109;
            picbox2DArr[12, 5] = pictureBox108;
            picbox2DArr[13, 5] = pictureBox107;
            picbox2DArr[14, 5] = pictureBox106;
            picbox2DArr[15, 5] = pictureBox105;
            picbox2DArr[16, 5] = pictureBox104;
            picbox2DArr[17, 5] = pictureBox103;
            picbox2DArr[18, 5] = pictureBox102;
            picbox2DArr[19, 5] = pictureBox101;

            picbox2DArr[0, 6] = pictureBox140;
            picbox2DArr[1, 6] = pictureBox139;
            picbox2DArr[2, 6] = pictureBox138;
            picbox2DArr[3, 6] = pictureBox137;
            picbox2DArr[4, 6] = pictureBox136;
            picbox2DArr[5, 6] = pictureBox135;
            picbox2DArr[6, 6] = pictureBox134;
            picbox2DArr[7, 6] = pictureBox133;
            picbox2DArr[8, 6] = pictureBox132;
            picbox2DArr[9, 6] = pictureBox131;
            picbox2DArr[10, 6] = pictureBox130;
            picbox2DArr[11, 6] = pictureBox129;
            picbox2DArr[12, 6] = pictureBox128;
            picbox2DArr[13, 6] = pictureBox127;
            picbox2DArr[14, 6] = pictureBox126;
            picbox2DArr[15, 6] = pictureBox125;
            picbox2DArr[16, 6] = pictureBox124;
            picbox2DArr[17, 6] = pictureBox123;
            picbox2DArr[18, 6] = pictureBox122;
            picbox2DArr[19, 6] = pictureBox121;

            picbox2DArr[20, 0] = pictureBoxA1;
            picbox2DArr[20, 1] = pictureBoxA2;
            picbox2DArr[20, 2] = pictureBoxA3;
            picbox2DArr[20, 3] = pictureBoxA4;

            picbox2DArr[21, 0] = pictureBoxExtend1;
            picbox2DArr[21, 1] = pictureBoxExtend2;
            picbox2DArr[21, 2] = pictureBoxExtend3;
            picbox2DArr[21, 3] = pictureBoxExtend4;
            picbox2DArr[21, 4] = pictureBoxExtend5;

            picbox2DArr[21, 5] = pictureBoxRemain;

            
            /**
             * Every picbox's border need to be none first AND invisible.
             * (Set All)
             */
            for (int i = 0; i <= 21; i++)
            {
                for (int j = 0; j <= 6; j++)
                {
                    /**
                     * ignore the null reference.
                     */
                    if (i == 20 && j == 4) j = 6;
                    else if (i == 21 && j == 6) { }
                    ///**
                    // * ignore the 4 position and the remaining deck.
                    // */
                    //else if (i == 20 && (j <= 3)) { }
                    //else if (i == 21 && j == 5) { }
                    else
                    {
                        picbox2DArr[i, j].BorderStyle = System.Windows.Forms.BorderStyle.None;
                        //picbox2DArr[i, j].Visible = false;
                        picbox2DArr[i, j].BackColor = Color.Transparent;
                        picbox2DArr[i, j].Image = null;
                        //picbox2DArr[i, j].BackgroundImage = null;
                        picbox2DArr[i, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    }//else
                }//for
            }//for


            /**Need to show the border for first placement position.
             */
            for (int i = 0; i <= 6; i++)
            {
                for (int j = i; j <= 6; j++)
                {
                    picbox2DArr[i, j].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    picbox2DArr[i, j].Visible = true; 
                }
            }

            /**
             * A1, A2, A3, A4 and main deck should be visible and fixed3D border foever.
             */
            //A1, A2, A3, A4
            for (int i = 20; i <= 20; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    picbox2DArr[i, j].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    picbox2DArr[i, j].Visible = true;
                }
            }
            //main deck
            picbox2DArr[21, 5].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            picbox2DArr[21, 5].Visible = true;

            
        }//initilizePicboxArr_makePicboxInvisible()

        public void picNameArr()
        {
            //Create an int array to match the names of picture file.
            int iterator = 10;
            for (int i = 0; i < picName.Length; i++)
            {
                picName[i] = iterator + i % 4 + 1;
                iterator = (i % 4 == 3) ? iterator + 10 : iterator;
                Console.WriteLine("Pic: {0}.", picName[i]);
            }
        }

        public void addBitmapToMainDeck()
        {
            /**
             * instantiate every picboxBitmaplist
             */
            for (int i = 0; i <= 21; i++)
            {
                for (int j = 0; j <= 6; j++)
                {
                    picboxBitmapList[i, j] = new List<Bitmap>();
                }
                
            }
            /**
             * Add all the bitmap onto the main deck
             */

            for (int i = 0; i <= 51; i++)
            {
                picboxBitmapList[21, 5].Add(
                        (Bitmap)(Properties.Resources.ResourceManager.GetObject((picName[i]).ToString()) as Image)
                    );

                //if (AnimationTime != 0)
                //{
                //    /**
                //     * The Dealing animation.
                //     */
                //    //show the card face.
                //    picbox2DArr[4, 4].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject((picName[i % 54]).ToString()) as Image);

                //    //show the topmost card face.
                //    picbox2DArr[4, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

                //    //Modify the label number.
                //    labelCenter.Text = picboxBitmapList[4, 4].Count.ToString();

                //    this.Refresh();
                //    System.Threading.Thread.Sleep(AnimationTime);
                //}//animation
            }
        }


        private void buttonS_Click(object sender, EventArgs e)
        {
            shuffle(picboxBitmapList[21, 5]);

        }//buttonS_click

        //shuffle
        public void shuffle(List<Bitmap> ary)
        {
            /**
             * make topmost 5 visible
             */
            for (int i = 0; i <= 4; i++)
            {
                picbox2DArr[21, i].Visible = true;
            }

            Random rnd = new Random();

            //i > 0 or i >= 0 ?
            for (int i = ary.Count - 1; i > 0; i--)
            //for (int i = 0; i <= ary.Count - 1; i++)
            {
                int r = rnd.Next(0, i);

                Bitmap tmp = ary[i];
                ary[i] = ary[r];
                ary[r] = tmp;

                //pause here show the topmost 5
                showTopmost5();
                //this.Refresh();
                
            }

            /**
             * make topmost 5 invisible
             */
            for (int i = 0; i <= 4; i++)
            {
                picbox2DArr[21, i].Visible = false;
            }
        }

        private void showTopmost5()
        {

            //show the topmost 5. Copy the last 5 card of central.
            for (int i = 0; i <= 4; i++)
            {
                //last index
                picbox2DArr[21, i].Image = picboxBitmapList[21, 5][
                                                                (picboxBitmapList[21, 5].Count - (i+1))
                                                                ];
                picbox2DArr[21, i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                picbox2DArr[21, i].Refresh();
                System.Threading.Thread.Sleep(shuffleAnimationTime);
            }
        }




        //Distribute
        private void buttonDistribute_Click(object sender, EventArgs e)
        {
            //example
            //pictureBoxRemain.Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("101") as Image);
            //pictureBoxRemain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;


            /**
             * Distribute cards in row -> col fashion.
             */
            for (int i = 0; i <= 6; i++)
            {
                for (int j = i; j <= 6; j++)
                {
                    picbox2DArr[i, j].Image = picboxBitmapList[21, 5][
                                                                    (picboxBitmapList[21, 5].Count - 1)
                                                                ];
                    picbox2DArr[i, j].Visible = true;
                    picbox2DArr[i, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

                    //add the distributed card to every position's own bitmap list.
                    picboxBitmapList[i, j].Add(picboxBitmapList[21, 5][
                                                                    (picboxBitmapList[21, 5].Count - 1)
                                                                ]);

                    //remove the topmost card from main deck
                    picboxBitmapList[21, 5].RemoveAt(picboxBitmapList[21, 5].Count - 1);
                    picbox2DArr[i, j].BringToFront();
                    

                    //pause here then flip
                    picbox2DArr[i, j].Refresh();
                    System.Threading.Thread.Sleep(DisAnimationTime);

                    /**
                     * flip the card when it is not the topmost card.
                     */
                    if (j > i)
                    {
                        picbox2DArr[i, j].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("Back") as Image);
                        picbox2DArr[i, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        
                    }

                    picbox2DArr[i, j].BringToFront();
                    picbox2DArr[i, j].Visible = true;

                    picbox2DArr[i, j].Refresh();
                }//for j
            }//for i
        }

        public void makeDropable_Draggable()
        {
            /**
            * Regarding the picturebox Drag Drop Events
            */
            for (int i = 0; i <= 21; i++)
            {
                for (int j = 0; j <= 6; j++)
                {

                    if (i == 20 && j == 4) j = 6;
                    else if (i == 21 && j == 6) { }
                    else
                        picbox2DArr[i, j].AllowDrop = true;

                }
            }
            //Modified
            //picbox2DArr[0, 0].MouseDown += picbox2DArr00_MouseDown;
            //picbox2DArr[0, 0].DragEnter += picbox2DArr00_DragEnter;
            //picbox2DArr[0, 0].DragDrop += picbox2DArr00_DragDrop;
            //picbox2DArr[0, 0].DragLeave += picbox2DArr00_DragLeave;

            //picbox2DArr[0, 1].MouseDown += picbox2DArr01_MouseDown;
            //picbox2DArr[0, 1].DragEnter += picbox2DArr01_DragEnter;
            //picbox2DArr[0, 1].DragDrop += picbox2DArr01_DragDrop;
            //picbox2DArr[0, 1].DragLeave += picbox2DArr01_DragLeave;

            //picbox2DArr[0, 2].MouseDown += picbox2DArr02_MouseDown;
            //picbox2DArr[0, 2].DragEnter += picbox2DArr02_DragEnter;
            //picbox2DArr[0, 2].DragDrop += picbox2DArr02_DragDrop;
            //picbox2DArr[0, 2].DragLeave += picbox2DArr02_DragLeave;

            //picbox2DArr[0, 3].MouseDown += picbox2DArr03_MouseDown;
            //picbox2DArr[0, 3].DragEnter += picbox2DArr03_DragEnter;
            //picbox2DArr[0, 3].DragDrop += picbox2DArr03_DragDrop;
            //picbox2DArr[0, 3].DragLeave += picbox2DArr03_DragLeave;

            //picbox2DArr[0, 4].MouseDown += picbox2DArr04_MouseDown;
            //picbox2DArr[0, 4].DragEnter += picbox2DArr04_DragEnter;
            //picbox2DArr[0, 4].DragDrop += picbox2DArr04_DragDrop;
            //picbox2DArr[0, 4].DragLeave += picbox2DArr04_DragLeave;

            //picbox2DArr[0, 5].MouseDown += picbox2DArr05_MouseDown;
            //picbox2DArr[0, 5].DragEnter += picbox2DArr05_DragEnter;
            //picbox2DArr[0, 5].DragDrop += picbox2DArr05_DragDrop;
            //picbox2DArr[0, 5].DragLeave += picbox2DArr05_DragLeave;

            //picbox2DArr[0, 6].MouseDown += picbox2DArr06_MouseDown;
            //picbox2DArr[0, 6].DragEnter += picbox2DArr06_DragEnter;
            //picbox2DArr[0, 6].DragDrop += picbox2DArr06_DragDrop;
            //picbox2DArr[0, 6].DragLeave += picbox2DArr06_DragLeave;

            //picbox2DArr[1, 0].MouseDown += picbox2DArr10_MouseDown;
            //picbox2DArr[1, 0].DragEnter += picbox2DArr10_DragEnter;
            //picbox2DArr[1, 0].DragDrop += picbox2DArr10_DragDrop;
            //picbox2DArr[1, 0].DragLeave += picbox2DArr10_DragLeave;

            //picbox2DArr[1, 1].MouseDown += picbox2DArr11_MouseDown;
            //picbox2DArr[1, 1].DragEnter += picbox2DArr11_DragEnter;
            //picbox2DArr[1, 1].DragDrop += picbox2DArr11_DragDrop;
            //picbox2DArr[1, 1].DragLeave += picbox2DArr11_DragLeave;

            //picbox2DArr[1, 2].MouseDown += picbox2DArr12_MouseDown;
            //picbox2DArr[1, 2].DragEnter += picbox2DArr12_DragEnter;
            //picbox2DArr[1, 2].DragDrop += picbox2DArr12_DragDrop;
            //picbox2DArr[1, 2].DragLeave += picbox2DArr12_DragLeave;

            //picbox2DArr[1, 3].MouseDown += picbox2DArr13_MouseDown;
            //picbox2DArr[1, 3].DragEnter += picbox2DArr13_DragEnter;
            //picbox2DArr[1, 3].DragDrop += picbox2DArr13_DragDrop;
            //picbox2DArr[1, 3].DragLeave += picbox2DArr13_DragLeave;

            //picbox2DArr[1, 4].MouseDown += picbox2DArr14_MouseDown;
            //picbox2DArr[1, 4].DragEnter += picbox2DArr14_DragEnter;
            //picbox2DArr[1, 4].DragDrop += picbox2DArr14_DragDrop;
            //picbox2DArr[1, 4].DragLeave += picbox2DArr14_DragLeave;

            //picbox2DArr[1, 5].MouseDown += picbox2DArr15_MouseDown;
            //picbox2DArr[1, 5].DragEnter += picbox2DArr15_DragEnter;
            //picbox2DArr[1, 5].DragDrop += picbox2DArr15_DragDrop;
            //picbox2DArr[1, 5].DragLeave += picbox2DArr15_DragLeave;

            //picbox2DArr[1, 6].MouseDown += picbox2DArr16_MouseDown;
            //picbox2DArr[1, 6].DragEnter += picbox2DArr16_DragEnter;
            //picbox2DArr[1, 6].DragDrop += picbox2DArr16_DragDrop;
            //picbox2DArr[1, 6].DragLeave += picbox2DArr16_DragLeave;

            //picbox2DArr[2, 0].MouseDown += picbox2DArr20_MouseDown;
            //picbox2DArr[2, 0].DragEnter += picbox2DArr20_DragEnter;
            //picbox2DArr[2, 0].DragDrop += picbox2DArr20_DragDrop;
            //picbox2DArr[2, 0].DragLeave += picbox2DArr20_DragLeave;

            //picbox2DArr[2, 1].MouseDown += picbox2DArr21_MouseDown;
            //picbox2DArr[2, 1].DragEnter += picbox2DArr21_DragEnter;
            //picbox2DArr[2, 1].DragDrop += picbox2DArr21_DragDrop;
            //picbox2DArr[2, 1].DragLeave += picbox2DArr21_DragLeave;

            //picbox2DArr[2, 2].MouseDown += picbox2DArr22_MouseDown;
            //picbox2DArr[2, 2].DragEnter += picbox2DArr22_DragEnter;
            //picbox2DArr[2, 2].DragDrop += picbox2DArr22_DragDrop;
            //picbox2DArr[2, 2].DragLeave += picbox2DArr22_DragLeave;

            //picbox2DArr[2, 3].MouseDown += picbox2DArr23_MouseDown;
            //picbox2DArr[2, 3].DragEnter += picbox2DArr23_DragEnter;
            //picbox2DArr[2, 3].DragDrop += picbox2DArr23_DragDrop;
            //picbox2DArr[2, 3].DragLeave += picbox2DArr23_DragLeave;

            //picbox2DArr[2, 4].MouseDown += picbox2DArr24_MouseDown;
            //picbox2DArr[2, 4].DragEnter += picbox2DArr24_DragEnter;
            //picbox2DArr[2, 4].DragDrop += picbox2DArr24_DragDrop;
            //picbox2DArr[2, 4].DragLeave += picbox2DArr24_DragLeave;

            //picbox2DArr[2, 5].MouseDown += picbox2DArr25_MouseDown;
            //picbox2DArr[2, 5].DragEnter += picbox2DArr25_DragEnter;
            //picbox2DArr[2, 5].DragDrop += picbox2DArr25_DragDrop;
            //picbox2DArr[2, 5].DragLeave += picbox2DArr25_DragLeave;

            //picbox2DArr[2, 6].MouseDown += picbox2DArr26_MouseDown;
            //picbox2DArr[2, 6].DragEnter += picbox2DArr26_DragEnter;
            //picbox2DArr[2, 6].DragDrop += picbox2DArr26_DragDrop;
            //picbox2DArr[2, 6].DragLeave += picbox2DArr26_DragLeave;

            //picbox2DArr[3, 0].MouseDown += picbox2DArr30_MouseDown;
            //picbox2DArr[3, 0].DragEnter += picbox2DArr30_DragEnter;
            //picbox2DArr[3, 0].DragDrop += picbox2DArr30_DragDrop;
            //picbox2DArr[3, 0].DragLeave += picbox2DArr30_DragLeave;

            //picbox2DArr[3, 1].MouseDown += picbox2DArr31_MouseDown;
            //picbox2DArr[3, 1].DragEnter += picbox2DArr31_DragEnter;
            //picbox2DArr[3, 1].DragDrop += picbox2DArr31_DragDrop;
            //picbox2DArr[3, 1].DragLeave += picbox2DArr31_DragLeave;

            //picbox2DArr[3, 2].MouseDown += picbox2DArr32_MouseDown;
            //picbox2DArr[3, 2].DragEnter += picbox2DArr32_DragEnter;
            //picbox2DArr[3, 2].DragDrop += picbox2DArr32_DragDrop;
            //picbox2DArr[3, 2].DragLeave += picbox2DArr32_DragLeave;

            //picbox2DArr[3, 3].MouseDown += picbox2DArr33_MouseDown;
            //picbox2DArr[3, 3].DragEnter += picbox2DArr33_DragEnter;
            //picbox2DArr[3, 3].DragDrop += picbox2DArr33_DragDrop;
            //picbox2DArr[3, 3].DragLeave += picbox2DArr33_DragLeave;

            //picbox2DArr[3, 4].MouseDown += picbox2DArr34_MouseDown;
            //picbox2DArr[3, 4].DragEnter += picbox2DArr34_DragEnter;
            //picbox2DArr[3, 4].DragDrop += picbox2DArr34_DragDrop;
            //picbox2DArr[3, 4].DragLeave += picbox2DArr34_DragLeave;

            //picbox2DArr[3, 5].MouseDown += picbox2DArr35_MouseDown;
            //picbox2DArr[3, 5].DragEnter += picbox2DArr35_DragEnter;
            //picbox2DArr[3, 5].DragDrop += picbox2DArr35_DragDrop;
            //picbox2DArr[3, 5].DragLeave += picbox2DArr35_DragLeave;

            //picbox2DArr[3, 6].MouseDown += picbox2DArr36_MouseDown;
            //picbox2DArr[3, 6].DragEnter += picbox2DArr36_DragEnter;
            //picbox2DArr[3, 6].DragDrop += picbox2DArr36_DragDrop;
            //picbox2DArr[3, 6].DragLeave += picbox2DArr36_DragLeave;

            //picbox2DArr[4, 0].MouseDown += picbox2DArr40_MouseDown;
            //picbox2DArr[4, 0].DragEnter += picbox2DArr40_DragEnter;
            //picbox2DArr[4, 0].DragDrop += picbox2DArr40_DragDrop;
            //picbox2DArr[4, 0].DragLeave += picbox2DArr40_DragLeave;

            //picbox2DArr[4, 1].MouseDown += picbox2DArr41_MouseDown;
            //picbox2DArr[4, 1].DragEnter += picbox2DArr41_DragEnter;
            //picbox2DArr[4, 1].DragDrop += picbox2DArr41_DragDrop;
            //picbox2DArr[4, 1].DragLeave += picbox2DArr41_DragLeave;

            //picbox2DArr[4, 2].MouseDown += picbox2DArr42_MouseDown;
            //picbox2DArr[4, 2].DragEnter += picbox2DArr42_DragEnter;
            //picbox2DArr[4, 2].DragDrop += picbox2DArr42_DragDrop;
            //picbox2DArr[4, 2].DragLeave += picbox2DArr42_DragLeave;

            //picbox2DArr[4, 3].MouseDown += picbox2DArr43_MouseDown;
            //picbox2DArr[4, 3].DragEnter += picbox2DArr43_DragEnter;
            //picbox2DArr[4, 3].DragDrop += picbox2DArr43_DragDrop;
            //picbox2DArr[4, 3].DragLeave += picbox2DArr43_DragLeave;

            //picbox2DArr[4, 4].MouseDown += picbox2DArr44_MouseDown;
            //picbox2DArr[4, 4].DragEnter += picbox2DArr44_DragEnter;
            //picbox2DArr[4, 4].DragDrop += picbox2DArr44_DragDrop;
            //picbox2DArr[4, 4].DragLeave += picbox2DArr44_DragLeave;

            //picbox2DArr[4, 5].MouseDown += picbox2DArr45_MouseDown;
            //picbox2DArr[4, 5].DragEnter += picbox2DArr45_DragEnter;
            //picbox2DArr[4, 5].DragDrop += picbox2DArr45_DragDrop;
            //picbox2DArr[4, 5].DragLeave += picbox2DArr45_DragLeave;

            //picbox2DArr[4, 6].MouseDown += picbox2DArr46_MouseDown;
            //picbox2DArr[4, 6].DragEnter += picbox2DArr46_DragEnter;
            //picbox2DArr[4, 6].DragDrop += picbox2DArr46_DragDrop;
            //picbox2DArr[4, 6].DragLeave += picbox2DArr46_DragLeave;

            //picbox2DArr[5, 0].MouseDown += picbox2DArr50_MouseDown;
            //picbox2DArr[5, 0].DragEnter += picbox2DArr50_DragEnter;
            //picbox2DArr[5, 0].DragDrop += picbox2DArr50_DragDrop;
            //picbox2DArr[5, 0].DragLeave += picbox2DArr50_DragLeave;

            //picbox2DArr[5, 1].MouseDown += picbox2DArr51_MouseDown;
            //picbox2DArr[5, 1].DragEnter += picbox2DArr51_DragEnter;
            //picbox2DArr[5, 1].DragDrop += picbox2DArr51_DragDrop;
            //picbox2DArr[5, 1].DragLeave += picbox2DArr51_DragLeave;

            //picbox2DArr[5, 2].MouseDown += picbox2DArr52_MouseDown;
            //picbox2DArr[5, 2].DragEnter += picbox2DArr52_DragEnter;
            //picbox2DArr[5, 2].DragDrop += picbox2DArr52_DragDrop;
            //picbox2DArr[5, 2].DragLeave += picbox2DArr52_DragLeave;

            //picbox2DArr[5, 3].MouseDown += picbox2DArr53_MouseDown;
            //picbox2DArr[5, 3].DragEnter += picbox2DArr53_DragEnter;
            //picbox2DArr[5, 3].DragDrop += picbox2DArr53_DragDrop;
            //picbox2DArr[5, 3].DragLeave += picbox2DArr53_DragLeave;

            //picbox2DArr[5, 4].MouseDown += picbox2DArr54_MouseDown;
            //picbox2DArr[5, 4].DragEnter += picbox2DArr54_DragEnter;
            //picbox2DArr[5, 4].DragDrop += picbox2DArr54_DragDrop;
            //picbox2DArr[5, 4].DragLeave += picbox2DArr54_DragLeave;

            //picbox2DArr[5, 5].MouseDown += picbox2DArr55_MouseDown;
            //picbox2DArr[5, 5].DragEnter += picbox2DArr55_DragEnter;
            //picbox2DArr[5, 5].DragDrop += picbox2DArr55_DragDrop;
            //picbox2DArr[5, 5].DragLeave += picbox2DArr55_DragLeave;

            //picbox2DArr[5, 6].MouseDown += picbox2DArr56_MouseDown;
            //picbox2DArr[5, 6].DragEnter += picbox2DArr56_DragEnter;
            //picbox2DArr[5, 6].DragDrop += picbox2DArr56_DragDrop;
            //picbox2DArr[5, 6].DragLeave += picbox2DArr56_DragLeave;

            //picbox2DArr[6, 0].MouseDown += picbox2DArr60_MouseDown;
            //picbox2DArr[6, 0].DragEnter += picbox2DArr60_DragEnter;
            //picbox2DArr[6, 0].DragDrop += picbox2DArr60_DragDrop;
            //picbox2DArr[6, 0].DragLeave += picbox2DArr60_DragLeave;

            //picbox2DArr[6, 1].MouseDown += picbox2DArr61_MouseDown;
            //picbox2DArr[6, 1].DragEnter += picbox2DArr61_DragEnter;
            //picbox2DArr[6, 1].DragDrop += picbox2DArr61_DragDrop;
            //picbox2DArr[6, 1].DragLeave += picbox2DArr61_DragLeave;

            //picbox2DArr[6, 2].MouseDown += picbox2DArr62_MouseDown;
            //picbox2DArr[6, 2].DragEnter += picbox2DArr62_DragEnter;
            //picbox2DArr[6, 2].DragDrop += picbox2DArr62_DragDrop;
            //picbox2DArr[6, 2].DragLeave += picbox2DArr62_DragLeave;

            //picbox2DArr[6, 3].MouseDown += picbox2DArr63_MouseDown;
            //picbox2DArr[6, 3].DragEnter += picbox2DArr63_DragEnter;
            //picbox2DArr[6, 3].DragDrop += picbox2DArr63_DragDrop;
            //picbox2DArr[6, 3].DragLeave += picbox2DArr63_DragLeave;

            //picbox2DArr[6, 4].MouseDown += picbox2DArr64_MouseDown;
            //picbox2DArr[6, 4].DragEnter += picbox2DArr64_DragEnter;
            //picbox2DArr[6, 4].DragDrop += picbox2DArr64_DragDrop;
            //picbox2DArr[6, 4].DragLeave += picbox2DArr64_DragLeave;

            //picbox2DArr[6, 5].MouseDown += picbox2DArr65_MouseDown;
            //picbox2DArr[6, 5].DragEnter += picbox2DArr65_DragEnter;
            //picbox2DArr[6, 5].DragDrop += picbox2DArr65_DragDrop;
            //picbox2DArr[6, 5].DragLeave += picbox2DArr65_DragLeave;

            //picbox2DArr[6, 6].MouseDown += picbox2DArr66_MouseDown;
            //picbox2DArr[6, 6].DragEnter += picbox2DArr66_DragEnter;
            //picbox2DArr[6, 6].DragDrop += picbox2DArr66_DragDrop;
            //picbox2DArr[6, 6].DragLeave += picbox2DArr66_DragLeave;

            //picbox2DArr[7, 0].MouseDown += picbox2DArr70_MouseDown;
            //picbox2DArr[7, 0].DragEnter += picbox2DArr70_DragEnter;
            //picbox2DArr[7, 0].DragDrop += picbox2DArr70_DragDrop;
            //picbox2DArr[7, 0].DragLeave += picbox2DArr70_DragLeave;

            //picbox2DArr[7, 1].MouseDown += picbox2DArr71_MouseDown;
            //picbox2DArr[7, 1].DragEnter += picbox2DArr71_DragEnter;
            //picbox2DArr[7, 1].DragDrop += picbox2DArr71_DragDrop;
            //picbox2DArr[7, 1].DragLeave += picbox2DArr71_DragLeave;

            //picbox2DArr[7, 2].MouseDown += picbox2DArr72_MouseDown;
            //picbox2DArr[7, 2].DragEnter += picbox2DArr72_DragEnter;
            //picbox2DArr[7, 2].DragDrop += picbox2DArr72_DragDrop;
            //picbox2DArr[7, 2].DragLeave += picbox2DArr72_DragLeave;

            //picbox2DArr[7, 3].MouseDown += picbox2DArr73_MouseDown;
            //picbox2DArr[7, 3].DragEnter += picbox2DArr73_DragEnter;
            //picbox2DArr[7, 3].DragDrop += picbox2DArr73_DragDrop;
            //picbox2DArr[7, 3].DragLeave += picbox2DArr73_DragLeave;

            //picbox2DArr[7, 4].MouseDown += picbox2DArr74_MouseDown;
            //picbox2DArr[7, 4].DragEnter += picbox2DArr74_DragEnter;
            //picbox2DArr[7, 4].DragDrop += picbox2DArr74_DragDrop;
            //picbox2DArr[7, 4].DragLeave += picbox2DArr74_DragLeave;

            //picbox2DArr[7, 5].MouseDown += picbox2DArr75_MouseDown;
            //picbox2DArr[7, 5].DragEnter += picbox2DArr75_DragEnter;
            //picbox2DArr[7, 5].DragDrop += picbox2DArr75_DragDrop;
            //picbox2DArr[7, 5].DragLeave += picbox2DArr75_DragLeave;

            //picbox2DArr[7, 6].MouseDown += picbox2DArr76_MouseDown;
            //picbox2DArr[7, 6].DragEnter += picbox2DArr76_DragEnter;
            //picbox2DArr[7, 6].DragDrop += picbox2DArr76_DragDrop;
            //picbox2DArr[7, 6].DragLeave += picbox2DArr76_DragLeave;

            //picbox2DArr[8, 0].MouseDown += picbox2DArr80_MouseDown;
            //picbox2DArr[8, 0].DragEnter += picbox2DArr80_DragEnter;
            //picbox2DArr[8, 0].DragDrop += picbox2DArr80_DragDrop;
            //picbox2DArr[8, 0].DragLeave += picbox2DArr80_DragLeave;

            //picbox2DArr[8, 1].MouseDown += picbox2DArr81_MouseDown;
            //picbox2DArr[8, 1].DragEnter += picbox2DArr81_DragEnter;
            //picbox2DArr[8, 1].DragDrop += picbox2DArr81_DragDrop;
            //picbox2DArr[8, 1].DragLeave += picbox2DArr81_DragLeave;

            //picbox2DArr[8, 2].MouseDown += picbox2DArr82_MouseDown;
            //picbox2DArr[8, 2].DragEnter += picbox2DArr82_DragEnter;
            //picbox2DArr[8, 2].DragDrop += picbox2DArr82_DragDrop;
            //picbox2DArr[8, 2].DragLeave += picbox2DArr82_DragLeave;

            //picbox2DArr[8, 3].MouseDown += picbox2DArr83_MouseDown;
            //picbox2DArr[8, 3].DragEnter += picbox2DArr83_DragEnter;
            //picbox2DArr[8, 3].DragDrop += picbox2DArr83_DragDrop;
            //picbox2DArr[8, 3].DragLeave += picbox2DArr83_DragLeave;

            //picbox2DArr[8, 4].MouseDown += picbox2DArr84_MouseDown;
            //picbox2DArr[8, 4].DragEnter += picbox2DArr84_DragEnter;
            //picbox2DArr[8, 4].DragDrop += picbox2DArr84_DragDrop;
            //picbox2DArr[8, 4].DragLeave += picbox2DArr84_DragLeave;

            //picbox2DArr[8, 5].MouseDown += picbox2DArr85_MouseDown;
            //picbox2DArr[8, 5].DragEnter += picbox2DArr85_DragEnter;
            //picbox2DArr[8, 5].DragDrop += picbox2DArr85_DragDrop;
            //picbox2DArr[8, 5].DragLeave += picbox2DArr85_DragLeave;

            //picbox2DArr[8, 6].MouseDown += picbox2DArr86_MouseDown;
            //picbox2DArr[8, 6].DragEnter += picbox2DArr86_DragEnter;
            //picbox2DArr[8, 6].DragDrop += picbox2DArr86_DragDrop;
            //picbox2DArr[8, 6].DragLeave += picbox2DArr86_DragLeave;

            //picbox2DArr[9, 0].MouseDown += picbox2DArr90_MouseDown;
            //picbox2DArr[9, 0].DragEnter += picbox2DArr90_DragEnter;
            //picbox2DArr[9, 0].DragDrop += picbox2DArr90_DragDrop;
            //picbox2DArr[9, 0].DragLeave += picbox2DArr90_DragLeave;

            //picbox2DArr[9, 1].MouseDown += picbox2DArr91_MouseDown;
            //picbox2DArr[9, 1].DragEnter += picbox2DArr91_DragEnter;
            //picbox2DArr[9, 1].DragDrop += picbox2DArr91_DragDrop;
            //picbox2DArr[9, 1].DragLeave += picbox2DArr91_DragLeave;

            //picbox2DArr[9, 2].MouseDown += picbox2DArr92_MouseDown;
            //picbox2DArr[9, 2].DragEnter += picbox2DArr92_DragEnter;
            //picbox2DArr[9, 2].DragDrop += picbox2DArr92_DragDrop;
            //picbox2DArr[9, 2].DragLeave += picbox2DArr92_DragLeave;

            //picbox2DArr[9, 3].MouseDown += picbox2DArr93_MouseDown;
            //picbox2DArr[9, 3].DragEnter += picbox2DArr93_DragEnter;
            //picbox2DArr[9, 3].DragDrop += picbox2DArr93_DragDrop;
            //picbox2DArr[9, 3].DragLeave += picbox2DArr93_DragLeave;

            //picbox2DArr[9, 4].MouseDown += picbox2DArr94_MouseDown;
            //picbox2DArr[9, 4].DragEnter += picbox2DArr94_DragEnter;
            //picbox2DArr[9, 4].DragDrop += picbox2DArr94_DragDrop;
            //picbox2DArr[9, 4].DragLeave += picbox2DArr94_DragLeave;

            //picbox2DArr[9, 5].MouseDown += picbox2DArr95_MouseDown;
            //picbox2DArr[9, 5].DragEnter += picbox2DArr95_DragEnter;
            //picbox2DArr[9, 5].DragDrop += picbox2DArr95_DragDrop;
            //picbox2DArr[9, 5].DragLeave += picbox2DArr95_DragLeave;

            //picbox2DArr[9, 6].MouseDown += picbox2DArr96_MouseDown;
            //picbox2DArr[9, 6].DragEnter += picbox2DArr96_DragEnter;
            //picbox2DArr[9, 6].DragDrop += picbox2DArr96_DragDrop;
            //picbox2DArr[9, 6].DragLeave += picbox2DArr96_DragLeave;

            //picbox2DArr[10, 0].MouseDown += picbox2DArr100_MouseDown;
            //picbox2DArr[10, 0].DragEnter += picbox2DArr100_DragEnter;
            //picbox2DArr[10, 0].DragDrop += picbox2DArr100_DragDrop;
            //picbox2DArr[10, 0].DragLeave += picbox2DArr100_DragLeave;

            //picbox2DArr[10, 1].MouseDown += picbox2DArr101_MouseDown;
            //picbox2DArr[10, 1].DragEnter += picbox2DArr101_DragEnter;
            //picbox2DArr[10, 1].DragDrop += picbox2DArr101_DragDrop;
            //picbox2DArr[10, 1].DragLeave += picbox2DArr101_DragLeave;

            //picbox2DArr[10, 2].MouseDown += picbox2DArr102_MouseDown;
            //picbox2DArr[10, 2].DragEnter += picbox2DArr102_DragEnter;
            //picbox2DArr[10, 2].DragDrop += picbox2DArr102_DragDrop;
            //picbox2DArr[10, 2].DragLeave += picbox2DArr102_DragLeave;

            //picbox2DArr[10, 3].MouseDown += picbox2DArr103_MouseDown;
            //picbox2DArr[10, 3].DragEnter += picbox2DArr103_DragEnter;
            //picbox2DArr[10, 3].DragDrop += picbox2DArr103_DragDrop;
            //picbox2DArr[10, 3].DragLeave += picbox2DArr103_DragLeave;

            //picbox2DArr[10, 4].MouseDown += picbox2DArr104_MouseDown;
            //picbox2DArr[10, 4].DragEnter += picbox2DArr104_DragEnter;
            //picbox2DArr[10, 4].DragDrop += picbox2DArr104_DragDrop;
            //picbox2DArr[10, 4].DragLeave += picbox2DArr104_DragLeave;

            //picbox2DArr[10, 5].MouseDown += picbox2DArr105_MouseDown;
            //picbox2DArr[10, 5].DragEnter += picbox2DArr105_DragEnter;
            //picbox2DArr[10, 5].DragDrop += picbox2DArr105_DragDrop;
            //picbox2DArr[10, 5].DragLeave += picbox2DArr105_DragLeave;

            //picbox2DArr[10, 6].MouseDown += picbox2DArr106_MouseDown;
            //picbox2DArr[10, 6].DragEnter += picbox2DArr106_DragEnter;
            //picbox2DArr[10, 6].DragDrop += picbox2DArr106_DragDrop;
            //picbox2DArr[10, 6].DragLeave += picbox2DArr106_DragLeave;

            //picbox2DArr[11, 0].MouseDown += picbox2DArr110_MouseDown;
            //picbox2DArr[11, 0].DragEnter += picbox2DArr110_DragEnter;
            //picbox2DArr[11, 0].DragDrop += picbox2DArr110_DragDrop;
            //picbox2DArr[11, 0].DragLeave += picbox2DArr110_DragLeave;

            //picbox2DArr[11, 1].MouseDown += picbox2DArr111_MouseDown;
            //picbox2DArr[11, 1].DragEnter += picbox2DArr111_DragEnter;
            //picbox2DArr[11, 1].DragDrop += picbox2DArr111_DragDrop;
            //picbox2DArr[11, 1].DragLeave += picbox2DArr111_DragLeave;

            //picbox2DArr[11, 2].MouseDown += picbox2DArr112_MouseDown;
            //picbox2DArr[11, 2].DragEnter += picbox2DArr112_DragEnter;
            //picbox2DArr[11, 2].DragDrop += picbox2DArr112_DragDrop;
            //picbox2DArr[11, 2].DragLeave += picbox2DArr112_DragLeave;

            //picbox2DArr[11, 3].MouseDown += picbox2DArr113_MouseDown;
            //picbox2DArr[11, 3].DragEnter += picbox2DArr113_DragEnter;
            //picbox2DArr[11, 3].DragDrop += picbox2DArr113_DragDrop;
            //picbox2DArr[11, 3].DragLeave += picbox2DArr113_DragLeave;

            //picbox2DArr[11, 4].MouseDown += picbox2DArr114_MouseDown;
            //picbox2DArr[11, 4].DragEnter += picbox2DArr114_DragEnter;
            //picbox2DArr[11, 4].DragDrop += picbox2DArr114_DragDrop;
            //picbox2DArr[11, 4].DragLeave += picbox2DArr114_DragLeave;

            //picbox2DArr[11, 5].MouseDown += picbox2DArr115_MouseDown;
            //picbox2DArr[11, 5].DragEnter += picbox2DArr115_DragEnter;
            //picbox2DArr[11, 5].DragDrop += picbox2DArr115_DragDrop;
            //picbox2DArr[11, 5].DragLeave += picbox2DArr115_DragLeave;

            //picbox2DArr[11, 6].MouseDown += picbox2DArr116_MouseDown;
            //picbox2DArr[11, 6].DragEnter += picbox2DArr116_DragEnter;
            //picbox2DArr[11, 6].DragDrop += picbox2DArr116_DragDrop;
            //picbox2DArr[11, 6].DragLeave += picbox2DArr116_DragLeave;

            //picbox2DArr[12, 0].MouseDown += picbox2DArr120_MouseDown;
            //picbox2DArr[12, 0].DragEnter += picbox2DArr120_DragEnter;
            //picbox2DArr[12, 0].DragDrop += picbox2DArr120_DragDrop;
            //picbox2DArr[12, 0].DragLeave += picbox2DArr120_DragLeave;

            //picbox2DArr[12, 1].MouseDown += picbox2DArr121_MouseDown;
            //picbox2DArr[12, 1].DragEnter += picbox2DArr121_DragEnter;
            //picbox2DArr[12, 1].DragDrop += picbox2DArr121_DragDrop;
            //picbox2DArr[12, 1].DragLeave += picbox2DArr121_DragLeave;

            //picbox2DArr[12, 2].MouseDown += picbox2DArr122_MouseDown;
            //picbox2DArr[12, 2].DragEnter += picbox2DArr122_DragEnter;
            //picbox2DArr[12, 2].DragDrop += picbox2DArr122_DragDrop;
            //picbox2DArr[12, 2].DragLeave += picbox2DArr122_DragLeave;

            //picbox2DArr[12, 3].MouseDown += picbox2DArr123_MouseDown;
            //picbox2DArr[12, 3].DragEnter += picbox2DArr123_DragEnter;
            //picbox2DArr[12, 3].DragDrop += picbox2DArr123_DragDrop;
            //picbox2DArr[12, 3].DragLeave += picbox2DArr123_DragLeave;

            //picbox2DArr[12, 4].MouseDown += picbox2DArr124_MouseDown;
            //picbox2DArr[12, 4].DragEnter += picbox2DArr124_DragEnter;
            //picbox2DArr[12, 4].DragDrop += picbox2DArr124_DragDrop;
            //picbox2DArr[12, 4].DragLeave += picbox2DArr124_DragLeave;

            //picbox2DArr[12, 5].MouseDown += picbox2DArr125_MouseDown;
            //picbox2DArr[12, 5].DragEnter += picbox2DArr125_DragEnter;
            //picbox2DArr[12, 5].DragDrop += picbox2DArr125_DragDrop;
            //picbox2DArr[12, 5].DragLeave += picbox2DArr125_DragLeave;

            //picbox2DArr[12, 6].MouseDown += picbox2DArr126_MouseDown;
            //picbox2DArr[12, 6].DragEnter += picbox2DArr126_DragEnter;
            //picbox2DArr[12, 6].DragDrop += picbox2DArr126_DragDrop;
            //picbox2DArr[12, 6].DragLeave += picbox2DArr126_DragLeave;

            //picbox2DArr[13, 0].MouseDown += picbox2DArr130_MouseDown;
            //picbox2DArr[13, 0].DragEnter += picbox2DArr130_DragEnter;
            //picbox2DArr[13, 0].DragDrop += picbox2DArr130_DragDrop;
            //picbox2DArr[13, 0].DragLeave += picbox2DArr130_DragLeave;

            //picbox2DArr[13, 1].MouseDown += picbox2DArr131_MouseDown;
            //picbox2DArr[13, 1].DragEnter += picbox2DArr131_DragEnter;
            //picbox2DArr[13, 1].DragDrop += picbox2DArr131_DragDrop;
            //picbox2DArr[13, 1].DragLeave += picbox2DArr131_DragLeave;

            //picbox2DArr[13, 2].MouseDown += picbox2DArr132_MouseDown;
            //picbox2DArr[13, 2].DragEnter += picbox2DArr132_DragEnter;
            //picbox2DArr[13, 2].DragDrop += picbox2DArr132_DragDrop;
            //picbox2DArr[13, 2].DragLeave += picbox2DArr132_DragLeave;

            //picbox2DArr[13, 3].MouseDown += picbox2DArr133_MouseDown;
            //picbox2DArr[13, 3].DragEnter += picbox2DArr133_DragEnter;
            //picbox2DArr[13, 3].DragDrop += picbox2DArr133_DragDrop;
            //picbox2DArr[13, 3].DragLeave += picbox2DArr133_DragLeave;

            //picbox2DArr[13, 4].MouseDown += picbox2DArr134_MouseDown;
            //picbox2DArr[13, 4].DragEnter += picbox2DArr134_DragEnter;
            //picbox2DArr[13, 4].DragDrop += picbox2DArr134_DragDrop;
            //picbox2DArr[13, 4].DragLeave += picbox2DArr134_DragLeave;

            //picbox2DArr[13, 5].MouseDown += picbox2DArr135_MouseDown;
            //picbox2DArr[13, 5].DragEnter += picbox2DArr135_DragEnter;
            //picbox2DArr[13, 5].DragDrop += picbox2DArr135_DragDrop;
            //picbox2DArr[13, 5].DragLeave += picbox2DArr135_DragLeave;

            //picbox2DArr[13, 6].MouseDown += picbox2DArr136_MouseDown;
            //picbox2DArr[13, 6].DragEnter += picbox2DArr136_DragEnter;
            //picbox2DArr[13, 6].DragDrop += picbox2DArr136_DragDrop;
            //picbox2DArr[13, 6].DragLeave += picbox2DArr136_DragLeave;

            //picbox2DArr[14, 0].MouseDown += picbox2DArr140_MouseDown;
            //picbox2DArr[14, 0].DragEnter += picbox2DArr140_DragEnter;
            //picbox2DArr[14, 0].DragDrop += picbox2DArr140_DragDrop;
            //picbox2DArr[14, 0].DragLeave += picbox2DArr140_DragLeave;

            //picbox2DArr[14, 1].MouseDown += picbox2DArr141_MouseDown;
            //picbox2DArr[14, 1].DragEnter += picbox2DArr141_DragEnter;
            //picbox2DArr[14, 1].DragDrop += picbox2DArr141_DragDrop;
            //picbox2DArr[14, 1].DragLeave += picbox2DArr141_DragLeave;

            //picbox2DArr[14, 2].MouseDown += picbox2DArr142_MouseDown;
            //picbox2DArr[14, 2].DragEnter += picbox2DArr142_DragEnter;
            //picbox2DArr[14, 2].DragDrop += picbox2DArr142_DragDrop;
            //picbox2DArr[14, 2].DragLeave += picbox2DArr142_DragLeave;

            //picbox2DArr[14, 3].MouseDown += picbox2DArr143_MouseDown;
            //picbox2DArr[14, 3].DragEnter += picbox2DArr143_DragEnter;
            //picbox2DArr[14, 3].DragDrop += picbox2DArr143_DragDrop;
            //picbox2DArr[14, 3].DragLeave += picbox2DArr143_DragLeave;

            //picbox2DArr[14, 4].MouseDown += picbox2DArr144_MouseDown;
            //picbox2DArr[14, 4].DragEnter += picbox2DArr144_DragEnter;
            //picbox2DArr[14, 4].DragDrop += picbox2DArr144_DragDrop;
            //picbox2DArr[14, 4].DragLeave += picbox2DArr144_DragLeave;

            //picbox2DArr[14, 5].MouseDown += picbox2DArr145_MouseDown;
            //picbox2DArr[14, 5].DragEnter += picbox2DArr145_DragEnter;
            //picbox2DArr[14, 5].DragDrop += picbox2DArr145_DragDrop;
            //picbox2DArr[14, 5].DragLeave += picbox2DArr145_DragLeave;

            //picbox2DArr[14, 6].MouseDown += picbox2DArr146_MouseDown;
            //picbox2DArr[14, 6].DragEnter += picbox2DArr146_DragEnter;
            //picbox2DArr[14, 6].DragDrop += picbox2DArr146_DragDrop;
            //picbox2DArr[14, 6].DragLeave += picbox2DArr146_DragLeave;

            //picbox2DArr[15, 0].MouseDown += picbox2DArr150_MouseDown;
            //picbox2DArr[15, 0].DragEnter += picbox2DArr150_DragEnter;
            //picbox2DArr[15, 0].DragDrop += picbox2DArr150_DragDrop;
            //picbox2DArr[15, 0].DragLeave += picbox2DArr150_DragLeave;

            //picbox2DArr[15, 1].MouseDown += picbox2DArr151_MouseDown;
            //picbox2DArr[15, 1].DragEnter += picbox2DArr151_DragEnter;
            //picbox2DArr[15, 1].DragDrop += picbox2DArr151_DragDrop;
            //picbox2DArr[15, 1].DragLeave += picbox2DArr151_DragLeave;

            //picbox2DArr[15, 2].MouseDown += picbox2DArr152_MouseDown;
            //picbox2DArr[15, 2].DragEnter += picbox2DArr152_DragEnter;
            //picbox2DArr[15, 2].DragDrop += picbox2DArr152_DragDrop;
            //picbox2DArr[15, 2].DragLeave += picbox2DArr152_DragLeave;

            //picbox2DArr[15, 3].MouseDown += picbox2DArr153_MouseDown;
            //picbox2DArr[15, 3].DragEnter += picbox2DArr153_DragEnter;
            //picbox2DArr[15, 3].DragDrop += picbox2DArr153_DragDrop;
            //picbox2DArr[15, 3].DragLeave += picbox2DArr153_DragLeave;

            //picbox2DArr[15, 4].MouseDown += picbox2DArr154_MouseDown;
            //picbox2DArr[15, 4].DragEnter += picbox2DArr154_DragEnter;
            //picbox2DArr[15, 4].DragDrop += picbox2DArr154_DragDrop;
            //picbox2DArr[15, 4].DragLeave += picbox2DArr154_DragLeave;

            //picbox2DArr[15, 5].MouseDown += picbox2DArr155_MouseDown;
            //picbox2DArr[15, 5].DragEnter += picbox2DArr155_DragEnter;
            //picbox2DArr[15, 5].DragDrop += picbox2DArr155_DragDrop;
            //picbox2DArr[15, 5].DragLeave += picbox2DArr155_DragLeave;

            //picbox2DArr[15, 6].MouseDown += picbox2DArr156_MouseDown;
            //picbox2DArr[15, 6].DragEnter += picbox2DArr156_DragEnter;
            //picbox2DArr[15, 6].DragDrop += picbox2DArr156_DragDrop;
            //picbox2DArr[15, 6].DragLeave += picbox2DArr156_DragLeave;

            //picbox2DArr[16, 0].MouseDown += picbox2DArr160_MouseDown;
            //picbox2DArr[16, 0].DragEnter += picbox2DArr160_DragEnter;
            //picbox2DArr[16, 0].DragDrop += picbox2DArr160_DragDrop;
            //picbox2DArr[16, 0].DragLeave += picbox2DArr160_DragLeave;

            //picbox2DArr[16, 1].MouseDown += picbox2DArr161_MouseDown;
            //picbox2DArr[16, 1].DragEnter += picbox2DArr161_DragEnter;
            //picbox2DArr[16, 1].DragDrop += picbox2DArr161_DragDrop;
            //picbox2DArr[16, 1].DragLeave += picbox2DArr161_DragLeave;

            //picbox2DArr[16, 2].MouseDown += picbox2DArr162_MouseDown;
            //picbox2DArr[16, 2].DragEnter += picbox2DArr162_DragEnter;
            //picbox2DArr[16, 2].DragDrop += picbox2DArr162_DragDrop;
            //picbox2DArr[16, 2].DragLeave += picbox2DArr162_DragLeave;

            //picbox2DArr[16, 3].MouseDown += picbox2DArr163_MouseDown;
            //picbox2DArr[16, 3].DragEnter += picbox2DArr163_DragEnter;
            //picbox2DArr[16, 3].DragDrop += picbox2DArr163_DragDrop;
            //picbox2DArr[16, 3].DragLeave += picbox2DArr163_DragLeave;

            //picbox2DArr[16, 4].MouseDown += picbox2DArr164_MouseDown;
            //picbox2DArr[16, 4].DragEnter += picbox2DArr164_DragEnter;
            //picbox2DArr[16, 4].DragDrop += picbox2DArr164_DragDrop;
            //picbox2DArr[16, 4].DragLeave += picbox2DArr164_DragLeave;

            //picbox2DArr[16, 5].MouseDown += picbox2DArr165_MouseDown;
            //picbox2DArr[16, 5].DragEnter += picbox2DArr165_DragEnter;
            //picbox2DArr[16, 5].DragDrop += picbox2DArr165_DragDrop;
            //picbox2DArr[16, 5].DragLeave += picbox2DArr165_DragLeave;

            //picbox2DArr[16, 6].MouseDown += picbox2DArr166_MouseDown;
            //picbox2DArr[16, 6].DragEnter += picbox2DArr166_DragEnter;
            //picbox2DArr[16, 6].DragDrop += picbox2DArr166_DragDrop;
            //picbox2DArr[16, 6].DragLeave += picbox2DArr166_DragLeave;

            //picbox2DArr[17, 0].MouseDown += picbox2DArr170_MouseDown;
            //picbox2DArr[17, 0].DragEnter += picbox2DArr170_DragEnter;
            //picbox2DArr[17, 0].DragDrop += picbox2DArr170_DragDrop;
            //picbox2DArr[17, 0].DragLeave += picbox2DArr170_DragLeave;

            //picbox2DArr[17, 1].MouseDown += picbox2DArr171_MouseDown;
            //picbox2DArr[17, 1].DragEnter += picbox2DArr171_DragEnter;
            //picbox2DArr[17, 1].DragDrop += picbox2DArr171_DragDrop;
            //picbox2DArr[17, 1].DragLeave += picbox2DArr171_DragLeave;

            //picbox2DArr[17, 2].MouseDown += picbox2DArr172_MouseDown;
            //picbox2DArr[17, 2].DragEnter += picbox2DArr172_DragEnter;
            //picbox2DArr[17, 2].DragDrop += picbox2DArr172_DragDrop;
            //picbox2DArr[17, 2].DragLeave += picbox2DArr172_DragLeave;

            //picbox2DArr[17, 3].MouseDown += picbox2DArr173_MouseDown;
            //picbox2DArr[17, 3].DragEnter += picbox2DArr173_DragEnter;
            //picbox2DArr[17, 3].DragDrop += picbox2DArr173_DragDrop;
            //picbox2DArr[17, 3].DragLeave += picbox2DArr173_DragLeave;

            //picbox2DArr[17, 4].MouseDown += picbox2DArr174_MouseDown;
            //picbox2DArr[17, 4].DragEnter += picbox2DArr174_DragEnter;
            //picbox2DArr[17, 4].DragDrop += picbox2DArr174_DragDrop;
            //picbox2DArr[17, 4].DragLeave += picbox2DArr174_DragLeave;

            //picbox2DArr[17, 5].MouseDown += picbox2DArr175_MouseDown;
            //picbox2DArr[17, 5].DragEnter += picbox2DArr175_DragEnter;
            //picbox2DArr[17, 5].DragDrop += picbox2DArr175_DragDrop;
            //picbox2DArr[17, 5].DragLeave += picbox2DArr175_DragLeave;

            //picbox2DArr[17, 6].MouseDown += picbox2DArr176_MouseDown;
            //picbox2DArr[17, 6].DragEnter += picbox2DArr176_DragEnter;
            //picbox2DArr[17, 6].DragDrop += picbox2DArr176_DragDrop;
            //picbox2DArr[17, 6].DragLeave += picbox2DArr176_DragLeave;

            //picbox2DArr[18, 0].MouseDown += picbox2DArr180_MouseDown;
            //picbox2DArr[18, 0].DragEnter += picbox2DArr180_DragEnter;
            //picbox2DArr[18, 0].DragDrop += picbox2DArr180_DragDrop;
            //picbox2DArr[18, 0].DragLeave += picbox2DArr180_DragLeave;

            //picbox2DArr[18, 1].MouseDown += picbox2DArr181_MouseDown;
            //picbox2DArr[18, 1].DragEnter += picbox2DArr181_DragEnter;
            //picbox2DArr[18, 1].DragDrop += picbox2DArr181_DragDrop;
            //picbox2DArr[18, 1].DragLeave += picbox2DArr181_DragLeave;

            //picbox2DArr[18, 2].MouseDown += picbox2DArr182_MouseDown;
            //picbox2DArr[18, 2].DragEnter += picbox2DArr182_DragEnter;
            //picbox2DArr[18, 2].DragDrop += picbox2DArr182_DragDrop;
            //picbox2DArr[18, 2].DragLeave += picbox2DArr182_DragLeave;

            //picbox2DArr[18, 3].MouseDown += picbox2DArr183_MouseDown;
            //picbox2DArr[18, 3].DragEnter += picbox2DArr183_DragEnter;
            //picbox2DArr[18, 3].DragDrop += picbox2DArr183_DragDrop;
            //picbox2DArr[18, 3].DragLeave += picbox2DArr183_DragLeave;

            //picbox2DArr[18, 4].MouseDown += picbox2DArr184_MouseDown;
            //picbox2DArr[18, 4].DragEnter += picbox2DArr184_DragEnter;
            //picbox2DArr[18, 4].DragDrop += picbox2DArr184_DragDrop;
            //picbox2DArr[18, 4].DragLeave += picbox2DArr184_DragLeave;

            //picbox2DArr[18, 5].MouseDown += picbox2DArr185_MouseDown;
            //picbox2DArr[18, 5].DragEnter += picbox2DArr185_DragEnter;
            //picbox2DArr[18, 5].DragDrop += picbox2DArr185_DragDrop;
            //picbox2DArr[18, 5].DragLeave += picbox2DArr185_DragLeave;

            //picbox2DArr[18, 6].MouseDown += picbox2DArr186_MouseDown;
            //picbox2DArr[18, 6].DragEnter += picbox2DArr186_DragEnter;
            //picbox2DArr[18, 6].DragDrop += picbox2DArr186_DragDrop;
            //picbox2DArr[18, 6].DragLeave += picbox2DArr186_DragLeave;

            //picbox2DArr[19, 0].MouseDown += picbox2DArr190_MouseDown;
            //picbox2DArr[19, 0].DragEnter += picbox2DArr190_DragEnter;
            //picbox2DArr[19, 0].DragDrop += picbox2DArr190_DragDrop;
            //picbox2DArr[19, 0].DragLeave += picbox2DArr190_DragLeave;

            //picbox2DArr[19, 1].MouseDown += picbox2DArr191_MouseDown;
            //picbox2DArr[19, 1].DragEnter += picbox2DArr191_DragEnter;
            //picbox2DArr[19, 1].DragDrop += picbox2DArr191_DragDrop;
            //picbox2DArr[19, 1].DragLeave += picbox2DArr191_DragLeave;

            //picbox2DArr[19, 2].MouseDown += picbox2DArr192_MouseDown;
            //picbox2DArr[19, 2].DragEnter += picbox2DArr192_DragEnter;
            //picbox2DArr[19, 2].DragDrop += picbox2DArr192_DragDrop;
            //picbox2DArr[19, 2].DragLeave += picbox2DArr192_DragLeave;

            //picbox2DArr[19, 3].MouseDown += picbox2DArr193_MouseDown;
            //picbox2DArr[19, 3].DragEnter += picbox2DArr193_DragEnter;
            //picbox2DArr[19, 3].DragDrop += picbox2DArr193_DragDrop;
            //picbox2DArr[19, 3].DragLeave += picbox2DArr193_DragLeave;

            //picbox2DArr[19, 4].MouseDown += picbox2DArr194_MouseDown;
            //picbox2DArr[19, 4].DragEnter += picbox2DArr194_DragEnter;
            //picbox2DArr[19, 4].DragDrop += picbox2DArr194_DragDrop;
            //picbox2DArr[19, 4].DragLeave += picbox2DArr194_DragLeave;

            //picbox2DArr[19, 5].MouseDown += picbox2DArr195_MouseDown;
            //picbox2DArr[19, 5].DragEnter += picbox2DArr195_DragEnter;
            //picbox2DArr[19, 5].DragDrop += picbox2DArr195_DragDrop;
            //picbox2DArr[19, 5].DragLeave += picbox2DArr195_DragLeave;

            //picbox2DArr[19, 6].MouseDown += picbox2DArr196_MouseDown;
            //picbox2DArr[19, 6].DragEnter += picbox2DArr196_DragEnter;
            //picbox2DArr[19, 6].DragDrop += picbox2DArr196_DragDrop;
            //picbox2DArr[19, 6].DragLeave += picbox2DArr196_DragLeave;

            //picbox2DArr[20, 0].MouseDown += picbox2DArr200_MouseDown;
            //picbox2DArr[20, 0].DragEnter += picbox2DArr200_DragEnter;
            //picbox2DArr[20, 0].DragDrop += picbox2DArr200_DragDrop;
            //picbox2DArr[20, 0].DragLeave += picbox2DArr200_DragLeave;

            //picbox2DArr[20, 1].MouseDown += picbox2DArr201_MouseDown;
            //picbox2DArr[20, 1].DragEnter += picbox2DArr201_DragEnter;
            //picbox2DArr[20, 1].DragDrop += picbox2DArr201_DragDrop;
            //picbox2DArr[20, 1].DragLeave += picbox2DArr201_DragLeave;

            //picbox2DArr[20, 2].MouseDown += picbox2DArr202_MouseDown;
            //picbox2DArr[20, 2].DragEnter += picbox2DArr202_DragEnter;
            //picbox2DArr[20, 2].DragDrop += picbox2DArr202_DragDrop;
            //picbox2DArr[20, 2].DragLeave += picbox2DArr202_DragLeave;

            //picbox2DArr[20, 3].MouseDown += picbox2DArr203_MouseDown;
            //picbox2DArr[20, 3].DragEnter += picbox2DArr203_DragEnter;
            //picbox2DArr[20, 3].DragDrop += picbox2DArr203_DragDrop;
            //picbox2DArr[20, 3].DragLeave += picbox2DArr203_DragLeave;

            ////picbox2DArr[20, 4].MouseDown += picbox2DArr204_MouseDown;
            ////picbox2DArr[20, 4].DragEnter += picbox2DArr204_DragEnter;
            ////picbox2DArr[20, 4].DragDrop += picbox2DArr204_DragDrop;
            ////picbox2DArr[20, 4].DragLeave += picbox2DArr204_DragLeave;

            ////picbox2DArr[20, 5].MouseDown += picbox2DArr205_MouseDown;
            ////picbox2DArr[20, 5].DragEnter += picbox2DArr205_DragEnter;
            ////picbox2DArr[20, 5].DragDrop += picbox2DArr205_DragDrop;
            ////picbox2DArr[20, 5].DragLeave += picbox2DArr205_DragLeave;

            ////picbox2DArr[20, 6].MouseDown += picbox2DArr206_MouseDown;
            ////picbox2DArr[20, 6].DragEnter += picbox2DArr206_DragEnter;
            ////picbox2DArr[20, 6].DragDrop += picbox2DArr206_DragDrop;
            ////picbox2DArr[20, 6].DragLeave += picbox2DArr206_DragLeave;

            //picbox2DArr[21, 0].MouseDown += picbox2DArr210_MouseDown;
            //picbox2DArr[21, 0].DragEnter += picbox2DArr210_DragEnter;
            //picbox2DArr[21, 0].DragDrop += picbox2DArr210_DragDrop;
            //picbox2DArr[21, 0].DragLeave += picbox2DArr210_DragLeave;

            //picbox2DArr[21, 1].MouseDown += picbox2DArr211_MouseDown;
            //picbox2DArr[21, 1].DragEnter += picbox2DArr211_DragEnter;
            //picbox2DArr[21, 1].DragDrop += picbox2DArr211_DragDrop;
            //picbox2DArr[21, 1].DragLeave += picbox2DArr211_DragLeave;

            //picbox2DArr[21, 2].MouseDown += picbox2DArr212_MouseDown;
            //picbox2DArr[21, 2].DragEnter += picbox2DArr212_DragEnter;
            //picbox2DArr[21, 2].DragDrop += picbox2DArr212_DragDrop;
            //picbox2DArr[21, 2].DragLeave += picbox2DArr212_DragLeave;

            //picbox2DArr[21, 3].MouseDown += picbox2DArr213_MouseDown;
            //picbox2DArr[21, 3].DragEnter += picbox2DArr213_DragEnter;
            //picbox2DArr[21, 3].DragDrop += picbox2DArr213_DragDrop;
            //picbox2DArr[21, 3].DragLeave += picbox2DArr213_DragLeave;

            //picbox2DArr[21, 4].MouseDown += picbox2DArr214_MouseDown;
            //picbox2DArr[21, 4].DragEnter += picbox2DArr214_DragEnter;
            //picbox2DArr[21, 4].DragDrop += picbox2DArr214_DragDrop;
            //picbox2DArr[21, 4].DragLeave += picbox2DArr214_DragLeave;

            //picbox2DArr[21, 5].MouseDown += picbox2DArr215_MouseDown;
            //picbox2DArr[21, 5].DragEnter += picbox2DArr215_DragEnter;
            //picbox2DArr[21, 5].DragDrop += picbox2DArr215_DragDrop;
            //picbox2DArr[21, 5].DragLeave += picbox2DArr215_DragLeave;

            ////picbox2DArr[21, 6].MouseDown += picbox2DArr216_MouseDown;
            ////picbox2DArr[21, 6].DragEnter += picbox2DArr216_DragEnter;
            ////picbox2DArr[21, 6].DragDrop += picbox2DArr216_DragDrop;
            ////picbox2DArr[21, 6].DragLeave += picbox2DArr216_DragLeave;

            //Original
            picbox2DArr[0, 0].MouseDown += picbox2DArr00_MouseDown;
            picbox2DArr[0, 0].DragEnter += picbox2DArr00_DragEnter;
            picbox2DArr[0, 0].DragDrop += picbox2DArr00_DragDrop;

            picbox2DArr[0, 1].MouseDown += picbox2DArr01_MouseDown;
            picbox2DArr[0, 1].DragEnter += picbox2DArr01_DragEnter;
            picbox2DArr[0, 1].DragDrop += picbox2DArr01_DragDrop;

            picbox2DArr[0, 2].MouseDown += picbox2DArr02_MouseDown;
            picbox2DArr[0, 2].DragEnter += picbox2DArr02_DragEnter;
            picbox2DArr[0, 2].DragDrop += picbox2DArr02_DragDrop;

            picbox2DArr[0, 3].MouseDown += picbox2DArr03_MouseDown;
            picbox2DArr[0, 3].DragEnter += picbox2DArr03_DragEnter;
            picbox2DArr[0, 3].DragDrop += picbox2DArr03_DragDrop;

            picbox2DArr[0, 4].MouseDown += picbox2DArr04_MouseDown;
            picbox2DArr[0, 4].DragEnter += picbox2DArr04_DragEnter;
            picbox2DArr[0, 4].DragDrop += picbox2DArr04_DragDrop;

            picbox2DArr[0, 5].MouseDown += picbox2DArr05_MouseDown;
            picbox2DArr[0, 5].DragEnter += picbox2DArr05_DragEnter;
            picbox2DArr[0, 5].DragDrop += picbox2DArr05_DragDrop;

            picbox2DArr[0, 6].MouseDown += picbox2DArr06_MouseDown;
            picbox2DArr[0, 6].DragEnter += picbox2DArr06_DragEnter;
            picbox2DArr[0, 6].DragDrop += picbox2DArr06_DragDrop;

            picbox2DArr[1, 0].MouseDown += picbox2DArr10_MouseDown;
            picbox2DArr[1, 0].DragEnter += picbox2DArr10_DragEnter;
            picbox2DArr[1, 0].DragDrop += picbox2DArr10_DragDrop;

            picbox2DArr[1, 1].MouseDown += picbox2DArr11_MouseDown;
            picbox2DArr[1, 1].DragEnter += picbox2DArr11_DragEnter;
            picbox2DArr[1, 1].DragDrop += picbox2DArr11_DragDrop;

            picbox2DArr[1, 2].MouseDown += picbox2DArr12_MouseDown;
            picbox2DArr[1, 2].DragEnter += picbox2DArr12_DragEnter;
            picbox2DArr[1, 2].DragDrop += picbox2DArr12_DragDrop;

            picbox2DArr[1, 3].MouseDown += picbox2DArr13_MouseDown;
            picbox2DArr[1, 3].DragEnter += picbox2DArr13_DragEnter;
            picbox2DArr[1, 3].DragDrop += picbox2DArr13_DragDrop;

            picbox2DArr[1, 4].MouseDown += picbox2DArr14_MouseDown;
            picbox2DArr[1, 4].DragEnter += picbox2DArr14_DragEnter;
            picbox2DArr[1, 4].DragDrop += picbox2DArr14_DragDrop;

            picbox2DArr[1, 5].MouseDown += picbox2DArr15_MouseDown;
            picbox2DArr[1, 5].DragEnter += picbox2DArr15_DragEnter;
            picbox2DArr[1, 5].DragDrop += picbox2DArr15_DragDrop;

            picbox2DArr[1, 6].MouseDown += picbox2DArr16_MouseDown;
            picbox2DArr[1, 6].DragEnter += picbox2DArr16_DragEnter;
            picbox2DArr[1, 6].DragDrop += picbox2DArr16_DragDrop;

            picbox2DArr[2, 0].MouseDown += picbox2DArr20_MouseDown;
            picbox2DArr[2, 0].DragEnter += picbox2DArr20_DragEnter;
            picbox2DArr[2, 0].DragDrop += picbox2DArr20_DragDrop;

            picbox2DArr[2, 1].MouseDown += picbox2DArr21_MouseDown;
            picbox2DArr[2, 1].DragEnter += picbox2DArr21_DragEnter;
            picbox2DArr[2, 1].DragDrop += picbox2DArr21_DragDrop;

            picbox2DArr[2, 2].MouseDown += picbox2DArr22_MouseDown;
            picbox2DArr[2, 2].DragEnter += picbox2DArr22_DragEnter;
            picbox2DArr[2, 2].DragDrop += picbox2DArr22_DragDrop;

            picbox2DArr[2, 3].MouseDown += picbox2DArr23_MouseDown;
            picbox2DArr[2, 3].DragEnter += picbox2DArr23_DragEnter;
            picbox2DArr[2, 3].DragDrop += picbox2DArr23_DragDrop;

            picbox2DArr[2, 4].MouseDown += picbox2DArr24_MouseDown;
            picbox2DArr[2, 4].DragEnter += picbox2DArr24_DragEnter;
            picbox2DArr[2, 4].DragDrop += picbox2DArr24_DragDrop;

            picbox2DArr[2, 5].MouseDown += picbox2DArr25_MouseDown;
            picbox2DArr[2, 5].DragEnter += picbox2DArr25_DragEnter;
            picbox2DArr[2, 5].DragDrop += picbox2DArr25_DragDrop;

            picbox2DArr[2, 6].MouseDown += picbox2DArr26_MouseDown;
            picbox2DArr[2, 6].DragEnter += picbox2DArr26_DragEnter;
            picbox2DArr[2, 6].DragDrop += picbox2DArr26_DragDrop;

            picbox2DArr[3, 0].MouseDown += picbox2DArr30_MouseDown;
            picbox2DArr[3, 0].DragEnter += picbox2DArr30_DragEnter;
            picbox2DArr[3, 0].DragDrop += picbox2DArr30_DragDrop;

            picbox2DArr[3, 1].MouseDown += picbox2DArr31_MouseDown;
            picbox2DArr[3, 1].DragEnter += picbox2DArr31_DragEnter;
            picbox2DArr[3, 1].DragDrop += picbox2DArr31_DragDrop;

            picbox2DArr[3, 2].MouseDown += picbox2DArr32_MouseDown;
            picbox2DArr[3, 2].DragEnter += picbox2DArr32_DragEnter;
            picbox2DArr[3, 2].DragDrop += picbox2DArr32_DragDrop;

            picbox2DArr[3, 3].MouseDown += picbox2DArr33_MouseDown;
            picbox2DArr[3, 3].DragEnter += picbox2DArr33_DragEnter;
            picbox2DArr[3, 3].DragDrop += picbox2DArr33_DragDrop;

            picbox2DArr[3, 4].MouseDown += picbox2DArr34_MouseDown;
            picbox2DArr[3, 4].DragEnter += picbox2DArr34_DragEnter;
            picbox2DArr[3, 4].DragDrop += picbox2DArr34_DragDrop;

            picbox2DArr[3, 5].MouseDown += picbox2DArr35_MouseDown;
            picbox2DArr[3, 5].DragEnter += picbox2DArr35_DragEnter;
            picbox2DArr[3, 5].DragDrop += picbox2DArr35_DragDrop;

            picbox2DArr[3, 6].MouseDown += picbox2DArr36_MouseDown;
            picbox2DArr[3, 6].DragEnter += picbox2DArr36_DragEnter;
            picbox2DArr[3, 6].DragDrop += picbox2DArr36_DragDrop;

            picbox2DArr[4, 0].MouseDown += picbox2DArr40_MouseDown;
            picbox2DArr[4, 0].DragEnter += picbox2DArr40_DragEnter;
            picbox2DArr[4, 0].DragDrop += picbox2DArr40_DragDrop;

            picbox2DArr[4, 1].MouseDown += picbox2DArr41_MouseDown;
            picbox2DArr[4, 1].DragEnter += picbox2DArr41_DragEnter;
            picbox2DArr[4, 1].DragDrop += picbox2DArr41_DragDrop;

            picbox2DArr[4, 2].MouseDown += picbox2DArr42_MouseDown;
            picbox2DArr[4, 2].DragEnter += picbox2DArr42_DragEnter;
            picbox2DArr[4, 2].DragDrop += picbox2DArr42_DragDrop;

            picbox2DArr[4, 3].MouseDown += picbox2DArr43_MouseDown;
            picbox2DArr[4, 3].DragEnter += picbox2DArr43_DragEnter;
            picbox2DArr[4, 3].DragDrop += picbox2DArr43_DragDrop;

            picbox2DArr[4, 4].MouseDown += picbox2DArr44_MouseDown;
            picbox2DArr[4, 4].DragEnter += picbox2DArr44_DragEnter;
            picbox2DArr[4, 4].DragDrop += picbox2DArr44_DragDrop;

            picbox2DArr[4, 5].MouseDown += picbox2DArr45_MouseDown;
            picbox2DArr[4, 5].DragEnter += picbox2DArr45_DragEnter;
            picbox2DArr[4, 5].DragDrop += picbox2DArr45_DragDrop;

            picbox2DArr[4, 6].MouseDown += picbox2DArr46_MouseDown;
            picbox2DArr[4, 6].DragEnter += picbox2DArr46_DragEnter;
            picbox2DArr[4, 6].DragDrop += picbox2DArr46_DragDrop;

            picbox2DArr[5, 0].MouseDown += picbox2DArr50_MouseDown;
            picbox2DArr[5, 0].DragEnter += picbox2DArr50_DragEnter;
            picbox2DArr[5, 0].DragDrop += picbox2DArr50_DragDrop;

            picbox2DArr[5, 1].MouseDown += picbox2DArr51_MouseDown;
            picbox2DArr[5, 1].DragEnter += picbox2DArr51_DragEnter;
            picbox2DArr[5, 1].DragDrop += picbox2DArr51_DragDrop;

            picbox2DArr[5, 2].MouseDown += picbox2DArr52_MouseDown;
            picbox2DArr[5, 2].DragEnter += picbox2DArr52_DragEnter;
            picbox2DArr[5, 2].DragDrop += picbox2DArr52_DragDrop;

            picbox2DArr[5, 3].MouseDown += picbox2DArr53_MouseDown;
            picbox2DArr[5, 3].DragEnter += picbox2DArr53_DragEnter;
            picbox2DArr[5, 3].DragDrop += picbox2DArr53_DragDrop;

            picbox2DArr[5, 4].MouseDown += picbox2DArr54_MouseDown;
            picbox2DArr[5, 4].DragEnter += picbox2DArr54_DragEnter;
            picbox2DArr[5, 4].DragDrop += picbox2DArr54_DragDrop;

            picbox2DArr[5, 5].MouseDown += picbox2DArr55_MouseDown;
            picbox2DArr[5, 5].DragEnter += picbox2DArr55_DragEnter;
            picbox2DArr[5, 5].DragDrop += picbox2DArr55_DragDrop;

            picbox2DArr[5, 6].MouseDown += picbox2DArr56_MouseDown;
            picbox2DArr[5, 6].DragEnter += picbox2DArr56_DragEnter;
            picbox2DArr[5, 6].DragDrop += picbox2DArr56_DragDrop;

            picbox2DArr[6, 0].MouseDown += picbox2DArr60_MouseDown;
            picbox2DArr[6, 0].DragEnter += picbox2DArr60_DragEnter;
            picbox2DArr[6, 0].DragDrop += picbox2DArr60_DragDrop;

            picbox2DArr[6, 1].MouseDown += picbox2DArr61_MouseDown;
            picbox2DArr[6, 1].DragEnter += picbox2DArr61_DragEnter;
            picbox2DArr[6, 1].DragDrop += picbox2DArr61_DragDrop;

            picbox2DArr[6, 2].MouseDown += picbox2DArr62_MouseDown;
            picbox2DArr[6, 2].DragEnter += picbox2DArr62_DragEnter;
            picbox2DArr[6, 2].DragDrop += picbox2DArr62_DragDrop;

            picbox2DArr[6, 3].MouseDown += picbox2DArr63_MouseDown;
            picbox2DArr[6, 3].DragEnter += picbox2DArr63_DragEnter;
            picbox2DArr[6, 3].DragDrop += picbox2DArr63_DragDrop;

            picbox2DArr[6, 4].MouseDown += picbox2DArr64_MouseDown;
            picbox2DArr[6, 4].DragEnter += picbox2DArr64_DragEnter;
            picbox2DArr[6, 4].DragDrop += picbox2DArr64_DragDrop;

            picbox2DArr[6, 5].MouseDown += picbox2DArr65_MouseDown;
            picbox2DArr[6, 5].DragEnter += picbox2DArr65_DragEnter;
            picbox2DArr[6, 5].DragDrop += picbox2DArr65_DragDrop;

            picbox2DArr[6, 6].MouseDown += picbox2DArr66_MouseDown;
            picbox2DArr[6, 6].DragEnter += picbox2DArr66_DragEnter;
            picbox2DArr[6, 6].DragDrop += picbox2DArr66_DragDrop;

            picbox2DArr[7, 0].MouseDown += picbox2DArr70_MouseDown;
            picbox2DArr[7, 0].DragEnter += picbox2DArr70_DragEnter;
            picbox2DArr[7, 0].DragDrop += picbox2DArr70_DragDrop;

            picbox2DArr[7, 1].MouseDown += picbox2DArr71_MouseDown;
            picbox2DArr[7, 1].DragEnter += picbox2DArr71_DragEnter;
            picbox2DArr[7, 1].DragDrop += picbox2DArr71_DragDrop;

            picbox2DArr[7, 2].MouseDown += picbox2DArr72_MouseDown;
            picbox2DArr[7, 2].DragEnter += picbox2DArr72_DragEnter;
            picbox2DArr[7, 2].DragDrop += picbox2DArr72_DragDrop;

            picbox2DArr[7, 3].MouseDown += picbox2DArr73_MouseDown;
            picbox2DArr[7, 3].DragEnter += picbox2DArr73_DragEnter;
            picbox2DArr[7, 3].DragDrop += picbox2DArr73_DragDrop;

            picbox2DArr[7, 4].MouseDown += picbox2DArr74_MouseDown;
            picbox2DArr[7, 4].DragEnter += picbox2DArr74_DragEnter;
            picbox2DArr[7, 4].DragDrop += picbox2DArr74_DragDrop;

            picbox2DArr[7, 5].MouseDown += picbox2DArr75_MouseDown;
            picbox2DArr[7, 5].DragEnter += picbox2DArr75_DragEnter;
            picbox2DArr[7, 5].DragDrop += picbox2DArr75_DragDrop;

            picbox2DArr[7, 6].MouseDown += picbox2DArr76_MouseDown;
            picbox2DArr[7, 6].DragEnter += picbox2DArr76_DragEnter;
            picbox2DArr[7, 6].DragDrop += picbox2DArr76_DragDrop;

            picbox2DArr[8, 0].MouseDown += picbox2DArr80_MouseDown;
            picbox2DArr[8, 0].DragEnter += picbox2DArr80_DragEnter;
            picbox2DArr[8, 0].DragDrop += picbox2DArr80_DragDrop;

            picbox2DArr[8, 1].MouseDown += picbox2DArr81_MouseDown;
            picbox2DArr[8, 1].DragEnter += picbox2DArr81_DragEnter;
            picbox2DArr[8, 1].DragDrop += picbox2DArr81_DragDrop;

            picbox2DArr[8, 2].MouseDown += picbox2DArr82_MouseDown;
            picbox2DArr[8, 2].DragEnter += picbox2DArr82_DragEnter;
            picbox2DArr[8, 2].DragDrop += picbox2DArr82_DragDrop;

            picbox2DArr[8, 3].MouseDown += picbox2DArr83_MouseDown;
            picbox2DArr[8, 3].DragEnter += picbox2DArr83_DragEnter;
            picbox2DArr[8, 3].DragDrop += picbox2DArr83_DragDrop;

            picbox2DArr[8, 4].MouseDown += picbox2DArr84_MouseDown;
            picbox2DArr[8, 4].DragEnter += picbox2DArr84_DragEnter;
            picbox2DArr[8, 4].DragDrop += picbox2DArr84_DragDrop;

            picbox2DArr[8, 5].MouseDown += picbox2DArr85_MouseDown;
            picbox2DArr[8, 5].DragEnter += picbox2DArr85_DragEnter;
            picbox2DArr[8, 5].DragDrop += picbox2DArr85_DragDrop;

            picbox2DArr[8, 6].MouseDown += picbox2DArr86_MouseDown;
            picbox2DArr[8, 6].DragEnter += picbox2DArr86_DragEnter;
            picbox2DArr[8, 6].DragDrop += picbox2DArr86_DragDrop;

            picbox2DArr[9, 0].MouseDown += picbox2DArr90_MouseDown;
            picbox2DArr[9, 0].DragEnter += picbox2DArr90_DragEnter;
            picbox2DArr[9, 0].DragDrop += picbox2DArr90_DragDrop;

            picbox2DArr[9, 1].MouseDown += picbox2DArr91_MouseDown;
            picbox2DArr[9, 1].DragEnter += picbox2DArr91_DragEnter;
            picbox2DArr[9, 1].DragDrop += picbox2DArr91_DragDrop;

            picbox2DArr[9, 2].MouseDown += picbox2DArr92_MouseDown;
            picbox2DArr[9, 2].DragEnter += picbox2DArr92_DragEnter;
            picbox2DArr[9, 2].DragDrop += picbox2DArr92_DragDrop;

            picbox2DArr[9, 3].MouseDown += picbox2DArr93_MouseDown;
            picbox2DArr[9, 3].DragEnter += picbox2DArr93_DragEnter;
            picbox2DArr[9, 3].DragDrop += picbox2DArr93_DragDrop;

            picbox2DArr[9, 4].MouseDown += picbox2DArr94_MouseDown;
            picbox2DArr[9, 4].DragEnter += picbox2DArr94_DragEnter;
            picbox2DArr[9, 4].DragDrop += picbox2DArr94_DragDrop;

            picbox2DArr[9, 5].MouseDown += picbox2DArr95_MouseDown;
            picbox2DArr[9, 5].DragEnter += picbox2DArr95_DragEnter;
            picbox2DArr[9, 5].DragDrop += picbox2DArr95_DragDrop;

            picbox2DArr[9, 6].MouseDown += picbox2DArr96_MouseDown;
            picbox2DArr[9, 6].DragEnter += picbox2DArr96_DragEnter;
            picbox2DArr[9, 6].DragDrop += picbox2DArr96_DragDrop;

            picbox2DArr[10, 0].MouseDown += picbox2DArr100_MouseDown;
            picbox2DArr[10, 0].DragEnter += picbox2DArr100_DragEnter;
            picbox2DArr[10, 0].DragDrop += picbox2DArr100_DragDrop;

            picbox2DArr[10, 1].MouseDown += picbox2DArr101_MouseDown;
            picbox2DArr[10, 1].DragEnter += picbox2DArr101_DragEnter;
            picbox2DArr[10, 1].DragDrop += picbox2DArr101_DragDrop;

            picbox2DArr[10, 2].MouseDown += picbox2DArr102_MouseDown;
            picbox2DArr[10, 2].DragEnter += picbox2DArr102_DragEnter;
            picbox2DArr[10, 2].DragDrop += picbox2DArr102_DragDrop;

            picbox2DArr[10, 3].MouseDown += picbox2DArr103_MouseDown;
            picbox2DArr[10, 3].DragEnter += picbox2DArr103_DragEnter;
            picbox2DArr[10, 3].DragDrop += picbox2DArr103_DragDrop;

            picbox2DArr[10, 4].MouseDown += picbox2DArr104_MouseDown;
            picbox2DArr[10, 4].DragEnter += picbox2DArr104_DragEnter;
            picbox2DArr[10, 4].DragDrop += picbox2DArr104_DragDrop;

            picbox2DArr[10, 5].MouseDown += picbox2DArr105_MouseDown;
            picbox2DArr[10, 5].DragEnter += picbox2DArr105_DragEnter;
            picbox2DArr[10, 5].DragDrop += picbox2DArr105_DragDrop;

            picbox2DArr[10, 6].MouseDown += picbox2DArr106_MouseDown;
            picbox2DArr[10, 6].DragEnter += picbox2DArr106_DragEnter;
            picbox2DArr[10, 6].DragDrop += picbox2DArr106_DragDrop;

            picbox2DArr[11, 0].MouseDown += picbox2DArr110_MouseDown;
            picbox2DArr[11, 0].DragEnter += picbox2DArr110_DragEnter;
            picbox2DArr[11, 0].DragDrop += picbox2DArr110_DragDrop;

            picbox2DArr[11, 1].MouseDown += picbox2DArr111_MouseDown;
            picbox2DArr[11, 1].DragEnter += picbox2DArr111_DragEnter;
            picbox2DArr[11, 1].DragDrop += picbox2DArr111_DragDrop;

            picbox2DArr[11, 2].MouseDown += picbox2DArr112_MouseDown;
            picbox2DArr[11, 2].DragEnter += picbox2DArr112_DragEnter;
            picbox2DArr[11, 2].DragDrop += picbox2DArr112_DragDrop;

            picbox2DArr[11, 3].MouseDown += picbox2DArr113_MouseDown;
            picbox2DArr[11, 3].DragEnter += picbox2DArr113_DragEnter;
            picbox2DArr[11, 3].DragDrop += picbox2DArr113_DragDrop;

            picbox2DArr[11, 4].MouseDown += picbox2DArr114_MouseDown;
            picbox2DArr[11, 4].DragEnter += picbox2DArr114_DragEnter;
            picbox2DArr[11, 4].DragDrop += picbox2DArr114_DragDrop;

            picbox2DArr[11, 5].MouseDown += picbox2DArr115_MouseDown;
            picbox2DArr[11, 5].DragEnter += picbox2DArr115_DragEnter;
            picbox2DArr[11, 5].DragDrop += picbox2DArr115_DragDrop;

            picbox2DArr[11, 6].MouseDown += picbox2DArr116_MouseDown;
            picbox2DArr[11, 6].DragEnter += picbox2DArr116_DragEnter;
            picbox2DArr[11, 6].DragDrop += picbox2DArr116_DragDrop;

            picbox2DArr[12, 0].MouseDown += picbox2DArr120_MouseDown;
            picbox2DArr[12, 0].DragEnter += picbox2DArr120_DragEnter;
            picbox2DArr[12, 0].DragDrop += picbox2DArr120_DragDrop;

            picbox2DArr[12, 1].MouseDown += picbox2DArr121_MouseDown;
            picbox2DArr[12, 1].DragEnter += picbox2DArr121_DragEnter;
            picbox2DArr[12, 1].DragDrop += picbox2DArr121_DragDrop;

            picbox2DArr[12, 2].MouseDown += picbox2DArr122_MouseDown;
            picbox2DArr[12, 2].DragEnter += picbox2DArr122_DragEnter;
            picbox2DArr[12, 2].DragDrop += picbox2DArr122_DragDrop;

            picbox2DArr[12, 3].MouseDown += picbox2DArr123_MouseDown;
            picbox2DArr[12, 3].DragEnter += picbox2DArr123_DragEnter;
            picbox2DArr[12, 3].DragDrop += picbox2DArr123_DragDrop;

            picbox2DArr[12, 4].MouseDown += picbox2DArr124_MouseDown;
            picbox2DArr[12, 4].DragEnter += picbox2DArr124_DragEnter;
            picbox2DArr[12, 4].DragDrop += picbox2DArr124_DragDrop;

            picbox2DArr[12, 5].MouseDown += picbox2DArr125_MouseDown;
            picbox2DArr[12, 5].DragEnter += picbox2DArr125_DragEnter;
            picbox2DArr[12, 5].DragDrop += picbox2DArr125_DragDrop;

            picbox2DArr[12, 6].MouseDown += picbox2DArr126_MouseDown;
            picbox2DArr[12, 6].DragEnter += picbox2DArr126_DragEnter;
            picbox2DArr[12, 6].DragDrop += picbox2DArr126_DragDrop;

            picbox2DArr[13, 0].MouseDown += picbox2DArr130_MouseDown;
            picbox2DArr[13, 0].DragEnter += picbox2DArr130_DragEnter;
            picbox2DArr[13, 0].DragDrop += picbox2DArr130_DragDrop;

            picbox2DArr[13, 1].MouseDown += picbox2DArr131_MouseDown;
            picbox2DArr[13, 1].DragEnter += picbox2DArr131_DragEnter;
            picbox2DArr[13, 1].DragDrop += picbox2DArr131_DragDrop;

            picbox2DArr[13, 2].MouseDown += picbox2DArr132_MouseDown;
            picbox2DArr[13, 2].DragEnter += picbox2DArr132_DragEnter;
            picbox2DArr[13, 2].DragDrop += picbox2DArr132_DragDrop;

            picbox2DArr[13, 3].MouseDown += picbox2DArr133_MouseDown;
            picbox2DArr[13, 3].DragEnter += picbox2DArr133_DragEnter;
            picbox2DArr[13, 3].DragDrop += picbox2DArr133_DragDrop;

            picbox2DArr[13, 4].MouseDown += picbox2DArr134_MouseDown;
            picbox2DArr[13, 4].DragEnter += picbox2DArr134_DragEnter;
            picbox2DArr[13, 4].DragDrop += picbox2DArr134_DragDrop;

            picbox2DArr[13, 5].MouseDown += picbox2DArr135_MouseDown;
            picbox2DArr[13, 5].DragEnter += picbox2DArr135_DragEnter;
            picbox2DArr[13, 5].DragDrop += picbox2DArr135_DragDrop;

            picbox2DArr[13, 6].MouseDown += picbox2DArr136_MouseDown;
            picbox2DArr[13, 6].DragEnter += picbox2DArr136_DragEnter;
            picbox2DArr[13, 6].DragDrop += picbox2DArr136_DragDrop;

            picbox2DArr[14, 0].MouseDown += picbox2DArr140_MouseDown;
            picbox2DArr[14, 0].DragEnter += picbox2DArr140_DragEnter;
            picbox2DArr[14, 0].DragDrop += picbox2DArr140_DragDrop;

            picbox2DArr[14, 1].MouseDown += picbox2DArr141_MouseDown;
            picbox2DArr[14, 1].DragEnter += picbox2DArr141_DragEnter;
            picbox2DArr[14, 1].DragDrop += picbox2DArr141_DragDrop;

            picbox2DArr[14, 2].MouseDown += picbox2DArr142_MouseDown;
            picbox2DArr[14, 2].DragEnter += picbox2DArr142_DragEnter;
            picbox2DArr[14, 2].DragDrop += picbox2DArr142_DragDrop;

            picbox2DArr[14, 3].MouseDown += picbox2DArr143_MouseDown;
            picbox2DArr[14, 3].DragEnter += picbox2DArr143_DragEnter;
            picbox2DArr[14, 3].DragDrop += picbox2DArr143_DragDrop;

            picbox2DArr[14, 4].MouseDown += picbox2DArr144_MouseDown;
            picbox2DArr[14, 4].DragEnter += picbox2DArr144_DragEnter;
            picbox2DArr[14, 4].DragDrop += picbox2DArr144_DragDrop;

            picbox2DArr[14, 5].MouseDown += picbox2DArr145_MouseDown;
            picbox2DArr[14, 5].DragEnter += picbox2DArr145_DragEnter;
            picbox2DArr[14, 5].DragDrop += picbox2DArr145_DragDrop;

            picbox2DArr[14, 6].MouseDown += picbox2DArr146_MouseDown;
            picbox2DArr[14, 6].DragEnter += picbox2DArr146_DragEnter;
            picbox2DArr[14, 6].DragDrop += picbox2DArr146_DragDrop;

            picbox2DArr[15, 0].MouseDown += picbox2DArr150_MouseDown;
            picbox2DArr[15, 0].DragEnter += picbox2DArr150_DragEnter;
            picbox2DArr[15, 0].DragDrop += picbox2DArr150_DragDrop;

            picbox2DArr[15, 1].MouseDown += picbox2DArr151_MouseDown;
            picbox2DArr[15, 1].DragEnter += picbox2DArr151_DragEnter;
            picbox2DArr[15, 1].DragDrop += picbox2DArr151_DragDrop;

            picbox2DArr[15, 2].MouseDown += picbox2DArr152_MouseDown;
            picbox2DArr[15, 2].DragEnter += picbox2DArr152_DragEnter;
            picbox2DArr[15, 2].DragDrop += picbox2DArr152_DragDrop;

            picbox2DArr[15, 3].MouseDown += picbox2DArr153_MouseDown;
            picbox2DArr[15, 3].DragEnter += picbox2DArr153_DragEnter;
            picbox2DArr[15, 3].DragDrop += picbox2DArr153_DragDrop;

            picbox2DArr[15, 4].MouseDown += picbox2DArr154_MouseDown;
            picbox2DArr[15, 4].DragEnter += picbox2DArr154_DragEnter;
            picbox2DArr[15, 4].DragDrop += picbox2DArr154_DragDrop;

            picbox2DArr[15, 5].MouseDown += picbox2DArr155_MouseDown;
            picbox2DArr[15, 5].DragEnter += picbox2DArr155_DragEnter;
            picbox2DArr[15, 5].DragDrop += picbox2DArr155_DragDrop;

            picbox2DArr[15, 6].MouseDown += picbox2DArr156_MouseDown;
            picbox2DArr[15, 6].DragEnter += picbox2DArr156_DragEnter;
            picbox2DArr[15, 6].DragDrop += picbox2DArr156_DragDrop;

            picbox2DArr[16, 0].MouseDown += picbox2DArr160_MouseDown;
            picbox2DArr[16, 0].DragEnter += picbox2DArr160_DragEnter;
            picbox2DArr[16, 0].DragDrop += picbox2DArr160_DragDrop;

            picbox2DArr[16, 1].MouseDown += picbox2DArr161_MouseDown;
            picbox2DArr[16, 1].DragEnter += picbox2DArr161_DragEnter;
            picbox2DArr[16, 1].DragDrop += picbox2DArr161_DragDrop;

            picbox2DArr[16, 2].MouseDown += picbox2DArr162_MouseDown;
            picbox2DArr[16, 2].DragEnter += picbox2DArr162_DragEnter;
            picbox2DArr[16, 2].DragDrop += picbox2DArr162_DragDrop;

            picbox2DArr[16, 3].MouseDown += picbox2DArr163_MouseDown;
            picbox2DArr[16, 3].DragEnter += picbox2DArr163_DragEnter;
            picbox2DArr[16, 3].DragDrop += picbox2DArr163_DragDrop;

            picbox2DArr[16, 4].MouseDown += picbox2DArr164_MouseDown;
            picbox2DArr[16, 4].DragEnter += picbox2DArr164_DragEnter;
            picbox2DArr[16, 4].DragDrop += picbox2DArr164_DragDrop;

            picbox2DArr[16, 5].MouseDown += picbox2DArr165_MouseDown;
            picbox2DArr[16, 5].DragEnter += picbox2DArr165_DragEnter;
            picbox2DArr[16, 5].DragDrop += picbox2DArr165_DragDrop;

            picbox2DArr[16, 6].MouseDown += picbox2DArr166_MouseDown;
            picbox2DArr[16, 6].DragEnter += picbox2DArr166_DragEnter;
            picbox2DArr[16, 6].DragDrop += picbox2DArr166_DragDrop;

            picbox2DArr[17, 0].MouseDown += picbox2DArr170_MouseDown;
            picbox2DArr[17, 0].DragEnter += picbox2DArr170_DragEnter;
            picbox2DArr[17, 0].DragDrop += picbox2DArr170_DragDrop;

            picbox2DArr[17, 1].MouseDown += picbox2DArr171_MouseDown;
            picbox2DArr[17, 1].DragEnter += picbox2DArr171_DragEnter;
            picbox2DArr[17, 1].DragDrop += picbox2DArr171_DragDrop;

            picbox2DArr[17, 2].MouseDown += picbox2DArr172_MouseDown;
            picbox2DArr[17, 2].DragEnter += picbox2DArr172_DragEnter;
            picbox2DArr[17, 2].DragDrop += picbox2DArr172_DragDrop;

            picbox2DArr[17, 3].MouseDown += picbox2DArr173_MouseDown;
            picbox2DArr[17, 3].DragEnter += picbox2DArr173_DragEnter;
            picbox2DArr[17, 3].DragDrop += picbox2DArr173_DragDrop;

            picbox2DArr[17, 4].MouseDown += picbox2DArr174_MouseDown;
            picbox2DArr[17, 4].DragEnter += picbox2DArr174_DragEnter;
            picbox2DArr[17, 4].DragDrop += picbox2DArr174_DragDrop;

            picbox2DArr[17, 5].MouseDown += picbox2DArr175_MouseDown;
            picbox2DArr[17, 5].DragEnter += picbox2DArr175_DragEnter;
            picbox2DArr[17, 5].DragDrop += picbox2DArr175_DragDrop;

            picbox2DArr[17, 6].MouseDown += picbox2DArr176_MouseDown;
            picbox2DArr[17, 6].DragEnter += picbox2DArr176_DragEnter;
            picbox2DArr[17, 6].DragDrop += picbox2DArr176_DragDrop;

            picbox2DArr[18, 0].MouseDown += picbox2DArr180_MouseDown;
            picbox2DArr[18, 0].DragEnter += picbox2DArr180_DragEnter;
            picbox2DArr[18, 0].DragDrop += picbox2DArr180_DragDrop;

            picbox2DArr[18, 1].MouseDown += picbox2DArr181_MouseDown;
            picbox2DArr[18, 1].DragEnter += picbox2DArr181_DragEnter;
            picbox2DArr[18, 1].DragDrop += picbox2DArr181_DragDrop;

            picbox2DArr[18, 2].MouseDown += picbox2DArr182_MouseDown;
            picbox2DArr[18, 2].DragEnter += picbox2DArr182_DragEnter;
            picbox2DArr[18, 2].DragDrop += picbox2DArr182_DragDrop;

            picbox2DArr[18, 3].MouseDown += picbox2DArr183_MouseDown;
            picbox2DArr[18, 3].DragEnter += picbox2DArr183_DragEnter;
            picbox2DArr[18, 3].DragDrop += picbox2DArr183_DragDrop;

            picbox2DArr[18, 4].MouseDown += picbox2DArr184_MouseDown;
            picbox2DArr[18, 4].DragEnter += picbox2DArr184_DragEnter;
            picbox2DArr[18, 4].DragDrop += picbox2DArr184_DragDrop;

            picbox2DArr[18, 5].MouseDown += picbox2DArr185_MouseDown;
            picbox2DArr[18, 5].DragEnter += picbox2DArr185_DragEnter;
            picbox2DArr[18, 5].DragDrop += picbox2DArr185_DragDrop;

            picbox2DArr[18, 6].MouseDown += picbox2DArr186_MouseDown;
            picbox2DArr[18, 6].DragEnter += picbox2DArr186_DragEnter;
            picbox2DArr[18, 6].DragDrop += picbox2DArr186_DragDrop;

            picbox2DArr[19, 0].MouseDown += picbox2DArr190_MouseDown;
            picbox2DArr[19, 0].DragEnter += picbox2DArr190_DragEnter;
            picbox2DArr[19, 0].DragDrop += picbox2DArr190_DragDrop;

            picbox2DArr[19, 1].MouseDown += picbox2DArr191_MouseDown;
            picbox2DArr[19, 1].DragEnter += picbox2DArr191_DragEnter;
            picbox2DArr[19, 1].DragDrop += picbox2DArr191_DragDrop;

            picbox2DArr[19, 2].MouseDown += picbox2DArr192_MouseDown;
            picbox2DArr[19, 2].DragEnter += picbox2DArr192_DragEnter;
            picbox2DArr[19, 2].DragDrop += picbox2DArr192_DragDrop;

            picbox2DArr[19, 3].MouseDown += picbox2DArr193_MouseDown;
            picbox2DArr[19, 3].DragEnter += picbox2DArr193_DragEnter;
            picbox2DArr[19, 3].DragDrop += picbox2DArr193_DragDrop;

            picbox2DArr[19, 4].MouseDown += picbox2DArr194_MouseDown;
            picbox2DArr[19, 4].DragEnter += picbox2DArr194_DragEnter;
            picbox2DArr[19, 4].DragDrop += picbox2DArr194_DragDrop;

            picbox2DArr[19, 5].MouseDown += picbox2DArr195_MouseDown;
            picbox2DArr[19, 5].DragEnter += picbox2DArr195_DragEnter;
            picbox2DArr[19, 5].DragDrop += picbox2DArr195_DragDrop;

            picbox2DArr[19, 6].MouseDown += picbox2DArr196_MouseDown;
            picbox2DArr[19, 6].DragEnter += picbox2DArr196_DragEnter;
            picbox2DArr[19, 6].DragDrop += picbox2DArr196_DragDrop;

            picbox2DArr[20, 0].MouseDown += picbox2DArr200_MouseDown;
            picbox2DArr[20, 0].DragEnter += picbox2DArr200_DragEnter;
            picbox2DArr[20, 0].DragDrop += picbox2DArr200_DragDrop;

            picbox2DArr[20, 1].MouseDown += picbox2DArr201_MouseDown;
            picbox2DArr[20, 1].DragEnter += picbox2DArr201_DragEnter;
            picbox2DArr[20, 1].DragDrop += picbox2DArr201_DragDrop;

            picbox2DArr[20, 2].MouseDown += picbox2DArr202_MouseDown;
            picbox2DArr[20, 2].DragEnter += picbox2DArr202_DragEnter;
            picbox2DArr[20, 2].DragDrop += picbox2DArr202_DragDrop;

            picbox2DArr[20, 3].MouseDown += picbox2DArr203_MouseDown;
            picbox2DArr[20, 3].DragEnter += picbox2DArr203_DragEnter;
            picbox2DArr[20, 3].DragDrop += picbox2DArr203_DragDrop;

            //picbox2DArr[20, 4].MouseDown += picbox2DArr204_MouseDown;
            //picbox2DArr[20, 4].DragEnter += picbox2DArr204_DragEnter;
            //picbox2DArr[20, 4].DragDrop += picbox2DArr204_DragDrop;

            //picbox2DArr[20, 5].MouseDown += picbox2DArr205_MouseDown;
            //picbox2DArr[20, 5].DragEnter += picbox2DArr205_DragEnter;
            //picbox2DArr[20, 5].DragDrop += picbox2DArr205_DragDrop;

            //picbox2DArr[20, 6].MouseDown += picbox2DArr206_MouseDown;
            //picbox2DArr[20, 6].DragEnter += picbox2DArr206_DragEnter;
            //picbox2DArr[20, 6].DragDrop += picbox2DArr206_DragDrop;

            picbox2DArr[21, 0].MouseDown += picbox2DArr210_MouseDown;
            picbox2DArr[21, 0].DragEnter += picbox2DArr210_DragEnter;
            picbox2DArr[21, 0].DragDrop += picbox2DArr210_DragDrop;

            picbox2DArr[21, 1].MouseDown += picbox2DArr211_MouseDown;
            picbox2DArr[21, 1].DragEnter += picbox2DArr211_DragEnter;
            picbox2DArr[21, 1].DragDrop += picbox2DArr211_DragDrop;

            picbox2DArr[21, 2].MouseDown += picbox2DArr212_MouseDown;
            picbox2DArr[21, 2].DragEnter += picbox2DArr212_DragEnter;
            picbox2DArr[21, 2].DragDrop += picbox2DArr212_DragDrop;

            picbox2DArr[21, 3].MouseDown += picbox2DArr213_MouseDown;
            picbox2DArr[21, 3].DragEnter += picbox2DArr213_DragEnter;
            picbox2DArr[21, 3].DragDrop += picbox2DArr213_DragDrop;

            picbox2DArr[21, 4].MouseDown += picbox2DArr214_MouseDown;
            picbox2DArr[21, 4].DragEnter += picbox2DArr214_DragEnter;
            picbox2DArr[21, 4].DragDrop += picbox2DArr214_DragDrop;

            picbox2DArr[21, 5].MouseDown += picbox2DArr215_MouseDown;
            picbox2DArr[21, 5].DragEnter += picbox2DArr215_DragEnter;
            picbox2DArr[21, 5].DragDrop += picbox2DArr215_DragDrop;

            //picbox2DArr[21, 6].MouseDown += picbox2DArr216_MouseDown;
            //picbox2DArr[21, 6].DragEnter += picbox2DArr216_DragEnter;
            //picbox2DArr[21, 6].DragDrop += picbox2DArr216_DragDrop;




        }



        private void pictureBoxRemain_Click(object sender, EventArgs e)
        {
            NeedMoreCards();
        }

        //bug here!
        private void NeedMoreCards()
        {
            if(picboxBitmapList[21, 5].Count != 0)
            {
                
                /**
                * Let picboxBitmapList[21, 6] be main flip 
                */
                //Transfer the image to main flip [21, 6]
                picboxBitmapList[21, 6].Add(picboxBitmapList[21, 5][
                                                                     (picboxBitmapList[21, 5].Count - 1)
                                                                        ]);
                picboxBitmapList[21, 5].RemoveAt((picboxBitmapList[21, 5].Count - 1));
                if (picboxBitmapList[21, 5].Count == 0)
                {
                    picbox2DArr[21, 5].BackgroundImage = null;
                }
                //show topmost image of [21, 6] onto [21, showHintCardsOnWhichE1E5]
                if (picboxBitmapList[21, 6].Count <= 5)
                {
                    int indexDisplace = picboxBitmapList[21, 6].Count;
                    for (int i = 0; i <= picboxBitmapList[21, 6].Count - 1; i++)
                    {
                        picbox2DArr[21, i].Image = picboxBitmapList[21, 6][
                                                                                (picboxBitmapList[21, 6].Count - indexDisplace)
                                                                                ];
                        picboxBitmapList[21, i].Clear();
                        picboxBitmapList[21, i].Add(picboxBitmapList[21, 6][
                                                                                (picboxBitmapList[21, 6].Count - indexDisplace)
                                                                                ]);
                        picbox2DArr[21, i].Visible = true;
                        picbox2DArr[21, i].BringToFront();
                        indexDisplace--;
                    }
                }
                else if (picboxBitmapList[21, 6].Count > 5)
                {
                    int indexDisplace = 5;
                    for (int i = 0; i <= 4; i++)
                    {
                        picbox2DArr[21, i].Image = picboxBitmapList[21, 6][
                                                                                (picboxBitmapList[21, 6].Count - indexDisplace)
                                                                                ];
                        picbox2DArr[21, i].Visible = true;
                        picbox2DArr[21, i].BringToFront();
                        indexDisplace--;
                    }
                }

            }//if(picboxBitmapList[21, 5].Count != 0)
            
            else if ( picbox2DArr[21, 5].BackgroundImage == null)
            {
                
                //transfer all cards from main flip to main
                for (int i = 0; i <= picboxBitmapList[21, 6].Count - 1 ; i++)
                {
                    picboxBitmapList[21, 5].Add(picboxBitmapList[21, 6][i]);
                }
                picbox2DArr[21, 5].BackgroundImage = (Bitmap)(Properties.Resources.ResourceManager.GetObject("Back") as Image);
                picboxBitmapList[21, 6].Clear();
                for (int i = 0; i <= 4 ; i++)
                {
                    picbox2DArr[21, i].Visible = false;
                    picboxBitmapList[21, i].Clear();

                }
            }
            
        }








       /**
        * Drag drop
        * All picbox.
        */
        //original


        private void picbox2DArr00_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[0, 0].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[0, 0].RemoveAt(picboxBitmapList[0, 0].Count - 1);
                if (picboxBitmapList[0, 0].Count != 0)
                    picbox2DArr[0, 0].Image = picboxBitmapList[0, 0][(picboxBitmapList[0, 0].Count - 1)];
                else
                {
                    picbox2DArr[0, 0].Image = null;
                    picbox2DArr[0, 0].BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
            }
        }
        void picbox2DArr00_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                if (picbox2DArr[0, 0].Image != null)
                {
                    picbox2DArr[1, 0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    picbox2DArr[1, 0].BringToFront();
                    e.Effect = DragDropEffects.Move;
                }
                else if (picbox2DArr[0, 0].Image == null)
                {
                    picbox2DArr[0, 0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    picbox2DArr[0, 0].BringToFront();
                    e.Effect = DragDropEffects.Move;
                }

            }
        }

        void picbox2DArr00_DragLeave(object sender, DragEventArgs e)
        {
            picbox2DArr[0, 0].BorderStyle = System.Windows.Forms.BorderStyle.None;
            picbox2DArr[-1, 0].BringToFront();

        }
        void picbox2DArr00_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[0, 0].Add(bmp);
            picbox2DArr[0, 0].Image = picboxBitmapList[0, 0][(picboxBitmapList[0, 0].Count - 1)];

        }








        private void picbox2DArr01_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[0, 1].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[0, 1].RemoveAt(picboxBitmapList[0, 1].Count - 1);
                if (picboxBitmapList[0, 1].Count != 0)
                    picbox2DArr[0, 1].Image = picboxBitmapList[0, 1][(picboxBitmapList[0, 1].Count - 1)];
                else
                {
                    picbox2DArr[0, 1].Image = null;
                    picbox2DArr[0, 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
            }
        }
        void picbox2DArr01_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[0, 1].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[0, 1].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr01_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[0, 1].Add(bmp);
            picbox2DArr[0, 1].Image = picboxBitmapList[0, 1][(picboxBitmapList[0, 1].Count - 1)];
            picbox2DArr[0, 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr02_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[0, 2].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[0, 2].RemoveAt(picboxBitmapList[0, 2].Count - 1);
                if (picboxBitmapList[0, 2].Count != 0)
                    picbox2DArr[0, 2].Image = picboxBitmapList[0, 2][(picboxBitmapList[0, 2].Count - 1)];
                else
                {
                    picbox2DArr[0, 2].Image = null;
                    picbox2DArr[0, 2].BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
            }
        }
        void picbox2DArr02_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[0, 2].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[0, 2].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr02_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[0, 2].Add(bmp);
            picbox2DArr[0, 2].Image = picboxBitmapList[0, 2][(picboxBitmapList[0, 2].Count - 1)];
            picbox2DArr[0, 2].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr03_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[0, 3].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[0, 3].RemoveAt(picboxBitmapList[0, 3].Count - 1);
                if (picboxBitmapList[0, 3].Count != 0)
                    picbox2DArr[0, 3].Image = picboxBitmapList[0, 3][(picboxBitmapList[0, 3].Count - 1)];
                else
                {
                    picbox2DArr[0, 3].Image = null;
                    picbox2DArr[0, 3].BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
            }
        }
        void picbox2DArr03_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[0, 3].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[0, 3].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr03_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[0, 3].Add(bmp);
            picbox2DArr[0, 3].Image = picboxBitmapList[0, 3][(picboxBitmapList[0, 3].Count - 1)];
            picbox2DArr[0, 3].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr04_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[0, 4].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[0, 4].RemoveAt(picboxBitmapList[0, 4].Count - 1);
                if (picboxBitmapList[0, 4].Count != 0)
                    picbox2DArr[0, 4].Image = picboxBitmapList[0, 4][(picboxBitmapList[0, 4].Count - 1)];
                else
                {
                    picbox2DArr[0, 4].Image = null;
                    picbox2DArr[0, 4].BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
            }
        }
        void picbox2DArr04_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[0, 4].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[0, 4].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr04_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[0, 4].Add(bmp);
            picbox2DArr[0, 4].Image = picboxBitmapList[0, 4][(picboxBitmapList[0, 4].Count - 1)];
            picbox2DArr[0, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr05_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[0, 5].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[0, 5].RemoveAt(picboxBitmapList[0, 5].Count - 1);
                if (picboxBitmapList[0, 5].Count != 0)
                    picbox2DArr[0, 5].Image = picboxBitmapList[0, 5][(picboxBitmapList[0, 5].Count - 1)];
                else
                {
                    picbox2DArr[0, 5].Image = null;
                    picbox2DArr[0, 5].BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
            }
        }
        void picbox2DArr05_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[0, 5].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[0, 5].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr05_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[0, 5].Add(bmp);
            picbox2DArr[0, 5].Image = picboxBitmapList[0, 5][(picboxBitmapList[0, 5].Count - 1)];
            picbox2DArr[0, 5].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr06_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[0, 6].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[0, 6].RemoveAt(picboxBitmapList[0, 6].Count - 1);
                if (picboxBitmapList[0, 6].Count != 0)
                    picbox2DArr[0, 6].Image = picboxBitmapList[0, 6][(picboxBitmapList[0, 6].Count - 1)];
                else
                {
                    picbox2DArr[0, 6].Image = null;
                    picbox2DArr[0, 6].BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
            }
        }
        void picbox2DArr06_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[0, 6].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[0, 6].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr06_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[0, 6].Add(bmp);
            picbox2DArr[0, 6].Image = picboxBitmapList[0, 6][(picboxBitmapList[0, 6].Count - 1)];
            picbox2DArr[0, 6].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr10_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[1, 0].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[1, 0].RemoveAt(picboxBitmapList[1, 0].Count - 1);
                if (picboxBitmapList[1, 0].Count != 0)
                    picbox2DArr[1, 0].Image = picboxBitmapList[1, 0][(picboxBitmapList[1, 0].Count - 1)];
                else
                {
                    picbox2DArr[1, 0].Image = null;
                    picbox2DArr[1, 0].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[0, 0].Image = picboxBitmapList[0, 0][
                    (picboxBitmapList[0, 0].Count - 1)];
                    picbox2DArr[0, 0].BringToFront();
                }
            }
        }
        void picbox2DArr10_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[1, 0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[1, 0].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr10_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[1, 0].Add(bmp);
            picbox2DArr[1, 0].Image = picboxBitmapList[1, 0][(picboxBitmapList[1, 0].Count - 1)];
            picbox2DArr[1, 0].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr11_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[1, 1].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[1, 1].RemoveAt(picboxBitmapList[1, 1].Count - 1);
                if (picboxBitmapList[1, 1].Count != 0)
                    picbox2DArr[1, 1].Image = picboxBitmapList[1, 1][(picboxBitmapList[1, 1].Count - 1)];
                else
                {
                    picbox2DArr[1, 1].Image = null;
                    picbox2DArr[1, 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[0, 1].Image = picboxBitmapList[0, 1][
                    (picboxBitmapList[0, 1].Count - 1)];
                    picbox2DArr[0, 1].BringToFront();
                }
            }
        }
        void picbox2DArr11_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[1, 1].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[1, 1].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr11_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[1, 1].Add(bmp);
            picbox2DArr[1, 1].Image = picboxBitmapList[1, 1][(picboxBitmapList[1, 1].Count - 1)];
            picbox2DArr[1, 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr12_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[1, 2].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[1, 2].RemoveAt(picboxBitmapList[1, 2].Count - 1);
                if (picboxBitmapList[1, 2].Count != 0)
                    picbox2DArr[1, 2].Image = picboxBitmapList[1, 2][(picboxBitmapList[1, 2].Count - 1)];
                else
                {
                    picbox2DArr[1, 2].Image = null;
                    picbox2DArr[1, 2].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[0, 2].Image = picboxBitmapList[0, 2][
                    (picboxBitmapList[0, 2].Count - 1)];
                    picbox2DArr[0, 2].BringToFront();
                }
            }
        }
        void picbox2DArr12_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[1, 2].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[1, 2].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr12_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[1, 2].Add(bmp);
            picbox2DArr[1, 2].Image = picboxBitmapList[1, 2][(picboxBitmapList[1, 2].Count - 1)];
            picbox2DArr[1, 2].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr13_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[1, 3].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[1, 3].RemoveAt(picboxBitmapList[1, 3].Count - 1);
                if (picboxBitmapList[1, 3].Count != 0)
                    picbox2DArr[1, 3].Image = picboxBitmapList[1, 3][(picboxBitmapList[1, 3].Count - 1)];
                else
                {
                    picbox2DArr[1, 3].Image = null;
                    picbox2DArr[1, 3].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[0, 3].Image = picboxBitmapList[0, 3][
                    (picboxBitmapList[0, 3].Count - 1)];
                    picbox2DArr[0, 3].BringToFront();
                }
            }
        }
        void picbox2DArr13_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[1, 3].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[1, 3].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr13_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[1, 3].Add(bmp);
            picbox2DArr[1, 3].Image = picboxBitmapList[1, 3][(picboxBitmapList[1, 3].Count - 1)];
            picbox2DArr[1, 3].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr14_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[1, 4].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[1, 4].RemoveAt(picboxBitmapList[1, 4].Count - 1);
                if (picboxBitmapList[1, 4].Count != 0)
                    picbox2DArr[1, 4].Image = picboxBitmapList[1, 4][(picboxBitmapList[1, 4].Count - 1)];
                else
                {
                    picbox2DArr[1, 4].Image = null;
                    picbox2DArr[1, 4].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[0, 4].Image = picboxBitmapList[0, 4][
                    (picboxBitmapList[0, 4].Count - 1)];
                    picbox2DArr[0, 4].BringToFront();
                }
            }
        }
        void picbox2DArr14_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[1, 4].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[1, 4].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr14_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[1, 4].Add(bmp);
            picbox2DArr[1, 4].Image = picboxBitmapList[1, 4][(picboxBitmapList[1, 4].Count - 1)];
            picbox2DArr[1, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr15_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[1, 5].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[1, 5].RemoveAt(picboxBitmapList[1, 5].Count - 1);
                if (picboxBitmapList[1, 5].Count != 0)
                    picbox2DArr[1, 5].Image = picboxBitmapList[1, 5][(picboxBitmapList[1, 5].Count - 1)];
                else
                {
                    picbox2DArr[1, 5].Image = null;
                    picbox2DArr[1, 5].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[0, 5].Image = picboxBitmapList[0, 5][
                    (picboxBitmapList[0, 5].Count - 1)];
                    picbox2DArr[0, 5].BringToFront();
                }
            }
        }
        void picbox2DArr15_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[1, 5].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[1, 5].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr15_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[1, 5].Add(bmp);
            picbox2DArr[1, 5].Image = picboxBitmapList[1, 5][(picboxBitmapList[1, 5].Count - 1)];
            picbox2DArr[1, 5].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr16_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[1, 6].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[1, 6].RemoveAt(picboxBitmapList[1, 6].Count - 1);
                if (picboxBitmapList[1, 6].Count != 0)
                    picbox2DArr[1, 6].Image = picboxBitmapList[1, 6][(picboxBitmapList[1, 6].Count - 1)];
                else
                {
                    picbox2DArr[1, 6].Image = null;
                    picbox2DArr[1, 6].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[0, 6].Image = picboxBitmapList[0, 6][
                    (picboxBitmapList[0, 6].Count - 1)];
                    picbox2DArr[0, 6].BringToFront();
                }
            }
        }
        void picbox2DArr16_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[1, 6].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[1, 6].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr16_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[1, 6].Add(bmp);
            picbox2DArr[1, 6].Image = picboxBitmapList[1, 6][(picboxBitmapList[1, 6].Count - 1)];
            picbox2DArr[1, 6].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr20_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[2, 0].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[2, 0].RemoveAt(picboxBitmapList[2, 0].Count - 1);
                if (picboxBitmapList[2, 0].Count != 0)
                    picbox2DArr[2, 0].Image = picboxBitmapList[2, 0][(picboxBitmapList[2, 0].Count - 1)];
                else
                {
                    picbox2DArr[2, 0].Image = null;
                    picbox2DArr[2, 0].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[1, 0].Image = picboxBitmapList[1, 0][
                    (picboxBitmapList[1, 0].Count - 1)];
                    picbox2DArr[1, 0].BringToFront();
                }
            }
        }
        void picbox2DArr20_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[2, 0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[2, 0].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr20_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[2, 0].Add(bmp);
            picbox2DArr[2, 0].Image = picboxBitmapList[2, 0][(picboxBitmapList[2, 0].Count - 1)];
            picbox2DArr[2, 0].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr21_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[2, 1].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[2, 1].RemoveAt(picboxBitmapList[2, 1].Count - 1);
                if (picboxBitmapList[2, 1].Count != 0)
                    picbox2DArr[2, 1].Image = picboxBitmapList[2, 1][(picboxBitmapList[2, 1].Count - 1)];
                else
                {
                    picbox2DArr[2, 1].Image = null;
                    picbox2DArr[2, 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[1, 1].Image = picboxBitmapList[1, 1][
                    (picboxBitmapList[1, 1].Count - 1)];
                    picbox2DArr[1, 1].BringToFront();
                }
            }
        }
        void picbox2DArr21_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[2, 1].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[2, 1].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr21_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[2, 1].Add(bmp);
            picbox2DArr[2, 1].Image = picboxBitmapList[2, 1][(picboxBitmapList[2, 1].Count - 1)];
            picbox2DArr[2, 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr22_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[2, 2].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[2, 2].RemoveAt(picboxBitmapList[2, 2].Count - 1);
                if (picboxBitmapList[2, 2].Count != 0)
                    picbox2DArr[2, 2].Image = picboxBitmapList[2, 2][(picboxBitmapList[2, 2].Count - 1)];
                else
                {
                    picbox2DArr[2, 2].Image = null;
                    picbox2DArr[2, 2].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[1, 2].Image = picboxBitmapList[1, 2][
                    (picboxBitmapList[1, 2].Count - 1)];
                    picbox2DArr[1, 2].BringToFront();
                }
            }
        }
        void picbox2DArr22_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[2, 2].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[2, 2].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr22_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[2, 2].Add(bmp);
            picbox2DArr[2, 2].Image = picboxBitmapList[2, 2][(picboxBitmapList[2, 2].Count - 1)];
            picbox2DArr[2, 2].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr23_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[2, 3].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[2, 3].RemoveAt(picboxBitmapList[2, 3].Count - 1);
                if (picboxBitmapList[2, 3].Count != 0)
                    picbox2DArr[2, 3].Image = picboxBitmapList[2, 3][(picboxBitmapList[2, 3].Count - 1)];
                else
                {
                    picbox2DArr[2, 3].Image = null;
                    picbox2DArr[2, 3].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[1, 3].Image = picboxBitmapList[1, 3][
                    (picboxBitmapList[1, 3].Count - 1)];
                    picbox2DArr[1, 3].BringToFront();
                }
            }
        }
        void picbox2DArr23_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[2, 3].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[2, 3].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr23_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[2, 3].Add(bmp);
            picbox2DArr[2, 3].Image = picboxBitmapList[2, 3][(picboxBitmapList[2, 3].Count - 1)];
            picbox2DArr[2, 3].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr24_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[2, 4].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[2, 4].RemoveAt(picboxBitmapList[2, 4].Count - 1);
                if (picboxBitmapList[2, 4].Count != 0)
                    picbox2DArr[2, 4].Image = picboxBitmapList[2, 4][(picboxBitmapList[2, 4].Count - 1)];
                else
                {
                    picbox2DArr[2, 4].Image = null;
                    picbox2DArr[2, 4].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[1, 4].Image = picboxBitmapList[1, 4][
                    (picboxBitmapList[1, 4].Count - 1)];
                    picbox2DArr[1, 4].BringToFront();
                }
            }
        }
        void picbox2DArr24_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[2, 4].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[2, 4].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr24_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[2, 4].Add(bmp);
            picbox2DArr[2, 4].Image = picboxBitmapList[2, 4][(picboxBitmapList[2, 4].Count - 1)];
            picbox2DArr[2, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr25_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[2, 5].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[2, 5].RemoveAt(picboxBitmapList[2, 5].Count - 1);
                if (picboxBitmapList[2, 5].Count != 0)
                    picbox2DArr[2, 5].Image = picboxBitmapList[2, 5][(picboxBitmapList[2, 5].Count - 1)];
                else
                {
                    picbox2DArr[2, 5].Image = null;
                    picbox2DArr[2, 5].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[1, 5].Image = picboxBitmapList[1, 5][
                    (picboxBitmapList[1, 5].Count - 1)];
                    picbox2DArr[1, 5].BringToFront();
                }
            }
        }
        void picbox2DArr25_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[2, 5].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[2, 5].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr25_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[2, 5].Add(bmp);
            picbox2DArr[2, 5].Image = picboxBitmapList[2, 5][(picboxBitmapList[2, 5].Count - 1)];
            picbox2DArr[2, 5].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr26_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[2, 6].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[2, 6].RemoveAt(picboxBitmapList[2, 6].Count - 1);
                if (picboxBitmapList[2, 6].Count != 0)
                    picbox2DArr[2, 6].Image = picboxBitmapList[2, 6][(picboxBitmapList[2, 6].Count - 1)];
                else
                {
                    picbox2DArr[2, 6].Image = null;
                    picbox2DArr[2, 6].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[1, 6].Image = picboxBitmapList[1, 6][
                    (picboxBitmapList[1, 6].Count - 1)];
                    picbox2DArr[1, 6].BringToFront();
                }
            }
        }
        void picbox2DArr26_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[2, 6].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[2, 6].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr26_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[2, 6].Add(bmp);
            picbox2DArr[2, 6].Image = picboxBitmapList[2, 6][(picboxBitmapList[2, 6].Count - 1)];
            picbox2DArr[2, 6].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr30_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[3, 0].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[3, 0].RemoveAt(picboxBitmapList[3, 0].Count - 1);
                if (picboxBitmapList[3, 0].Count != 0)
                    picbox2DArr[3, 0].Image = picboxBitmapList[3, 0][(picboxBitmapList[3, 0].Count - 1)];
                else
                {
                    picbox2DArr[3, 0].Image = null;
                    picbox2DArr[3, 0].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[2, 0].Image = picboxBitmapList[2, 0][
                    (picboxBitmapList[2, 0].Count - 1)];
                    picbox2DArr[2, 0].BringToFront();
                }
            }
        }
        void picbox2DArr30_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[3, 0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[3, 0].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr30_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[3, 0].Add(bmp);
            picbox2DArr[3, 0].Image = picboxBitmapList[3, 0][(picboxBitmapList[3, 0].Count - 1)];
            picbox2DArr[3, 0].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr31_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[3, 1].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[3, 1].RemoveAt(picboxBitmapList[3, 1].Count - 1);
                if (picboxBitmapList[3, 1].Count != 0)
                    picbox2DArr[3, 1].Image = picboxBitmapList[3, 1][(picboxBitmapList[3, 1].Count - 1)];
                else
                {
                    picbox2DArr[3, 1].Image = null;
                    picbox2DArr[3, 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[2, 1].Image = picboxBitmapList[2, 1][
                    (picboxBitmapList[2, 1].Count - 1)];
                    picbox2DArr[2, 1].BringToFront();
                }
            }
        }
        void picbox2DArr31_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[3, 1].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[3, 1].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr31_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[3, 1].Add(bmp);
            picbox2DArr[3, 1].Image = picboxBitmapList[3, 1][(picboxBitmapList[3, 1].Count - 1)];
            picbox2DArr[3, 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr32_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[3, 2].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[3, 2].RemoveAt(picboxBitmapList[3, 2].Count - 1);
                if (picboxBitmapList[3, 2].Count != 0)
                    picbox2DArr[3, 2].Image = picboxBitmapList[3, 2][(picboxBitmapList[3, 2].Count - 1)];
                else
                {
                    picbox2DArr[3, 2].Image = null;
                    picbox2DArr[3, 2].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[2, 2].Image = picboxBitmapList[2, 2][
                    (picboxBitmapList[2, 2].Count - 1)];
                    picbox2DArr[2, 2].BringToFront();
                }
            }
        }
        void picbox2DArr32_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[3, 2].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[3, 2].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr32_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[3, 2].Add(bmp);
            picbox2DArr[3, 2].Image = picboxBitmapList[3, 2][(picboxBitmapList[3, 2].Count - 1)];
            picbox2DArr[3, 2].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr33_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[3, 3].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[3, 3].RemoveAt(picboxBitmapList[3, 3].Count - 1);
                if (picboxBitmapList[3, 3].Count != 0)
                    picbox2DArr[3, 3].Image = picboxBitmapList[3, 3][(picboxBitmapList[3, 3].Count - 1)];
                else
                {
                    picbox2DArr[3, 3].Image = null;
                    picbox2DArr[3, 3].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[2, 3].Image = picboxBitmapList[2, 3][
                    (picboxBitmapList[2, 3].Count - 1)];
                    picbox2DArr[2, 3].BringToFront();
                }
            }
        }
        void picbox2DArr33_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[3, 3].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[3, 3].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr33_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[3, 3].Add(bmp);
            picbox2DArr[3, 3].Image = picboxBitmapList[3, 3][(picboxBitmapList[3, 3].Count - 1)];
            picbox2DArr[3, 3].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr34_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[3, 4].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[3, 4].RemoveAt(picboxBitmapList[3, 4].Count - 1);
                if (picboxBitmapList[3, 4].Count != 0)
                    picbox2DArr[3, 4].Image = picboxBitmapList[3, 4][(picboxBitmapList[3, 4].Count - 1)];
                else
                {
                    picbox2DArr[3, 4].Image = null;
                    picbox2DArr[3, 4].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[2, 4].Image = picboxBitmapList[2, 4][
                    (picboxBitmapList[2, 4].Count - 1)];
                    picbox2DArr[2, 4].BringToFront();
                }
            }
        }
        void picbox2DArr34_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[3, 4].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[3, 4].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr34_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[3, 4].Add(bmp);
            picbox2DArr[3, 4].Image = picboxBitmapList[3, 4][(picboxBitmapList[3, 4].Count - 1)];
            picbox2DArr[3, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr35_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[3, 5].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[3, 5].RemoveAt(picboxBitmapList[3, 5].Count - 1);
                if (picboxBitmapList[3, 5].Count != 0)
                    picbox2DArr[3, 5].Image = picboxBitmapList[3, 5][(picboxBitmapList[3, 5].Count - 1)];
                else
                {
                    picbox2DArr[3, 5].Image = null;
                    picbox2DArr[3, 5].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[2, 5].Image = picboxBitmapList[2, 5][
                    (picboxBitmapList[2, 5].Count - 1)];
                    picbox2DArr[2, 5].BringToFront();
                }
            }
        }
        void picbox2DArr35_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[3, 5].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[3, 5].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr35_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[3, 5].Add(bmp);
            picbox2DArr[3, 5].Image = picboxBitmapList[3, 5][(picboxBitmapList[3, 5].Count - 1)];
            picbox2DArr[3, 5].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr36_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[3, 6].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[3, 6].RemoveAt(picboxBitmapList[3, 6].Count - 1);
                if (picboxBitmapList[3, 6].Count != 0)
                    picbox2DArr[3, 6].Image = picboxBitmapList[3, 6][(picboxBitmapList[3, 6].Count - 1)];
                else
                {
                    picbox2DArr[3, 6].Image = null;
                    picbox2DArr[3, 6].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[2, 6].Image = picboxBitmapList[2, 6][
                    (picboxBitmapList[2, 6].Count - 1)];
                    picbox2DArr[2, 6].BringToFront();
                }
            }
        }
        void picbox2DArr36_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[3, 6].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[3, 6].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr36_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[3, 6].Add(bmp);
            picbox2DArr[3, 6].Image = picboxBitmapList[3, 6][(picboxBitmapList[3, 6].Count - 1)];
            picbox2DArr[3, 6].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr40_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[4, 0].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[4, 0].RemoveAt(picboxBitmapList[4, 0].Count - 1);
                if (picboxBitmapList[4, 0].Count != 0)
                    picbox2DArr[4, 0].Image = picboxBitmapList[4, 0][(picboxBitmapList[4, 0].Count - 1)];
                else
                {
                    picbox2DArr[4, 0].Image = null;
                    picbox2DArr[4, 0].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[3, 0].Image = picboxBitmapList[3, 0][
                    (picboxBitmapList[3, 0].Count - 1)];
                    picbox2DArr[3, 0].BringToFront();
                }
            }
        }
        void picbox2DArr40_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[4, 0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[4, 0].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr40_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[4, 0].Add(bmp);
            picbox2DArr[4, 0].Image = picboxBitmapList[4, 0][(picboxBitmapList[4, 0].Count - 1)];
            picbox2DArr[4, 0].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr41_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[4, 1].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[4, 1].RemoveAt(picboxBitmapList[4, 1].Count - 1);
                if (picboxBitmapList[4, 1].Count != 0)
                    picbox2DArr[4, 1].Image = picboxBitmapList[4, 1][(picboxBitmapList[4, 1].Count - 1)];
                else
                {
                    picbox2DArr[4, 1].Image = null;
                    picbox2DArr[4, 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[3, 1].Image = picboxBitmapList[3, 1][
                    (picboxBitmapList[3, 1].Count - 1)];
                    picbox2DArr[3, 1].BringToFront();
                }
            }
        }
        void picbox2DArr41_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[4, 1].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[4, 1].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr41_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[4, 1].Add(bmp);
            picbox2DArr[4, 1].Image = picboxBitmapList[4, 1][(picboxBitmapList[4, 1].Count - 1)];
            picbox2DArr[4, 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr42_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[4, 2].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[4, 2].RemoveAt(picboxBitmapList[4, 2].Count - 1);
                if (picboxBitmapList[4, 2].Count != 0)
                    picbox2DArr[4, 2].Image = picboxBitmapList[4, 2][(picboxBitmapList[4, 2].Count - 1)];
                else
                {
                    picbox2DArr[4, 2].Image = null;
                    picbox2DArr[4, 2].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[3, 2].Image = picboxBitmapList[3, 2][
                    (picboxBitmapList[3, 2].Count - 1)];
                    picbox2DArr[3, 2].BringToFront();
                }
            }
        }
        void picbox2DArr42_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[4, 2].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[4, 2].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr42_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[4, 2].Add(bmp);
            picbox2DArr[4, 2].Image = picboxBitmapList[4, 2][(picboxBitmapList[4, 2].Count - 1)];
            picbox2DArr[4, 2].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr43_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[4, 3].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[4, 3].RemoveAt(picboxBitmapList[4, 3].Count - 1);
                if (picboxBitmapList[4, 3].Count != 0)
                    picbox2DArr[4, 3].Image = picboxBitmapList[4, 3][(picboxBitmapList[4, 3].Count - 1)];
                else
                {
                    picbox2DArr[4, 3].Image = null;
                    picbox2DArr[4, 3].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[3, 3].Image = picboxBitmapList[3, 3][
                    (picboxBitmapList[3, 3].Count - 1)];
                    picbox2DArr[3, 3].BringToFront();
                }
            }
        }
        void picbox2DArr43_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[4, 3].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[4, 3].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr43_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[4, 3].Add(bmp);
            picbox2DArr[4, 3].Image = picboxBitmapList[4, 3][(picboxBitmapList[4, 3].Count - 1)];
            picbox2DArr[4, 3].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr44_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[4, 4].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[4, 4].RemoveAt(picboxBitmapList[4, 4].Count - 1);
                if (picboxBitmapList[4, 4].Count != 0)
                    picbox2DArr[4, 4].Image = picboxBitmapList[4, 4][(picboxBitmapList[4, 4].Count - 1)];
                else
                {
                    picbox2DArr[4, 4].Image = null;
                    picbox2DArr[4, 4].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[3, 4].Image = picboxBitmapList[3, 4][
                    (picboxBitmapList[3, 4].Count - 1)];
                    picbox2DArr[3, 4].BringToFront();
                }
            }
        }
        void picbox2DArr44_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[4, 4].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[4, 4].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr44_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[4, 4].Add(bmp);
            picbox2DArr[4, 4].Image = picboxBitmapList[4, 4][(picboxBitmapList[4, 4].Count - 1)];
            picbox2DArr[4, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr45_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[4, 5].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[4, 5].RemoveAt(picboxBitmapList[4, 5].Count - 1);
                if (picboxBitmapList[4, 5].Count != 0)
                    picbox2DArr[4, 5].Image = picboxBitmapList[4, 5][(picboxBitmapList[4, 5].Count - 1)];
                else
                {
                    picbox2DArr[4, 5].Image = null;
                    picbox2DArr[4, 5].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[3, 5].Image = picboxBitmapList[3, 5][
                    (picboxBitmapList[3, 5].Count - 1)];
                    picbox2DArr[3, 5].BringToFront();
                }
            }
        }
        void picbox2DArr45_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[4, 5].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[4, 5].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr45_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[4, 5].Add(bmp);
            picbox2DArr[4, 5].Image = picboxBitmapList[4, 5][(picboxBitmapList[4, 5].Count - 1)];
            picbox2DArr[4, 5].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr46_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[4, 6].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[4, 6].RemoveAt(picboxBitmapList[4, 6].Count - 1);
                if (picboxBitmapList[4, 6].Count != 0)
                    picbox2DArr[4, 6].Image = picboxBitmapList[4, 6][(picboxBitmapList[4, 6].Count - 1)];
                else
                {
                    picbox2DArr[4, 6].Image = null;
                    picbox2DArr[4, 6].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[3, 6].Image = picboxBitmapList[3, 6][
                    (picboxBitmapList[3, 6].Count - 1)];
                    picbox2DArr[3, 6].BringToFront();
                }
            }
        }
        void picbox2DArr46_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[4, 6].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[4, 6].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr46_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[4, 6].Add(bmp);
            picbox2DArr[4, 6].Image = picboxBitmapList[4, 6][(picboxBitmapList[4, 6].Count - 1)];
            picbox2DArr[4, 6].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr50_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[5, 0].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[5, 0].RemoveAt(picboxBitmapList[5, 0].Count - 1);
                if (picboxBitmapList[5, 0].Count != 0)
                    picbox2DArr[5, 0].Image = picboxBitmapList[5, 0][(picboxBitmapList[5, 0].Count - 1)];
                else
                {
                    picbox2DArr[5, 0].Image = null;
                    picbox2DArr[5, 0].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[4, 0].Image = picboxBitmapList[4, 0][
                    (picboxBitmapList[4, 0].Count - 1)];
                    picbox2DArr[4, 0].BringToFront();
                }
            }
        }
        void picbox2DArr50_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[5, 0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[5, 0].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr50_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[5, 0].Add(bmp);
            picbox2DArr[5, 0].Image = picboxBitmapList[5, 0][(picboxBitmapList[5, 0].Count - 1)];
            picbox2DArr[5, 0].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr51_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[5, 1].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[5, 1].RemoveAt(picboxBitmapList[5, 1].Count - 1);
                if (picboxBitmapList[5, 1].Count != 0)
                    picbox2DArr[5, 1].Image = picboxBitmapList[5, 1][(picboxBitmapList[5, 1].Count - 1)];
                else
                {
                    picbox2DArr[5, 1].Image = null;
                    picbox2DArr[5, 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[4, 1].Image = picboxBitmapList[4, 1][
                    (picboxBitmapList[4, 1].Count - 1)];
                    picbox2DArr[4, 1].BringToFront();
                }
            }
        }
        void picbox2DArr51_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[5, 1].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[5, 1].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr51_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[5, 1].Add(bmp);
            picbox2DArr[5, 1].Image = picboxBitmapList[5, 1][(picboxBitmapList[5, 1].Count - 1)];
            picbox2DArr[5, 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr52_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[5, 2].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[5, 2].RemoveAt(picboxBitmapList[5, 2].Count - 1);
                if (picboxBitmapList[5, 2].Count != 0)
                    picbox2DArr[5, 2].Image = picboxBitmapList[5, 2][(picboxBitmapList[5, 2].Count - 1)];
                else
                {
                    picbox2DArr[5, 2].Image = null;
                    picbox2DArr[5, 2].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[4, 2].Image = picboxBitmapList[4, 2][
                    (picboxBitmapList[4, 2].Count - 1)];
                    picbox2DArr[4, 2].BringToFront();
                }
            }
        }
        void picbox2DArr52_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[5, 2].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[5, 2].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr52_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[5, 2].Add(bmp);
            picbox2DArr[5, 2].Image = picboxBitmapList[5, 2][(picboxBitmapList[5, 2].Count - 1)];
            picbox2DArr[5, 2].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr53_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[5, 3].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[5, 3].RemoveAt(picboxBitmapList[5, 3].Count - 1);
                if (picboxBitmapList[5, 3].Count != 0)
                    picbox2DArr[5, 3].Image = picboxBitmapList[5, 3][(picboxBitmapList[5, 3].Count - 1)];
                else
                {
                    picbox2DArr[5, 3].Image = null;
                    picbox2DArr[5, 3].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[4, 3].Image = picboxBitmapList[4, 3][
                    (picboxBitmapList[4, 3].Count - 1)];
                    picbox2DArr[4, 3].BringToFront();
                }
            }
        }
        void picbox2DArr53_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[5, 3].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[5, 3].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr53_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[5, 3].Add(bmp);
            picbox2DArr[5, 3].Image = picboxBitmapList[5, 3][(picboxBitmapList[5, 3].Count - 1)];
            picbox2DArr[5, 3].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr54_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[5, 4].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[5, 4].RemoveAt(picboxBitmapList[5, 4].Count - 1);
                if (picboxBitmapList[5, 4].Count != 0)
                    picbox2DArr[5, 4].Image = picboxBitmapList[5, 4][(picboxBitmapList[5, 4].Count - 1)];
                else
                {
                    picbox2DArr[5, 4].Image = null;
                    picbox2DArr[5, 4].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[4, 4].Image = picboxBitmapList[4, 4][
                    (picboxBitmapList[4, 4].Count - 1)];
                    picbox2DArr[4, 4].BringToFront();
                }
            }
        }
        void picbox2DArr54_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[5, 4].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[5, 4].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr54_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[5, 4].Add(bmp);
            picbox2DArr[5, 4].Image = picboxBitmapList[5, 4][(picboxBitmapList[5, 4].Count - 1)];
            picbox2DArr[5, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr55_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[5, 5].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[5, 5].RemoveAt(picboxBitmapList[5, 5].Count - 1);
                if (picboxBitmapList[5, 5].Count != 0)
                    picbox2DArr[5, 5].Image = picboxBitmapList[5, 5][(picboxBitmapList[5, 5].Count - 1)];
                else
                {
                    picbox2DArr[5, 5].Image = null;
                    picbox2DArr[5, 5].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[4, 5].Image = picboxBitmapList[4, 5][
                    (picboxBitmapList[4, 5].Count - 1)];
                    picbox2DArr[4, 5].BringToFront();
                }
            }
        }
        void picbox2DArr55_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[5, 5].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[5, 5].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr55_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[5, 5].Add(bmp);
            picbox2DArr[5, 5].Image = picboxBitmapList[5, 5][(picboxBitmapList[5, 5].Count - 1)];
            picbox2DArr[5, 5].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr56_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[5, 6].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[5, 6].RemoveAt(picboxBitmapList[5, 6].Count - 1);
                if (picboxBitmapList[5, 6].Count != 0)
                    picbox2DArr[5, 6].Image = picboxBitmapList[5, 6][(picboxBitmapList[5, 6].Count - 1)];
                else
                {
                    picbox2DArr[5, 6].Image = null;
                    picbox2DArr[5, 6].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[4, 6].Image = picboxBitmapList[4, 6][
                    (picboxBitmapList[4, 6].Count - 1)];
                    picbox2DArr[4, 6].BringToFront();
                }
            }
        }
        void picbox2DArr56_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[5, 6].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[5, 6].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr56_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[5, 6].Add(bmp);
            picbox2DArr[5, 6].Image = picboxBitmapList[5, 6][(picboxBitmapList[5, 6].Count - 1)];
            picbox2DArr[5, 6].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr60_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[6, 0].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[6, 0].RemoveAt(picboxBitmapList[6, 0].Count - 1);
                if (picboxBitmapList[6, 0].Count != 0)
                    picbox2DArr[6, 0].Image = picboxBitmapList[6, 0][(picboxBitmapList[6, 0].Count - 1)];
                else
                {
                    picbox2DArr[6, 0].Image = null;
                    picbox2DArr[6, 0].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[5, 0].Image = picboxBitmapList[5, 0][
                    (picboxBitmapList[5, 0].Count - 1)];
                    picbox2DArr[5, 0].BringToFront();
                }
            }
        }
        void picbox2DArr60_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[6, 0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[6, 0].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr60_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[6, 0].Add(bmp);
            picbox2DArr[6, 0].Image = picboxBitmapList[6, 0][(picboxBitmapList[6, 0].Count - 1)];
            picbox2DArr[6, 0].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr61_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[6, 1].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[6, 1].RemoveAt(picboxBitmapList[6, 1].Count - 1);
                if (picboxBitmapList[6, 1].Count != 0)
                    picbox2DArr[6, 1].Image = picboxBitmapList[6, 1][(picboxBitmapList[6, 1].Count - 1)];
                else
                {
                    picbox2DArr[6, 1].Image = null;
                    picbox2DArr[6, 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[5, 1].Image = picboxBitmapList[5, 1][
                    (picboxBitmapList[5, 1].Count - 1)];
                    picbox2DArr[5, 1].BringToFront();
                }
            }
        }
        void picbox2DArr61_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[6, 1].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[6, 1].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr61_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[6, 1].Add(bmp);
            picbox2DArr[6, 1].Image = picboxBitmapList[6, 1][(picboxBitmapList[6, 1].Count - 1)];
            picbox2DArr[6, 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr62_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[6, 2].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[6, 2].RemoveAt(picboxBitmapList[6, 2].Count - 1);
                if (picboxBitmapList[6, 2].Count != 0)
                    picbox2DArr[6, 2].Image = picboxBitmapList[6, 2][(picboxBitmapList[6, 2].Count - 1)];
                else
                {
                    picbox2DArr[6, 2].Image = null;
                    picbox2DArr[6, 2].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[5, 2].Image = picboxBitmapList[5, 2][
                    (picboxBitmapList[5, 2].Count - 1)];
                    picbox2DArr[5, 2].BringToFront();
                }
            }
        }
        void picbox2DArr62_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[6, 2].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[6, 2].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr62_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[6, 2].Add(bmp);
            picbox2DArr[6, 2].Image = picboxBitmapList[6, 2][(picboxBitmapList[6, 2].Count - 1)];
            picbox2DArr[6, 2].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr63_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[6, 3].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[6, 3].RemoveAt(picboxBitmapList[6, 3].Count - 1);
                if (picboxBitmapList[6, 3].Count != 0)
                    picbox2DArr[6, 3].Image = picboxBitmapList[6, 3][(picboxBitmapList[6, 3].Count - 1)];
                else
                {
                    picbox2DArr[6, 3].Image = null;
                    picbox2DArr[6, 3].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[5, 3].Image = picboxBitmapList[5, 3][
                    (picboxBitmapList[5, 3].Count - 1)];
                    picbox2DArr[5, 3].BringToFront();
                }
            }
        }
        void picbox2DArr63_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[6, 3].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[6, 3].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr63_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[6, 3].Add(bmp);
            picbox2DArr[6, 3].Image = picboxBitmapList[6, 3][(picboxBitmapList[6, 3].Count - 1)];
            picbox2DArr[6, 3].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr64_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[6, 4].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[6, 4].RemoveAt(picboxBitmapList[6, 4].Count - 1);
                if (picboxBitmapList[6, 4].Count != 0)
                    picbox2DArr[6, 4].Image = picboxBitmapList[6, 4][(picboxBitmapList[6, 4].Count - 1)];
                else
                {
                    picbox2DArr[6, 4].Image = null;
                    picbox2DArr[6, 4].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[5, 4].Image = picboxBitmapList[5, 4][
                    (picboxBitmapList[5, 4].Count - 1)];
                    picbox2DArr[5, 4].BringToFront();
                }
            }
        }
        void picbox2DArr64_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[6, 4].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[6, 4].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr64_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[6, 4].Add(bmp);
            picbox2DArr[6, 4].Image = picboxBitmapList[6, 4][(picboxBitmapList[6, 4].Count - 1)];
            picbox2DArr[6, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr65_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[6, 5].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[6, 5].RemoveAt(picboxBitmapList[6, 5].Count - 1);
                if (picboxBitmapList[6, 5].Count != 0)
                    picbox2DArr[6, 5].Image = picboxBitmapList[6, 5][(picboxBitmapList[6, 5].Count - 1)];
                else
                {
                    picbox2DArr[6, 5].Image = null;
                    picbox2DArr[6, 5].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[5, 5].Image = picboxBitmapList[5, 5][
                    (picboxBitmapList[5, 5].Count - 1)];
                    picbox2DArr[5, 5].BringToFront();
                }
            }
        }
        void picbox2DArr65_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[6, 5].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[6, 5].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr65_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[6, 5].Add(bmp);
            picbox2DArr[6, 5].Image = picboxBitmapList[6, 5][(picboxBitmapList[6, 5].Count - 1)];
            picbox2DArr[6, 5].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr66_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[6, 6].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[6, 6].RemoveAt(picboxBitmapList[6, 6].Count - 1);
                if (picboxBitmapList[6, 6].Count != 0)
                    picbox2DArr[6, 6].Image = picboxBitmapList[6, 6][(picboxBitmapList[6, 6].Count - 1)];
                else
                {
                    picbox2DArr[6, 6].Image = null;
                    picbox2DArr[6, 6].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[5, 6].Image = picboxBitmapList[5, 6][
                    (picboxBitmapList[5, 6].Count - 1)];
                    picbox2DArr[5, 6].BringToFront();
                }
            }
        }
        void picbox2DArr66_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[6, 6].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[6, 6].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr66_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[6, 6].Add(bmp);
            picbox2DArr[6, 6].Image = picboxBitmapList[6, 6][(picboxBitmapList[6, 6].Count - 1)];
            picbox2DArr[6, 6].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr70_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[7, 0].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[7, 0].RemoveAt(picboxBitmapList[7, 0].Count - 1);
                if (picboxBitmapList[7, 0].Count != 0)
                    picbox2DArr[7, 0].Image = picboxBitmapList[7, 0][(picboxBitmapList[7, 0].Count - 1)];
                else
                {
                    picbox2DArr[7, 0].Image = null;
                    picbox2DArr[7, 0].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[6, 0].Image = picboxBitmapList[6, 0][
                    (picboxBitmapList[6, 0].Count - 1)];
                    picbox2DArr[6, 0].BringToFront();
                }
            }
        }
        void picbox2DArr70_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[7, 0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[7, 0].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr70_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[7, 0].Add(bmp);
            picbox2DArr[7, 0].Image = picboxBitmapList[7, 0][(picboxBitmapList[7, 0].Count - 1)];
            picbox2DArr[7, 0].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr71_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[7, 1].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[7, 1].RemoveAt(picboxBitmapList[7, 1].Count - 1);
                if (picboxBitmapList[7, 1].Count != 0)
                    picbox2DArr[7, 1].Image = picboxBitmapList[7, 1][(picboxBitmapList[7, 1].Count - 1)];
                else
                {
                    picbox2DArr[7, 1].Image = null;
                    picbox2DArr[7, 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[6, 1].Image = picboxBitmapList[6, 1][
                    (picboxBitmapList[6, 1].Count - 1)];
                    picbox2DArr[6, 1].BringToFront();
                }
            }
        }
        void picbox2DArr71_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[7, 1].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[7, 1].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr71_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[7, 1].Add(bmp);
            picbox2DArr[7, 1].Image = picboxBitmapList[7, 1][(picboxBitmapList[7, 1].Count - 1)];
            picbox2DArr[7, 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr72_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[7, 2].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[7, 2].RemoveAt(picboxBitmapList[7, 2].Count - 1);
                if (picboxBitmapList[7, 2].Count != 0)
                    picbox2DArr[7, 2].Image = picboxBitmapList[7, 2][(picboxBitmapList[7, 2].Count - 1)];
                else
                {
                    picbox2DArr[7, 2].Image = null;
                    picbox2DArr[7, 2].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[6, 2].Image = picboxBitmapList[6, 2][
                    (picboxBitmapList[6, 2].Count - 1)];
                    picbox2DArr[6, 2].BringToFront();
                }
            }
        }
        void picbox2DArr72_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[7, 2].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[7, 2].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr72_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[7, 2].Add(bmp);
            picbox2DArr[7, 2].Image = picboxBitmapList[7, 2][(picboxBitmapList[7, 2].Count - 1)];
            picbox2DArr[7, 2].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr73_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[7, 3].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[7, 3].RemoveAt(picboxBitmapList[7, 3].Count - 1);
                if (picboxBitmapList[7, 3].Count != 0)
                    picbox2DArr[7, 3].Image = picboxBitmapList[7, 3][(picboxBitmapList[7, 3].Count - 1)];
                else
                {
                    picbox2DArr[7, 3].Image = null;
                    picbox2DArr[7, 3].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[6, 3].Image = picboxBitmapList[6, 3][
                    (picboxBitmapList[6, 3].Count - 1)];
                    picbox2DArr[6, 3].BringToFront();
                }
            }
        }
        void picbox2DArr73_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[7, 3].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[7, 3].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr73_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[7, 3].Add(bmp);
            picbox2DArr[7, 3].Image = picboxBitmapList[7, 3][(picboxBitmapList[7, 3].Count - 1)];
            picbox2DArr[7, 3].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr74_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[7, 4].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[7, 4].RemoveAt(picboxBitmapList[7, 4].Count - 1);
                if (picboxBitmapList[7, 4].Count != 0)
                    picbox2DArr[7, 4].Image = picboxBitmapList[7, 4][(picboxBitmapList[7, 4].Count - 1)];
                else
                {
                    picbox2DArr[7, 4].Image = null;
                    picbox2DArr[7, 4].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[6, 4].Image = picboxBitmapList[6, 4][
                    (picboxBitmapList[6, 4].Count - 1)];
                    picbox2DArr[6, 4].BringToFront();
                }
            }
        }
        void picbox2DArr74_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[7, 4].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[7, 4].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr74_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[7, 4].Add(bmp);
            picbox2DArr[7, 4].Image = picboxBitmapList[7, 4][(picboxBitmapList[7, 4].Count - 1)];
            picbox2DArr[7, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr75_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[7, 5].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[7, 5].RemoveAt(picboxBitmapList[7, 5].Count - 1);
                if (picboxBitmapList[7, 5].Count != 0)
                    picbox2DArr[7, 5].Image = picboxBitmapList[7, 5][(picboxBitmapList[7, 5].Count - 1)];
                else
                {
                    picbox2DArr[7, 5].Image = null;
                    picbox2DArr[7, 5].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[6, 5].Image = picboxBitmapList[6, 5][
                    (picboxBitmapList[6, 5].Count - 1)];
                    picbox2DArr[6, 5].BringToFront();
                }
            }
        }
        void picbox2DArr75_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[7, 5].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[7, 5].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr75_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[7, 5].Add(bmp);
            picbox2DArr[7, 5].Image = picboxBitmapList[7, 5][(picboxBitmapList[7, 5].Count - 1)];
            picbox2DArr[7, 5].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr76_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[7, 6].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[7, 6].RemoveAt(picboxBitmapList[7, 6].Count - 1);
                if (picboxBitmapList[7, 6].Count != 0)
                    picbox2DArr[7, 6].Image = picboxBitmapList[7, 6][(picboxBitmapList[7, 6].Count - 1)];
                else
                {
                    picbox2DArr[7, 6].Image = null;
                    picbox2DArr[7, 6].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[6, 6].Image = picboxBitmapList[6, 6][
                    (picboxBitmapList[6, 6].Count - 1)];
                    picbox2DArr[6, 6].BringToFront();
                }
            }
        }
        void picbox2DArr76_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[7, 6].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[7, 6].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr76_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[7, 6].Add(bmp);
            picbox2DArr[7, 6].Image = picboxBitmapList[7, 6][(picboxBitmapList[7, 6].Count - 1)];
            picbox2DArr[7, 6].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr80_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[8, 0].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[8, 0].RemoveAt(picboxBitmapList[8, 0].Count - 1);
                if (picboxBitmapList[8, 0].Count != 0)
                    picbox2DArr[8, 0].Image = picboxBitmapList[8, 0][(picboxBitmapList[8, 0].Count - 1)];
                else
                {
                    picbox2DArr[8, 0].Image = null;
                    picbox2DArr[8, 0].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[7, 0].Image = picboxBitmapList[7, 0][
                    (picboxBitmapList[7, 0].Count - 1)];
                    picbox2DArr[7, 0].BringToFront();
                }
            }
        }
        void picbox2DArr80_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[8, 0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[8, 0].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr80_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[8, 0].Add(bmp);
            picbox2DArr[8, 0].Image = picboxBitmapList[8, 0][(picboxBitmapList[8, 0].Count - 1)];
            picbox2DArr[8, 0].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr81_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[8, 1].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[8, 1].RemoveAt(picboxBitmapList[8, 1].Count - 1);
                if (picboxBitmapList[8, 1].Count != 0)
                    picbox2DArr[8, 1].Image = picboxBitmapList[8, 1][(picboxBitmapList[8, 1].Count - 1)];
                else
                {
                    picbox2DArr[8, 1].Image = null;
                    picbox2DArr[8, 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[7, 1].Image = picboxBitmapList[7, 1][
                    (picboxBitmapList[7, 1].Count - 1)];
                    picbox2DArr[7, 1].BringToFront();
                }
            }
        }
        void picbox2DArr81_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[8, 1].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[8, 1].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr81_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[8, 1].Add(bmp);
            picbox2DArr[8, 1].Image = picboxBitmapList[8, 1][(picboxBitmapList[8, 1].Count - 1)];
            picbox2DArr[8, 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr82_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[8, 2].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[8, 2].RemoveAt(picboxBitmapList[8, 2].Count - 1);
                if (picboxBitmapList[8, 2].Count != 0)
                    picbox2DArr[8, 2].Image = picboxBitmapList[8, 2][(picboxBitmapList[8, 2].Count - 1)];
                else
                {
                    picbox2DArr[8, 2].Image = null;
                    picbox2DArr[8, 2].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[7, 2].Image = picboxBitmapList[7, 2][
                    (picboxBitmapList[7, 2].Count - 1)];
                    picbox2DArr[7, 2].BringToFront();
                }
            }
        }
        void picbox2DArr82_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[8, 2].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[8, 2].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr82_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[8, 2].Add(bmp);
            picbox2DArr[8, 2].Image = picboxBitmapList[8, 2][(picboxBitmapList[8, 2].Count - 1)];
            picbox2DArr[8, 2].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr83_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[8, 3].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[8, 3].RemoveAt(picboxBitmapList[8, 3].Count - 1);
                if (picboxBitmapList[8, 3].Count != 0)
                    picbox2DArr[8, 3].Image = picboxBitmapList[8, 3][(picboxBitmapList[8, 3].Count - 1)];
                else
                {
                    picbox2DArr[8, 3].Image = null;
                    picbox2DArr[8, 3].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[7, 3].Image = picboxBitmapList[7, 3][
                    (picboxBitmapList[7, 3].Count - 1)];
                    picbox2DArr[7, 3].BringToFront();
                }
            }
        }
        void picbox2DArr83_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[8, 3].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[8, 3].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr83_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[8, 3].Add(bmp);
            picbox2DArr[8, 3].Image = picboxBitmapList[8, 3][(picboxBitmapList[8, 3].Count - 1)];
            picbox2DArr[8, 3].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr84_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[8, 4].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[8, 4].RemoveAt(picboxBitmapList[8, 4].Count - 1);
                if (picboxBitmapList[8, 4].Count != 0)
                    picbox2DArr[8, 4].Image = picboxBitmapList[8, 4][(picboxBitmapList[8, 4].Count - 1)];
                else
                {
                    picbox2DArr[8, 4].Image = null;
                    picbox2DArr[8, 4].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[7, 4].Image = picboxBitmapList[7, 4][
                    (picboxBitmapList[7, 4].Count - 1)];
                    picbox2DArr[7, 4].BringToFront();
                }
            }
        }
        void picbox2DArr84_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[8, 4].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[8, 4].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr84_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[8, 4].Add(bmp);
            picbox2DArr[8, 4].Image = picboxBitmapList[8, 4][(picboxBitmapList[8, 4].Count - 1)];
            picbox2DArr[8, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr85_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[8, 5].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[8, 5].RemoveAt(picboxBitmapList[8, 5].Count - 1);
                if (picboxBitmapList[8, 5].Count != 0)
                    picbox2DArr[8, 5].Image = picboxBitmapList[8, 5][(picboxBitmapList[8, 5].Count - 1)];
                else
                {
                    picbox2DArr[8, 5].Image = null;
                    picbox2DArr[8, 5].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[7, 5].Image = picboxBitmapList[7, 5][
                    (picboxBitmapList[7, 5].Count - 1)];
                    picbox2DArr[7, 5].BringToFront();
                }
            }
        }
        void picbox2DArr85_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[8, 5].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[8, 5].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr85_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[8, 5].Add(bmp);
            picbox2DArr[8, 5].Image = picboxBitmapList[8, 5][(picboxBitmapList[8, 5].Count - 1)];
            picbox2DArr[8, 5].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr86_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[8, 6].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[8, 6].RemoveAt(picboxBitmapList[8, 6].Count - 1);
                if (picboxBitmapList[8, 6].Count != 0)
                    picbox2DArr[8, 6].Image = picboxBitmapList[8, 6][(picboxBitmapList[8, 6].Count - 1)];
                else
                {
                    picbox2DArr[8, 6].Image = null;
                    picbox2DArr[8, 6].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[7, 6].Image = picboxBitmapList[7, 6][
                    (picboxBitmapList[7, 6].Count - 1)];
                    picbox2DArr[7, 6].BringToFront();
                }
            }
        }
        void picbox2DArr86_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[8, 6].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[8, 6].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr86_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[8, 6].Add(bmp);
            picbox2DArr[8, 6].Image = picboxBitmapList[8, 6][(picboxBitmapList[8, 6].Count - 1)];
            picbox2DArr[8, 6].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr90_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[9, 0].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[9, 0].RemoveAt(picboxBitmapList[9, 0].Count - 1);
                if (picboxBitmapList[9, 0].Count != 0)
                    picbox2DArr[9, 0].Image = picboxBitmapList[9, 0][(picboxBitmapList[9, 0].Count - 1)];
                else
                {
                    picbox2DArr[9, 0].Image = null;
                    picbox2DArr[9, 0].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[8, 0].Image = picboxBitmapList[8, 0][
                    (picboxBitmapList[8, 0].Count - 1)];
                    picbox2DArr[8, 0].BringToFront();
                }
            }
        }
        void picbox2DArr90_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[9, 0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[9, 0].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr90_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[9, 0].Add(bmp);
            picbox2DArr[9, 0].Image = picboxBitmapList[9, 0][(picboxBitmapList[9, 0].Count - 1)];
            picbox2DArr[9, 0].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr91_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[9, 1].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[9, 1].RemoveAt(picboxBitmapList[9, 1].Count - 1);
                if (picboxBitmapList[9, 1].Count != 0)
                    picbox2DArr[9, 1].Image = picboxBitmapList[9, 1][(picboxBitmapList[9, 1].Count - 1)];
                else
                {
                    picbox2DArr[9, 1].Image = null;
                    picbox2DArr[9, 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[8, 1].Image = picboxBitmapList[8, 1][
                    (picboxBitmapList[8, 1].Count - 1)];
                    picbox2DArr[8, 1].BringToFront();
                }
            }
        }
        void picbox2DArr91_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[9, 1].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[9, 1].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr91_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[9, 1].Add(bmp);
            picbox2DArr[9, 1].Image = picboxBitmapList[9, 1][(picboxBitmapList[9, 1].Count - 1)];
            picbox2DArr[9, 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr92_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[9, 2].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[9, 2].RemoveAt(picboxBitmapList[9, 2].Count - 1);
                if (picboxBitmapList[9, 2].Count != 0)
                    picbox2DArr[9, 2].Image = picboxBitmapList[9, 2][(picboxBitmapList[9, 2].Count - 1)];
                else
                {
                    picbox2DArr[9, 2].Image = null;
                    picbox2DArr[9, 2].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[8, 2].Image = picboxBitmapList[8, 2][
                    (picboxBitmapList[8, 2].Count - 1)];
                    picbox2DArr[8, 2].BringToFront();
                }
            }
        }
        void picbox2DArr92_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[9, 2].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[9, 2].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr92_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[9, 2].Add(bmp);
            picbox2DArr[9, 2].Image = picboxBitmapList[9, 2][(picboxBitmapList[9, 2].Count - 1)];
            picbox2DArr[9, 2].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr93_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[9, 3].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[9, 3].RemoveAt(picboxBitmapList[9, 3].Count - 1);
                if (picboxBitmapList[9, 3].Count != 0)
                    picbox2DArr[9, 3].Image = picboxBitmapList[9, 3][(picboxBitmapList[9, 3].Count - 1)];
                else
                {
                    picbox2DArr[9, 3].Image = null;
                    picbox2DArr[9, 3].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[8, 3].Image = picboxBitmapList[8, 3][
                    (picboxBitmapList[8, 3].Count - 1)];
                    picbox2DArr[8, 3].BringToFront();
                }
            }
        }
        void picbox2DArr93_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[9, 3].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[9, 3].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr93_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[9, 3].Add(bmp);
            picbox2DArr[9, 3].Image = picboxBitmapList[9, 3][(picboxBitmapList[9, 3].Count - 1)];
            picbox2DArr[9, 3].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr94_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[9, 4].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[9, 4].RemoveAt(picboxBitmapList[9, 4].Count - 1);
                if (picboxBitmapList[9, 4].Count != 0)
                    picbox2DArr[9, 4].Image = picboxBitmapList[9, 4][(picboxBitmapList[9, 4].Count - 1)];
                else
                {
                    picbox2DArr[9, 4].Image = null;
                    picbox2DArr[9, 4].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[8, 4].Image = picboxBitmapList[8, 4][
                    (picboxBitmapList[8, 4].Count - 1)];
                    picbox2DArr[8, 4].BringToFront();
                }
            }
        }
        void picbox2DArr94_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[9, 4].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[9, 4].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr94_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[9, 4].Add(bmp);
            picbox2DArr[9, 4].Image = picboxBitmapList[9, 4][(picboxBitmapList[9, 4].Count - 1)];
            picbox2DArr[9, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr95_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[9, 5].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[9, 5].RemoveAt(picboxBitmapList[9, 5].Count - 1);
                if (picboxBitmapList[9, 5].Count != 0)
                    picbox2DArr[9, 5].Image = picboxBitmapList[9, 5][(picboxBitmapList[9, 5].Count - 1)];
                else
                {
                    picbox2DArr[9, 5].Image = null;
                    picbox2DArr[9, 5].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[8, 5].Image = picboxBitmapList[8, 5][
                    (picboxBitmapList[8, 5].Count - 1)];
                    picbox2DArr[8, 5].BringToFront();
                }
            }
        }
        void picbox2DArr95_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[9, 5].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[9, 5].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr95_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[9, 5].Add(bmp);
            picbox2DArr[9, 5].Image = picboxBitmapList[9, 5][(picboxBitmapList[9, 5].Count - 1)];
            picbox2DArr[9, 5].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr96_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[9, 6].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[9, 6].RemoveAt(picboxBitmapList[9, 6].Count - 1);
                if (picboxBitmapList[9, 6].Count != 0)
                    picbox2DArr[9, 6].Image = picboxBitmapList[9, 6][(picboxBitmapList[9, 6].Count - 1)];
                else
                {
                    picbox2DArr[9, 6].Image = null;
                    picbox2DArr[9, 6].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[8, 6].Image = picboxBitmapList[8, 6][
                    (picboxBitmapList[8, 6].Count - 1)];
                    picbox2DArr[8, 6].BringToFront();
                }
            }
        }
        void picbox2DArr96_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[9, 6].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[9, 6].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr96_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[9, 6].Add(bmp);
            picbox2DArr[9, 6].Image = picboxBitmapList[9, 6][(picboxBitmapList[9, 6].Count - 1)];
            picbox2DArr[9, 6].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr100_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[10, 0].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[10, 0].RemoveAt(picboxBitmapList[10, 0].Count - 1);
                if (picboxBitmapList[10, 0].Count != 0)
                    picbox2DArr[10, 0].Image = picboxBitmapList[10, 0][(picboxBitmapList[10, 0].Count - 1)];
                else
                {
                    picbox2DArr[10, 0].Image = null;
                    picbox2DArr[10, 0].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[9, 0].Image = picboxBitmapList[9, 0][
                    (picboxBitmapList[9, 0].Count - 1)];
                    picbox2DArr[9, 0].BringToFront();
                }
            }
        }
        void picbox2DArr100_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[10, 0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[10, 0].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr100_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[10, 0].Add(bmp);
            picbox2DArr[10, 0].Image = picboxBitmapList[10, 0][(picboxBitmapList[10, 0].Count - 1)];
            picbox2DArr[10, 0].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr101_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[10, 1].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[10, 1].RemoveAt(picboxBitmapList[10, 1].Count - 1);
                if (picboxBitmapList[10, 1].Count != 0)
                    picbox2DArr[10, 1].Image = picboxBitmapList[10, 1][(picboxBitmapList[10, 1].Count - 1)];
                else
                {
                    picbox2DArr[10, 1].Image = null;
                    picbox2DArr[10, 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[9, 1].Image = picboxBitmapList[9, 1][
                    (picboxBitmapList[9, 1].Count - 1)];
                    picbox2DArr[9, 1].BringToFront();
                }
            }
        }
        void picbox2DArr101_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[10, 1].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[10, 1].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr101_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[10, 1].Add(bmp);
            picbox2DArr[10, 1].Image = picboxBitmapList[10, 1][(picboxBitmapList[10, 1].Count - 1)];
            picbox2DArr[10, 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr102_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[10, 2].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[10, 2].RemoveAt(picboxBitmapList[10, 2].Count - 1);
                if (picboxBitmapList[10, 2].Count != 0)
                    picbox2DArr[10, 2].Image = picboxBitmapList[10, 2][(picboxBitmapList[10, 2].Count - 1)];
                else
                {
                    picbox2DArr[10, 2].Image = null;
                    picbox2DArr[10, 2].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[9, 2].Image = picboxBitmapList[9, 2][
                    (picboxBitmapList[9, 2].Count - 1)];
                    picbox2DArr[9, 2].BringToFront();
                }
            }
        }
        void picbox2DArr102_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[10, 2].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[10, 2].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr102_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[10, 2].Add(bmp);
            picbox2DArr[10, 2].Image = picboxBitmapList[10, 2][(picboxBitmapList[10, 2].Count - 1)];
            picbox2DArr[10, 2].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr103_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[10, 3].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[10, 3].RemoveAt(picboxBitmapList[10, 3].Count - 1);
                if (picboxBitmapList[10, 3].Count != 0)
                    picbox2DArr[10, 3].Image = picboxBitmapList[10, 3][(picboxBitmapList[10, 3].Count - 1)];
                else
                {
                    picbox2DArr[10, 3].Image = null;
                    picbox2DArr[10, 3].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[9, 3].Image = picboxBitmapList[9, 3][
                    (picboxBitmapList[9, 3].Count - 1)];
                    picbox2DArr[9, 3].BringToFront();
                }
            }
        }
        void picbox2DArr103_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[10, 3].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[10, 3].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr103_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[10, 3].Add(bmp);
            picbox2DArr[10, 3].Image = picboxBitmapList[10, 3][(picboxBitmapList[10, 3].Count - 1)];
            picbox2DArr[10, 3].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr104_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[10, 4].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[10, 4].RemoveAt(picboxBitmapList[10, 4].Count - 1);
                if (picboxBitmapList[10, 4].Count != 0)
                    picbox2DArr[10, 4].Image = picboxBitmapList[10, 4][(picboxBitmapList[10, 4].Count - 1)];
                else
                {
                    picbox2DArr[10, 4].Image = null;
                    picbox2DArr[10, 4].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[9, 4].Image = picboxBitmapList[9, 4][
                    (picboxBitmapList[9, 4].Count - 1)];
                    picbox2DArr[9, 4].BringToFront();
                }
            }
        }
        void picbox2DArr104_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[10, 4].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[10, 4].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr104_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[10, 4].Add(bmp);
            picbox2DArr[10, 4].Image = picboxBitmapList[10, 4][(picboxBitmapList[10, 4].Count - 1)];
            picbox2DArr[10, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr105_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[10, 5].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[10, 5].RemoveAt(picboxBitmapList[10, 5].Count - 1);
                if (picboxBitmapList[10, 5].Count != 0)
                    picbox2DArr[10, 5].Image = picboxBitmapList[10, 5][(picboxBitmapList[10, 5].Count - 1)];
                else
                {
                    picbox2DArr[10, 5].Image = null;
                    picbox2DArr[10, 5].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[9, 5].Image = picboxBitmapList[9, 5][
                    (picboxBitmapList[9, 5].Count - 1)];
                    picbox2DArr[9, 5].BringToFront();
                }
            }
        }
        void picbox2DArr105_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[10, 5].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[10, 5].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr105_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[10, 5].Add(bmp);
            picbox2DArr[10, 5].Image = picboxBitmapList[10, 5][(picboxBitmapList[10, 5].Count - 1)];
            picbox2DArr[10, 5].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr106_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[10, 6].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[10, 6].RemoveAt(picboxBitmapList[10, 6].Count - 1);
                if (picboxBitmapList[10, 6].Count != 0)
                    picbox2DArr[10, 6].Image = picboxBitmapList[10, 6][(picboxBitmapList[10, 6].Count - 1)];
                else
                {
                    picbox2DArr[10, 6].Image = null;
                    picbox2DArr[10, 6].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[9, 6].Image = picboxBitmapList[9, 6][
                    (picboxBitmapList[9, 6].Count - 1)];
                    picbox2DArr[9, 6].BringToFront();
                }
            }
        }
        void picbox2DArr106_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[10, 6].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[10, 6].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr106_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[10, 6].Add(bmp);
            picbox2DArr[10, 6].Image = picboxBitmapList[10, 6][(picboxBitmapList[10, 6].Count - 1)];
            picbox2DArr[10, 6].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr110_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[11, 0].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[11, 0].RemoveAt(picboxBitmapList[11, 0].Count - 1);
                if (picboxBitmapList[11, 0].Count != 0)
                    picbox2DArr[11, 0].Image = picboxBitmapList[11, 0][(picboxBitmapList[11, 0].Count - 1)];
                else
                {
                    picbox2DArr[11, 0].Image = null;
                    picbox2DArr[11, 0].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[10, 0].Image = picboxBitmapList[10, 0][
                    (picboxBitmapList[10, 0].Count - 1)];
                    picbox2DArr[10, 0].BringToFront();
                }
            }
        }
        void picbox2DArr110_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[11, 0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[11, 0].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr110_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[11, 0].Add(bmp);
            picbox2DArr[11, 0].Image = picboxBitmapList[11, 0][(picboxBitmapList[11, 0].Count - 1)];
            picbox2DArr[11, 0].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr111_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[11, 1].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[11, 1].RemoveAt(picboxBitmapList[11, 1].Count - 1);
                if (picboxBitmapList[11, 1].Count != 0)
                    picbox2DArr[11, 1].Image = picboxBitmapList[11, 1][(picboxBitmapList[11, 1].Count - 1)];
                else
                {
                    picbox2DArr[11, 1].Image = null;
                    picbox2DArr[11, 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[10, 1].Image = picboxBitmapList[10, 1][
                    (picboxBitmapList[10, 1].Count - 1)];
                    picbox2DArr[10, 1].BringToFront();
                }
            }
        }
        void picbox2DArr111_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[11, 1].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[11, 1].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr111_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[11, 1].Add(bmp);
            picbox2DArr[11, 1].Image = picboxBitmapList[11, 1][(picboxBitmapList[11, 1].Count - 1)];
            picbox2DArr[11, 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr112_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[11, 2].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[11, 2].RemoveAt(picboxBitmapList[11, 2].Count - 1);
                if (picboxBitmapList[11, 2].Count != 0)
                    picbox2DArr[11, 2].Image = picboxBitmapList[11, 2][(picboxBitmapList[11, 2].Count - 1)];
                else
                {
                    picbox2DArr[11, 2].Image = null;
                    picbox2DArr[11, 2].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[10, 2].Image = picboxBitmapList[10, 2][
                    (picboxBitmapList[10, 2].Count - 1)];
                    picbox2DArr[10, 2].BringToFront();
                }
            }
        }
        void picbox2DArr112_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[11, 2].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[11, 2].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr112_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[11, 2].Add(bmp);
            picbox2DArr[11, 2].Image = picboxBitmapList[11, 2][(picboxBitmapList[11, 2].Count - 1)];
            picbox2DArr[11, 2].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr113_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[11, 3].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[11, 3].RemoveAt(picboxBitmapList[11, 3].Count - 1);
                if (picboxBitmapList[11, 3].Count != 0)
                    picbox2DArr[11, 3].Image = picboxBitmapList[11, 3][(picboxBitmapList[11, 3].Count - 1)];
                else
                {
                    picbox2DArr[11, 3].Image = null;
                    picbox2DArr[11, 3].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[10, 3].Image = picboxBitmapList[10, 3][
                    (picboxBitmapList[10, 3].Count - 1)];
                    picbox2DArr[10, 3].BringToFront();
                }
            }
        }
        void picbox2DArr113_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[11, 3].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[11, 3].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr113_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[11, 3].Add(bmp);
            picbox2DArr[11, 3].Image = picboxBitmapList[11, 3][(picboxBitmapList[11, 3].Count - 1)];
            picbox2DArr[11, 3].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr114_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[11, 4].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[11, 4].RemoveAt(picboxBitmapList[11, 4].Count - 1);
                if (picboxBitmapList[11, 4].Count != 0)
                    picbox2DArr[11, 4].Image = picboxBitmapList[11, 4][(picboxBitmapList[11, 4].Count - 1)];
                else
                {
                    picbox2DArr[11, 4].Image = null;
                    picbox2DArr[11, 4].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[10, 4].Image = picboxBitmapList[10, 4][
                    (picboxBitmapList[10, 4].Count - 1)];
                    picbox2DArr[10, 4].BringToFront();
                }
            }
        }
        void picbox2DArr114_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[11, 4].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[11, 4].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr114_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[11, 4].Add(bmp);
            picbox2DArr[11, 4].Image = picboxBitmapList[11, 4][(picboxBitmapList[11, 4].Count - 1)];
            picbox2DArr[11, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr115_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[11, 5].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[11, 5].RemoveAt(picboxBitmapList[11, 5].Count - 1);
                if (picboxBitmapList[11, 5].Count != 0)
                    picbox2DArr[11, 5].Image = picboxBitmapList[11, 5][(picboxBitmapList[11, 5].Count - 1)];
                else
                {
                    picbox2DArr[11, 5].Image = null;
                    picbox2DArr[11, 5].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[10, 5].Image = picboxBitmapList[10, 5][
                    (picboxBitmapList[10, 5].Count - 1)];
                    picbox2DArr[10, 5].BringToFront();
                }
            }
        }
        void picbox2DArr115_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[11, 5].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[11, 5].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr115_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[11, 5].Add(bmp);
            picbox2DArr[11, 5].Image = picboxBitmapList[11, 5][(picboxBitmapList[11, 5].Count - 1)];
            picbox2DArr[11, 5].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr116_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[11, 6].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[11, 6].RemoveAt(picboxBitmapList[11, 6].Count - 1);
                if (picboxBitmapList[11, 6].Count != 0)
                    picbox2DArr[11, 6].Image = picboxBitmapList[11, 6][(picboxBitmapList[11, 6].Count - 1)];
                else
                {
                    picbox2DArr[11, 6].Image = null;
                    picbox2DArr[11, 6].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[10, 6].Image = picboxBitmapList[10, 6][
                    (picboxBitmapList[10, 6].Count - 1)];
                    picbox2DArr[10, 6].BringToFront();
                }
            }
        }
        void picbox2DArr116_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[11, 6].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[11, 6].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr116_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[11, 6].Add(bmp);
            picbox2DArr[11, 6].Image = picboxBitmapList[11, 6][(picboxBitmapList[11, 6].Count - 1)];
            picbox2DArr[11, 6].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr120_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[12, 0].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[12, 0].RemoveAt(picboxBitmapList[12, 0].Count - 1);
                if (picboxBitmapList[12, 0].Count != 0)
                    picbox2DArr[12, 0].Image = picboxBitmapList[12, 0][(picboxBitmapList[12, 0].Count - 1)];
                else
                {
                    picbox2DArr[12, 0].Image = null;
                    picbox2DArr[12, 0].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[11, 0].Image = picboxBitmapList[11, 0][
                    (picboxBitmapList[11, 0].Count - 1)];
                    picbox2DArr[11, 0].BringToFront();
                }
            }
        }
        void picbox2DArr120_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[12, 0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[12, 0].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr120_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[12, 0].Add(bmp);
            picbox2DArr[12, 0].Image = picboxBitmapList[12, 0][(picboxBitmapList[12, 0].Count - 1)];
            picbox2DArr[12, 0].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr121_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[12, 1].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[12, 1].RemoveAt(picboxBitmapList[12, 1].Count - 1);
                if (picboxBitmapList[12, 1].Count != 0)
                    picbox2DArr[12, 1].Image = picboxBitmapList[12, 1][(picboxBitmapList[12, 1].Count - 1)];
                else
                {
                    picbox2DArr[12, 1].Image = null;
                    picbox2DArr[12, 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[11, 1].Image = picboxBitmapList[11, 1][
                    (picboxBitmapList[11, 1].Count - 1)];
                    picbox2DArr[11, 1].BringToFront();
                }
            }
        }
        void picbox2DArr121_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[12, 1].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[12, 1].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr121_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[12, 1].Add(bmp);
            picbox2DArr[12, 1].Image = picboxBitmapList[12, 1][(picboxBitmapList[12, 1].Count - 1)];
            picbox2DArr[12, 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr122_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[12, 2].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[12, 2].RemoveAt(picboxBitmapList[12, 2].Count - 1);
                if (picboxBitmapList[12, 2].Count != 0)
                    picbox2DArr[12, 2].Image = picboxBitmapList[12, 2][(picboxBitmapList[12, 2].Count - 1)];
                else
                {
                    picbox2DArr[12, 2].Image = null;
                    picbox2DArr[12, 2].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[11, 2].Image = picboxBitmapList[11, 2][
                    (picboxBitmapList[11, 2].Count - 1)];
                    picbox2DArr[11, 2].BringToFront();
                }
            }
        }
        void picbox2DArr122_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[12, 2].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[12, 2].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr122_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[12, 2].Add(bmp);
            picbox2DArr[12, 2].Image = picboxBitmapList[12, 2][(picboxBitmapList[12, 2].Count - 1)];
            picbox2DArr[12, 2].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr123_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[12, 3].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[12, 3].RemoveAt(picboxBitmapList[12, 3].Count - 1);
                if (picboxBitmapList[12, 3].Count != 0)
                    picbox2DArr[12, 3].Image = picboxBitmapList[12, 3][(picboxBitmapList[12, 3].Count - 1)];
                else
                {
                    picbox2DArr[12, 3].Image = null;
                    picbox2DArr[12, 3].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[11, 3].Image = picboxBitmapList[11, 3][
                    (picboxBitmapList[11, 3].Count - 1)];
                    picbox2DArr[11, 3].BringToFront();
                }
            }
        }
        void picbox2DArr123_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[12, 3].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[12, 3].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr123_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[12, 3].Add(bmp);
            picbox2DArr[12, 3].Image = picboxBitmapList[12, 3][(picboxBitmapList[12, 3].Count - 1)];
            picbox2DArr[12, 3].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr124_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[12, 4].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[12, 4].RemoveAt(picboxBitmapList[12, 4].Count - 1);
                if (picboxBitmapList[12, 4].Count != 0)
                    picbox2DArr[12, 4].Image = picboxBitmapList[12, 4][(picboxBitmapList[12, 4].Count - 1)];
                else
                {
                    picbox2DArr[12, 4].Image = null;
                    picbox2DArr[12, 4].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[11, 4].Image = picboxBitmapList[11, 4][
                    (picboxBitmapList[11, 4].Count - 1)];
                    picbox2DArr[11, 4].BringToFront();
                }
            }
        }
        void picbox2DArr124_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[12, 4].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[12, 4].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr124_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[12, 4].Add(bmp);
            picbox2DArr[12, 4].Image = picboxBitmapList[12, 4][(picboxBitmapList[12, 4].Count - 1)];
            picbox2DArr[12, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr125_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[12, 5].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[12, 5].RemoveAt(picboxBitmapList[12, 5].Count - 1);
                if (picboxBitmapList[12, 5].Count != 0)
                    picbox2DArr[12, 5].Image = picboxBitmapList[12, 5][(picboxBitmapList[12, 5].Count - 1)];
                else
                {
                    picbox2DArr[12, 5].Image = null;
                    picbox2DArr[12, 5].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[11, 5].Image = picboxBitmapList[11, 5][
                    (picboxBitmapList[11, 5].Count - 1)];
                    picbox2DArr[11, 5].BringToFront();
                }
            }
        }
        void picbox2DArr125_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[12, 5].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[12, 5].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr125_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[12, 5].Add(bmp);
            picbox2DArr[12, 5].Image = picboxBitmapList[12, 5][(picboxBitmapList[12, 5].Count - 1)];
            picbox2DArr[12, 5].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr126_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[12, 6].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[12, 6].RemoveAt(picboxBitmapList[12, 6].Count - 1);
                if (picboxBitmapList[12, 6].Count != 0)
                    picbox2DArr[12, 6].Image = picboxBitmapList[12, 6][(picboxBitmapList[12, 6].Count - 1)];
                else
                {
                    picbox2DArr[12, 6].Image = null;
                    picbox2DArr[12, 6].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[11, 6].Image = picboxBitmapList[11, 6][
                    (picboxBitmapList[11, 6].Count - 1)];
                    picbox2DArr[11, 6].BringToFront();
                }
            }
        }
        void picbox2DArr126_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[12, 6].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[12, 6].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr126_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[12, 6].Add(bmp);
            picbox2DArr[12, 6].Image = picboxBitmapList[12, 6][(picboxBitmapList[12, 6].Count - 1)];
            picbox2DArr[12, 6].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr130_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[13, 0].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[13, 0].RemoveAt(picboxBitmapList[13, 0].Count - 1);
                if (picboxBitmapList[13, 0].Count != 0)
                    picbox2DArr[13, 0].Image = picboxBitmapList[13, 0][(picboxBitmapList[13, 0].Count - 1)];
                else
                {
                    picbox2DArr[13, 0].Image = null;
                    picbox2DArr[13, 0].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[12, 0].Image = picboxBitmapList[12, 0][
                    (picboxBitmapList[12, 0].Count - 1)];
                    picbox2DArr[12, 0].BringToFront();
                }
            }
        }
        void picbox2DArr130_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[13, 0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[13, 0].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr130_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[13, 0].Add(bmp);
            picbox2DArr[13, 0].Image = picboxBitmapList[13, 0][(picboxBitmapList[13, 0].Count - 1)];
            picbox2DArr[13, 0].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr131_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[13, 1].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[13, 1].RemoveAt(picboxBitmapList[13, 1].Count - 1);
                if (picboxBitmapList[13, 1].Count != 0)
                    picbox2DArr[13, 1].Image = picboxBitmapList[13, 1][(picboxBitmapList[13, 1].Count - 1)];
                else
                {
                    picbox2DArr[13, 1].Image = null;
                    picbox2DArr[13, 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[12, 1].Image = picboxBitmapList[12, 1][
                    (picboxBitmapList[12, 1].Count - 1)];
                    picbox2DArr[12, 1].BringToFront();
                }
            }
        }
        void picbox2DArr131_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[13, 1].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[13, 1].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr131_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[13, 1].Add(bmp);
            picbox2DArr[13, 1].Image = picboxBitmapList[13, 1][(picboxBitmapList[13, 1].Count - 1)];
            picbox2DArr[13, 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr132_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[13, 2].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[13, 2].RemoveAt(picboxBitmapList[13, 2].Count - 1);
                if (picboxBitmapList[13, 2].Count != 0)
                    picbox2DArr[13, 2].Image = picboxBitmapList[13, 2][(picboxBitmapList[13, 2].Count - 1)];
                else
                {
                    picbox2DArr[13, 2].Image = null;
                    picbox2DArr[13, 2].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[12, 2].Image = picboxBitmapList[12, 2][
                    (picboxBitmapList[12, 2].Count - 1)];
                    picbox2DArr[12, 2].BringToFront();
                }
            }
        }
        void picbox2DArr132_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[13, 2].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[13, 2].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr132_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[13, 2].Add(bmp);
            picbox2DArr[13, 2].Image = picboxBitmapList[13, 2][(picboxBitmapList[13, 2].Count - 1)];
            picbox2DArr[13, 2].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr133_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[13, 3].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[13, 3].RemoveAt(picboxBitmapList[13, 3].Count - 1);
                if (picboxBitmapList[13, 3].Count != 0)
                    picbox2DArr[13, 3].Image = picboxBitmapList[13, 3][(picboxBitmapList[13, 3].Count - 1)];
                else
                {
                    picbox2DArr[13, 3].Image = null;
                    picbox2DArr[13, 3].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[12, 3].Image = picboxBitmapList[12, 3][
                    (picboxBitmapList[12, 3].Count - 1)];
                    picbox2DArr[12, 3].BringToFront();
                }
            }
        }
        void picbox2DArr133_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[13, 3].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[13, 3].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr133_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[13, 3].Add(bmp);
            picbox2DArr[13, 3].Image = picboxBitmapList[13, 3][(picboxBitmapList[13, 3].Count - 1)];
            picbox2DArr[13, 3].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr134_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[13, 4].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[13, 4].RemoveAt(picboxBitmapList[13, 4].Count - 1);
                if (picboxBitmapList[13, 4].Count != 0)
                    picbox2DArr[13, 4].Image = picboxBitmapList[13, 4][(picboxBitmapList[13, 4].Count - 1)];
                else
                {
                    picbox2DArr[13, 4].Image = null;
                    picbox2DArr[13, 4].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[12, 4].Image = picboxBitmapList[12, 4][
                    (picboxBitmapList[12, 4].Count - 1)];
                    picbox2DArr[12, 4].BringToFront();
                }
            }
        }
        void picbox2DArr134_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[13, 4].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[13, 4].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr134_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[13, 4].Add(bmp);
            picbox2DArr[13, 4].Image = picboxBitmapList[13, 4][(picboxBitmapList[13, 4].Count - 1)];
            picbox2DArr[13, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr135_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[13, 5].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[13, 5].RemoveAt(picboxBitmapList[13, 5].Count - 1);
                if (picboxBitmapList[13, 5].Count != 0)
                    picbox2DArr[13, 5].Image = picboxBitmapList[13, 5][(picboxBitmapList[13, 5].Count - 1)];
                else
                {
                    picbox2DArr[13, 5].Image = null;
                    picbox2DArr[13, 5].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[12, 5].Image = picboxBitmapList[12, 5][
                    (picboxBitmapList[12, 5].Count - 1)];
                    picbox2DArr[12, 5].BringToFront();
                }
            }
        }
        void picbox2DArr135_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[13, 5].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[13, 5].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr135_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[13, 5].Add(bmp);
            picbox2DArr[13, 5].Image = picboxBitmapList[13, 5][(picboxBitmapList[13, 5].Count - 1)];
            picbox2DArr[13, 5].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr136_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[13, 6].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[13, 6].RemoveAt(picboxBitmapList[13, 6].Count - 1);
                if (picboxBitmapList[13, 6].Count != 0)
                    picbox2DArr[13, 6].Image = picboxBitmapList[13, 6][(picboxBitmapList[13, 6].Count - 1)];
                else
                {
                    picbox2DArr[13, 6].Image = null;
                    picbox2DArr[13, 6].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[12, 6].Image = picboxBitmapList[12, 6][
                    (picboxBitmapList[12, 6].Count - 1)];
                    picbox2DArr[12, 6].BringToFront();
                }
            }
        }
        void picbox2DArr136_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[13, 6].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[13, 6].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr136_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[13, 6].Add(bmp);
            picbox2DArr[13, 6].Image = picboxBitmapList[13, 6][(picboxBitmapList[13, 6].Count - 1)];
            picbox2DArr[13, 6].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr140_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[14, 0].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[14, 0].RemoveAt(picboxBitmapList[14, 0].Count - 1);
                if (picboxBitmapList[14, 0].Count != 0)
                    picbox2DArr[14, 0].Image = picboxBitmapList[14, 0][(picboxBitmapList[14, 0].Count - 1)];
                else
                {
                    picbox2DArr[14, 0].Image = null;
                    picbox2DArr[14, 0].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[13, 0].Image = picboxBitmapList[13, 0][
                    (picboxBitmapList[13, 0].Count - 1)];
                    picbox2DArr[13, 0].BringToFront();
                }
            }
        }
        void picbox2DArr140_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[14, 0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[14, 0].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr140_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[14, 0].Add(bmp);
            picbox2DArr[14, 0].Image = picboxBitmapList[14, 0][(picboxBitmapList[14, 0].Count - 1)];
            picbox2DArr[14, 0].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr141_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[14, 1].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[14, 1].RemoveAt(picboxBitmapList[14, 1].Count - 1);
                if (picboxBitmapList[14, 1].Count != 0)
                    picbox2DArr[14, 1].Image = picboxBitmapList[14, 1][(picboxBitmapList[14, 1].Count - 1)];
                else
                {
                    picbox2DArr[14, 1].Image = null;
                    picbox2DArr[14, 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[13, 1].Image = picboxBitmapList[13, 1][
                    (picboxBitmapList[13, 1].Count - 1)];
                    picbox2DArr[13, 1].BringToFront();
                }
            }
        }
        void picbox2DArr141_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[14, 1].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[14, 1].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr141_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[14, 1].Add(bmp);
            picbox2DArr[14, 1].Image = picboxBitmapList[14, 1][(picboxBitmapList[14, 1].Count - 1)];
            picbox2DArr[14, 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr142_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[14, 2].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[14, 2].RemoveAt(picboxBitmapList[14, 2].Count - 1);
                if (picboxBitmapList[14, 2].Count != 0)
                    picbox2DArr[14, 2].Image = picboxBitmapList[14, 2][(picboxBitmapList[14, 2].Count - 1)];
                else
                {
                    picbox2DArr[14, 2].Image = null;
                    picbox2DArr[14, 2].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[13, 2].Image = picboxBitmapList[13, 2][
                    (picboxBitmapList[13, 2].Count - 1)];
                    picbox2DArr[13, 2].BringToFront();
                }
            }
        }
        void picbox2DArr142_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[14, 2].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[14, 2].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr142_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[14, 2].Add(bmp);
            picbox2DArr[14, 2].Image = picboxBitmapList[14, 2][(picboxBitmapList[14, 2].Count - 1)];
            picbox2DArr[14, 2].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr143_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[14, 3].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[14, 3].RemoveAt(picboxBitmapList[14, 3].Count - 1);
                if (picboxBitmapList[14, 3].Count != 0)
                    picbox2DArr[14, 3].Image = picboxBitmapList[14, 3][(picboxBitmapList[14, 3].Count - 1)];
                else
                {
                    picbox2DArr[14, 3].Image = null;
                    picbox2DArr[14, 3].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[13, 3].Image = picboxBitmapList[13, 3][
                    (picboxBitmapList[13, 3].Count - 1)];
                    picbox2DArr[13, 3].BringToFront();
                }
            }
        }
        void picbox2DArr143_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[14, 3].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[14, 3].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr143_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[14, 3].Add(bmp);
            picbox2DArr[14, 3].Image = picboxBitmapList[14, 3][(picboxBitmapList[14, 3].Count - 1)];
            picbox2DArr[14, 3].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr144_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[14, 4].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[14, 4].RemoveAt(picboxBitmapList[14, 4].Count - 1);
                if (picboxBitmapList[14, 4].Count != 0)
                    picbox2DArr[14, 4].Image = picboxBitmapList[14, 4][(picboxBitmapList[14, 4].Count - 1)];
                else
                {
                    picbox2DArr[14, 4].Image = null;
                    picbox2DArr[14, 4].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[13, 4].Image = picboxBitmapList[13, 4][
                    (picboxBitmapList[13, 4].Count - 1)];
                    picbox2DArr[13, 4].BringToFront();
                }
            }
        }
        void picbox2DArr144_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[14, 4].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[14, 4].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr144_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[14, 4].Add(bmp);
            picbox2DArr[14, 4].Image = picboxBitmapList[14, 4][(picboxBitmapList[14, 4].Count - 1)];
            picbox2DArr[14, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr145_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[14, 5].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[14, 5].RemoveAt(picboxBitmapList[14, 5].Count - 1);
                if (picboxBitmapList[14, 5].Count != 0)
                    picbox2DArr[14, 5].Image = picboxBitmapList[14, 5][(picboxBitmapList[14, 5].Count - 1)];
                else
                {
                    picbox2DArr[14, 5].Image = null;
                    picbox2DArr[14, 5].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[13, 5].Image = picboxBitmapList[13, 5][
                    (picboxBitmapList[13, 5].Count - 1)];
                    picbox2DArr[13, 5].BringToFront();
                }
            }
        }
        void picbox2DArr145_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[14, 5].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[14, 5].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr145_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[14, 5].Add(bmp);
            picbox2DArr[14, 5].Image = picboxBitmapList[14, 5][(picboxBitmapList[14, 5].Count - 1)];
            picbox2DArr[14, 5].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr146_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[14, 6].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[14, 6].RemoveAt(picboxBitmapList[14, 6].Count - 1);
                if (picboxBitmapList[14, 6].Count != 0)
                    picbox2DArr[14, 6].Image = picboxBitmapList[14, 6][(picboxBitmapList[14, 6].Count - 1)];
                else
                {
                    picbox2DArr[14, 6].Image = null;
                    picbox2DArr[14, 6].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[13, 6].Image = picboxBitmapList[13, 6][
                    (picboxBitmapList[13, 6].Count - 1)];
                    picbox2DArr[13, 6].BringToFront();
                }
            }
        }
        void picbox2DArr146_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[14, 6].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[14, 6].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr146_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[14, 6].Add(bmp);
            picbox2DArr[14, 6].Image = picboxBitmapList[14, 6][(picboxBitmapList[14, 6].Count - 1)];
            picbox2DArr[14, 6].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr150_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[15, 0].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[15, 0].RemoveAt(picboxBitmapList[15, 0].Count - 1);
                if (picboxBitmapList[15, 0].Count != 0)
                    picbox2DArr[15, 0].Image = picboxBitmapList[15, 0][(picboxBitmapList[15, 0].Count - 1)];
                else
                {
                    picbox2DArr[15, 0].Image = null;
                    picbox2DArr[15, 0].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[14, 0].Image = picboxBitmapList[14, 0][
                    (picboxBitmapList[14, 0].Count - 1)];
                    picbox2DArr[14, 0].BringToFront();
                }
            }
        }
        void picbox2DArr150_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[15, 0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[15, 0].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr150_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[15, 0].Add(bmp);
            picbox2DArr[15, 0].Image = picboxBitmapList[15, 0][(picboxBitmapList[15, 0].Count - 1)];
            picbox2DArr[15, 0].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr151_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[15, 1].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[15, 1].RemoveAt(picboxBitmapList[15, 1].Count - 1);
                if (picboxBitmapList[15, 1].Count != 0)
                    picbox2DArr[15, 1].Image = picboxBitmapList[15, 1][(picboxBitmapList[15, 1].Count - 1)];
                else
                {
                    picbox2DArr[15, 1].Image = null;
                    picbox2DArr[15, 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[14, 1].Image = picboxBitmapList[14, 1][
                    (picboxBitmapList[14, 1].Count - 1)];
                    picbox2DArr[14, 1].BringToFront();
                }
            }
        }
        void picbox2DArr151_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[15, 1].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[15, 1].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr151_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[15, 1].Add(bmp);
            picbox2DArr[15, 1].Image = picboxBitmapList[15, 1][(picboxBitmapList[15, 1].Count - 1)];
            picbox2DArr[15, 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr152_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[15, 2].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[15, 2].RemoveAt(picboxBitmapList[15, 2].Count - 1);
                if (picboxBitmapList[15, 2].Count != 0)
                    picbox2DArr[15, 2].Image = picboxBitmapList[15, 2][(picboxBitmapList[15, 2].Count - 1)];
                else
                {
                    picbox2DArr[15, 2].Image = null;
                    picbox2DArr[15, 2].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[14, 2].Image = picboxBitmapList[14, 2][
                    (picboxBitmapList[14, 2].Count - 1)];
                    picbox2DArr[14, 2].BringToFront();
                }
            }
        }
        void picbox2DArr152_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[15, 2].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[15, 2].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr152_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[15, 2].Add(bmp);
            picbox2DArr[15, 2].Image = picboxBitmapList[15, 2][(picboxBitmapList[15, 2].Count - 1)];
            picbox2DArr[15, 2].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr153_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[15, 3].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[15, 3].RemoveAt(picboxBitmapList[15, 3].Count - 1);
                if (picboxBitmapList[15, 3].Count != 0)
                    picbox2DArr[15, 3].Image = picboxBitmapList[15, 3][(picboxBitmapList[15, 3].Count - 1)];
                else
                {
                    picbox2DArr[15, 3].Image = null;
                    picbox2DArr[15, 3].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[14, 3].Image = picboxBitmapList[14, 3][
                    (picboxBitmapList[14, 3].Count - 1)];
                    picbox2DArr[14, 3].BringToFront();
                }
            }
        }
        void picbox2DArr153_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[15, 3].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[15, 3].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr153_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[15, 3].Add(bmp);
            picbox2DArr[15, 3].Image = picboxBitmapList[15, 3][(picboxBitmapList[15, 3].Count - 1)];
            picbox2DArr[15, 3].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr154_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[15, 4].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[15, 4].RemoveAt(picboxBitmapList[15, 4].Count - 1);
                if (picboxBitmapList[15, 4].Count != 0)
                    picbox2DArr[15, 4].Image = picboxBitmapList[15, 4][(picboxBitmapList[15, 4].Count - 1)];
                else
                {
                    picbox2DArr[15, 4].Image = null;
                    picbox2DArr[15, 4].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[14, 4].Image = picboxBitmapList[14, 4][
                    (picboxBitmapList[14, 4].Count - 1)];
                    picbox2DArr[14, 4].BringToFront();
                }
            }
        }
        void picbox2DArr154_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[15, 4].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[15, 4].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr154_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[15, 4].Add(bmp);
            picbox2DArr[15, 4].Image = picboxBitmapList[15, 4][(picboxBitmapList[15, 4].Count - 1)];
            picbox2DArr[15, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr155_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[15, 5].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[15, 5].RemoveAt(picboxBitmapList[15, 5].Count - 1);
                if (picboxBitmapList[15, 5].Count != 0)
                    picbox2DArr[15, 5].Image = picboxBitmapList[15, 5][(picboxBitmapList[15, 5].Count - 1)];
                else
                {
                    picbox2DArr[15, 5].Image = null;
                    picbox2DArr[15, 5].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[14, 5].Image = picboxBitmapList[14, 5][
                    (picboxBitmapList[14, 5].Count - 1)];
                    picbox2DArr[14, 5].BringToFront();
                }
            }
        }
        void picbox2DArr155_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[15, 5].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[15, 5].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr155_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[15, 5].Add(bmp);
            picbox2DArr[15, 5].Image = picboxBitmapList[15, 5][(picboxBitmapList[15, 5].Count - 1)];
            picbox2DArr[15, 5].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr156_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[15, 6].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[15, 6].RemoveAt(picboxBitmapList[15, 6].Count - 1);
                if (picboxBitmapList[15, 6].Count != 0)
                    picbox2DArr[15, 6].Image = picboxBitmapList[15, 6][(picboxBitmapList[15, 6].Count - 1)];
                else
                {
                    picbox2DArr[15, 6].Image = null;
                    picbox2DArr[15, 6].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[14, 6].Image = picboxBitmapList[14, 6][
                    (picboxBitmapList[14, 6].Count - 1)];
                    picbox2DArr[14, 6].BringToFront();
                }
            }
        }
        void picbox2DArr156_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[15, 6].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[15, 6].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr156_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[15, 6].Add(bmp);
            picbox2DArr[15, 6].Image = picboxBitmapList[15, 6][(picboxBitmapList[15, 6].Count - 1)];
            picbox2DArr[15, 6].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr160_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[16, 0].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[16, 0].RemoveAt(picboxBitmapList[16, 0].Count - 1);
                if (picboxBitmapList[16, 0].Count != 0)
                    picbox2DArr[16, 0].Image = picboxBitmapList[16, 0][(picboxBitmapList[16, 0].Count - 1)];
                else
                {
                    picbox2DArr[16, 0].Image = null;
                    picbox2DArr[16, 0].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[15, 0].Image = picboxBitmapList[15, 0][
                    (picboxBitmapList[15, 0].Count - 1)];
                    picbox2DArr[15, 0].BringToFront();
                }
            }
        }
        void picbox2DArr160_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[16, 0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[16, 0].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr160_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[16, 0].Add(bmp);
            picbox2DArr[16, 0].Image = picboxBitmapList[16, 0][(picboxBitmapList[16, 0].Count - 1)];
            picbox2DArr[16, 0].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr161_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[16, 1].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[16, 1].RemoveAt(picboxBitmapList[16, 1].Count - 1);
                if (picboxBitmapList[16, 1].Count != 0)
                    picbox2DArr[16, 1].Image = picboxBitmapList[16, 1][(picboxBitmapList[16, 1].Count - 1)];
                else
                {
                    picbox2DArr[16, 1].Image = null;
                    picbox2DArr[16, 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[15, 1].Image = picboxBitmapList[15, 1][
                    (picboxBitmapList[15, 1].Count - 1)];
                    picbox2DArr[15, 1].BringToFront();
                }
            }
        }
        void picbox2DArr161_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[16, 1].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[16, 1].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr161_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[16, 1].Add(bmp);
            picbox2DArr[16, 1].Image = picboxBitmapList[16, 1][(picboxBitmapList[16, 1].Count - 1)];
            picbox2DArr[16, 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr162_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[16, 2].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[16, 2].RemoveAt(picboxBitmapList[16, 2].Count - 1);
                if (picboxBitmapList[16, 2].Count != 0)
                    picbox2DArr[16, 2].Image = picboxBitmapList[16, 2][(picboxBitmapList[16, 2].Count - 1)];
                else
                {
                    picbox2DArr[16, 2].Image = null;
                    picbox2DArr[16, 2].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[15, 2].Image = picboxBitmapList[15, 2][
                    (picboxBitmapList[15, 2].Count - 1)];
                    picbox2DArr[15, 2].BringToFront();
                }
            }
        }
        void picbox2DArr162_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[16, 2].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[16, 2].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr162_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[16, 2].Add(bmp);
            picbox2DArr[16, 2].Image = picboxBitmapList[16, 2][(picboxBitmapList[16, 2].Count - 1)];
            picbox2DArr[16, 2].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr163_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[16, 3].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[16, 3].RemoveAt(picboxBitmapList[16, 3].Count - 1);
                if (picboxBitmapList[16, 3].Count != 0)
                    picbox2DArr[16, 3].Image = picboxBitmapList[16, 3][(picboxBitmapList[16, 3].Count - 1)];
                else
                {
                    picbox2DArr[16, 3].Image = null;
                    picbox2DArr[16, 3].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[15, 3].Image = picboxBitmapList[15, 3][
                    (picboxBitmapList[15, 3].Count - 1)];
                    picbox2DArr[15, 3].BringToFront();
                }
            }
        }
        void picbox2DArr163_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[16, 3].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[16, 3].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr163_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[16, 3].Add(bmp);
            picbox2DArr[16, 3].Image = picboxBitmapList[16, 3][(picboxBitmapList[16, 3].Count - 1)];
            picbox2DArr[16, 3].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr164_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[16, 4].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[16, 4].RemoveAt(picboxBitmapList[16, 4].Count - 1);
                if (picboxBitmapList[16, 4].Count != 0)
                    picbox2DArr[16, 4].Image = picboxBitmapList[16, 4][(picboxBitmapList[16, 4].Count - 1)];
                else
                {
                    picbox2DArr[16, 4].Image = null;
                    picbox2DArr[16, 4].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[15, 4].Image = picboxBitmapList[15, 4][
                    (picboxBitmapList[15, 4].Count - 1)];
                    picbox2DArr[15, 4].BringToFront();
                }
            }
        }
        void picbox2DArr164_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[16, 4].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[16, 4].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr164_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[16, 4].Add(bmp);
            picbox2DArr[16, 4].Image = picboxBitmapList[16, 4][(picboxBitmapList[16, 4].Count - 1)];
            picbox2DArr[16, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr165_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[16, 5].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[16, 5].RemoveAt(picboxBitmapList[16, 5].Count - 1);
                if (picboxBitmapList[16, 5].Count != 0)
                    picbox2DArr[16, 5].Image = picboxBitmapList[16, 5][(picboxBitmapList[16, 5].Count - 1)];
                else
                {
                    picbox2DArr[16, 5].Image = null;
                    picbox2DArr[16, 5].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[15, 5].Image = picboxBitmapList[15, 5][
                    (picboxBitmapList[15, 5].Count - 1)];
                    picbox2DArr[15, 5].BringToFront();
                }
            }
        }
        void picbox2DArr165_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[16, 5].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[16, 5].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr165_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[16, 5].Add(bmp);
            picbox2DArr[16, 5].Image = picboxBitmapList[16, 5][(picboxBitmapList[16, 5].Count - 1)];
            picbox2DArr[16, 5].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr166_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[16, 6].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[16, 6].RemoveAt(picboxBitmapList[16, 6].Count - 1);
                if (picboxBitmapList[16, 6].Count != 0)
                    picbox2DArr[16, 6].Image = picboxBitmapList[16, 6][(picboxBitmapList[16, 6].Count - 1)];
                else
                {
                    picbox2DArr[16, 6].Image = null;
                    picbox2DArr[16, 6].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[15, 6].Image = picboxBitmapList[15, 6][
                    (picboxBitmapList[15, 6].Count - 1)];
                    picbox2DArr[15, 6].BringToFront();
                }
            }
        }
        void picbox2DArr166_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[16, 6].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[16, 6].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr166_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[16, 6].Add(bmp);
            picbox2DArr[16, 6].Image = picboxBitmapList[16, 6][(picboxBitmapList[16, 6].Count - 1)];
            picbox2DArr[16, 6].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr170_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[17, 0].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[17, 0].RemoveAt(picboxBitmapList[17, 0].Count - 1);
                if (picboxBitmapList[17, 0].Count != 0)
                    picbox2DArr[17, 0].Image = picboxBitmapList[17, 0][(picboxBitmapList[17, 0].Count - 1)];
                else
                {
                    picbox2DArr[17, 0].Image = null;
                    picbox2DArr[17, 0].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[16, 0].Image = picboxBitmapList[16, 0][
                    (picboxBitmapList[16, 0].Count - 1)];
                    picbox2DArr[16, 0].BringToFront();
                }
            }
        }
        void picbox2DArr170_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[17, 0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[17, 0].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr170_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[17, 0].Add(bmp);
            picbox2DArr[17, 0].Image = picboxBitmapList[17, 0][(picboxBitmapList[17, 0].Count - 1)];
            picbox2DArr[17, 0].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr171_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[17, 1].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[17, 1].RemoveAt(picboxBitmapList[17, 1].Count - 1);
                if (picboxBitmapList[17, 1].Count != 0)
                    picbox2DArr[17, 1].Image = picboxBitmapList[17, 1][(picboxBitmapList[17, 1].Count - 1)];
                else
                {
                    picbox2DArr[17, 1].Image = null;
                    picbox2DArr[17, 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[16, 1].Image = picboxBitmapList[16, 1][
                    (picboxBitmapList[16, 1].Count - 1)];
                    picbox2DArr[16, 1].BringToFront();
                }
            }
        }
        void picbox2DArr171_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[17, 1].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[17, 1].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr171_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[17, 1].Add(bmp);
            picbox2DArr[17, 1].Image = picboxBitmapList[17, 1][(picboxBitmapList[17, 1].Count - 1)];
            picbox2DArr[17, 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr172_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[17, 2].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[17, 2].RemoveAt(picboxBitmapList[17, 2].Count - 1);
                if (picboxBitmapList[17, 2].Count != 0)
                    picbox2DArr[17, 2].Image = picboxBitmapList[17, 2][(picboxBitmapList[17, 2].Count - 1)];
                else
                {
                    picbox2DArr[17, 2].Image = null;
                    picbox2DArr[17, 2].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[16, 2].Image = picboxBitmapList[16, 2][
                    (picboxBitmapList[16, 2].Count - 1)];
                    picbox2DArr[16, 2].BringToFront();
                }
            }
        }
        void picbox2DArr172_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[17, 2].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[17, 2].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr172_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[17, 2].Add(bmp);
            picbox2DArr[17, 2].Image = picboxBitmapList[17, 2][(picboxBitmapList[17, 2].Count - 1)];
            picbox2DArr[17, 2].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr173_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[17, 3].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[17, 3].RemoveAt(picboxBitmapList[17, 3].Count - 1);
                if (picboxBitmapList[17, 3].Count != 0)
                    picbox2DArr[17, 3].Image = picboxBitmapList[17, 3][(picboxBitmapList[17, 3].Count - 1)];
                else
                {
                    picbox2DArr[17, 3].Image = null;
                    picbox2DArr[17, 3].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[16, 3].Image = picboxBitmapList[16, 3][
                    (picboxBitmapList[16, 3].Count - 1)];
                    picbox2DArr[16, 3].BringToFront();
                }
            }
        }
        void picbox2DArr173_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[17, 3].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[17, 3].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr173_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[17, 3].Add(bmp);
            picbox2DArr[17, 3].Image = picboxBitmapList[17, 3][(picboxBitmapList[17, 3].Count - 1)];
            picbox2DArr[17, 3].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr174_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[17, 4].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[17, 4].RemoveAt(picboxBitmapList[17, 4].Count - 1);
                if (picboxBitmapList[17, 4].Count != 0)
                    picbox2DArr[17, 4].Image = picboxBitmapList[17, 4][(picboxBitmapList[17, 4].Count - 1)];
                else
                {
                    picbox2DArr[17, 4].Image = null;
                    picbox2DArr[17, 4].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[16, 4].Image = picboxBitmapList[16, 4][
                    (picboxBitmapList[16, 4].Count - 1)];
                    picbox2DArr[16, 4].BringToFront();
                }
            }
        }
        void picbox2DArr174_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[17, 4].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[17, 4].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr174_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[17, 4].Add(bmp);
            picbox2DArr[17, 4].Image = picboxBitmapList[17, 4][(picboxBitmapList[17, 4].Count - 1)];
            picbox2DArr[17, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr175_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[17, 5].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[17, 5].RemoveAt(picboxBitmapList[17, 5].Count - 1);
                if (picboxBitmapList[17, 5].Count != 0)
                    picbox2DArr[17, 5].Image = picboxBitmapList[17, 5][(picboxBitmapList[17, 5].Count - 1)];
                else
                {
                    picbox2DArr[17, 5].Image = null;
                    picbox2DArr[17, 5].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[16, 5].Image = picboxBitmapList[16, 5][
                    (picboxBitmapList[16, 5].Count - 1)];
                    picbox2DArr[16, 5].BringToFront();
                }
            }
        }
        void picbox2DArr175_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[17, 5].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[17, 5].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr175_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[17, 5].Add(bmp);
            picbox2DArr[17, 5].Image = picboxBitmapList[17, 5][(picboxBitmapList[17, 5].Count - 1)];
            picbox2DArr[17, 5].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr176_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[17, 6].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[17, 6].RemoveAt(picboxBitmapList[17, 6].Count - 1);
                if (picboxBitmapList[17, 6].Count != 0)
                    picbox2DArr[17, 6].Image = picboxBitmapList[17, 6][(picboxBitmapList[17, 6].Count - 1)];
                else
                {
                    picbox2DArr[17, 6].Image = null;
                    picbox2DArr[17, 6].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[16, 6].Image = picboxBitmapList[16, 6][
                    (picboxBitmapList[16, 6].Count - 1)];
                    picbox2DArr[16, 6].BringToFront();
                }
            }
        }
        void picbox2DArr176_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[17, 6].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[17, 6].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr176_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[17, 6].Add(bmp);
            picbox2DArr[17, 6].Image = picboxBitmapList[17, 6][(picboxBitmapList[17, 6].Count - 1)];
            picbox2DArr[17, 6].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr180_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[18, 0].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[18, 0].RemoveAt(picboxBitmapList[18, 0].Count - 1);
                if (picboxBitmapList[18, 0].Count != 0)
                    picbox2DArr[18, 0].Image = picboxBitmapList[18, 0][(picboxBitmapList[18, 0].Count - 1)];
                else
                {
                    picbox2DArr[18, 0].Image = null;
                    picbox2DArr[18, 0].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[17, 0].Image = picboxBitmapList[17, 0][
                    (picboxBitmapList[17, 0].Count - 1)];
                    picbox2DArr[17, 0].BringToFront();
                }
            }
        }
        void picbox2DArr180_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[18, 0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[18, 0].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr180_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[18, 0].Add(bmp);
            picbox2DArr[18, 0].Image = picboxBitmapList[18, 0][(picboxBitmapList[18, 0].Count - 1)];
            picbox2DArr[18, 0].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr181_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[18, 1].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[18, 1].RemoveAt(picboxBitmapList[18, 1].Count - 1);
                if (picboxBitmapList[18, 1].Count != 0)
                    picbox2DArr[18, 1].Image = picboxBitmapList[18, 1][(picboxBitmapList[18, 1].Count - 1)];
                else
                {
                    picbox2DArr[18, 1].Image = null;
                    picbox2DArr[18, 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[17, 1].Image = picboxBitmapList[17, 1][
                    (picboxBitmapList[17, 1].Count - 1)];
                    picbox2DArr[17, 1].BringToFront();
                }
            }
        }
        void picbox2DArr181_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[18, 1].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[18, 1].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr181_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[18, 1].Add(bmp);
            picbox2DArr[18, 1].Image = picboxBitmapList[18, 1][(picboxBitmapList[18, 1].Count - 1)];
            picbox2DArr[18, 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr182_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[18, 2].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[18, 2].RemoveAt(picboxBitmapList[18, 2].Count - 1);
                if (picboxBitmapList[18, 2].Count != 0)
                    picbox2DArr[18, 2].Image = picboxBitmapList[18, 2][(picboxBitmapList[18, 2].Count - 1)];
                else
                {
                    picbox2DArr[18, 2].Image = null;
                    picbox2DArr[18, 2].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[17, 2].Image = picboxBitmapList[17, 2][
                    (picboxBitmapList[17, 2].Count - 1)];
                    picbox2DArr[17, 2].BringToFront();
                }
            }
        }
        void picbox2DArr182_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[18, 2].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[18, 2].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr182_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[18, 2].Add(bmp);
            picbox2DArr[18, 2].Image = picboxBitmapList[18, 2][(picboxBitmapList[18, 2].Count - 1)];
            picbox2DArr[18, 2].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr183_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[18, 3].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[18, 3].RemoveAt(picboxBitmapList[18, 3].Count - 1);
                if (picboxBitmapList[18, 3].Count != 0)
                    picbox2DArr[18, 3].Image = picboxBitmapList[18, 3][(picboxBitmapList[18, 3].Count - 1)];
                else
                {
                    picbox2DArr[18, 3].Image = null;
                    picbox2DArr[18, 3].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[17, 3].Image = picboxBitmapList[17, 3][
                    (picboxBitmapList[17, 3].Count - 1)];
                    picbox2DArr[17, 3].BringToFront();
                }
            }
        }
        void picbox2DArr183_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[18, 3].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[18, 3].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr183_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[18, 3].Add(bmp);
            picbox2DArr[18, 3].Image = picboxBitmapList[18, 3][(picboxBitmapList[18, 3].Count - 1)];
            picbox2DArr[18, 3].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr184_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[18, 4].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[18, 4].RemoveAt(picboxBitmapList[18, 4].Count - 1);
                if (picboxBitmapList[18, 4].Count != 0)
                    picbox2DArr[18, 4].Image = picboxBitmapList[18, 4][(picboxBitmapList[18, 4].Count - 1)];
                else
                {
                    picbox2DArr[18, 4].Image = null;
                    picbox2DArr[18, 4].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[17, 4].Image = picboxBitmapList[17, 4][
                    (picboxBitmapList[17, 4].Count - 1)];
                    picbox2DArr[17, 4].BringToFront();
                }
            }
        }
        void picbox2DArr184_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[18, 4].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[18, 4].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr184_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[18, 4].Add(bmp);
            picbox2DArr[18, 4].Image = picboxBitmapList[18, 4][(picboxBitmapList[18, 4].Count - 1)];
            picbox2DArr[18, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr185_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[18, 5].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[18, 5].RemoveAt(picboxBitmapList[18, 5].Count - 1);
                if (picboxBitmapList[18, 5].Count != 0)
                    picbox2DArr[18, 5].Image = picboxBitmapList[18, 5][(picboxBitmapList[18, 5].Count - 1)];
                else
                {
                    picbox2DArr[18, 5].Image = null;
                    picbox2DArr[18, 5].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[17, 5].Image = picboxBitmapList[17, 5][
                    (picboxBitmapList[17, 5].Count - 1)];
                    picbox2DArr[17, 5].BringToFront();
                }
            }
        }
        void picbox2DArr185_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[18, 5].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[18, 5].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr185_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[18, 5].Add(bmp);
            picbox2DArr[18, 5].Image = picboxBitmapList[18, 5][(picboxBitmapList[18, 5].Count - 1)];
            picbox2DArr[18, 5].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr186_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[18, 6].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[18, 6].RemoveAt(picboxBitmapList[18, 6].Count - 1);
                if (picboxBitmapList[18, 6].Count != 0)
                    picbox2DArr[18, 6].Image = picboxBitmapList[18, 6][(picboxBitmapList[18, 6].Count - 1)];
                else
                {
                    picbox2DArr[18, 6].Image = null;
                    picbox2DArr[18, 6].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[17, 6].Image = picboxBitmapList[17, 6][
                    (picboxBitmapList[17, 6].Count - 1)];
                    picbox2DArr[17, 6].BringToFront();
                }
            }
        }
        void picbox2DArr186_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[18, 6].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[18, 6].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr186_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[18, 6].Add(bmp);
            picbox2DArr[18, 6].Image = picboxBitmapList[18, 6][(picboxBitmapList[18, 6].Count - 1)];
            picbox2DArr[18, 6].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr190_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[19, 0].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[19, 0].RemoveAt(picboxBitmapList[19, 0].Count - 1);
                if (picboxBitmapList[19, 0].Count != 0)
                    picbox2DArr[19, 0].Image = picboxBitmapList[19, 0][(picboxBitmapList[19, 0].Count - 1)];
                else
                {
                    picbox2DArr[19, 0].Image = null;
                    picbox2DArr[19, 0].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[18, 0].Image = picboxBitmapList[18, 0][
                    (picboxBitmapList[18, 0].Count - 1)];
                    picbox2DArr[18, 0].BringToFront();
                }
            }
        }
        void picbox2DArr190_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[19, 0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[19, 0].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr190_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[19, 0].Add(bmp);
            picbox2DArr[19, 0].Image = picboxBitmapList[19, 0][(picboxBitmapList[19, 0].Count - 1)];
            picbox2DArr[19, 0].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr191_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[19, 1].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[19, 1].RemoveAt(picboxBitmapList[19, 1].Count - 1);
                if (picboxBitmapList[19, 1].Count != 0)
                    picbox2DArr[19, 1].Image = picboxBitmapList[19, 1][(picboxBitmapList[19, 1].Count - 1)];
                else
                {
                    picbox2DArr[19, 1].Image = null;
                    picbox2DArr[19, 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[18, 1].Image = picboxBitmapList[18, 1][
                    (picboxBitmapList[18, 1].Count - 1)];
                    picbox2DArr[18, 1].BringToFront();
                }
            }
        }
        void picbox2DArr191_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[19, 1].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[19, 1].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr191_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[19, 1].Add(bmp);
            picbox2DArr[19, 1].Image = picboxBitmapList[19, 1][(picboxBitmapList[19, 1].Count - 1)];
            picbox2DArr[19, 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr192_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[19, 2].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[19, 2].RemoveAt(picboxBitmapList[19, 2].Count - 1);
                if (picboxBitmapList[19, 2].Count != 0)
                    picbox2DArr[19, 2].Image = picboxBitmapList[19, 2][(picboxBitmapList[19, 2].Count - 1)];
                else
                {
                    picbox2DArr[19, 2].Image = null;
                    picbox2DArr[19, 2].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[18, 2].Image = picboxBitmapList[18, 2][
                    (picboxBitmapList[18, 2].Count - 1)];
                    picbox2DArr[18, 2].BringToFront();
                }
            }
        }
        void picbox2DArr192_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[19, 2].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[19, 2].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr192_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[19, 2].Add(bmp);
            picbox2DArr[19, 2].Image = picboxBitmapList[19, 2][(picboxBitmapList[19, 2].Count - 1)];
            picbox2DArr[19, 2].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr193_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[19, 3].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[19, 3].RemoveAt(picboxBitmapList[19, 3].Count - 1);
                if (picboxBitmapList[19, 3].Count != 0)
                    picbox2DArr[19, 3].Image = picboxBitmapList[19, 3][(picboxBitmapList[19, 3].Count - 1)];
                else
                {
                    picbox2DArr[19, 3].Image = null;
                    picbox2DArr[19, 3].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[18, 3].Image = picboxBitmapList[18, 3][
                    (picboxBitmapList[18, 3].Count - 1)];
                    picbox2DArr[18, 3].BringToFront();
                }
            }
        }
        void picbox2DArr193_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[19, 3].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[19, 3].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr193_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[19, 3].Add(bmp);
            picbox2DArr[19, 3].Image = picboxBitmapList[19, 3][(picboxBitmapList[19, 3].Count - 1)];
            picbox2DArr[19, 3].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr194_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[19, 4].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[19, 4].RemoveAt(picboxBitmapList[19, 4].Count - 1);
                if (picboxBitmapList[19, 4].Count != 0)
                    picbox2DArr[19, 4].Image = picboxBitmapList[19, 4][(picboxBitmapList[19, 4].Count - 1)];
                else
                {
                    picbox2DArr[19, 4].Image = null;
                    picbox2DArr[19, 4].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[18, 4].Image = picboxBitmapList[18, 4][
                    (picboxBitmapList[18, 4].Count - 1)];
                    picbox2DArr[18, 4].BringToFront();
                }
            }
        }
        void picbox2DArr194_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[19, 4].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[19, 4].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr194_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[19, 4].Add(bmp);
            picbox2DArr[19, 4].Image = picboxBitmapList[19, 4][(picboxBitmapList[19, 4].Count - 1)];
            picbox2DArr[19, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr195_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[19, 5].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[19, 5].RemoveAt(picboxBitmapList[19, 5].Count - 1);
                if (picboxBitmapList[19, 5].Count != 0)
                    picbox2DArr[19, 5].Image = picboxBitmapList[19, 5][(picboxBitmapList[19, 5].Count - 1)];
                else
                {
                    picbox2DArr[19, 5].Image = null;
                    picbox2DArr[19, 5].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[18, 5].Image = picboxBitmapList[18, 5][
                    (picboxBitmapList[18, 5].Count - 1)];
                    picbox2DArr[18, 5].BringToFront();
                }
            }
        }
        void picbox2DArr195_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[19, 5].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[19, 5].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr195_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[19, 5].Add(bmp);
            picbox2DArr[19, 5].Image = picboxBitmapList[19, 5][(picboxBitmapList[19, 5].Count - 1)];
            picbox2DArr[19, 5].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr196_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[19, 6].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[19, 6].RemoveAt(picboxBitmapList[19, 6].Count - 1);
                if (picboxBitmapList[19, 6].Count != 0)
                    picbox2DArr[19, 6].Image = picboxBitmapList[19, 6][(picboxBitmapList[19, 6].Count - 1)];
                else
                {
                    picbox2DArr[19, 6].Image = null;
                    picbox2DArr[19, 6].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    picbox2DArr[18, 6].Image = picboxBitmapList[18, 6][
                    (picboxBitmapList[18, 6].Count - 1)];
                    picbox2DArr[18, 6].BringToFront();
                }
            }
        }
        void picbox2DArr196_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[19, 6].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[19, 6].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr196_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[19, 6].Add(bmp);
            picbox2DArr[19, 6].Image = picboxBitmapList[19, 6][(picboxBitmapList[19, 6].Count - 1)];
            picbox2DArr[19, 6].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }



        private void picbox2DArr200_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[20, 0].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[20, 0].RemoveAt(picboxBitmapList[20, 0].Count - 1);
                if (picboxBitmapList[20, 0].Count != 0)
                    picbox2DArr[20, 0].Image = picboxBitmapList[20, 0][(picboxBitmapList[20, 0].Count - 1)];
                else
                {
                    picbox2DArr[20, 0].Image = null;
                    picbox2DArr[20, 0].BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
            }
        }
        void picbox2DArr200_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[20, 0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[20, 0].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr200_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[20, 0].Add(bmp);
            picbox2DArr[20, 0].Image = picboxBitmapList[20, 0][(picboxBitmapList[20, 0].Count - 1)];
            picbox2DArr[20, 0].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr201_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[20, 1].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[20, 1].RemoveAt(picboxBitmapList[20, 1].Count - 1);
                if (picboxBitmapList[20, 1].Count != 0)
                    picbox2DArr[20, 1].Image = picboxBitmapList[20, 1][(picboxBitmapList[20, 1].Count - 1)];
                else
                {
                    picbox2DArr[20, 1].Image = null;
                    picbox2DArr[20, 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
            }
        }
        void picbox2DArr201_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[20, 1].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[20, 1].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr201_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[20, 1].Add(bmp);
            picbox2DArr[20, 1].Image = picboxBitmapList[20, 1][(picboxBitmapList[20, 1].Count - 1)];
            picbox2DArr[20, 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr202_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[20, 2].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[20, 2].RemoveAt(picboxBitmapList[20, 2].Count - 1);
                if (picboxBitmapList[20, 2].Count != 0)
                    picbox2DArr[20, 2].Image = picboxBitmapList[20, 2][(picboxBitmapList[20, 2].Count - 1)];
                else
                {
                    picbox2DArr[20, 2].Image = null;
                    picbox2DArr[20, 2].BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
            }
        }
        void picbox2DArr202_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[20, 2].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[20, 2].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr202_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[20, 2].Add(bmp);
            picbox2DArr[20, 2].Image = picboxBitmapList[20, 2][(picboxBitmapList[20, 2].Count - 1)];
            picbox2DArr[20, 2].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr203_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[20, 3].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[20, 3].RemoveAt(picboxBitmapList[20, 3].Count - 1);
                if (picboxBitmapList[20, 3].Count != 0)
                    picbox2DArr[20, 3].Image = picboxBitmapList[20, 3][(picboxBitmapList[20, 3].Count - 1)];
                else
                {
                    picbox2DArr[20, 3].Image = null;
                    picbox2DArr[20, 3].BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
            }
        }
        void picbox2DArr203_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[20, 3].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[20, 3].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr203_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[20, 3].Add(bmp);
            picbox2DArr[20, 3].Image = picboxBitmapList[20, 3][(picboxBitmapList[20, 3].Count - 1)];
            picbox2DArr[20, 3].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr204_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[20, 4].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[20, 4].RemoveAt(picboxBitmapList[20, 4].Count - 1);
                if (picboxBitmapList[20, 4].Count != 0)
                    picbox2DArr[20, 4].Image = picboxBitmapList[20, 4][(picboxBitmapList[20, 4].Count - 1)];
                else
                {
                    picbox2DArr[20, 4].Image = null;
                    picbox2DArr[20, 4].BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
            }
        }
        void picbox2DArr204_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[20, 4].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[20, 4].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr204_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[20, 4].Add(bmp);
            picbox2DArr[20, 4].Image = picboxBitmapList[20, 4][(picboxBitmapList[20, 4].Count - 1)];
            picbox2DArr[20, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr205_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[20, 5].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[20, 5].RemoveAt(picboxBitmapList[20, 5].Count - 1);
                if (picboxBitmapList[20, 5].Count != 0)
                    picbox2DArr[20, 5].Image = picboxBitmapList[20, 5][(picboxBitmapList[20, 5].Count - 1)];
                else
                {
                    picbox2DArr[20, 5].Image = null;
                    picbox2DArr[20, 5].BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
            }
        }
        void picbox2DArr205_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[20, 5].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[20, 5].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr205_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[20, 5].Add(bmp);
            picbox2DArr[20, 5].Image = picboxBitmapList[20, 5][(picboxBitmapList[20, 5].Count - 1)];
            picbox2DArr[20, 5].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr206_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[20, 6].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[20, 6].RemoveAt(picboxBitmapList[20, 6].Count - 1);
                if (picboxBitmapList[20, 6].Count != 0)
                    picbox2DArr[20, 6].Image = picboxBitmapList[20, 6][(picboxBitmapList[20, 6].Count - 1)];
                else
                {
                    picbox2DArr[20, 6].Image = null;
                    picbox2DArr[20, 6].BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
            }
        }
        void picbox2DArr206_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[20, 6].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[20, 6].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr206_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[20, 6].Add(bmp);
            picbox2DArr[20, 6].Image = picboxBitmapList[20, 6][(picboxBitmapList[20, 6].Count - 1)];
            picbox2DArr[20, 6].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr210_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[21, 0].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[21, 0].RemoveAt(picboxBitmapList[21, 0].Count - 1);
                if (picboxBitmapList[21, 0].Count != 0)
                    picbox2DArr[21, 0].Image = picboxBitmapList[21, 0][(picboxBitmapList[21, 0].Count - 1)];
                else
                {
                    picbox2DArr[21, 0].Image = null;
                    picbox2DArr[21, 0].BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
                picboxBitmapList[21, 6].RemoveAt((picboxBitmapList[21, 6].Count - 1));
            }
        }
        void picbox2DArr210_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[21, 0].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[21, 0].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr210_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[21, 0].Add(bmp);
            picbox2DArr[21, 0].Image = picboxBitmapList[21, 0][(picboxBitmapList[21, 0].Count - 1)];
            picbox2DArr[21, 0].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr211_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[21, 1].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[21, 1].RemoveAt(picboxBitmapList[21, 1].Count - 1);
                if (picboxBitmapList[21, 1].Count != 0)
                    picbox2DArr[21, 1].Image = picboxBitmapList[21, 1][(picboxBitmapList[21, 1].Count - 1)];
                else
                {
                    picbox2DArr[21, 1].Image = null;
                    picbox2DArr[21, 1].BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
                picboxBitmapList[21, 6].RemoveAt((picboxBitmapList[21, 6].Count - 1));
            }
        }
        void picbox2DArr211_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[21, 1].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[21, 1].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr211_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[21, 1].Add(bmp);
            picbox2DArr[21, 1].Image = picboxBitmapList[21, 1][(picboxBitmapList[21, 1].Count - 1)];
            picbox2DArr[21, 1].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr212_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[21, 2].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[21, 2].RemoveAt(picboxBitmapList[21, 2].Count - 1);
                if (picboxBitmapList[21, 2].Count != 0)
                    picbox2DArr[21, 2].Image = picboxBitmapList[21, 2][(picboxBitmapList[21, 2].Count - 1)];
                else
                {
                    picbox2DArr[21, 2].Image = null;
                    picbox2DArr[21, 2].BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
                picboxBitmapList[21, 6].RemoveAt((picboxBitmapList[21, 6].Count - 1));
            }
        }
        void picbox2DArr212_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[21, 2].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[21, 2].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr212_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[21, 2].Add(bmp);
            picbox2DArr[21, 2].Image = picboxBitmapList[21, 2][(picboxBitmapList[21, 2].Count - 1)];
            picbox2DArr[21, 2].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr213_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[21, 3].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[21, 3].RemoveAt(picboxBitmapList[21, 3].Count - 1);
                if (picboxBitmapList[21, 3].Count != 0)
                    picbox2DArr[21, 3].Image = picboxBitmapList[21, 3][(picboxBitmapList[21, 3].Count - 1)];
                else
                {
                    picbox2DArr[21, 3].Image = null;
                    picbox2DArr[21, 3].BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
                picboxBitmapList[21, 6].RemoveAt((picboxBitmapList[21, 6].Count - 1));
            }
        }
        void picbox2DArr213_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[21, 3].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[21, 3].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr213_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[21, 3].Add(bmp);
            picbox2DArr[21, 3].Image = picboxBitmapList[21, 3][(picboxBitmapList[21, 3].Count - 1)];
            picbox2DArr[21, 3].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr214_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[21, 4].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[21, 4].RemoveAt(picboxBitmapList[21, 4].Count - 1);
                if (picboxBitmapList[21, 4].Count != 0)
                    picbox2DArr[21, 4].Image = picboxBitmapList[21, 4][(picboxBitmapList[21, 4].Count - 1)];
                else
                {
                    picbox2DArr[21, 4].Image = null;
                    picbox2DArr[21, 4].BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
                picboxBitmapList[21, 6].RemoveAt((picboxBitmapList[21, 6].Count - 1));
            }
        }
        void picbox2DArr214_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[21, 4].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[21, 4].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr214_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[21, 4].Add(bmp);
            picbox2DArr[21, 4].Image = picboxBitmapList[21, 4][(picboxBitmapList[21, 4].Count - 1)];
            picbox2DArr[21, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr215_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[21, 5].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[21, 5].RemoveAt(picboxBitmapList[21, 5].Count - 1);
                if (picboxBitmapList[21, 5].Count != 0)
                    picbox2DArr[21, 5].Image = picboxBitmapList[21, 5][(picboxBitmapList[21, 5].Count - 1)];
                else
                {
                    picbox2DArr[21, 5].Image = null;
                    picbox2DArr[21, 5].BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
            }
        }
        void picbox2DArr215_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[21, 5].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[21, 5].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr215_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[21, 5].Add(bmp);
            picbox2DArr[21, 5].Image = picboxBitmapList[21, 5][(picboxBitmapList[21, 5].Count - 1)];
            picbox2DArr[21, 5].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void picbox2DArr216_MouseDown(object sender, MouseEventArgs e)
        {
            var img = picbox2DArr[21, 6].Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[21, 6].RemoveAt(picboxBitmapList[21, 6].Count - 1);
                if (picboxBitmapList[21, 6].Count != 0)
                    picbox2DArr[21, 6].Image = picboxBitmapList[21, 6][(picboxBitmapList[21, 6].Count - 1)];
                else
                {
                    picbox2DArr[21, 6].Image = null;
                    picbox2DArr[21, 6].BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
            }
        }
        void picbox2DArr216_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                picbox2DArr[21, 6].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                picbox2DArr[21, 6].BringToFront();
                e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr216_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            picboxBitmapList[21, 6].Add(bmp);
            picbox2DArr[21, 6].Image = picboxBitmapList[21, 6][(picboxBitmapList[21, 6].Count - 1)];
            picbox2DArr[21, 6].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }







       













    }
}
