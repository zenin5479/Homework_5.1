using System;
using System.IO;

// Поиск экстремального элемента, удовлетворяющего нескольким условиям
// В данной задаче необходимо сначала найти номер элемента, удовлетворяющего одному условию,
// затем номер элемента, удовлетворяющего другому условию, и только затем искать между ними максимальный или минимальный элемент
// При поиске элементов, удовлетворяющих условию, необходимо использовать досрочный выход из цикла
// Ввод осуществляется из файла, вывод – в файл
// Задан целочисленный одномерный массив A из n элементов
// Найти номер первого максимального элемента среди отрицательных элементов, расположенных до последнего элемента, равного t
// Если нет равных t элементов, искать до конца массива

namespace Homework_5._1
{
   internal class Program
   {
      static void Main(string[] args)
      {
         // Обновить методы для int !!!
         // Написать перегрузки методов без названия массива (nameArray) +
         string nameFileOne = "a.txt";
         string nameFileTwo = "finish.txt";

         int elementsOne = LibraryFor1DArray.NumberArrayElements();
         string pathOne = Path.GetFullPath(nameFileOne);
         if (!File.Exists(pathOne))
         {
            Console.WriteLine("Ошибка при открытии файла для чтения. Файл не существует");
         }

         string pathFour = Path.GetFullPath(nameFileTwo);
         File.Create(pathFour).Close();

         int[] sourceOne = LibraryFor1DArray.EnterArrayInt(pathOne);
         if (sourceOne.Length == 0)
         {
            Console.WriteLine("Исходный строковый массив пуст");
         }
         else
         {
            int[] searchOne = LibraryFor1DArray.InputArrayInt(sourceOne, elementsOne);
            int maxOne = LibraryFor1DArray.FindMaxArrayInt(searchOne);
            int[] replacingOne = LibraryFor1DArray.ReplacingMaxInt(searchOne, maxOne);
            string[] arrayOne = LibraryFor1DArray.OutputStringArrayInt(replacingOne);
            LibraryFor1DArray.FileWriteArrayString(arrayOne, nameFileTwo);
         }

         Console.ReadKey();
      }
   }
}