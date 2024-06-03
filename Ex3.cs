using System;
using System.Collections.Generic;
using System.Linq;

class Ex3
{
    public class ItemPedido
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

        public ItemPedido(string nome, int quantidade, decimal precoUnitario)
        {
            Nome = nome;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Quantidade: {Quantidade}, Preço Unitário: {PrecoUnitario:C}";
        }
    }

    public class Cliente
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public Cliente(string nome, string endereco, string telefone)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Endereço: {Endereco}, Telefone: {Telefone}";
        }
    }
    public class Pedido
    {
        public int Numero { get; set; }
        public List<ItemPedido> Itens { get; set; }
        public Cliente Cliente { get; set; }

        public Pedido(int numero, List<ItemPedido> itens, Cliente cliente)
        {
            Numero = numero;
            Itens = itens;
            Cliente = cliente;
        }

        public override string ToString()
        {
            string itensStr = string.Join("\n", Itens.Select(i => i.ToString()));
            return $"Número do Pedido: {Numero}\nCliente: {Cliente}\nItens:\n{itensStr}";
        }
    }

    static void Main(string[] args)
    {
        List<Pedido> pedidos = new List<Pedido>();
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Adicionar novo pedido");
            Console.WriteLine("2. Visualizar todos os pedidos");
            Console.WriteLine("3. Pesquisar pedido pelo número");
            Console.WriteLine("4. Atualizar informações de um pedido");
            Console.WriteLine("5. Remover um pedido");
            Console.WriteLine("6. Sair");

            switch (Console.ReadLine())
            {
                case "1":
                    AdicionarPedido(pedidos);
                    break;
                case "2":
                    VisualizarPedidos(pedidos);
                    break;
                case "3":
                    PesquisarPedido(pedidos);
                    break;
                case "4":
                    AtualizarPedido(pedidos);
                    break;
                case "5":
                    RemoverPedido(pedidos);
                    break;
                case "6":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void AdicionarPedido(List<Pedido> pedidos)
    {
        Console.Write("Digite o número do pedido: ");
        int numero;
        while (!int.TryParse(Console.ReadLine(), out numero) || numero < 0 || pedidos.Any(p => p.Numero == numero))
        {
            Console.Write("Número de pedido inválido ou já existente. Digite novamente: ");
        }

        Console.Write("Digite o nome do cliente: ");
        string nomeCliente = Console.ReadLine();

        Console.Write("Digite o endereço do cliente: ");
        string endereco = Console.ReadLine();

        Console.Write("Digite o telefone do cliente: ");
        string telefone = Console.ReadLine();

        List<ItemPedido> itens = new List<ItemPedido>();
        bool adicionarMaisItens = true;
        while (adicionarMaisItens)
        {
            Console.Write("Digite o nome do item: ");
            string nomeItem = Console.ReadLine();

            Console.Write("Digite a quantidade do item: ");
            int quantidade;
            while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade < 0)
            {
                Console.Write("Quantidade inválida. Digite novamente: ");
            }

            Console.Write("Digite o preço unitário do item: ");
            decimal precoUnitario;
            while (!decimal.TryParse(Console.ReadLine(), out precoUnitario) || precoUnitario < 0)
            {
                Console.Write("Preço unitário inválido. Digite novamente: ");
            }

            itens.Add(new ItemPedido(nomeItem, quantidade, precoUnitario));

            Console.Write("Deseja adicionar mais itens? (s/n): ");
            adicionarMaisItens = Console.ReadLine().Trim().ToLower() == "s";
        }

        Cliente cliente = new Cliente(nomeCliente, endereco, telefone);
        pedidos.Add(new Pedido(numero, itens, cliente));
        Console.WriteLine("Pedido adicionado com sucesso!\n");
    }

    static void VisualizarPedidos(List<Pedido> pedidos)
    {
        Console.WriteLine("Lista de pedidos:");
        if (pedidos.Count == 0)
        {
            Console.WriteLine("Nenhum pedido cadastrado.");
        }
        else
        {
            foreach (var pedido in pedidos)
            {
                Console.WriteLine(pedido);
            }
        }
        Console.WriteLine();
    }

    static void PesquisarPedido(List<Pedido> pedidos)
    {
        Console.Write("Digite o número do pedido a ser pesquisado: ");
        int numero;
        if (int.TryParse(Console.ReadLine(), out numero))
        {
            var pedido = pedidos.FirstOrDefault(p => p.Numero == numero);
            if (pedido != null)
            {
                Console.WriteLine(pedido);
            }
            else
            {
                Console.WriteLine("Pedido não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Número de pedido inválido.");
        }
        Console.WriteLine();
    }

    static void AtualizarPedido(List<Pedido> pedidos)
    {
        Console.Write("Digite o número do pedido a ser atualizado: ");
        int numero;
        if (int.TryParse(Console.ReadLine(), out numero))
        {
            var pedido = pedidos.FirstOrDefault(p => p.Numero == numero);
            if (pedido != null)
            {
                Console.Write("Digite o novo nome do cliente (deixe em branco para manter o atual): ");
                string novoNomeCliente = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novoNomeCliente))
                {
                    pedido.Cliente.Nome = novoNomeCliente;
                }

                Console.Write("Digite o novo endereço do cliente (deixe em branco para manter o atual): ");
                string novoEndereco = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novoEndereco))
                {
                    pedido.Cliente.Endereco = novoEndereco;
                }

                Console.Write("Digite o novo telefone do cliente (deixe em branco para manter o atual): ");
                string novoTelefone = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novoTelefone))
                {
                    pedido.Cliente.Telefone = novoTelefone;
                }

                Console.WriteLine("Deseja atualizar os itens do pedido? (s/n): ");
                if (Console.ReadLine().Trim().ToLower() == "s")
                {
                    List<ItemPedido> novosItens = new List<ItemPedido>();
                    bool adicionarMaisItens = true;
                    while (adicionarMaisItens)
                    {
                        Console.Write("Digite o nome do item: ");
                        string nomeItem = Console.ReadLine();

                        Console.Write("Digite a quantidade do item: ");
                        int quantidade;
                        while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade < 0)
                        {
                            Console.Write("Quantidade inválida. Digite novamente: ");
                        }

                        Console.Write("Digite o preço unitário do item: ");
                        decimal precoUnitario;
                        while (!decimal.TryParse(Console.ReadLine(), out precoUnitario) || precoUnitario < 0)
                        {
                            Console.Write("Preço unitário inválido. Digite novamente: ");
                        }

                        novosItens.Add(new ItemPedido(nomeItem, quantidade, precoUnitario));

                        Console.Write("Deseja adicionar mais itens? (s/n): ");
                        adicionarMaisItens = Console.ReadLine().Trim().ToLower() == "s";
                    }
                    pedido.Itens = novosItens;
                }

                Console.WriteLine("Pedido atualizado com sucesso!\n");
            }
            else
            {
                Console.WriteLine("Pedido não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Número de pedido inválido.");
        }
        Console.WriteLine();
    }

    static void RemoverPedido(List<Pedido> pedidos)
    {
        Console.Write("Digite o número do pedido a ser removido: ");
        int numero;
        if (int.TryParse(Console.ReadLine(), out numero))
        {
            var pedido = pedidos.FirstOrDefault(p => p.Numero == numero);
            if (pedido != null)
            {
                pedidos.Remove(pedido);
                Console.WriteLine("Pedido removido com sucesso!\n");
            }
            else
            {
                Console.WriteLine("Pedido não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Número de pedido inválido.");
        }
        Console.WriteLine();
    }
}
