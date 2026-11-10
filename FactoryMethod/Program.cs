using System;
namespace FactoryMethodExample
{

    public abstract class Creator
    {
        public abstract Product FactoryMethod(int type);
    }

    public class ConcreteCreator : Creator
    {
        public override Product FactoryMethod(int type)
        {
            switch (type)
            {
           
                case 1: return new ConcreteProductA();
                 
                case 2: return new ConcreteProductB();
              
                case 3: return new ConcreteProductC();
                default: throw new ArgumentException("Invalid type.", "type");
            }
        }
    }

    public abstract class Product { } 

    public class ConcreteProductA : Product { }

    public class ConcreteProductB : Product { }

    public class ConcreteProductC : Product { }

    class MainApp
    {
        static void Main()
        {      
            Creator creator = new ConcreteCreator();
            for (int i = 1; i <= 3; i++)
            {
               
                var product = creator.FactoryMethod(i);
                Console.WriteLine("Where id = {0}, Created {1} ", i, product.GetType());
            }
            Console.ReadKey();
        }
    }
}

