
using Pokemon_FireRed.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Pokemon_FireRed.Entities.Classes
{
    class Trainer
    {
        public event EventHandler AnimationTick;
        private PictureBox PbPlayer;

        private const int initialInterval = 10;
        private const int pressedInterval = 10;//400;
        private bool keyIsPressed;

        private Map map = new Map();

        private Point targetPosition;
        private double speed = 1;

        public string Name { get; protected set; }
        public Position CurrentPosition { get; protected set; }

        private Timer timerAnimation;

        public Trainer(string name, int x, int y, PictureBox pb)
        {
            Name = name;
            CurrentPosition = new Position(x * Inf.CELLW, y * Inf.CELLH);
            PbPlayer = pb;

            timerAnimation = new Timer();
            timerAnimation.Interval = initialInterval;
            timerAnimation.Tick += TimerAnimation_Tick;
            keyIsPressed = false;
        }

        public void HandleKeyDown()
        {
            if (!keyIsPressed)
            {
                timerAnimation.Start();
                keyIsPressed = true;
            }
        }
        public void HandleKeyUp()
        {
            timerAnimation.Stop();
            keyIsPressed = false;
        }
        public void MoveTo(Point target)
        {
            targetPosition = target;
            timerAnimation.Start();
        }
        public void StopAnimation() =>
            timerAnimation.Stop();

        private void TimerAnimation_Tick(object sender, EventArgs e)
        {

            int deltaX = targetPosition.X - CurrentPosition.X;
            int deltaY = targetPosition.Y - CurrentPosition.Y;
            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            double movement = Math.Min(speed, distance);
            double ratio = movement / distance;
            CurrentPosition.X += (int)(deltaX * ratio);
            CurrentPosition.Y += (int)(deltaY * ratio);


            if (keyIsPressed )
            timerAnimation.Interval = pressedInterval;

            else
            {
                timerAnimation.Interval = initialInterval;
            }


            if (CurrentPosition.X == targetPosition.X && CurrentPosition.Y == targetPosition.Y)
            timerAnimation.Stop();

            // Notificar outros assinantes do evento sobre o intervalo de tempo
            AnimationTick?.Invoke(this, EventArgs.Empty);
        }


        public void HandleMovement(Keys key)
        {
            Point nextCell = DetermineNextCell(key);

            CollisionType collision = CheckCollision(nextCell);
           
            switch (collision)
            {
                case CollisionType.WALL:
                    MessageBox.Show("Parede");
                    break;

                case CollisionType.BUSH:
                    FindPokemon();
                    break;

                case CollisionType.DOOR:
                    MessageBox.Show("Porta");
                    break;

                case CollisionType.INTERACTION:
                    MessageBox.Show("Interação");
                    break;

                case CollisionType.NO_COLLISION:
                    MoveTo(nextCell);
                    break;
            }
        }

        private Point DetermineNextCell(Keys key)
        {
            int nextX = CurrentPosition.X;
            int nextY = CurrentPosition.Y;

            switch (key)
            {
                case Keys.W:
                    MoveTo(new Point(CurrentPosition.X, CurrentPosition.Y - 1));
                    nextY -= 1; // Movimento para cima, decrementa o valor de Y
                    break;

                case Keys.S:
                    MoveTo(new Point(CurrentPosition.X, CurrentPosition.Y + 1));
                    nextY += 1; // Movimento para baixo, incrementa o valor de Y
                    break;

                case Keys.A:
                    MoveTo(new Point(CurrentPosition.X - 1, CurrentPosition.Y));
                    nextX -= 1; // Movimento para a esquerda, decrementa o valor de X
                    break;

                case Keys.D:
                    MoveTo(new Point(CurrentPosition.X + 1, CurrentPosition.Y));
                    nextX += 1; // Movimento para a direita, incrementa o valor de X
                    break;
            }

            return new Point(nextX, nextY);
        }

        private CollisionType CheckCollision(Point nextCell)
        {
            
            
            if (nextCell.X < 0 || nextCell.Y < 0 || nextCell.X >= map.Width  || nextCell.Y >= map.Height )
            return CollisionType.WALL;

            CollisionType collision = map.HaColisao(nextCell.X, nextCell.Y);

            return collision;
        }

        private void FindPokemon()
        {
            FormBattle fb = new FormBattle();
            fb.ShowDialog();
        }
    }
}