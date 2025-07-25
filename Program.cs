﻿using System;
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
         bool flag = false;
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
         string pathFileInput = Path.GetFullPath(nameFileInput);
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

            Console.WriteLine("Одномерный целочисленный массив:");
            int[] outputArray = new int[elements];
            int l = 0;
            while (l < elements)
            {
               outputArray[l] = sourceArray[l];
               Console.Write("{0} ", outputArray[l]);
               l++;
            }

            Console.WriteLine();
            File.Create(pathFileInput).Close();

            int istart = outputArray[0];
            int j = outputArray.Length - 1;
            while (j > -1 && flag == false)
            {
               if (outputArray[j] == value)
               {
                  flag = true;
               }
               else
               {
                  j--;
               }
            }

            if (flag)
            {
               istart = j;
               Console.WriteLine("Номер элемента равный {0}: {1}", value, istart);
            }

            if (flag == false)
            {
               Console.WriteLine("Числа равного {0} нет", value);
               istart = outputArray.Length - 1;
            }

            int min = outputArray[0];
            int k = 0;
            while (k < istart)
            {
               if (outputArray[k] < min)
               {
                  min = outputArray[k];
               }

               k++;
            }

            if (min > 0)
            {
               flag = false;
               string lines = "Отрицательных элементов нет";
               Console.WriteLine(lines);
               // Создание одномерного массива строк string[] для записи в файл строки
               string[] arrayString = { lines };
               File.WriteAllLines(pathFileInput, arrayString);
            }
            else
            {
               flag = true;
            }

            int max = min;
            l = 0;
            while (l < istart && flag)
            {
               if (outputArray[l] < 0)
               {
                  if (outputArray[l] > max)
                  {
                     max = outputArray[l];
                  }
               }

               l++;
            }

            if (flag)
            {
               string line = "Максимум: " + max;
               Console.WriteLine(line);
               // Создание одномерного массива строк string[] для записи в файл строки
               string[] stringArray = { line };
               // Запись массива строк в файл
               File.WriteAllLines(pathFileInput, stringArray);
            }
         }

         Console.ReadKey();
      }
   }
}