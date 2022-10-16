using Game_Kursak.view_model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Game_Kursak
{
    public partial class Form_Game : Form
    {
        View_model view_model = new View_model();

        public Form_Game()
        {
            InitializeComponent();
            view_model.RestartGame(player, this, GameTimer);
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {

            if (view_model.player_class.playerHealth > 1)
            {
                healthBar.Value = view_model.player_class.playerHealth;
            }
            else
            {
                view_model.player_class.gameOver = true;
                player.Image = Properties.Resources.dead;
                GameTimer.Stop();
            }

            txtAmmo.Text = "Ammo: " + view_model.player_class.ammo;
            txtScore.Text = "Kills: " + view_model.player_class.score;

            if (view_model.player_class.goLeft == true && player.Left > 0)
            {
                player.Left -= view_model.player_class.speed;
            }
            if (view_model.player_class.goRight == true && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += view_model.player_class.speed;
            }
            if (view_model.player_class.goUp == true && player.Top > 45)
            {
                player.Top -= view_model.player_class.speed;
            }
            if (view_model.player_class.goDown == true && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += view_model.player_class.speed;
            }

            foreach (Control item in this.Controls)
            {
                if (item is PictureBox && (string)item.Tag == "ammo")
                {
                    if (player.Bounds.IntersectsWith(item.Bounds))
                    {
                        this.Controls.Remove(item);
                        ((PictureBox)item).Dispose();
                        view_model.player_class.ammo += 5;
                    }
                }

                if (item is PictureBox && (string)item.Tag == "zombie")
                {
                    if (player.Bounds.IntersectsWith(item.Bounds))
                    {
                        view_model.player_class.playerHealth -= 1;
                    }

                    if (item.Left > player.Left)
                    {
                        item.Left -= view_model.zombieSpeed;
                        ((PictureBox)item).Image = Properties.Resources.zleft;
                    }
                    if (item.Left < player.Left)
                    {
                        item.Left += view_model.zombieSpeed;
                        ((PictureBox)item).Image = Properties.Resources.zright;
                    }
                    if (item.Top > player.Top)
                    {
                        item.Top -= view_model.zombieSpeed;
                        ((PictureBox)item).Image = Properties.Resources.zup;
                    }
                    if (item.Top < player.Top)
                    {
                        item.Top += view_model.zombieSpeed;
                        ((PictureBox)item).Image = Properties.Resources.zdown;
                    }
                }

                foreach (Control item2 in this.Controls)
                {
                    if (item2 is PictureBox && (string)item2.Tag == "bullet" && item is PictureBox && (string)item.Tag == "zombie")
                    {
                        if (item.Bounds.IntersectsWith(item2.Bounds))
                        {
                            view_model.player_class.score++;
                            this.Controls.Remove(item2);
                            ((PictureBox)item2).Dispose();
                            this.Controls.Remove(item);
                            ((PictureBox)item).Dispose();
                            view_model.zombiesList.Remove(((PictureBox)item));
                            view_model.MakeZombies(player, this);
                        }
                    }
                }
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (view_model.player_class.gameOver == true)
            {
                return;
            }

            if (e.KeyCode == Keys.Left)
            {
                view_model.player_class.goLeft = true;
                view_model.player_class.facing = "left";
                player.Image = Properties.Resources.left;
            }

            if (e.KeyCode == Keys.Right)
            {
                view_model.player_class.goRight = true;
                view_model.player_class.facing = "right";
                player.Image = Properties.Resources.right;
            }
            if (e.KeyCode == Keys.Up)
            {
                view_model.player_class.goUp = true;
                view_model.player_class.facing = "up";
                player.Image = Properties.Resources.up;
            }

            if (e.KeyCode == Keys.Down)
            {
                view_model.player_class.goDown = true;
                view_model.player_class.facing = "down";
                player.Image = Properties.Resources.down;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                view_model.player_class.goLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                view_model.player_class.goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                view_model.player_class.goUp = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                view_model.player_class.goDown = false;
            }

            if (e.KeyCode == Keys.Space && view_model.player_class.ammo > 0 && view_model.player_class.gameOver == false)
            {
                view_model.player_class.ammo--;
                view_model.ShootBullet(view_model.player_class.facing, player, this);

                if (view_model.player_class.ammo < 1)
                {
                    view_model.DropAmmo(player, this);
                }
            }

            if (e.KeyCode == Keys.Enter && view_model.player_class.gameOver == true)
            {
                view_model.RestartGame(player, this, GameTimer);
            }
        }

        private void Form_Deactivate(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
