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
         // Обновить методы для int
         string nameOne = "A";
         int elementsOne = LibraryFor1DArray.NumberArrayElements(nameOne);

         string pathOne = Path.GetFullPath("a.txt");
         if (!File.Exists(pathOne))
         {
            Console.WriteLine("Ошибка при открытии файла для чтения. Файл не существует");
         }

         //string pathFour = Path.GetFullPath("finish.txt");
         //File.Create(pathFour).Close();

         double[] sourceOne = LibraryFor1DArray.VvodArray(pathOne, nameOne);
         if (sourceOne.Length == 0)
         {
            Console.WriteLine("Исходный строковый массив {0} пуст", nameOne);
         }
         else
         {
            double[] searchOne = LibraryFor1DArray.InputArray(sourceOne, elementsOne, nameOne);
            double maxOne = LibraryFor1DArray.FindMaxArray(searchOne, nameOne);
            double[] replacingOne = LibraryFor1DArray.ReplacingMax(searchOne, maxOne);
            string[] arrayOne = LibraryFor1DArray.VivodStringArray(replacingOne);
            LibraryFor1DArray.FileAppendString(arrayOne, pathFour);
         }

         Console.ReadKey();
      }
   }
}