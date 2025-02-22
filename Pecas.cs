using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xadrez;

public abstract class Pecas : Form
{
    public string cor;
    public int linha;
    public int coluna;

    public Pecas(string Cor, int Linha, int Coluna)
    {
        cor = Cor;
        linha = Linha;
        coluna = Coluna;
    }
    public Pecas() { }
    public abstract bool MovimentoValido(int LinhaDestino, int ColunaDestino);
}
