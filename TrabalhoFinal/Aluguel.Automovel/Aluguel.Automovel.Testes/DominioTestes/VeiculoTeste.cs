using Aluguel.Automoveis.Dominio.Entidades;
using Aluguel.Automovel.Testes.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel.Automovel.Testes.DominioTestes
{
   // [TestFixure]
    public class VeiculoTeste
    {
        private Veiculo _veiculo;

      // [SetUp]
        public void Inicializador()
        {
            _veiculo = ConstrutorObjeto.CriarVeiculo();
        }
    }
}
