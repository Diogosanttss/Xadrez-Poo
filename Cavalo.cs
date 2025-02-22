using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Cavalo : Pecas
{
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

        PictureBox cavalo = new PictureBox();
        cavalo.Location = new Point(50, 50);
        cavalo.Size = new Size(50, 50);
        cavalo.SizeMode = PictureBoxSizeMode.StretchImage;
        PictureBox torre = new PictureBox();

        if ((linha + coluna) % 2 == 0)
        {
            try
            {
                string path = Path.Combine(@"D:\Users\20231170150047\Xadrez-Poo", "bin", "Debug", "imagens", "cavalo_branco.png");
                MessageBox.Show("Tentando carregar: " + path);
                cavalo.Image = Image.FromFile(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar imagem: " + ex.Message);
            }
          
        }
        else {
          try
            {
                string path = Path.Combine(@"D:\Users\20231170150047\Xadrez-Poo", "bin", "Debug", "imagens", "cavalo_preto.png");
                MessageBox.Show("Tentando carregar: " + path);
                cavalo.Image = Image.FromFile(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar imagem: " + ex.Message);
            }
        }
        this.Controls.Add(cavalo);

    }
}
