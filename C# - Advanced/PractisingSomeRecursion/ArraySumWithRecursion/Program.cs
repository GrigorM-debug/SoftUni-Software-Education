namespace ArraySumWithRecursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = {1, 2, 3, 4, 5, 6};

            Console.WriteLine($"Sum of the Array: {Sum(array, 0)}");
        }

        static int Sum(int[] nums, int index)
        {
            if(index == nums.Length) // This is the "Bottom od recursion". 
            {
                return 0;
            }

            return nums[index] + Sum(nums, index + 1);
        }
    }
}