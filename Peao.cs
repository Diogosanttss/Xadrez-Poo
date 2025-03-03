using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;

namespace Xadrez;

public class Peao : Pecas
{
    bool primeiroMovimento = true;
    public override bool MovimentoValido(int LinhaDestino, int ColunaDestino, Pecas pecaDestino)
    {
        // Define a direção do movimento:
        // Peão branco avança para linhas maiores (+1) e preto para linhas menores (-1)
        if (LinhaDestino < 0 || LinhaDestino > 7 || ColunaDestino < 0 || ColunaDestino > 7)
            return false;

        int direcao = (cor == "branco") ? 1 : -1;

        int difLinha = linha - LinhaDestino;
        int difColuna = coluna - ColunaDestino;

        if (difColuna == 0 && (difLinha == direcao || difLinha == 2 * direcao) && pecaDestino is not CasaVazia){
            MessageBox.Show($"Movimento inválido");
            return false;
        }

        if (difColuna == 0 && difLinha == direcao)
        {
            primeiroMovimento = false;
            return true;
        }

        if (difColuna == 0 && difLinha == 2 * direcao && primeiroMovimento)
        {
            primeiroMovimento = false;
            return true;
        }

        if (Math.Abs(difColuna) == 1 && difLinha == direcao)
        {
            if (!(pecaDestino is CasaVazia) && pecaDestino.cor != cor)
            {
                primeiroMovimento = false;
                return true;
            }
        }

        MessageBox.Show($"Movimento inválido");
        return false;
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
