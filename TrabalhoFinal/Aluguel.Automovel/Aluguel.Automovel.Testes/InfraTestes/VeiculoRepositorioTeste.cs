using Aluguel.Automoveis.Dominio.Entidades;
using Aluguel.Automovel.Infra.Dados.Contexto;
using Aluguel.Automovel.Infra.Dados.Repositorios;
using Aluguel.Automovel.Testes.Base;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel.Automovel.Testes.InfraTestes
{
    //[TestFixure]
    public class VeiculoRepositorioTeste
    {
        private AluguelVeiculoContexto _contextoTeste;
        private VeiculoRepositorio _repositorio;
        private Veiculo _veiculoTest;

       //[SetUp]
        public void Inicializador()
        {
            Database.SetInitializer(new InicializadorBanco<AluguelVeiculoContexto>());

            _contextoTeste = new AluguelVeiculoContexto();

            _repositorio = new VeiculoRepositorio();

            _veiculoTest = ConstrutorObjeto.CriarVeiculo();

            _contextoTeste.Database.Initialize(true);
        }

        //[Test]
        public void Deveria_adicionar_um_novo_veiculo()
        {
            //Preparação

            //Ação
            _repositorio.Adicionar(_veiculoTest);

            //Afirmar
            var todosVeiculos = _contextoTeste.Veiculos.ToList();

           // Assert.AreEqual(3, todosVeiculos.Count);
        }

        //[Test]
        public void Deveria_editar_um_veiculo()
        {
            //Preparação
            var veiculoEditado = _contextoTeste.Veiculos.Find(1);
            veiculoEditado.Modelo = "EDITADO";

            //Ação
            _repositorio.Editar(veiculoEditado);

            //Afirmar
            var veiculoBuscado = _contextoTeste.Veiculos.Find(1);

           // Assert.AreEqual("EDITADO", veiculoBuscado.Modelo);
        }

       // [Test]
        public void Deveria_deletar_um_veiculo()
        {
            //Preparação
            var veiculoDeletado = _contextoTeste.Veiculos.Find(1);

            //Ação
            _repositorio.Deletar(veiculoDeletado);

            //Afirmar
            var todosVeiculos = _contextoTeste.Veiculos.ToList();

          //  Assert.AreEqual(1, todosVeiculos.Count);
        }

        //[Test]
        public void Deveria_buscar_veiculo_por_id()
        {

            //Preparação

            //Ação
            var veiculoBuscado = _repositorio.BuscarPor(1);

            //Afirmar

           // Assert.IsNotNull(veiculoBuscado);
        }

       // [Test]
        public void Deveria_buscar_todos_os_veiculos()
        {
            //Preparação

            //Ação
            var veiculoBuscado = _repositorio.BuscarTudo();

            //Afirmar

           // Assert.IsNotNull(veiculoBuscado);
        }

       // [Test]
        public void Deveria_buscar_veiculo_por_modelo()
        {
            //Preparação

            //Ação
            var veiculoBuscado = _repositorio.BuscarPorModelo("Uno 1.0");

            //Afirmar

          //  Assert.IsNotNull(veiculoBuscado);
        }
    }
}
