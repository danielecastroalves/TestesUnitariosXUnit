using Moq;

namespace CalculadoraFinanceira.Tests;

public class CalculadoraFinanceiraServiceTestsMoq
{
    private readonly Mock<ICalculadoraFinanceira> _calculadoraFinanceiraMock;
    private readonly CalculadoraFinanceiraService _calculadoraFinanceiraService;

    public CalculadoraFinanceiraServiceTestsMoq()
    {
        _calculadoraFinanceiraMock = new Mock<ICalculadoraFinanceira>();
        _calculadoraFinanceiraService = new CalculadoraFinanceiraService(_calculadoraFinanceiraMock.Object);
    }

    #region Testes com Fact
    [Fact]
    public void SomarValores_QuandoRecebeDoisValores_DeveRetornarSomaCorreta()
    {
        // Arrange
        const int a = 10, b = 20;
        const int resultadoEsperado = 30;

        _calculadoraFinanceiraMock
            .Setup(m => m.Somar(a, b))
            .Returns(resultadoEsperado);

        // Act
        var resultado = _calculadoraFinanceiraService.SomarValores(a, b);

        // Assert
        Assert.Equal(resultadoEsperado, resultado);

        _calculadoraFinanceiraMock
            .Verify(m => m.Somar(a, b), Times.Once);
    }

    [Fact]
    public async Task CalcularDivisaoAsync_QuantoRecebeDoisValores_DeveRetornarResultadoCorreto()
    {
        // Arrange
        const int numerador = 100, denominador = 5;

        _calculadoraFinanceiraMock
            .Setup(m => m.DividirAsync(numerador, denominador))
            .ReturnsAsync(20);

        // Act
        var resultado = await _calculadoraFinanceiraService.CalcularDivisaoAsync(numerador, denominador);

        // Assert
        Assert.Equal(20, resultado);

        _calculadoraFinanceiraMock
            .Verify(m => m.DividirAsync(numerador, denominador), Times.Once);
    }

    [Fact]
    public async Task CalcularDivisaoAsync_QuandoDenominadorForZero_DeveLancarArgumentException()
    {
        // Arrange
        const int numerador = 10, denominador = 0;

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(
            () => _calculadoraFinanceiraService.CalcularDivisaoAsync(numerador, denominador));

        Assert.Equal("O denominador não pode ser zero.", exception.Message);

        _calculadoraFinanceiraMock
            .Verify(m => m.DividirAsync(
                It.IsAny<int>(),
                It.IsAny<int>()), Times.Never);
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
            () => _calculadoraFinanceiraService.CalcularJurosCompostos(principal, taxa, periodo));

        Assert.Equal("Os valores devem ser positivos.", exception.Message);

