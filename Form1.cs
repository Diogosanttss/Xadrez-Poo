using System.CodeDom;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;

namespace Xadrez;

public partial class Form1 : Form
{
    #pragma warning disable CS8632 // A anotação para tipos de referência anuláveis deve ser usada apenas em código em um contexto de anotações '#nullable'.
        private PictureBox? pecaSelecionada = null; // Armazena a peça selecionada
    #pragma warning restore CS8632 // A anotação para tipos de referência anuláveis deve ser usada apenas em código em um contexto de anotações '#nullable'.
    
    private int origemX = -1, origemY = -1; // Armazena a posição da peça
    public Tabuleiro tb = new Tabuleiro();

    public Pecas[,] tabuleiro;

    public Form1()
    {
        tabuleiro = tb.Matriz;

        try
        {
            tb.InicializarTabuleiro(this);
        }
        catch (Exception e)
        {
            MessageBox.Show($"{e.Message}: {e.StackTrace}");
        }

        InitializeComponent();
    }

    public void ClickNoTabuleiro(Pecas peca)
    {
        if (origemX == -1 && origemY == -1) // Primeiro clique: seleciona a peça
        {
            if (peca is not CasaVazia)
            {
                pecaSelecionada = peca.pictureBox;
                origemX = peca.linha;
                origemY = peca.coluna;
                // MessageBox.Show($"Peça selecionada em ({peca.linha}, {peca.coluna})");
            }
        }
        else // Segundo clique: tenta mover a peça
        {
            Pecas pecaOrigem = tabuleiro[origemX, origemY];
            Pecas pecaDestino = tabuleiro[peca.linha, peca.coluna];

            // MessageBox.Show(peca.GetType().ToString());
            // MessageBox.Show(pecaOrigem.GetType().ToString());
            // MessageBox.Show(pecaDestino.GetType().ToString());

            // MessageBox.Show($"Origem: {pecaOrigem.GetType()} ({origemX}, {origemY})");
            // MessageBox.Show($"Destino: {pecaDestino.GetType()} ({peca.linha}, {peca.coluna})");
            // Verifica se o movimento é válido
            if (pecaOrigem.MovimentoValido(peca.linha, peca.coluna, pecaDestino))
            {
                // MessageBox.Show("Movimento Inválido!");
                pecaSelecionada = null;
                origemX = -1;
                origemY = -1;
                return;
            }

            else if (pecaDestino is CasaVazia) // Se o destino estiver vazio, apenas move a peça
            {
                // Atualiza a matriz
                // tabuleiro[peca.linha, peca.coluna].pictureBox = pecaOrigem.pictureBox;
                tabuleiro[origemX, origemY] = new CasaVazia("casavazia", origemX, origemY);
                tabuleiro[peca.linha, peca.coluna] = pecaOrigem;

                // Atualiza as coordenadas da peça movida
                pecaOrigem.linha = peca.linha;
                pecaOrigem.coluna = peca.coluna;

                // Atualiza a posição visualmente
                pecaOrigem.pictureBox.Location = new Point(pecaOrigem.coluna * 50, pecaOrigem.linha * 50);
                pecaOrigem.pictureBox.BackColor = (pecaOrigem.linha + peca.coluna) % 2 == 0 ? Color.White : Color.Black;
                pecaOrigem.pictureBox.Visible = true;
                if (!this.Controls.Contains(pecaOrigem.pictureBox))
                {
                    MessageBox.Show("PictureBox NÃO encontrado no Controls! Adicionando...");
                    this.Controls.Add(pecaOrigem.pictureBox);
                }
                // MessageBox.Show($"Nova posição: ({pecaOrigem.linha}, {pecaOrigem.coluna})");
                pecaDestino.pictureBox.BringToFront();
                this.Controls.SetChildIndex(pecaDestino.pictureBox, 0);
                pecaOrigem.pictureBox.BringToFront();
                this.Controls.SetChildIndex(pecaOrigem.pictureBox, 0);

                // _tabuleiro.InicializarTabuleiro(this);
            }
            else // Se houver outra peça, troca as posições
            {
                // Remover peça do tabuleiro
                this.Controls.Remove(pecaDestino.pictureBox);

                // Substitui a peça no tabuleiro
                tabuleiro[peca.linha, peca.coluna] = pecaOrigem;
                tabuleiro[origemX, origemY] = new CasaVazia("casavazia", origemX, origemY);

                // Atualiza a posição visualmente
                pecaOrigem.linha = peca.linha;
                pecaOrigem.coluna = peca.coluna;
                pecaOrigem.pictureBox.Location = new Point(pecaOrigem.coluna * 50, pecaOrigem.linha * 50); // Eu juro que daqui pra frente, eu nunca vou esquecer dessa desgraça, isso vai ser meu pesadelo de todas as noites ╰（‵□′）╯
                pecaOrigem.pictureBox.BackColor = (pecaOrigem.linha + pecaOrigem.coluna) % 2 == 0 ? Color.White : Color.Black;

            }

            // Atualiza a interface
            this.Refresh();

            // Reseta os valores para a próxima jogada
            pecaSelecionada = null;
            origemX = -1;
            origemY = -1;
        }
    }
}
