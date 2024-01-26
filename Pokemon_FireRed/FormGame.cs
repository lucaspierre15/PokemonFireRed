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
        private Map mapa;
        private int larguraCadaCelula = 50; // Substitua pelo tamanho desejado em pixels
        private int alturaCadaCelula = 50; // Substitua pelo tamanho desejado em pixels

        public FormGame()
        {
            InitializeComponent();
            InicializarJogo();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            TimerMov();
        }
        public void TimerMov()
        {
            // Configura o Timer para atualizar a câmera
            timerMovimento.Interval = 50; // Altere conforme necessário
            timerMovimento.Tick += timerMovimento_Tick;
            timerMovimento.Start();
        }

        private void InicializarJogo()
        {
            ClientSize = new Size(1386, 788);
            BackColor = Color.Black;

            
            mapa = new Map(20, 20);
            // Substitua 10, 10 pelo tamanho desejado do mapa

            // Configura a posição inicial do jogador
        }

        private void timerMovimento_Tick(object sender, EventArgs e)
        {
            DesenharMapa();
        }

        private void DesenharMapa()
        {
            // Use um controle Panel para representar o mapa

            // Adicione o controle Panel ao formulário

            //panelMapa.Size = new Size(mapa.Largura * larguraCadaCelula, mapa.Altura * alturaCadaCelula);
            
            //panelMapa.Location = new Point(10, 10); // Ajuste conforme necessário

            
            panelMapa.Size = new Size(999, 772);
            int pointX = (Screen.PrimaryScreen.Bounds.Width - panelMapa.Width) / 2;
            int pointY = (Screen.PrimaryScreen.Bounds.Height - panelMapa.Height) / 2;

            panelMapa.Location = new System.Drawing.Point(pointX, pointY);

            // Lógica para desenhar e colorir as células do mapa
            using (Graphics g = panelMapa.CreateGraphics())
            {
                for (int x = 0; x < mapa.Largura; x++)
                {
                    for (int y = 0; y < mapa.Altura; y++)
                    {
                        Color corCelula = mapa.HaColisao(x, y) ? Color.Red : Color.Green;

                        using (SolidBrush brush = new SolidBrush(corCelula))
                        {
                            g.FillRectangle(brush, x * larguraCadaCelula, y * alturaCadaCelula, larguraCadaCelula, alturaCadaCelula);
                        }
                    }
                }
            }
        }

    }
}

