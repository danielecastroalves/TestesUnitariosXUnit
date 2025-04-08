using Shouldly;
using NSubstitute;

namespace CalculadoraFinanceira.Tests;

public class CalculadoraFinanceiraServiceTestsNSubstitute
{
    private readonly ICalculadoraFinanceira _calculadoraFinanceiraMock;
    private readonly CalculadoraFinanceiraService _sut;

    public CalculadoraFinanceiraServiceTestsNSubstitute()
    {
        _calculadoraFinanceiraMock = Substitute.For<ICalculadoraFinanceira>();
        _sut = new CalculadoraFinanceiraService(_calculadoraFinanceiraMock);
    }

    #region Testes com Fact
    [Fact]
    public void SomarValores_QuandoRecebeDoisValores_DeveRetornarSomaCorreta()
    {
        // Arrange
        const int a = 10, b = 20;
        const int resultadoEsperado = 30;

        _calculadoraFinanceiraMock
            .Somar(a, b)
            .Returns(resultadoEsperado);

        // Act
        var resultado = _sut.SomarValores(a, b);

        // Assert
        resultado.ShouldBe(resultadoEsperado);

        _calculadoraFinanceiraMock
            .Received(1).Somar(a, b);
    }

    [Fact]
    public async Task CalcularDivisaoAsync_QuantoRecebeDoisValores_DeveRetornarResultadoCorreto()
    {
        // Arrange
        const int numerador = 100, denominador = 5;

        _calculadoraFinanceiraMock
            .DividirAsync(numerador, denominador)
            .Returns(20);

        // Act
        var resultado = await _sut.CalcularDivisaoAsync(numerador, denominador);

        // Assert
        resultado.ShouldBe(20);

        await _calculadoraFinanceiraMock
            .Received(1).DividirAsync(numerador, denominador);
    }

    [Fact]
    public async Task CalcularDivisaoAsync_QuandoDenominadorForZero_DeveLancarArgumentException()
    {
        // Arrange
        const int numerador = 10, denominador = 0;

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(
            () => _sut.CalcularDivisaoAsync(numerador, denominador));

        exception.Message.ShouldBe("O denominador não pode ser zero.");

        await _calculadoraFinanceiraMock
            .DidNotReceive().DividirAsync(
                Arg.Any<int>(),
                Arg.Any<int>());
    }

    [Fact]
    public void CalcularJurosCompostos_QuandoValoresInvalidos_DeveLancarExcecao()
    {
        // Arrange
        const decimal principal = -1000;
        const decimal taxa = 0.05m;
        const int periodo = 2;

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(
            () => _sut.CalcularJurosCompostos(principal, taxa, periodo));

        exception.Message.ShouldBe("Os valores devem ser positivos.");

        _calculadoraFinanceiraMock
            .DidNotReceive().CalcularJurosCompostos(
                Arg.Any<decimal>(),
                Arg.Any<decimal>(),
                Arg.Any<int>());
    }

    [Fact]
    public void ConverterMoeda_QuandoValoresInvalidos_DeveLancarExcecao()
    {
        // Arrange
        const decimal valor = -100;
        const decimal taxaDeConversao = 5.25m;

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(
            () => _sut.ConverterMoeda(valor, taxaDeConversao));

        exception.Message.ShouldBe("Valor e taxa de conversão devem ser positivos.");

        _calculadoraFinanceiraMock
            .DidNotReceive().ConverterMoeda(
                Arg.Any<decimal>(),
                Arg.Any<decimal>());
    }

    [Fact]
    public void CalcularDesconto_QuandoPercentualInvalido_DeveLancarExcecao()
    {
        // Arrange
        const decimal valorOriginal = 200;
        const decimal percentualDesconto = 110;

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(
            () => _sut.CalcularDesconto(valorOriginal, percentualDesconto));

        exception.Message.ShouldBe("Valores inválidos para o desconto.");

        _calculadoraFinanceiraMock
           .DidNotReceive().ConverterMoeda(
               Arg.Any<decimal>(),
               Arg.Any<decimal>());
    }
    #endregion

