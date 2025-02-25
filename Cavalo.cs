using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xadrez;

public class Cavalo : Pecas
{
    Cavalo cavalo;
    public PictureBox cavaloImagem { get; private set; }
    public override bool MovimentoValido(int LinhaDestino, int ColunaDestino)
    {
        if (LinhaDestino < 1 || LinhaDestino > 8 || ColunaDestino < 1 || ColunaDestino > 8)
        {
            return false;
        }

        int difLinha = Math.Abs(linha - LinhaDestino);
        int difColuna = Math.Abs(coluna - ColunaDestino);

        return (difLinha == 2 && difColuna == 1) || (difLinha == 1 && difColuna == 2);
    }

    public Cavalo(string cor, int linha, int coluna) : base(cor, linha, coluna)
    {
        cavaloImagem = new PictureBox
        {
            Location = new Point(coluna * 50, linha * 50),
            Size = new Size(45, 45),
            SizeMode = PictureBoxSizeMode.StretchImage,
            Parent = this,
        };

        cavaloImagem.BackColor = (linha+coluna)%2==0 ? Color.White : Color.Black;
        
        try
        {
            string path = Path.Combine(@"D:\Users\", Environment.UserName, "Xadrez-Poo", "bin", "Debug", "imagens", $"cavalo_{cor}.png");

            MessageBox.Show("Tentando carregar: " + path);
            cavaloImagem.Image = Image.FromFile(path);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao carregar imagem: " + ex.Message);
        }

    }
}
