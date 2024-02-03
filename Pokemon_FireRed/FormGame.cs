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

        public FormGame()
        {
            InitializeComponent();
            // Inicializa Todos os objetos e coisas básicas
            InitializeJogo();
            // Calculos com o Timer 
            TimerDrawMap();
        }

        private void InitializeJogo()
        {
            ClientSize = new Size(Inf.SCREENW, Inf.SCREENH);
            BackColor = Color.Black;

            //Images
            pbImageMap  = new PictureBox();
            pbPlayer = new PictureBox();

            // 49c Largura 37c Altura | 20p, 21p Cada Celula 
            map = new Map();

            pbImageMap.ImageLocation = @"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Images or GIFS\PalletCity01.png";
            pbImageMap.Size = new Size(Inf.WIDTH, Inf.HEIGHT);
            pbImageMap.SizeMode = PictureBoxSizeMode.StretchImage;

            int x = (panelMapa.Width - pbImageMap.Width) / 2;
            int y = (panelMapa.Height - pbImageMap.Height) / 2;

            pbImageMap.Location = new Point(x, y);
            pbImageMap.Anchor = AnchorStyles.None;
            panelMapa.Controls.Add(pbImageMap);

            player = new Trainer(name, 1, 1, pbPlayer);
            pbPlayer.Size= new Size (Inf.CELLW, Inf.CELLH);
            

            panelMapa.Controls.Add(pbPlayer);
            pbPlayer.BringToFront();

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
            DrawMap();
            DrawPlayer();
        }


        private void DrawMap()
        {
            panelMapa.Size = new Size(Inf.WIDTH, Inf.HEIGHT);

            int pointX = (Screen.PrimaryScreen.Bounds.Width - panelMapa.Width) / 2;
            int pointY = (Screen.PrimaryScreen.Bounds.Height - panelMapa.Height) / 2;

            panelMapa.Location = new Point(pointX, pointY);
            /*
            using Graphics g = panelMapa.CreateGraphics();
            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    Color corCelula;

                    switch (map.HaColisao(x, y))
                    {
                        case CollisionType.WALL:
                            corCelula = Color.Red;
                            break;
                        case CollisionType.BUSH:
                            corCelula = Color.DarkGreen;
                            break;
                        case CollisionType.INTERATION:
                            corCelula = Color.Yellow;
                            break;
                        case CollisionType.DOOR:
                            corCelula = Color.White;
                            break;
                        case CollisionType.NO_COLLISION:
                            corCelula = Color.AliceBlue;
                            break;
                        default:
                            corCelula = Color.Orange;
                            break;
                    }

                    using SolidBrush brush = new SolidBrush(corCelula);
                    g.FillRectangle(brush, x * map.WidhtCell, y * map.HeightCell,
                        map.WidhtCell, map.HeightCell
                        );
                }
            }*/
        }


        private void DrawPlayer()
        {
            map = new Map();
            int jogadorX = player.CurrentPosition.X;
            int jogadorY = player.CurrentPosition.Y;
            pbPlayer.Location = new Point(jogadorX * map.WidhtCell, jogadorY * map.HeightCell/*, map.WidhtCell, map.HeightCell*/);
                               
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
    }
}

