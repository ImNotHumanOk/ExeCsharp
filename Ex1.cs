using System;
using System.Collections.Generic;
using System.Linq;

class Ex1
{
    public class Produto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }

        public Produto(string nome, decimal preco, int quantidade)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Preço: {Preco:C}, Quantidade: {Quantidade}";
        }
    }

    static void Main(string[] args)
    {
        List<Produto> produtos = new List<Produto>();
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Adicionar novo produto");
            Console.WriteLine("2. Visualizar todos os produtos");
            Console.WriteLine("3. Pesquisar produto pelo nome");
            Console.WriteLine("4. Atualizar preço de um produto");
            Console.WriteLine("5. Remover produto da lista");
            Console.WriteLine("6. Sair");

            switch (Console.ReadLine())
            {
                case "1":
                    AdicionarProduto(produtos);
                    break;
                case "2":
                    VisualizarProdutos(produtos);
                    break;
                case "3":
                    PesquisarProduto(produtos);
                    break;
                case "4":
                    AtualizarPreco(produtos);
                    break;
                case "5":
                    
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

    static void AdicionarProduto(List<Produto> produtos)
    {
        Console.Write("Digite o nome do produto: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o preço do produto: ");
        decimal preco;
        while (!decimal.TryParse(Console.ReadLine(), out preco) || preco < 0)
        {
            Console.Write("Preço inválido. Digite novamente: ");
        }

        Console.Write("Digite a quantidade em estoque: ");
        int quantidade;
        while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade < 0)
        {
            Console.Write("Quantidade inválida. Digite novamente: ");
        }

        produtos.Add(new Produto(nome, preco, quantidade));
        Console.WriteLine("Produto adicionado com sucesso!\n");
    }

    static void VisualizarProdutos(List<Produto> produtos)
    {
        Console.WriteLine("Lista de produtos:");
        if (produtos.Count == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
        }
        else
        {
            foreach (var produto in produtos)
            {
                Console.WriteLine(produto);
            }
        }
        Console.WriteLine();
    }

    static void PesquisarProduto(List<Produto> produtos)
    {
        Console.Write("Digite o nome do produto a ser pesquisado: ");
        string nome = Console.ReadLine();

        var produto = produtos.FirstOrDefault(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        if (produto != null)
        {
            Console.WriteLine(produto);
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
        Console.WriteLine();
    }

    static void AtualizarPreco(List<Produto> produtos)
    {
        Console.Write("Digite o nome do produto a ter o preço atualizado: ");
        string nome = Console.ReadLine();

        var produto = produtos.FirstOrDefault(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        if (produto != null)
        {
            Console.Write("Digite o novo preço: ");
            decimal novoPreco;
            while (!decimal.TryParse(Console.ReadLine(), out novoPreco) || novoPreco < 0)
            {
                Console.Write("Preço inválido. Digite novamente: ");
            }

            produto.Preco = novoPreco;
            Console.WriteLine("Preço atualizado com sucesso!\n");
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
        Console.WriteLine();
    }

    static void RemoverProduto(List<Produto> produtos)
    {
        Console.Write("Digite o nome do produto a ser removido: ");
        string nome = Console.ReadLine();

        var produto = produtos.FirstOrDefault(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        if (produto != null)
        {
            produtos.Remove(produto);
            Console.WriteLine("Produto removido com sucesso!\n");
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
        Console.WriteLine();
    }

}
