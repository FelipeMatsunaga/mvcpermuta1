using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Model
    {
        protected static string nome;
        protected static string altura;
        protected static ArrayList Lista = new ArrayList();
    }

    class Controller : Model
    {
        public static void LerNome(string x)
        {
            Model.nome = x;
            Lista.Add(nome);
        }
        public static void LerAltura(string y)
        {
            Model.altura = y;
            Lista.Add(altura);
        }
        public static void Printar()
        {
            int ct = 0;
            for (int x = 0; x < Model.Lista.Count; x=x+2)
            {
                Console.WriteLine($"Cadastro {ct + 1}\n" +
                        $"Nome: {Model.Lista[x]}\n" +
                        $"Altura: {Model.Lista[x + 1]}\n");
                ct++;
            }
            
            Console.ReadLine();
        }
    }

    class View
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insira o nome: ");
            Controller.LerNome(Console.ReadLine());
            Console.WriteLine("Insira a altura: ");
            Controller.LerAltura(Console.ReadLine());
            Controller.Printar();
        
        }
    }
}
