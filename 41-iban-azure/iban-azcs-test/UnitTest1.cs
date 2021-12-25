using HSW;
using Shouldly;
using Xunit;

namespace HSW.Tests;

public class TestKlazz
{
    [Fact]
    public void TestValid()
    {
        IbanUtil.Validate("DE75888888880000012345").ShouldBe(true);
    }

    [Fact]
    public void TestInvalid()
    {
        IbanUtil.Validate("DE76888888880000012345").ShouldBe(false);
    }
}