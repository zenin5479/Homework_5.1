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

         int value = EnterSetValue();
         Console.WriteLine(value);
         int elementsOne = LibraryFor1DArray.NumberArrayElements();
         string pathOne = Path.GetFullPath(nameFileOne);
         int[] sourceOne = LibraryFor1DArray.EnterArrayInt(pathOne);
         if (sourceOne.Length == 0)
         {
            Console.WriteLine("Файл {0} пуст", nameFileOne);
         }
         else
         {
            int[] searchOne = LibraryFor1DArray.InputArrayInt(sourceOne, elementsOne);
            int maxOne = LibraryFor1DArray.FindMaxArrayInt(searchOne);
            int[] replacingOne = LibraryFor1DArray.ReplacingMaxInt(searchOne, maxOne);
            string[] arrayOne = LibraryFor1DArray.OutputStringArrayInt(replacingOne);
            string pathTwo = Path.GetFullPath(nameFileTwo);
            File.Create(pathTwo).Close();
            LibraryFor1DArray.FileWriteArrayString(arrayOne, nameFileTwo);
         }

         Console.ReadKey();
      }

      public static int EnterSetValue()
      {
         int v;
         do
         {
            Console.WriteLine("Введите значение элемента:");
            int.TryParse(Console.ReadLine(), out v);
            //v = Convert.ToInt32(Console.ReadLine());
            if (v <= -100 || v >= 100)
            {
               Console.WriteLine("Введено не верное значение");
            }
         } while (v <= -100 || v >= 100);

         return v;
      }

      public int SearchingSetValue(int[] inputArray, int setValue)
      {
         int i = 0;
         while (i < inputArray.Length)
         {
            // Сравниваем значения int используя метод CompareTo(Int) 
            if (inputArray[i].CompareTo(setValue) == 0)
            {
               Console.WriteLine("В массиве найден необходимый элемент {0} по индексу: {1}", setValue, i);
               return i;
            }

            // Сравниваем значения int используя оператор равенства ==
            if (inputArray[i] == setValue)
            {
               Console.WriteLine("В массиве найден необходимый элемент {0} по индексу: {1}", setValue, i);
               return i;
            }

            i++;
         }

         Console.WriteLine("В массиве отсутствует необходимый элемент: {0}", setValue);
         return -1;
      }
   }
}