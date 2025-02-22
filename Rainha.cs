using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


       public class Rainha : Pecas
{
    public Rainha(string cor, int linha, int coluna) : base(cor, linha, coluna) { }

    public override bool MovimentoValido(int linhaDestino, int colunaDestino)
    {
       
        if (linhaDestino < 1 || linhaDestino > 8 || colunaDestino < 1 || colunaDestino > 8)
        {
            return false;
        }

        // Verificar se o movimento é horizontal (mesma linha)
        if (linhaDestino == this.linha && colunaDestino != this.coluna)
        {
            return true;
        }

        // Verificar se o movimento é vertical (mesma coluna)
        if (colunaDestino == this.coluna && linhaDestino != this.linha)
        {
            return true;
        }

        // Verificar se o movimento é diagonal
        if (Math.Abs(linhaDestino - this.linha) == Math.Abs(colunaDestino - this.coluna))
        {
            return true;
        }

        // Caso contrário, não é um movimento válido
        return false;
    }
}

    