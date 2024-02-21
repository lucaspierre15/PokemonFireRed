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
using System.Text.Json.Serialization;

namespace Pokemon_FireRed
{
    public partial class Form1 : Form
    {
        private WaveOutEvent waveOutEvent;
        private AudioFileReader audioFileReader;

        private Panel panelScreen = new Panel();
        private Panel panelChoose = new Panel();

        private Button btnProxBtn;
        private Font pokemonFont = new Font(new FontFamily("Pokemon Fire Red"), 28);
        private PictureBox pbTitleScreen, pbChossePlayer, pbShowPlayer, pbNamePlayer,
            pbTextBox;

        public Form1()
        {
            
            InitializeComponent();
            InitializeTitleLoad();

            btnProxBtn = new Button();
            btnProxBtn.Size = new Size(50, 15);
            btnProxBtn.Location = new Point(0, 0);
            btnProxBtn.BackColor = Color.White; 
            Controls.Add(btnProxBtn);
            btnProxBtn.Click += btnProxBtn_Click;

            //TextBox pao = new TextBox();
            //pao.Size = new Size(60, 20);
            //pao.Location = new Point(20, 20);
            //panelScreen.Controls.Add(pao);
            //pao.BringToFront();

            //Label asd = new Label();
            //asd.Size = new Size(70, 30);
            //asd.Location = new Point(30, 30);
            //asd.Font = pokemonFont;
            //asd.Text = "Pokémom";
            //panelScreen.Controls.Add(asd);

        }
        private void btnProxBtn_Click(object sender, EventArgs e)
        {
            FormGame formGame = new FormGame();
            formGame.ShowDialog();
            this.Close();
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

        private void InitializeLoginComponent()
        {
            pbTitleScreen.Visible = false;
            pbTitleScreen.Enabled = false;

            LoadPanelScreen();
            panelScreen.BackgroundImage = Image.FromFile(@"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Images or GIFS\ScreenPlayer.png");
            panelScreen.BackgroundImageLayout = ImageLayout.Stretch;

            panelChoose = new Panel
            {
                Size = new Size(364, 229),
                Location = new Point(566, 311),
                BackgroundImage = Image.FromFile(@"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Images or GIFS\ChooseBoyAndGirl.png"),
                BackgroundImageLayout = ImageLayout.Stretch
            };
            panelScreen.Controls.Add(panelChoose);

            pbTextBox = new PictureBox
            {
                Size = new Size(959, 215),
                Location = new Point(22, 541),
                BackgroundImage = Image.FromFile(@"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Images or GIFS\TextBoxBar.png"),
                BackgroundImageLayout = ImageLayout.Stretch
            };
            panelScreen.Controls.Add(pbTextBox);

        }

        private void LoadPanelScreen()
        {

            panelScreen.Size = new Size(Inf.WIDTH, Inf.HEIGHT);

            panelScreen.BackColor = Color.Aquamarine;

            int pointX = (Screen.PrimaryScreen.Bounds.Width - panelScreen.Width) / 2;
            int pointY = (Screen.PrimaryScreen.Bounds.Height - panelScreen.Height) / 2;

            panelScreen.Location = new Point(pointX, pointY);
            Controls.Add(panelScreen);
        }

        //private string LabelPrueba()
        //{
        //    string prueba = "";
        //    prueba = CarregarDados();

        //    MessageBox.Show("Contenido del archivo: " + prueba);

        //    return prueba;
        //}

        //internal static string CarregarDados()
        //{
        //    try
        //    {
        //        using FileStream fs = File.Open(@"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Usuario.txt", FileMode.OpenOrCreate, FileAccess.Read, FileShare.Delete);
        //        using StreamReader sr = new StreamReader(fs);

        //        string contenido = sr.ReadToEnd();
        //        if (string.IsNullOrEmpty(contenido))
        //            return "";

        //        //Esto es para convertir ese texto en el objeto que quiera deserializar del JSON
        //        //messagem = JsonConvert.DeserializeObject<List<Utilizador>>(contenido) ?? new Classe();

        //        return contenido;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Erro ao lêr os utilizadores: {ex.Message}");
        //    }

        //    return "";
        //}

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                InitializeLoginComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e) => InitializeLoginComponent();

        private void pbTitleScreen_Click(object sender, EventArgs e) => InitializeLoginComponent();

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            //string algo = "";
            //algo = LabelPrueba();
        }
    }
}

