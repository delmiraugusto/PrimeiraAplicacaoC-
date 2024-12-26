// Screen Sound
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

Dictionary<string, List<double>> dicionarioBandas = new Dictionary<string, List<double>>();

dicionarioBandas.Add("Billie", new List<double> { 10, 9, 10 });
dicionarioBandas.Add("Glaive", new List<double>());
void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
    ");
}

void ExibirOpcoesMenu() {
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcao = Console.ReadLine()!;
    int opcaoNumerica = int.Parse(opcao);

    switch (opcaoNumerica)
    {
        case 1: RegistrarBanda();
            break;
        case 2: ListarBandas();
            break;
        case 3: AvaliarBanda();
            break;
        case 4: MediaBanda();
            break;
        case -1: 
            Console.WriteLine("Saindo... ");
            break;
        default: Console.WriteLine("Opção Inválida");
            break;
    }
}

void RegistrarBanda() 
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro das Bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeBanda = Console.ReadLine()!;
    dicionarioBandas.Add(nomeBanda, new List<double>());
    Console.WriteLine($"A banda {nomeBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesMenu();
}

void ListarBandas() 
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as Bandas Registradas");
    //for (int i = 0; i < listBanda.Count; i++)
    foreach (string banda in dicionarioBandas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.WriteLine("\nDigite qualquer tecla para voltar ao menu");
    Console.ReadKey();
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesMenu();
}

void AvaliarBanda() { 
    Console.Clear();
    ExibirTituloDaOpcao("Avaliação de Banda");
    Console.Write("Digite a banda que deseja avaliar: ");
    string banda = Console.ReadLine()!;
    if (dicionarioBandas.ContainsKey(banda))
    {
        Console.Write($"Nota para {banda}: ");
        double nota = double.Parse(Console.ReadLine()!);
        dicionarioBandas[banda].Add(nota);
        Console.WriteLine($"Nota {nota} foi registrada para {banda}");
        Thread.Sleep(3000);
        Console.Clear();
        ExibirOpcoesMenu();
    }
    else {
        Console.WriteLine($"\n{banda} não foi encontrada");
        Console.WriteLine("Digite qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
    }
}

void MediaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliação Média da Banda");
    Console.Write("Digite a banda que deseja saber a média: ");
    string banda = Console.ReadLine()!;
    if (dicionarioBandas.ContainsKey(banda))
    {
        List<double> notasBanda = dicionarioBandas[banda];
        double mediaBanda = notasBanda.Average();

        Console.WriteLine($"A média de Nota de {banda} é de: {mediaBanda:F2}");
        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
    }
    else {
        Console.WriteLine($"\n{banda} não foi encontrada");
        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();

    }
}

void ExibirTituloDaOpcao(string titulo) { 
    int quantLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

ExibirOpcoesMenu();