using NewTalents;

namespace NewTalentsTests;

public class UnitTest1
{     

    public Calculadora construirClasse()
    {
        string data = "27/09/2024";
        Calculadora calc = new Calculadora(data);
        return calc;
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(4, 5, 9)]
    public void TesteSomar(int num1, int num2, int resultado)
    {   
        Calculadora calc = construirClasse();
        int resultadoCalculadora = calc.Somar(num1,num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(1, 2, -1)]
    [InlineData(4, 5, -1)]
    public void TesteSubtrair(int num1, int num2, int resultado)
    {   
        Calculadora calc = construirClasse();
        int resultadoCalculadora = calc.Subtrair(num1,num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(1, 2, 2)]
    [InlineData(4, 5, 20)]
    public void TesteMultiplicar(int num1, int num2, int resultado)
    {   
        Calculadora calc = construirClasse();
        int resultadoCalculadora = calc.Multiplicar(num1,num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(6, 2, 3)]
    [InlineData(45, 5, 9)]
    public void TesteDividir(int num1, int num2, int resultado)
    {   
        Calculadora calc = construirClasse();
        int resultadoCalculadora = calc.Dividir(num1,num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Fact]
    public void TestarDivisaoPorZero()
    {   
        Calculadora calc = construirClasse();
        Assert.Throws<DivideByZeroException>(
            () => calc.Dividir(3, 0)
        );
    }

    [Fact]
    public void TestarHistorico()
    {   
        Calculadora calc = construirClasse();

        calc.Somar(5, 2);
        calc.Somar(4, 3);
        calc.Somar(3, 4);
        calc.Somar(2, 5);

        var lista = calc.Historico();

        Assert.NotEmpty(lista);
        Assert.Equal(3, lista.Count);
    }
}