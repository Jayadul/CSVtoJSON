using Application.services;
using Xunit;

namespace TestCase.Test;

public class UnitTest
{
    [Fact]
    public void SanakeCaseTransformationTest()
    {
        //arrange
        var expected = "Hello_World_!";

        //act
        var actual = Transformation.ToSankeCase("Hello World !");

        //assert 
        Assert.Equal(actual, expected);
    }
}