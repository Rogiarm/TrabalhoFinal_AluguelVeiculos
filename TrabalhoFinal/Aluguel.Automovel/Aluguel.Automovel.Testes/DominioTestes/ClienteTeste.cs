using Aluguel.Automoveis.Dominio.Entidades;
using Aluguel.Automoveis.Dominio.Excecoes;
using Aluguel.Automovel.Testes.Base;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel.Automovel.Testes.DominioTestes
{
    [TestFixture]
    public class ClienteTeste
    {
        private Cliente _cliente;

        [SetUp]
        public void Inicializador()
        {
            _cliente = ConstrutorObjeto.CriarCliente();
        }

        [Test]
        public void Cliente_deve_ter_nomeCompleto()
        {
            Assert.AreEqual("Thiago Sartor", _cliente.NomeCompleto);
        }

        [Test]
        public void Cliente_deve_ter_CNH()
        {
            Assert.AreEqual("1356119894", _cliente.CNH);
        }

        [Test]
        public void Cliente_deve_ter_CPF()
        {
            Assert.AreEqual("09388261909", _cliente.CPF);
        }

        [Test]
        public void Cliente_deve_ter_Telefone()
        {
            Assert.AreEqual("(49) 99839876", _cliente.Telefone);
        }

        [Test]
        public void Cliente_deve_ter_um_nomeCompleto_valido()
        {
            _cliente.NomeCompleto = "";

            _cliente.Validar();
        }

        [Test]
        public void Cliente_deve_ter_um_telefone_valido()
        {
            var _cliente = ConstrutorObjeto.CriarCliente();

            _cliente.Telefone = "";

            _cliente.Validar();
        }

        [Test]
        public void Cliente_deve_ter_um_endereco_valido()
        {
            var _cliente = ConstrutorObjeto.CriarCliente();

            _cliente.Endereco = null;

            _cliente.Validar();
        }
    }
}
