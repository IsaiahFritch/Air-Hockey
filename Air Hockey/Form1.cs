using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Air_Hockey
{
    public partial class Form1 : Form
    {
        //objects
        Rectangle player1 = new Rectangle(249, 205, 100, 100);
        Rectangle player2 = new Rectangle(249, 690, 100, 100);
        Rectangle goal1 = new Rectangle(185, 1, 227, 35);
        Rectangle goal2 = new Rectangle(185, 963, 227, 35);
        Rectangle puck = new Rectangle(269, 468, 60, 60);

        //global variables
        int player1Score = 0;
        int player2Score = 0;

        int playerSpeed = 10;
        int puckXSpeed = -0;
        int puckYSpeed = 0;
        int counter = 0;

        int speedone = 0;
        int speedtwo = 0;

        bool leaveBoundaries = false;

        int lastP1X = 249;
        int lastP1Y = 205;
        int lastP2X = 249;
        int lastP2Y = 690;


        //player 1 controls
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftDown = false;
        bool rightDown = false;

        //player 2 controls
        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;

        //randomizer
        Random randomGen = new Random();

        //brushes
        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        Pen whitePen = new Pen(Color.White, 4);

        //sounds
        SoundPlayer wallColisionSound = new SoundPlayer(Properties.Resources.wallColSound);
        SoundPlayer playerCollisionSound = new SoundPlayer(Properties.Resources.playerColSound);
        SoundPlayer winSound = new SoundPlayer(Properties.Resources.winSound);
        SoundPlayer goalSound = new SoundPlayer(Properties.Resources.goalSound);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //move player 1 
            if (wDown == true && player1.Y > 40)
            {
                player1.Y -= playerSpeed;
            }

            if (sDown == true && player1.Y < 497 - player1.Width)
            {
                player1.Y += playerSpeed;
            }
            if (aDown == true && player1.X > 40)
            {
                player1.X -= playerSpeed;
            }

            if (dDown == true && player1.X < this.Width - player1.Width - 40)
            {
                player1.X += playerSpeed;
            }

            //move player 2 
            if (upArrowDown == true && player2.Y > 500)
            {
                player2.Y -= playerSpeed;
            }

            if (downArrowDown == true && player2.Y < 962 - player2.Height)
            {
                player2.Y += playerSpeed;
            }

            if (leftDown == true && player2.X > 40)
            {
                player2.X -= playerSpeed;
            }

            if (rightDown == true && player2.X < this.Width - player2.Width - 40)
            {
                player2.X += playerSpeed;
            }

            //move puck 
            puck.X += puckXSpeed;
            puck.Y += puckYSpeed;

            //slow puck to a stop  (I was able to do this but it looked very choppy, so I tried this code and it didn't work or I didn't finish it, I can't remember
            ////try
            ////{
            ////    if (puckXSpeed != 0)
            ////    {
            ////        puckXSpeed += -(puckYSpeed / puckXSpeed);
            ////    }

            ////    if (puckYSpeed != 0)
            ////    {
            ////        puckYSpeed += -(puckXSpeed / puckYSpeed);
            ////    }
            ////}
            ////catch
            ////{
            ////    //do nothing
            ////}

            //reset game
            if (leaveBoundaries == true)
            {
                //reset game
                puckXSpeed = -0;
                puckYSpeed = 0;

                player1.X = 249;
                player1.Y = 205;
                player2.X = 249;
                player2.Y = 690;
                puck.X = 269;
                puck.Y = 468;

                leaveBoundaries = false;
            }

            //check if ball hit top or bottom wall and change direction if it does
            else
            {
                if (puck.IntersectsWith(goal1) || puck.IntersectsWith(goal2))
                {
                    leaveBoundaries = true;
                }
                else
                {
                    if (puck.Y < 40 || puck.Y > 962 - puck.Height)
                    {
                        puckYSpeed *= -1;
                        wallColisionSound.Play();
                    }
                    if (puck.X < 40 || puck.X > this.Width - puck.Width - 40)
                    {
                        puckXSpeed *= -1;
                        wallColisionSound.Play();
                    }
                }
            }

            //did a player collide with a ball? 
            if (puck.IntersectsWith(player1))
            {
                //sound
                playerCollisionSound.Play();

                //player one collision boxes
                //top
                Rectangle p1TopCornerLeft = new Rectangle(player1.X, player1.Y, 10, 10);
                Rectangle p1TopMiddle = new Rectangle(player1.X + 0, player1.Y, 70, 1);
                Rectangle p1TopCornerRight = new Rectangle(player1.X + 90, player1.Y, 10, 10);

                //bottom
                Rectangle p1BottomCornerLeft = new Rectangle(player1.X, player1.Y + 90, 10, 10);
                Rectangle p1BottomMiddle = new Rectangle(player1.X + 0, player1.Y + 100, 70, 1);
                Rectangle p1BottomCornerRight = new Rectangle(player1.X + 90, player1.Y + 90, 10, 10);

                //left
                Rectangle p1LeftMiddle = new Rectangle(player1.X, player1.Y + 0, 1, 70);

                //right
                Rectangle p1RightMiddle = new Rectangle(player1.X + 100, player1.Y + 0, 1, 70);

                //generate random directions
                speedone = randomGen.Next(-5, 6);
                speedtwo = randomGen.Next(-5, 6);

                if (puck.IntersectsWith(p1TopCornerLeft))
                {
                    puckXSpeed = -10 + speedone;
                    puckYSpeed = -10 + speedtwo;
                }
                else if (puck.IntersectsWith(p1TopMiddle))
                {
                    puckXSpeed = 0 + speedone;
                    puckYSpeed = -12 + speedtwo;
                }
                else if (puck.IntersectsWith(p1TopCornerRight))
                {
                    puckXSpeed = 10 + speedone;
                    puckYSpeed = -10 + speedtwo;
                }
                else if (puck.IntersectsWith(p1BottomCornerLeft))
                {
                    puckXSpeed = -10 + speedone;
                    puckYSpeed = 10 + speedtwo;
                }
                else if (puck.IntersectsWith(p1BottomMiddle))
                {
                    puckXSpeed = 0 + speedone;
                    puckYSpeed = 12 + speedtwo;
                }
                else if (puck.IntersectsWith(p1BottomCornerRight))
                {
                    puckXSpeed = 10 + speedone;
                    puckYSpeed = 10 + speedtwo;
                }
                else if (puck.IntersectsWith(p1LeftMiddle))
                {
                    puckXSpeed = -12 + speedone;
                    puckYSpeed = 0 + speedtwo;
                }
                else if (puck.IntersectsWith(p1RightMiddle))
                {
                    puckXSpeed = 12 + speedone;
                    puckYSpeed = 0 + speedtwo;
                }
            }
            if (puck.IntersectsWith(player2))
            {
                //sound
                playerCollisionSound.Play();

                //player one collision boxes
                //top
                Rectangle p2TopCornerLeft = new Rectangle(player2.X, player2.Y, 10, 10);
                Rectangle p2TopMiddle = new Rectangle(player2.X + 0, player2.Y, 70, 1);
                Rectangle p2TopCornerRight = new Rectangle(player2.X + 90, player2.Y, 10, 10);

                //bottom
                Rectangle p2BottomCornerLeft = new Rectangle(player2.X, player2.Y + 90, 10, 10);
                Rectangle p2BottomMiddle = new Rectangle(player2.X + 0, player2.Y + 100, 70, 1);
                Rectangle p2BottomCornerRight = new Rectangle(player2.X + 90, player2.Y + 90, 10, 10);

                //left
                Rectangle p2LeftMiddle = new Rectangle(player2.X, player2.Y + 0, 1, 70);

                //right
                Rectangle p2RightMiddle = new Rectangle(player2.X + 100, player2.Y + 0, 1, 70);

                //generate random directions
                speedone = randomGen.Next(-5, 6);
                speedtwo = randomGen.Next(-5, 6);

                if (puck.IntersectsWith(p2TopCornerLeft))
                {
                    puckXSpeed = -10 + speedone;
                    puckYSpeed = -10 + speedtwo;
                }
                else if (puck.IntersectsWith(p2TopMiddle))
                {
                    puckXSpeed = 0 + speedone;
                    puckYSpeed = -12 + speedtwo;
                }
                else if (puck.IntersectsWith(p2TopCornerRight))
                {
                    puckXSpeed = 10 + speedone;
                    puckYSpeed = -10 + speedtwo;
                }
                else if (puck.IntersectsWith(p2BottomCornerLeft))
                {
                    puckXSpeed = -10 + speedone;
                    puckYSpeed = 10 + speedtwo;
                }
                else if (puck.IntersectsWith(p2BottomMiddle))
                {
                    puckXSpeed = 0 + speedone;
                    puckYSpeed = 12 + speedtwo;
                }
                else if (puck.IntersectsWith(p2BottomCornerRight))
                {
                    puckXSpeed = 10 + speedone;
                    puckYSpeed = 10 + speedtwo;
                }
                else if (puck.IntersectsWith(p2LeftMiddle))
                {
                    puckXSpeed = -12 + speedone;
                    puckYSpeed = 0 + speedtwo;
                }
                else if (puck.IntersectsWith(p2RightMiddle))
                {
                    puckXSpeed = 12 + speedone;
                    puckYSpeed = 0 + speedtwo;
                }
            }

            //add scores
            if (puck.IntersectsWith(goal2))
            {
                player1Score++;
                scoreOneLabel.Text = $"{player1Score}";

                goalSound.Play();
            }
            if (puck.IntersectsWith(goal1))
            {
                player2Score++;
                scoreTwoLabel.Text = $"{player2Score}";

                goalSound.Play();
            }

            //player wins
            if (player1Score == 3)
            {
                winLabel.Text = "Player One Wins";
                winLabel.Visible = true;
                resetButton.Visible = true;

                winSound.Play();

                gameTimer.Stop();
            }
            else if (player2Score == 3)
            {
                winLabel.Text = "Player Two Wins";
                winLabel.Visible = true;
                resetButton.Visible = true;

                winSound.Play();

                gameTimer.Stop();
            }

            //avoid getting stuck (helps a bit but not perfect)
            {
                if (lastP1X == player1.X || lastP1Y == player1.Y || puck.IntersectsWith(player1))
                {
                    //player one collision boxes
                    //top
                    Rectangle p1TopCornerLeft = new Rectangle(player1.X, player1.Y, 10, 10);
                    Rectangle p1TopMiddle = new Rectangle(player1.X + 0, player1.Y, 70, 1);
                    Rectangle p1TopCornerRight = new Rectangle(player1.X + 90, player1.Y, 10, 10);

                    //bottom
                    Rectangle p1BottomCornerLeft = new Rectangle(player1.X, player1.Y + 90, 10, 10);
                    Rectangle p1BottomMiddle = new Rectangle(player1.X + 0, player1.Y + 100, 70, 1);
                    Rectangle p1BottomCornerRight = new Rectangle(player1.X + 90, player1.Y + 90, 10, 10);

                    //left
                    Rectangle p1LeftMiddle = new Rectangle(player1.X, player1.Y + 0, 1, 70);

                    //right
                    Rectangle p1RightMiddle = new Rectangle(player1.X + 100, player1.Y + 0, 1, 70);

                    if (puck.IntersectsWith(p1TopCornerLeft))
                    {
                        puck.X += 3;
                        puck.Y += 3;
                        player1.X += 4;
                        player1.X += 4;
                    }
                    else if (puck.IntersectsWith(p1TopMiddle))
                    {
                        puck.X += 0;
                        puck.Y += 3;
                        player1.X += 0;
                        player1.X += 4;
                    }
                    else if (puck.IntersectsWith(p1TopCornerRight))
                    {
                        puck.X += -3;
                        puck.Y += 3;
                        player1.X += -4;
                        player1.X += 4;
                    }
                    else if (puck.IntersectsWith(p1BottomCornerLeft))
                    {
                        puck.X += 2;
                        puck.Y += -2;
                        player1.X += 4;
                        player1.X += -4;
                    }
                    else if (puck.IntersectsWith(p1BottomMiddle))
                    {
                        puck.X += 0;
                        puck.Y += -3;
                        player1.X += 0;
                        player1.X += -4;
                    }
                    else if (puck.IntersectsWith(p1BottomCornerRight))
                    {
                        puck.X += -3;
                        puck.Y += -3;
                        player1.X += -4;
                        player1.X += -4;
                    }
                    else if (puck.IntersectsWith(p1LeftMiddle))
                    {
                        puck.X += 3;
                        puck.Y += 0;
                        player1.X += 4;
                        player1.X += 0;
                    }
                    else if (puck.IntersectsWith(p1RightMiddle))
                    {
                        puck.X += -3;
                        puck.Y += 0;
                        player1.X += -4;
                        player1.X += 0;
                    }
                }
                if (lastP2X == player2.X || lastP2Y == player2.Y || puck.IntersectsWith(player2))
                {
                    //player one collision boxes
                    //top
                    Rectangle p2TopCornerLeft = new Rectangle(player2.X, player2.Y, 10, 10);
                    Rectangle p2TopMiddle = new Rectangle(player2.X + 0, player2.Y, 70, 1);
                    Rectangle p2TopCornerRight = new Rectangle(player2.X + 90, player2.Y, 10, 10);

                    //bottom
                    Rectangle p2BottomCornerLeft = new Rectangle(player2.X, player2.Y + 90, 10, 10);
                    Rectangle p2BottomMiddle = new Rectangle(player2.X + 0, player2.Y + 100, 70, 1);
                    Rectangle p2BottomCornerRight = new Rectangle(player2.X + 90, player2.Y + 90, 10, 10);

                    //left
                    Rectangle p2LeftMiddle = new Rectangle(player2.X, player2.Y + 0, 1, 70);

                    //right
                    Rectangle p2RightMiddle = new Rectangle(player2.X + 100, player2.Y + 0, 1, 70);


                    if (puck.IntersectsWith(p2TopCornerLeft))
                    {
                        puck.X += 3;
                        puck.Y += 3;
                        player2.X += 4;
                        player2.X += 4;
                    }
                    else if (puck.IntersectsWith(p2TopMiddle))
                    {
                        puck.X += 0;
                        puck.Y += 3;
                        player2.X += 0;
                        player2.X += 4;
                    }
                    else if (puck.IntersectsWith(p2TopCornerRight))
                    {
                        puck.X += -3;
                        puck.Y += 3;
                        player2.X += -4;
                        player2.X += 4;
                    }
                    else if (puck.IntersectsWith(p2BottomCornerLeft))
                    {
                        puck.X += 3;
                        puck.Y += -3;
                        player2.X += 4;
                        player2.X += -4;
                    }
                    else if (puck.IntersectsWith(p2BottomMiddle))
                    {
                        puck.X += 0;
                        puck.Y += -3;
                        player2.X += 0;
                        player2.X += -4;
                    }
                    else if (puck.IntersectsWith(p2BottomCornerRight))
                    {
                        puck.X += -3;
                        puck.Y += -3;
                        player2.X += -4;
                        player2.X += -4;
                    }
                    else if (puck.IntersectsWith(p2LeftMiddle))
                    {
                        puck.X += 3;
                        puck.Y += 0;
                        player2.X += 4;
                        player2.X += 0;
                    }
                    else if (puck.IntersectsWith(p2RightMiddle))
                    {
                        puck.X += -3;
                        puck.Y += 0;
                        player2.X += -4;
                        player2.X += 0;
                    }

                    //Copy Last Position
                    lastP1X = player1.X;
                    lastP1Y = player1.Y;
                    lastP2X = player2.X;
                    lastP2Y = player2.Y;
                }
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //background 
            e.Graphics.DrawImage(Properties.Resources.Background, 0, 0, 600, 1000);

            //player 1
            e.Graphics.FillRectangle(blackBrush, player1);

            //player 2
            e.Graphics.FillRectangle(blackBrush, player2);

            //puck
            e.Graphics.FillRectangle(whiteBrush, puck);

            ////nets (for locating)
            //e.Graphics.FillRectangle(whiteBrush, goal1);
            //e.Graphics.FillRectangle(whiteBrush, goal2);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            //reset game
            puckXSpeed = -0;
            puckYSpeed = 0;

            player1.X = 249;
            player1.Y = 205;
            player2.X = 249;
            player2.Y = 690;
            puck.X = 269;
            puck.Y = 468;

            leaveBoundaries = false;

            player1Score = 0;
            player2Score = 0;
            scoreOneLabel.Text = $"{player1Score}";
            scoreTwoLabel.Text = $"{player2Score}";

            winLabel.Visible = false;
            resetButton.Visible = false;

            gameTimer.Enabled = true;
            this.Focus();
        }
    }
}
