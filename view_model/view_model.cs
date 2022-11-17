using Game_Kursak.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game_Kursak.view_model
{
    internal class View_model
    {
        Client client = new Client();
        public Player player_class = new Player("up", 100, 10, 10);
        public int zombieSpeed = 3;
        public Random randNum = new Random();
        public List<PictureBox> zombiesList = new List<PictureBox>();
        public List<PictureBox> ammo_and_health = new List<PictureBox>();
        public List<SaveResult> results = new List<SaveResult>();
        public Player z = new Player("up", 100, 10, 10);



        public void ShootBullet(string direction,PictureBox player, Form main)
        {
            Bullet shootBullet = new Bullet();
            shootBullet.diraction = direction;
            shootBullet.bulletLeft = player.Left + (player.Width / 2);
            shootBullet.bulletTop = player.Top + (player.Height / 5);
            shootBullet.MakeBullet(main);
        }

        public void ShootBulletZombie(string direction, PictureBox zombie, Form main)
        {
            Bullet_Zombie shootBulletZombie = new Bullet_Zombie();
            shootBulletZombie.diraction = direction;
            shootBulletZombie.bulletLeft = zombie.Left + (zombie.Width / 2);
            shootBulletZombie.bulletTop = zombie.Top + (zombie.Height / 2);
            shootBulletZombie.MakeBullet(main);
        }

        public void MakeZombies(PictureBox player, Form main)
        {
            PictureBox zombie = new PictureBox();
            zombie.BackColor = Color.FromArgb(0,0,0,0);
            zombie.Tag = "zombie";
            zombie.Image = Properties.Resources.zdown;
            zombie.Left = randNum.Next(0, 900);
            zombie.Top = randNum.Next(0, 800);
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;
            zombiesList.Add(zombie);
            main.Controls.Add(zombie);
            player.BringToFront();
        }

        public void MakeZombiesShooter(PictureBox player, Form main, Bitmap facingResorce, string tag)
        {
            PictureBox zombie_shooter = new PictureBox();
            zombie_shooter.BackColor = Color.FromArgb(0, 0, 0, 0);
            zombie_shooter.Tag = tag;
            zombie_shooter.Image = facingResorce;
            zombie_shooter.Left = randNum.Next(0, 800);
            zombie_shooter.Top = randNum.Next(0, 600);
            zombie_shooter.SizeMode = PictureBoxSizeMode.AutoSize;
            zombiesList.Add(zombie_shooter);
            main.Controls.Add(zombie_shooter);
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
            ammo_and_health.Add(ammo);
            ammo.BringToFront();
            player.BringToFront();
        }

        public void DropHP(PictureBox player, Form main)
        {
            PictureBox helth = new PictureBox();
            helth.Image = Properties.Resources.hp_Image;
            helth.SizeMode = PictureBoxSizeMode.AutoSize;
            helth.Left = randNum.Next(10, main.ClientSize.Width - helth.Width);
            helth.Top = randNum.Next(60, main.ClientSize.Height - helth.Height);
            helth.Tag = "hp";
            main.Controls.Add(helth);
            ammo_and_health.Add(helth);
            helth.BringToFront();
            player.BringToFront();
        }

        public void RestartGame(PictureBox player, Form main, Timer GameTimer, Timer TimeOfGame)
        {
            player.Image = Properties.Resources.up;
            
            foreach (PictureBox item in zombiesList)
            {
                main.Controls.Remove(item);
            }
            zombiesList.Clear();

            foreach (PictureBox item in ammo_and_health)
            {
                main.Controls.Remove(item);
            }
            ammo_and_health.Clear();

            for (int i = 0; i < 2; i++)
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
            TimeOfGame.Start();
        }

        public void SaveResultPlayer(string nickName, int kills, int ammo_picked_up, int fired_bullets, int med_kit_picked_up, int hP_replenishment_amount, string game_time)
        {
            SaveResult saveResult = new SaveResult(nickName, kills, ammo_picked_up, fired_bullets, med_kit_picked_up, hP_replenishment_amount, game_time);
            results.Add(saveResult);
        }

        public void SendToServer()
        {
            client.Work("Hello!");
        }
    }
}
