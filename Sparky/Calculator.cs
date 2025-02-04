namespace Sparky
{
    public class Calculator
    {
        public List<int> numbers = new List<int>();
        public int Add(int a, int b)
        {
            return a+b;
        }
        public bool IsOdd(int n)
        {
            if(n%2!=0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public double AddDoubles(double a, double b)
        {
            return a+b;
        }
        public List<int> GetOddRange(int min, int max)
        {
            numbers.Clear();
            for(int i=min;i<=max;i++)
            {
                if(i%2!=0)
                {
                    numbers.Add(i);
                }
            }
            return numbers;
        }
    }
}
