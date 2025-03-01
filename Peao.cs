using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;

namespace Xadrez;

public class Peao : Pecas
{
    // public PictureBox peaoImagem { get; private set; }
    bool primeiroMovimento = true;
    public override bool MovimentoValido(int LinhaDestino, int ColunaDestino, Pecas pecaDestino)
    {
        if (LinhaDestino < 0 || LinhaDestino > 7 || ColunaDestino < 0 || ColunaDestino > 7)
        {
            return false;
        }

        // Define a direção do movimento:
        // Peão branco avança para linhas maiores (+1) e preto para linhas menores (-1)
        int direcao = (cor == "branco") ? 1 : -1;

        // Diferença real de linhas e colunas
        int difLinha = LinhaDestino - linha;       // importante: usa a linha atual (não a coluna)
        int difColuna = ColunaDestino - coluna;      // valor com sinal para capturar o sentido

        // Movimento normal: 1 casa para frente sem mudança lateral
        if (difColuna == 0 && difLinha == direcao)
        {
            primeiroMovimento = false;
            return true;
        }

        // Movimento duplo: 2 casas para frente no primeiro movimento
        if (difColuna == 0 && difLinha == 2 * direcao && primeiroMovimento)
        {
            primeiroMovimento = false;
            return true;
        }

        // Captura diagonal: 1 casa em diagonal para frente
        if (Math.Abs(difColuna) == 1 && difLinha == direcao)
        {
            if (!(pecaDestino is CasaVazia) && pecaDestino.cor != cor)
            {
                return true;
            }
        }

        return false; // Movimento inválido
    }
    public Peao(string Cor, int Linha, int Coluna) : base(Cor, Linha, Coluna)
    {
        pictureBox = new PictureBox
        {
            Location = new Point(coluna * 50, linha * 50),
            Size = new Size(48, 48),
            SizeMode = PictureBoxSizeMode.StretchImage,
            Parent = this,
        };

        pictureBox.BackColor = (linha + coluna) % 2 == 0 ? Color.White : Color.Black;

        try
        {
            string path = Path.Combine($@"{disk}:\Users\", Environment.UserName, "Xadrez-Poo", "bin", "Debug", "imagens", $"peao_{cor}.png"); // Se estiver dando erro, edite o valor da variável 'disk' para "D"
            // MessageBox.Show("Tentando carregar: " + path);
            pictureBox.Image = Image.FromFile(path);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao carregar imagem: " + ex.Message);
        }

    }
    public Peao() : base() { }

}
