using System;
using System.Collections.Generic;

namespace ConsoleApp7
{
    class Program
    {
        /*
            1.	можливість створювати листа з отримувачем і текстом.
            2.	Історія всіх емейлів в системі
            3.	Вхідні, надіслані, чернетки
            4.	Прочитані, не прочитані
            5.	функціональність додавати в копію
            6.	функціональність додавати в сховану копію
            7.	Функціональність важливих повідомлень
            8.	Функціональність подій
        
            */
        static void Main(string[] args)
        {
            while (true)
            {
                var username = GetInput("Choose username: ");
                var ac = 99999;
                while (ac > 0)
                {
                    var menuManager = new MenuManager(username);
                    menuManager.printMenu();
                    var action = GetInput("Choose: ");
                    ac = menuManager.doAction(action);
                }
            }
        }

        public static string GetInput(string text)
        {
            Console.WriteLine(text);
            return Console.ReadLine();
        }
    }
}