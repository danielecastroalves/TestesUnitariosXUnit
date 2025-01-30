using NSubstitute;

namespace CalculadoraFinanceira.Tests;

public class CalculadoraFinanceiraServiceTest2
{
    private readonly ICalculadoraFinanceira _calculadoraFinanceiraMock;
    private readonly CalculadoraFinanceiraService _calculadoraFinanceiraService;

    public CalculadoraFinanceiraServiceTest2()
    {
        _calculadoraFinanceiraMock = Substitute.For<ICalculadoraFinanceira>();
        _calculadoraFinanceiraService = new CalculadoraFinanceiraService(_calculadoraFinanceiraMock);
    }

    [Fact]
    public void SomarValores_QuandoRecebeDoisValores_DeveRetornarSomaCorreta()
    {
        // Arrange
        int a = 10, b = 20;
        var resultadoEsperado = 30;

        _calculadoraFinanceiraMock.Somar(a, b).Returns(resultadoEsperado);

        // Act
        var resultado = _calculadoraFinanceiraService.SomarValores(a, b);

        // Assert
        Assert.Equal(resultadoEsperado, resultado);
        _calculadoraFinanceiraMock.Received(1).Somar(a, b);
    }

    [Fact]
    public async Task CalcularDivisaoAsync_QuantoRecebeDoisValores_DeveRetornarResultadoCorreto()
    {
        // Arrange
        int numerador = 100, denominador = 5;
        _calculadoraFinanceiraMock.DividirAsync(numerador, denominador).Returns(20);

        // Act
        var resultado = await _calculadoraFinanceiraService.CalcularDivisaoAsync(numerador, denominador);

        // Assert
        Assert.Equal(20, resultado);
        await _calculadoraFinanceiraMock.Received(1).DividirAsync(numerador, denominador);
    }

    [Fact]
    public async Task CalcularDivisaoAsync_QuandoDenominadorForZero_DeveLancarArgumentException()
    {
        // Arrange
        int numerador = 10, denominador = 0;

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(
            () => _calculadoraFinanceiraService.CalcularDivisaoAsync(numerador, denominador));

        Assert.Equal("O denominador não pode ser zero.", exception.Message);
        await _calculadoraFinanceiraMock.DidNotReceive().DividirAsync(Arg.Any<int>(), Arg.Any<int>());
    }

    [Theory]
    [InlineData(5, 5, 10)]  // Cenário 1: Soma de números positivos
    [InlineData(-3, 7, 4)]  // Cenário 2: Soma de positivo e negativo
    [InlineData(0, 0, 0)]   // Cenário 3: Soma de zeros
    public void SomarValores_RecebendoDoisNumeros_DeveRetornarSomaCorreta(int a, int b, int esperado)
    {
        // Arrange
        _calculadoraFinanceiraMock.Somar(a, b).Returns(esperado);

        // Act
        var resultado = _calculadoraFinanceiraService.SomarValores(a, b);

        // Assert
        Assert.Equal(esperado, resultado);
        _calculadoraFinanceiraMock.Received(1).Somar(a, b);
    }

    [Theory]
    [InlineData(3, false)]  // Ímpar
    [InlineData(4, true)]   // Par
    [InlineData(0, true)]   // Zero é par
    [InlineData(-2, true)]  // Negativo par
    public void VerificarSeEhPar_QuandoReceberUmNumero_DeveIdentificarCorretamente(int numero, bool esperado)
    {
        // Arrange
        _calculadoraFinanceiraMock.EhPar(numero).Returns(esperado);

        // Act
        var resultado = _calculadoraFinanceiraService.VerificarSeEhPar(numero);

        // Assert
        Assert.Equal(esperado, resultado);
        _calculadoraFinanceiraMock.Received(1).EhPar(numero);
    }

    [Theory]
    [InlineData(10, 2, 5)]  // Divisão normal
    [InlineData(9, 3, 3)]   // Outra divisão normal
    public async Task CalcularDivisaoAsync_QuandoReceberDoisValores_DeveRetornarResultadoEsperado(int numerador, int denominador, int esperado)
    {
        // Arrange
        _calculadoraFinanceiraMock.DividirAsync(numerador, denominador).Returns(esperado);

        // Act
        var resultado = await _calculadoraFinanceiraService.CalcularDivisaoAsync(numerador, denominador);

        // Assert
        Assert.Equal(esperado, resultado);
        await _calculadoraFinanceiraMock.Received(1).DividirAsync(numerador, denominador);
    }
}
