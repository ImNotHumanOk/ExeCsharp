using System;
using System.Collections.Generic;

class Ex2
{
    public class Aluno
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public List<decimal> Notas { get; set; }

        public Aluno(string nome, int idade, List<decimal> notas)
        {
            Nome = nome;
            Idade = idade;
            Notas = notas;
        }

        public override string ToString()
        {
            string notasStr = string.Join(", ", Notas);
            return $"Nome: {Nome}, Idade: {Idade}, Notas: [{notasStr}]";
        }
    }

    static void Main(string[] args)
    {
        Dictionary<int, Aluno> alunos = new Dictionary<int, Aluno>();
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Adicionar novo aluno");
            Console.WriteLine("2. Visualizar todos os alunos");
            Console.WriteLine("3. Pesquisar aluno pelo número da matrícula");
            Console.WriteLine("4. Atualizar notas de um aluno");
            Console.WriteLine("5. Remover um aluno");
            Console.WriteLine("6. Sair");

            switch (Console.ReadLine())
            {
                case "1":
                    AdicionarAluno(alunos);
                    break;
                case "2":
                    VisualizarAlunos(alunos);
                    break;
                case "3":
                    PesquisarAluno(alunos);
                    break;
                case "4":
                    AtualizarNotas(alunos);
                    break;
                case "5":
                    RemoverAluno(alunos);
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

    static void AdicionarAluno(Dictionary<int, Aluno> alunos)
    {
        Console.Write("Digite o número de matrícula do aluno: ");
        int matricula;
        while (!int.TryParse(Console.ReadLine(), out matricula) || matricula < 0 || alunos.ContainsKey(matricula))
        {
            Console.Write("Número de matrícula inválido ou já existente. Digite novamente: ");
        }

        Console.Write("Digite o nome do aluno: ");
        string nome = Console.ReadLine();

        Console.Write("Digite a idade do aluno: ");
        int idade;
        while (!int.TryParse(Console.ReadLine(), out idade) || idade < 0)
        {
            Console.Write("Idade inválida. Digite novamente: ");
        }

        Console.Write("Digite as notas do aluno separadas por vírgula: ");
        List<decimal> notas = new List<decimal>();
        string[] notasStr = Console.ReadLine().Split(',');
        foreach (string nota in notasStr)
        {
            if (decimal.TryParse(nota.Trim(), out decimal notaDecimal))
            {
                notas.Add(notaDecimal);
            }
        }

        alunos[matricula] = new Aluno(nome, idade, notas);
        Console.WriteLine("Aluno adicionado com sucesso!\n");
    }

    static void VisualizarAlunos(Dictionary<int, Aluno> alunos)
    {
        Console.WriteLine("Lista de alunos:");
        if (alunos.Count == 0)
        {
            Console.WriteLine("Nenhum aluno cadastrado.");
        }
        else
        {
            foreach (var aluno in alunos)
            {
                Console.WriteLine($"Matrícula: {aluno.Key}, {aluno.Value}");
            }
        }
        Console.WriteLine();
    }

    static void PesquisarAluno(Dictionary<int, Aluno> alunos)
    {
        Console.Write("Digite o número de matrícula do aluno a ser pesquisado: ");
        int matricula;
        if (int.TryParse(Console.ReadLine(), out matricula) && alunos.ContainsKey(matricula))
        {
            Console.WriteLine(alunos[matricula]);
        }
        else
        {
            Console.WriteLine("Aluno não encontrado.");
        }
        Console.WriteLine();
    }

    static void AtualizarNotas(Dictionary<int, Aluno> alunos)
    {
        Console.Write("Digite o número de matrícula do aluno a ter as notas atualizadas: ");
        int matricula;
        if (int.TryParse(Console.ReadLine(), out matricula) && alunos.ContainsKey(matricula))
        {
            Console.Write("Digite as novas notas do aluno separadas por vírgula: ");
            List<decimal> novasNotas = new List<decimal>();
            string[] notasStr = Console.ReadLine().Split(',');
            foreach (string nota in notasStr)
            {
                if (decimal.TryParse(nota.Trim(), out decimal notaDecimal))
                {
                    novasNotas.Add(notaDecimal);
                }
            }

            alunos[matricula].Notas = novasNotas;
            Console.WriteLine("Notas atualizadas com sucesso!\n");
        }
        else
        {
            Console.WriteLine("Aluno não encontrado.");
        }
        Console.WriteLine();
    }

    static void RemoverAluno(Dictionary<int, Aluno> alunos)
    {
        Console.Write("Digite o número de matrícula do aluno a ser removido: ");
        int matricula;
        if (int.TryParse(Console.ReadLine(), out matricula) && alunos.ContainsKey(matricula))
        {
            alunos.Remove(matricula);
            Console.WriteLine("Aluno removido com sucesso!\n");
        }
        else
        {
            Console.WriteLine("Aluno não encontrado.");
        }
        Console.WriteLine();
    }
}
