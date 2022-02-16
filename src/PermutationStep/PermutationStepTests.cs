namespace PermutationStep;

using NUnit.Framework;

public class PermutationStepChallengeTests
{

    private readonly PermutationStepChallenge challenge = new();

    [Test(ExpectedResult = -1)]
    public int Test_42() => challenge.PermutationStep(42);

    [Test(ExpectedResult = 132)]
    public int Test_123() => challenge.PermutationStep(123);

    [Test(ExpectedResult = 12534)]
    public int Test_12453() => challenge.PermutationStep(12453);

    [Test(ExpectedResult = 41523)]
    public int Test_41352() => challenge.PermutationStep(41352);

    [Test(ExpectedResult = 11211)]
    public int Test_11121() => challenge.PermutationStep(11121);

    [Test(Description = "Number has no greater permutation.", ExpectedResult = -1)]
    public int Test_999() => challenge.PermutationStep(999);

}
