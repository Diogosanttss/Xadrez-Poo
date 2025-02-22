using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class Tabuleiro
    {
        
    // Matriz 8x8 para armazenar as peças
    public Pecas[,] Matriz { get; set; }

    public Tabuleiro()
    {
        // Inicializando a matriz 8x8
        Matriz = new Pecas[8, 8];
    }

    // Inicializa o tabuleiro colocando as peças nas posições corretas
    public void InicializarTabuleiro()
    {
        // Colocando as peças brancas na primeira linha
        Matriz[0, 0] = new Torre("Branca", 0, 0);
        Matriz[0, 1] = new Cavalo("Branca", 0, 1);
        Matriz[0, 2] = new Bispo("Branca", 0, 2);
        Matriz[0, 3] = new Rainha("Branca", 0, 3);
        Matriz[0, 4] = new Rei("Branca", 0, 4);
        Matriz[0, 5] = new Bispo("Branca", 0, 5);
        Matriz[0, 6] = new Cavalo("Branca", 0, 6);
        Matriz[0, 7] = new Torre("Branca", 0, 7);

        // Colocando os peões brancos na segunda linha
        for (int i = 0; i < 8; i++)
        {
            Matriz[1, i] = new Peao("Branco", 1, i);
        }

        // Colocando as peças pretas na última linha
        Matriz[7, 0] = new Torre("Preta", 7, 0);
        Matriz[7, 1] = new Cavalo("Preta", 7, 1);
        Matriz[7, 2] = new Bispo("Preta", 7, 2);
        Matriz[7, 3] = new Rainha("Preta", 7, 3);
        Matriz[7, 4] = new Rei("Preta", 7, 4);
        Matriz[7, 5] = new Bispo("Preta", 7, 5);
        Matriz[7, 6] = new Cavalo("Preta", 7, 6);
        Matriz[7, 7] = new Torre("Preta", 7, 7);

        // Colocando os peões pretos na penúltima linha
        for (int i = 0; i < 8; i++)
        {
            Matriz[6, i] = new Peao("Preto", 6, i);
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

    