    #region Testes com Theory
    [Theory]
    [InlineData(5, 5, 10)]    // Cenário 1: Soma de números positivos
    [InlineData(-3, 7, 4)]    // Cenário 2: Soma de positivo e negativo
    [InlineData(-2, -3, -5)]  // Cenário 3: Soma de negativo e negativo
    [InlineData(0, 0, 0)]     // Cenário 4: Soma de zeros
    public void SomarValores_RecebendoDoisNumeros_DeveRetornarSomaCorreta(int a, int b, int esperado)
    {
        // Arrange
        _calculadoraFinanceiraMock.Somar(a, b).Returns(esperado);

        // Act
        var resultado = _sut.SomarValores(a, b);

        // Assert
        resultado.ShouldBe(esperado);

        _calculadoraFinanceiraMock
            .Received(1).Somar(a, b);
    }

    [Theory]
    [InlineData(10, 2, 5)]
    [InlineData(9, 3, 3)]
    public async Task CalcularDivisaoAsync_QuandoReceberDoisValores_DeveRetornarResultadoEsperado(int numerador, int denominador, int esperado)
    {
        // Arrange
        _calculadoraFinanceiraMock.DividirAsync(numerador, denominador).Returns(esperado);

        // Act
        var resultado = await _sut.CalcularDivisaoAsync(numerador, denominador);

        // Assert
        resultado.ShouldBe(esperado);

        await _calculadoraFinanceiraMock
            .Received(1).DividirAsync(numerador, denominador);
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
        var resultado = _sut.VerificarSeEhPar(numero);

        // Assert
        resultado.ShouldBe(esperado);

        _calculadoraFinanceiraMock
            .Received(1).EhPar(numero);
    }

    [Theory]
    [InlineData(1000, 0.05, 2, 1102.50)]
    [InlineData(500, 0.10, 3, 665.50)]
    public void CalcularJurosCompostos_QuandoValoresValidos_DeveRetornarResultadoCorreto(decimal principal, decimal taxa, int periodo, decimal esperado)
    {
        // Arrange
        _calculadoraFinanceiraMock
            .CalcularJurosCompostos(principal, taxa, periodo)
            .Returns(esperado);

        // Act
        var resultado = _sut.CalcularJurosCompostos(principal, taxa, periodo);

        // Assert
        resultado.ShouldBe(esperado);

        _calculadoraFinanceiraMock
            .Received(1).CalcularJurosCompostos(
                Arg.Any<decimal>(),
                Arg.Any<decimal>(),
                Arg.Any<int>());
    }

    [Theory]
    [InlineData(100, 5.25, 525)]
    [InlineData(200, 4.5, 900)]
    public void ConverterMoeda_QuandoValoresValidos_DeveRetornarValorConvertido(decimal valor, decimal taxaDeConversao, decimal esperado)
    {
        // Arrange
        _calculadoraFinanceiraMock
            .ConverterMoeda(valor, taxaDeConversao)
            .Returns(esperado);

        // Act
        var resultado = _sut.ConverterMoeda(valor, taxaDeConversao);

        // Assert
        resultado.ShouldBe(esperado);

        _calculadoraFinanceiraMock
            .Received(1).ConverterMoeda(
                Arg.Any<decimal>(),
                Arg.Any<decimal>());
    }

    [Theory]
    [InlineData(200, 10, 180)]
    [InlineData(500, 20, 400)]
    public void CalcularDesconto_QuandoValoresValidos_DeveRetornarValorComDesconto(decimal valorOriginal, decimal percentualDesconto, decimal esperado)
    {
        // Arrange
        _calculadoraFinanceiraMock
            .CalcularDesconto(valorOriginal, percentualDesconto)
            .Returns(esperado);

        // Act
        var resultado = _sut.CalcularDesconto(valorOriginal, percentualDesconto);

        // Assert
        resultado.ShouldBe(esperado);

        _calculadoraFinanceiraMock
           .Received(1).CalcularDesconto(
               Arg.Any<decimal>(),
               Arg.Any<decimal>());
    }
    #endregion
}
