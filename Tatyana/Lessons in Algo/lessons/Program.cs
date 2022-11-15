// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine("Enter size of array");
var size = Convert.ToInt32(Console.ReadLine());
int[] newArray = new int[size];
Console.WriteLine(size);
for (int i = 0; i<size; i++) 
{
    Console.WriteLine($"Enter {i} element of array");
    newArray[i] = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine();
for (int i = 0; i < size; i++)
{
    Console.Write($" {newArray[i]} ");
}
int index = 1, 
    indexMax = 0, 
    indexMin = 0, 
    min = newArray[0], 
    max = newArray[0];
while (index < size)
{
    if (newArray[index] > max)
    {
        max = newArray[index];
        indexMax = index;
        index++;
    }
    else if (newArray[index] < min)
    {
        min = newArray[index];
        indexMin = index;
        index++;
    }
    else index++;
}
Console.WriteLine($"index of min = {indexMin}; index of max = {indexMax}");
