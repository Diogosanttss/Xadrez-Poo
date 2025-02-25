using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xadrez;

public class Rei : Pecas
{
    public PictureBox reiImagem { get; private set; }
    bool movimentou;
    public Rei(string cor, int linha, int coluna) : base(cor, linha, coluna)
    {
        reiImagem = new PictureBox
        {
            Location = new Point(coluna * 50, linha * 50),
            Size = new Size(45, 45),
            SizeMode = PictureBoxSizeMode.StretchImage,
            Parent = this,
        };

        reiImagem.BackColor = (linha+coluna)%2==0 ? Color.White : Color.Black;

        try
        {
            string path = Path.Combine(@"D:\Users\", Environment.UserName, "Xadrez-Poo", "bin", "Debug", "imagens", $"rei_{cor}.png");

            MessageBox.Show("Tentando carregar: " + path);
            reiImagem.Image = Image.FromFile(path);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao carregar imagem: " + ex.Message);
        }
    }
    public override bool MovimentoValido(int LinhaDestino, int ColunaDestino)
    {

        return false;
    }
}
