using System;
using System.Collections;
using System.Text;

namespace Mediator.Examples
{

    class MainApp
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            ConcreteMediator m = new ConcreteMediator();
            ConcreteColleague1 c1 = new ConcreteColleague1(m);
            ConcreteColleague2 c2 = new ConcreteColleague2(m);
            ConcreteCollegue3 c3 = new ConcreteCollegue3(m);

            m.Colleague1 = c1;
            m.Colleague2 = c2;
            m.Colleague3 = c3;

            m.Send("How are you?", c1);
            m.Send("Fine, thanks", c2);
            c3.Send("Hello!");
             
         
            Console.Read();
        }
    }

    abstract class Mediator
    {
        public abstract void Send(string message,
          Colleague colleague);
    }
  
    class ConcreteMediator : Mediator
    {
        private ConcreteColleague1 colleague1;
        private ConcreteColleague2 colleague2;
        private ConcreteCollegue3 colleague3;

        public ConcreteColleague1 Colleague1
        {
            set { colleague1 = value; }
        }


        public ConcreteColleague2 Colleague2
        {
            set { colleague2 = value; }
        }
        public ConcreteCollegue3 Colleague3
        {
            set { colleague3 = value; }
        }

        public override void Send(string message,
          Colleague colleague)
        {
          
            if (colleague != colleague1 && colleague1 != null)
            {
                colleague1.Notify(message);
            }
            if (colleague != colleague2 && colleague2 != null)
            {
                colleague2.Notify(message);
            }
            if (colleague != colleague3 && colleague3 != null)
            {
                colleague3.Notify(message);
            }
        }
    }


    abstract class Colleague
    {
        protected Mediator mediator;

 
        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }

    class ConcreteColleague1 : Colleague
    {

        public ConcreteColleague1(Mediator mediator)
            : base(mediator)
        {
        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("Colleague1 gets message: "
              + message);
        }
    }
    
    class ConcreteColleague2 : Colleague
    {
      
        public ConcreteColleague2(Mediator mediator)
            : base(mediator)
        {
        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("Colleague2 gets message: "
              + message);
        }
    }

   
    class ConcreteCollegue3 : Colleague
    {
        public ConcreteCollegue3(Mediator mediator) : base(mediator)
        {
        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("Colleague3 gets message: " + message);
        }
    }
}
