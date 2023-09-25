using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA
{
    public partial class Form1 : Form
    {
        bool goLeft, goRight, jumping, isGameOver;
        int jumpspeed;
        int force;
        int score = 0;
        int playerspeed = 7;
        int horizontalSpeed = 5;
        int verticalSpeed = 3;
        int enemy1Speed = 5;
        int enemy2Speed = 3;

        public Form1()
        {
            InitializeComponent();
        }

        private void MainGameTickEvt(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;

            player.Top += jumpspeed;
            if (goLeft)
            {
                player.Left -= playerspeed;
            }
            if (goRight)
            {
                player.Left += playerspeed;
            }
            if (jumping && force <0)
            {
                jumping = false;
            }
            if (jumping)
            {
                jumpspeed = -8;
                force -= 1;
            } else
            {
                jumpspeed = 10;
            }

            foreach(Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    /*if ((string)x.Tag == "wall")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            if (x.Bounds.X - player.Width <= player.Bounds.X)
                            {
                                player.Left = x.Left - player.Width;
                            }
                        }
                    }*/
                    if ((string)x.Tag == "platform")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            txtScore.Text = "x.Bounds: " + x.Bounds + Environment.NewLine + "player.Bounds: " + player.Bounds;
                            if (x.Bounds.Y <= player.Bounds.Y && player.Bounds.X + player.Width >= x.Bounds.X+8 && player.Bounds.X <= x.Bounds.X+ x.Width-8)
                            {
                                player.Top = x.Top+player.Height;
                            }
                            else if (player.Bounds.Y <=  x.Bounds.Y + player.Bounds.Height && player.Bounds.X + player.Width >= x.Bounds.X + 8 && player.Bounds.X <= x.Bounds.X + x.Width - 8)
                            {
                                force = 8;
                                player.Top = x.Top - player.Height;
                            }
                            else if (x.Bounds.X >= player.Bounds.X - player.Width && player.Bounds.X - player.Width <= x.Bounds.X- 8)
                            {
                                player.Left = x.Left - player.Width;
                            }
                            /*else if (x.Bounds.X + x.Width >= player.Bounds.X && player.Bounds.X <= x.Bounds.X - x.Width)
                            {
                                player.Left = x.Left - player.Width;
                            }*/
                        }
                        x.BringToFront();
                    }
                    if ((string)x.Tag == "coin")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible)
                        {
                            x.Visible = false;
                            score++;
                        }
                    }
                    if (((string)x.Tag == "enemy"))
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameTimer.Stop();
                            isGameOver = true;
                            //txtScore.Text = "Score: " + score + Environment.NewLine + "you die L";
                        }
                    }
                }
            }
            enemy1.Left -= enemy1Speed;
            if (enemy1.Left < pictureBox4.Left || enemy1.Left + enemy1.Width > pictureBox4.Left + pictureBox4.Width)
            {
                enemy1Speed = -enemy1Speed;
            } 
            enemy2.Left -= enemy2Speed;
            if (enemy2.Left < pictureBox6.Left || enemy2.Left + enemy2.Width > pictureBox6.Left + pictureBox6.Width)
            {
                enemy2Speed = -enemy2Speed;
            }
            if (player.Top + player.Height > this.ClientSize.Height + 50)
            {
                gameTimer.Stop();
                isGameOver = true;
                //txtScore.Text = "Score: " + score + Environment.NewLine + "you fell L";
            }
            if (player.Bounds.IntersectsWith(door.Bounds) && score >= 26)
            {
                gameTimer.Stop();
                isGameOver = true;
                //txtScore.Text = "Score: " + score + Environment.NewLine + "you win";
            } else
            {
                //txtScore.Text = "Score: " + score + Environment.NewLine + "Collect all the coin";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (jumping == true)
            {
                jumping = false;
            }
            if (e.KeyCode == Keys.Enter && isGameOver)
            {
               RestartGame();
            } 
        }

        private void RestartGame()
        {
            goLeft = false;
            goRight = false;
            jumping = false;
            isGameOver = false;
            score = 0;
            //txtScore.Text = "Score:" + score;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }
            player.Left = 169;
            player.Top = 659;
        }
    }
}
