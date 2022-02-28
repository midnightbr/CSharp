﻿namespace tabuleiro {
    abstract class Peca {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; set; }
        public int QtdMovimentos { get; set; }
        public Tabuleiro Tab { get; set; }

        public Peca(Tabuleiro tab, Cor cor) {
            Posicao = null;
            Cor = cor;
            Tab = tab;
            QtdMovimentos = 0;
        }

        public void incrementarQtdMovimentos() {
            QtdMovimentos++;
        }

        public abstract bool[,] movimentosPossiveis();
    }
}
