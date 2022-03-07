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

    internal class Program
    {
        static int numeroEquipamentos = 0;
        static Equipamento[] equipamentos = new Equipamento[1000];
        static int numeroChamados = 0;
        static Chamado[] chamados = new Chamado[1000];
        static Solicitante[] solicitantes = new Solicitante[1000];
        static Random random = new Random();
        static int numeroSolicitantes = 0;

        static void Main(string[] args)
        {
            PopularTestes();
            MenuPrincipal();
        }

        private static void PopularTestes()
        {
            solicitantes[numeroSolicitantes++] = new Solicitante("4986", "Oscar Raichert", "oscarraichert@hotmail.com", "(49) 999014654");
            equipamentos[numeroEquipamentos++] = new Equipamento("Impressora Dell", "42069", "Dell", "169", new DateTime(2018, 03, 09));
            chamados[numeroChamados++] = new Chamado("ai ta bugado", "churrascou", equipamentos[0], DateTime.Now.AddDays(-5), solicitantes[0]);
        }

        static void MenuPrincipal()
        {
            string opção = null;

            while (opção != "4")
            {
                Console.Clear();
                Console.WriteLine("\nControle de equipamentos (1)" +
                                "\nControle de chamadas de manutenção (2)" +
                                "\nSolicitantes (3)" +
                                "\nSair (4)");
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
                        MenuSolicitantes();
                        break;

                    case "4":
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

            while (opcao != "9")
            {
                Console.Clear();
                Console.WriteLine("\nRegistrar chamado (1)" +
                    "\nVisualizar chamados registrados (2)" +
                    "\nEditar chamado (3)" +
                    "\nExcluir chamado (4)" +
                    "\nEditar solicitante (5)" +
                    "\nVer histórico de problemas nos equipamentos (6)" +
                    "\nFechar um chamado (7)" +
                    "\nMostrar chamados abertos e fechados (8)" +
                    "\nSair (9)");

                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        RegistrarChamado(numeroChamados++, null, null);
                        break;

                    case "2":
                        VisualizarChamados();
                        Console.ReadKey();
                        break;

                    case "3":
                        EditarChamado();
                        break;

                    case "4":
                        ExcluirItens(chamados);
                        break;

                    case "5":
                        EditarSolicitanteDoChamado(numeroSolicitantes, chamados[numeroChamados], solicitantes[numeroSolicitantes]);
                        break;

                    case "6":
                        EquipamentosProblematicos();
                        Console.ReadKey();
                        break;

                    case "7":
                        FecharChamado();
                        break;

                    case "8":
                        OrganizarChamados();
                        break;

                    case "9":
                        return;
                        break;

                    default:
                        Console.WriteLine("Comando inválido.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void RegistrarChamado(int indice, Equipamento equipamento, Solicitante solicitante)
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

            if (solicitante == null)
            {
                VisualizarItens(solicitantes);
                Console.Write("\nDigite qual solicitante você gostaria de vincular ao chamado: ");
                int i = Convert.ToInt32(Console.ReadLine());
                solicitante = solicitantes[i - 1];
            }

            Chamado novoChamado = new Chamado(titulo, descricao, equipamento, dataAbertura, solicitante);
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

        static void VisualizarChamados()
        {
            Console.Clear();
            for (int i = 0; i < chamados.Length; i++)
            {
                if (chamados[i] != null && chamados[i].Aberto == true)
                {
                    Console.Write($"\nItem {i + 1}\n{chamados[i]}\n");
                }
            }
        }

        static void EditarEquipamento()
        {
            Console.Clear();
            VisualizarItens(equipamentos);

            Console.Write("\nDigite o número do equipamento para edita-lo: ");
            int eqpEdit = Convert.ToInt32(Console.ReadLine());

            if (equipamentos[eqpEdit - 1] != null)
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
            VisualizarChamados();

            Console.Write("\nDigite o número do chamado para edita-lo: ");
            int indiceChamado = Convert.ToInt32(Console.ReadLine());
            var chamado = chamados[indiceChamado - 1];

            RegistrarChamado(indiceChamado - 1, chamado.Equipamento, chamado.Solicitante);

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

        static void MenuSolicitantes()
        {
            Console.Clear();
            string opcao = null;

            while (opcao != "5")
            {
                Console.WriteLine("Registrar solicitante (1)" +
                    "\nVisualizar solicitantes registrados (2)" +
                    "\nEditar cadastro (3)" +
                    "\nExcluir solicitante (4)" +
                    "\nSair (5)");

                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        RegistrarSolicitante(numeroSolicitantes++);
                        break;

                    case "2":
                        Console.Clear();
                        VisualizarItens(solicitantes);
                        Console.WriteLine();
                        break;

                    case "3":
                        EditarSolicitante();
                        break;

                    case "4":
                        ExcluirItens(solicitantes);
                        Console.WriteLine();
                        break;

                    case "5":
                        break;

                    default:
                        Console.WriteLine("Comando inválido!");
                        break;
                }
            }
        }

        static void RegistrarSolicitante(int cadastro)
        {
            string id = $"{random.Next(1000, 9999)}";

            Console.Write("\nNome do solicitante: ");
            string nome = Console.ReadLine();

            Console.Write("E-mail: ");
            string email = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Solicitante novoSolicitante = new Solicitante(id, nome, email, telefone);
            solicitantes[cadastro] = novoSolicitante;

            Console.WriteLine();
        }

        static void EditarSolicitante()
        {
            Console.Clear();
            VisualizarItens(solicitantes);

            Console.Write("Selecione o item para editar o cadastro: ");
            int i = Convert.ToInt32(Console.ReadLine());

            string id = $"{solicitantes[i - 1].ID}";

            Console.Write("\nNome do solicitante: ");
            string nome = Console.ReadLine();

            Console.Write("E-mail: ");
            string email = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Solicitante novoSolicitante = new Solicitante(id, nome, email, telefone);
            solicitantes[i - 1] = novoSolicitante;

            Console.WriteLine();
        }

        static void EditarSolicitanteDoChamado(int i, Chamado chamado, Solicitante solicitante)
        {
            Console.WriteLine("Selecione um chamado para editar o solicitante: ");
            VisualizarChamados();

            i = Convert.ToInt32(Console.ReadLine());
            chamado = chamados[i - 1];

            Console.WriteLine("Selecione um solicitante para vincular ao chamado: ");
            VisualizarItens(solicitantes);

            int j = Convert.ToInt32(Console.ReadLine());

            chamados[i - 1] = new Chamado(chamado.Titulo, chamado.Descricao, chamado.Equipamento, chamado.DataAbertura, solicitantes[j - 1]);
        }

        static void EquipamentosProblematicos()
        {
            int i = 0;            
            Problema[] problemasEquipamentos = new Problema[equipamentos.Length];
            
            foreach (Equipamento eqp in equipamentos)
            {
                if (eqp == null)
                {
                    continue;
                }
                
                Problema problema = new Problema(eqp);
                foreach (Chamado chamado in chamados)
                {
                    if (chamado != null && eqp == chamado.Equipamento)
                    {
                        problema.Problemas++;
                    }
                }

                problemasEquipamentos[i++] = problema;
            }

            Array.Sort(problemasEquipamentos);
            Array.Reverse(problemasEquipamentos);
            VisualizarItens(problemasEquipamentos);
        }

        static void FecharChamado()
        {
            VisualizarChamados();

            Console.Write("\nSelecione o chamado que você deseja fechar: ");
            int i = Convert.ToInt32(Console.ReadLine()) - 1;

            chamados[i].Aberto = false;
        }

        static void OrganizarChamados()
        {
            Console.WriteLine("\nChamados abertos: ");
            for (int i = 0; i < chamados.Length; i++)
            {
                if (chamados[i] != null && chamados[i].Aberto == true)
                {
                    Console.Write($"{chamados[i]}\n");
                }
            }

            Console.WriteLine("\nChamados fechados: ");
            for (int i = 0; i < chamados.Length; i++)
            {
                if (chamados[i] != null && chamados[i].Aberto == false)
                {
                    Console.Write($"{chamados[i]}\n");
                }
            }

            Console.ReadKey();
        }
    }
}