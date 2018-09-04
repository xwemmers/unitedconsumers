using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExamtestConsole

{

    class Animal
    {
        protected Animal()
        {

        }

        public static Animal Create()
        {
            return new Animal();
        }
    }

    class Monkey: Animal
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            //var a = new Animal();

            var a2 = Animal.Create();



            int getal = 10;
            var tc = new TestClass();

            //tc.RunTestClass();
            //tc.test();

#if (DEBUG)
            Console.WriteLine("Debug");
#elif (RELEASE)
            Console.WriteLine("Release");
#else
            Console.WriteLine("Nothing");
#endif

            float x = 2.02F;
            ConvertAmount(x);
            ConvertAmount2(x);

            Console.ReadLine();
        }

        static void ConvertAmount(float amount)
        {
            TransferFunds((decimal)amount);
        }

        static void TransferFunds(decimal funds)
        {
            Console.WriteLine(funds);
        }

        static void ConvertAmount2(float amount)
        {
            TransferFunds2((double)amount);
        }

        static void TransferFunds2(double funds)
        {
            Console.WriteLine(funds);
        }


        public class TestClass
        {
            [Conditional("DEBUG")]
            public void LogData()
            {
                Console.WriteLine("LogDatal");
            }
            public void RunTestClass()
            {
                this.LogData();
#if (DEBUG)
                Console.WriteLine("LogData2");
#endif

                Console.ReadLine();
            }

            public void test()
            {
                Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

                foreach (var item in assemblies)
                {
                    Console.WriteLine(item.FullName);
                }

                //IEnumerable<Type[]> types1 = assemblies.Select(t => t.GetTypes());
                IEnumerable<Type> types2 = assemblies.SelectMany(t => t.GetTypes());



                List<Type> result = types2.Where(t => t.IsClass && t.Assembly == this.GetType().Assembly).ToList();

                foreach (var t in result)
                {
                    Console.WriteLine(t.Name);
                }
            }
        }
    }
}
