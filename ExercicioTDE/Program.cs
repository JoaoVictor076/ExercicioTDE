using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Criar uma lista de objetos da classe Pessoa
        List<Pessoa> pessoas = new List<Pessoa>() {
            new Pessoa { Nome = "Luis", Idade = 25 },
            new Pessoa { Nome = "Bianca", Idade = 30 },
            new Pessoa { Nome = "Pedro", Idade = 35 }
        };

        // Serializar objetos da classe Pessoa em uma string JSON
        string jsonString = JsonConvert.SerializeObject(pessoas);

        // Salvar a string JSON em um arquivo
        string caminhoArquivo = @"C:\Users\044983\Desktp\Pessoas.json";

        if (File.Exists(caminhoArquivo))
        {
            File.WriteAllText(caminhoArquivo, jsonString);
        }
        else
        {
            Console.Write("Arquivo não existe");
            return;
        }


        // Ler o conteúdo do arquivo de volta para uma string JSON
        string jsonStringFromFile = File.ReadAllText(caminhoArquivo);

        // Transformar a string JSON de volta em objetos da classe Pessoa
        List<Pessoa> pessoasFromFile = JsonConvert.DeserializeObject<List<Pessoa>>(jsonStringFromFile);

        // Exibir os objetos da classe Pessoa lidos do arquivo
        foreach (Pessoa p in pessoasFromFile)
        {
            Console.WriteLine($"Nome: {p.Nome}, Idade: {p.Idade}");
        }

        Console.ReadLine();
    }
}