using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Redo
{
    public partial class Form1 : Form
    {
        /**
         *  Below for HowManyPlayerDialog();
         */
        public int howManyP = 0;
        public Form howManyPDialog;
        private System.Windows.Forms.ComboBox howManyPComboBox2;
        private System.Windows.Forms.Label howManyPLabel50;
        private System.Windows.Forms.Button howManyPButton1;
        private System.Windows.Forms.Button howManyPButton2;

        /**
         *  Below for Player's Name 
         */
        public Form PlayerName = new Form();
        private System.Windows.Forms.Label labelPN_A;
        private System.Windows.Forms.TextBox textBoxPN_A;
        private System.Windows.Forms.Label labelPN_B;
        private System.Windows.Forms.Label labelPN_C;
        private System.Windows.Forms.Label labelPN_D;
        private System.Windows.Forms.TextBox textBoxPN_B;
        private System.Windows.Forms.TextBox textBoxPN_C;
        private System.Windows.Forms.TextBox textBoxPN_D;
        private System.Windows.Forms.Label labelPN_mark;
        private System.Windows.Forms.Button buttonPN_OK;
        private System.Windows.Forms.Button buttonPN_Cancel;
        private string p1_name = "";
        private string p2_name = "";
        private string p3_name = "";
        private string p4_name = "";

        //  picture file named as 101, 102.. meaning card 10, 1st and 2nd color.
        public int[] picName = new int[54];

        //Every pictureBox(card Position) has a bitmap array
        //public List<Bitmap>[][] picboxBitmapList = new List<Bitmap>[5][];
        public List<Bitmap>[,] picboxBitmapList = new List<Bitmap>[5,10];
        public PictureBox[,] picbox2DArr = new PictureBox[5, 10];

        //Put picbox show 12 into array.
        public PictureBox[] picboxShow12 = new PictureBox[12];
        
        //Set the Animation Time
        public int AnimationTime = 0;

        public int shuffleTime = 0;

        public bool doNotShuffleAgain = false;

        public Form shuffleAgainForm;// = new Form();

        public Form askShuffleTime;// = new Form();

        public Form whichPlayer1st;
        public int playing = 0;

        //Player's scores.
        public int p1s = 0, p2s = 0, p3s = 0, p4s = 0;

        public bool dropped1 = false, dropped2 = false, dropped3 = false, dropped4 = false;

        public Form1()
        {
            //Welcome wel = new Welcome();
            
            ////Dialog for how many players.
            //HowManyPlayerDialog();

            ////Dialog for enter players' names.
            //EnterPlayersName();
            //labelWelcome = new System.Windows.Forms.Label();

            
           

            //The card Board.
            InitializeComponent();

            this.Size = new Size(1402, 617);

            //richTextBox1.SelectAll();
            //richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            //richTextBox1.DeselectAll();
            

            picbox050_TO_picbox2DArr();
            

            //default player name is empty.
            labelP1.Text = "";
            labelP2.Text = "";
            labelP3.Text = "";
            labelP4.Text = "";
            
            
            //initialize all label number to 0;
            labelP1S.Text = "0";
            labelP2S.Text = "0";
            labelP3S.Text = "0";
            labelP4S.Text = "0";

            label021.Text = "0";
            label121.Text = "0";
            label221.Text = "0";
            label321.Text = "0";

            label0.Text = "0";
            label1.Text = "0";
            label2.Text = "0";
            label3.Text = "0";

            labelCenter.Text = "0";
            


            //Create an int array to match the names of picture file.
            int iterator = 10;
            for (int i = 0; i < picName.Length; i++)
            {
                picName[i] = iterator + i % 4 + 1;
                iterator = (i % 4 == 3) ? iterator + 10 : iterator;
                
                //picName = 11, 12, 13, 14, 21, 22,....133, 134, 141, 142
                //Console.WriteLine("Pic: {0}.", picName[i]);
            }


            for (int i = 0; i <= 4; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    
                    picboxBitmapList[i,j] = new List<Bitmap>();

                }
            }

            

            //Debugging
            //Console.WriteLine("l : {0}, {1}", picboxBitmapList.Length, picboxBitmapList.GetLength(1));

            //picboxBitmapList[4][4].Add
            //pictureBoxCenter.Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject((picName[0]).ToString()) as Image);
            

            /**
             * Regarding the picturebox Drag Drop Events
             */
            for (int i = 0; i <= 4; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    picbox2DArr[i, j].AllowDrop = true;
                    //set the size mode
                    picbox2DArr[i, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                }   
            }

            MouseDown_Drag_Drop();

            

            //put picbox show 12 into array
            picboxShow12[0] = pictureBoxShow120;
            picboxShow12[1] = pictureBoxShow121;
            picboxShow12[2] = pictureBoxShow122;
            picboxShow12[3] = pictureBoxShow123;
            picboxShow12[4] = pictureBoxShow124;
            picboxShow12[5] = pictureBoxShow125;
            picboxShow12[6] = pictureBoxShow126;
            picboxShow12[7] = pictureBoxShow127;
            picboxShow12[8] = pictureBoxShow128;
            picboxShow12[9] = pictureBoxShow129;
            picboxShow12[10] = pictureBoxShow1210;
            picboxShow12[11] = pictureBoxShow1211;

            for (int j = 0; j <= 11; j++)
            {
                //set the size mode
                picboxShow12[j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            }   

            /**
             *Hove and Leave
             */
            //for (int i = 0; i <= 3; i++)
            //{
            //    for (int j = 5; j <= 8; j++)
            //    {
            //        this.pictureBox140.MouseLeave += new System.EventHandler(this.pictureBox140_MouseLeave);
            //        this.pictureBox140.MouseHover += new System.EventHandler(this.pictureBox140_MouseHover);
            //        picbox2DArr[i, j] += new System.EventHandler(this.pictureBox140_MouseLeave);
            //    }
            //}

            picboxHove_leave();

            buttonStart.Visible = false;

            


        }//form1()

        private void drawLine()//PaintEventArgs e)
        {
           

    //// Create pen.
    //Pen blackPen = new Pen(Color.Yellow, 3);

    //// Create points that define line.
    //Point point1 = new Point(508, 244);
    //Point point2 = new Point(508, 846);

    //// Draw line to screen.
    //.Graphics.DrawLine(blackPen, point1, point2);


            //System.Drawing.Pen myPen;
            //myPen = new System.Drawing.Pen(System.Drawing.Color.Red, 5);

            //System.Drawing.Graphics formGraphics = this.CreateGraphics();

            //formGraphics.DrawLine(myPen, 508, 244, 508, 846);
            //myPen.Dispose();
            //formGraphics.Dispose();



        }

       



        private void picbox050_TO_picbox2DArr()
        {
            /*
             * Make reference to all the pictureBoxs.
             * 
             * row 0 ~ 3: player ID;
             *      col 0 ~ 4: 5 cards;
             *      col 5 ~ 8: 4 cards;
             *      col 9    : 21 cards;
             *      
             * row 4    : central area position(including main deck & A's position) and topmost 5;
             *      col 0 ~ 3: pictureBox 0 ~ pictureBox 3 which is marked "A" position.
             *      col 4    : pictureBoxCenter (Main Deck);
             *      col 5 ~ 9: Topmost 5;
             * 
             */
            picbox2DArr[0, 0] = pictureBox050;
            picbox2DArr[0, 1] = pictureBox051;
            picbox2DArr[0, 2] = pictureBox052;
            picbox2DArr[0, 3] = pictureBox053;
            picbox2DArr[0, 4] = pictureBox054;
            picbox2DArr[0, 5] = pictureBox040;
            picbox2DArr[0, 6] = pictureBox041;
            picbox2DArr[0, 7] = pictureBox042;
            picbox2DArr[0, 8] = pictureBox043;
            picbox2DArr[0, 9] = pictureBox021;

            picbox2DArr[1, 0] = pictureBox150;
            picbox2DArr[1, 1] = pictureBox151;
            picbox2DArr[1, 2] = pictureBox152;
            picbox2DArr[1, 3] = pictureBox153;
            picbox2DArr[1, 4] = pictureBox154;
            picbox2DArr[1, 5] = pictureBox140;
            picbox2DArr[1, 6] = pictureBox141;
            picbox2DArr[1, 7] = pictureBox142;
            picbox2DArr[1, 8] = pictureBox143;
            picbox2DArr[1, 9] = pictureBox121;

            picbox2DArr[2, 0] = pictureBox250;
            picbox2DArr[2, 1] = pictureBox251;
            picbox2DArr[2, 2] = pictureBox252;
            picbox2DArr[2, 3] = pictureBox253;
            picbox2DArr[2, 4] = pictureBox254;
            picbox2DArr[2, 5] = pictureBox240;
            picbox2DArr[2, 6] = pictureBox241;
            picbox2DArr[2, 7] = pictureBox242;
            picbox2DArr[2, 8] = pictureBox243;
            picbox2DArr[2, 9] = pictureBox221;

            picbox2DArr[3, 0] = pictureBox350;
            picbox2DArr[3, 1] = pictureBox351;
            picbox2DArr[3, 2] = pictureBox352;
            picbox2DArr[3, 3] = pictureBox353;
            picbox2DArr[3, 4] = pictureBox354;
            picbox2DArr[3, 5] = pictureBox340;
            picbox2DArr[3, 6] = pictureBox341;
            picbox2DArr[3, 7] = pictureBox342;
            picbox2DArr[3, 8] = pictureBox343;
            picbox2DArr[3, 9] = pictureBox321;

            picbox2DArr[4, 0] = pictureBox0;
            picbox2DArr[4, 1] = pictureBox1;
            picbox2DArr[4, 2] = pictureBox2;
            picbox2DArr[4, 3] = pictureBox3;
            picbox2DArr[4, 4] = pictureBoxCenter;

            //for the Topmost 5
            picbox2DArr[4, 5] = pictureBoxT0;
            picbox2DArr[4, 6] = pictureBoxT1;
            picbox2DArr[4, 7] = pictureBoxT2;
            picbox2DArr[4, 8] = pictureBoxT3;
            picbox2DArr[4, 9] = pictureBoxT4;
        }


        private void MouseDown_Drag_Drop()
        {
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

            picbox2DArr[0, 7].MouseDown += picbox2DArr07_MouseDown;
            picbox2DArr[0, 7].DragEnter += picbox2DArr07_DragEnter;
            picbox2DArr[0, 7].DragDrop += picbox2DArr07_DragDrop;

            picbox2DArr[0, 8].MouseDown += picbox2DArr08_MouseDown;
            picbox2DArr[0, 8].DragEnter += picbox2DArr08_DragEnter;
            picbox2DArr[0, 8].DragDrop += picbox2DArr08_DragDrop;

            picbox2DArr[0, 9].MouseDown += picbox2DArr09_MouseDown;
            //picbox2DArr[0, 9].DragEnter += picbox2DArr09_DragEnter;
            //picbox2DArr[0, 9].DragDrop += picbox2DArr09_DragDrop;

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

            picbox2DArr[1, 7].MouseDown += picbox2DArr17_MouseDown;
            picbox2DArr[1, 7].DragEnter += picbox2DArr17_DragEnter;
            picbox2DArr[1, 7].DragDrop += picbox2DArr17_DragDrop;

            picbox2DArr[1, 8].MouseDown += picbox2DArr18_MouseDown;
            picbox2DArr[1, 8].DragEnter += picbox2DArr18_DragEnter;
            picbox2DArr[1, 8].DragDrop += picbox2DArr18_DragDrop;

            picbox2DArr[1, 9].MouseDown += picbox2DArr19_MouseDown;
            //picbox2DArr[1, 9].DragEnter += picbox2DArr19_DragEnter;
            //picbox2DArr[1, 9].DragDrop += picbox2DArr19_DragDrop;

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

            picbox2DArr[2, 7].MouseDown += picbox2DArr27_MouseDown;
            picbox2DArr[2, 7].DragEnter += picbox2DArr27_DragEnter;
            picbox2DArr[2, 7].DragDrop += picbox2DArr27_DragDrop;

            picbox2DArr[2, 8].MouseDown += picbox2DArr28_MouseDown;
            picbox2DArr[2, 8].DragEnter += picbox2DArr28_DragEnter;
            picbox2DArr[2, 8].DragDrop += picbox2DArr28_DragDrop;

            picbox2DArr[2, 9].MouseDown += picbox2DArr29_MouseDown;
            //picbox2DArr[2, 9].DragEnter += picbox2DArr29_DragEnter;
            //picbox2DArr[2, 9].DragDrop += picbox2DArr29_DragDrop;

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

            picbox2DArr[3, 7].MouseDown += picbox2DArr37_MouseDown;
            picbox2DArr[3, 7].DragEnter += picbox2DArr37_DragEnter;
            picbox2DArr[3, 7].DragDrop += picbox2DArr37_DragDrop;

            picbox2DArr[3, 8].MouseDown += picbox2DArr38_MouseDown;
            picbox2DArr[3, 8].DragEnter += picbox2DArr38_DragEnter;
            picbox2DArr[3, 8].DragDrop += picbox2DArr38_DragDrop;

            picbox2DArr[3, 9].MouseDown += picbox2DArr39_MouseDown;
            //picbox2DArr[3, 9].DragEnter += picbox2DArr39_DragEnter;
            //picbox2DArr[3, 9].DragDrop += picbox2DArr39_DragDrop;

            //picbox2DArr[4, 0].MouseDown += picbox2DArr40_MouseDown;
            picbox2DArr[4, 0].DragEnter += picbox2DArr40_DragEnter;
            picbox2DArr[4, 0].DragDrop += picbox2DArr40_DragDrop;

            //picbox2DArr[4, 1].MouseDown += picbox2DArr41_MouseDown;
            picbox2DArr[4, 1].DragEnter += picbox2DArr41_DragEnter;
            picbox2DArr[4, 1].DragDrop += picbox2DArr41_DragDrop;

            //picbox2DArr[4, 2].MouseDown += picbox2DArr42_MouseDown;
            picbox2DArr[4, 2].DragEnter += picbox2DArr42_DragEnter;
            picbox2DArr[4, 2].DragDrop += picbox2DArr42_DragDrop;

            //picbox2DArr[4, 3].MouseDown += picbox2DArr43_MouseDown;
            picbox2DArr[4, 3].DragEnter += picbox2DArr43_DragEnter;
            picbox2DArr[4, 3].DragDrop += picbox2DArr43_DragDrop;

            picbox2DArr[4, 4].MouseDown += picbox2DArr44_MouseDown;
            //picbox2DArr[4, 4].DragEnter += picbox2DArr44_DragEnter;
            //picbox2DArr[4, 4].DragDrop += picbox2DArr44_DragDrop;

            //picbox2DArr[4, 5].MouseDown += picbox2DArr45_MouseDown;
            //picbox2DArr[4, 5].DragEnter += picbox2DArr45_DragEnter;
            //picbox2DArr[4, 5].DragDrop += picbox2DArr45_DragDrop;

            //picbox2DArr[4, 6].MouseDown += picbox2DArr46_MouseDown;
            //picbox2DArr[4, 6].DragEnter += picbox2DArr46_DragEnter;
            //picbox2DArr[4, 6].DragDrop += picbox2DArr46_DragDrop;

            //picbox2DArr[4, 7].MouseDown += picbox2DArr47_MouseDown;
            //picbox2DArr[4, 7].DragEnter += picbox2DArr47_DragEnter;
            //picbox2DArr[4, 7].DragDrop += picbox2DArr47_DragDrop;

            //picbox2DArr[4, 8].MouseDown += picbox2DArr48_MouseDown;
            //picbox2DArr[4, 8].DragEnter += picbox2DArr48_DragEnter;
            //picbox2DArr[4, 8].DragDrop += picbox2DArr48_DragDrop;

            //picbox2DArr[4, 9].MouseDown += picbox2DArr49_MouseDown;
            //picbox2DArr[4, 9].DragEnter += picbox2DArr49_DragEnter;
            //picbox2DArr[4, 9].DragDrop += picbox2DArr49_DragDrop;
        }

        private void picboxHove_leave()
        {
            //0 row
            pictureBox040.MouseLeave += new System.EventHandler(pictureBox040_MouseLeave);
            pictureBox040.MouseHover += new System.EventHandler(pictureBox040_MouseHover);

            pictureBox041.MouseLeave += new System.EventHandler(pictureBox041_MouseLeave);
            pictureBox041.MouseHover += new System.EventHandler(pictureBox041_MouseHover);

            pictureBox042.MouseLeave += new System.EventHandler(pictureBox042_MouseLeave);
            pictureBox042.MouseHover += new System.EventHandler(pictureBox042_MouseHover);

            pictureBox043.MouseLeave += new System.EventHandler(pictureBox043_MouseLeave);
            pictureBox043.MouseHover += new System.EventHandler(pictureBox043_MouseHover);

            //1 row
            pictureBox140.MouseLeave += new System.EventHandler(pictureBox140_MouseLeave);
            pictureBox140.MouseHover += new System.EventHandler(pictureBox140_MouseHover);

            pictureBox141.MouseLeave += new System.EventHandler(pictureBox141_MouseLeave);
            pictureBox141.MouseHover += new System.EventHandler(pictureBox141_MouseHover);

            pictureBox142.MouseLeave += new System.EventHandler(pictureBox142_MouseLeave);
            pictureBox142.MouseHover += new System.EventHandler(pictureBox142_MouseHover);

            pictureBox143.MouseLeave += new System.EventHandler(pictureBox143_MouseLeave);
            pictureBox143.MouseHover += new System.EventHandler(pictureBox143_MouseHover);

            //2 row
            pictureBox240.MouseLeave += new System.EventHandler(pictureBox240_MouseLeave);
            pictureBox240.MouseHover += new System.EventHandler(pictureBox240_MouseHover);

            pictureBox241.MouseLeave += new System.EventHandler(pictureBox241_MouseLeave);
            pictureBox241.MouseHover += new System.EventHandler(pictureBox241_MouseHover);

            pictureBox242.MouseLeave += new System.EventHandler(pictureBox242_MouseLeave);
            pictureBox242.MouseHover += new System.EventHandler(pictureBox242_MouseHover);

            pictureBox243.MouseLeave += new System.EventHandler(pictureBox243_MouseLeave);
            pictureBox243.MouseHover += new System.EventHandler(pictureBox243_MouseHover);

            //3 row
            pictureBox340.MouseLeave += new System.EventHandler(pictureBox340_MouseLeave);
            pictureBox340.MouseHover += new System.EventHandler(pictureBox340_MouseHover);

            pictureBox341.MouseLeave += new System.EventHandler(pictureBox341_MouseLeave);
            pictureBox341.MouseHover += new System.EventHandler(pictureBox341_MouseHover);

            pictureBox342.MouseLeave += new System.EventHandler(pictureBox342_MouseLeave);
            pictureBox342.MouseHover += new System.EventHandler(pictureBox342_MouseHover);

            pictureBox343.MouseLeave += new System.EventHandler(pictureBox343_MouseLeave);
            pictureBox343.MouseHover += new System.EventHandler(pictureBox343_MouseHover);

            labelplaying1.Visible = false;
            labelplaying2.Visible = false;
            labelplaying3.Visible = false;
            labelplaying4.Visible = false;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            panelWelcome.Visible = false;
            labelWelcome.Visible = false;
            buttonD.Visible = false;

            //Welcome to the game, Are you ready to play?
            
            //WelcomeToGame();
            //richTextBox1.Visible = false;


            //Dialog for how many players.
            HowManyPlayerDialog();

            //Dialog for enter players' names.
            EnterPlayersName();


            //Assign the player name area, the player name label.
            labelP1.Text = p1_name;
            labelP2.Text = p2_name;
            labelP3.Text = p3_name;
            labelP4.Text = p4_name;

            /**
             * Set the Player name and their scores visible value.
             */
            if (howManyP == 2)
            {
                labelP3.Visible = false;
                labelP3S.Visible = false;
                labelP4.Visible = false;
                labelP4S.Visible = false;
                labelPN3_mark.Visible = false;
                labelPN4_mark.Visible = false;

            }
            else if (howManyP == 3)
            {
                labelP4.Visible = false;
                labelP4S.Visible = false;
                labelPN4_mark.Visible = false;
            }


            ////Create an int array to match the names of picture file.
            //int iterator = 10;
            //for (int i = 0; i < picName.Length; i++)
            //{
            //    picName[i] = iterator + i % 4 + 1;
            //    iterator = (i % 4 == 3) ? iterator + 10 : iterator;
            //    Console.WriteLine("Pic: {0}.", picName[i]);
            //}

            int assignTime = 0;
            int cardValue = 1;

            for (int i = 0; i <= howManyP * 54 - 1; i++)
            {
                //string addition = "_";
                picboxBitmapList[4, 4].Add(
                        (Bitmap)(Properties.Resources.ResourceManager.GetObject("_"+(picName[i % 54]).ToString()) as Image)
                    );
                //add tag to bitmap
                
                picboxBitmapList[4, 4][(
                    picboxBitmapList[4, 4].Count - 1)
                    ].Tag = cardValue;// i % 54 + 1;

                Console.WriteLine("Card Value: {0}", cardValue);


                assignTime++;
                if (cardValue == 14 && assignTime == 2)
                {
                    cardValue = 1;
                    assignTime = 0;
                }
                else if (assignTime == 4)
                {
                    cardValue++;
                    //if (cardValue == 13)
                    //{
                    //    cardValue = 1;
                    //}
                    assignTime = 0;
                }



                //debug
                //i% 54 = 0, 1, 2, .... 53.
                //but card is 1, 1, 1, 1, 2, 2, 2, 2, 3, ...
                //Console.WriteLine("Picture Name: {0}", i%54);

                if (AnimationTime != 0)
                {
                    /**
                     * The Dealing animation.
                     */
                    //show the card face.
                    picbox2DArr[4, 4].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject((picName[i % 54]).ToString()) as Image);

                    //show the topmost card face.
                    picbox2DArr[4, 4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

                    //Modify the label number.
                    labelCenter.Text = picboxBitmapList[4, 4].Count.ToString();

                    picbox2DArr[4, 4].Refresh();
                    System.Threading.Thread.Sleep(AnimationTime);
                }//animation
            }

            //debugging
            //Console.WriteLine("Hhahah: {0}", picboxBitmapList[4, 4].Capacity);
            
            
            //Image of center picturebox is equal to the last image in [4, 4]
            //picbox2DArr[4, 4].Image =
            //    picboxBitmapList[4, 4][
            //    (picboxBitmapList[4,4].Count - 1)
            //    ];

            //show the card back.
            picbox2DArr[4, 4].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("Back") as Image);

            //show the topmost card face.
            picbox2DArr[4,4].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            //Modify the label number.
            labelCenter.Text = picboxBitmapList[4, 4].Count.ToString();


            showTopmost5();

            MessageBox.Show("Please Click the Shuffle button for shuffling the cards.");
            


        }//buttonStart_click

        private void showTopmost5()
        {
            //show the topmost 5. Copy the last 5 card of central.
            for (int i = 5; i <= 9; i++)
            {
                if (picboxBitmapList[4, 4].Count != 0)
                {
                    //last index
                    picbox2DArr[4, i].Image = picboxBitmapList[4, 4][
                                                                    (picboxBitmapList[4, 4].Count - (i - 4))
                                                                    ];
                    picbox2DArr[4, i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                }
            }
        }


        private void HowManyPlayerDialog()
        {
            //howManyPDialog.Controls.Add(howManyPComboBox2);
            //howManyPDialog.Visible = true;

            howManyPDialog = new Form();

            howManyPComboBox2 = new System.Windows.Forms.ComboBox();
            howManyPLabel50 = new System.Windows.Forms.Label();
            howManyPButton1 = new System.Windows.Forms.Button();
            howManyPButton2 = new System.Windows.Forms.Button();
            SuspendLayout();
            //// 
            //// howManyPComboBox2
            //// 
            howManyPComboBox2.AccessibleName = "";
            howManyPComboBox2.BackColor = System.Drawing.SystemColors.ControlDarkDark;// .ControlLight;
            howManyPComboBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            howManyPComboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            howManyPComboBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;// .ScrollBar;
            howManyPComboBox2.FormattingEnabled = true;
            howManyPComboBox2.ItemHeight = 33;
            howManyPComboBox2.Items.AddRange(new object[] {
            "2",
            "3",
            "4"});
            howManyPComboBox2.Location = new System.Drawing.Point(317, 83);
            howManyPComboBox2.Margin = new System.Windows.Forms.Padding(4);
            howManyPComboBox2.Name = "howManyPComboBox2";
            howManyPComboBox2.Size = new System.Drawing.Size(152, 41);
            howManyPComboBox2.TabIndex = 67;
            howManyPComboBox2.Text = "Please select";
            // 
            // howManyPLabel50
            // 
            howManyPLabel50.AutoSize = true;
            howManyPLabel50.BackColor = System.Drawing.Color.Transparent;
            howManyPLabel50.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            howManyPLabel50.ForeColor = System.Drawing.SystemColors.Highlight;
            howManyPLabel50.Location = new System.Drawing.Point(70, 83);
            howManyPLabel50.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            howManyPLabel50.Name = "howManyPLabel50";
            howManyPLabel50.Size = new System.Drawing.Size(316, 37);
            howManyPLabel50.TabIndex = 68;
            howManyPLabel50.Text = "How many Players?";
            // 
            // howManyPButton1
            // 
            howManyPButton1.Location = new System.Drawing.Point(157, 198);
            howManyPButton1.Name = "howManyPButton1";
            howManyPButton1.Size = new System.Drawing.Size(70, 42);
            howManyPButton1.TabIndex = 69;
            howManyPButton1.Text = "Next";
            howManyPButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            howManyPButton1.UseVisualStyleBackColor = true;
            howManyPButton1.Click += new System.EventHandler(howManyPButton1_Click);
            //howManyPButton1.Visible = true;
            // 
            // howManyPButton2
            // 
            howManyPButton2.Location = new System.Drawing.Point(247, 198);
            howManyPButton2.Name = "howManyPButton2";
            howManyPButton2.Size = new System.Drawing.Size(70, 42);
            howManyPButton2.TabIndex = 70;
            howManyPButton2.Text = "Exit";
            howManyPButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            howManyPButton2.UseVisualStyleBackColor = true;
            howManyPButton2.Click += new System.EventHandler(howManyPButton2_Click);
            // 
            // Form1
            // 
            howManyPDialog.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            howManyPDialog.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            howManyPDialog.ClientSize = new System.Drawing.Size(488, 288);
            howManyPDialog.Controls.Add(howManyPButton2);
            howManyPDialog.Controls.Add(this.howManyPButton1);
            howManyPDialog.Controls.Add(this.howManyPLabel50);
            howManyPDialog.Controls.Add(howManyPComboBox2);
            //this.Name = "Form1";
            //this.Text = "Form1";
            howManyPDialog.ResumeLayout(false);
            howManyPDialog.PerformLayout();
            howManyPDialog.StartPosition = FormStartPosition.CenterScreen;
            howManyPDialog.ShowDialog(this);
        }

        private void howManyPButton1_Click(object sender, EventArgs e)
        {
            
            
            //Console.WriteLine("input is: ======{0}", howManyP);
            if (howManyPComboBox2.SelectedIndex >= 0)
            {
                howManyP = Convert.ToInt32(howManyPComboBox2.Text);
                howManyPDialog.Dispose();
            }
        }
        private void howManyPButton2_Click(object sender, EventArgs e)
        {
            //terminate the program
            howManyPDialog.Dispose();
            System.Windows.Forms.Application.Exit();
        }


        



        

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void EnterPlayersName()
        {
            labelPN_A = new System.Windows.Forms.Label();
            textBoxPN_A = new System.Windows.Forms.TextBox();
            labelPN_B = new System.Windows.Forms.Label();
            labelPN_C = new System.Windows.Forms.Label();
            labelPN_D = new System.Windows.Forms.Label();
            textBoxPN_B = new System.Windows.Forms.TextBox();
            textBoxPN_C = new System.Windows.Forms.TextBox();
            textBoxPN_D = new System.Windows.Forms.TextBox();
            labelPN_mark = new System.Windows.Forms.Label();
            buttonPN_OK = new System.Windows.Forms.Button();
            buttonPN_Cancel = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // labelPN_A
            // 
            labelPN_A.AutoSize = true;
            labelPN_A.BackColor = System.Drawing.Color.Transparent;
            labelPN_A.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelPN_A.ForeColor = System.Drawing.SystemColors.Highlight;
            labelPN_A.Location = new System.Drawing.Point(96, 63);
            labelPN_A.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            labelPN_A.Name = "labelPN_A";
            labelPN_A.Size = new System.Drawing.Size(80, 20);
            labelPN_A.TabIndex = 53;
            labelPN_A.Text = "Player A:";
            // 
            // textBoxPN_A
            // 
            textBoxPN_A.Location = new System.Drawing.Point(214, 63);
            textBoxPN_A.Name = "textBoxPN_A";
            textBoxPN_A.Size = new System.Drawing.Size(100, 20);
            textBoxPN_A.TabIndex = 54;
            //textBoxPN_A.Text = " ";
            // 
            // labelPN_B
            // 
            labelPN_B.AutoSize = true;
            labelPN_B.BackColor = System.Drawing.Color.Transparent;
            labelPN_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelPN_B.ForeColor = System.Drawing.SystemColors.Highlight;
            labelPN_B.Location = new System.Drawing.Point(96, 105);
            labelPN_B.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            labelPN_B.Name = "labelPN_B";
            labelPN_B.Size = new System.Drawing.Size(80, 20);
            labelPN_B.TabIndex = 55;
            labelPN_B.Text = "Player B:";
            // 
            // labelPN_C
            // 
            labelPN_C.AutoSize = true;
            labelPN_C.BackColor = System.Drawing.Color.Transparent;
            labelPN_C.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelPN_C.ForeColor = System.Drawing.SystemColors.Highlight;
            labelPN_C.Location = new System.Drawing.Point(96, 144);
            labelPN_C.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            labelPN_C.Name = "labelPN_C";
            labelPN_C.Size = new System.Drawing.Size(80, 20);
            labelPN_C.TabIndex = 56;
            labelPN_C.Text = "Player C:";
            // 
            // labelPN_D
            // 
            labelPN_D.AutoSize = true;
            labelPN_D.BackColor = System.Drawing.Color.Transparent;
            labelPN_D.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelPN_D.ForeColor = System.Drawing.SystemColors.Highlight;
            labelPN_D.Location = new System.Drawing.Point(96, 183);
            labelPN_D.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            labelPN_D.Name = "labelPN_D";
            labelPN_D.Size = new System.Drawing.Size(81, 20);
            labelPN_D.TabIndex = 57;
            labelPN_D.Text = "Player D:";
            // 
            // textBoxPN_B
            // 
            textBoxPN_B.Location = new System.Drawing.Point(214, 105);
            textBoxPN_B.Name = "textBoxPN_B";
            textBoxPN_B.Size = new System.Drawing.Size(100, 20);
            textBoxPN_B.TabIndex = 58;
            // 
            // textBoxPN_C
            // 
            textBoxPN_C.Location = new System.Drawing.Point(214, 146);
            textBoxPN_C.Name = "textBoxPN_C";
            textBoxPN_C.Size = new System.Drawing.Size(100, 20);
            textBoxPN_C.TabIndex = 59;
            // 
            // textBoxPN_D
            // 
            textBoxPN_D.Location = new System.Drawing.Point(214, 185);
            textBoxPN_D.Name = "textBoxPN_D";
            textBoxPN_D.Size = new System.Drawing.Size(100, 20);
            textBoxPN_D.TabIndex = 60;
            // 
            // labelPN_mark
            // 
            labelPN_mark.AutoSize = true;
            labelPN_mark.BackColor = System.Drawing.Color.Transparent;
            labelPN_mark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelPN_mark.ForeColor = System.Drawing.SystemColors.Highlight;
            labelPN_mark.Location = new System.Drawing.Point(11, 19);
            labelPN_mark.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            labelPN_mark.Name = "labelPN_mark";
            labelPN_mark.Size = new System.Drawing.Size(235, 20);
            labelPN_mark.TabIndex = 61;
            labelPN_mark.Text = "Please Enter Player\'s Name:";
            // 
            // buttonPN_OK
            // 
            buttonPN_OK.BackColor = System.Drawing.Color.Transparent;
            buttonPN_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            buttonPN_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            buttonPN_OK.Location = new System.Drawing.Point(101, 244);
            buttonPN_OK.Margin = new System.Windows.Forms.Padding(2);
            buttonPN_OK.Name = "buttonPN_OK";
            buttonPN_OK.Size = new System.Drawing.Size(96, 34);
            buttonPN_OK.TabIndex = 62;
            buttonPN_OK.Text = "Next";
            buttonPN_OK.UseVisualStyleBackColor = false;
            buttonPN_OK.Click += new System.EventHandler(buttonPN_OK_Click);
            // 
            // buttonPN_Cancel
            // 
            buttonPN_Cancel.BackColor = System.Drawing.Color.Transparent;
            buttonPN_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            buttonPN_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            buttonPN_Cancel.Location = new System.Drawing.Point(214, 244);
            buttonPN_Cancel.Margin = new System.Windows.Forms.Padding(2);
            buttonPN_Cancel.Name = "buttonPN_Cancel";
            buttonPN_Cancel.Size = new System.Drawing.Size(96, 34);
            buttonPN_Cancel.TabIndex = 63;
            buttonPN_Cancel.Text = "Exit";
            buttonPN_Cancel.UseVisualStyleBackColor = false;
            buttonPN_Cancel.Click += new System.EventHandler(buttonPN_Cancel_Click);
            // 
            // Form1
            // 
            PlayerName.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            PlayerName.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            PlayerName.ClientSize = new System.Drawing.Size(389, 309);
            PlayerName.Controls.Add(buttonPN_Cancel);
            PlayerName.Controls.Add(buttonPN_OK);
            PlayerName.Controls.Add(labelPN_mark);
            PlayerName.Controls.Add(textBoxPN_D);
            PlayerName.Controls.Add(textBoxPN_C);
            PlayerName.Controls.Add(textBoxPN_B);
            PlayerName.Controls.Add(labelPN_D);
            PlayerName.Controls.Add(labelPN_C);
            PlayerName.Controls.Add(labelPN_B);
            PlayerName.Controls.Add(textBoxPN_A);
            PlayerName.Controls.Add(labelPN_A);
            PlayerName.Name = "Form1";
            PlayerName.Text = "Form1";
            PlayerName.ResumeLayout(false);
            PlayerName.StartPosition = FormStartPosition.CenterScreen;
            PlayerName.PerformLayout();

            if (howManyP == 2)
            {
                labelPN_C.Visible = false;
                labelPN_D.Visible = false;
                textBoxPN_C.Visible = false;
                textBoxPN_D.Visible = false;
            }
            else if (howManyP == 3)
            {
                labelPN_D.Visible = false;
                textBoxPN_D.Visible = false;
            }



            PlayerName.ShowDialog(this);
        }

        private void buttonPN_OK_Click(object sender, EventArgs e)
        {
            p1_name = textBoxPN_A.Text;
            p2_name = textBoxPN_B.Text;
            p3_name = textBoxPN_C.Text;
            p4_name = textBoxPN_D.Text;
            
            PlayerName.Dispose();
        }

        private void buttonPN_Cancel_Click(object sender, EventArgs e)
        {
            PlayerName.Dispose();
            System.Windows.Forms.Application.Exit();
        }






        private void AskShuffleTime()
        {
            askShuffleTime = new Form();


            labelPN_A = new System.Windows.Forms.Label();
            textBoxPN_A = new System.Windows.Forms.TextBox();
            labelPN_B = new System.Windows.Forms.Label();
            labelPN_C = new System.Windows.Forms.Label();
            labelPN_D = new System.Windows.Forms.Label();
            textBoxPN_B = new System.Windows.Forms.TextBox();
            textBoxPN_C = new System.Windows.Forms.TextBox();
            textBoxPN_D = new System.Windows.Forms.TextBox();
            labelPN_mark = new System.Windows.Forms.Label();
            buttonPN_OK = new System.Windows.Forms.Button();
            buttonPN_Cancel = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // labelPN_A
            // 
            labelPN_A.AutoSize = true;
            labelPN_A.BackColor = System.Drawing.Color.Transparent;
            labelPN_A.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelPN_A.ForeColor = System.Drawing.SystemColors.Highlight;
            labelPN_A.Location = new System.Drawing.Point(16, 63);
            labelPN_A.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            labelPN_A.Name = "labelPN_A";
            labelPN_A.Size = new System.Drawing.Size(80, 20);
            labelPN_A.TabIndex = 53;
            labelPN_A.Text = "How many times for shuffling: ";
            // 
            // textBoxPN_A
            // 
            textBoxPN_A.Location = new System.Drawing.Point(274, 63);
            textBoxPN_A.Name = "textBoxPN_A";
            textBoxPN_A.Size = new System.Drawing.Size(100, 20);
            textBoxPN_A.TabIndex = 54;
            //textBoxPN_A.Text = " ";
            //
            // buttonPN_OK
            // 
            buttonPN_OK.BackColor = System.Drawing.Color.Transparent;
            buttonPN_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            buttonPN_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            buttonPN_OK.Location = new System.Drawing.Point(91, 104);
            buttonPN_OK.Margin = new System.Windows.Forms.Padding(2);
            buttonPN_OK.Name = "buttonPN_OK";
            buttonPN_OK.Size = new System.Drawing.Size(96, 34);
            buttonPN_OK.TabIndex = 62;
            buttonPN_OK.Text = "Shuffle";
            buttonPN_OK.UseVisualStyleBackColor = false;
            buttonPN_OK.Click += new System.EventHandler(buttonAskShuffleTime_OK_Click);
            // 
            // buttonPN_Cancel
            // 
            buttonPN_Cancel.BackColor = System.Drawing.Color.Transparent;
            buttonPN_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            buttonPN_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            buttonPN_Cancel.Location = new System.Drawing.Point(200, 104);
            buttonPN_Cancel.Margin = new System.Windows.Forms.Padding(2);
            buttonPN_Cancel.Name = "buttonPN_Cancel";
            buttonPN_Cancel.Size = new System.Drawing.Size(156, 34);
            buttonPN_Cancel.TabIndex = 63;
            buttonPN_Cancel.Text = "Don't shuffle";
            buttonPN_Cancel.UseVisualStyleBackColor = false;
            //buttonPN_Cancel.Click += new System.EventHandler(buttonAskShuffleTime_Cancel_Click);

            buttonPN_Cancel.Click += new System.EventHandler(buttonD_Click);
            // 
            // Form1
            // 
            askShuffleTime.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            askShuffleTime.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            askShuffleTime.ClientSize = new System.Drawing.Size(389, 209);
            askShuffleTime.Controls.Add(buttonPN_Cancel);
            askShuffleTime.Controls.Add(buttonPN_OK);
            askShuffleTime.Controls.Add(labelPN_mark);
            askShuffleTime.Controls.Add(textBoxPN_D);
            askShuffleTime.Controls.Add(textBoxPN_C);
            askShuffleTime.Controls.Add(textBoxPN_B);
            askShuffleTime.Controls.Add(labelPN_D);
            askShuffleTime.Controls.Add(labelPN_C);
            askShuffleTime.Controls.Add(labelPN_B);
            askShuffleTime.Controls.Add(textBoxPN_A);
            askShuffleTime.Controls.Add(labelPN_A);
            askShuffleTime.Name = "Form1";
            askShuffleTime.Text = "Form1";
            askShuffleTime.ResumeLayout(false);
            askShuffleTime.StartPosition = FormStartPosition.CenterScreen;
            askShuffleTime.PerformLayout();

            //if (howManyP == 2)
            //{
            //    labelPN_C.Visible = false;
            //    labelPN_D.Visible = false;
            //    textBoxPN_C.Visible = false;
            //    textBoxPN_D.Visible = false;
            //}
            //else if (howManyP == 3)
            //{
            //    labelPN_D.Visible = false;
            //    textBoxPN_D.Visible = false;
            //}



            askShuffleTime.ShowDialog(this);
        }

        private void buttonAskShuffleTime_Cancel_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            doNotShuffleAgain = true;
            askShuffleTime.Dispose();
        }

        private void buttonAskShuffleTime_OK_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (!string.IsNullOrEmpty(textBoxPN_A.Text))
            {


                shuffleTime += Convert.ToInt32(textBoxPN_A.Text);
                askShuffleTime.Dispose();
            }
        }

        //private void fileSystemWatcher2_Changed(object sender, System.IO.FileSystemEventArgs e)
        //{

        //}

        private void buttonS_Click(object sender, EventArgs e)
        {
            while (doNotShuffleAgain == false)
            {
                //Ask for shuffle time
                AskShuffleTime();
                for (int i = 0; i < shuffleTime; i++)
                {
                    shuffle(picboxBitmapList[4, 4]);
                    //put topmost 5
                    showTopmost5();
                    /**
                     * Animation effect
                     */
                    System.Threading.Thread.Sleep(5);
                    for (int j = 5; j <= 9; j++)
                    {
                        picbox2DArr[4, j].Refresh();
                    }

                }

                //showTopmost5();


                //ask for shuffle again?
                if(shuffleTime != 0)
                    shuffleAgain();
            }
            showTopmost5();
        }


        //shuffle
        public void shuffle(List<Bitmap> ary)
        {
            Random rnd = new Random();

            //i > 0 or i >= 0 ?
            for (int i = ary.Count - 1; i > 0; i--)
            {
                int r = rnd.Next(0, i);

                Bitmap tmp = ary[i];
                ary[i] = ary[r];
                ary[r] = tmp;
            }
        }

        //button2 is shuffle
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    shuffle(cardSet);
        //    labelS.Text = (++shuffleTime).ToString();
        //    DistributeToMainDeck();
        //}


        private void shuffleAgain()
        {
            shuffleAgainForm = new Form();


            labelPN_A = new System.Windows.Forms.Label();
            textBoxPN_A = new System.Windows.Forms.TextBox();
            labelPN_B = new System.Windows.Forms.Label();
            labelPN_C = new System.Windows.Forms.Label();
            labelPN_D = new System.Windows.Forms.Label();
            textBoxPN_B = new System.Windows.Forms.TextBox();
            textBoxPN_C = new System.Windows.Forms.TextBox();
            textBoxPN_D = new System.Windows.Forms.TextBox();
            labelPN_mark = new System.Windows.Forms.Label();
            buttonPN_OK = new System.Windows.Forms.Button();
            buttonPN_Cancel = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // labelPN_A
            // 
            labelPN_A.AutoSize = true;
            labelPN_A.BackColor = System.Drawing.Color.Transparent;
            labelPN_A.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelPN_A.ForeColor = System.Drawing.SystemColors.Highlight;
            labelPN_A.Location = new System.Drawing.Point(16, 63);
            labelPN_A.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            labelPN_A.Name = "labelPN_A";
            labelPN_A.Size = new System.Drawing.Size(80, 20);
            labelPN_A.TabIndex = 53;
            labelPN_A.Text = "You have shuffled " + shuffleTime + " times.\nShuffle again?";
            //// 
            //// textBoxPN_A
            //// 
            //textBoxPN_A.Location = new System.Drawing.Point(274, 63);
            //textBoxPN_A.Name = "textBoxPN_A";
            //textBoxPN_A.Size = new System.Drawing.Size(100, 20);
            //textBoxPN_A.TabIndex = 54;
            //textBoxPN_A.Text = " ";
            //
            // buttonPN_OK
            // 
            buttonPN_OK.BackColor = System.Drawing.Color.Transparent;
            buttonPN_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            buttonPN_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            buttonPN_OK.Location = new System.Drawing.Point(91, 134);
            buttonPN_OK.Margin = new System.Windows.Forms.Padding(2);
            buttonPN_OK.Name = "buttonPN_OK";
            buttonPN_OK.Size = new System.Drawing.Size(96, 34);
            buttonPN_OK.TabIndex = 62;
            buttonPN_OK.Text = "Shuffle";
            buttonPN_OK.UseVisualStyleBackColor = false;
            buttonPN_OK.Click += new System.EventHandler(buttonShuffleAgain_OK_Click);
            // 
            // buttonPN_Cancel
            // 
            buttonPN_Cancel.BackColor = System.Drawing.Color.Transparent;
            buttonPN_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            buttonPN_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            buttonPN_Cancel.Location = new System.Drawing.Point(200, 134);
            buttonPN_Cancel.Margin = new System.Windows.Forms.Padding(2);
            buttonPN_Cancel.Name = "buttonPN_Cancel";
            buttonPN_Cancel.Size = new System.Drawing.Size(96, 34);
            buttonPN_Cancel.TabIndex = 63;
            buttonPN_Cancel.Text = "Done";
            buttonPN_Cancel.UseVisualStyleBackColor = false;
            //buttonPN_Cancel.Click += new System.EventHandler(buttonShuffleAgain_Cancel_Click);
            //distribute card after click do not shuffle.
            buttonPN_Cancel.Click += new System.EventHandler(buttonD_Click);
            // 
            // Form1
            // 
            shuffleAgainForm.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            shuffleAgainForm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            shuffleAgainForm.ClientSize = new System.Drawing.Size(359, 209);
            shuffleAgainForm.Controls.Add(buttonPN_Cancel);
            shuffleAgainForm.Controls.Add(buttonPN_OK);
            shuffleAgainForm.Controls.Add(labelPN_mark);
            shuffleAgainForm.Controls.Add(textBoxPN_D);
            shuffleAgainForm.Controls.Add(textBoxPN_C);
            shuffleAgainForm.Controls.Add(textBoxPN_B);
            shuffleAgainForm.Controls.Add(labelPN_D);
            shuffleAgainForm.Controls.Add(labelPN_C);
            shuffleAgainForm.Controls.Add(labelPN_B);
            shuffleAgainForm.Controls.Add(textBoxPN_A);
            shuffleAgainForm.Controls.Add(labelPN_A);
            shuffleAgainForm.Name = "Form1";
            shuffleAgainForm.Text = "Form1";
            shuffleAgainForm.ResumeLayout(false);
            shuffleAgainForm.StartPosition = FormStartPosition.CenterScreen;
            shuffleAgainForm.PerformLayout();

            //if (howManyP == 2)
            //{
            //    labelPN_C.Visible = false;
            //    labelPN_D.Visible = false;
            //    textBoxPN_C.Visible = false;
            //    textBoxPN_D.Visible = false;
            //}
            //else if (howManyP == 3)
            //{
            //    labelPN_D.Visible = false;
            //    textBoxPN_D.Visible = false;
            //}



            shuffleAgainForm.ShowDialog(this);
        }


        private void buttonShuffleAgain_OK_Click(object sender, EventArgs e)
        {
            shuffleAgainForm.Dispose();
            //shuffleTime = 0;
            //AskShuffleTime();

        }

        private void buttonShuffleAgain_Cancel_Click(object sender, EventArgs e)
        {
            doNotShuffleAgain = true;
            shuffleAgainForm.Dispose();
            //buttonPN_Cancel.Click += new System.EventHandler(this.buttonD_Click);
        }

        //Distribute button
        private void buttonD_Click(object sender, EventArgs e)
        {
            doNotShuffleAgain = true;
            if (shuffleTime == 0)
                askShuffleTime.Dispose();
            else
                shuffleAgainForm.Dispose();
            

            //Set shuffleTime to zero
            shuffleTime = 0;

            //distribute the cards to everyone's 5-card place.
            //  start from player 0 to 3.
            //distribute_howManyP(howManyP);

            //215
            //distribute the card from index 0 since the putToMainDeck is putting
            //      from index 0;


            for (int i = 0; i <= 3; i++)
            {

                if (howManyP == 2 && i == 1)
                {
                    i++;
                }

                //distribute to 5 cards position.
                for (int j = 0; j <= 4; j++)
                {
                    //if(pnR[4, 5].Controls.Contains(Card))
                    //{
                    //    pnR[4, 5].Controls.Remove(Card);
                    //}
                    //pnR[4, 5].Controls.Remove
                        //pnR[4, 5].Controls.Clear();
                        //pnR[i, j].Controls.Add(cardSet[firstIndex]);

                    /** add first then remove
                     * 
                     * Add card to 1st position of 5 cards.
                     * 
                     * Remove card from last index in main deck.
                     */
                    
                    picboxBitmapList[i, j].Add(picboxBitmapList[4, 4][
                                                                (picboxBitmapList[4, 4].Count - 1)
                                                                ]);
                    //display the card, since this position is only allowed to have 1 card.
                    //last index
                    picbox2DArr[i, j].Image = picboxBitmapList[i, j][
                                                                    (picboxBitmapList[i, j].Count - 1)
                                                                    ];
                    picbox2DArr[i, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;


                    picboxBitmapList[4, 4].RemoveAt(picboxBitmapList[4, 4].Count - 1);

                    //Modify the label number.
                    labelCenter.Text = picboxBitmapList[4, 4].Count.ToString();






                    //cardSet[firstIndex].BringToFront();

                    //firstIndex++;

                    //for (int t = 6; t <= 9; t++)
                    //{
                    //    pnR[4, t].Controls.Clear();
                    //    pnR[4, t - 1].Controls.Add(cardSet[firstIndex + (t - 6)]);
                    //    cardSet[firstIndex + (t - 6)].BringToFront();
                    //}
                    ////move topmost in main deck to
                    ////      the rightmost position of the 5.

                    ////if(pnR[4, 4].Controls.Contains(cardSet[firstIndex - 4]))
                    ////{
                    //pnR[4, 4].Controls.Remove(cardSet[firstIndex + 4]);
                    //l00--;
                    //label00.Text = l00.ToString();
                    ////}
                    //pnR[4, 9].Controls.Add(cardSet[firstIndex + 4]);


                    ////panel00.Controls.Remove(cardSet[topmostIndex]);

                    ////what's this line below?
                    ////cardSet[firstIndex++].BringToFront();



                    if (AnimationTime != 0)
                    {
                        //this.Refresh();
                        System.Threading.Thread.Sleep(AnimationTime);
                    }
                }//for 


                if ((howManyP == 3 || howManyP == 2) && i == 2) i++;

            }//for 5


            //System.Threading.Thread.Sleep(1000);

            //distribute cards to 21-place
            for (int i = 0; i <= 3; i++)
            {
                if (howManyP == 2 && i == 1)
                {
                    i++;
                }


                for (int j = 0; j <= 20; j++)
                {



                    /** add first then remove
                     * 
                     * Add card to 1st position of 5 cards.
                     * 
                     * Remove card from last index in main deck.
                     */

                    picboxBitmapList[i, 9].Add(picboxBitmapList[4, 4][
                                                                (picboxBitmapList[4, 4].Count - 1)
                                                                ]);


                    //display the card, since this position is only allowed to have 1 card.
                    //last index
                    picbox2DArr[i, 9].Image = picboxBitmapList[i, 9][
                                                                    (picboxBitmapList[i, 9].Count - 1)
                                                                    ];
                    picbox2DArr[i, 9].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;




                    picboxBitmapList[4, 4].RemoveAt(picboxBitmapList[4, 4].Count - 1);

                    //Modify the label number.
                    //main deck
                    labelCenter.Text = picboxBitmapList[4, 4].Count.ToString();
                    //21 cards position
                    if (i == 0)
                        label021.Text = picboxBitmapList[i, 9].Count.ToString();
                    else if (i == 1)
                        label121.Text = picboxBitmapList[i, 9].Count.ToString();
                    else if (i == 2)
                        label221.Text = picboxBitmapList[i, 9].Count.ToString();
                    else if (i == 3)
                        label321.Text = picboxBitmapList[i, 9].Count.ToString();






                    //pnR[4, 5].Controls.Clear();
                    //pnR[i, 9].Controls.Add(cardSet[firstIndex]);
                    //cardSet[firstIndex].BringToFront();
                    //firstIndex++;



                    //for (int t = 6; t <= 9; t++)
                    //{
                    //    pnR[4, t].Controls.Clear();
                    //    pnR[4, t - 1].Controls.Add(cardSet[firstIndex + (t - 6)]);
                    //    cardSet[firstIndex + (t - 6)].BringToFront();
                    //}
                    ////move topmost in main deck to
                    ////      the rightmost position of the 5.

                    ////if(pnR[4, 4].Controls.Contains(cardSet[firstIndex - 4]))
                    ////{
                    //pnR[4, 4].Controls.Remove(cardSet[firstIndex + 4]);
                    //l00--;
                    //label00.Text = l00.ToString();
                    ////}
                    //pnR[4, 9].Controls.Add(cardSet[firstIndex + 4]);




                    ////below the if and else if is for updating the number
                    ////      inside the 21 label.
                    //if (i == 0)
                    //{
                    //    l021++;
                    //    label021.Text = l021.ToString();
                    //}
                    //else if (i == 1)
                    //{
                    //    l121++;
                    //    label121.Text = l121.ToString();
                    //}
                    //else if (i == 2)
                    //{
                    //    l221++;
                    //    label221.Text = l221.ToString();
                    //}
                    //else if (i == 3)
                    //{
                    //    l321++;
                    //    label321.Text = l321.ToString();
                    //}


                    ////panel00.Controls.Remove(cardSet[firstIndex]);
                    ////l00--;
                    //// label00.Text = l00.ToString();
                    ////cardSet[firstIndex--].BringToFront();
                    if (AnimationTime != 0)
                    {
                        this.Refresh();
                        System.Threading.Thread.Sleep(AnimationTime);
                    }
                }

                if ((howManyP == 3 || howManyP == 2) && i == 2)
                {
                    i++;
                }
            }//for 21


            whichPlayerPlay1st();


            coverNonPlayingCardsBe4Distri();
            


        }//distribute


        private void coverNonPlayingCardsBe4Distri()
        {

            //show Playing.//
            if (playing == 1)
            {
                labelplaying1.Visible = true;
                labelplaying2.Visible = false;
                labelplaying3.Visible = false;
                labelplaying4.Visible = false;
            }
            else if (playing == 2)
            {
                labelplaying1.Visible = false;
                labelplaying2.Visible = true;
                labelplaying3.Visible = false;
                labelplaying4.Visible = false;
            }
            else if (playing == 3)
            {
                labelplaying1.Visible = false;
                labelplaying2.Visible = false;
                labelplaying3.Visible = true;
                labelplaying4.Visible = false;
            }
            else if (playing == 4)
            {
                labelplaying1.Visible = false;
                labelplaying2.Visible = false;
                labelplaying3.Visible = false;
                labelplaying4.Visible = true;
            }
        }

        //private void disableNonPlayingDragDrop(int playing)
        //{
        //    for (int i = 0; i <= 3; i++)
        //    {   
        //        if(i != playing)
        //            for (int j = 0; j <= 9; j++)
        //            {
        //                picbox2DArr[i, j].AllowDrop = false;
        //            }
        //    }
        //}



        private void whichPlayerPlay1st()
        {

            whichPlayer1st = new Form();


            labelPN_A = new System.Windows.Forms.Label();
            textBoxPN_A = new System.Windows.Forms.TextBox();
            labelPN_B = new System.Windows.Forms.Label();
            labelPN_C = new System.Windows.Forms.Label();
            labelPN_D = new System.Windows.Forms.Label();
            textBoxPN_B = new System.Windows.Forms.TextBox();
            textBoxPN_C = new System.Windows.Forms.TextBox();
            textBoxPN_D = new System.Windows.Forms.TextBox();
            labelPN_mark = new System.Windows.Forms.Label();
            buttonPN_OK = new System.Windows.Forms.Button();
            buttonPN_Cancel = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // labelPN_A
            // 
            labelPN_A.AutoSize = true;
            labelPN_A.BackColor = System.Drawing.Color.Transparent;
            labelPN_A.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelPN_A.ForeColor = System.Drawing.SystemColors.Highlight;
            labelPN_A.Location = new System.Drawing.Point(16, 63);
            labelPN_A.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            labelPN_A.Name = "labelPN_A";
            labelPN_A.Size = new System.Drawing.Size(80, 20);
            labelPN_A.TabIndex = 53;
            labelPN_A.Text = "Which player first?(1 ~ 4): ";
            // 
            // textBoxPN_A
            // 
            textBoxPN_A.Location = new System.Drawing.Point(274, 63);
            textBoxPN_A.Name = "textBoxPN_A";
            textBoxPN_A.Size = new System.Drawing.Size(100, 20);
            textBoxPN_A.TabIndex = 54;
            //textBoxPN_A.Text = " ";
            //
            // buttonPN_OK
            // 
            buttonPN_OK.BackColor = System.Drawing.Color.Transparent;
            buttonPN_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            buttonPN_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            buttonPN_OK.Location = new System.Drawing.Point(91, 104);
            buttonPN_OK.Margin = new System.Windows.Forms.Padding(2);
            buttonPN_OK.Name = "buttonPN_OK";
            buttonPN_OK.Size = new System.Drawing.Size(96, 34);
            buttonPN_OK.TabIndex = 62;
            buttonPN_OK.Text = "Next";
            buttonPN_OK.UseVisualStyleBackColor = false;
            buttonPN_OK.Click += new System.EventHandler(buttonwhichPlayer1st_OK_Click);
            // 
            // buttonPN_Cancel
            // 
            buttonPN_Cancel.BackColor = System.Drawing.Color.Transparent;
            buttonPN_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            buttonPN_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            buttonPN_Cancel.Location = new System.Drawing.Point(200, 104);
            buttonPN_Cancel.Margin = new System.Windows.Forms.Padding(2);
            buttonPN_Cancel.Name = "buttonPN_Cancel";
            buttonPN_Cancel.Size = new System.Drawing.Size(96, 34);
            buttonPN_Cancel.TabIndex = 63;
            buttonPN_Cancel.Text = "Randomize";
            buttonPN_Cancel.UseVisualStyleBackColor = false;
            buttonPN_Cancel.Click += new System.EventHandler(buttonwhichPlayer1st_Randomize_Click);
            // 
            // Form1
            // 
            whichPlayer1st.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            whichPlayer1st.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            whichPlayer1st.ClientSize = new System.Drawing.Size(389, 209);
            whichPlayer1st.Controls.Add(buttonPN_Cancel);
            whichPlayer1st.Controls.Add(buttonPN_OK);
            whichPlayer1st.Controls.Add(labelPN_mark);
            whichPlayer1st.Controls.Add(textBoxPN_D);
            whichPlayer1st.Controls.Add(textBoxPN_C);
            whichPlayer1st.Controls.Add(textBoxPN_B);
            whichPlayer1st.Controls.Add(labelPN_D);
            whichPlayer1st.Controls.Add(labelPN_C);
            whichPlayer1st.Controls.Add(labelPN_B);
            whichPlayer1st.Controls.Add(textBoxPN_A);
            whichPlayer1st.Controls.Add(labelPN_A);
            whichPlayer1st.Name = "Form1";
            whichPlayer1st.Text = "Form1";
            whichPlayer1st.ResumeLayout(false);
            whichPlayer1st.StartPosition = FormStartPosition.CenterScreen;
            whichPlayer1st.PerformLayout();

            //if (howManyP == 2)
            //{
            //    labelPN_C.Visible = false;
            //    labelPN_D.Visible = false;
            //    textBoxPN_C.Visible = false;
            //    textBoxPN_D.Visible = false;
            //}
            //else if (howManyP == 3)
            //{
            //    labelPN_D.Visible = false;
            //    textBoxPN_D.Visible = false;
            //}

            
            whichPlayer1st.ShowDialog(this);
            /**
             * Cover all the cards of 4 players.
             */
            coverNonPlayingCards();
        }

        private void buttonwhichPlayer1st_OK_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            playing = Convert.ToInt32(textBoxPN_A.Text);
            //debugging
            //Console.WriteLine("player {0} 1st!", playing);
            forceRefill(playing);
            whichPlayer1st.Dispose();
            
        }

        private void buttonwhichPlayer1st_Randomize_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Random random = new Random();
            playing = random.Next(1, howManyP + 1);
            //debugging
            //Console.WriteLine("player {0} 1st!", playing);
            forceRefill(playing);
            whichPlayer1st.Dispose();
            
        }

        /**
         * This function covers the 5 position cards.
         */
        private void coverNonPlayingCards()
        {
            if (howManyP >= 3)//3 or 4 people playing.
            {
                for (int i = 0; i <= howManyP - 1; i++)
                {
                    //cover the 5 position.
                    for (int j = 0; j <= 4; j++)
                    {
                        //playing = 1, 2, 3, 4
                        if (i == playing - 1)
                        {
                            /**
                             * Show
                             */
                            if (picboxBitmapList[i, j].Count != 0)
                            {
                                picbox2DArr[i, j].Image = picboxBitmapList[i, j][
                                                                        (picboxBitmapList[i, j].Count - 1)
                                                                        ];
                                picbox2DArr[i, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                //++i;
                            }
                        }
                        //if (i != 4)// || i != 5)
                        if (i != playing - 1)
                        {
                            /**
                             * Cover
                             */
                            if (picboxBitmapList[i, j].Count != 0)
                            {
                                picbox2DArr[i, j].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("Back") as Image);
                                //show the topmost card face.
                                picbox2DArr[i, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            }
                        }


                    }

                }
            }//if
            else if (howManyP == 2)
            {
                /**
                 * playing =  1 2
                 *      Show  0 2
                 *      Cover 2 0
                 */
                if (playing == 1)
                {
                    for (int j = 0; j <= 4; j++)
                    {
                        //show
                        if (picboxBitmapList[0, j].Count != 0)
                        {
                            picbox2DArr[0, j].Image = picboxBitmapList[0, j][
                                                                            (picboxBitmapList[0, j].Count - 1)
                                                                            ];
                            picbox2DArr[0, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        }
                        /**
                          * Cover
                          */
                        if (picboxBitmapList[2, j].Count != 0)
                        {
                            picbox2DArr[2, j].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("Back") as Image);
                            //show the topmost card face.
                            picbox2DArr[2, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        }
                    }
                }
                else if (playing == 2)
                {
                    for (int j = 0; j <= 4; j++)
                    {
                        //show
                        if (picboxBitmapList[2, j].Count != 0)
                        {
                            picbox2DArr[2, j].Image = picboxBitmapList[2, j][
                                                                            (picboxBitmapList[2, j].Count - 1)
                                                                            ];
                            picbox2DArr[2, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        }
                        /**
                          * Cover
                          */
                        if (picboxBitmapList[0, j].Count != 0)
                        {
                            picbox2DArr[0, j].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("Back") as Image);
                            //show the topmost card face.
                            picbox2DArr[0, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        }
                    }
                }

            }//else if (howManyP == 2)
        }

        //next player button.
        private void button3_Click(object sender, EventArgs e)
        {
            switch (playing)
            {
                case 1:
                    if (!dropped1)
                    {
                        MessageBox.Show("Please Drop card to 4-card Position before you finish.");
                    }
                    break;
                case 2:
                    if (!dropped2)
                    {
                        MessageBox.Show("Please Drop card to 4-card Position before you finish.");
                    }
                    break;
                case 3:
                    if (!dropped3)
                    {
                        MessageBox.Show("Please Drop card to 4-card Position before you finish.");
                    }
                    break;
                case 4:
                    if (!dropped4)
                    {
                        MessageBox.Show("Please Drop card to 4-card Position before you finish.");
                    }
                    break;
            }

            if (doNotShuffleAgain == true && (dropped1 || dropped2 || dropped3 || dropped4))
            {
                


                dropped1 = false;
                dropped2 = false;
                dropped3 = false;
                dropped4 = false;

                /**
                 * make sure that Playing is looping in 1, 2, 3, 4, 1, 2, 3...
                 */
                playing++;
                playing = playing % (howManyP + 1);
                if (playing == 0)
                {
                    playing++;
                }
                //debugging
                //Console.WriteLine("playing = {0}", playing);





                coverNonPlayingCards();

                //show Playing icon.
                if (playing == 1)
                {
                    labelplaying1.Visible = true;
                    labelplaying2.Visible = false;
                    labelplaying3.Visible = false;
                    labelplaying4.Visible = false;
                }
                else if (playing == 2)
                {
                    labelplaying1.Visible = false;
                    labelplaying2.Visible = true;
                    labelplaying3.Visible = false;
                    labelplaying4.Visible = false;
                }
                else if (playing == 3)
                {
                    labelplaying1.Visible = false;
                    labelplaying2.Visible = false;
                    labelplaying3.Visible = true;
                    labelplaying4.Visible = false;
                }
                else if (playing == 4)
                {
                    labelplaying1.Visible = false;
                    labelplaying2.Visible = false;
                    labelplaying3.Visible = false;
                    labelplaying4.Visible = true;
                }


                /**
                * Check & forcing fill cards.
                */
                forceRefill(playing);

            }
        }//coverNonPlayingCards



        private void forceRefill(int playing)
        {
            //check 5 position.
            for (int i = 0; i <= 4; i++)
            {
                if (picboxBitmapList[(playing - 1), i].Count == 0)
                {
                    MessageBox.Show("Please Refill your cards!");
                    break;
                }

            }

            //force to dispose A.
            //A could be in 5 position, 4 position and 21 position.
            for (int i = 0; i <= 9; i++)
            {

                if (picboxBitmapList[(playing - 1), i].Count != 0 && picboxBitmapList[(playing - 1), i][
                                                        (picboxBitmapList[(playing - 1), i].Count - 1)
                                                        ].Tag.Equals(1) &&
                                                        (picboxBitmapList[4, 0].Count == 0 || picboxBitmapList[4, 1].Count == 0 ||
                                                        picboxBitmapList[4, 2].Count == 0 || picboxBitmapList[4, 3].Count == 0))
                {
                    MessageBox.Show("Please drop your \"A\" first!");

                    break;
                }
                //foreach (Bitmap item in picboxBitmapList[(playing - 1), i])
                //{
                //    if (item.Tag.Equals(1))
                //    {
                //        MessageBox.Show("Please drop your \"A\" first!");
                        
                //        break;
                //    }




                

                //}

                //debug
                if (picboxBitmapList[(playing - 1), i].Count != 0)
                {
                    Console.WriteLine("Item.tag: {0}", picboxBitmapList[(playing - 1), i][
                        (picboxBitmapList[(playing - 1), i].Count - 1)
                        ].Tag);
                }
            }
        }

        /**
         * Update scores after every drag drop event.
         */
        private void updateScore(){
            switch (playing)
            {
                case 1:
                    p1s += 4;
                    labelP1S.Text = p1s.ToString();
                    break;
                case 2:
                    p2s += 4;
                    labelP2S.Text = p2s.ToString();
                    break;
                case 3:
                    p3s += 4;
                    labelP3S.Text = p3s.ToString();
                    break;
                case 4:
                    p4s += 4;
                    labelP4S.Text = p4s.ToString();
                    break;
            }
        }












        /**
         * Regarding the Drag Drop Events
         */
        //00
        private void picbox2DArr00_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 1)
            {
                var img = picbox2DArr[0, 0].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[0, 0].RemoveAt(picboxBitmapList[0, 0].Count - 1);
                    if (picboxBitmapList[0, 0].Count != 0)
                        picbox2DArr[0, 0].Image = picboxBitmapList[0, 0][(picboxBitmapList[0, 0].Count - 1)];
                    else
                        picbox2DArr[0, 0].Image = null;
                }
            }
        }
        void picbox2DArr00_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 1)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr00_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 1)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[0, 0].Add(bmp);
                picbox2DArr[0, 0].Image = picboxBitmapList[0, 0][(picboxBitmapList[0, 0].Count - 1)];
            }
        }

        //01
        private void picbox2DArr01_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 1)
            {
                var img = picbox2DArr[0, 1].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[0, 1].RemoveAt(picboxBitmapList[0, 1].Count - 1);
                    if (picboxBitmapList[0, 1].Count != 0)
                        picbox2DArr[0, 1].Image = picboxBitmapList[0, 1][(picboxBitmapList[0, 1].Count - 1)];
                    else
                        picbox2DArr[0, 1].Image = null;
                }
            }
        }
        void picbox2DArr01_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 1)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr01_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 1)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[0, 1].Add(bmp);
                picbox2DArr[0, 1].Image = picboxBitmapList[0, 1][(picboxBitmapList[0, 1].Count - 1)];
            }
        }

        //02
        private void picbox2DArr02_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 1)
            {
                var img = picbox2DArr[0, 2].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[0, 2].RemoveAt(picboxBitmapList[0, 2].Count - 1);
                    if (picboxBitmapList[0, 2].Count != 0)
                        picbox2DArr[0, 2].Image = picboxBitmapList[0, 2][(picboxBitmapList[0, 2].Count - 1)];
                    else
                        picbox2DArr[0, 2].Image = null;
                }
            }
        }
        void picbox2DArr02_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 1)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr02_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 1)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[0, 2].Add(bmp);
                picbox2DArr[0, 2].Image = picboxBitmapList[0, 2][(picboxBitmapList[0, 2].Count - 1)];
            }
        }

        //03
        private void picbox2DArr03_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 1)
            {
                var img = picbox2DArr[0, 3].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[0, 3].RemoveAt(picboxBitmapList[0, 3].Count - 1);
                    if (picboxBitmapList[0, 3].Count != 0)
                        picbox2DArr[0, 3].Image = picboxBitmapList[0, 3][(picboxBitmapList[0, 3].Count - 1)];
                    else
                        picbox2DArr[0, 3].Image = null;
                }
            }
        }
        void picbox2DArr03_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 1)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr03_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 1)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[0, 3].Add(bmp);
                picbox2DArr[0, 3].Image = picboxBitmapList[0, 3][(picboxBitmapList[0, 3].Count - 1)];
            }
        }

        //04
        private void picbox2DArr04_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 1)
            {
                var img = picbox2DArr[0, 4].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[0, 4].RemoveAt(picboxBitmapList[0, 4].Count - 1);
                    if (picboxBitmapList[0, 4].Count != 0)
                        picbox2DArr[0, 4].Image = picboxBitmapList[0, 4][(picboxBitmapList[0, 4].Count - 1)];
                    else
                        picbox2DArr[0, 4].Image = null;
                }
            }
        }
        void picbox2DArr04_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 1)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr04_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 1)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[0, 4].Add(bmp);
                picbox2DArr[0, 4].Image = picboxBitmapList[0, 4][(picboxBitmapList[0, 4].Count - 1)];
            }
        }

        //05
        private void picbox2DArr05_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 1)
            {
                var img = picbox2DArr[0, 5].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[0, 5].RemoveAt(picboxBitmapList[0, 5].Count - 1);
                    if (picboxBitmapList[0, 5].Count != 0)
                        picbox2DArr[0, 5].Image = picboxBitmapList[0, 5][(picboxBitmapList[0, 5].Count - 1)];
                    else
                        picbox2DArr[0, 5].Image = null;
                }
            }
        }
        void picbox2DArr05_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 1)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr05_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 1)
            {
                dropped1 = true;
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[0, 5].Add(bmp);
                picbox2DArr[0, 5].Image = picboxBitmapList[0, 5][(picboxBitmapList[0, 5].Count - 1)];
            }
        }

        //06
        private void picbox2DArr06_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 1)
            {
                var img = picbox2DArr[0, 6].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[0, 6].RemoveAt(picboxBitmapList[0, 6].Count - 1);
                    if (picboxBitmapList[0, 6].Count != 0)
                        picbox2DArr[0, 6].Image = picboxBitmapList[0, 6][(picboxBitmapList[0, 6].Count - 1)];
                    else
                        picbox2DArr[0, 6].Image = null;
                }
            }
        }
        void picbox2DArr06_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 1)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr06_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 1)
            {
                dropped1 = true;
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[0, 6].Add(bmp);
                picbox2DArr[0, 6].Image = picboxBitmapList[0, 6][(picboxBitmapList[0, 6].Count - 1)];
            }
        }

        //07
        private void picbox2DArr07_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 1)
            {
                var img = picbox2DArr[0, 7].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[0, 7].RemoveAt(picboxBitmapList[0, 7].Count - 1);
                    if (picboxBitmapList[0, 7].Count != 0)
                        picbox2DArr[0, 7].Image = picboxBitmapList[0, 7][(picboxBitmapList[0, 7].Count - 1)];
                    else
                        picbox2DArr[0, 7].Image = null;
                }
            }
        }
        void picbox2DArr07_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 1)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr07_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 1)
            {
                dropped1 = true;
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[0, 7].Add(bmp);
                picbox2DArr[0, 7].Image = picboxBitmapList[0, 7][(picboxBitmapList[0, 7].Count - 1)];
            }
        }

        //08
        private void picbox2DArr08_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 1)
            {
                var img = picbox2DArr[0, 8].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[0, 8].RemoveAt(picboxBitmapList[0, 8].Count - 1);
                    if (picboxBitmapList[0, 8].Count != 0)
                        picbox2DArr[0, 8].Image = picboxBitmapList[0, 8][(picboxBitmapList[0, 8].Count - 1)];
                    else
                        picbox2DArr[0, 8].Image = null;
                }
            }
        }
        void picbox2DArr08_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 1)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr08_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 1)
            {
                dropped1 = true;
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[0, 8].Add(bmp);
                picbox2DArr[0, 8].Image = picboxBitmapList[0, 8][(picboxBitmapList[0, 8].Count - 1)];
            }
        }

        //09
        private void picbox2DArr09_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 1)
            {
                var img = picbox2DArr[0, 9].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[0, 9].RemoveAt(picboxBitmapList[0, 9].Count - 1);
                    if (picboxBitmapList[0, 9].Count != 0)
                        picbox2DArr[0, 9].Image = picboxBitmapList[0, 9][(picboxBitmapList[0, 9].Count - 1)];
                    else
                        picbox2DArr[0, 9].Image = null;
                }
                //Modify the label number.
                label021.Text = picboxBitmapList[0, 9].Count.ToString();
                if (picboxBitmapList[0, 9].Count == 0)
                {
                    MessageBox.Show("Player 1 Won this Game!");
                    System.Windows.Forms.Application.Exit();
                }
            }
            
        }
        void picbox2DArr09_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 1)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr09_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 1)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[0, 9].Add(bmp);
                picbox2DArr[0, 9].Image = picboxBitmapList[0, 9][(picboxBitmapList[0, 9].Count - 1)];
            }
        }

        //10
        private void picbox2DArr10_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 2)
            {
                var img = picbox2DArr[1, 0].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[1, 0].RemoveAt(picboxBitmapList[1, 0].Count - 1);
                    if (picboxBitmapList[1, 0].Count != 0)
                        picbox2DArr[1, 0].Image = picboxBitmapList[1, 0][(picboxBitmapList[1, 0].Count - 1)];
                    else
                        picbox2DArr[1, 0].Image = null;
                }
            }
        }
        void picbox2DArr10_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 2)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr10_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 2)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[1, 0].Add(bmp);
                picbox2DArr[1, 0].Image = picboxBitmapList[1, 0][(picboxBitmapList[1, 0].Count - 1)];
            }
        }

        //11
        private void picbox2DArr11_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 2)
            {
                var img = picbox2DArr[1, 1].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[1, 1].RemoveAt(picboxBitmapList[1, 1].Count - 1);
                    if (picboxBitmapList[1, 1].Count != 0)
                        picbox2DArr[1, 1].Image = picboxBitmapList[1, 1][(picboxBitmapList[1, 1].Count - 1)];
                    else
                        picbox2DArr[1, 1].Image = null;
                }
            }
        }
        void picbox2DArr11_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 2)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr11_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 2)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[1, 1].Add(bmp);
                picbox2DArr[1, 1].Image = picboxBitmapList[1, 1][(picboxBitmapList[1, 1].Count - 1)];
            }
        }

        //12
        private void picbox2DArr12_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 2)
            {
                var img = picbox2DArr[1, 2].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[1, 2].RemoveAt(picboxBitmapList[1, 2].Count - 1);
                    if (picboxBitmapList[1, 2].Count != 0)
                        picbox2DArr[1, 2].Image = picboxBitmapList[1, 2][(picboxBitmapList[1, 2].Count - 1)];
                    else
                        picbox2DArr[1, 2].Image = null;
                }
            }
        }
        void picbox2DArr12_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 2)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr12_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 2)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[1, 2].Add(bmp);
                picbox2DArr[1, 2].Image = picboxBitmapList[1, 2][(picboxBitmapList[1, 2].Count - 1)];
            }
        }

        //13
        private void picbox2DArr13_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 2)
            {
                var img = picbox2DArr[1, 3].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[1, 3].RemoveAt(picboxBitmapList[1, 3].Count - 1);
                    if (picboxBitmapList[1, 3].Count != 0)
                        picbox2DArr[1, 3].Image = picboxBitmapList[1, 3][(picboxBitmapList[1, 3].Count - 1)];
                    else
                        picbox2DArr[1, 3].Image = null;
                }
            }
        }
        void picbox2DArr13_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 2)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr13_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 2)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[1, 3].Add(bmp);
                picbox2DArr[1, 3].Image = picboxBitmapList[1, 3][(picboxBitmapList[1, 3].Count - 1)];
            }
        }

        //14
        private void picbox2DArr14_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 2)
            {
                var img = picbox2DArr[1, 4].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[1, 4].RemoveAt(picboxBitmapList[1, 4].Count - 1);
                    if (picboxBitmapList[1, 4].Count != 0)
                        picbox2DArr[1, 4].Image = picboxBitmapList[1, 4][(picboxBitmapList[1, 4].Count - 1)];
                    else
                        picbox2DArr[1, 4].Image = null;
                }
            }
        }
        void picbox2DArr14_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 2)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr14_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 2)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[1, 4].Add(bmp);
                picbox2DArr[1, 4].Image = picboxBitmapList[1, 4][(picboxBitmapList[1, 4].Count - 1)];
            }
        }

        //15
        private void picbox2DArr15_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 2)
            {
                var img = picbox2DArr[1, 5].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[1, 5].RemoveAt(picboxBitmapList[1, 5].Count - 1);
                    if (picboxBitmapList[1, 5].Count != 0)
                        picbox2DArr[1, 5].Image = picboxBitmapList[1, 5][(picboxBitmapList[1, 5].Count - 1)];
                    else
                        picbox2DArr[1, 5].Image = null;
                }
            }
        }
        void picbox2DArr15_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 2)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr15_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 2)
            {
                dropped2 = true;
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[1, 5].Add(bmp);
                picbox2DArr[1, 5].Image = picboxBitmapList[1, 5][(picboxBitmapList[1, 5].Count - 1)];
            }
        }

        //16
        private void picbox2DArr16_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 2)
            {
                var img = picbox2DArr[1, 6].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[1, 6].RemoveAt(picboxBitmapList[1, 6].Count - 1);
                    if (picboxBitmapList[1, 6].Count != 0)
                        picbox2DArr[1, 6].Image = picboxBitmapList[1, 6][(picboxBitmapList[1, 6].Count - 1)];
                    else
                        picbox2DArr[1, 6].Image = null;
                }
            }
        }
        void picbox2DArr16_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 2)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr16_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 2)
            {
                dropped2 = true;
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[1, 6].Add(bmp);
                picbox2DArr[1, 6].Image = picboxBitmapList[1, 6][(picboxBitmapList[1, 6].Count - 1)];
            }
        }

        //17
        private void picbox2DArr17_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 2)
            {
                var img = picbox2DArr[1, 7].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[1, 7].RemoveAt(picboxBitmapList[1, 7].Count - 1);
                    if (picboxBitmapList[1, 7].Count != 0)
                        picbox2DArr[1, 7].Image = picboxBitmapList[1, 7][(picboxBitmapList[1, 7].Count - 1)];
                    else
                        picbox2DArr[1, 7].Image = null;
                }
            }
        }
        void picbox2DArr17_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 2)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr17_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 2)
            {
                dropped2 = true;
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[1, 7].Add(bmp);
                picbox2DArr[1, 7].Image = picboxBitmapList[1, 7][(picboxBitmapList[1, 7].Count - 1)];
            }
        }

        //18
        private void picbox2DArr18_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 2)
            {
                var img = picbox2DArr[1, 8].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[1, 8].RemoveAt(picboxBitmapList[1, 8].Count - 1);
                    if (picboxBitmapList[1, 8].Count != 0)
                        picbox2DArr[1, 8].Image = picboxBitmapList[1, 8][(picboxBitmapList[1, 8].Count - 1)];
                    else
                        picbox2DArr[1, 8].Image = null;
                }
            }
        }
        void picbox2DArr18_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 2)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr18_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 2)
            {
                dropped2 = true;
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[1, 8].Add(bmp);
                picbox2DArr[1, 8].Image = picboxBitmapList[1, 8][(picboxBitmapList[1, 8].Count - 1)];
            }
        }

        //19
        private void picbox2DArr19_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 2)
            {
                var img = picbox2DArr[1, 9].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[1, 9].RemoveAt(picboxBitmapList[1, 9].Count - 1);
                    if (picboxBitmapList[1, 9].Count != 0)
                        picbox2DArr[1, 9].Image = picboxBitmapList[1, 9][(picboxBitmapList[1, 9].Count - 1)];
                    else
                        picbox2DArr[1, 9].Image = null;
                }
                //Modify the label number.
                label121.Text = picboxBitmapList[1, 9].Count.ToString();
                if (picboxBitmapList[1, 9].Count == 0)
                {
                    MessageBox.Show("Player 2 Won this Game!");
                    System.Windows.Forms.Application.Exit();
                }
            }
           
        }
        void picbox2DArr19_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 2)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr19_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 2)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[1, 9].Add(bmp);
                picbox2DArr[1, 9].Image = picboxBitmapList[1, 9][(picboxBitmapList[1, 9].Count - 1)];
            }
        }

        //20
        private void picbox2DArr20_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 3)
            {
                var img = picbox2DArr[2, 0].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[2, 0].RemoveAt(picboxBitmapList[2, 0].Count - 1);
                    if (picboxBitmapList[2, 0].Count != 0)
                        picbox2DArr[2, 0].Image = picboxBitmapList[2, 0][(picboxBitmapList[2, 0].Count - 1)];
                    else
                        picbox2DArr[2, 0].Image = null;
                }
            }
        }
        void picbox2DArr20_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 3)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr20_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 3)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[2, 0].Add(bmp);
                picbox2DArr[2, 0].Image = picboxBitmapList[2, 0][(picboxBitmapList[2, 0].Count - 1)];
            }
        }

        //21
        private void picbox2DArr21_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 3)
            {
                var img = picbox2DArr[2, 1].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[2, 1].RemoveAt(picboxBitmapList[2, 1].Count - 1);
                    if (picboxBitmapList[2, 1].Count != 0)
                        picbox2DArr[2, 1].Image = picboxBitmapList[2, 1][(picboxBitmapList[2, 1].Count - 1)];
                    else
                        picbox2DArr[2, 1].Image = null;
                }
            }
        }
        void picbox2DArr21_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 3)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr21_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 3)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[2, 1].Add(bmp);
                picbox2DArr[2, 1].Image = picboxBitmapList[2, 1][(picboxBitmapList[2, 1].Count - 1)];
            }
        }

        //22
        private void picbox2DArr22_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 3)
            {
                var img = picbox2DArr[2, 2].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[2, 2].RemoveAt(picboxBitmapList[2, 2].Count - 1);
                    if (picboxBitmapList[2, 2].Count != 0)
                        picbox2DArr[2, 2].Image = picboxBitmapList[2, 2][(picboxBitmapList[2, 2].Count - 1)];
                    else
                        picbox2DArr[2, 2].Image = null;
                }
            }
        }
        void picbox2DArr22_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 3)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr22_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 3)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[2, 2].Add(bmp);
                picbox2DArr[2, 2].Image = picboxBitmapList[2, 2][(picboxBitmapList[2, 2].Count - 1)];
            }
        }

        //23
        private void picbox2DArr23_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 3)
            {
                var img = picbox2DArr[2, 3].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[2, 3].RemoveAt(picboxBitmapList[2, 3].Count - 1);
                    if (picboxBitmapList[2, 3].Count != 0)
                        picbox2DArr[2, 3].Image = picboxBitmapList[2, 3][(picboxBitmapList[2, 3].Count - 1)];
                    else
                        picbox2DArr[2, 3].Image = null;
                }
            }
        }
        void picbox2DArr23_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 3)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr23_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 3)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[2, 3].Add(bmp);
                picbox2DArr[2, 3].Image = picboxBitmapList[2, 3][(picboxBitmapList[2, 3].Count - 1)];
            }
        }

        //24
        private void picbox2DArr24_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 3)
            {
                var img = picbox2DArr[2, 4].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[2, 4].RemoveAt(picboxBitmapList[2, 4].Count - 1);
                    if (picboxBitmapList[2, 4].Count != 0)
                        picbox2DArr[2, 4].Image = picboxBitmapList[2, 4][(picboxBitmapList[2, 4].Count - 1)];
                    else
                        picbox2DArr[2, 4].Image = null;
                }
            }
        }
        void picbox2DArr24_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 3)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr24_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 3)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[2, 4].Add(bmp);
                picbox2DArr[2, 4].Image = picboxBitmapList[2, 4][(picboxBitmapList[2, 4].Count - 1)];
            }
        }

        //25
        private void picbox2DArr25_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 3)
            {
                var img = picbox2DArr[2, 5].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[2, 5].RemoveAt(picboxBitmapList[2, 5].Count - 1);
                    if (picboxBitmapList[2, 5].Count != 0)
                        picbox2DArr[2, 5].Image = picboxBitmapList[2, 5][(picboxBitmapList[2, 5].Count - 1)];
                    else
                        picbox2DArr[2, 5].Image = null;
                }
            }
        }
        void picbox2DArr25_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 3)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr25_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 3)
            {
                dropped3 = true;
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[2, 5].Add(bmp);
                picbox2DArr[2, 5].Image = picboxBitmapList[2, 5][(picboxBitmapList[2, 5].Count - 1)];
            }
        }

        //26
        private void picbox2DArr26_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 3)
            {
                var img = picbox2DArr[2, 6].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[2, 6].RemoveAt(picboxBitmapList[2, 6].Count - 1);
                    if (picboxBitmapList[2, 6].Count != 0)
                        picbox2DArr[2, 6].Image = picboxBitmapList[2, 6][(picboxBitmapList[2, 6].Count - 1)];
                    else
                        picbox2DArr[2, 6].Image = null;
                }
            }
        }
        void picbox2DArr26_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 3)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr26_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 3)
            {
                dropped3 = true;
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[2, 6].Add(bmp);
                picbox2DArr[2, 6].Image = picboxBitmapList[2, 6][(picboxBitmapList[2, 6].Count - 1)];
            }
        }

        //27
        private void picbox2DArr27_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 3)
            {
                var img = picbox2DArr[2, 7].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[2, 7].RemoveAt(picboxBitmapList[2, 7].Count - 1);
                    if (picboxBitmapList[2, 7].Count != 0)
                        picbox2DArr[2, 7].Image = picboxBitmapList[2, 7][(picboxBitmapList[2, 7].Count - 1)];
                    else
                        picbox2DArr[2, 7].Image = null;
                }
            }
        }
        void picbox2DArr27_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 3)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr27_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 3)
            {
                dropped3 = true;
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[2, 7].Add(bmp);
                picbox2DArr[2, 7].Image = picboxBitmapList[2, 7][(picboxBitmapList[2, 7].Count - 1)];
            }
        }

        //28
        private void picbox2DArr28_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 3)
            {
                var img = picbox2DArr[2, 8].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[2, 8].RemoveAt(picboxBitmapList[2, 8].Count - 1);
                    if (picboxBitmapList[2, 8].Count != 0)
                        picbox2DArr[2, 8].Image = picboxBitmapList[2, 8][(picboxBitmapList[2, 8].Count - 1)];
                    else
                        picbox2DArr[2, 8].Image = null;
                }
            }
        }
        void picbox2DArr28_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 3)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr28_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 3)
            {
                dropped3 = true;
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[2, 8].Add(bmp);
                picbox2DArr[2, 8].Image = picboxBitmapList[2, 8][(picboxBitmapList[2, 8].Count - 1)];
            }
        }

        //29
        private void picbox2DArr29_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 3)
            {
                var img = picbox2DArr[2, 9].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[2, 9].RemoveAt(picboxBitmapList[2, 9].Count - 1);
                    if (picboxBitmapList[2, 9].Count != 0)
                        picbox2DArr[2, 9].Image = picboxBitmapList[2, 9][(picboxBitmapList[2, 9].Count - 1)];
                    else
                        picbox2DArr[2, 9].Image = null;
                }
                //Modify the label number.
                label221.Text = picboxBitmapList[2, 9].Count.ToString();
                if (picboxBitmapList[2, 9].Count == 0)
                {
                    MessageBox.Show("Player 3 Won this Game!");
                    System.Windows.Forms.Application.Exit();
                }
            }
            
        }
        void picbox2DArr29_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 3)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr29_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 3)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[2, 9].Add(bmp);
                picbox2DArr[2, 9].Image = picboxBitmapList[2, 9][(picboxBitmapList[2, 9].Count - 1)];
            }
        }

        //30
        private void picbox2DArr30_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 4)
            {
                var img = picbox2DArr[3, 0].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[3, 0].RemoveAt(picboxBitmapList[3, 0].Count - 1);
                    if (picboxBitmapList[3, 0].Count != 0)
                        picbox2DArr[3, 0].Image = picboxBitmapList[3, 0][(picboxBitmapList[3, 0].Count - 1)];
                    else
                        picbox2DArr[3, 0].Image = null;
                }
            }
        }
        void picbox2DArr30_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 4)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr30_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 4)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[3, 0].Add(bmp);
                picbox2DArr[3, 0].Image = picboxBitmapList[3, 0][(picboxBitmapList[3, 0].Count - 1)];
            }
        }

        //31
        private void picbox2DArr31_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 4)
            {
                var img = picbox2DArr[3, 1].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[3, 1].RemoveAt(picboxBitmapList[3, 1].Count - 1);
                    if (picboxBitmapList[3, 1].Count != 0)
                        picbox2DArr[3, 1].Image = picboxBitmapList[3, 1][(picboxBitmapList[3, 1].Count - 1)];
                    else
                        picbox2DArr[3, 1].Image = null;
                }
            }
        }
        void picbox2DArr31_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 4)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr31_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 4)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[3, 1].Add(bmp);
                picbox2DArr[3, 1].Image = picboxBitmapList[3, 1][(picboxBitmapList[3, 1].Count - 1)];
            }
        }

        //32
        private void picbox2DArr32_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 4)
            {
                var img = picbox2DArr[3, 2].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[3, 2].RemoveAt(picboxBitmapList[3, 2].Count - 1);
                    if (picboxBitmapList[3, 2].Count != 0)
                        picbox2DArr[3, 2].Image = picboxBitmapList[3, 2][(picboxBitmapList[3, 2].Count - 1)];
                    else
                        picbox2DArr[3, 2].Image = null;
                }
            }
        }
        void picbox2DArr32_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 4)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr32_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 4)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[3, 2].Add(bmp);
                picbox2DArr[3, 2].Image = picboxBitmapList[3, 2][(picboxBitmapList[3, 2].Count - 1)];
            }
        }

        //33
        private void picbox2DArr33_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 4)
            {
                var img = picbox2DArr[3, 3].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[3, 3].RemoveAt(picboxBitmapList[3, 3].Count - 1);
                    if (picboxBitmapList[3, 3].Count != 0)
                        picbox2DArr[3, 3].Image = picboxBitmapList[3, 3][(picboxBitmapList[3, 3].Count - 1)];
                    else
                        picbox2DArr[3, 3].Image = null;
                }
            }
        }
        void picbox2DArr33_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 4)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr33_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 4)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[3, 3].Add(bmp);
                picbox2DArr[3, 3].Image = picboxBitmapList[3, 3][(picboxBitmapList[3, 3].Count - 1)];
            }
        }

        //34
        private void picbox2DArr34_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 4)
            {
                var img = picbox2DArr[3, 4].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[3, 4].RemoveAt(picboxBitmapList[3, 4].Count - 1);
                    if (picboxBitmapList[3, 4].Count != 0)
                        picbox2DArr[3, 4].Image = picboxBitmapList[3, 4][(picboxBitmapList[3, 4].Count - 1)];
                    else
                        picbox2DArr[3, 4].Image = null;
                }
            }
        }
        void picbox2DArr34_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 4)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr34_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 4)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[3, 4].Add(bmp);
                picbox2DArr[3, 4].Image = picboxBitmapList[3, 4][(picboxBitmapList[3, 4].Count - 1)];
            }
        }

        //35
        private void picbox2DArr35_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 4)
            {
                var img = picbox2DArr[3, 5].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[3, 5].RemoveAt(picboxBitmapList[3, 5].Count - 1);
                    if (picboxBitmapList[3, 5].Count != 0)
                        picbox2DArr[3, 5].Image = picboxBitmapList[3, 5][(picboxBitmapList[3, 5].Count - 1)];
                    else
                        picbox2DArr[3, 5].Image = null;
                }
            }
        }
        void picbox2DArr35_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 4)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr35_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 4)
            {
                dropped4 = true;
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[3, 5].Add(bmp);
                picbox2DArr[3, 5].Image = picboxBitmapList[3, 5][(picboxBitmapList[3, 5].Count - 1)];
            }
        }

        //36
        private void picbox2DArr36_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 4)
            {
                var img = picbox2DArr[3, 6].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[3, 6].RemoveAt(picboxBitmapList[3, 6].Count - 1);
                    if (picboxBitmapList[3, 6].Count != 0)
                        picbox2DArr[3, 6].Image = picboxBitmapList[3, 6][(picboxBitmapList[3, 6].Count - 1)];
                    else
                        picbox2DArr[3, 6].Image = null;
                }
            }
        }
        void picbox2DArr36_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 4)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr36_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 4)
            {
                dropped4 = true;
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[3, 6].Add(bmp);
                picbox2DArr[3, 6].Image = picboxBitmapList[3, 6][(picboxBitmapList[3, 6].Count - 1)];
            }
        }

        //37
        private void picbox2DArr37_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 4)
            {
                var img = picbox2DArr[3, 7].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[3, 7].RemoveAt(picboxBitmapList[3, 7].Count - 1);
                    if (picboxBitmapList[3, 7].Count != 0)
                        picbox2DArr[3, 7].Image = picboxBitmapList[3, 7][(picboxBitmapList[3, 7].Count - 1)];
                    else
                        picbox2DArr[3, 7].Image = null;
                }
            }
        }
        void picbox2DArr37_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 4)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr37_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 4)
            {
                dropped4 = true;
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[3, 7].Add(bmp);
                picbox2DArr[3, 7].Image = picboxBitmapList[3, 7][(picboxBitmapList[3, 7].Count - 1)];
            }
        }

        //38
        private void picbox2DArr38_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 4)
            {
                var img = picbox2DArr[3, 8].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[3, 8].RemoveAt(picboxBitmapList[3, 8].Count - 1);
                    if (picboxBitmapList[3, 8].Count != 0)
                        picbox2DArr[3, 8].Image = picboxBitmapList[3, 8][(picboxBitmapList[3, 8].Count - 1)];
                    else
                        picbox2DArr[3, 8].Image = null;
                }
            }
        }
        void picbox2DArr38_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 4)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr38_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 4)
            {
                dropped4 = true;
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[3, 8].Add(bmp);
                picbox2DArr[3, 8].Image = picboxBitmapList[3, 8][(picboxBitmapList[3, 8].Count - 1)];
            }
        }

        //39
        private void picbox2DArr39_MouseDown(object sender, MouseEventArgs e)
        {
            if (playing == 4)
            {
                var img = picbox2DArr[3, 9].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[3, 9].RemoveAt(picboxBitmapList[3, 9].Count - 1);
                    if (picboxBitmapList[3, 9].Count != 0)
                        picbox2DArr[3, 9].Image = picboxBitmapList[3, 9][(picboxBitmapList[3, 9].Count - 1)];
                    else
                        picbox2DArr[3, 9].Image = null;
                }
                //Modify the label number.
                label321.Text = picboxBitmapList[3, 9].Count.ToString();
                if (picboxBitmapList[3, 9].Count == 0)
                {
                    MessageBox.Show("Player 4 Won this Game!");
                    System.Windows.Forms.Application.Exit();
                }
            }
        }
        void picbox2DArr39_DragEnter(object sender, DragEventArgs e)
        {
            if (playing == 4)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            }
        }
        void picbox2DArr39_DragDrop(object sender, DragEventArgs e)
        {
            if (playing == 4)
            {
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[3, 9].Add(bmp);
                picbox2DArr[3, 9].Image = picboxBitmapList[3, 9][(picboxBitmapList[3, 9].Count - 1)];
            }
        }

        //40 Modify the label number.
        /**
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
                        picbox2DArr[4, 0].Image = null;
                }
                //Modify the label number.
                label0.Text = picboxBitmapList[4, 0].Count.ToString();
        }
         */
        void picbox2DArr40_DragEnter(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            Console.WriteLine("card tag: {0}", bmp.Tag);
            //if (e.Data.GetDataPresent(DataFormats.Bitmap))
            //    e.Effect = DragDropEffects.Move;
            if ((picboxBitmapList[4, 0].Count == 0 && Convert.ToInt32(bmp.Tag) == 1)
                || (Convert.ToInt32(bmp.Tag) >= 13 && Convert.ToInt32(label0.Text) != 0)
                || (Convert.ToInt32(bmp.Tag) == Convert.ToInt32(label0.Text) + 1))
            {
                e.Effect = DragDropEffects.Move;
            }
            
        }
        
        void picbox2DArr40_DragDrop(object sender, DragEventArgs e)
        {
            

                
                //bmp.Tag.Equals(13) || bmp.Tag.Equals(14)
            //bmp.Tag.Equals(picboxBitmapList[4, 0][(picboxBitmapList[4, 0].Count - 1)].Tag + 1)

                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                //int ijc = Convert.ToInt32(bmp.Tag);

                
                //if (picboxBitmapList[4, 0].Count == 0 || Convert.ToInt32(bmp.Tag) >= 13 || Convert.ToInt32(bmp.Tag) == Convert.ToInt32(picboxBitmapList[4, 0][(picboxBitmapList[4, 0].Count - 1)].Tag) + 1)
                //{


                    picboxBitmapList[4, 0].Add(bmp);
                    picbox2DArr[4, 0].Image = picboxBitmapList[4, 0][(picboxBitmapList[4, 0].Count - 1)];

                    //Modify the label number.
                    label0.Text = picboxBitmapList[4, 0].Count.ToString();

                    picbox2DArr[4, 0].Refresh();

                    if (picboxBitmapList[4, 0].Count == 12)
                    {
                        picboxBitmapList[4, 0].Clear();
                        System.Threading.Thread.Sleep(1000);

                        picbox2DArr[4, 0].Image = null;
                        picbox2DArr[4, 0].Refresh();
                    }

                    updateScore();
                    //Modify the label number.
                    label0.Text = picboxBitmapList[4, 0].Count.ToString();
                //}

            //}
        }

        //41
        /**
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
                        picbox2DArr[4, 1].Image = null;
                }
                //Modify the label number.
                label1.Text = picboxBitmapList[4, 1].Count.ToString();
            
        }
         */
        void picbox2DArr41_DragEnter(object sender, DragEventArgs e)
        {
            
                //if (e.Data.GetDataPresent(DataFormats.Bitmap))
                //    e.Effect = DragDropEffects.Move;

                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                Console.WriteLine("card tag: {0}", bmp.Tag);
                if ((picboxBitmapList[4, 1].Count == 0 && Convert.ToInt32(bmp.Tag) == 1)
                    || (Convert.ToInt32(bmp.Tag) >= 13 && Convert.ToInt32(label1.Text) != 0)
                    || (Convert.ToInt32(bmp.Tag) == Convert.ToInt32(label1.Text) + 1))
                {
                    e.Effect = DragDropEffects.Move;
                }
        }
        void picbox2DArr41_DragDrop(object sender, DragEventArgs e)
        {
            updateScore();
            
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[4, 1].Add(bmp);
                picbox2DArr[4, 1].Image = picboxBitmapList[4, 1][(picboxBitmapList[4, 1].Count - 1)];
                //Modify the label number.
                label1.Text = picboxBitmapList[4, 1].Count.ToString();

                picbox2DArr[4, 1].Refresh();

                if (picboxBitmapList[4, 1].Count == 12)
                {
                    picboxBitmapList[4, 1].Clear();
                    System.Threading.Thread.Sleep(1000);

                    picbox2DArr[4, 1].Image = null;
                    picbox2DArr[4, 1].Refresh();
                }
                //Modify the label number.
                label1.Text = picboxBitmapList[4, 1].Count.ToString();
        }

        //42
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
                        picbox2DArr[4, 2].Image = null;
                }
                //Modify the label number.
                label2.Text = picboxBitmapList[4, 2].Count.ToString();
            
        }
        void picbox2DArr42_DragEnter(object sender, DragEventArgs e)
        {
            
                //if (e.Data.GetDataPresent(DataFormats.Bitmap))
                //    e.Effect = DragDropEffects.Move;
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            Console.WriteLine("card tag: {0}", bmp.Tag);
            if ((picboxBitmapList[4, 2].Count == 0 && Convert.ToInt32(bmp.Tag) == 1)
                || (Convert.ToInt32(bmp.Tag) >= 13 && Convert.ToInt32(label2.Text) != 0)
                || (Convert.ToInt32(bmp.Tag) == Convert.ToInt32(label2.Text) + 1))
            {
                e.Effect = DragDropEffects.Move;
            }
            
        }
        void picbox2DArr42_DragDrop(object sender, DragEventArgs e)
        {
            updateScore();
           
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[4, 2].Add(bmp);
                picbox2DArr[4, 2].Image = picboxBitmapList[4, 2][(picboxBitmapList[4, 2].Count - 1)];
                //Modify the label number.
                label2.Text = picboxBitmapList[4, 2].Count.ToString();

                picbox2DArr[4, 2].Refresh();

                if (picboxBitmapList[4, 2].Count == 12)
                {
                    picboxBitmapList[4, 2].Clear();
                    System.Threading.Thread.Sleep(1000);

                    picbox2DArr[4, 2].Image = null;
                    picbox2DArr[4, 2].Refresh();
                }

                //Modify the label number.
                label2.Text = picboxBitmapList[4, 2].Count.ToString();
        }

        //43
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
                        picbox2DArr[4, 3].Image = null;
                }
                //Modify the label number.
                label3.Text = picboxBitmapList[4, 3].Count.ToString();
            
        }
        void picbox2DArr43_DragEnter(object sender, DragEventArgs e)
        {
            
                //if (e.Data.GetDataPresent(DataFormats.Bitmap))
                //    e.Effect = DragDropEffects.Move;
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            Console.WriteLine("card tag: {0}", bmp.Tag);
            if ((picboxBitmapList[4, 3].Count == 0 && Convert.ToInt32(bmp.Tag) == 1)
                || (Convert.ToInt32(bmp.Tag) >= 13 && Convert.ToInt32(label3.Text) != 0)
                || (Convert.ToInt32(bmp.Tag) == Convert.ToInt32(label3.Text) + 1))
            {
                e.Effect = DragDropEffects.Move;
            }
            
        }
        void picbox2DArr43_DragDrop(object sender, DragEventArgs e)
        {
            updateScore();
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[4, 3].Add(bmp);
                picbox2DArr[4, 3].Image = picboxBitmapList[4, 3][(picboxBitmapList[4, 3].Count - 1)];
                //Modify the label number.
                label3.Text = picboxBitmapList[4, 3].Count.ToString();

                picbox2DArr[4, 3].Refresh();

                if (picboxBitmapList[4, 3].Count == 12)
                {
                    picboxBitmapList[4, 3].Clear();
                    System.Threading.Thread.Sleep(1000);

                    picbox2DArr[4, 3].Image = null;
                    picbox2DArr[4, 3].Refresh();
                }

                //Modify the label number.
                label3.Text = picboxBitmapList[4, 3].Count.ToString();
        }

        //44 additional showtopmost 5();
        private void picbox2DArr44_MouseDown(object sender, MouseEventArgs e)
        {

            //var img = picbox2DArr[4, 4].Image;
            var img = picboxBitmapList[4, 4][(picboxBitmapList[4, 4].Count - 1)];
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                picboxBitmapList[4, 4].RemoveAt(picboxBitmapList[4, 4].Count - 1);
                if (picboxBitmapList[4, 4].Count != 0)
                    //show the next one
                    //picbox2DArr[4, 4].Image = picboxBitmapList[4, 4][(picboxBitmapList[4, 4].Count - 1)];
                    //show the card back
                    picbox2DArr[4, 4].Image = (Bitmap)(Properties.Resources.ResourceManager.GetObject("Back") as Image);
                else if (picboxBitmapList[4, 4].Count == 0)
                    picbox2DArr[4, 4].Image = null;
            }
            //Modify the label number.
            labelCenter.Text = picboxBitmapList[4, 4].Count.ToString();
            showTopmost5();
            
        }
        //void picbox2DArr44_DragEnter(object sender, DragEventArgs e)
        //{
            
        //        if (e.Data.GetDataPresent(DataFormats.Bitmap))
        //            e.Effect = DragDropEffects.Move;
            
        //}
        //void picbox2DArr44_DragDrop(object sender, DragEventArgs e)
        //{

        //    var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
        //    picboxBitmapList[4, 4].Add(bmp);
        //    picbox2DArr[4, 4].Image = picboxBitmapList[4, 4][(picboxBitmapList[4, 4].Count - 1)];
        //    //Modify the label number.
        //    labelCenter.Text = picboxBitmapList[4, 4].Count.ToString();
            
        //}

        //45
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
                        picbox2DArr[4, 5].Image = null;
                }
            
        }
        void picbox2DArr45_DragEnter(object sender, DragEventArgs e)
        {
            
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            
        }
        void picbox2DArr45_DragDrop(object sender, DragEventArgs e)
        {
            
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[4, 5].Add(bmp);
                picbox2DArr[4, 5].Image = picboxBitmapList[4, 5][(picboxBitmapList[4, 5].Count - 1)];
            
        }

        //46
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
                        picbox2DArr[4, 6].Image = null;
                }
            
        }
        void picbox2DArr46_DragEnter(object sender, DragEventArgs e)
        {
            
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            
        }
        void picbox2DArr46_DragDrop(object sender, DragEventArgs e)
        {
            
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[4, 6].Add(bmp);
                picbox2DArr[4, 6].Image = picboxBitmapList[4, 6][(picboxBitmapList[4, 6].Count - 1)];
            
        }

        //47
        private void picbox2DArr47_MouseDown(object sender, MouseEventArgs e)
        {
            
                var img = picbox2DArr[4, 7].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[4, 7].RemoveAt(picboxBitmapList[4, 7].Count - 1);
                    if (picboxBitmapList[4, 7].Count != 0)
                        picbox2DArr[4, 7].Image = picboxBitmapList[4, 7][(picboxBitmapList[4, 7].Count - 1)];
                    else
                        picbox2DArr[4, 7].Image = null;
                }
            
        }
        void picbox2DArr47_DragEnter(object sender, DragEventArgs e)
        {
            
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            
        }
        void picbox2DArr47_DragDrop(object sender, DragEventArgs e)
        {
            
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[4, 7].Add(bmp);
                picbox2DArr[4, 7].Image = picboxBitmapList[4, 7][(picboxBitmapList[4, 7].Count - 1)];
            
        }

        //48
        private void picbox2DArr48_MouseDown(object sender, MouseEventArgs e)
        {
            
                var img = picbox2DArr[4, 8].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[4, 8].RemoveAt(picboxBitmapList[4, 8].Count - 1);
                    if (picboxBitmapList[4, 8].Count != 0)
                        picbox2DArr[4, 8].Image = picboxBitmapList[4, 8][(picboxBitmapList[4, 8].Count - 1)];
                    else
                        picbox2DArr[4, 8].Image = null;
                }
            
        }
        void picbox2DArr48_DragEnter(object sender, DragEventArgs e)
        {
            
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            
        }
        void picbox2DArr48_DragDrop(object sender, DragEventArgs e)
        {
            
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[4, 8].Add(bmp);
                picbox2DArr[4, 8].Image = picboxBitmapList[4, 8][(picboxBitmapList[4, 8].Count - 1)];
            
        }

        //49
        private void picbox2DArr49_MouseDown(object sender, MouseEventArgs e)
        {
            
                var img = picbox2DArr[4, 9].Image;
                if (img == null) return;
                if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    picboxBitmapList[4, 9].RemoveAt(picboxBitmapList[4, 9].Count - 1);
                    if (picboxBitmapList[4, 9].Count != 0)
                        picbox2DArr[4, 9].Image = picboxBitmapList[4, 9][(picboxBitmapList[4, 9].Count - 1)];
                    else
                        picbox2DArr[4, 9].Image = null;
                }
            }
        
        void picbox2DArr49_DragEnter(object sender, DragEventArgs e)
        {
            
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                    e.Effect = DragDropEffects.Move;
            
        }
        void picbox2DArr49_DragDrop(object sender, DragEventArgs e)
        {
            
                var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                picboxBitmapList[4, 9].Add(bmp);
                picbox2DArr[4, 9].Image = picboxBitmapList[4, 9][(picboxBitmapList[4, 9].Count - 1)];
            
        }


        /**
         * Hover
         */
        private void pictureBox040_MouseHover(object sender, EventArgs e)
        {
            for (int i = 0; i <= 11; i++)
            {
                if (picboxBitmapList[0, 5].Count >= 1 && i < picboxBitmapList[0, 5].Count)
                {
                    picboxShow12[i].Image = picboxBitmapList[0, 5][(picboxBitmapList[0, 5].Count - (i + 1))];
                    //picboxShow12[0].Location = new Point(52, 620);
                    if (i == 0)
                    {
                        picboxShow12[i].Location = new Point(picbox2DArr[0, 5].Location.X + 26, picbox2DArr[0, 5].Location.Y + 32 + 6);
                        picboxShow12[i].Visible = true;
                    }
                    else
                    {
                        picboxShow12[i].Location = new Point(picboxShow12[i - 1].Location.X + 50, picboxShow12[i - 1].Location.Y);
                        picboxShow12[i].Visible = true;
                    }
                }
            }
        }
        private void pictureBox040_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i <= 11; i++)
            {
                picboxShow12[i].Visible = false;
            }
        }

        private void pictureBox041_MouseHover(object sender, EventArgs e){
            for (int i = 0; i <= 11; i++)
            {
                if (picboxBitmapList[0, 6].Count >= 1 && i < picboxBitmapList[0, 6].Count)
                {
                    picboxShow12[i].Image = picboxBitmapList[0, 6][(picboxBitmapList[0, 6].Count - (i + 1))];
                    //picboxShow12[0].Location = new Point(52, 620);
                    if (i == 0)
                    {
                        picboxShow12[i].Location = new Point(picbox2DArr[0, 6].Location.X + 26, picbox2DArr[0, 6].Location.Y + 32 + 6);
                        picboxShow12[i].Visible = true;
                    }
                    else
                    {
                        picboxShow12[i].Location = new Point(picboxShow12[i - 1].Location.X + 50, picboxShow12[i - 1].Location.Y);
                        picboxShow12[i].Visible = true;
                    }
                }
            }
        }



            private void pictureBox041_MouseLeave(object sender, EventArgs e){
                for (int i = 0; i <= 11; i++)
                {
                    picboxShow12[i].Visible = false;
                }
            }

                private void pictureBox042_MouseHover(object sender, EventArgs e){
                    for (int i = 0; i <= 11; i++)
                    {
                        if (picboxBitmapList[0, 7].Count >= 1 && i < picboxBitmapList[0, 7].Count)
                        {
                            picboxShow12[i].Image = picboxBitmapList[0, 7][(picboxBitmapList[0, 7].Count - (i + 1))];
                            //picboxShow12[0].Location = new Point(52, 620);
                            if (i == 0)
                            {
                                picboxShow12[i].Location = new Point(picbox2DArr[0, 7].Location.X + 26, picbox2DArr[0, 7].Location.Y + 32 + 6);
                                picboxShow12[i].Visible = true;
                            }
                            else
                            {
                                picboxShow12[i].Location = new Point(picboxShow12[i - 1].Location.X + 50, picboxShow12[i - 1].Location.Y);
                                picboxShow12[i].Visible = true;
                            }
                        }
                    }
                }
            private void pictureBox042_MouseLeave(object sender, EventArgs e){
                for (int i = 0; i <= 11; i++)
                {
                    picboxShow12[i].Visible = false;
                }
            }

                private void pictureBox043_MouseHover(object sender, EventArgs e){
                    for (int i = 0; i <= 11; i++)
                    {
                        if (picboxBitmapList[0, 8].Count >= 1 && i < picboxBitmapList[0, 8].Count)
                        {
                            picboxShow12[i].Image = picboxBitmapList[0, 8][(picboxBitmapList[0, 8].Count - (i + 1))];
                            //picboxShow12[0].Location = new Point(52, 620);
                            if (i == 0)
                            {
                                picboxShow12[i].Location = new Point(picbox2DArr[0, 8].Location.X + 26, picbox2DArr[0, 8].Location.Y + 32 + 6);
                                picboxShow12[i].Visible = true;
                            }
                            else
                            {
                                picboxShow12[i].Location = new Point(picboxShow12[i - 1].Location.X + 50, picboxShow12[i - 1].Location.Y);
                                picboxShow12[i].Visible = true;
                            }
                        }
                    }
                }
            private void pictureBox043_MouseLeave(object sender, EventArgs e){
                for (int i = 0; i <= 11; i++)
                {
                    picboxShow12[i].Visible = false;
                }
            }
            
            
        private void pictureBox140_MouseHover(object sender, EventArgs e)
        {
            for (int i = 0; i <= 11; i++)
            {
                if (picboxBitmapList[1, 5].Count >= 1 && i < picboxBitmapList[1, 5].Count)
                {
                    picboxShow12[i].Image = picboxBitmapList[1, 5][(  picboxBitmapList[1, 5].Count - (i + 1)  )];
                    //picboxShow12[0].Location = new Point(52, 620);
                    if (i == 0)
                    {
                        picboxShow12[i].Location = new Point(picbox2DArr[1, 5].Location.X + 26, picbox2DArr[1, 5].Location.Y + 32 + 6);
                        picboxShow12[i].Visible = true;
                    }
                    else
                    {
                        picboxShow12[i].Location = new Point(picboxShow12[i - 1].Location.X + 50, picboxShow12[i - 1].Location.Y);
                        picboxShow12[i].Visible = true;
                    }
                }
            }
        }

        private void pictureBox140_MouseLeave(object sender, EventArgs e)
        {
            //Console.WriteLine("mouse leaved.");
            for (int i = 0; i <= 11; i++)
            {
                picboxShow12[i].Visible = false;
            }
        }

        private void pictureBox141_MouseHover(object sender, EventArgs e) {
            for (int i = 0; i <= 11; i++)
            {
                if (picboxBitmapList[1, 6].Count >= 1 && i < picboxBitmapList[1, 6].Count)
                {
                    picboxShow12[i].Image = picboxBitmapList[1, 6][(picboxBitmapList[1, 6].Count - (i + 1))];
                    //picboxShow12[0].Location = new Point(52, 620);
                    if (i == 0)
                    {
                        picboxShow12[i].Location = new Point(picbox2DArr[1, 6].Location.X + 26, picbox2DArr[1, 6].Location.Y + 32 + 6);
                        picboxShow12[i].Visible = true;
                    }
                    else
                    {
                        picboxShow12[i].Location = new Point(picboxShow12[i - 1].Location.X + 50, picboxShow12[i - 1].Location.Y);
                        picboxShow12[i].Visible = true;
                    }
                }
            }
        }
        private void pictureBox141_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i <= 11; i++)
            {
                picboxShow12[i].Visible = false;
            }
        }

        private void pictureBox142_MouseHover(object sender, EventArgs e)
        {
            for (int i = 0; i <= 11; i++)
            {
                if (picboxBitmapList[1, 7].Count >= 1 && i < picboxBitmapList[1, 7].Count)
                {
                    picboxShow12[i].Image = picboxBitmapList[1, 7][(picboxBitmapList[1, 7].Count - (i + 1))];
                    //picboxShow12[0].Location = new Point(52, 620);
                    if (i == 0)
                    {
                        picboxShow12[i].Location = new Point(picbox2DArr[1, 7].Location.X + 26, picbox2DArr[1, 7].Location.Y + 32 + 6);
                        picboxShow12[i].Visible = true;
                    }
                    else
                    {
                        picboxShow12[i].Location = new Point(picboxShow12[i - 1].Location.X + 50, picboxShow12[i - 1].Location.Y);
                        picboxShow12[i].Visible = true;
                    }
                }
            }
        }
        private void pictureBox142_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i <= 11; i++)
            {
                picboxShow12[i].Visible = false;
            }
        }

        private void pictureBox143_MouseHover(object sender, EventArgs e)
        {
            for (int i = 0; i <= 11; i++)
            {
                if (picboxBitmapList[1, 8].Count >= 1 && i < picboxBitmapList[1, 8].Count)
                {
                    picboxShow12[i].Image = picboxBitmapList[1, 8][(picboxBitmapList[1, 8].Count - (i + 1))];
                    //picboxShow12[0].Location = new Point(52, 620);
                    if (i == 0)
                    {
                        picboxShow12[i].Location = new Point(picbox2DArr[1, 8].Location.X + 26, picbox2DArr[1, 8].Location.Y + 32 + 6);
                        picboxShow12[i].Visible = true;
                    }
                    else
                    {
                        picboxShow12[i].Location = new Point(picboxShow12[i - 1].Location.X + 50, picboxShow12[i - 1].Location.Y);
                        picboxShow12[i].Visible = true;
                    }
                }
            }
        }
        private void pictureBox143_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i <= 11; i++)
            {
                picboxShow12[i].Visible = false;
            }
        }


        private void pictureBox240_MouseHover(object sender, EventArgs e) {
            for (int i = 0; i <= 11; i++)
            {
                if (picboxBitmapList[2, 5].Count >= 1 && i < picboxBitmapList[2, 5].Count)
                {
                    picboxShow12[i].Image = picboxBitmapList[2, 5][(picboxBitmapList[2, 5].Count - (i + 1))];
                    //picboxShow12[0].Location = new Point(52, 620);
                    if (i == 0)
                    {
                        picboxShow12[i].Location = new Point(picbox2DArr[2, 5].Location.X + 26, picbox2DArr[2, 5].Location.Y + 32 + 6);
                        picboxShow12[i].Visible = true;
                    }
                    else
                    {
                        picboxShow12[i].Location = new Point(picboxShow12[i - 1].Location.X + 50, picboxShow12[i - 1].Location.Y);
                        picboxShow12[i].Visible = true;
                    }
                }
            }
        }
        private void pictureBox240_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i <= 11; i++)
            {
                picboxShow12[i].Visible = false;
            }
        }

        private void pictureBox241_MouseHover(object sender, EventArgs e) {
            for (int i = 0; i <= 11; i++)
            {
                if (picboxBitmapList[2, 6].Count >= 1 && i < picboxBitmapList[2, 6].Count)
                {
                    picboxShow12[i].Image = picboxBitmapList[2, 6][(picboxBitmapList[2, 6].Count - (i + 1))];
                    //picboxShow12[0].Location = new Point(52, 620);
                    if (i == 0)
                    {
                        picboxShow12[i].Location = new Point(picbox2DArr[2, 6].Location.X + 26, picbox2DArr[2, 6].Location.Y + 32 + 6);
                        picboxShow12[i].Visible = true;
                    }
                    else
                    {
                        picboxShow12[i].Location = new Point(picboxShow12[i - 1].Location.X + 50, picboxShow12[i - 1].Location.Y);
                        picboxShow12[i].Visible = true;
                    }
                }
            }
        }
        private void pictureBox241_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i <= 11; i++)
            {
                picboxShow12[i].Visible = false;
            }
        }

        private void pictureBox242_MouseHover(object sender, EventArgs e)
        {
            for (int i = 0; i <= 11; i++)
            {
                if (picboxBitmapList[2, 7].Count >= 1 && i < picboxBitmapList[2, 7].Count)
                {
                    picboxShow12[i].Image = picboxBitmapList[2, 7][(picboxBitmapList[2, 7].Count - (i + 1))];
                    //picboxShow12[0].Location = new Point(52, 720);
                    if (i == 0)
                    {
                        picboxShow12[i].Location = new Point(picbox2DArr[2, 7].Location.X + 26, picbox2DArr[2, 7].Location.Y + 32 + 6);
                        picboxShow12[i].Visible = true;
                    }
                    else
                    {
                        picboxShow12[i].Location = new Point(picboxShow12[i - 1].Location.X + 50, picboxShow12[i - 1].Location.Y);
                        picboxShow12[i].Visible = true;
                    }
                }
            }
        }
        private void pictureBox242_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i <= 11; i++)
            {
                picboxShow12[i].Visible = false;
            }
        }

        private void pictureBox243_MouseHover(object sender, EventArgs e) {
            for (int i = 0; i <= 11; i++)
            {
                if (picboxBitmapList[2, 8].Count >= 1 && i < picboxBitmapList[2, 8].Count)
                {
                    picboxShow12[i].Image = picboxBitmapList[2, 8][(picboxBitmapList[2, 8].Count - (i + 1))];
                    //picboxShow12[0].Location = new Point(52, 820);
                    if (i == 0)
                    {
                        picboxShow12[i].Location = new Point(picbox2DArr[2, 8].Location.X + 26, picbox2DArr[2, 8].Location.Y + 32 + 6);
                        picboxShow12[i].Visible = true;
                    }
                    else
                    {
                        picboxShow12[i].Location = new Point(picboxShow12[i - 1].Location.X + 50, picboxShow12[i - 1].Location.Y);
                        picboxShow12[i].Visible = true;
                    }
                }
            }
        }
        private void pictureBox243_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i <= 11; i++)
            {
                picboxShow12[i].Visible = false;
            }
        }



        private void pictureBox340_MouseHover(object sender, EventArgs e)
        {
            for (int i = 0; i <= 11; i++)
            {
                if (picboxBitmapList[3, 5].Count >= 1 && i < picboxBitmapList[3, 5].Count)
                {
                    picboxShow12[i].Image = picboxBitmapList[3, 5][(picboxBitmapList[3, 5].Count - (i + 1))];
                    //picboxShow12[0].Location = new Point(53, 520);
                    if (i == 0)
                    {
                        picboxShow12[i].Location = new Point(picbox2DArr[3, 5].Location.X + 26, picbox2DArr[3, 5].Location.Y + 32 + 6);
                        picboxShow12[i].Visible = true;
                    }
                    else
                    {
                        picboxShow12[i].Location = new Point(picboxShow12[i - 1].Location.X + 50, picboxShow12[i - 1].Location.Y);
                        picboxShow12[i].Visible = true;
                    }
                }
            }
        }
        private void pictureBox340_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i <= 11; i++)
            {
                picboxShow12[i].Visible = false;
            }
        }

        private void pictureBox341_MouseHover(object sender, EventArgs e)
        {
            for (int i = 0; i <= 11; i++)
            {
                if (picboxBitmapList[3, 6].Count >= 1 && i < picboxBitmapList[3, 6].Count)
                {
                    picboxShow12[i].Image = picboxBitmapList[3, 6][(picboxBitmapList[3, 6].Count - (i + 1))];
                    //picboxShow12[0].Location = new Point(53, 620);
                    if (i == 0)
                    {
                        picboxShow12[i].Location = new Point(picbox2DArr[3, 6].Location.X + 26, picbox2DArr[3, 6].Location.Y + 32 + 6);
                        picboxShow12[i].Visible = true;
                    }
                    else
                    {
                        picboxShow12[i].Location = new Point(picboxShow12[i - 1].Location.X + 50, picboxShow12[i - 1].Location.Y);
                        picboxShow12[i].Visible = true;
                    }
                }
            }
        }
        private void pictureBox341_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i <= 11; i++)
            {
                picboxShow12[i].Visible = false;
            }
        }

        private void pictureBox342_MouseHover(object sender, EventArgs e)
        {
            for (int i = 0; i <= 11; i++)
            {
                if (picboxBitmapList[3, 7].Count >= 1 && i < picboxBitmapList[3, 7].Count)
                {
                    picboxShow12[i].Image = picboxBitmapList[3, 7][(picboxBitmapList[3, 7].Count - (i + 1))];
                    //picboxShow12[0].Location = new Point(53, 720);
                    if (i == 0)
                    {
                        picboxShow12[i].Location = new Point(picbox2DArr[3, 7].Location.X + 26, picbox2DArr[3, 7].Location.Y + 32 + 6);
                        picboxShow12[i].Visible = true;
                    }
                    else
                    {
                        picboxShow12[i].Location = new Point(picboxShow12[i - 1].Location.X + 50, picboxShow12[i - 1].Location.Y);
                        picboxShow12[i].Visible = true;
                    }
                }
            }
        }
        private void pictureBox342_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i <= 11; i++)
            {
                picboxShow12[i].Visible = false;
            }
        }

        private void pictureBox343_MouseHover(object sender, EventArgs e) {
            for (int i = 0; i <= 11; i++)
            {
                if (picboxBitmapList[3, 8].Count >= 1 && i < picboxBitmapList[3, 8].Count)
                {
                    picboxShow12[i].Image = picboxBitmapList[3, 8][(picboxBitmapList[3, 8].Count - (i + 1))];
                    //picboxShow12[0].Location = new Point(53, 820);
                    if (i == 0)
                    {
                        picboxShow12[i].Location = new Point(picbox2DArr[3, 8].Location.X + 26, picbox2DArr[3, 8].Location.Y + 32 + 6);
                        picboxShow12[i].Visible = true;
                    }
                    else
                    {
                        picboxShow12[i].Location = new Point(picboxShow12[i - 1].Location.X + 50, picboxShow12[i - 1].Location.Y);
                        picboxShow12[i].Visible = true;
                    }
                }
            }
        }
        private void pictureBox343_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i <= 11; i++)
            {
                picboxShow12[i].Visible = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelWelcome_Click(object sender, EventArgs e)
        {
            panelWelcome.Visible = false;
            labelWelcome.Visible = false;
            
            labelWelcome.Click += new System.EventHandler(this.buttonStart_Click);
        }









    }//form
}//Redo
