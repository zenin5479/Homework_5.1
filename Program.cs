using System;
using System.IO;
using System.Runtime.InteropServices;

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
         //string nameFileTwo = "finish.txt";

         int value = EnterSetValue();
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
            //int index = SearchingSetValue(searchOne, value);
            //Console.WriteLine(index);
            bool fl = SearchingLastValue(searchOne, value);
            //Console.WriteLine(fl);
            //string[] arrayOne = LibraryFor1DArray.OutputStringArrayInt(replacingOne);
            //string pathTwo = Path.GetFullPath(nameFileTwo);
            //File.Create(pathTwo).Close();
            //LibraryFor1DArray.FileWriteArrayString(arrayOne, nameFileTwo);
         }

         Console.ReadKey();
      }

      // Написать метод для определнния наличия величины через флаг
      public static bool Check(int[] inputArray, int setValue)
      {
         int i = 0;
         bool fl = true;
         while (i < inputArray.Length && fl)
         {
            if (inputArray[i].Equals(setValue))
            {
               fl = false;
            }
            else
            {
               i++;
            }
         }
         return fl;
      }

      public static bool SearchingLastValue(int[] inputArray, int setValue)
      {
         // Поиск элемента строки (c флагом bool)

         // Вариант 1 обход массива с последнего элемента
         bool flag = true;
         int i = inputArray.Length - 1;
         while (i >= 0 && flag)
         {
            // Сравниваем значения int используя оператор равенства ==
            if (inputArray[i] == setValue)
            {
               Console.WriteLine("В массиве найден необходимый элемент {0} по индексу: {1}", setValue, i);
               flag = false;
            }

            // Сравниваем значения int используя метод CompareTo(Int) 
            //if (inputArray[i].CompareTo(setValue) == 0)
            //{
            //   Console.WriteLine("В массиве найден элемент {0} по индексу: {1}", setValue, i);
            //   flag = false;
            //}

            // Сравниваем значения int используя метод Equals(Int)
            //if (inputArray[i].Equals(setValue))
            //{
            //   Console.WriteLine("В массиве найден элемент {0} по индексу: {1}", setValue, i);
            //   flag = false;
            //}

            //Console.Write("{0} ", inputArray[i]);
            i--;
         }

         Console.WriteLine();
         int n = inputArray.Length;
         while (n > 0)
         {
            n--;
            Console.Write("{0} ", inputArray[n]);

         }

         // Вариант 2 обход массива с последнего элемента
         //bool flag = true;
         //int i = inputArray.Length;
         //while (i > 0 && flag)
         //{
         //   i--;
         //   // Сравниваем значения int используя метод CompareTo(Int) 
         //   if (inputArray[i].CompareTo(setValue) == 0)
         //   {
         //      Console.WriteLine("В массиве найден элемент {0} по индексу: {1}", setValue, i);
         //      flag = false;
         //   }

         //   // Сравниваем значения int используя метод Equals(Int)
         //   //if (inputArray[i].Equals(setValue))
         //   //{
         //   //   Console.WriteLine("В массиве найден элемент {0} по индексу: {1}", setValue, i);
         //   //   flag = false;
         //   //}

         //   // Сравниваем значения int используя оператор равенства ==
         //   //if (inputArray[i] == setValue)
         //   //{
         //   //   Console.WriteLine("В массиве найден необходимый элемент {0} по индексу: {1}", setValue, i);
         //   //   flag = false;
         //   //}

         //   Console.Write("{0} ", inputArray[i]);
         //}

         Console.WriteLine();
         if (flag)
         {
            Console.WriteLine("В массиве отсутствует элемент: {0}", setValue);
         }

         return flag;
      }

      public static int SearchingSetValue(int[] inputArray, int setValue)
      {
         int i = 0;
         while (i < inputArray.Length)
         {
            // Сравниваем значения int используя метод CompareTo(Int) 
            if (inputArray[i].CompareTo(setValue) == 0)
            {
               Console.WriteLine("В массиве найден элемент {0} по индексу: {1}", setValue, i);
               return i;
            }

            // Сравниваем значения int используя оператор равенства ==
            //if (inputArray[i] == setValue)
            //{
            //   Console.WriteLine("В массиве найден необходимый элемент {0} по индексу: {1}", setValue, i);
            //   return i;
            //}

            i++;
         }

         Console.WriteLine("В массиве отсутствует элемент: {0}", setValue);
         return -1;
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
   }
}