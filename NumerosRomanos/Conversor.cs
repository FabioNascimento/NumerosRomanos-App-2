using System;
using System.Collections.Generic;

namespace NumerosRomanos
{
    public class Conversor
    {

        public int Converter(string numeroRomano)
        {
            var numeroIndoArabico = 0;
            var ultimoNumeroIndoArabico = 0;
            var quantidadeLetra = new Dictionary<char, int>();
            var valorLetra = new Dictionary<char, int>
            {
                {'I',1},
                {'V',5},
                {'X',10},
                {'L',50},
                {'C',100},
                {'D',500},
                {'M',1000},
            };

            for (var i = numeroRomano.Length - 1; i >= 0; i--)
            {
                var letra = numeroRomano[i];

                if (!quantidadeLetra.ContainsKey(letra))
                    quantidadeLetra.Add(letra, 0);

                quantidadeLetra[letra]++;

                var numeroRepresentaLetra = valorLetra[letra];

                if (numeroRepresentaLetra < ultimoNumeroIndoArabico)
                    numeroRepresentaLetra *= -1;

                numeroIndoArabico += numeroRepresentaLetra;
                ultimoNumeroIndoArabico = numeroRepresentaLetra;
            }

            disparaSeHouverMaisQueUma(quantidadeLetra, "VLD");
            disparaSeHouverMaisQueTres(quantidadeLetra, "IX");

            return numeroIndoArabico;

        }

        private void disparaSeHouverMaisQueUma(Dictionary<char, int> quantidadeLetras, string letras)
        {
            foreach (var letra in letras)
            {
                if (quantidadeLetras.ContainsKey(letra) && quantidadeLetras[letra] > 1)
                {
                    throw new Exception(
                       string.Format(
                           "Letra {0} não deve se repetir !!!", letra));
                }
            }
        }

        private void disparaSeHouverMaisQueTres(Dictionary<char, int> quantidadeLetras, string letras)
        {
            foreach (var letra in letras)
            {
                if (quantidadeLetras.ContainsKey(letra) && quantidadeLetras[letra] > 3)
                {
                    throw new Exception(
                        string.Format(
                            "Letra {0} não deve se repetir !!!", letra));
                }

            }
        }

    }
}
