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
            //int index = SearchingLastSetValue(searchOne, value);
            //Console.WriteLine(index);
            bool fl = SearchingLastValue(searchOne, value);
            Console.WriteLine(fl);
            //string[] arrayOne = LibraryFor1DArray.OutputStringArrayInt(replacingOne);
            //string pathTwo = Path.GetFullPath(nameFileTwo);
            //File.Create(pathTwo).Close();
            //LibraryFor1DArray.FileWriteArrayString(arrayOne, nameFileTwo);

            int max = 0;
            for (int i = 1; i < searchOne.Length; i++)
            {
               if (searchOne[i] < 0 && searchOne[i] > max)
               {
                  max = searchOne[i];
               }
            }

            Console.WriteLine("Максимальное среди отрицательных: " + max);
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
         // Поиск элемента строки (c флагом bool) обход массива с последнего элемента
         bool flag = true;
         int i = inputArray.Length - 1;
         while (i >= 0 && flag)
         {
            // Сравниваем значения int используя оператор равенства ==
            if (inputArray[i] == setValue)
            {
               Console.WriteLine("В массиве найден элемент {0} по индексу: {1}", setValue, i);
               flag = false;
            }

            i--;
         }

         if (flag)
         {
            Console.WriteLine("В массиве отсутствует элемент: {0}", setValue);
         }

         return flag;
      }

      public static int SearchingLastSetValue(int[] inputArray, int setValue)
      {
         // Поиск элемента строки обход массива с последнего элемента
         int i = inputArray.Length - 1;
         while (i >= 0)
         {
            // Сравниваем значения int используя оператор равенства ==
            if (inputArray[i] == setValue)
            {
               Console.WriteLine("В массиве найден элемент {0} по индексу: {1}", setValue, i);
               return i;
            }

            i--;
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

      //   setlocale(LC_ALL, "Russian");
      //   int t;
      //   double istart, mina;
      //   bool fl = false;
      //   printf("Введите величину t\n");
      //   scanf("%d", &t);
      //   double* a;
      //   int n;
      //      do
      //   {
      //      printf("Введите количество элементов массива А\n");
      //      scanf("%d", &n);
      //      if (n <= 0 || n >= 20)
      //      {
      //         printf("Введено неверное значение\n");
      //      }
      //   } while (n <= 0 || n >= 20) ;
      //a = new double[n];
      //printf("Задайте элементы массива А\n");
      //for (int i = 0; i < n; i++)
      //   scanf("%lf", &a[i]);
      //printf("Массив: ");
      //for (int i = 0; i < n; i++)
      //   printf("%lf ", a[i]);
      //istart = a[0];
      //int i = n - 1;
      //while (i > -1 and fl == false)
      //{
      //   if (a[i] == t)
      //   {
      //      fl = true;
      //   }
      //   else
      //   {
      //      i = i - 1;
      //   }
      //}

      //if (fl == true)
      //{
      //   istart = i;
      //   printf("\nНомер элемента равный t: %f", istart);
      //}
      //if (fl == false)
      //{
      //   printf("\nЧисла равного t нет\n");
      //   istart = n - 1; // зачем уменьшаем число элементов????
      //   //istart = n;
      //}
      //mina = a[0];
      //for (int k = 0; k < n; k++)
      //{
      //   if (a[k] < mina)
      //   {
      //      mina = a[k];
      //   }
      //}
      //if (mina > 0)
      //{
      //   fl = false;
      //   printf("Отрицательных элементов нет\n");
      //}
      //else
      //{
      //   fl = true;
      //}
      //i = 0;
      //while (i < istart and fl == true)
      //{
      //   if (a[i] < 0)
      //   {
      //      if (a[i] > mina)
      //      {
      //         mina = a[i];
      //      }
      //   }
      //   i++;
      //}
      //if (fl == true)
      //{
      //   printf("\nМаксимум %f \n", mina);
      //}
      //delete[] a;
      //return 0;
   }
}