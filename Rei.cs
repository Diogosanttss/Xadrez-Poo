using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Rei : Pecas
    {
        bool movimentou;
       public Rei (string Cor, int Linha, int Coluna) : base (Cor, Linha, Coluna){
        movimentou = false;
       }
       public override bool MovimentoValido(int LinhaDestino, int ColunaDestino) {
        
        return false;
       }
    }
