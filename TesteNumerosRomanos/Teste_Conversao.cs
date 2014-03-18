using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NumerosRomanos;
using NUnit.Framework;

namespace TesteNumerosRomanos
{
    [TestFixture]
    public class Teste_Conversao
    {
        [Test]
        public void Deve_ser_possivel_realizar_conversao()
        {
            //Arrange
            //Act
            var conversor = new Conversor();

            
            //Assert
            Assert.Pass();
            
        }

        [Test]
        [TestCase("I", 1)]
        [TestCase("V", 5)]
        [TestCase("X", 10)]
        [TestCase("L", 50)]
        [TestCase("C", 100)]
        [TestCase("D", 500)]
        [TestCase("M", 1000)]
        public void Cada_letra_representa_um_valor(string letra, int resultadoEsperado)
        {
            //Arrange
            var conversao = new Conversor();
            //Act
            var resultadoDaConversao = conversao.Converter(letra);            
            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoDaConversao);

            

        }

        [Test]
        public void A_letras_V_NAO_podem_se_repetir()
        {
            var conversao = new Conversor();

            Assert.DoesNotThrow(() => conversao.Converter("V"));

            Assert.Throws<Exception>(() => conversao.Converter("VV"));
            Assert.Throws<Exception>(() => conversao.Converter("VVVVVV"));
            Assert.Throws<Exception>(() => conversao.Converter("VVVVVVVVV"));
        }

        [Test]
        public void A_letras_L_NAO_podem_se_repetir()
        {
            var conversao = new Conversor();

            Assert.DoesNotThrow(() => conversao.Converter("L"));

            Assert.Throws<Exception>(() => conversao.Converter("LL"));

        }

        [Test]
        public void A_letra_D_NAO_pode_repetir()
        {
            var conversao = new Conversor();
            
            Assert.DoesNotThrow(() => conversao.Converter("D"));

            Assert.Throws<Exception>(() => conversao.Converter("DD"));
        }

        [Test]
        public void A_letra_I_nao_pode_repetir_mais_que_tres_vezes()
        {
            var conversao = new Conversor();

            Assert.DoesNotThrow(() => conversao.Converter("I"));
            Assert.DoesNotThrow(() => conversao.Converter("II"));
            Assert.DoesNotThrow(() => conversao.Converter("III"));

            Assert.Throws<Exception>(() => conversao.Converter("IIII"));
            Assert.Throws<Exception>(() => conversao.Converter("IIIIIIIIIIIIIIII"));
            
        }
        
        [Test]
        public void A_letra_X_nao_pode_repetir_mais_que_tres_vezes()
        {
            var conversao = new Conversor();

            Assert.Throws<Exception>(() => conversao.Converter("XXXX"));
            Assert.Throws<Exception>(() => conversao.Converter("XXXXXXXXXXXXXXXXXXXXX"));
        }
        
        [Test]
        public void A_letra_X_pode_repetir_ate_tres_vezes()
        {
            var conversao = new Conversor();

            Assert.DoesNotThrow(() => conversao.Converter("X"));
            Assert.DoesNotThrow(() => conversao.Converter("XX"));
            Assert.DoesNotThrow(() => conversao.Converter("XXX"));
        }

        [Test]
        [TestCase("VIII", 8)]
        [TestCase("LXII", 62)]
        [TestCase("CLVIII", 158)]
        [TestCase("MCXX", 1120)]
        public void Somar_I_X_C_Quando_localizado_a_direita_dos_demais_algarismos(string letraAgrupada, int resultadoEsperado)
        {
            //Arrange
            var conversao = new Conversor();
            //Act
            var resultadoSoma = conversao.Converter(letraAgrupada);
            //Assert
            Assert.AreEqual(resultadoEsperado, resultadoSoma);
        }


        [Test]
        [TestCase("IV", 4)]
        [TestCase("IX", 9)]
        [TestCase("XC", 90)]
        [TestCase("MCCCLIV", 1354)]
        [TestCase("MMMCCCXXVIII", 3328)]

        public void Subtrair_I_X_C_Quando_Estiverem_a_Esquerda_dos_Algarismos(string letraAgrupada, int resultadoEsperado)
        {
            var conversao = new Conversor();

            var resultadoConvertido = conversao.Converter(letraAgrupada);

            Assert.AreEqual(resultadoEsperado, resultadoConvertido);
        }

    }
}
