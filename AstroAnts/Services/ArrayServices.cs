namespace AstroAnts.Services
{
    internal class ArrayServices
    {
        public static void InitializeArrayValue<T>(T[] arr, T val)
        {
            var arrLength = arr.Length;
            for (var i = 0; i < arrLength; i++)
                arr[i] = val;
        }
    }
}