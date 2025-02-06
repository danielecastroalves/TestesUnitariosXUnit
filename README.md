# Testes Unitários em .Net com xUnit, Moq e NSubstitute

Este repositório contém exemplos práticos de **Testes Unitários** utilizando o framework **xUnit** no .NET, além das bibliotecas **Moq** e **NSubstitute** para **mocking** de dependências.

## 📌 O que são Testes Unitários?

Os **testes unitários** são pequenos testes automatizados que verificam o comportamento de **unidades isoladas** de código, como funções, métodos ou classes. 

Eles são escritos pelos desenvolvedores para garantir que cada parte do código funcione conforme esperado.

### **📌 Características principais:**
- **Isolados:** Não dependem de banco de dados, APIs ou outras partes do sistema.
- **Reprodutíveis:** Sempre geram os mesmos resultados sob as mesmas condições.
- **Rápidos:** Podem ser executados constantemente durante o desenvolvimento.

## 🚀 Benefícios dos Testes Unitários

✅ **Aumentam a confiança no código:** Permitem identificar e corrigir erros antes da integração com outras partes do sistema.

✅ **Previnem falhas em produção:** Diminuem a probabilidade de bugs em funcionalidades críticas.

✅ **Facilitam a refatoração:** Garantem que as alterações não quebrem funcionalidades existentes.

✅ **Funcionam como documentação viva:** Servem como exemplos claros do uso esperado do código.

✅ **Aprimoram a colaboração:** Ajudam outros desenvolvedores a entender e testar o sistema facilmente.

## 🏗 Testes no Ciclo de Desenvolvimento

Os testes unitários são fundamentais em práticas como **TDD (Test-Driven Development)**, onde os testes são escritos **antes do código**.

Além disso, eles fazem parte da **CI/CD (Continuous Integration / Continuous Delivery)**, permitindo que cada nova alteração seja validada automaticamente antes da implantação.

## 🔹 Outros tipos de Testes

🔹 **Testes de Integração**: Verificam a comunicação entre diferentes partes do sistema.

🔹 **Testes End-to-End (E2E)**: Simulam o fluxo completo de um usuário utilizando a aplicação.

## 🛠 O que testar?

✅ **Lógica de negócios**: Regras financeiras, cálculos, regras tributárias.

✅ **Regras de validação**: Certificar que os dados de entrada seguem os critérios esperados.

✅ **Fluxos críticos**: Garantir que funcionalidades essenciais não quebrem.

## 🔹 Características de um Bom Teste

🔹 **Independência:** Cada teste deve rodar de forma isolada.

🔹 **Clareza:** O nome do teste deve indicar exatamente o que ele verifica.

🔹 **Foco:** Um único teste deve validar apenas uma funcionalidade.

🔹 **Reprodutibilidade:** Deve sempre gerar o mesmo resultado para as mesmas entradas.

## 🔹 A Pirâmide de Testes

A pirâmide de testes divide os testes em três camadas:
- **Base (Testes Unitários):** Muitos testes, rápidos e isolados.
- **Meio (Testes de Integração):** Menos testes, verificam comunicação entre componentes.
- **Topo (Testes E2E):** Poucos testes, mais lentos, cobrem fluxos completos.

## 📌 Frameworks de Teste

Os frameworks de teste **automatizam** a execução dos testes, promovem **boas práticas** e **aumentam a produtividade**.

🔹 **.NET:** xUnit, NUnit, MSTest

🔹 **Java:** JUnit, TestNG

🔹 **JavaScript/TypeScript:** Jest, Mocha

🔹 **Python:** pytest, unittest

🔹 **C/C++:** Google Test (gTest), Catch2

🔹 **PHP:** PHPUnit

🔹 **Dart/Flutter:** test, Mockito

## 🔹 Introdução ao xUnit

O **xUnit** é um dos frameworks de testes mais modernos para .NET. Ele facilita a criação de testes eficazes e enxutos.

### **Características do xUnit:**
- Usa **[Fact]** para testes únicos.
- Usa **[Theory]** para testes parametrizados.
- Compatível com **CI/CD**.
- Suporte nativo para **injeção de dependências**.

## 🔍 Moq vs. NSubstitute: Comparação de Bibliotecas de Mocking
O **Moq** e o **NSubstitute** são duas das bibliotecas mais populares para criar **mocks** em testes unitários no .NET.
Ambas permitem a substituição de dependências externas para isolar a unidade de código em teste.

