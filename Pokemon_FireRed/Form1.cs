using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Pokemon_FireRed.Entities.Classes;

namespace Pokemon_FireRed
{
    public partial class Form1 : Form
    {
        private WaveOutEvent waveOutEvent;
        private AudioFileReader audioFileReader;

        PictureBox pbTitleScreen;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeTitleLoad();
            
        }

        private void InitializeTitleLoad()
        {
            //Inicializa o formulario
            ClientSize = new Size(1386, 788);
            BackColor = Color.Black;
            CenterToScreen();

            //Adiciona e modifica a PictureBox
            pbTitleScreen = new PictureBox();
            pbTitleScreen.ImageLocation = @"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Images or GIFS\TitleScreen.gif";

            pbTitleScreen.Size = new Size(999, 772);
            pbTitleScreen.SizeMode = PictureBoxSizeMode.StretchImage;

            int x = (Screen.PrimaryScreen.Bounds.Width - pbTitleScreen.Width) / 2;
            int y = (Screen.PrimaryScreen.Bounds.Height - pbTitleScreen.Height) / 2;

            pbTitleScreen.Location = new Point(x, y);
            Controls.Add(pbTitleScreen);

            //Adiciona a música 
            string musicPath = @"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Music\PokémonFireRedTitle Screen.wav";

            // Inicie a reprodução da música em uma thread separada
            Task.Run(() => MusicTitleLoad(musicPath));

        }

        private void MusicTitleLoad(string mP)
        {

            try
            {
                // Inicialize o leitor de áudio
                audioFileReader = new AudioFileReader(mP);

                // Inicialize o evento de saída de áudio
                waveOutEvent = new WaveOutEvent();
                waveOutEvent.Init(audioFileReader);

                // Reproduza a música indefinidamente até 
                //que pbTitleScreen não seja mais visível
                while (pbTitleScreen.Visible)
                {
                    waveOutEvent.Play();

                    // Aguarde um curto período antes de verificar novamente
                    Thread.Sleep(100);

                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Pare a reprodução quando pbTitleScreen não for mais visível
                waveOutEvent?.Stop();
                waveOutEvent?.Dispose();
                audioFileReader?.Dispose();
            }
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                pbTitleScreen.Enabled = false;
                pbTitleScreen.Visible = false;
            FormGame game = new FormGame();
            game.ShowDialog();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            pbTitleScreen.Enabled = false;
            pbTitleScreen.Visible = false;
            FormGame game = new FormGame();
            game.ShowDialog();
        }

        private void pbTitleScreen_Click(object sender, EventArgs e)
        {
            pbTitleScreen.Enabled = false;
            pbTitleScreen.Visible = false;
            FormGame game = new FormGame();
            game.ShowDialog();
        }
    }
}
