using System;
using System.Collections.Generic;

namespace ReverseBits;

/* Have the function StringChallenge(str) take 
 * the str parameter being passed, which will be a 
 * psoitive integer, take its binary representation
 * (padded to the neares N * 8 bits), reverse taht
 * string of bits, and then finally return the new
 * reversed string in decimal form. 
 * For example:
 * If str is "47", then the binary version is 101111
 * but we pad it to be 0010111. Your program should 
 * reverse this binary string which then becomes:
 * 11110100 and then finally return the 
 * decimal version of this string, which is 244.
 */
public class ReverseBitsChallenge
{

    public string StringChallenge(string str)
    {
        var number = Convert.ToInt32(str);
        var bits = NumberToBits(number);
        bits.Reverse();
        return BitsToNumber(bits).ToString();
    }

    // Edge case (i.e. 4567) has more than 8bit
    // TODO: Fix edge case
    public List<int> NumberToBits(int number, int size = 8)
    {
        var remainders = new List<int>();
        for (int i = 0; i < size; i++)
        {
            //Console.Write(number + ",");
            var remainder = number % 2;
            remainders.Add((int)remainder);
            number /= 2;
            //Console.WriteLine(remainder);
        }
        remainders.Reverse();
        return remainders;
    }

    public int BitsToNumber(List<int> bits)
    {
        bits.Reverse();
        var sum = 0;
        for (int i = 0; i < bits.Count; i++)
        {
            sum += bits[i] * (int)Math.Pow(2, i);
        }
        return sum;
    }

}
