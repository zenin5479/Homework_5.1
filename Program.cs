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

         // Переводит (,) в (.)
         //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

         string nameOne = "A";
         int elementsOne = LibraryFor1DArray.NumberArrayElements(nameOne);

         string pathOne = Path.GetFullPath("a.txt");
         if (!File.Exists(pathOne))
         {
            Console.WriteLine("Ошибка при открытии файла для чтения. Файл не существует");
         }

         string pathTwo = Path.GetFullPath("b.txt");
         if (!File.Exists(pathTwo))
         {
            Console.WriteLine("Ошибка при открытии файла для чтения. Файл не существует");
         }

         string pathThree = Path.GetFullPath("c.txt");
         if (!File.Exists(pathThree))
         {
            Console.WriteLine("Ошибка при открытии файла для чтения. Файл не существует");
         }

         string pathFour = Path.GetFullPath("finish.txt");
         if (!File.Exists(pathFour))
         {
            Console.WriteLine("Ошибка при открытии файла для чтения. Файл не существует");
            File.Create(pathFour);
         }
         else
         {
            Console.WriteLine("Файл существует. Очищаем");
            // Очищаем содержимое файла
            // Вариант 1
            File.Create(pathFour).Close();
            // Вариант 2
            //File.WriteAllLines(pathFour, new string[0]);
            //File.WriteAllLines(pathFour, Array.Empty<string>());
            // Вариант 3
            //File.WriteAllText(pathFour, string.Empty);
            // Вариант 4
            //File.WriteAllBytes(pathFour, new byte[0]);
            //File.WriteAllBytes(pathFour, Array.Empty<byte>());
            // Вариант 5
            //FileStream fileStream = new FileStream(pathFour, FileMode.Truncate);
            //fileStream.Close();
            // Вариант 6
            //FileStream fileStream = new FileStream(pathFour, FileMode.Open);
            //fileStream.SetLength(0);
            //fileStream.Close();
         }

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

         double[] sourceTwo = LibraryFor1DArray.VvodArray(pathTwo, nameTwo);
         if (sourceTwo.Length == 0)
         {
            Console.WriteLine("Исходный строковый массив {0} пуст", nameTwo);
         }
         else
         {
            double[] searchTwo = LibraryFor1DArray.InputArray(sourceTwo, elementsTwo, nameTwo);
            double maxTwo = LibraryFor1DArray.FindMaxArray(searchTwo, nameTwo);
            double[] replacingTwo = LibraryFor1DArray.ReplacingMax(searchTwo, maxTwo);
            string[] arrayTwo = LibraryFor1DArray.VivodStringArray(replacingTwo);
            LibraryFor1DArray.FileAppendString(arrayTwo, pathFour);
         }

         double[] sourceThree = LibraryFor1DArray.VvodArray(pathThree, nameThree);
         if (sourceThree.Length == 0)
         {
            Console.WriteLine("Исходный строковый массив {0} пуст", nameThree);
         }
         else
         {
            double[] searchThree = LibraryFor1DArray.InputArray(sourceThree, elementsThree, nameThree);
            double maxThree = LibraryFor1DArray.FindMaxArray(searchThree, nameThree);
            double[] replacingThree = LibraryFor1DArray.ReplacingMax(searchThree, maxThree);
            string[] arrayThree = LibraryFor1DArray.VivodStringArray(replacingThree);
            LibraryFor1DArray.FileAppendString(arrayThree, pathFour);
         }

         Console.ReadKey();
      }
   }
}