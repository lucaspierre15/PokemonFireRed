using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon_FireRed.Entities.Classes
{
    class Map
    {
        private int[,] matrizColisao;

        public int Largura { get; private set; }
        public int Altura { get; private set; }
        public int LarguraCadaCelula { get; private set; } 
        public int AlturaCadaCelula { get; private set; } 

        public Map(int largura, int altura, int larguraCadaCelula, int alturaCadaCelula)
        {
            Largura = largura;
            Altura = altura;
            this.LarguraCadaCelula = larguraCadaCelula;
            this.AlturaCadaCelula = alturaCadaCelula;
            matrizColisao = new int[Largura, Altura];

            // Lógica para inicializar a matriz de colisão
            InicializarMatrizColisao();
        }

        private void InicializarMatrizColisao()
        {
            // Configura a matriz de colisão
            // 0 indica sem colisão, 1 indica colisão

            // Exemplo: Colisão nas células (1, 1) e (2, 2)
            //Max[48,36]
            matrizColisao[0, 0] = 1;
            matrizColisao[0, 36] = 1;
            matrizColisao[48, 0] = 1;
            matrizColisao[48, 36] = 1;
        }

        public bool HaColisao(int x, int y)
        {
            // Verifica se há uma colisão na posição (x, y)
            return matrizColisao[x, y] == 1;
        }
    }
}
