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

}