using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace NumerosRomanos
{
    public class Conversor
    {
        public int Converter(string numeroRomano)
        {
            var numeroIndoArabico   = 0;
            var quantidadeV         = 0;
            var quantidadeL         = 0;
            var quantidadeD         = 0;
            var quantidadeI         = 0;
            var quantidadeX         = 0;

            foreach (var letra in numeroRomano)
            {
                switch (letra)
                {
                    case 'V':
                        quantidadeV++;
                        break;
                    case 'L':
                        quantidadeL++;
                        break;
                    case 'D':
                        quantidadeD++;
                        break;
                    case 'I':
                        quantidadeI++;
                        break;
                    case 'X':
                        quantidadeX++;
                        break;
                }
                numeroIndoArabico += ObterValorLetra(letra);
            }

            if (quantidadeV > 1)
                throw new Exception("Letra V deve repetir somente 1 vez !!");

            if (quantidadeL > 1)
                throw new Exception("Letra L não deve repetir!!");

            if (quantidadeD > 1)
                throw new Exception("Letra D não deve repetir");

            if (quantidadeI > 3)
                throw new Exception("Letra I nao pode repetir mais que 3 vezes");

            if (quantidadeX > 3)
                throw new Exception("Letra X nao pode repetir mais que 3 vezes");

            return numeroIndoArabico;
        }

        public int ObterValorLetra(char numeroRomano)
        {
            switch (numeroRomano)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    return 0;
            }
        }

    }
}
