using Aluguel.Automoveis.Dominio.Entidades;
using Aluguel.Automoveis.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel.Automovel.Testes.Base
{
    public static class ConstrutorObjeto
    {
        public static Cliente CriarCliente()
        {
            return new Cliente
            {
                Id = 1,
                NomeCompleto = "Thiago Sartor",
                CNH = "1356119894",
                CPF = "09388261909",
                Telefone = "(49) 99839876",
                DataNascimento = new DateTime(1990, 02, 19),
                Endereco = new Endereco
                {
                    Logradouro = "Av. Castelo Branco",
                    Numero = "261",
                    Complemento = "",
                    Bairro = "Universitário",
                    Localidade = "Lages",
                    UF = "SC",
                    Cep = "88 987 876"
                },
            };
        }

        public static Contrato CriarContrato()
        {
            return new Contrato
            {
                Id = 1,
                Cliente = CriarCliente()
            };
        }

        public static Veiculo CriarVeiculo()
        {
            return new Veiculo
            {
                Id = 1,
                Modelo = "Uno 1.0",
                Marca = "Fiat",
                Valor = 39.90,
                TipoCarro = TipoCarro.Economico
            };
        }
    }
}
