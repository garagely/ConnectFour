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
        
        private PictureBox[,] aryGameBox = new PictureBox[7, 6];
        private Button[] aryButtons = new Button[7];
        private int intPlayerTurn = 1;
        public GameBoard()
        { 
            InitializeComponent();
            picPlayerTurn.BackColor = Color.Blue;
            lblPLayerTurn.Text = "Player 1 Turn";
            for(int r=0; r<7; r++)
            {
                for(int c = 0; c < 6; c++)
                {
                    aryGameBox[r, c] = new PictureBox()
                    {
                        Location = new Point(r * 100 + 100, c * 100 + 100),
                        Width = 100,
                        Height = 100,
                        Visible = true,
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Color.Transparent
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
            Color color = Color.Transparent;

            if(intPlayerTurn == 1)
            {
                color = Color.Blue;
            }else if(intPlayerTurn == 2)
            {
                color = Color.Red;
            }
            
            //get column based on button pressed.
            int c = Array.IndexOf(aryButtons, btnPressed);

            //aryGameBox[0, 2].BackColor = Color.Blue;

            for (int r = 5; r >=0; r--)
            {
                if(aryGameBox[c,r].BackColor == Color.Transparent)
                {
                    aryGameBox[c, r].BackColor = color;
                    //break out of loop when it finds an empty square
                    if (intPlayerTurn == 1)
                    {
                        intPlayerTurn = 2;
                        picPlayerTurn.BackColor = Color.Red;
                        lblPLayerTurn.Text = "Player 2 Turn";
                    }
                    else
                    {
                        intPlayerTurn = 1;
                        picPlayerTurn.BackColor = Color.Blue;
                        lblPLayerTurn.Text = "Player 1 Turn";
                    }
                    break;
                }
            }

            //aryGameBox[c, 5].BackColor = color;
            //if(intPlayerTurn == 1)
            //{
            //    intPlayerTurn = 2;
            //    picPlayerTurn.BackColor = Color.Red;
            //    lblPLayerTurn.Text = "Player 2 Turn";
            //}
            //else
            //{
            //    intPlayerTurn = 1;
            //    picPlayerTurn.BackColor = Color.Blue;
            //    lblPLayerTurn.Text = "Player 1 Turn";
            //}
        }

        private void mnuExitOnClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuResetOnClick(object sender, EventArgs e) {
            foreach(PictureBox box in aryGameBox)
            {
                box.BackColor = Color.Transparent;
                intPlayerTurn = 1;
                picPlayerTurn.BackColor = Color.Blue;
                lblPLayerTurn.Text = "Player 1 Turn";
            }
        }
    }
}
