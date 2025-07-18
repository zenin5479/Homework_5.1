using System;
using System.IO;
using System.Text;

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
         int value, elements;
         string nameFileEnter = "a.txt";
         string nameFileInput = "finish.txt";
         do
         {
            Console.WriteLine("Введите значение элемента:");
            int.TryParse(Console.ReadLine(), out value);
            //value = Convert.ToInt32(Console.ReadLine());
            if (value <= -100 || value >= 100)
            {
               Console.WriteLine("Введено не верное значение");
            }
         } while (value <= -100 || value >= 100);
         do
         {
            Console.WriteLine("Введите количество элементов массива:");
            //int.TryParse(Console.ReadLine(), out elements);
            elements = Convert.ToInt32(Console.ReadLine());
            if (elements <= 0 || elements > 20)
            {
               Console.WriteLine("Введено не верное значение");
            }
         } while (elements <= 0 || elements > 20);
         string pathFileEnter = Path.GetFullPath(nameFileEnter);
         string stroka = null;
         int[] sourceArray = { };
         FileStream filestream = File.Open(pathFileEnter, FileMode.Open, FileAccess.Read);
         if (filestream == null || filestream.Length == 0)
         {
            Console.WriteLine("Ошибка при открытии файла для чтения");
         }
         else
         {
            StreamReader streamReader = new StreamReader(filestream);
            while (streamReader.Peek() >= 0)
            {
               stroka = streamReader.ReadLine();
            }
            char symbolSpace = ' ';
            int symbolСount = 0;
            int сolumn = 0;
            if (stroka != null)
            {
               while (symbolСount < stroka.Length)
               {
                  if (symbolSpace == stroka[symbolСount])
                  {
                     сolumn++;
                  }

                  if (symbolСount == stroka.Length - 1)
                  {
                     сolumn++;
                  }

                  symbolСount++;
               }

               sourceArray = new int[сolumn];
               StringBuilder stringModified = new StringBuilder();
               symbolСount = 0;
               сolumn = 0;
               while (symbolСount < stroka.Length)
               {
                  if (symbolSpace != stroka[symbolСount])
                  {
                     stringModified.Append(stroka[symbolСount]);
                  }
                  else
                  {
                     string subLine = stringModified.ToString();
                     sourceArray[сolumn] = Convert.ToInt32(subLine);
                     stringModified.Clear();
                     сolumn++;
                  }

                  if (symbolСount == stroka.Length - 1)
                  {
                     string subLine = stringModified.ToString();
                     sourceArray[сolumn] = Convert.ToInt32(subLine);
                     stringModified.Clear();
                     сolumn++;
                  }

                  symbolСount++;
               }
            }
            streamReader.Close();

            if (sourceArray.Length == 0)
            {
               Console.WriteLine("Файл {0} пуст", nameFileEnter);
            }
            else
            {
               int[] searchOne = LibraryFor1DArray.InputArrayInt(sourceArray, elements);
               //int index = SearchingLastSetValue(searchOne, value);
               //Console.WriteLine(index);
               //bool fl = SearchingLastValue(searchOne, value);
               //Console.WriteLine(fl);
               bool fl = Check(sourceArray, value);
               Console.WriteLine(fl);

               //string[] arrayOne = LibraryFor1DArray.OutputStringArrayInt(replacingOne);
               //string pathTwo = Path.GetFullPath(nameFileTwo);
               //File.Create(pathTwo).Close();
               //LibraryFor1DArray.FileWriteArrayString(arrayOne, nameFileTwo);
            }

            // Минимальный элемент массива среди отрицательных
            int max = sourceArray[0];
            for (int i = 1; i < sourceArray.Length; i++)
            {
               if (sourceArray[i] < 0)
               {
                  if (sourceArray[i] < max)
                  {
                     max = sourceArray[i];
                  }
               }
            }

            Console.WriteLine("Минимальный элемент массива среди отрицательных: " + max);

            // Поиск максимального и минимального элемента строки
            // Cчитаем, что максимум - это первый элемент строки
            double maxOne = sourceArray[0];
            // Cчитаем, что минимум - это первый элемент строки
            double minOne = sourceArray[0];
            int column = 0;
            while (column < sourceArray.Length)
            {
               if (maxOne < sourceArray[column])
               {
                  maxOne = sourceArray[column];
               }

               if (minOne > sourceArray[column])
               {
                  minOne = sourceArray[column];
               }

               column++;
            }
            Console.WriteLine("Максимум равен: {0}", maxOne);
            Console.WriteLine("Минимум равен: {0}", minOne);

            Console.ReadKey();
         }
      }

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

      public static bool Check(int[] inputArray, int setValue)
      {
         //int i = 0;
         //bool fl = true;
         //while (i < inputArray.Length && fl)
         //{
         //   if (inputArray[i] == setValue)
         //   {
         //      fl = false;
         //   }
         //   else
         //   {
         //      i++;
         //   }
         //}
         //return fl;

         int i = 0;
         bool fl = true;
         while (i < inputArray.Length && fl)
         {
            if (inputArray[i] < setValue)
            {
               i++;
            }
            else
            {
               fl = false;
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
   }
}