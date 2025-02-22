using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Peao : Pecas
{
    bool primeiroMovimento;
    Peao peaoAdversario;
    public override bool MovimentoValido(int LinhaDestino, int ColunaDestino)
    {
        if (LinhaDestino < 1 || LinhaDestino > 8 || ColunaDestino < 1 || ColunaDestino > 8)
        {
            return false;
        }
        int difLinha = Math.Abs(linha - LinhaDestino);
        int difColuna = Math.Abs(coluna - ColunaDestino);

        if (difColuna == 0)
        {
            if ((cor == "branca" && LinhaDestino == linha + 1) ||
                (cor == "preta" && LinhaDestino == linha - 1))
            {
                return true; // Movimento normal de 1 casa para frente
            }
            if (primeiroMovimento &&
                ((cor == "branca" && LinhaDestino == linha + 2) ||
                 (cor == "preta" && LinhaDestino == linha - 2)))
            {
                return true; // Movimento especial: 2 casas no primeiro movimento
            }
        }
        if (difLinha == 1 && difColuna == 1 && peaoAdversario != null && peaoAdversario.cor != cor)
        {
            return true; // Captura diagonal
        }
        if (difLinha == 1 && difColuna == 1 && peaoAdversario != null && peaoAdversario.cor != cor)
        {
            return true; // En Passant (captura especial)
        }

        return false; // Movimento inválido
    }
    public Peao(string cor, int linha, int coluna) : base(cor, linha, coluna)
    {
        peaoAdversario = new Peao();
    }
    public Peao() : base() { }

}
