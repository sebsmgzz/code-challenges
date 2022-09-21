namespace CompressedRunLengthString;

using System;

public class CompressedRunLengthStringChallenge
{

    public string StringChallenge(string str)
    {
        var output = String.Empty;
        var count = 0;
        char? current = null;
        var chars = str.ToCharArray();
        foreach (var c in chars)
        {
            if (c == current)
            {
                count++;
            }
            else
            {
                if (current != null)
                {
                    output += count.ToString() + current;
                }
                current = c;
                count = 1;
            }
        }
        output += count.ToString() + current;
        return output;
    }

}
