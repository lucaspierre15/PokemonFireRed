using Pokemon_FireRed.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pokemon_FireRed.Entities.Classes
{
    public partial class FormBattle : Form
    {
        private PictureBox myPokemon, wildPokemon, backgroundBattle, 
        myImageGUI, wildImageGUI, ImageInterface, backgroundInterface, ImageIntercafeAttck;

        private Label namePokemon;
        private Panel panelBattle, panelBattleInterface, myPanelGUI, wildPanelGUI, panelAttcks;
        private Button attackBtn;
        private ProgressBar myLifeBar ,wildLifeBar;

        private Pokemon Pikachu, Charmander, Bulbasaur, Squirtle;

        private List<Pokemon> myPokemonList = new List<Pokemon>();

        private void FightBtn_Click(object sender, EventArgs e)
        {
            panelBattleInterface.Visible = false;
            panelAttcks.Visible = true;

        }

        private void PokemonBtn_Click(object sender, EventArgs e)
        {

        }

        private void BagBtn_Click(object sender, EventArgs e)
        {

        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public FormBattle()
        {
            InitializeComponent();
            MapComponent();
            LoadComponent();
            PokemonComponent();
            LoadPokemonComponent();
        }

        private void FormBattle_Load(object sender, EventArgs e)
        {
        }

        private void MapComponent()
        {
            panelTeste.Visible = false;
           

            ClientSize = new Size(Inf.SCREENW, Inf.SCREENH);
            BackColor = Color.Black;
            this.CenterToScreen();

            panelBattle = new Panel();
            panelBattle.BackColor = Color.Black;
            panelBattle.Size = new Size(Inf.WIDTH, Inf.HEIGHT);

            int pointX = (Screen.PrimaryScreen.Bounds.Width - panelBattle.Width) / 2;
            int pointY = (Screen.PrimaryScreen.Bounds.Height - panelBattle.Height) / 2;
            panelBattle.Location = new Point(pointX, pointY); 

            Controls.Add(panelBattle);
            SendToBack();
        }

        private void LoadComponent()
        { 
            panelAttcks = new Panel();
            panelAttcks.Size = new Size(Inf.WIDTH, 204);
            panelAttcks.Location = new Point(0, 520);
            panelAttcks.BackColor = Color.Blue;
            panelBattle.Controls.Add(panelAttcks);
            panelAttcks.Visible = false;

            ImageIntercafeAttck = new PictureBox();
            ImageIntercafeAttck.Size = new Size(Inf.WIDTH, 204);
            ImageIntercafeAttck.SizeMode = PictureBoxSizeMode.StretchImage;
            ImageIntercafeAttck.Location = new Point(0, 520);
            ImageIntercafeAttck.ImageLocation = @"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Images or GIFS\InterfaceAttck.png";
            panelAttcks.Controls.Add(ImageIntercafeAttck);



            backgroundBattle = new PictureBox();
            backgroundBattle.Size = new Size(Inf.WIDTH, 480);
            backgroundBattle.SizeMode = PictureBoxSizeMode.StretchImage;
            backgroundBattle.Location = new Point(3, 42);
            backgroundBattle.ImageLocation = @"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Images or GIFS\BackGroung_Battle_01.png";
            backgroundBattle.SendToBack();
            panelBattle.Controls.Add(backgroundBattle);
            

            wildPanelGUI = new Panel();
            wildPanelGUI.Size = new Size(432, 135);
            wildPanelGUI.Location = new Point(45, 106);
            panelBattle.Controls.Add(wildPanelGUI);
            wildPanelGUI.BringToFront();

            wildImageGUI = new PictureBox();
            wildImageGUI.Size = new Size(432, 135);
            wildImageGUI.SizeMode = PictureBoxSizeMode.StretchImage;
            wildImageGUI.Location = new Point(0, 0);
            wildImageGUI.ImageLocation = @"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Images or GIFS\WildLifeBarGUI.png";
            wildPanelGUI.Controls.Add(wildImageGUI);


            myPanelGUI = new Panel();
            myPanelGUI.Size = new Size(445, 166);
            myPanelGUI.Location = new Point(521, 356);
            panelBattle.Controls.Add(myPanelGUI);
            myPanelGUI.BringToFront();

            myImageGUI = new PictureBox();
            myImageGUI.Size = new Size(445, 166);
            myImageGUI.SizeMode = PictureBoxSizeMode.StretchImage;
            myImageGUI.Location = new Point(0, 0);
            myImageGUI.ImageLocation = @"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Images or GIFS\MyLifeBarGUI.png";
            myPanelGUI.Controls.Add(myImageGUI);


            panelBattleInterface = new Panel();
            panelBattleInterface.Size = new Size(Inf.WIDTH, 204);
            panelBattleInterface.Location = new Point(0, 520);
            panelBattleInterface.BackColor = Color.DarkRed;
            panelBattle.Controls.Add(panelBattleInterface);

            backgroundInterface = new PictureBox();
            backgroundInterface.Size = new Size(Inf.WIDTH, 204);
            backgroundInterface.SizeMode = PictureBoxSizeMode.StretchImage;
            backgroundInterface.Location = new Point(0, 0);
            backgroundInterface.ImageLocation= @"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Images or GIFS\BackGround_Interface.png";
            panelBattleInterface.Controls.Add(backgroundInterface);
            backgroundInterface.SendToBack();

            ImageInterface = new PictureBox();
            ImageInterface.Size = new Size(499, 204);
            ImageInterface.SizeMode = PictureBoxSizeMode.StretchImage;
            ImageInterface.Location = new Point(500, 0);
            ImageInterface.ImageLocation = @"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Images or GIFS\Interface01.png";
            panelBattleInterface.Controls.Add(ImageInterface);
            ImageInterface.BringToFront();

            wildLifeBar = new ProgressBar();
            wildLifeBar.Size = new Size(203, 18);
            wildLifeBar.Location = new Point(172, 77);
            wildLifeBar.Value = 100;
            wildLifeBar.ForeColor = Color.FromArgb(112, 248, 168);
            wildLifeBar.BackColor = Color.FromArgb(217, 222, 219);
            wildLifeBar.Style = ProgressBarStyle.Continuous;
            wildPanelGUI.Controls.Add(wildLifeBar);
            wildLifeBar.BringToFront();


            myLifeBar = new ProgressBar();
            myLifeBar.Size = new Size(203, 18);
            myLifeBar.Location = new Point(205, 74);
            myLifeBar.Value = 100;
            myLifeBar.ForeColor = Color.FromArgb(112, 248, 168);
            myLifeBar.BackColor = Color.FromArgb(217, 222, 219);
            myLifeBar.Style = ProgressBarStyle.Continuous;
            myPanelGUI.Controls.Add(myLifeBar);
            myLifeBar.BringToFront();

            wildPokemon = new PictureBox();
            wildPokemon.Size = new Size(277, 276);
            wildPokemon.Location = new Point(598, 82);
            wildPokemon.BackColor = Color.FromArgb(226, 226, 226);
            wildPokemon.SizeMode = PictureBoxSizeMode.StretchImage;
            panelBattle.Controls.Add(wildPokemon);
            wildPokemon.BringToFront();

            myPokemon = new PictureBox();
            myPokemon.Size = new Size(266, 249);
            myPokemon.Location = new Point(168, 273);
            myPokemon.BackColor = Color.FromArgb(226, 226, 226);
            myPokemon.SizeMode = PictureBoxSizeMode.StretchImage;
            panelBattle.Controls.Add(myPokemon);
            myPokemon.BringToFront();


            panelBattleInterface.Controls.Add(FightBtn);
            panelBattleInterface.Controls.Add(PokemonBtn);
            panelBattleInterface.Controls.Add(BagBtn);
            panelBattleInterface.Controls.Add(RunBtn);

            panelAttcks.Controls.Add(AttckBtn01);
            panelAttcks.Controls.Add(AttckBtn02);
            panelAttcks.Controls.Add(AttckBtn03);
            panelAttcks.Controls.Add(AttckBtn04);
            
        }

        private void PokemonComponent()
        {
            //Pikachu
            Pikachu = new Pokemon("Pikachu", PokemonType.ELETRIC, PokemonType.NONE, 5, 10,
                PokemonSpecies.PIKACHU,
               @"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Pokemons Sprites\Bulbasaur\SprBattle_Bulbasaur.png",
               @"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Pokemons Sprites\Bulbasaur\SprWild_Bulbasaur.png",
                35, 55, 40, 50, 50, 90);

            Pikachu.LearnAttack("Quick Attack", PokemonType.NORMAL, MoveType.PHYSICAL, 40, 100);
            Pikachu.LearnAttack("Thunder Shock", PokemonType.ELETRIC, MoveType.SPECIAL, 40, 100);
            Pikachu.LearnAttack("Thunder Wave", PokemonType.ELETRIC, MoveType.STATUS, 0, 90);

            //myPokemonList.Add(Pikachu);

            //Baulbasaur
            Bulbasaur = new Pokemon("Bulbasaur", PokemonType.GRASS, PokemonType.POISON, 5, 10,
                PokemonSpecies.BULBASAUR,
                @"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Pokemons Sprites\Pikachu\sprBattle_Pikachu.png",
                @"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Pokemons Sprites\Pikachu\sprWild_Pikachu.png",
                45, 49, 49, 65, 65, 45);

            Bulbasaur.LearnAttack("Growl", PokemonType.NORMAL, MoveType.STATUS, 0, 100);
            Bulbasaur.LearnAttack("Tackle", PokemonType.NORMAL, MoveType.PHYSICAL, 40, 100);
            Bulbasaur.LearnAttack("Vine Whip", PokemonType.GRASS, MoveType.PHYSICAL, 45, 100);

           // myPokemonList.Add(Bulbasaur);

        }

        private void LoadPokemonComponent()
        {
            myPokemon.ImageLocation = Pikachu.MySpritePath;
            wildPokemon.ImageLocation = Bulbasaur.WildSpritePath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Bulbasaur.Attck >= myLifeBar.Minimum & Bulbasaur.Attck <= myLifeBar.Maximum)
                myLifeBar.Value = myLifeBar.Value - Bulbasaur.Attck;

            if (myLifeBar.Value == 0)
                MessageBox.Show("Ganhou");
        }
    }
}
