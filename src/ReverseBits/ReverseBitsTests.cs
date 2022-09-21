namespace ReverseBits;

using NUnit.Framework;

public class ReverseBitsTests
{

    private readonly ReverseBitsChallenge challenge = new();

    [Test(ExpectedResult = "244")]
    public string Test_47() => challenge.StringChallenge("47");

    [Test(ExpectedResult = "?")] // TODO: Figure this out
    public string Test_4567() => challenge.StringChallenge("4567");

}
