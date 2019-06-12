//=============================================================
//Programmer: Michael Sandell
//Date:12 Jun 2019
//Version: 0.1
//Description: A connect four game
//=============================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour
{
    public partial class GameBoard : Form
    {
        PictureBox[,] aryGameBox = new PictureBox[7, 6];
        Button[] aryButtons = new Button[7];
        public GameBoard()
        { 
            InitializeComponent();
            for(int r=0; r<7; r++)
            {
                for(int c = 0; c < 6; c++)
                {
                    aryGameBox[r,c] = new PictureBox()
                    {
                        Location = new Point(r * 100 + 100, c * 100 + 100),
                        Width = 100,
                        Height = 100,
                        Visible = true,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    aryGameBox[r, c].BringToFront();
                    this.Controls.Add(aryGameBox[r, c]);
                }
            }
            
            for(int i = 0; i<7; i++)
            {
                aryButtons[i] = new Button()
                {
                    Location = new Point(i * 100 + 100, 50),
                    Width = 100,
                    Height = 25,
                    Visible = true
                };
                aryButtons[i].BringToFront();
                aryButtons[i].Name = String.Format("btnCol{0}", i);
                aryButtons[i].Click += new System.EventHandler(this.btnDropPieceOnClick);
                this.Controls.Add(aryButtons[i]);
            }
        }
        /// <summary>
        /// checks which positions are empty in column and drops piece
        /// </summary>
        private void btnDropPieceOnClick(object sender, EventArgs e)   
        {
            Button btnPressed = (Button)sender;
            //get column based on button pressed.
            int c = Array.IndexOf(aryButtons, btnPressed);

            //aryGameBox[0, 2].BackColor = Color.Blue;

            for (int r = 0; r < 5; r++)
            {
                aryGameBox[c, r].BackColor = Color.Blue;
                if (!(aryGameBox[c, r+1].BackColor == Color.Blue))
                {
                    aryGameBox[c, r].BackColor = Color.Transparent;
                }
            }

            aryGameBox[c, 5].BackColor = Color.Blue;
        }

        private void test()
        {
            //this is a test method
            //more test stuff
            //alfjniufneiu
            //weofweuib
        }
    }
}
