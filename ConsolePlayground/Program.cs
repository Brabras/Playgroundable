Console.WriteLine(Solution.Euk(156, 48));

public class Solution
{
    public static int Euk(int m, int n)
    {
        decimal M = m;
        decimal N = n;
        while (true)
        {
            decimal r = M % N;
            if (r == 0)
                return Convert.ToInt32(N);
            M = n;
            N = r;
        }
    }
}