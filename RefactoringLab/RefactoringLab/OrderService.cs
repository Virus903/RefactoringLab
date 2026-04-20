using System;
using System.Collections.Generic;

namespace RefactoringLab
{
    /// Сервис для обработки заказов
    public class OrderService
    {
        // Константы для расчёта скидки
        private const double HighAmountThreshold = 1000.0;
        private const double RegularClientHighDiscount = 0.10;  // 10%
        private const double RegularClientLowDiscount = 0.05;   // 5%
        private const double NewClientHighDiscount = 0.03;      // 3%
        private const double NewClientLowDiscount = 0.0;        // 0%

        // Константы для расчёта доставки
        private const double StandardDeliveryPrice = 300.0;
        private const double ExpressDeliveryPrice = 150.0;
        private const double PickupDeliveryPrice = 0.0;
        private const double DeliveryDiscountForManyItems = 50.0;
        private const int ManyItemsThreshold = 4;

        /// Рассчитывает скидку для заказа
        public double CalculateDiscount(Order order)
        {
            if (order.IsRegular)
            {
                // Постоянный клиент
                if (order.Amount > HighAmountThreshold)
                {
                    return order.Amount * RegularClientHighDiscount;
                }
                else
                {
                    return order.Amount * RegularClientLowDiscount;
                }
            }
            else
            {
                // Новый клиент
                if (order.Amount > HighAmountThreshold)
                {
                    return order.Amount * NewClientHighDiscount;
                }
                else
                {
                    return NewClientLowDiscount;
                }
            }
        }

        /// Рассчитывает стоимость доставки для заказа
        public double CalculateDeliveryPrice(Order order)
        {
            double deliveryPrice = order.DeliveryType switch
            {
                1 => StandardDeliveryPrice,  // Стандартная доставка
                2 => ExpressDeliveryPrice,   // Экспресс-доставка
                3 => PickupDeliveryPrice,    // Самовывоз
                _ => 0                       // Неизвестный тип
            };

            // Скидка на доставку при большом количестве товаров
            if (order.ItemsCount > ManyItemsThreshold)
            {
                deliveryPrice = Math.Max(0, deliveryPrice - DeliveryDiscountForManyItems);
            }

            return deliveryPrice;
        }

        /// Рассчитывает итоговую стоимость заказа
        public double CalculateFinalAmount(Order order)
        {
            double discount = CalculateDiscount(order);
            double delivery = CalculateDeliveryPrice(order);
            return order.Amount - discount + delivery;
        }

        /// Выводит информацию о заказе
        public void PrintOrderInfo(Order order)
        {
            double discount = CalculateDiscount(order);
            double delivery = CalculateDeliveryPrice(order);
            double finalAmount = order.Amount - discount + delivery;

            Console.WriteLine($"Заказ №{order.Id}");
            Console.WriteLine($"Клиент: {order.ClientName}");
            Console.WriteLine($"Сумма заказа: {order.Amount}");
            Console.WriteLine($"Скидка: {discount:F2}");
            Console.WriteLine($"Доставка: {delivery:F2}");
            Console.WriteLine($"Итог: {finalAmount:F2}");
            Console.WriteLine("----------------------------");
        }

        /// Обрабатывает список заказов и возвращает общую сумму
        public double ProcessOrders(List<Order> orders)
        {
            double total = 0;

            foreach (var order in orders)
            {
                PrintOrderInfo(order);
                total += CalculateFinalAmount(order);
            }

            return total;
        }

        /// Вычисляет сумму чётных чисел в списке
        public int SumEvenNumbers(List<int> numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    sum += number;
                }
            }
            return sum;
        }
    }
}