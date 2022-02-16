namespace PermutationStep;

// Have the function PermutationStep(int num) take
// the num parameter being passed and return the next
// number greater than num using the same digits.
// If num has no greater permutation, return -1.
public class PermutationStepChallenge
{

    public int PermutationStep(int num)
    {
        return GetPermutations(num)
            .OrderBy(p => p)
            .FirstOrDefault(
                predicate: p => p > num, 
                defaultValue: -1);
    }

    public IEnumerable<int> GetPermutations(int num)
    {
        var digits = GetDigits(num);
        var permutations = new HashSet<int>();
        Permute(permutations, digits, 0);
        return permutations;
    }

    public int[] GetDigits(int num)
    {
        var digits = new Stack<int>();
        while (num > 0)
        {
            digits.Push(num % 10);
            num /= 10;
        }
        return digits.ToArray();
    }

    private void Permute(HashSet<int> permutations, int[] nums, int fixedIndex)
    {
        if(fixedIndex < nums.Length - 1)
        {
            for (int i = fixedIndex + 1; i < nums.Length; i++)
            {
                var swappedNums = Swap(fixedIndex, i, nums);
                Permute(permutations, swappedNums, ++fixedIndex);
            }
        }
        else
        {
            permutations.Add(Join(nums));
        }
    }

    public int[] Swap(int i, int j, int[] digits)
    {
        if(i >= digits.Length || j >= digits.Length)
        {
            throw new IndexOutOfRangeException();
        }
        var changed = new int[digits.Length];
        Array.Copy(digits, changed, digits.Length);
        changed[i] = digits[j];
        changed[j] = digits[i];
        return changed;
    }

    public int Join(params int[] nums)
    {
        int joined = 0;
        foreach(var num in nums)
        {
            joined = 10 * joined + num;
        }
        return joined;
    }

}
