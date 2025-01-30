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
}
