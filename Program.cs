using System.Diagnostics.Metrics;

class Urso
{
    public double Peso { get; set; }
    public char Sexo { get; set; }
    public string? Categoria { get; set; }
}

class Program
{
    static string[] categorias = { "ML", "L", "M", "P", "MP" };

    static string ClassificaPeso(double peso)
    {
        if (peso > 0 && peso <= 50) return "ML";
        if (peso > 50 && peso <= 100) return "L";
        if (peso > 100 && peso <= 150) return "M";
        if (peso > 150 && peso <= 200) return "P";
        if (peso > 200 && peso <= 250) return "MP";
        return "Inválido";
    }

   static void histogramas(List<Urso> lista, string titulo)
    {
        Console.WriteLine($"\n-----  {titulo}  -----");
        Console.WriteLine("+...10...20...30...40...50...60...70...80...90..100");
        foreach (var category in categorias)
        {
            int count = lista.Count(u => u.Categoria == category);
            string barra = new string('*', count);
            Console.WriteLine($"{category,-3}|{barra}");
        }

    }

    static void Main()
    {
        Console.WriteLine("---------------------Ursos---------------------");
        List<Urso> ursos = new List<Urso>();

        Console.WriteLine("Para encerrar, informe um peso menor ou igual a 0 ou maior que 250.\n");

        while (true)
        {
            Console.Write("Informe o peso do urso (em kg, entre 1 e 250): ");
            if (!double.TryParse(Console.ReadLine(), out double peso))
            {
                Console.WriteLine("Valor inválido. Por favor, digite um número válido para o peso.\n"); continue;
            }
            if (peso < 0 || peso > 250)
            {
                Console.Write("Informe o peso do urso (em kg, entre 1 e 250): ");
                break;
            }

            Console.Write("Informe o sexo do urso (M para macho, F para fêmea): ");
            if (!char.TryParse(Console.ReadLine()!.ToUpper(), out char sexo))
            {
                Console.WriteLine("Sexo inválido. Digite apenas 'M' ou 'F'.\n");
                continue;
            }

            string categoria = ClassificaPeso(peso);

            ursos.Add(new Urso
            {
                Peso = peso,
                Sexo = sexo,
                Categoria = categoria
            });
           
        }

        if (ursos.Count == 0)
        {
            Console.WriteLine("Nenhum urso foi registrado!");
            return;
        }
        var listmachos = ursos.Where(u => u.Sexo == 'M').ToList();
        var listfemeas = ursos.Where(u => u.Sexo == 'F').ToList();

        //Urso mais pesado
        var listaOrdenada = ursos.OrderByDescending(e => e.Peso).First();
        Console.WriteLine($"Urso mais pesado: {listaOrdenada.Peso}, Sexo: {listaOrdenada.Sexo}");

        double[] media = new double[2];

        if (ursos.Any(u => u.Sexo == 'M'))
        {
            media[0] = ursos.Where(u => u.Sexo == 'M').Average(u => u.Peso);
            Console.WriteLine($"Média do peso dos ursos masculinos: {media[0]:F2} kg");
        }
        else
        {
            Console.WriteLine("Nenhum urso masculino registrado.");
        }

        if (ursos.Any(u => u.Sexo == 'F'))
        {
            media[1] = ursos.Where(u => u.Sexo == 'F').Average(u => u.Peso);
            Console.WriteLine($"Média do peso dos ursos feminino: {media[1]:F2} kg");
        }
        else
        {
            Console.WriteLine("Nenhum urso feminino registrado.");
        }

        int totalUrsos = ursos.Count;
        int totalMachos = ursos.Count(u => u.Sexo == 'M');
        int totalFemeas = ursos.Count(u => u.Sexo == 'F');
        Console.WriteLine("| Categoria    | Ursos | Ursos (%)  | Machos | Machos (%)  | Fêmeas | Fêmeas (%)  |");
        Console.WriteLine("|--------------|-------|------------|--------|-------------|--------|-------------|");

        foreach (var cat in categorias)
        {
            var grupo = ursos.Where(u => u.Categoria == cat);
            int qtd = grupo.Count();
            int machos = grupo.Count(u => u.Sexo == 'M');
            int femeas = grupo.Count(u => u.Sexo == 'F');
            double pctUrsos = totalUrsos > 0 ? qtd / totalUrsos * 100 : 0;
            double pctMachos = totalMachos > 0 ? machos / totalMachos * 100 : 0;
            double pctFemeas = totalFemeas > 0 ? femeas / totalFemeas * 100 : 0;

            Console.WriteLine($"| {cat,-12} | {qtd,5} | {pctUrsos,9:F0}% | {machos,6} | {pctMachos,10:F0}% | {femeas,6} | {pctFemeas,10:F0}% |");
        }

        Console.WriteLine("|--------------|-------|------------|--------|-------------|--------|-------------|");
        Console.WriteLine($"| {"Total",-12} | {totalUrsos,5} | {100,9}% | {totalMachos,6} | {(totalUrsos > 0 ? (double)totalMachos / totalUrsos * 100 : 0),10:F0}% | {totalFemeas,6} | {(totalUrsos > 0 ? (double)totalFemeas / totalUrsos * 100 : 0),10:F0}% |");


        histogramas(listmachos, "Ursos Machos");
        histogramas(listfemeas, "Ursos Fêmeas");
        histogramas(ursos, "Total de Ursos");
    }


}