        _calculadoraFinanceiraMock
            .Verify(m => m.CalcularJurosCompostos(
                It.IsAny<decimal>(),
                It.IsAny<decimal>(),
                It.IsAny<int>()), Times.Never);
    }

    [Fact]
    public void ConverterMoeda_QuandoValoresInvalidos_DeveLancarExcecao()
    {
        // Arrange
        const decimal valor = -100;
        const decimal taxaDeConversao = 5.25m;

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(
            () => _calculadoraFinanceiraService.ConverterMoeda(valor, taxaDeConversao));

        Assert.Equal("Valor e taxa de conversão devem ser positivos.", exception.Message);

        _calculadoraFinanceiraMock
            .Verify(m => m.ConverterMoeda(
                It.IsAny<decimal>(),
                It.IsAny<decimal>()), Times.Never);
    }

    [Fact]
    public void CalcularDesconto_QuandoPercentualInvalido_DeveLancarExcecao()
    {
        // Arrange
        const decimal valorOriginal = 200;
        const decimal percentualDesconto = 110;

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(
            () => _calculadoraFinanceiraService.CalcularDesconto(valorOriginal, percentualDesconto));

        Assert.Equal("Valores inválidos para o desconto.", exception.Message);

        _calculadoraFinanceiraMock
            .Verify(m => m.CalcularDesconto(
                It.IsAny<decimal>(),
                It.IsAny<decimal>()), Times.Never);
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
        _calculadoraFinanceiraMock
            .Setup(m => m.Somar(a, b))
            .Returns(esperado);

        // Act
        var resultado = _calculadoraFinanceiraService.SomarValores(a, b);

        // Assert
        Assert.Equal(esperado, resultado);

        _calculadoraFinanceiraMock
            .Verify(m => m.Somar(a, b), Times.Once);
    }

    [Theory]
    [InlineData(10, 2, 5)]
    [InlineData(9, 3, 3)]
    public async Task CalcularDivisaoAsync_QuandoReceberDoisValores_DeveRetornarResultadoEsperado(int numerador, int denominador, int esperado)
    {
        // Arrange
        _calculadoraFinanceiraMock
            .Setup(m => m.DividirAsync(numerador, denominador))
            .ReturnsAsync(esperado);

        // Act
        var resultado = await _calculadoraFinanceiraService.CalcularDivisaoAsync(numerador, denominador);

        // Assert
        Assert.Equal(esperado, resultado);

        _calculadoraFinanceiraMock
            .Verify(m => m.DividirAsync(numerador, denominador), Times.Once);
    }

    [Theory]
    [InlineData(3, false)]  // Ímpar
    [InlineData(4, true)]   // Par
    [InlineData(0, true)]   // Zero é par
    [InlineData(-2, true)]  // Negativo par
    public void VerificarSeEhPar_QuandoReceberUmNumero_DeveIdentificarCorretamente(int numero, bool esperado)
    {
        // Arrange
        _calculadoraFinanceiraMock
            .Setup(m => m.EhPar(numero))
            .Returns(esperado);

        // Act
        var resultado = _calculadoraFinanceiraService.VerificarSeEhPar(numero);

        // Assert
        Assert.Equal(esperado, resultado);

        _calculadoraFinanceiraMock
            .Verify(m => m.EhPar(It.IsAny<int>()), Times.Once);
    }

    [Theory]
    [InlineData(1000, 0.05, 2, 1102.50)]
    [InlineData(500, 0.10, 3, 665.50)]
    public void CalcularJurosCompostos_QuandoValoresValidos_DeveRetornarResultadoCorreto(decimal principal, decimal taxa, int periodo, decimal esperado)
    {
        // Arrange
        _calculadoraFinanceiraMock
            .Setup(m => m.CalcularJurosCompostos(principal, taxa, periodo))
            .Returns(esperado);

        // Act
        var resultado = _calculadoraFinanceiraService.CalcularJurosCompostos(principal, taxa, periodo);

        // Assert
        Assert.Equal(esperado, resultado);

        _calculadoraFinanceiraMock
            .Verify(m => m.CalcularJurosCompostos(
                It.IsAny<decimal>(),
                It.IsAny<decimal>(),
                It.IsAny<int>()), Times.Once);
    }

    [Theory]
    [InlineData(100, 5.25, 525)]
    [InlineData(200, 4.5, 900)]
    public void ConverterMoeda_QuandoValoresValidos_DeveRetornarValorConvertido(decimal valor, decimal taxaDeConversao, decimal esperado)
    {
        // Arrange
        _calculadoraFinanceiraMock
            .Setup(m => m.ConverterMoeda(valor, taxaDeConversao))
            .Returns(esperado);

        // Act
        var resultado = _calculadoraFinanceiraService.ConverterMoeda(valor, taxaDeConversao);

        // Assert
        Assert.Equal(esperado, resultado);

        _calculadoraFinanceiraMock
            .Verify(m => m.ConverterMoeda(
                It.IsAny<decimal>(),
                It.IsAny<decimal>()), Times.Once);
    }

    [Theory]
    [InlineData(200, 10, 180)]
    [InlineData(500, 20, 400)]
    public void CalcularDesconto_QuandoValoresValidos_DeveRetornarValorComDesconto(decimal valorOriginal, decimal percentualDesconto, decimal esperado)
    {
        // Arrange
        _calculadoraFinanceiraMock
            .Setup(m => m.CalcularDesconto(valorOriginal, percentualDesconto))
            .Returns(esperado);

        // Act
        var resultado = _calculadoraFinanceiraService.CalcularDesconto(valorOriginal, percentualDesconto);

        // Assert
        Assert.Equal(esperado, resultado);

        _calculadoraFinanceiraMock
           .Verify(m => m.CalcularDesconto(
               It.IsAny<decimal>(),
               It.IsAny<decimal>()), Times.Once);
    }
    #endregion
}
