using System;
using System.Collections.Generic;
using RefactoringLab;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=".PadRight(60, '='));
        Console.WriteLine("    Обработка заказов интернет-магазина");
        Console.WriteLine("=".PadRight(60, '='));
        Console.WriteLine();

        // Создание списка заказов
        List<Order> orders = new List<Order>
        {
            new Order { Id = 1, ClientName = "Иван", Amount = 1200, IsRegular = true, ItemsCount = 3, DeliveryType = 1 },
            new Order { Id = 2, ClientName = "Анна", Amount = 400, IsRegular = false, ItemsCount = 1, DeliveryType = 2 },
            new Order { Id = 3, ClientName = "Олег", Amount = 2500, IsRegular = true, ItemsCount = 5, DeliveryType = 1 },
            new Order { Id = 4, ClientName = "Мария", Amount = 700, IsRegular = false, ItemsCount = 2, DeliveryType = 3 }
        };

        // Обработка заказов
        OrderService orderService = new OrderService();
        double total = orderService.ProcessOrders(orders);

        Console.WriteLine($"Общая сумма всех заказов: {total:F2}");
        Console.WriteLine();

        // Подсчёт суммы чётных чисел
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int sumEven = orderService.SumEvenNumbers(numbers);
        Console.WriteLine($"Сумма четных чисел: {sumEven}");

        Console.WriteLine();
        Console.WriteLine("=".PadRight(60, '='));
        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}