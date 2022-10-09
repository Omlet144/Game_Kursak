using Game_Kursak.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Kursak.view_model
{
    internal class View_model
    {
        public Player player_class = new Player("up", 100, 10, 10);
        public int zombieSpeed = 3;
        public Random randNum = new Random();
        public List<PictureBox> zombiesList = new List<PictureBox>();



        public void ShootBullet(string direction,PictureBox player, Form main)
        {
            Bullet shootBullet = new Bullet();
            shootBullet.diraction = direction;
            shootBullet.bulletLeft = player.Left + (player.Width / 2);
            shootBullet.bulletTop = player.Top + (player.Height / 2);
            shootBullet.MakeBullet(main);
        }

        public void MakeZombies(PictureBox player, Form main)
        {
            PictureBox zombie = new PictureBox();
            zombie.Tag = "zombie";
            zombie.Image = Properties.Resources.zdown;
            zombie.Left = randNum.Next(0, 900);
            zombie.Top = randNum.Next(0, 800);
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;
            zombiesList.Add(zombie);
            main.Controls.Add(zombie);
            player.BringToFront();
        }

        public void DropAmmo(PictureBox player, Form main)
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo_Image;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = randNum.Next(10, main.ClientSize.Width - ammo.Width);
            ammo.Top = randNum.Next(60, main.ClientSize.Height - ammo.Height);
            ammo.Tag = "ammo";
            main.Controls.Add(ammo);

            ammo.BringToFront();
            player.BringToFront();
        }

        public void RestartGame(PictureBox player, Form main, Timer GameTimer)
        {
            player.Image = Properties.Resources.up;

            foreach (PictureBox item in zombiesList)
            {
                main.Controls.Remove(item);
            }
            zombiesList.Clear();

            for (int i = 0; i < 3; i++)
            {
                MakeZombies(player, main);
            }

            player_class.goUp = false;
            player_class.goDown = false;
            player_class.goLeft = false;
            player_class.goRight = false;
            player_class.gameOver = false;

            player_class.playerHealth = 100;
            player_class.score = 0;
            player_class.ammo = 10;

            GameTimer.Start();
        }
    }
}
