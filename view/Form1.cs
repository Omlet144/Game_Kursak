using Game_Kursak.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Game_Kursak
{
    public partial class Form1 : Form
    {
        bool goLeft, goRight, goUp, goDown, gameOver;
        string facing = "up";
        int playerHealth = 100;
        int speed = 10;
        int ammo = 10;
        int zombieSpeed = 3;
        int score;
        Random randNum = new Random();

        List<PictureBox> zombiesList = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {

            if (playerHealth > 1)
            {
                healthBar.Value = playerHealth;
            }
            else
            {
                gameOver = true;
                player.Image = Properties.Resources.dead;
                GameTimer.Stop();
            }

            txtAmmo.Text = "Ammo: " + ammo;
            txtScore.Text = "Kills: " + score;

            if (goLeft == true && player.Left > 0)
            {
                player.Left -= speed;
            }
            if (goRight == true && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += speed;
            }
            if (goUp == true && player.Top > 45)
            {
                player.Top -= speed;
            }
            if (goDown == true && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += speed;
            }

            foreach (Control item in this.Controls)
            {
                if (item is PictureBox && (string)item.Tag == "ammo")
                {
                    if (player.Bounds.IntersectsWith(item.Bounds))
                    {
                        this.Controls.Remove(item);
                        ((PictureBox)item).Dispose();
                        ammo += 5;
                    }
                }

                if (item is PictureBox && (string)item.Tag == "zombie")
                {
                    if (player.Bounds.IntersectsWith(item.Bounds))
                    {
                        playerHealth -= 1;
                    }

                    if (item.Left > player.Left)
                    {
                        item.Left -= zombieSpeed;
                        ((PictureBox)item).Image = Properties.Resources.zleft;
                    }
                    if (item.Left < player.Left)
                    {
                        item.Left += zombieSpeed;
                        ((PictureBox)item).Image = Properties.Resources.zright;
                    }
                    if (item.Top > player.Top)
                    {
                        item.Top -= zombieSpeed;
                        ((PictureBox)item).Image = Properties.Resources.zup;
                    }
                    if (item.Top < player.Top)
                    {
                        item.Top += zombieSpeed;
                        ((PictureBox)item).Image = Properties.Resources.zdown;
                    }
                }

                foreach (Control item2 in this.Controls)
                {
                    if (item2 is PictureBox && (string)item2.Tag == "bullet" && item is PictureBox && (string)item.Tag == "zombie")
                    {
                        if (item.Bounds.IntersectsWith(item2.Bounds))
                        {
                            score++;
                            this.Controls.Remove(item2);
                            ((PictureBox)item2).Dispose();
                            this.Controls.Remove(item);
                            ((PictureBox)item).Dispose();
                            zombiesList.Remove(((PictureBox)item));
                            MakeZombies();
                        }
                    }
                }
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (gameOver == true)
            {
                return;
            }

            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
                facing = "left";
                player.Image = Properties.Resources.left;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                facing = "right";
                player.Image = Properties.Resources.right;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                facing = "up";
                player.Image = Properties.Resources.up;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                facing = "down";
                player.Image = Properties.Resources.down;
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
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }

            if (e.KeyCode == Keys.Space && ammo > 0 && gameOver == false)
            {
                ammo--;
                ShootBullet(facing);

                if (ammo < 1)
                {
                    DropAmmo();
                }
            }

            if (e.KeyCode == Keys.Enter && gameOver == true)
            {
                RestartGame();
            }
        }

        private void ShootBullet(string direction)
        {
            Bullet shootBullet = new Bullet();
            shootBullet.diraction = direction;
            shootBullet.bulletLeft = player.Left + (player.Width / 2);
            shootBullet.bulletTop = player.Top + (player.Height / 2);
            shootBullet.MakeBullet(this);
        }

        private void MakeZombies()
        {
            PictureBox zombie = new PictureBox();
            zombie.Tag = "zombie";
            zombie.Image = Properties.Resources.zdown;
            zombie.Left = randNum.Next(0, 900);
            zombie.Top = randNum.Next(0, 800);
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;
            zombiesList.Add(zombie);
            this.Controls.Add(zombie);
            player.BringToFront();
        }

        private void DropAmmo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo_Image;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = randNum.Next(10, this.ClientSize.Width - ammo.Width);
            ammo.Top = randNum.Next(60, this.ClientSize.Height - ammo.Height);
            ammo.Tag = "ammo";
            this.Controls.Add(ammo);

            ammo.BringToFront();
            player.BringToFront();

        }

        private void RestartGame()
        {
            player.Image = Properties.Resources.up;

            foreach (PictureBox item in zombiesList)
            {
                this.Controls.Remove(item);
            }
            zombiesList.Clear();

            for (int i = 0; i < 3; i++)
            {
                MakeZombies();
            }

            goUp = false;
            goDown = false;
            goLeft = false;
            goRight = false;
            gameOver = false;

            playerHealth = 100;
            score = 0;
            ammo = 10;

            GameTimer.Start();
        }

    }
}