### 🔹 Moq
- **Baseado em expressões lambda:** Utiliza um estilo mais verboso, exigindo configurações explícitas para cada método mockado.
- **Maior controle sobre chamadas:** Permite configurar retornos diferentes para múltiplas chamadas do mesmo método.
- **Amplamente adotado na comunidade .NET:** Tem suporte consolidado e ampla documentação.

### 🔹 NSubstitute
- **Sintaxe mais fluida e concisa:** Usa um estilo mais intuitivo e fácil de ler.
- **Foca em legibilidade:** Reduz a quantidade de código repetitivo necessária para configurar mocks.
- **Menos configuração explícita:** Permite capturar argumentos e definir comportamentos de forma mais dinâmica.

| Característica | Moq | NSubstitute |
|---------------|-----|------------|
| Sintaxe       | Verbosa | Concisa |
| Estilo        | Orientado a configuração | Fluent |
| Flexibilidade | Maior controle | Mais natural |

## 🛠 Estrutura Básica dos Testes

A estrutura dos testes deve seguir o padrão **AAA (Arrange, Act, Assert)**:

```csharp
// Arrange: Configura o ambiente
var calculadora = new Calculadora();

// Act: Executa o método
var resultado = calculadora.Somar(2, 3);

// Assert: Verifica o resultado
Assert.Equal(5, resultado);
```

Os nomes dos testes devem seguir o formato:
**`MetodoEmTeste_CenarioASerTestado_ResultadoEsperado`**.

## 🛠 Configuração do Ambiente e Introdução Prática

1. Criar ou abrir um projeto de exemplo no .NET.
2. Configurar o **XUnit** no **Visual Studio** (via NuGet).
3. Estruturar o projeto de testes:
   - Criar um projeto separado.
   - Organizar namespaces.

### **Instalação do xUnit via NuGet:**
```sh
dotnet add package xunit
dotnet add package Moq
dotnet add package NSubstitute
```

### **Executando os Testes:**
```sh
dotnet test
```

## 📊 Cobertura de Código e Relatórios

A **cobertura de código** mede a quantidade de código que é efetivamente executada pelos testes unitários.
Uma alta cobertura não significa necessariamente testes de qualidade, mas ajuda a identificar trechos não testados.

### 🔹 Ferramentas para Cobertura de Código

- **Coverlet**: Ferramenta para gerar métricas de cobertura de código em testes unitários no .NET.
- **ReportGenerator**: Gera relatórios visuais a partir dos dados de cobertura.
- **Relatórios do Visual Studio**: Integração nativa para visualizar a cobertura.

## 🔹 Automação dos Testes em Pipelines CI/CD

Os testes devem ser integrados às **pipelines de CI/CD** para garantir qualidade antes da implantação.

✅ **Garante que os testes rodem automaticamente** a cada alteração.

✅ **Evita problemas antes da integração.**

✅ **Melhora a qualidade e segurança da aplicação.**

### 🚀 Integração com CI/CD
A integração com **CI/CD (Continuous Integration/Continuous Deployment)** permite a execução automatizada dos testes a cada nova alteração no código, garantindo que o sistema continue funcionando corretamente sem regressões.

### 🔹 Benefícios da Integração com CI/CD
✅ **Execução automática dos testes** a cada commit, pull request ou merge.

✅ **Rápida identificação de falhas** antes da entrega em produção.

✅ **Garante qualidade contínua** no código da aplicação.

✅ **Redução de retrabalho** ao evitar que código quebrado seja integrado.

### 🔹 Configuração da Pipeline
A integração pode ser feita utilizando ferramentas como:
- **GitHub Actions** para automação no GitHub.
- **Azure DevOps Pipelines** para execução em ambientes Azure.

## 🔗 Recursos e Links Úteis

- 📖 **Melhores práticas de Testes Unitários:** [Microsoft Docs](https://learn.microsoft.com/pt-br/dotnet/core/testing/unit-testing-best-practices)
- 📘 **Guia Oficial do xUnit:** [xUnit.net](https://xunit.net/)
- 🔍 **Código aberto do xUnit:** [GitHub xUnit](https://github.com/xunit/xunit)
- 📌 **Documentação do Moq:** [Moq Docs](https://documentation.help/Moq/)
- 📚 **Guia do NSubstitute:** [NSubstitute Docs](https://nsubstitute.github.io/help/getting-started/)
- 🏗 **Guia de TDD (Test-Driven Development):** [Martin Fowler](https://martinfowler.com/bliki/TestDrivenDevelopment.html)

---
📌 **Conecte-se comigo:** [LinkedIn](https://www.linkedin.com/in/danielegarciadecastroalves/)

🚀 **Bons testes!**
