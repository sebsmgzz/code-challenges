namespace CompressedRunLengthString;

using NUnit.Framework;

public class CompressedRunLengthStringTests
{

    private readonly CompressedRunLengthStringChallenge challenge = new ();

    [Test(ExpectedResult = "3w2g1o2p")]
    public string Test_wwwggopp() => challenge.StringChallenge("wwwggopp");

    [Test(ExpectedResult = "2a2b1c1d1e")]
    public string Test_aabbcde() => challenge.StringChallenge("aabbcde");

    [Test(ExpectedResult = "3w2b1w")]
    public string Test_wwwbbw() => challenge.StringChallenge("wwwbbw");

}
