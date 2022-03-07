using System;

namespace GestaoDeEquipamentos.ConsoleApp
{
    public class Problema: IComparable<Problema>
    {
        public Equipamento Equipamento;
        public int Problemas = 0;

        public Problema(Equipamento equipamento)
        {
            Equipamento = equipamento;
        }

        public override string ToString()
        {
            return $"\nO equipamento {Equipamento.Nome} apresentou problemas {Problemas} vezes.";
        }

        public int CompareTo(Problema other)
        {
            if (other == null)
            {
                return 1;
            }

            return Problemas.CompareTo(other.Problemas);
        }
    }
}