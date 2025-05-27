
# Exemplos do Ciclo TDD (Red → Green → Refactor)

Este arquivo contém exemplos práticos aplicando o ciclo Red → Green → Refactor com C# e xUnit.

---

## 📌 Exemplo 1: Validação de CPF (formato simples)

### 🟥 Red
```csharp
[Fact]
public void DeveRetornarTrueParaCpfComFormatoValido()
{
    var validator = new CpfValidator();
    Assert.True(validator.IsValid("123.456.789-09"));
}
```

### 🟩 Green
```csharp
public bool IsValid(string cpf)
{
    return cpf == "123.456.789-09";
}
```

### ♻️ Refactor
```csharp
public bool IsValid(string cpf)
{
    return Regex.IsMatch(cpf, @"\d{3}\.\d{3}\.\d{3}-\d{2}");
}
```

---

## 🛒 Exemplo 2: Soma de itens no carrinho

### 🟥 Red
```csharp
[Fact]
public void SomaItens_DeveRetornar30QuandoDoisItensCom15ForemAdicionados()
{
    var carrinho = new Carrinho();
    carrinho.AdicionarItem(15);
    carrinho.AdicionarItem(15);

    Assert.Equal(30, carrinho.Total());
}
```

### 🟩 Green
```csharp
public class Carrinho
{
    private int total = 0;
    public void AdicionarItem(int valor) => total += valor;
    public int Total() => total;
}
```

### ♻️ Refactor
```csharp
public class Carrinho
{
    private readonly List<int> _itens = new();
    public void AdicionarItem(int valor) => _itens.Add(valor);
    public int Total() => _itens.Sum();
}
```

---

## 💰 Exemplo 3: Calculadora de desconto

### 🟥 Red
```csharp
[Fact]
public void CalcularDesconto_DeveAplicar10PorCentoParaValoresAcimaDe100()
{
    var calc = new CalculadoraDesconto();
    var valorComDesconto = calc.Calcular(150);

    Assert.Equal(135, valorComDesconto);
}
```

### 🟩 Green
```csharp
public decimal Calcular(decimal valor)
{
    return 135;
}
```

### ♻️ Refactor
```csharp
public decimal Calcular(decimal valor)
{
    return valor > 100 ? valor * 0.9m : valor;
}
```

---
