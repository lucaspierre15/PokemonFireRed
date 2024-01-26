using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemon_FireRed
{
    public partial class Form1 : Form
    {
        private SoundPlayer Music;
        private Task MusicTask;
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

            Task.Run(() => MusicTitleLoad());

            ClientSize = new Size(1386, 788);
            BackColor = Color.Black;

            pbTitleScreen.Size = new Size(999, 772);
            int x = (Screen.PrimaryScreen.Bounds.Width - pbTitleScreen.Width) / 2;
            int y = (Screen.PrimaryScreen.Bounds.Height - pbTitleScreen.Height) / 2;

            pbTitleScreen.Location = new System.Drawing.Point(x, y);
        }

        private async Task MusicTitleLoad()
        {
            Music = new SoundPlayer();

            Music.SoundLocation = @"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Music\PokémonFireRedTitle Screen.wav";

            try
            {
                while (pbTitleScreen.Visible)
                {
                    Music.Play();
                    await Task.Delay(100);
                }
                Music.Stop();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                pbTitleScreen.Enabled = false;
                pbTitleScreen.Visible = false;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            pbTitleScreen.Enabled = false;
            pbTitleScreen.Visible = false;
        }

        private void pbTitleScreen_Click(object sender, EventArgs e)
        {
            pbTitleScreen.Enabled = false;
            pbTitleScreen.Visible = false;
        }
    }
}
