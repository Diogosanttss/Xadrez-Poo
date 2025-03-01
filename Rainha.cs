using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xadrez;

public class Rainha : Pecas
{
    // public PictureBox rainhaImagem { get; private set; }
    public override bool MovimentoValido(int linhaDestino, int colunaDestino, Pecas pecaDestino)
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
    public Rainha(string cor, int linha, int coluna) : base(cor, linha, coluna)
    {
        pictureBox = new PictureBox
        {
            Location = new Point(coluna * 50, linha * 50),
            Size = new Size(48, 48),
            SizeMode = PictureBoxSizeMode.StretchImage,
            Parent = this,
        };
        
        pictureBox.BackColor = (linha+coluna)%2==0 ? Color.White : Color.Black;
        
        try
        {
            string path = Path.Combine($@"{disk}:\Users\", Environment.UserName, "Xadrez-Poo", "bin", "Debug", "imagens", $"dama_{cor}.png"); // Se estiver dando erro, edite o valor da variável 'disk' para "D"
            // MessageBox.Show("Tentando carregar: " + path);
            pictureBox.Image = Image.FromFile(path);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao carregar imagem: " + ex.Message);
        }
    }
}
