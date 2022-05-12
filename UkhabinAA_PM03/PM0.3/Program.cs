using System;
using System.IO;
using System.Text;

public class Smartphone : IComparable
{
    public string brand;
    public string model;
    public int price;

    public Smartphone(string brand, string model, int price) // Тип для хранения данных о смартфоне (марка [brand], модель [model], цена [price])
    {
        this.brand = brand;
        this.model = model;
        this.price = price;
    }

    public string ToString() // Данные массива которые переводятся в текстовый файл
    {
        return string.Format("Марка: {0}  Производитель: {1} Цена: {2}", brand, model, price);
    }

    public int CompareTo(object obj) // Функция сравнения марка+цена
    {
        Smartphone compared = obj as Smartphone;
        if (compared != null)
        {
            int result = brand.CompareTo(compared.brand);
            if (result != 0)
            {
                return result;
            }
            return price.CompareTo(compared.price);
        }
        else
        {
            throw new Exception("Невозможно сравнить два объекта");
        }
    }

}

public class DeviceShop // Хранение массива, сортировки и вывода в файл. Работает с классом PrintToFile
{
    int cntPhones;
    public Smartphone[] Phones;

    public DeviceShop(int cntPhones)
    {
        this.cntPhones = cntPhones;
        Phones = new Smartphone[cntPhones];
    }

    public void Fill() // Функция диаологового заполнения
    {
        string brand;
        string model;
        int price;
        try
        {
            for (int i = 0; i < this.cntPhones; i++)
            {
                Console.WriteLine("[Смартфон № " + (i+1) + "]");
                Console.WriteLine("Введите марку телефона:");
                brand = Console.ReadLine();
                Console.WriteLine("Введите модель телефона:");
                model = Console.ReadLine();
                Console.WriteLine("Введите стоимость телефона:");
                price = Convert.ToInt32(Console.ReadLine());
                this.Phones[i] = new Smartphone(brand, model, price);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Введенные данные некорректны");
            Console.WriteLine("Введите данные заново:");
            Fill();
        }
    }

    public void Sort() // Функция сортировки
    {
        Array.Sort(this.Phones);
    }

    public void PrintToFile() // Функция вывода в текстовый файл. Находится в Debug
    {
        using (StreamWriter file = new StreamWriter("result.txt", false, Encoding.UTF8))
        {
            foreach (Smartphone compared in this.Phones)
            {
                file.WriteLine(compared.ToString());
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            int cntPhones = 0;
            Console.WriteLine("Количество устройств:");
            cntPhones = Convert.ToInt32(Console.ReadLine());
            if (cntPhones < 1)
            {
                Environment.Exit(0);
            }
            else
            {
                DeviceShop DeviceShop = new DeviceShop(cntPhones);
                DeviceShop.Fill();
                DeviceShop.Sort();
                DeviceShop.PrintToFile();
            }
        }
        catch (Exception ex) // Повторение предыдущего кода
        {
            int cntPhones = 0;
            Console.WriteLine("Количество устройств:");
            cntPhones = Convert.ToInt32(Console.ReadLine());
            if (cntPhones < 1)
            {
                Environment.Exit(0);
            }
            else
            {
                DeviceShop DeviceShop = new DeviceShop(cntPhones);
                DeviceShop.Fill();
                DeviceShop.Sort();
                DeviceShop.PrintToFile();
            }
        }
    }
}