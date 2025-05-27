
# Desenvolvimento Guiado por Testes (TDD) com .NET e xUnit

Este documento complementa o conteúdo de testes unitários abordando o **Desenvolvimento Guiado por Testes (TDD)**, uma prática de desenvolvimento em que os testes são escritos **antes do código de produção**, com o objetivo de **guiar o design do software** de forma incremental e orientada a requisitos de comportamento.

---

## 🕰 Breve História e Motivação do TDD

O TDD foi formalizado por **Kent Beck** no início dos anos 2000 como parte da metodologia **Extreme Programming (XP)**, com o objetivo de melhorar a qualidade e confiabilidade do software.

Na época, muitos sistemas eram desenvolvidos com pouca testabilidade, alta complexidade e grande acoplamento. Isso tornava as alterações arriscadas, caras e difíceis de manter.

O TDD surgiu como uma resposta prática para:

- Garantir que o código fosse testável desde sua origem
- Evitar regressões silenciosas
- Guiar o design com foco em simplicidade, clareza e desacoplamento

### 🔍 Explicação desses pontos:

**Garantir que o código fosse testável desde sua origem**: antes do TDD, era comum escrever código difícil de isolar ou verificar. O TDD força o desenvolvedor a pensar desde o início em como organizar o código para que ele possa ser testado facilmente, o que geralmente implica melhor coesão e menor acoplamento.

**Evitar regressões silenciosas**: ao criar testes antes do código, o desenvolvedor estabelece contratos claros sobre o comportamento esperado. Qualquer modificação futura que quebrar esse comportamento será identificada imediatamente.

**Guiar o design com foco em simplicidade, clareza e desacoplamento**: o ciclo de TDD (Red → Green → Refactor) promove pequenas iterações com foco no que é necessário agora. Isso naturalmente leva a soluções mais enxutas, legíveis e desacopladas.

> “Testes não são apenas para verificar o código. Eles **guiam** o design do código.” – Kent Beck

---

## 🧪 O que é TDD?

O **TDD (Test-Driven Development)** é uma abordagem de desenvolvimento de software em que o desenvolvedor escreve primeiro o **teste que falha**, depois o **código mínimo para passar no teste**, e por fim **refatora** o código mantendo os testes funcionando.

Esse ciclo é conhecido como:

### 🔁 Red → Green → Refactor

1. **Red**: Criar um teste que falha (porque o código ainda não existe ou não está implementado corretamente).
2. **Green**: Escrever o código mínimo necessário para o teste passar.
3. **Refactor**: Melhorar o design e a legibilidade do código, sem alterar seu comportamento.

---

## ❌ Mitos e ✅ Verdades sobre TDD

| Mito                                 | Verdade                                                                                    |
| ------------------------------------ | ------------------------------------------------------------------------------------------ |
| TDD dobra o tempo de desenvolvimento | TDD exige tempo no início, mas reduz drasticamente o tempo gasto com bugs e retrabalho     |
| TDD é só escrever testes             | TDD é um **método de design orientado por testes**, não apenas verificação                 |
| TDD é para projetos grandes          | TDD funciona muito bem em **projetos pequenos e médios**, especialmente MVPs e bibliotecas |
| TDD impede criatividade              | TDD **foca a criatividade** no design e na clareza de código, não em gambiarras            |
| Testes escritos depois são iguais    | Escrever testes depois do código **não tem o mesmo efeito** no design e acoplamento        |

---

## ✅ Benefícios do TDD

- **Código mais confiável** e menos propenso a erros.
- **Design mais modular e limpo**, guiado por testes.
- **Maior cobertura de testes** desde o início do projeto.
- **Facilita refatorações futuras** com segurança.
- **Documentação executável** do comportamento esperado.

---

## 🛠 Exemplo de Ciclo TDD

Imagine que queremos implementar um método para verificar se um número é primo.

### 1. Escrevendo o teste (Red)

```csharp
[Fact]
public void EhPrimo_DeveRetornarTrueParaNumero7()
{
    var service = new NumeroService();
    Assert.True(service.EhPrimo(7));
}
```

### 2. Código mínimo (Green)

```csharp
public bool EhPrimo(int numero)
{
    return numero == 7;
}
```

### 3. Refatorando (Refactor)

```csharp
public bool EhPrimo(int numero)
{
    if (numero < 2) return false;
    for (int i = 2; i <= Math.Sqrt(numero); i++)
        if (numero % i == 0) return false;
    return true;
}
```

---

## 🧭 Dicas de Aplicação

- Comece com testes simples e evolua gradualmente.
- Evite implementar além do necessário no ciclo "Green".
- Mantenha os testes rápidos e confiáveis.
- Use nomes descritivos para facilitar a leitura.

---

## 📚 Leitura Complementar

- "Test-Driven Development by Example" – Kent Beck
- Documentação oficial do xUnit: [https://xunit.net](https://xunit.net)
- Artigo sobre TDD no .NET: [https://learn.microsoft.com/dotnet/core/testing/unit-testing-with-dotnet-test](https://learn.microsoft.com/dotnet/core/testing/unit-testing-with-dotnet-test)

---

## 💡 Desafio

Implemente uma classe `Pedido` com um método `CalcularValorTotal()` aplicando TDD. Inclua cenários com itens, descontos e impostos.

---
