using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Examples
{

    class MainApp
    {
        public static void Main()
        {
            Facade facade = new Facade();
            facade.MethodA();
            facade.MethodB();
            facade.MethodC();
         
            Console.Read();
        }
    }


    
    class SubSystemOne
    {
        public void MethodOne()
        {
            Console.WriteLine(" SubSystemOne Method");
        }
    }

 
    class SubSystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine(" SubSystemTwo Method");
        }
    }


    class SubSystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine(" SubSystemThree Method");
        }
    }
  
    class SubSystemFour
    {
        public void MethodFour()
        {
            Console.WriteLine(" SubSystemFour Method");
        }
    }
  
    class SubSystemFive
    {
        public void MethodFive()
        {
            Console.WriteLine(" SubSystemFive Method");
        }
    }


    class Facade
    {
        SubSystemOne one;
        SubSystemTwo two;
        SubSystemThree three;
        SubSystemFour four;
        SubSystemFive five;

        public Facade()
        {
            one = new SubSystemOne();
            two = new SubSystemTwo();
            three = new SubSystemThree();
            four = new SubSystemFour();
            five = new SubSystemFive();
        }

        public void MethodA()
        {
            Console.WriteLine("\nMethodA() ---- ");
            one.MethodOne();
            two.MethodTwo();
            four.MethodFour();
        }

        public void MethodB()
        {
            Console.WriteLine("\nMethodB() ---- ");
            two.MethodTwo();
            three.MethodThree();
        }

      
        public void MethodC()
        {
            Console.WriteLine("\nMethodC() ---- ");
            one.MethodOne();
            three.MethodThree();
            five.MethodFive();
        }
    }
}
