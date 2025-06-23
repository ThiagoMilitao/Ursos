using System;
using System.Collections.Generic;
using System.Linq;

class Urso
{
    public double Peso { get; set; }
    public char Sexo { get; set; }
    public string? Categoria { get; set; }
}

class Program
{
    static readonly string[] categorias = { "ML", "L", "M", "P", "MP" };

    static string ClassificaPeso(double peso)
    {
        if (peso > 0 && peso <= 50) return "ML";
        if (peso > 50 && peso <= 100) return "L";
        if (peso > 100 && peso <= 150) return "M";
        if (peso > 150 && peso <= 200) return "P";
        if (peso > 200 && peso <= 250) return "MP";
        return "Inválido";
    }
    static void histogramas(List<Urso> lista, string titulo, ConsoleColor corDaBarra)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n-----  {titulo}  -----");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("+...10...20...30...40...50...60...70...80...90..100");
        Console.ResetColor();

        foreach (var category in categorias)
        {
            int count = lista.Count(u => u.Categoria == category);
            string barra = new string('*', count);
            
            Console.Write($"{category,-3}|");

            Console.ForegroundColor = corDaBarra;
            Console.WriteLine(barra);
            Console.ResetColor();
        }
    }

    static void Main()
    {
        // Título estilizado
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"
 _    _
| |  | |
| |  | | _ __  ___   ___   ___
| |  | || '__|/ __| / _ \ / __|
| |__| || |   \__ \| (_) |\__ \
 \____/ |_|   |___/ \___/ |___/

        ");
        Console.ResetColor();

        List<Urso> ursos = new List<Urso>();
        Console.WriteLine("Para encerrar, informe um peso menor ou igual a 0.\n");

        while (true)
        {
            Console.Write("Informe o peso do urso (em kg, entre 1 e 250): ");
            if (!double.TryParse(Console.ReadLine(), out double peso) || peso <= 0 || peso > 250)
            {
                Console.WriteLine("\nEncerrando a coleta de dados...");
                break;
            }

            Console.Write("Informe o sexo do urso (M para macho, F para fêmea): ");
            if (!char.TryParse(Console.ReadLine()!.ToUpper(), out char sexo) || (sexo != 'M' && sexo != 'F'))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sexo inválido. Digite apenas 'M' ou 'F'.\n");
                Console.ResetColor();
                continue;
            }

            string categoria = ClassificaPeso(peso);
            ursos.Add(new Urso { Peso = peso, Sexo = sexo, Categoria = categoria });
            Console.WriteLine("--- Urso registrado! --- \n");
        }

        if (ursos.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nenhum urso foi registrado!");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n================= ANÁLISE DOS DADOS =================\n");
        Console.ResetColor();

        var listmachos = ursos.Where(u => u.Sexo == 'M').ToList();
        var listfemeas = ursos.Where(u => u.Sexo == 'F').ToList();

        // Urso mais pesado
        var ursoMaisPesado = ursos.OrderByDescending(e => e.Peso).First();
        Console.Write("Urso mais pesado: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{ursoMaisPesado.Peso} kg, Sexo: {ursoMaisPesado.Sexo}");
        Console.ResetColor();


        // Média de peso
        if (listmachos.Any())
        {
            Console.WriteLine($"Média do peso dos ursos machos: {listmachos.Average(u => u.Peso):F2} kg");
        }
        if (listfemeas.Any())
        {
            Console.WriteLine($"Média do peso dos ursos fêmeas: {listfemeas.Average(u => u.Peso):F2} kg");
        }

        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("| Categoria    | Ursos | Ursos (%)  | Machos | Machos (%)  | Fêmeas | Fêmeas (%)  |");
        Console.WriteLine("|--------------|-------|------------|--------|-------------|--------|-------------|");
        Console.ResetColor();

        int totalUrsos = ursos.Count;
        int totalMachos = listmachos.Count;
        int totalFemeas = listfemeas.Count;

        foreach (var cat in categorias)
        {
            var grupo = ursos.Where(u => u.Categoria == cat);
            int qtd = grupo.Count();
            int machos = grupo.Count(u => u.Sexo == 'M');
            int femeas = grupo.Count(u => u.Sexo == 'F');
            double pctUrsos = totalUrsos > 0 ? (double)qtd / totalUrsos * 100 : 0;
            double pctMachos = totalMachos > 0 ? (double)machos / totalMachos * 100 : 0;
            double pctFemeas = totalFemeas > 0 ? (double)femeas / totalFemeas * 100 : 0;

            Console.WriteLine($"| {cat,-12} | {qtd,5} | {pctUrsos,9:F0}% | {machos,6} | {pctMachos,10:F0}% | {femeas,6} | {pctFemeas,10:F0}% |");
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("|--------------|-------|------------|--------|-------------|--------|-------------|");
        double pctTotalMachos = totalUrsos > 0 ? (double)totalMachos / totalUrsos * 100 : 0;
        double pctTotalFemeas = totalUrsos > 0 ? (double)totalFemeas / totalUrsos * 100 : 0;
        Console.WriteLine($"| {"Total",-12} | {totalUrsos,5} | {100,9:F0}% | {totalMachos,6} | {pctTotalMachos,10:F0}% | {totalFemeas,6} | {pctTotalFemeas,10:F0}% |");
        Console.ResetColor();

        histogramas(listmachos, "Distribuição de Ursos Machos", ConsoleColor.Blue);
        histogramas(listfemeas, "Distribuição de Ursos Fêmeas", ConsoleColor.Magenta);
        histogramas(ursos, "Distribuição Total de Ursos", ConsoleColor.Green);
        
        Console.WriteLine("\nPressione Enter para fechar o programa...");
        Console.ReadLine(); 
    }
}