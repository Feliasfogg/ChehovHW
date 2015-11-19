using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSample
{
   class Program {
      /// <summary>
      /// Итак у нас есть событие событие содержит ключевое слово event ТипДелегатаОбрабатывающегоСобытие НазваниеСобытия
      /// ДЕлегат это объект содержащий в себе ссылку на одну единственную функцию. Важный момент, что делегат и функция должны иметь
      /// одинаковую сигнатуру. 
      /// Мы создаем объект делегата, в конструктор передаем делегату функцию, которая соответсвует сигнатуре делегата. Затем мы берем событие
      /// и подписываем на него делегат.
      /// Событие отрабатывает -> зовутся все делегаты которые подписаны на событие -> зовутся все методы-обработчики.
      /// Не рекомендуется поджписывать событие на несколько обработчиков(делегатов) т.к в этом случае точный порядок вызовов обработчиков 
      /// не известен
      /// </summary>
      /// <param name="args"></param>

      static void Main(string[] args) {
         var objMyClass = new MyClass();

         for(int i=0; i<10000; ++i) objMyClass.CallEvent();
      }
     
      public class MyClass
      {
         private event MyDelegate MyEvent;
         private delegate void MyDelegate(object sender, EventArgs e);

         public MyClass()
         {
            MyDelegate objDelegate1=new MyDelegate(MyMethod1);
            MyDelegate objDelegate2=new MyDelegate(MyMethod2);

            MyEvent += objDelegate1;
            MyEvent += objDelegate2;
         }
         public void CallEvent() {
            MyEvent(null, null);
         }
         private void MyMethod1(object sender, EventArgs eventArgs) {
            Console.WriteLine("Invoke Method1");
         }
         private void MyMethod2(object sender, EventArgs eventArgs)
         {
            Console.WriteLine("Invoke Method2");
         }
      }
   }
}
