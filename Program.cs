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
         string nameFileOne = "a.txt";
         string nameFileTwo = "finish.txt";

         int rowOne = LibraryFor1DArray.SizeRow();
         int columnOne = LibraryFor1DArray.SizeColumn();
         int multipleElement = LibraryFor1DArray.MultipleElement();

         string pathOne = Path.GetFullPath(nameFileOne);
         int[,] sourceOne = LibraryFor1DArray.EnterArrayInt(pathOne, nameFileOne);
         if (sourceOne.GetLength(0) == 0)
         {
            Console.WriteLine("Файл {0} пуст", nameFileOne);
         }
         else
         {
            int[,] inputArray = LibraryFor1DArray.InputArrayInt(sourceOne, rowOne, columnOne);
            string pathTwo = Path.GetFullPath(nameFileTwo);
            File.Create(pathTwo).Close();
            LibraryFor1DArray.SplittingLines(inputArray, multipleElement, nameFileTwo);
         }

         Console.ReadKey();
      }
   }
}