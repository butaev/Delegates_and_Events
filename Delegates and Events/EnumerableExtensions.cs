namespace Delegates_and_Events;

using System;
using System.Collections.Generic;
using System.Linq;

public static class EnumerableExtensions
{
    public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
    {
        if (collection == null || !collection.Any())
            throw new ArgumentException("Коллекция не может быть пустой.");

        var items = collection as T[] ?? collection.ToArray();
        var maxItem = items[0];
        float maxNumber;
        try
        {
            maxNumber = convertToNumber(maxItem);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка конвертации: {e.Message}");
            throw;
        }

        foreach (var item in items)
        {
            var currentNumber = convertToNumber(item);
            if (currentNumber > maxNumber)
            {
                maxNumber = currentNumber;
                maxItem = item;
            }
        }

        return maxItem;
    }
}