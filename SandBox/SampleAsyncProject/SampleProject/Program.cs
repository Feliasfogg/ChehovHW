using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Запуск асинхронного вызова");
            MethodAsync();
            Console.WriteLine("Продолжение программы");
            Console.ReadKey();
        }
        static async void MethodAsync()
        {
            Task<string> returnedTaskResult = GetStringAsync();
            string str = await returnedTaskResult;//или так string str = await GetStringAsync();
            //Весь код, который идет после await блокируется до выполенния задания в таске returnedTaskResult
            //т.е Надпиьс о завершении выполнения задачи не появится пока в Str не вернется рещультат работы задания
            Console.WriteLine("kjk");
        }
        static Task<string> GetStringAsync()
        {
            Console.WriteLine("Запуск асинхронной задачи");
            //запуск асинхронного выполнения задачи и возврат Параметризированного Task
            return Task.Run(delegate
            {
                for (int i = 0; i < 1000000000; ++i) { }
                Console.WriteLine("Асинхронная задача завершена");
                return "Асинхронная задача завершена";
            });
        }
    }
}
