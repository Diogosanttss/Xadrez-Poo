using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xadrez;

public class Bispo : Pecas
{
    public PictureBox bispoImagem { get; private set; }
    public override bool MovimentoValido(int LinhaDestino, int ColunaDestino)
    {
        if (LinhaDestino < 1 || LinhaDestino > 8 || ColunaDestino < 1 || ColunaDestino > 8)
        {
            return false;
        }
        int difLinha = Math.Abs(linha - LinhaDestino);
        int difColuna = Math.Abs(coluna - ColunaDestino);

        return difLinha == difColuna;
    }
    public Bispo(string cor, int linha, int coluna) : base(cor, linha, coluna)
    {
        bispoImagem = new PictureBox
        {
            Location = new Point(coluna * 50, linha * 50),
            Size = new Size(45, 45),
            SizeMode = PictureBoxSizeMode.StretchImage,
            BackColor = Color.Transparent,
            Parent = this,
        };

        try
        {
            string path = Path.Combine(@"C:\Users\", Environment.UserName, "Xadrez-Poo", "bin", "Debug", "imagens", $"bispo_{cor}.png");

            MessageBox.Show("Tentando carregar: " + path);
            bispoImagem.Image = Image.FromFile(path);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao carregar imagem: " + ex.Message);
        }
    }
}
