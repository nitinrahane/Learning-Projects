using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    public interface I1
    {
        void Add();
    }

    public interface I2 {
        void Add();
    }

   public class Test1 : I1, I2
    {

        public  void Add()
        {
           // throw new NotImplementedException();
        }

        //void I2.Add()
        //{
        //  //  throw new NotImplementedException();
        //}
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Test t = new Test();
            //t.Add(5, 5);
            //t.Add(5, 5.5);

            //Test1 t1 = new Test1();
            //Console.ReadLine();


        }

    }

    class Test {

        public int Add(int a, int b) {
            Console.WriteLine("Add int");
            return 0;
        }

        public double Add(double a, double b) {
            Console.WriteLine("double");
            return 0;
        }
    }
}
