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

    public class Chamado
    {
        public string Titulo;
        public string Descricao;
        public Equipamento Equipamento;
        public DateTime DataAbertura;

        public Chamado(string titulo, string descricao, Equipamento equipamento, DateTime dataAbertura)
        {
            Titulo = titulo;
            Descricao = descricao;
            Equipamento = equipamento;
            DataAbertura = dataAbertura;
        }

        public override string ToString()
        {
            return $"\nTítulo: {Titulo}" +
                        $"\nEquipamento:\n{Equipamento}" +
                        $"\nData de abertura: {DataAbertura}" +
                        $"\nDias em aberto: {(DateTime.Now - DataAbertura).Days}\n";
        }
    }

    internal class Program
    {
        static int numeroEquipamentos = 0;
        static Equipamento[] equipamentos = new Equipamento[1000];
        static int numeroChamados = 0;
        static Chamado[] chamados = new Chamado[1000];

        static void Main(string[] args)
        {
            PopularTestes();
            MenuPrincipal();
        }

        private static void PopularTestes()
        {
            equipamentos[numeroEquipamentos++] = new Equipamento("Impressora Dell", "42069", "Dell", "169", new DateTime(2018, 03, 09));
            chamados[numeroChamados++] = new Chamado("ai ta bugado", "churrascou", equipamentos[0], DateTime.Now.AddDays(-5));
        }

        static void MenuPrincipal()
        {
            string opção = null;

            while (opção != "3")
            {
                Console.Clear();
                Console.WriteLine("\nControle de equipamentos (1)" +
                                "\nControle de chamadas de manutenção (2)" +
                                "\nSair (3)");
                opção = Console.ReadLine();

                switch (opção)
                {
                    case "1":
                        MenuControleEquipamentos();
                        break;

                    case "2":
                        MenuControleChamadas();
                        break;

                    case "3":
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void MenuControleEquipamentos()
        {
            string opcao = null;

            while (opcao != "5")
            {
                Console.Clear();
                Console.WriteLine("\nRegistrar equipamento (1)" +
                                        "\nVisualizar os equipamentos (2)" +
                                        "\nEditar um equipamento (3)" +
                                        "\nExcluir um equipamento (4)" +
                                        "\nSair (5)");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        RegistrarEquipamentos(numeroEquipamentos++);
                        break;

                    case "2":
                        VisualizarItens(equipamentos);
                        Console.ReadKey();
                        break;

                    case "3":
                        EditarEquipamento();
                        break;

                    case "4":
                        ExcluirItens(equipamentos);
                        break;

                    case "5":
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void MenuControleChamadas()
        {
            string opcao = null;

            while (opcao != "5")
            {
                Console.Clear();
                Console.WriteLine("\nRegistrar chamado (1)" +
                    "\nVisualizar chamados registrados (2)" +
                    "\nEditar chamado (3)" +
                    "\nExcluir chamado (4)" +
                    "\nSair (5)");

                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        RegistrarChamado(numeroChamados++, null);
                        break;

                    case "2":
                        VisualizarItens(chamados);
                        Console.ReadKey();
                        break;

                    case "3":
                        EditarChamado();
                        break;

                    case "4":
                        ExcluirItens(chamados);
                        break;

                    case "5":
                        break;

                    default:
                        Console.WriteLine("Comando inválido.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void RegistrarChamado(int indice, Equipamento equipamento)
        {
            Console.Write("\nTítulo do chamado: ");
            string titulo = Console.ReadLine();

            Console.Write("Descrição do chamado: ");
            string descricao = Console.ReadLine();

            if (equipamento == null)
            {
                VisualizarItens(equipamentos);
                Console.Write("\nEquipamento do chamado: ");
                int eqpChamado = Convert.ToInt32(Console.ReadLine()) - 1;
                equipamento = equipamentos[eqpChamado];
            }

            Console.WriteLine(equipamento.Nome);

            DateTime dataAbertura = DateTime.Now;
            Console.WriteLine($"Data de abertura: {dataAbertura}");

            Chamado novoChamado = new Chamado(titulo, descricao, equipamento, dataAbertura);
            chamados[indice] = novoChamado;
        }

        static void RegistrarEquipamentos(int indice)
        {
            Console.Write("\nNome do equipamento: ");
            string nomeEquip = Console.ReadLine();

            if (nomeEquip.Length < 6)
            {
                Console.WriteLine("O nome precisa ter 6 ou mais caracteres.");
                RegistrarEquipamentos(indice);
                return;
            }

            Console.Write("Preço de aquisição: R$");
            string precoEquip = Console.ReadLine();

            Console.Write("Número de série: ");
            string numSerie = Console.ReadLine();

            Console.Write("Data de fabricação: ");
            DateTime fabricacaoEquip = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Nome do fabricante: ");
            string nomeFabricante = Console.ReadLine();

            Equipamento novoEqp = new Equipamento(nomeEquip, numSerie, nomeFabricante, precoEquip, fabricacaoEquip);
            equipamentos[indice] = novoEqp;
        }

        static void VisualizarItens(object[] itens)
        {            
            for (int i = 0; i < itens.Length; i++)
            {
                object item = itens[i];

                if (item != null)
                {
                    Console.Write($"\nItem {i + 1}\n{item}\n");
                }
            }
        }

        static void EditarEquipamento()
        {
            Console.Clear();
            VisualizarItens(equipamentos);

            Console.Write("\nDigite o número do equipamento para edita-lo: ");
            int eqpEdit = Convert.ToInt32(Console.ReadLine());

            if (equipamentos[eqpEdit-1] != null)
            {
                foreach (Chamado chamado in chamados)
                {
                    if (chamado != null && chamado.Equipamento == equipamentos[eqpEdit - 1])
                    {
                        Console.WriteLine("Você não pode editar um equipamento vinculado a um chamado.");
                        Console.ReadKey();
                        return;
                    }
                }
            }

            RegistrarEquipamentos(eqpEdit - 1);
        }

        static void EditarChamado()
        {
            Console.Clear();
            VisualizarItens(chamados);

            Console.Write("\nDigite o número do chamado para edita-lo: ");
            int indiceChamado = Convert.ToInt32(Console.ReadLine());
            var chamado = chamados[indiceChamado - 1];

            RegistrarChamado(indiceChamado - 1, chamado.Equipamento);

        }

        static void ExcluirItens(object[] itens)
        {
            VisualizarItens(itens);

            Console.Write("\nDigite o número do item para excluí-lo: ");
            int i = Convert.ToInt32(Console.ReadLine()) - 1;

            if (itens[i] is Equipamento)
            {
                foreach (Chamado cham in chamados)
                {
                    if (cham != null && cham.Equipamento == itens[i])
                    {
                        Console.WriteLine("Você não pode excluir um equipamento vinculado a um chamado.");
                        Console.ReadKey();
                        return;
                    }
                }
            }

            itens[i] = null;
        }
    }
}