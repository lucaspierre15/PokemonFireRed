using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pokemon_FireRed.Entities.Classes
{
    class Trainer
    {
        public event EventHandler AnimationTick;

        private int targetX;
        private int targetY;

        private Point targetPosition;

        private double speed = 1;
        public string Name { get; protected set; }
        public Position CurrentPosition { get; protected set; }

        private Timer timerAnimation;

        public Trainer(string name, int x, int y)
        {
            Name = name;
            CurrentPosition = new Position(x * Inf.CELLW, y * Inf.CELLH);

            // Inicializar o temporizador na construção do treinador
            timerAnimation = new Timer();
            timerAnimation.Interval = 10;
            timerAnimation.Tick += TimerAnimation_Tick;
        }

        public void MoveTo(Point target)
        {
            targetX = target.X * Inf.CELLW;
            targetY = target.Y * Inf.CELLH;

            // Iniciar o temporizador para o movimento suave
            timerAnimation.Start();
        }

        private void TimerAnimation_Tick(object sender, EventArgs e)
        {
            // Lógica de movimento pixel por pixel

            // Atualizar a posição
            CurrentPosition.X += (int)(speed * Math.Sign(targetPosition.X - CurrentPosition.X));
            CurrentPosition.Y += (int)(speed * Math.Sign(targetPosition.Y - CurrentPosition.Y));

            // Se atingiu a posição alvo, parar o temporizador
            if (Math.Abs(CurrentPosition.X - targetPosition.X) <= speed &&
                Math.Abs(CurrentPosition.Y - targetPosition.Y) <= speed)
            {
                timerAnimation.Stop();

                // Configurar CurrentPosition diretamente para a posição alvo
                CurrentPosition.X = targetPosition.X;
                CurrentPosition.Y = targetPosition.Y;
            }

            // Notificar outros assinantes do evento sobre o intervalo de tempo
            AnimationTick?.Invoke(this, EventArgs.Empty);
        }

        public void HandleMovement(Keys key)
        {
            switch (key)
            {
                case Keys.W:
                    MoveTo(new Point(CurrentPosition.X, CurrentPosition.Y - Inf.CELLH));
                    break;
                case Keys.S:
                    MoveTo(new Point(CurrentPosition.X, CurrentPosition.Y + Inf.CELLH));
                    break;
                case Keys.A:
                    MoveTo(new Point(CurrentPosition.X - Inf.CELLW, CurrentPosition.Y));
                    break;
                case Keys.D:
                    MoveTo(new Point(CurrentPosition.X + Inf.CELLW, CurrentPosition.Y));
                    break;
            }
        }

        

    }
}

