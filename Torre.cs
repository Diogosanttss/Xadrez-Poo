using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;



    public class Torre : Pecas
    {
        public override bool MovimentoValido(int LinhaDestino, int ColunaDestino){
          if (LinhaDestino < 1 || LinhaDestino > 8 || ColunaDestino < 1 || ColunaDestino > 8)
        {
            return false; 
        }   
        if(linha != LinhaDestino && coluna != ColunaDestino){
            return false;
        }
            return true;
        }
          public Torre(string cor, int linha, int coluna): base(cor, linha, coluna){}
    }
