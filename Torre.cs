using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Xadrez;

public class Torre : Pecas
{
    public PictureBox torreImagem { get; private set; }
    public override bool MovimentoValido(int LinhaDestino, int ColunaDestino)
    {
        if (LinhaDestino < 1 || LinhaDestino > 8 || ColunaDestino < 1 || ColunaDestino > 8)
        {
            return false;
        }
        if (linha != LinhaDestino && coluna != ColunaDestino)
        {
            return false;
        }
        return true;
    }
    public Torre(string cor, int linha, int coluna) : base(cor, linha, coluna)
    {
        torreImagem = new PictureBox
        {
            Location = new Point(coluna * 50, linha * 50),
            Size = new Size(50, 50),
            SizeMode = PictureBoxSizeMode.StretchImage,
            Parent = this,
        };

        torreImagem.BackColor = (linha+coluna)%2==0 ? Color.White : Color.Black;

        try
        {
            string path = Path.Combine(@"D:\Users\", Environment.UserName, "Xadrez-Poo", "bin", "Debug", "imagens", $"torre_{cor}.png");

            MessageBox.Show("Tentando carregar: " + path);
            torreImagem.Image = Image.FromFile(path);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao carregar imagem: " + ex.Message);
        }
    }
}
