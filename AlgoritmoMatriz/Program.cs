// See https://aka.ms/new-console-template for more information
int NumColunas = 0;

int NumLinhas = 0;

bool NumColunasValido = false;
do
{
    Console.WriteLine("Digite o número de colunas da matriz:");
    NumColunas = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();
    if (NumColunas == 0)
    {
        NumColunasValido = false;
        Console.WriteLine("O número de colunas de uma matriz não pode ser menor que um!!!");
        Console.WriteLine();
    }
    else NumColunasValido = true;
} while (NumColunasValido == false);
bool NumLinhasValido = false;
do
{
    Console.WriteLine("Digite o número de linhas da matriz:");
    NumLinhas = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();
    if (NumLinhas == 0)
    {
        NumLinhasValido = false;
        Console.WriteLine("O número de linhas de uma matriz não pode ser menor que um!!!");
        Console.WriteLine();
    }
    else NumLinhasValido = true;
} while (NumLinhasValido == false);
Random rnd = new Random();
List<int> NumerosMatriz = new List<int>();

for (var i = 0; i < (NumColunas * NumLinhas); i++)
{
    int NovoNumero = rnd.Next(1, ((NumLinhas * NumColunas) + 1));
    NumerosMatriz.Add(NovoNumero);
}

List<int> NumerosContados = new List<int>();

foreach (int item in NumerosMatriz)
{
    bool NumeroJaContado = false;
    foreach (int item2 in NumerosContados)
    {
        if (item2 == item)
        {
            NumeroJaContado = true;
        }
    }
    if (NumeroJaContado == false)
    {
        NumerosContados.Add(item);
        int RepeticoesDoNumero = NumerosMatriz.FindAll(n => n == item).Count;
        Console.WriteLine($"O número {item} se repete {RepeticoesDoNumero} vezes!!!");
    }
}
Console.WriteLine();
bool RespostaOrdenacaoValida = false;
bool Ordenar = false;
do
{
    Console.WriteLine("Deseja ordenar a matriz?(S/N)");
    string Resposta;
    Resposta = Console.ReadLine().ToUpper();
    Console.WriteLine();
    switch (Resposta)
    {
        case "S":
            Ordenar = true;
            RespostaOrdenacaoValida = true;
            break;
        case "N":
            Ordenar = false;
            RespostaOrdenacaoValida = true;
            break;
        default:
            Console.WriteLine("Resposta inválida");
            Console.WriteLine();
            break;
    }
} while (RespostaOrdenacaoValida == false);

if (Ordenar)
{
    int Contador = 0;
    foreach (int item in NumerosMatriz)
    {
        if (Contador == NumColunas)
        {
            Console.Write("\n");
            Contador = 0;
        }
        Console.Write($"--{item}--");
        Contador++;
    }
}
else
{
    Console.WriteLine("Certo, desligando...");
}