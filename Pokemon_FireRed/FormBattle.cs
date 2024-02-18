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
        private PictureBox myPokemon, wildPokemon;

        private Label namePokemon;
        private Panel panelBattle;


        private Pokemon Pikachu, Charmander, Bulbasaur, Squirtle;

        private List<Pokemon> myPokemonList = new List<Pokemon>();

        public FormBattle()
        {
            InitializeComponent();
            MapComponent();
            LoadComponent();
            PokemonComponent();
            LoadBattleComponent();
        }

        private void FormBattle_Load(object sender, EventArgs e)
        {
        }

        private void MapComponent()
        {
            ClientSize = new Size(Inf.SCREENW, Inf.SCREENH);
            BackColor = Color.Black;
            this.CenterToScreen();

            panelBattle = new Panel();
            panelBattle.BackColor = Color.IndianRed;
            panelBattle.Size = new Size(Inf.WIDTH, Inf.HEIGHT);

            int pointX = (Screen.PrimaryScreen.Bounds.Width - panelBattle.Width) / 2;
            int pointY = (Screen.PrimaryScreen.Bounds.Height - panelBattle.Height) / 2;
            panelBattle.Location = new Point(pointX, pointY);

            Controls.Add(panelBattle);
            SendToBack();
        }

        private void LoadComponent()
        {


            namePokemon = new Label();
            namePokemon.Size = new Size(200, 30);
            namePokemon.Location = new Point(300, 200);

            myPokemon = new PictureBox();
            myPokemon.Size = new Size(200, 200);
            myPokemon.Location = new Point(300, 300);
            myPokemon.SizeMode = PictureBoxSizeMode.StretchImage;

            namePokemon = new Label();
            namePokemon.Size = new Size(200, 30);
            namePokemon.Location = new Point(300, 200);

            Controls.Add(namePokemon);
            Controls.Add(myPokemon);
        }

        private void PokemonComponent()
        {
            //Pikachu
            Pikachu = new Pokemon("Pikachu", PokemonType.ELETRIC, PokemonType.NONE, 5, 10,
                PokemonSpecies.PIKACHU,
                "\"C:\\Users\\lucas\\OneDrive\\Área de Trabalho\\Pokemons Sprites\\Pikachu\\sprBattle_Pikachu.png\"",
                "\"C:\\Users\\lucas\\OneDrive\\Área de Trabalho\\Pokemons Sprites\\Pikachu\\sprWild_Pikachu.png\"",
                35, 55, 40, 50, 50, 90);

            myPokemonList.Add(Pikachu);

            //Baulbasaur
            Bulbasaur = new Pokemon("Bulbasaur", PokemonType.GRASS, PokemonType.POISON, 5, 10,
                PokemonSpecies.BULBASAUR,
                "\"C:\\Users\\lucas\\OneDrive\\Área de Trabalho\\Pokemons Sprites\\Bulbasaur\\SprWild_Bulbasaur.png\"",
                "\"C:\\Users\\lucas\\OneDrive\\Área de Trabalho\\Pokemons Sprites\\Bulbasaur\\SprBattle_Bulbasaur.png\"",
                45, 49, 49, 65, 65, 45);

            myPokemonList.Add(Bulbasaur);
        }

        private void LoadBattleComponent()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            progress.Value += 10;
            if (progress.Value > 20)
                progress.ForeColor = Color.Azure;
            if (progress.Value > 30)
                progress.ForeColor = Color.DarkRed;
        }
    }
}
