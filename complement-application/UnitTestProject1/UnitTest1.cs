using Static;

namespace UnitTestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void Test1()
    {
        var sum = 2 + 2;
        Assert.AreEqual(4, sum);
        // Assert.That(sum, Is.EqualTo(4));
    }
    
    [Test]
    public void TestGetPrettyPrintedNationalNumber()
    {
        // 11223345684 => 11.22.33-456.84
        Assert.AreEqual("11.22.33-456.84", DataFormatterStatic.GetPrettyPrintedNationalNumber("11223345684"));
    }
}