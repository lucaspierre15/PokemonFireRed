
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
        private const int pressedInterval = 400;
        private DateTime lastKeyPressTime;
        private bool keyIsPressed;

        private Map map;

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
            lastKeyPressTime = DateTime.MinValue;
        }

        public void HandleKeyDown()
        {
                if (!keyIsPressed)
                {
                    timerAnimation.Start();
                    keyIsPressed = true;
                    lastKeyPressTime = DateTime.Now;
                }
        }
        public void HandleKeyUp()
        {
            timerAnimation.Stop();
            keyIsPressed = false;
            lastKeyPressTime = DateTime.MinValue;
        }
        public void MoveTo(Point target)
        {
            targetPosition = target;
            // Inicie ou reinicie o temporizador para animar o movimento
            timerAnimation.Start();
        }
        public void StopAnimation()
        {
            // Pare o temporizador
            timerAnimation.Stop();
        }
        private void TimerAnimation_Tick(object sender, EventArgs e)
        {
            // Lógica de movimento pixel por pixel
            // Lógica de animação do treinador
            int deltaX = targetPosition.X - CurrentPosition.X;
            int deltaY = targetPosition.Y - CurrentPosition.Y;
            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            double movement = Math.Min(speed, distance);
            double ratio = movement / distance;
            // Atualizar a posição
            CurrentPosition.X += (int)(deltaX * ratio);
            CurrentPosition.Y += (int)(deltaY * ratio);

            if (keyIsPressed && (DateTime.Now - lastKeyPressTime).TotalMilliseconds > pressedInterval)
            {
                timerAnimation.Interval = pressedInterval;
            }
            else
            {
                timerAnimation.Interval = initialInterval;
            }


            if (CurrentPosition.X == targetPosition.X && CurrentPosition.Y == targetPosition.Y)
            {
                // Parar o temporizador quando a posição alvo for alcançada
                timerAnimation.Stop();
            }

            // Notificar outros assinantes do evento sobre o intervalo de tempo
            AnimationTick?.Invoke(this, EventArgs.Empty);
        }


        public void HandleMovement(Keys key)
        {
            /*
            map = new Map();
            Point nextCell = DetermineNextCell(key);
            // Verifica se há uma colisão na próxima célula
            CollisionType collision = map.HaColisao(nextCell.X / Inf.CELLW, nextCell.Y / Inf.CELLH);
            // Agora, você pode tratar a colisão conforme necessário
            switch (collision)
            {
                case CollisionType.WALL:
                    // Lógica para lidar com colisão de parede (ex: não permitir movimento)
                    break;
                case CollisionType.BUSH:
                    // Lógica para lidar com colisão de matinho
                    break;
                case CollisionType.INTERATION:
                    // Lógica para lidar com colisão de interação
                    break;
                case CollisionType.NO_COLLISION:
                    // Não há colisão, então você pode mover o jogador
                    MoveTo(nextCell);
                    break;
            }*/
            switch (key)
            {
                case Keys.W:
                    MoveTo(new Point(CurrentPosition.X, CurrentPosition.Y - 1));
                    break;
                case Keys.S:
                    MoveTo(new Point(CurrentPosition.X, CurrentPosition.Y + 1));
                    break;
                case Keys.A:
                    MoveTo(new Point(CurrentPosition.X - 1, CurrentPosition.Y));
                    break;
                case Keys.D:
                    MoveTo(new Point(CurrentPosition.X + 1, CurrentPosition.Y));
                    break;
            }
        }

        /*private Point DetermineNextCell(Keys key)
        {
            int nextX = CurrentPosition.X;
            int nextY = CurrentPosition.Y;
            
            
            switch (key)
            {
                case Keys.W:
                    MoveTo(new Point(CurrentPosition.X, CurrentPosition.Y -1));
                    break;
                case Keys.S:
                    MoveTo(new Point(CurrentPosition.X, CurrentPosition.Y));
                    break;
                case Keys.A:
                    MoveTo(new Point(CurrentPosition.X - 1, CurrentPosition.Y));
                    break;
                case Keys.D:
                    MoveTo(new Point(CurrentPosition.X + 1, CurrentPosition.Y));
                    break;
            }*/

        //return new Point(nextX, nextY);

    }
}