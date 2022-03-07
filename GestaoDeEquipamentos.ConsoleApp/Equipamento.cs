using System;

namespace GestaoDeEquipamentos.ConsoleApp
{
    public class Equipamento
    {
        public string Nome;
        public string NumSerie;
        public string Fabricante;
        public string Preco;
        public DateTime DataFabricacao;

        public Equipamento(string nome, string numSerie, string fabricante, string preco, DateTime dataFabricacao)
        {
            Nome = nome;
            NumSerie = numSerie;
            Fabricante = fabricante;
            Preco = preco;
            DataFabricacao = dataFabricacao;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}" +
                $"\nNº série: {NumSerie}" +
                $"\nFabricante: {Fabricante}";
        }
    }
}