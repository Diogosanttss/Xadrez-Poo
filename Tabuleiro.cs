using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Xadrez;

public class Tabuleiro
{
    public Pecas[,] Matriz { get; set; }

    private List<PictureBox> pb = new List<PictureBox>();

    Torre[] torres;
    Cavalo[] cavalos;
    Bispo[] bispos;
    Rei[] reis;
    Rainha[] damas;
    Peao[] peoes;

    public Tabuleiro()
    {
        Matriz = new Pecas[8,8];

        torres = new Torre[4];
        cavalos = new Cavalo[4];
        bispos = new Bispo[4];
        reis = new Rei[2];
        damas = new Rainha[2];
        peoes = new Peao[16];

        torres[0] = new Torre("preta", 0, 0);
        cavalos[0] = new Cavalo("preto", 0, 1);
        bispos[0] = new Bispo("preto", 0, 2);
        damas[0] = new Rainha("preta", 0, 3);
        reis[0] = new Rei("preto", 0, 4);
        bispos[1] = new Bispo("preto", 0, 5);
        cavalos[1] = new Cavalo("preto", 0, 6);
        torres[1] = new Torre("preta", 0, 7);

        pb.Add(torres[0].torreImagem);
        pb.Add(cavalos[0].cavaloImagem);
        pb.Add(bispos[0].bispoImagem);
        pb.Add(damas[0].rainhaImagem);
        pb.Add(reis[0].reiImagem);
        pb.Add(bispos[1].bispoImagem);
        pb.Add(cavalos[1].cavaloImagem);
        pb.Add(torres[1].torreImagem);

        for (int i = 0; i < 8; i++)
        {
            peoes[i] = new Peao("preto", 1, i);
            pb.Add(peoes[i].peaoImagem);
        }

        for (int i = 0; i < 8; i++)
        {
            peoes[i] = new Peao("branco", 6, i);
            pb.Add(peoes[i].peaoImagem);
        }

        torres[2] = new Torre("branca", 7, 0);
        cavalos[2] = new Cavalo("branco", 7, 1);
        bispos[2] = new Bispo("branco", 7, 2);
        damas[1] = new Rainha("branca", 7, 3);
        reis[1] = new Rei("branco", 7, 4);
        bispos[3] = new Bispo("branco", 7, 5);
        cavalos[3] = new Cavalo("branco", 7, 6);
        torres[3] = new Torre("branca", 7, 7);

        pb.Add(torres[2].torreImagem);
        pb.Add(cavalos[2].cavaloImagem);
        pb.Add(bispos[2].bispoImagem);
        pb.Add(damas[1].rainhaImagem);
        pb.Add(reis[1].reiImagem);
        pb.Add(bispos[3].bispoImagem);
        pb.Add(cavalos[3].cavaloImagem);
        pb.Add(torres[3].torreImagem);
    }

    // Inicializa o tabuleiro colocando as peças nas posições corretas
    public void InicializarTabuleiro(Form1 arg)
    {
        foreach (PictureBox imagem in pb)
        {
            arg.Controls.Add(imagem);
        }
    }

    // Verifica se o movimento é válido
    public bool MoverPeca(int linhaOrigem, int colunaOrigem, int linhaDestino, int colunaDestino)
    {
        // Verificar se a origem e o destino estão dentro do tabuleiro
        if (linhaOrigem < 0 || linhaOrigem >= 8 || colunaOrigem < 0 || colunaOrigem >= 8 || linhaDestino < 0 || linhaDestino >= 8 || colunaDestino < 0 || colunaDestino >= 8)
        {
            Console.WriteLine("Movimento fora dos limites do tabuleiro.");
            return false;
        }

        Pecas pecaOrigem = Matriz[linhaOrigem, colunaOrigem];
        Pecas pecaDestino = Matriz[linhaDestino, colunaDestino];

        if (pecaOrigem == null)
        {
            Console.WriteLine("Não há peça na posição de origem.");
            return false;
        }

        // Verificar se a peça de origem é da cor correta (não pode mover a peça do adversário)
        if (pecaDestino != null && pecaDestino.cor == pecaOrigem.cor)
        {
            Console.WriteLine("Não é possível mover para uma posição ocupada por uma peça da mesma cor.");
            return false;
        }

        // Verificar se o movimento da peça é válido de acordo com a peça
        if (!pecaOrigem.MovimentoValido(linhaDestino, colunaDestino))
        {
            Console.WriteLine("Movimento inválido para a peça.");
            return false;
        }

        // Mover a peça (por enquanto sem considerar movimentos como roque ou en passant)
        Matriz[linhaDestino, colunaDestino] = pecaOrigem;
        Matriz[linhaOrigem, colunaOrigem] = null;

        Console.WriteLine($"Peça movida de ({linhaOrigem}, {colunaOrigem}) para ({linhaDestino}, {colunaDestino})");
        return true;
    }
}
