using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xadrez;

public class Rei : Pecas
{
    // public PictureBox reiImagem { get; private set; }
    // bool movimentou;
    public Rei(string cor, int linha, int coluna) : base(cor, linha, coluna)
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
            string path = Path.Combine($@"{disk}:\Users\", Environment.UserName, "Xadrez-Poo", "bin", "Debug", "imagens", $"rei_{cor}.png"); // Se estiver dando erro, edite o valor da variável 'disk' para "D"
            // MessageBox.Show("Tentando carregar: " + path);
            pictureBox.Image = Image.FromFile(path);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao carregar imagem: " + ex.Message);
        }
    }
    public override bool MovimentoValido(int LinhaDestino, int ColunaDestino, Pecas pecaDestino)
    {
        int difLinha = Math.Abs(LinhaDestino - linha);
        int difColuna = Math.Abs(ColunaDestino - coluna);

        // O Rei pode se mover apenas uma casa em qualquer direção
        return difLinha <= 1 && difColuna <= 1;
    }
}
