using System;

namespace GestaoDeEquipamentos.ConsoleApp
{
    public class Chamado
    {
        public string Titulo;
        public string Descricao;
        public Equipamento Equipamento;
        public DateTime DataAbertura;
        public Solicitante Solicitante;
        public bool Aberto;

        public Chamado(string titulo, string descricao, Equipamento equipamento, DateTime dataAbertura, Solicitante solicitante)
        {
            Titulo = titulo;
            Descricao = descricao;
            Equipamento = equipamento;
            DataAbertura = dataAbertura;
            Solicitante = solicitante;
            Aberto = true;
        }

        public override string ToString()
        {
            return $"\nTítulo: {Titulo}" +
                        $"\nEquipamento:\n{Equipamento}" +
                        $"\nData de abertura: {DataAbertura}" +
                        $"\nDias em aberto: {(DateTime.Now - DataAbertura).Days}" +
                        $"\nSolicitante: {Solicitante.Nome} ID: {Solicitante.ID}";
        }
    }
}