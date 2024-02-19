using Pokemon_FireRed.Entities.Classes;
using Pokemon_FireRed.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pokemon_FireRed
{
     public partial class FormGame : Form
    {
        private string name = "Batman";
        private Map map;
        private Trainer player;

        PictureBox pbImageMap;
        PictureBox pbPlayer;
        Label label1;


        public FormGame()
        {
            InitializeComponent();
            MapComponent();
            PlayerComponent();
            TimerDrawMap();
        }

        private void MapComponent()
        {
            ClientSize = new Size(Inf.SCREENW, Inf.SCREENH);
            BackColor = Color.Black;

            pbImageMap = new PictureBox();
            pbPlayer = new PictureBox();
            map = new Map();


            panelMapa.Size = new Size(Inf.WIDTH, Inf.HEIGHT);

            int pointX = (Screen.PrimaryScreen.Bounds.Width - panelMapa.Width) / 2;
            int pointY = (Screen.PrimaryScreen.Bounds.Height - panelMapa.Height) / 2;

            panelMapa.Location = new Point(pointX, pointY);


            pbImageMap.ImageLocation = @"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Images or GIFS\PalletCity01.png";
            pbImageMap.Size = new Size(Inf.WIDTH, Inf.HEIGHT);
            pbImageMap.SizeMode = PictureBoxSizeMode.StretchImage;

            int x = (panelMapa.Width - pbImageMap.Width) / 2;
            int y = (panelMapa.Height - pbImageMap.Height) / 2;
            
            pbImageMap.Location = new Point(x, y);
            pbImageMap.Anchor = AnchorStyles.None;

            panelMapa.Controls.Add(pbImageMap);
          
        }

        private void PlayerComponent()
        {
            player = new Trainer(name, 1, 1, pbPlayer);
            pbPlayer.Size = new Size(Inf.CELLW * 2, Inf.CELLH * 2);
            pbPlayer.BackColor = Color.Transparent;
            pbPlayer.ImageLocation = @"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Red\GIF PNG\RedDown.gif";
            pbPlayer.SizeMode = PictureBoxSizeMode.StretchImage;


            panelMapa.Controls.Add(pbPlayer);
            pbPlayer.BringToFront();

            label1 = new Label();
            label1.BackColor = Color.White;
            label1.Size = new Size(100, 30);
            label1.Location = new Point(1250, 750);
            Controls.Add(label1);
        }

        private void TimerDrawMap()
        {
            // Configura o Timer para atualizar a câmera
            TimerMap.Interval = 50; // Altere conforme necessário
            TimerMap.Tick += TimerMovimento_Tick;
            TimerMap.Start();
        }

        private void TimerMovimento_Tick(object sender, EventArgs e)
        {
            label1.Text = $"{player.CurrentPosition.X}, {player.CurrentPosition.Y}";
            //DrawMap();
            DrawPlayer();
        }


        //private void DrawMap()  
        //{
           

        //    using Graphics g = panelMapa.CreateGraphics();
        //    for (int x = 0; x < map.Width; x++)
        //    {
        //        for (int y = 0; y < map.Height; y++)
        //        {
        //            Color corCelula;

        //            switch (map.HaColisao(x, y))
        //            {
        //                case CollisionType.WALL:
        //                    corCelula = Color.Red;
        //                    break;
        //                case CollisionType.BUSH:
        //                    corCelula = Color.DarkGreen;
        //                    break;
        //                case CollisionType.INTERACTION:
        //                    corCelula = Color.Yellow;
        //                    break;
        //                case CollisionType.DOOR:
        //                    corCelula = Color.White;
        //                    break;
        //                case CollisionType.NO_COLLISION:
        //                    corCelula = Color.BlueViolet;
        //                    break;
        //                default:
        //                    corCelula = Color.Orange;
        //                    break;
        //            }

        //            using SolidBrush brush = new SolidBrush(corCelula);
        //            g.FillRectangle(brush, x * map.WidthCell, y * map.HeightCell,
        //                map.WidthCell, map.HeightCell);
        //        }
        //    }
        //}


        private void DrawPlayer()
        {
            map = new Map();
            int jogadorX = player.CurrentPosition.X;
            int jogadorY = player.CurrentPosition.Y;
            pbPlayer.Location = new Point(jogadorX * map.WidthCell, jogadorY * map.HeightCell/*, map.WidhtCell, map.HeightCell*/);
           
                               
        }

        private void FormGame_KeyDown(object sender, KeyEventArgs e)
        {
            player.HandleMovement(e.KeyCode);
            player.HandleKeyDown();
        }

        private void FormGame_KeyUp(object sender, KeyEventArgs e)
        {
            player.HandleKeyUp();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {

        }
    }
}

