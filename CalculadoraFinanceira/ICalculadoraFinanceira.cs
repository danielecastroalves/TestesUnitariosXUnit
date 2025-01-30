namespace CalculadoraFinanceira;

public interface ICalculadoraFinanceira
{
    int Somar(int a, int b);
    int Multiplicar(int a, int b);
    Task<int> DividirAsync(int numerador, int denominador);
    bool EhPar(int numero);
}
