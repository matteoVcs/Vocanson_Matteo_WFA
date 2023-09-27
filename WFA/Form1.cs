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
        bool goLeft, goRight, jumping, isSticky, isGameOver;
        int jumpspeed;
        int force;
        int fireball = 1;
        bool fireball1Visible = false;
        int score = 0;
        int playerspeed = 5;
        int movingSpeed = 3;
        int expension = 2;
        int enemy1Speed = 5;
        int enemy2Speed = 3;
        string facing = "right";

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
                jumpspeed = -10;
                force -= 1;
            } else
            {
                jumpspeed = 10;
            }
            if (fireball1Visible)
                fireball1.Visible = true;
            else fireball1.Visible = false;

            foreach(Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "platform")
                    {
                        if (fireball1.Bounds.IntersectsWith(x.Bounds) && fireball1.Visible)
                        {
                            fireball1.Visible = false;
                            fireball1Visible = false;
                            fireball = 1;
                        }
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            txtScore.Text = "x.Bounds: " + x.Bounds + Environment.NewLine + "player.Bounds: " + player.Bounds;
                            if (x.Bounds.Y <= player.Bounds.Y && player.Bounds.X + player.Width >= x.Bounds.X+8 && player.Bounds.X <= x.Bounds.X+ x.Width-8)
                            {
                                while (force >= 0)
                                {
                                    force -= 1;
                                    jumpspeed = 0;
                                    player.Top = x.Top + x.Height;

                                }
                            }
                            else if (player.Bounds.Y <=  x.Bounds.Y + player.Bounds.Height && player.Bounds.X + player.Width >= x.Bounds.X + 8 && player.Bounds.X <= x.Bounds.X + x.Width - 8)
                            {
                                isSticky = false;
                                force = 8;
                                if (!jumping)
                                    jumpspeed = 0;
                                else jumpspeed = -10;
                                player.Top = x.Top - player.Height+1;
                            }
                            else if (x.Bounds.X >= player.Bounds.X - player.Width && player.Bounds.X - player.Width <= x.Bounds.X- 8)
                            {
                                player.Left = x.Left - player.Width;
                            }
                            else if (player.Bounds.X <= x.Bounds.X + x.Width && player.Bounds.X >= x.Bounds.X + x.Width - 8)
                            {
                                player.Left = x.Left + x.Width;
                            }
                        }
                        x.BringToFront();
                    }
                    if ((string)x.Tag == "platformS")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            if (x.Bounds.Y <= player.Bounds.Y && player.Bounds.X + player.Width >= x.Bounds.X + 8 && player.Bounds.X <= x.Bounds.X + x.Width - 8)
                            {
                                player.Top = x.Top + x.Height-1;
                                jumpspeed = 0;
                                isSticky = true;
                            }
                            else if (player.Bounds.Y <= x.Bounds.Y + player.Bounds.Height && player.Bounds.X + player.Width >= x.Bounds.X + 8 && player.Bounds.X <= x.Bounds.X + x.Width - 8)
                            {
                                force = 8;
                                if (!jumping)
                                    jumpspeed = 0;
                                else jumpspeed = -10;
                                player.Top = x.Top - player.Height + 1;
                            }
                            else if (x.Bounds.X >= player.Bounds.X - player.Width && player.Bounds.X - player.Width <= x.Bounds.X - 8)
                            {
                                player.Left = x.Left - player.Width;
                            }
                            else if (player.Bounds.X <= x.Bounds.X + x.Width && player.Bounds.X >= x.Bounds.X + x.Width - 8)
                            {
                                player.Left = x.Left + x.Width;
                            }
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
                    if ((string)x.Tag == "enemy")
                    {
                        if (fireball1.Bounds.IntersectsWith(x.Bounds) && fireball1.Visible)
                        {
                            fireball1.Visible = false;
                            fireball1Visible = false;
                            fireball = 1;
                            x.Visible = false;
                            x.Tag = "dead";
                        }
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            /*if (player.Bounds.Y + player.Bounds.Height <= x.Bounds.Y + 8 && player.Bounds.Y + player.Bounds.Height >= x.Bounds.Y)
                            {
                                x.Visible = false;
                                x.Tag = "";
                            } else
                            {*/
                                gameTimer.Stop();
                                isGameOver = true;
                                txtScore.Text = "Score: " + score + Environment.NewLine + "you die L";
                            //}
                        }
                    }
                }
            }
            enemy1.Left -= enemy1Speed;
            if (enemy1.Left < pictureBox2.Left || enemy1.Left + enemy1.Width > pictureBox2.Left + pictureBox2.Width)
            {
                enemy1Speed = -enemy1Speed;
            } 
            enemy2.Left -= enemy2Speed;
            if (enemy2.Left < pictureBox6.Left || enemy2.Left + enemy2.Width > pictureBox6.Left + pictureBox6.Width)
            {
                enemy2Speed = -enemy2Speed;
            }
            platformM.Top += movingSpeed;
            platformM.Width += expension;
            platformM.Left -=  expension / 2;
            if (platformM.Width > 150 || platformM.Width < 50)
            {
                expension = -expension;
            }
            if (platformM.Top < 60 || platformM.Top > 330)
            {
                movingSpeed = -movingSpeed;
            }
            if (player.Top + player.Height > this.ClientSize.Height + 50)
            {
                gameTimer.Stop();
                isGameOver = true;
                txtScore.Text = "Score: " + score + Environment.NewLine + "you fell L";
            }
            if (player.Bounds.IntersectsWith(door.Bounds) && score >= 26)
            {
                gameTimer.Stop();
                isGameOver = true;
                txtScore.Text = "Score: " + score + Environment.NewLine + "you win";
            } else
            {
                txtScore.Text = "Score: " + score + Environment.NewLine + "Collect all the coin";
            }
            if (fireball == 1)
            {
                if (facing == "right")
                {
                    fireball1.Left = player.Left+ player.Width;
                    fireball1.Top = player.Top + player.Height / 2;
                }
                else
                {
                    fireball1.Left = player.Left - fireball1.Width;
                    fireball1.Top = player.Top + player.Height / 2;
                }
            }
            if (fireball == 0)
            {
                if (facing == "right")
                {
                    fireball1.Left += 10;
                }
                else
                {
                    fireball1.Left -= 10;
                }
            }
            if (fireball1.Left < 0 || fireball1.Left > this.ClientSize.Width)
            {
                fireball1.Visible = false;
                fireball1Visible = false;
                fireball = 1;
            }
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (fireball == 1)
                    facing = "left";
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                if (fireball == 1)
                    facing = "right";
                goRight = true;
            }
            if (e.KeyCode == Keys.Space && isSticky)
            {
                force = 0;
                player.Top += 10;
                isSticky = false;
            }
            else if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
            }
            if (e.KeyCode == Keys.F)
            {
                fireball1Visible = true;
                fireball = 0;
                fireball1.Visible = true;
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
                force = 0;
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
            txtScore.Text = "Score:" + score;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && !x.Visible)
                {
                    x.Visible = true;
                }
                if ((string)x.Tag == "dead")
                {
                    x.Visible = true;
                    x.Tag = "enemy";
                }
            }
            fireball1.Visible = false;
            player.Left = 130;
            player.Top = 530;
            gameTimer.Start();
        }
    }
}
