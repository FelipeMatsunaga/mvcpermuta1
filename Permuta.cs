using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Model
    {
        public string nome;
        public float altura;
        public int idade;
        public string cidade;
        public string CPF;
        public static ArrayList Lista = new ArrayList();
        public Model(string Nome, float Altura, int Idade, string Cidade, string cpf)
        {
            this.nome = Nome;
            this.altura = Altura;
            this.idade = Idade;
            this.cidade = Cidade;
            this.CPF = cpf;
        }
    }

    public class Controller 
    {
        public static void LerInfo(string nome2, float altura2, int idade2, string cidade2, string cpf2)
        {
            Model mLista = new Model(nome2, altura2, idade2, cidade2, cpf2);
            Model.Lista.Add(mLista.nome);
            Model.Lista.Add(mLista.altura);
            Model.Lista.Add(mLista.idade);
            Model.Lista.Add(mLista.cidade);
            Model.Lista.Add(mLista.CPF);
        }
        
        public static bool AcharCad(string nome)
        {
            if (Model.Lista.Contains(nome))
            {
                return true;
            }
            return false;
            
        }
    }

    class View
    {
        static void Main(string[] args)
        {
            char reset = 'n';
            do
            {
                Console.WriteLine("Menu \n" +
                    "1 - Cadastro\n" +
                    "2 - Imprimir Cadastros\n" +
                    "3 - Procurar cadastro por nome\n" +
                    "4 - Finalizar o programa\n");
                Start:
                char menu = Console.ReadKey().KeyChar;
                switch (menu)
                {
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente: ");
                        goto Start;
                    case '1':
                        Repeat:
                        Console.WriteLine("\nInsira o nome: ");
                        string nome = Console.ReadLine();
                        while (nome.Any(char.IsNumber) || nome == String.Empty || nome == null || nome.Any(char.IsSymbol) || nome.Any(char.IsPunctuation))
                        {
                            Console.WriteLine("\nInválido, Insira novamente: ");
                            nome = Console.ReadLine();
                        }
                        Console.WriteLine("\nInsira a altura: ");
                        float altura;
                        AlturaRep:
                        try
                        {
                            altura = float.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\nApenas valores numéricos");
                            goto AlturaRep;
                        }
                        Console.WriteLine("\nInsira a idade: ");
                        int idade;
                        IdadeRep:
                        try
                        {
                            idade = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\nApenas valores numéricos");
                            goto IdadeRep;
                        }
                        Console.WriteLine("\nInsira a cidade: ");
                        string cidade = Console.ReadLine();
                        while (cidade.Any(char.IsNumber) || cidade == String.Empty || cidade == null || cidade.Any(char.IsSymbol) || cidade.Any(char.IsPunctuation))
                        {
                            Console.WriteLine("\nInválido, Insira novamente: ");
                            cidade = Console.ReadLine();
                        }
                        Console.WriteLine("\nInsira o CPF (apenas números): ");
                        string cpf = Console.ReadLine();
                        while (cpf.Any(char.IsLetter) || cpf == String.Empty || cpf == null || cpf.Any(char.IsSymbol) || cpf.Any(char.IsPunctuation))
                        {
                            Console.WriteLine("\nEntrada inválida, tente novamente");
                            cpf = Console.ReadLine();
                        }
                        Controller.LerInfo(nome, altura, idade, cidade, cpf);
                        Console.WriteLine("\nDeseja fazer outro cadastro? S/N");
                        char cadRep = Console.ReadKey().KeyChar;
                        if(cadRep == 's' || cadRep == 'S')
                        {
                            goto Repeat;
                        }
                        else
                        {
                            break;
                        }
                    case '2':
                        int ct = 0;
                        if(Model.Lista.Capacity > 0) {
                            for (int x = 0; x < Model.Lista.Count; x = x + 5)
                            {
                                Console.WriteLine($"Cadastro {ct + 1}\n" +
                                        $"Nome: {Model.Lista[x]}\n" +
                                        $"Altura: {Model.Lista[x + 1]}\n" +
                                        $"Idade: {Model.Lista[x + 2]}\n" +
                                        $"Cidade: {Model.Lista[x + 3]}\n" +
                                        $"CPF: {Model.Lista[x + 4]}\n"
                                        );
                                ct++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNenhum registro encontrado.");
                        }
                        break;
                    case '3':
                        Console.WriteLine("\nInsira o nome à ser buscado: ");
                        string nomeBusca = Console.ReadLine();
                        if (Controller.AcharCad(nomeBusca) == true)
                        {
                            int ct2 = 0;
                            for (int x = 0; x < Model.Lista.Count; x = x + 5)
                            {
                                string check = Model.Lista[x].ToString();
                                if (check == nomeBusca)
                                {
                                    Console.WriteLine($"Cadastro {ct2 + 1}\n" +
                                   $"Nome: {Model.Lista[x]}\n" +
                                   $"Altura: {Model.Lista[x + 1]}\n" +
                                   $"Idade: {Model.Lista[x + 2]}\n" +
                                   $"Cidade: {Model.Lista[x + 3]}\n" +
                                   $"CPF: {Model.Lista[x + 4]}\n"
                                   );
                                }
                                ct2++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNenhum registro encontrado.");
                        }
                        break;
                    case '4':
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine("\nDebug na sua mãe");
                Console.ReadKey();
                Console.Clear();
            } while (reset == 'n');
        }
    }
}