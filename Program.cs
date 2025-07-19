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

            Console.WriteLine("Одномерный целочисленный массив для проведения поиска:");
            int[] outputArray = new int[elements];
            int i = 0;
            while (i < elements)
            {
               outputArray[i] = sourceArray[i];
               Console.Write("{0} ", outputArray[i]);
               i++;
            }

            Console.WriteLine();


            double istart, mina;
            bool flag = false;

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



            //int index = SearchingLastSetValue(searchOne, value);
            //Console.WriteLine(index);
            //bool fl = SearchingLastValue(searchOne, value);
            //Console.WriteLine(fl);
            bool fl = CheckSetValue(sourceArray, value);
            Console.WriteLine(fl);

            //string[] arrayOne = LibraryFor1DArray.OutputStringArrayInt(replacingOne);
            string pathFileInput = Path.GetFullPath(nameFileInput);
            File.Create(pathFileInput).Close();
            //LibraryFor1DArray.FileWriteArrayString(arrayOne, nameFileTwo);
         }

         // Минимальный элемент массива среди отрицательных
         int min = sourceArray[0];
         for (int i = 1; i < sourceArray.Length; i++)
         {
            if (sourceArray[i] < 0)
            {
               if (sourceArray[i] < min)
               {
                  min = sourceArray[i];
               }
            }
         }
         Console.WriteLine("Минимальный элемент массива среди отрицательных: " + min);

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

         int x = 1, y = 2, a = 3, b = 4, sum = -1;
         Console.WriteLine("До вызова: x={0}; y ={1}; a ={2}; b ={3}; sum ={4}", x, y, a, b, sum);
         sum = Add(x, y, out a, out b);
         Console.WriteLine("После вызова: x={0}; y ={1}; a ={2}; b ={3}; sum ={4}", x, y, a, b, sum);

         Console.ReadKey();
      }

      // Выходные параметры, представленные значением
      public static int Add(int x, int y, out int a, out int b)
      {
         int sum = x + y;
         x = 10; y = 20; a = 30; b = 40;
         return sum;
      }

      public static bool CheckSetValue(int[] inputArray, int setValue)
      {
         // Прверка наличия элемента в массиве
         int i = 0;
         bool fl = true;
         while (i < inputArray.Length && fl)
         {
            if (inputArray[i] == setValue)
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
   }
}