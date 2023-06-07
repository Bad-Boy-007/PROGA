using System.Collections;

void display(List<string> arrList, string name)
{
    Console.Write(name + ":");
    foreach (var x in arrList)
    {
        Console.Write("\t{0}", x);
    }
    Console.WriteLine();
}


var list = new List<string>();
while (true)
{
    Console.WriteLine("Меню.\n");
    Console.WriteLine(
        "1. Add\n" +
        "2. AddRange\n" +
        "3. Insert\n" +
        "4. Remove\n" +
        "5. Remove At\n" +
        "6. Sort\n" +
        "7. Reverse\n" +
        "8. Get Range\n" +
        "9. Index of");

    string method = Console.ReadLine();

    if (method == "1")
    {
        Console.WriteLine("Введите элемент");
        list.Add(Console.ReadLine());
    }

    else if (method == "2")
    {
        Console.WriteLine("Введите элементы, которые хотите добавить в коллекцию (чтобы прекратить ввод - введите пустую строку)");
        var extraList = new List<string>();
        for (string x = Console.ReadLine(); x != ""; x = Console.ReadLine())
        {
            extraList.Add(x);
        }
        list.AddRange(extraList);
    }

    else if (method == "3")
    {
        Console.WriteLine("Укажите элемент");
        string element = Console.ReadLine();
        Console.WriteLine("Укажите позицию, на которую будет поставлен элемент");
        int index = int.Parse(Console.ReadLine());

        if (index <= list.Count)
            list.Insert(index, element);
        else
            list.Add(element);

    }

    else if (method == "4")
    {
        Console.WriteLine("Укажите элемент");
        list.Remove(Console.ReadLine());
    }

    else if (method == "5")
    {
        Console.WriteLine("Укажите индекс");
        list.RemoveAt(int.Parse(Console.ReadLine()));
    }

    else if (method == "6")
    {
        list.Sort();
    }

    else if (method == "7")
    {
        list.Reverse();
    }

    else if (method == "8")
    {
        Console.WriteLine("Укажите индекс, с которого начинается копироварние");
        int index = int.Parse(Console.ReadLine());
        Console.WriteLine("Укажите кол-во элементов в диапазоне");
        int count = int.Parse(Console.ReadLine());

        var newList = list.GetRange(index, count);
        display(newList, "newList");
    }

    else if (method == "9")
    {
        Console.WriteLine("Укажите элемент");
        string item = Console.ReadLine();
        Console.WriteLine("Index: {0}", list.IndexOf(item));
    }

    else
    {
        Console.WriteLine("Что-то непонятное.");
    }

    display(list, "list");
    Console.WriteLine("Нажмите любую кнопку");
    Console.ReadKey();
    Console.Clear();
}
