using Aluguel.Automoveis.Dominio.Entidades;
using Aluguel.Automoveis.Dominio.Enums;
using Aluguel.Automovel.Infra.Dados.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel.Automovel.Testes.Base
{
    public class InicializadorBanco<T> : DropCreateDatabaseAlways<AluguelVeiculoContexto>
    {
        protected override void Seed(AluguelVeiculoContexto context)
        {
            //Cria Veiculo
            Veiculo veiculo1 = new Veiculo();
            veiculo1.Modelo = "Uno 1.0";
            veiculo1.Marca = "Fiat";
            veiculo1.Valor = 49.99;
            veiculo1.TipoCarro = TipoCarro.Economico;

            Veiculo veiculo2 = new Veiculo();
            veiculo2.Modelo = "Fusion 2.0";
            veiculo2.Marca = "Ford";
            veiculo2.Valor = 150.90;
            veiculo2.TipoCarro = TipoCarro.Executivo;

            var listaVeiculos = new List<Veiculo>() { veiculo1, veiculo2 };

            //Criar cliente
            Cliente cliente = new Cliente();
            cliente.NomeCompleto = "Thiago Sartor";
            cliente.CNH = "1356119894";
            cliente.CPF = "09388261909";
            cliente.Telefone = "(49) 9 96487239";
            cliente.DataNascimento = DateTime.Now.AddYears(-28);

            cliente.Endereco = new Endereco
            {
                Logradouro = "Av. Castelo Branco",
                Numero = "261",
                Complemento = "",
                Bairro = "Universitário",
                Localidade = "Lages",
                UF = "SC",
                Cep = "88987876"
            };

            //Cria Contrato
            Contrato contrato = new Contrato();
            contrato.Cliente = cliente;

            //Adiciona os produtos
            contrato.Veiculos = listaVeiculos;

            //Fecha pedido
            contrato.CalculaTotal();

            //Adicionar no contexto
            context.Contratos.Add(contrato);

            //Salvar no contexto
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
