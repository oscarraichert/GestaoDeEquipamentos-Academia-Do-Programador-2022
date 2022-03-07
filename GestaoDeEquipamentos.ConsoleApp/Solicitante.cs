namespace GestaoDeEquipamentos.ConsoleApp
{
    public class Solicitante
    {
        public string ID;
        public string Nome;
        public string Email;
        public string Telefone;

        public Solicitante(string iD, string nome, string email, string telefone)
        {
            ID = iD;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public override string ToString()
        {
            return $"ID: {ID}" +
                $"\nNome: {Nome}" +
                $"\nE-mail: {Email}" +
                $"\nTelefone: {Telefone}";
        }
    }
}