namespace ListLinq;

class Program
{
    static int Count = 0;
    static int Sum = 0;
    static int Avg = 0;
    static int Max = int.MinValue;
    static bool Over1000 = false;

    static void Main(string[] args)
    {
        var inputs = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 9001 };

        //ListImperative(inputs);
        ListFunctional(inputs);

        Console.WriteLine($"Count {Count} Sum {Sum} Avg {Avg} Max {Max} Over1000 {Over1000}");
    }

    static void ListImperative(List<int> list)
    {

        foreach (int item in list)
        {
            Count++;
            Sum += item;
            Avg = Sum / Count;
            if (item > Max)
            {
                Max = item;
            }
            if (item > 1000)
            {
                Over1000 = true;
            }
        }
    }

    static void ListFunctional(List<int> list)
    {
        Count = list.Count;
        Sum = list.Sum();
        Avg = Sum / Count;
        Max = list.Max();
        Over1000 = list.Any(x => x > 1000);

        // Weitere Beispiele: 
        // Anzahl der Werte >1000
        list.Count(x => x > 1000);
        // Summe der Werte >1000
        list.Where(x => x > 1000).Sum();
    }
}