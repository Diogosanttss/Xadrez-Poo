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
    bool __mv = false;

    private bool vez_das_brancas = true;

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
            MessageBox.Show($"Peça selecionada: {peca.GetType().ToString()}");
            if (peca is not CasaVazia)
            {
                pecaSelecionada = peca.pictureBox;
                origemX = peca.linha;
                origemY = peca.coluna;
            }

            if ((peca.cor == "preto" || peca.cor == "preta") && !__mv)
            {
                MessageBox.Show("As peças brancas que começam.");
                origemX = -1;
                origemY = -1;
                return;
            }

            if ((peca.cor == "preto" || peca.cor == "preta") && vez_das_brancas){
                MessageBox.Show($"Vez das brancas");
                origemX = -1;
                origemY = -1;
                return;
            }else if ((peca.cor == "branco" || peca.cor == "branca") && !vez_das_brancas)
            {
                MessageBox.Show($"Vez das pretas");
                origemX = -1;
                origemY = -1;
                return;
            }

        }
        else // Segundo clique: tenta mover a peça
        {
            __mv = true;
            vez_das_brancas = !vez_das_brancas;

            Pecas pecaOrigem = tabuleiro[origemX, origemY];
            Pecas pecaDestino = tabuleiro[peca.linha, peca.coluna];
            
            MessageBox.Show($"Peça destino: {pecaDestino.GetType().ToString()}");

            

            // MessageBox.Show(peca.GetType().ToString());

            // MessageBox.Show($"Origem: {pecaOrigem.GetType()} ({origemX}, {origemY})");
            // MessageBox.Show($"Destino: {pecaDestino.GetType()} ({peca.linha}, {peca.coluna})");
            // Verifica se o movimento é válido
            if (peca.linha == origemX && peca.coluna == origemY)
            {
                pecaSelecionada = null;
                origemX = -1;
                origemY = -1;
                return;
            }

            if (!pecaOrigem.MovimentoValido(peca.linha, peca.coluna, pecaDestino))
            {
                vez_das_brancas = !vez_das_brancas;
                pecaSelecionada = null;
                origemX = -1;
                origemY = -1;
                return;
            }

            else if (pecaDestino is CasaVazia) // Se o destino estiver vazio, apenas move a peça
            {
                // Guarda as coordenadas originais
                int xOrigem = origemX, yOrigem = origemY;
                // Atualiza a matriz
                CasaVazia novaCasaVazia = CriarCasaVazia(xOrigem, yOrigem);
                tabuleiro[xOrigem, yOrigem] = novaCasaVazia;
                tabuleiro[peca.linha, peca.coluna] = pecaOrigem;

                // Atualiza as coordenadas da peça movida
                pecaOrigem.linha = pecaDestino.linha;
                pecaOrigem.coluna = pecaDestino.coluna;
                this.Controls.Remove(pecaOrigem);

                // Atualiza a posição visualmente
                peca.pictureBox.Location = new Point(origemY * 50, origemX * 50);
                peca.pictureBox.BackColor = (origemX + origemY) % 2 == 0 ? Color.White : Color.Black;
                peca.pictureBox.Visible = true;
                pecaOrigem.pictureBox.Location = new Point(pecaOrigem.coluna * 50, pecaOrigem.linha * 50); // Eu juro que daqui pra frente, eu nunca vou esquecer dessa desgraça, isso vai ser meu pesadelo de todas as noites ╰（‵□′）╯
                pecaOrigem.pictureBox.BackColor = (pecaOrigem.linha + peca.coluna) % 2 == 0 ? Color.White : Color.Black;
                pecaOrigem.pictureBox.Visible = true;
                if (!this.Controls.Contains(pecaOrigem.pictureBox))
                {
                    MessageBox.Show("PictureBox NÃO encontrado no Controls! Adicionando...");
                    pecaOrigem.pictureBox.BringToFront();
                    this.Controls.SetChildIndex(pecaOrigem.pictureBox, 0);
                }


                if (!this.Controls.Contains(novaCasaVazia.pictureBox))
                {
                    novaCasaVazia.pictureBox.BringToFront();
                    this.Controls.Add(novaCasaVazia.pictureBox);
                }

                // MessageBox.Show($"Nova posição: ({pecaOrigem.linha}, {pecaOrigem.coluna})");
                // pecaDestino.pictureBox.BringToFront();
                // this.Controls.SetChildIndex(pecaDestino.pictureBox, 0);
                novaCasaVazia.pictureBox.BringToFront();
                this.Controls.SetChildIndex(novaCasaVazia.pictureBox, 0);
                pecaOrigem.pictureBox.BringToFront();
                this.Controls.SetChildIndex(pecaOrigem.pictureBox, 0);

                // _tabuleiro.InicializarTabuleiro(this);
            }
            else // Se houver outra peça, troca as posições
            {
                if (!pecaOrigem.MovimentoValido(peca.linha, peca.coluna, pecaDestino))
                {
                    // MessageBox.Show("Movimento Inválido!");
                    pecaSelecionada = null;
                    origemX = -1;
                    origemY = -1;
                    return;
                }
                if ((pecaOrigem.cor.StartsWith("b") && peca.cor.StartsWith("b")) || (pecaOrigem.cor.StartsWith("p") && peca.cor.StartsWith("p")))
                {
                    MessageBox.Show("Movimento inválido");
                    pecaSelecionada = null;
                    origemX = -1;
                    origemY = -1;
                    return;
                }
                // Remover peça do tabuleiro
                if (this.Controls.Contains(tabuleiro[peca.linha, peca.coluna].pictureBox))
                {
                    this.Controls.Remove(tabuleiro[peca.linha, peca.coluna].pictureBox);
                    this.Controls.Remove(tabuleiro[peca.linha, peca.coluna]);
                }

                // Substitui a peça no tabuleiro
                tabuleiro[peca.linha, peca.coluna] = pecaOrigem;
                tabuleiro[origemX, origemY] = CriarCasaVazia(origemX, origemY);

                this.Controls.Add(tabuleiro[origemX, origemY].pictureBox);

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

    private CasaVazia CriarCasaVazia(int linha, int coluna)
    {
        CasaVazia casa = new CasaVazia("casavazia", linha, coluna);
        casa.pictureBox.Visible = true;
        // Configura o clique para a nova casa vazia
        casa.pictureBox.Click += (sender, args) => { ClickNoTabuleiro(casa); };

        return casa;
    }
}
