using Pokemon_FireRed.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon_FireRed.Entities.Classes
{
    class Map
    {
        public int[,] CollisionMatrix { get; set; }

        public int Width { get; private set; }
        public int Height { get; private set; }
        public int WidthCell { get; private set; }
        public int HeightCell { get; private set; }

        public Map()
        {
            Width = Inf.MAPW;
            Height = Inf.MAPH;
            WidthCell = Inf.CELLW;
            HeightCell = Inf.CELLH;
            CollisionMatrix = new int[Width, Height];

            InicializarMatrizColisao();
        }

        private void InicializarMatrizColisao()
        {
            DefinirColisao(17, 17, CollisionType.WALL);
            DefinirColisao(15, 15, CollisionType.DOOR);
            DefinirColisao(14, 15, CollisionType.INTERACTION);
            DefinirColisao(12, 15, CollisionType.BUSH);
            DefinirColisao(13, 15, CollisionType.WALL);
            DefinirColisao(0, 0, CollisionType.WALL);
            DefinirColisao(0, 36, CollisionType.WALL);
            DefinirColisao(48, 0, CollisionType.WALL);
            DefinirColisao(48, 36, CollisionType.WALL);
        }

        private void DefinirColisao(int x, int y, CollisionType collisionType)
        {
            if (x >= 0 && x <= Inf.MAPW && y <= Inf.MAPH && y >= 0)
            {
                // Define uma colisão na célula (x, y)
                if (x >= 0 && x < Width && y >= 0 && y < Height)
                    CollisionMatrix[x, y] = (int)collisionType;
            }
        }

        public CollisionType HaColisao(int x, int y)
        {
            // Verifica se há uma colisão na posição (x, y)
            if (x >= 0 && x < Width && y >= 0 && y < Height)
            {
                if (CollisionMatrix[x, y] == 1)
                    return CollisionType.WALL;

                if (CollisionMatrix[x, y] == 3)
                    return CollisionType.BUSH;

                if (CollisionMatrix[x, y] == 4)
                    return CollisionType.INTERACTION;

                if (CollisionMatrix[x, y] == 2)
                    return CollisionType.DOOR;
            }

            return CollisionType.NO_COLLISION;
        }
    }
}
