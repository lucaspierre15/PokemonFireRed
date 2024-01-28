using Pokemon_FireRed.Entities.Classes;
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
        private bool keyIsPressed;

        private Map map;
        private Trainer player;
        

        public FormGame()
        {
            InitializeComponent();
            //Inicializa Todos os objetos e coisas basicas
            InitializeJogo();
            //Calculos com o Timer 
            TimerDrawMap();
        }

        public void TimerDrawMap()
        {
            // Configura o Timer para atualizar a câmera
            TimerMap.Interval = 50; // Altere conforme necessário
            TimerMap.Tick += TimerMovimento_Tick;
            TimerMap.Start();
        }

        private void InitializeJogo()
        {
            ClientSize = new Size(1386, 788);
            BackColor = Color.Black;

            //49c Largura 37c Altura | 20p, 21p Cada Celula 
            map = new Map(49, 37, 20, 21);

            //
            player = new Trainer(name, 1, 1);

            // Configura a posição inicial do jogador
        }

        private void TimerMovimento_Tick(object sender, EventArgs e)
        {
            DrawMap();
            DrawPlayer();
        }

        private void DrawMap()
        {
            // Use um controle Panel para representar o mapa

            //panelMapa.Size = new Size(mapa.Largura * larguraCadaCelula, mapa.Altura * alturaCadaCelula);

            //panelMapa.Location = new Point(10, 10); // Ajuste conforme necessário

            panelMapa.Size = new Size(999, 772);
            int pointX = (Screen.PrimaryScreen.Bounds.Width - panelMapa.Width) / 2;
            int pointY = (Screen.PrimaryScreen.Bounds.Height - panelMapa.Height) / 2;

            panelMapa.Location = new System.Drawing.Point(pointX, pointY);

            // Lógica para desenhar e colorir as células do mapa
            using Graphics g = panelMapa.CreateGraphics();
            for (int x = 0; x < map.Largura; x++)
            {
                for (int y = 0; y < map.Altura; y++)
                {
                    Color vermCelula = Color.FromArgb(255, 0, 0);
                    Color AzulCelula = Color.FromArgb(0, 0, 255);

                    Color corCelula = map.HaColisao(x, y) ? vermCelula : AzulCelula;

                    using SolidBrush brush = new SolidBrush(corCelula);
                        g.FillRectangle(brush, x * map.LarguraCadaCelula, y * map.AlturaCadaCelula,
                            map.LarguraCadaCelula, map.AlturaCadaCelula);
                }
            }
        }

        private void DrawPlayer()
        {
            using Graphics g = panelMapa.CreateGraphics();
            Color playerCor = Color.FromArgb(255, 192, 203);

            int jogadorX = player.CurrentPosition.X;
            int jogadorY = player.CurrentPosition.Y;

            using (SolidBrush brush = new SolidBrush(playerCor))
                g.FillRectangle(brush, jogadorX * map.LarguraCadaCelula, jogadorY * map.AlturaCadaCelula,
                                map.LarguraCadaCelula, map.AlturaCadaCelula);
            
        }

        private void FormGame_KeyDown(object sender, KeyEventArgs e)
        {
            player.HandleMovement(e.KeyCode);
            player.HandleKeyDown();

            //RedesenharJogo();

        }

        private void FormGame_KeyUp(object sender, KeyEventArgs e)
        {
            player.HandleKeyUp();
        }
    }
}

