using Pokemon_FireRed.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemon_FireRed.Entities.Classes
{
    public partial class FormBattle : Form
    {
        private PictureBox myPokemon, wildPokemon, backgroundBattle;

        private Label lblMyNamePokemon, lblEnemyNamePokemon, textBattle;

        private Panel panelBattle, panelBattleInterface, panelChooseOptions, 
            myPanelGUI, wildPanelGUI, panelAttcks;

        private Button FightBtn, PokemonBtn, BagBtn, RunBtn, 
            attckBtn1, attckBtn2, attckBtn3, attckBtn4;

        private Font pokemonFont = new Font(new FontFamily("Pokemon Fire Red"), 35);

        private ProgressBar myLifeBar ,wildLifeBar;

        private Pokemon Pikachu, Charmander, Bulbasaur, Squirtle;

        private List<Pokemon> myPokemonList = new List<Pokemon>();

        private Battle battle;

        private string currentBattleText = "";
        private int currentCharIndex = 0;

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
            PokemonComponent();
            BattleStructure();
        }

        private void MapComponent()
        {   

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
            
        
            backgroundBattle = new PictureBox
            {
                Size = new Size(Inf.WIDTH, 480),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(3, 42),
                ImageLocation = @"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Images or GIFS\BackGroung_Battle_01.png",
                BackgroundImageLayout = ImageLayout.Stretch
            };
            backgroundBattle.SendToBack();
            panelBattle.Controls.Add(backgroundBattle);

            panelBattleInterface = new Panel
            {
                Size = new Size(Inf.WIDTH, 204),
                Location = new Point(0, 520),
                BackgroundImage = Image.FromFile(@"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Images or GIFS\BackGround_Interface.png"),
                BackgroundImageLayout = ImageLayout.Stretch
            };
            panelBattle.Controls.Add(panelBattleInterface);

            textBattle = new Label
            {
                Size = new Size(470,140),
                Location = new Point(31, 37),
                Font = new Font(new FontFamily("Pokemon Fire Red"), 60),
                BackColor = Color.DarkRed,
                ForeColor = Color.FromArgb(219, 238, 244)
               
            };
            panelBattleInterface.Controls.Add(textBattle);
            textBattle.BringToFront();

            wildPanelGUI = new Panel
            {
                Size = new Size(432, 135),
                Location = new Point(45, 106),
                BackColor = Color.FromArgb(232, 232, 232),
                BackgroundImage = Image.FromFile(@"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Images or GIFS\WildLifeBarGUI.png"),
                BackgroundImageLayout = ImageLayout.Stretch
            };
            panelBattle.Controls.Add(wildPanelGUI);
            wildPanelGUI.BringToFront();

            myPanelGUI = new Panel
            {
                Size = new Size(445, 166),
                Location = new Point(521, 356),
                BackColor = Color.FromArgb(232, 232, 232),
                BackgroundImage = Image.FromFile(@"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Images or GIFS\MyLifeBarGUI.png"),
                BackgroundImageLayout = ImageLayout.Stretch
            };
            panelBattle.Controls.Add(myPanelGUI);
            myPanelGUI.BringToFront();

            wildPokemon = new PictureBox
            {
                Size = new Size(277, 276),
                Location = new Point(598, 82),
                BackColor = Color.FromArgb(232, 232, 232),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            panelBattle.Controls.Add(wildPokemon);
            wildPokemon.BringToFront();

            myPokemon = new PictureBox
            {
                Size = new Size(266, 249),
                Location = new Point(168, 273),
                BackColor = Color.FromArgb(226, 226, 226),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            panelBattle.Controls.Add(myPokemon);
            myPokemon.BringToFront();

            //LifeBarComponents
            //PanelLifeBarComponent();
            

            //PanelAttackComponent
            //PanelAttackComponent();


            //PanelChooseOptions
            //PanelChooseOptions();
            

        }

        private void PanelLifeBarComponent()
        {
            LoadComponent();

            wildLifeBar = new ProgressBar
            {
                Size = new Size(203, 18),
                Location = new Point(172, 77),
                Value = 100,
                ForeColor = Color.FromArgb(112, 248, 168),
                BackColor = Color.FromArgb(78, 94, 88),
                Style = ProgressBarStyle.Continuous
            };
            wildLifeBar.BringToFront();
            

            myLifeBar = new ProgressBar
            {
                Size = new Size(203, 18),
                Location = new Point(205, 74),
                Value = 100,
                ForeColor = Color.FromArgb(112, 248, 168),
                BackColor = Color.FromArgb(78, 94, 88),
                Style = ProgressBarStyle.Continuous
            }; 
            myLifeBar.BringToFront();

            wildPanelGUI.Controls.Add(wildLifeBar);
            myPanelGUI.Controls.Add(myLifeBar);
        }

        private void PanelAttackComponent()
        {
            PokemonComponent();
            LoadComponent();

            wildLifeBar.Maximum = battle.EnemyPokemon.Hp;
            myLifeBar.Maximum = battle.CurrentPokemon.Hp;

            panelAttcks = new Panel
            {
                Size = new Size(Inf.WIDTH, 204),
                Location = new Point(0, 520),
                BackColor = Color.FromArgb(248, 248, 248),
                BackgroundImage = Image.FromFile(@"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Images or GIFS\InterfaceAttck.png"),
                BackgroundImageLayout = ImageLayout.Stretch
            };
            panelAttcks.SendToBack();

            panelAttcks.Visible = false;


            attckBtn1 = ButtonsMovementsBattle(60, 30);
            attckBtn1.Text = $"{battle.CurrentPokemon.Attacks[0].Name}";

            attckBtn2 = ButtonsMovementsBattle(364, 30);
            attckBtn2.Text = (battle.CurrentPokemon.Attacks.Count >= 2) ? battle.CurrentPokemon.Attacks[1].Name : " - ";

            attckBtn3 = ButtonsMovementsBattle(60, 102);
            attckBtn3.Text = (battle.CurrentPokemon.Attacks.Count >= 3) ? battle.CurrentPokemon.Attacks[2].Name : " - ";

            attckBtn4 = ButtonsMovementsBattle(364, 102);
            attckBtn4.Text = (battle.CurrentPokemon.Attacks.Count >= 4) ? battle.CurrentPokemon.Attacks[3].Name : " - ";

            panelAttcks.Controls.OfType<Button>().ToList().ForEach(b => b.BringToFront());
            panelBattle.Controls.Add(panelAttcks);
            panelAttcks.Controls.Add(attckBtn1);
            panelAttcks.Controls.Add(attckBtn2);
            panelAttcks.Controls.Add(attckBtn3);
            panelAttcks.Controls.Add(attckBtn4);

            attckBtn1.Click += AttckBtn1_Click;
            attckBtn2.Click += AttckBtn2_Click;
            attckBtn3.Click += AttckBtn2_Click;
            attckBtn4.Click += AttckBtn4_Click;
        }

        private void AttckBtn1_Click(object sender, EventArgs e)
        {
            CheckAttack(0);
        }

        private void AttckBtn2_Click(object sender, EventArgs e)
        {
            CheckAttack(1);
        }
       
        private void AttckBtn3_Click(object sender, EventArgs e)
        {
            CheckAttack(2);
        }

        private void AttckBtn4_Click(object sender, EventArgs e)
        {
            CheckAttack(3);
        }

        private Button ButtonsMovementsBattle(int x, int y)
        {
            return new Button
            {
                Size = new Size(255, 66),
                Location = new Point(x, y),
                BackColor = Color.FromArgb(248, 248, 248),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Font = pokemonFont,
                ForeColor = Color.FromArgb(72, 72, 72),
                TextAlign = ContentAlignment.MiddleLeft
            };
        }

        private void PanelChooseOptions()
        {
            LoadComponent();

            panelChooseOptions = new Panel
            {
                Size = new Size(499, 204),
                Location = new Point(500, 0),
                BackgroundImage = Image.FromFile(@"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Images or GIFS\Interface01.png"),
                BackgroundImageLayout = ImageLayout.Stretch
            };
            panelChooseOptions.BringToFront();


            FightBtn = new Button
            {
                Size = new Size(193, 60),
                Location = new Point(61, 53),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
            FightBtn.Click += FightBtn_Click;

            FightBtn.MouseEnter += (sender, e) => FightBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            FightBtn.MouseLeave += (sender, e) => FightBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;


            PokemonBtn = new Button
            {
                Size = new Size(193, 60),
                Location = new Point(61, 119),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
            PokemonBtn.Click += PokemonBtn_Click;

            PokemonBtn.MouseEnter += (sender, e) => PokemonBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            PokemonBtn.MouseLeave += (sender, e) => PokemonBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;


            BagBtn = new Button
            {
                Size = new Size(193, 60),
                Location = new Point(284, 53),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
            BagBtn.Click += BagBtn_Click;

            BagBtn.MouseEnter += (sender, e) => BagBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BagBtn.MouseLeave += (sender, e) => BagBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;


            RunBtn = new Button
            {
                Size = new Size(193, 60),
                Location = new Point(284, 119),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
            RunBtn.Click += RunBtn_Click;

            RunBtn.MouseEnter += (sender, e) => RunBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            RunBtn.MouseLeave += (sender, e) => RunBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;


            panelChooseOptions.Controls.OfType<Button>().ToList().ForEach(b => b.BringToFront());

            panelBattleInterface.Controls.Add(panelChooseOptions);
            panelChooseOptions.Controls.Add(FightBtn);
            panelChooseOptions.Controls.Add(PokemonBtn);
            panelChooseOptions.Controls.Add(BagBtn);
            panelChooseOptions.Controls.Add(RunBtn);

        }

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
        private void RunBtn_Click(object sender, EventArgs e) => this.Close();

        private void PokemonComponent()
        {
            

            //Pikachu
            Pikachu = new Pokemon("Pikachu", PokemonType.ELETRIC, PokemonType.NONE, 5,
                PokemonSpecies.PIKACHU,
               @"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Pokemons Sprites\Bulbasaur\SprBattle_Bulbasaur.png",
               @"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Pokemons Sprites\Bulbasaur\SprWild_Bulbasaur.png",
                /*35*/19, 55, 40, 50, 50, 90);

            Pikachu.LearnAttack("Quick Attack", PokemonType.NORMAL, MoveType.PHYSICAL, 40, 100, new EffectDetails(AttackEffect.NONE, 0));
            Pikachu.LearnAttack("Thunder Shock", PokemonType.ELETRIC, MoveType.SPECIAL, 40, 100, new EffectDetails(AttackEffect.PARALYZED, 10));
            Pikachu.LearnAttack("Thunder Wave", PokemonType.ELETRIC, MoveType.STATUS, 0, 90, new EffectDetails(AttackEffect.PARALYZED, 100));

            myPokemonList.Add(Pikachu);
            

            //Baulbasaur
            Bulbasaur = new Pokemon("Bulbasaur", PokemonType.GRASS, PokemonType.POISON, 5,
                PokemonSpecies.BULBASAUR,
                @"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Pokemons Sprites\Pikachu\sprBattle_Pikachu.png",
                @"C:\Users\lucas\OneDrive\Área de Trabalho\Jogos\Pokemon FIreRed\Pokemon_FireRed\ResourcesPK\Pokemons Sprites\Pikachu\sprWild_Pikachu.png",
                /*45*/19, 49, 49, 65, 65, 45);

            Bulbasaur.LearnAttack("Growl", PokemonType.NORMAL, MoveType.STATUS, 0, 100, new EffectDetails(AttackEffect.NONE, 0));
            Bulbasaur.LearnAttack("Tackle", PokemonType.NORMAL, MoveType.PHYSICAL, 40, 100, new EffectDetails(AttackEffect.NONE, 0));
            Bulbasaur.LearnAttack("Vine Whip", PokemonType.GRASS, MoveType.PHYSICAL, 45, 100, new EffectDetails(AttackEffect.NONE,0));

             myPokemonList.Add(Bulbasaur);

            battle = new Battle(Bulbasaur, Pikachu);
        }

        private void LoadPokemonComponent()
        {
            myPokemon.ImageLocation = battle.CurrentPokemon.MySpritePath;
            wildPokemon.ImageLocation = battle.EnemyPokemon.WildSpritePath;
        }

        private void MyEquipe()
        {
            battle.CurrentPokemon = myPokemonList[0];
        }

        private void PlayerTurn()
        {
            PanelChooseOptions();
        }

        private void CheckAttack(int attackIndex)
        {
            if (attackIndex >= 0 && attackIndex < battle.CurrentPokemon.Attacks.Count)
                PlayerAttack(attackIndex);
        }

        private void PlayerChooseAttacks()
        {

            
        }

        private void PlayerAttack(int currentAttack)
        {   
            
            bool isFainted = battle.TakeDamageEnemy(battle.CurrentPokemon.SelectAttack(currentAttack));
            wildLifeBar.Value = battle.EnemyPokemon.Hp;
           
            

            if(isFainted)
            {
                
                MessageBox.Show($"{battle.EnemyPokemon.Name} Desmaiou Oponente");
                if(wildLifeBar.Value > 0)
                    wildLifeBar.Value = 0;
            }
            else
            {
                EnemyAttack();
            }

        }

        private void EnemyAttack()
        {
            //dialogo
            bool isFainted = battle.TakeDamagePlayer(battle.GetRandomAttack());
            myLifeBar.Value = battle.CurrentPokemon.Hp;
            myLifeBar.ForeColor = Color.Blue;

            if (isFainted)
            {
              
                MessageBox.Show($"{battle.CurrentPokemon.Name} Desmaiou");
                if (myLifeBar.Value > 0)
                    myLifeBar.Value = 0;
            }
            else
            {
                PlayerTurn();
            }


        }

        //private void DisplayText(string text)
        //{

        //    foreach (char c in text)
        //    {
        //        textBattle.Text += c;

        //        Thread.Sleep(50);
        //        Application.DoEvents();
        //    }


        //    textBattle.Text += Environment.NewLine;
        //}
        private async Task DisplayTextWithTimerAsync(string text, int delayBetweenLetters)
        {
            foreach (char c in text)
            {
                textBattle.Text += c;
                await Task.Delay(delayBetweenLetters);
            }

            textBattle.Text += Environment.NewLine;
        }

        private void ClearText() => textBattle.Text = string.Empty;

        private void BattleStructure()
        {
            PlayerChooseAttacks();


            ChangeState(battle.State = BattleState.PLAYERTURN);

        }

        private void ChangeState(BattleState newState)
        {
            battle.State = newState;

            switch(newState)
            {
                case BattleState.PLAYERTURN:
                    PlayerTurnSetup();

                    break;
                case BattleState.ENEMYTURN:


                    break;
            }

        }

        private async void PlayerTurnSetup()
        {


            await DisplayTextWithTimerAsync("Apareceu " + battle.EnemyPokemon.Name.ToUpper() + " selvagem!", 100);
            await Thread.Sleep(500);
            ClearText();
            await DisplayTextWithTimerAsync($"Vá {battle.CurrentPokemon.Name.ToUpper()}!", 100);

            MyEquipe();

        }

    }
}
