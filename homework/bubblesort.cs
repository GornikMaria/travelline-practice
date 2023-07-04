int[] arr = { 5, 2, 10, 1, 13 };
Console.WriteLine("Массив до сортировки:");
PrintArray(arr);

int n = arr.Length;
bool swapped;
for (int i = 0; i < n - 1; i++)
{
    swapped = false;
    for (int j = 0; j < n - i - 1; j++)
    {
        if (arr[j] > arr[j + 1])
        {
            int temp = arr[j];
            arr[j] = arr[j + 1];
            arr[j + 1] = temp;
            swapped = true;
        }
    }
    if (!swapped)
        break;
}

Console.WriteLine("Массив после сортировки:");
PrintArray(arr);

void PrintArray(int[] arr)
{
    foreach (int element in arr)
    {
        Console.Write(element + " ");
    }
    Console.WriteLine();
}
