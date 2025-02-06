# Testes Unitários com .NET e XUnit

## Introdução e Contextualização

### O que são testes unitários?
Testes unitários são testes automatizados que verificam o funcionamento de pequenas partes do código (unidades), geralmente funções ou métodos.

### Benefícios:
- Maior confiança no código.
- Prevenção de erros em produção.
- Suporte à refatoração sem medo de quebrar funcionalidades.

### Contexto no ciclo de desenvolvimento:
- Utilizados dentro de metodologias **Agile** e **CI/CD**.
- Complementam testes de integração e end-to-end.

## Fundamentos Teóricos

### O que testar?
- Lógica de negócios.
- Regras de validação.
- Fluxos críticos do sistema.

### Características de um bom teste:
- **Independência:** Não deve depender de outros testes.
- **Clareza:** O que está sendo testado deve ser evidente.
- **Responsabilidade única:** Um teste = um comportamento validado.

### Pirâmide de Testes:
- Base sólida de testes unitários.
- Testes de integração e end-to-end no topo.

### Frameworks de Teste
- O **XUnit** é um dos mais populares para .NET.
- Ele permite automação e facilita a integração com pipelines CI/CD.

## Configuração do Ambiente e Introdução Prática

1. Criar ou abrir um projeto de exemplo no .NET.
2. Configurar o **XUnit** no **Visual Studio** (via NuGet).
3. Estruturar o projeto de testes:
   - Criar um projeto separado.
   - Organizar namespaces.

## Parte Prática: Escrevendo Testes com XUnit

### Criando o primeiro teste
```csharp
public class CalculadoraTests
{
    [Fact]
    public void Somar_DeveRetornarResultadoCorreto()
    {
        var calculadora = new Calculadora();
        var resultado = calculadora.Somar(2, 3);
        Assert.Equal(5, resultado);
    }
}
```

### Testes parametrizados com [Theory]
```csharp
public class CalculadoraTests
{
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(5, 5, 10)]
    [InlineData(-3, 3, 0)]
    public void Somar_DeveRetornarResultadoCorreto(int a, int b, int esperado)
    {
        var calculadora = new Calculadora();
        var resultado = calculadora.Somar(a, b);
        Assert.Equal(esperado, resultado);
    }
}
```

### Testando exceções com Assert.Throws
```csharp
[Fact]
public void Dividir_DeveLancarExcecao_QuandoDivisorForZero()
{
    var calculadora = new Calculadora();
    Assert.Throws<DivideByZeroException>(() => calculadora.Dividir(10, 0));
}
```

### Mocking com Moq e NSubstitute
#### Usando Moq
```csharp
var servicoMock = new Mock<IServico>();
servicoMock.Setup(s => s.ObterValor()).Returns(10);
```

#### Usando NSubstitute
```csharp
var servicoMock = Substitute.For<IServico>();
servicoMock.ObterValor().Returns(10);
```

## Cobertura de Código e Automação

### Cobertura de Código
Ferramentas:
- **Coverlet** para medir cobertura.
- **Relatórios no Visual Studio.**

### Integração com CI/CD
- Configuração no **GitHub Actions** ou **Azure DevOps**.
- Execução automática dos testes em cada commit.

## Comparando Moq e NSubstitute
| Característica | Moq | NSubstitute |
|---------------|-----|------------|
| Sintaxe       | Verbosa | Concisa |
| Estilo        | Orientado a configuração | Fluent |
| Flexibilidade | Maior controle | Mais natural |

### Exemplos de SetupSequence
#### Usando Moq
```csharp
var mock = new Mock<IServico>();
mock.SetupSequence(s => s.ObterValor())
    .Returns(10)
    .Returns(20);
```

#### Usando NSubstitute
```csharp
var mock = Substitute.For<IServico>();
mock.ObterValor().Returns(10, 20);
```

## Frameworks de Testes para Outras Linguagens
| Linguagem  | Frameworks |
|------------|------------|
| Java       | JUnit, TestNG |
| JavaScript | Jest, Mocha |
| Python     | pytest, unittest |
| C/C++      | Google Test, Catch2 |
| PHP        | PHPUnit |
| Ruby       | RSpec |
| Go         | testing, Testify |
| Swift      | XCTest |
| Kotlin     | Kotest, JUnit |
| Dart       | test, Mockito |

---




