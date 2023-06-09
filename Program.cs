﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Threading;
namespace RGR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Данил\source\repos\Алгосы\Алгосы\products.txt";

            while (true)
            {
                Console.WriteLine("Это программа-справочник калорийности пищевых продуктов и их совместимости!\nВыберете пункт меню:");
                Console.WriteLine("1. Узнать группу продукта и список совместимых с ним продуктов");
                Console.WriteLine("2. Узнать совместимость 2-х продуктов");
                Console.WriteLine("Для выхода из программы, нажмите любую другую цифру");
                int ans = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (ans == 1)
                {

                    Console.WriteLine("Введите название продукта");
                    string nesProd = Console.ReadLine().ToLower();
                    List<string> list = new List<string>();
                    string group = "";

                    using (StreamReader reader1 = new StreamReader(path))
                    {
                        int n = reader1.ReadToEnd().Split('\n').Length;
                        using (StreamReader reader2 = new StreamReader(path))
                        {
                            for (int i = 0; i < n; i++)
                            {
                                string s = reader2.ReadLine();

                                if (s.Contains('-'))
                                {
                                    group = s.Remove(0, 1);
                                }

                                string[] product = s.Split('\t');

                                if (product[0].ToLower() == nesProd.ToLower())
                                {
                                    using (StreamReader reader = new StreamReader(path))
                                    {
                                        for (int j = 0; j < n; j++)
                                        {
                                            string[] component = reader.ReadLine().Split('\t');

                                            if ((MaxEl(component) == 1 && MaxEl(product) == 3) || (MaxEl(component) == 3 && MaxEl(product) == 3))
                                            {
                                                continue;
                                            }

                                            else if ((MaxEl(product) == 2 && (MaxEl(component) == 1 || MaxEl(component) == 3)) || (MaxEl(component) == 2 && (MaxEl(product) == 1 || MaxEl(product) == 3)))
                                            {
                                                list.Add(component[0]);
                                            }
                                        }
                                    }

                                    break;
                                }
                            }
                        }

                        Console.WriteLine($"Продукт относится к группе {group}\n\nСочетается со следующими продуктами:");
                        foreach (string s in list)
                            Console.WriteLine(s);
                        Thread.Sleep(10000);
                        Console.Clear();
                    }

                }

                else if (ans == 2)
                {
                    Console.Write("Введите названия продуктов (через ', '): ");
                    string[] products = Console.ReadLine().Split(", ");
                    string product1 = products[0];
                    string product2 = products[1];


                    if ((SearchValProduct(path, product1) == 1 && SearchValProduct(path, product2) == 3) || (SearchValProduct(path, product1) == 3 && SearchValProduct(path, product2) == 1) || (SearchValProduct(path, product1) == SearchValProduct(path, product2)))
                    {
                        Console.WriteLine("Продукты несовместимы!");
                        
                    }

                    else if ((SearchValProduct(path, product1) == 2 && (SearchValProduct(path, product2) == 1 || SearchValProduct(path, product2) == 3)) || (SearchValProduct(path, product2) == 2 && (SearchValProduct(path, product1) == 1 || SearchValProduct(path, product1) == 3)))
                    {
                        Console.WriteLine("Продукты можно употреблять вместе!");
                    }
                    Thread.Sleep(3000);
                    Console.Clear();
                }

                else
                {
                    Console.Clear();
                    break;
                }
            }
        }

        // Поиск "доминирующего компонента в БЖУ"
        public static int MaxEl(string[] a)
        {
            double max = -1.0;
            int index = 0;
            for (int i = 1; i < a.Length - 1; i++)
            {
                if (max < Convert.ToDouble(a[i].ToString()))
                {
                    max = Convert.ToDouble(a[i]);
                    index = i;
                }
            }
            return index;

        }

        // Поиск продукта в файле и возврат его "доминирующего компонента в БЖУ"
        public static int SearchValProduct(string path, string product)
        {
            int index = 0;
            using (StreamReader reader1 = new StreamReader(path))
            {
                int n = reader1.ReadToEnd().Split('\n').Length;
                using (StreamReader reader2 = new StreamReader(path))
                {
                    for (int i = 0; i < n; i++)
                    {
                        string[] ttx = reader2.ReadLine().Split('\t');
                        if (ttx[0].ToLower() == product.ToLower())
                        {
                            index =  MaxEl(ttx);
                        }
                    }
                }
            }
            return index;
        }
    }
}