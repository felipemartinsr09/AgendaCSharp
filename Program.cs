using System;
using System.Collections.Generic;
using System.Linq;

namespace Agenda
{
    class Tarefa
    {
        public string Descricao {  get; set; }
        public string Prioridade { get; set; }
        public bool Finalizada { get; set; }
    }
    class Program
    {
        static List<Tarefa> agenda = new List<Tarefa>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Agenda");
                Console.WriteLine("(1) Adicionar Tarefa");
                Console.WriteLine("(2) Listar tarefa");
                Console.WriteLine("(3) Alterar prioridade");
                Console.WriteLine("(4) Finalizar Tarefa");
                Console.WriteLine("(5) Fechar");
                Console.Write("Escolha:");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": Adicionar(); break;
                    case "2": Listar(); break;
                    case "3": AlterarPrioridade(); break;
                    case "4": Finalizar(); break;
                    case "5": return;
                        default : Console.WriteLine("Opção inválida."); break; 
                }
            }
        }
        static void Adicionar()
        {
            Console.Write("Descrição:");
            string desc = Console.ReadLine();
            Console.Write("Prioridade ( Alta/ Media/ Baixa):"); 
            string prio = Console.ReadLine().ToLower();
            agenda.Add(new Tarefa { Descricao = desc, Prioridade = prio, Finalizada = false }); 
        }
        static void Listar()
        {
            for (int i = 0; i < agenda.Count; i++)
            {
                var t = agenda[i];
                string status = t.Finalizada ? "[OK]" : "[]";
                Console.WriteLine($"{i} - {status} {t.Descricao}(Prio: {t.Prioridade})");
            }           
        }
        static void AlterarPrioridade()
        {
            Listar();
            Console.Write("Índice da tarefa:");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nova prioridade:");
            agenda[id].Prioridade = Console.ReadLine().ToLower();
        }
        static void Finalizar()
        {
            Listar();
            Console.Write("Índice da tarefa para finalizar:");
            int id = int.Parse(Console.ReadLine());
            agenda[id].Finalizada = true;
        }
    }
}