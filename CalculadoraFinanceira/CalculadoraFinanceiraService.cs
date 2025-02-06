namespace CalculadoraFinanceira;

public class CalculadoraFinanceiraService(ICalculadoraFinanceira calculadoraFinanceira)
{
    private readonly ICalculadoraFinanceira _calculadoraFinanceira = calculadoraFinanceira;

    public int SomarValores(int a, int b)
    {
        return _calculadoraFinanceira.Somar(a, b);
    }

    public int MultiplicarValores(int a, int b)
    {
        return _calculadoraFinanceira.Multiplicar(a, b);
    }

    public async Task<int> CalcularDivisaoAsync(int numerador, int denominador)
    {
        if (denominador == 0)
            throw new ArgumentException("O denominador não pode ser zero.");

        return await _calculadoraFinanceira.DividirAsync(numerador, denominador);
    }

    public bool VerificarSeEhPar(int numero)
    {
        return _calculadoraFinanceira.EhPar(numero);
    }

    public decimal CalcularJurosCompostos(decimal principal, decimal taxa, int periodo)
    {
        if (principal < 0 || taxa < 0 || periodo < 0)
            throw new ArgumentException("Os valores devem ser positivos.");

        return _calculadoraFinanceira.CalcularJurosCompostos(principal, taxa, periodo);
    }

    public decimal ConverterMoeda(decimal valor, decimal taxaDeConversao)
    {
        if (valor < 0 || taxaDeConversao <= 0)
            throw new ArgumentException("Valor e taxa de conversão devem ser positivos.");

        return _calculadoraFinanceira.ConverterMoeda(valor, taxaDeConversao);
    }

    public decimal CalcularDesconto(decimal valorOriginal, decimal percentualDesconto)
    {
        if (valorOriginal < 0 || percentualDesconto < 0 || percentualDesconto > 100)
            throw new ArgumentException("Valores inválidos para o desconto.");

        return _calculadoraFinanceira.CalcularDesconto(valorOriginal, percentualDesconto);
    }
}
