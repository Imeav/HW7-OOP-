using System;
using System.Text;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
         
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();

        
            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Operation();

            Console.WriteLine("\nChristmas tree with ornaments and garland:");
            ChristmasTree tree = new SimpleChristmasTree();
            tree = new OrnamentsDecorator(tree, "balls and a star");
            tree = new GarlandDecorator(tree);
            tree.Show();
            tree.Shine();

            Console.WriteLine("\nChristmas tree with ornaments only:");
            ChristmasTree withOrnaments = new OrnamentsDecorator(
                new SimpleChristmasTree(), "snowflakes");
            withOrnaments.Show();
            withOrnaments.Shine();

            Console.WriteLine("\nChristmas tree with garland only:");
            ChristmasTree withGarland = new GarlandDecorator(new SimpleChristmasTree());
            withGarland.Show();
            withGarland.Shine();

          
            Console.Read();
        }
    }

    abstract class Component
    {
        public abstract void Operation();
    }

  
    class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteComponent.Operation()");
        }
    }
 
    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

   
    class ConcreteDecoratorA : Decorator
    {
        private string addedState;

        public override void Operation()
        {
            base.Operation();
            addedState = "New State";
            Console.WriteLine("ConcreteDecoratorA.Operation()");
        }
    }

    
    class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("ConcreteDecoratorB.Operation()");
        }
        void AddedBehavior()
        { }
    }


    abstract class ChristmasTree
    {
        public abstract void Show();
        public virtual void Shine()
        {
            Console.WriteLine("No garland - the tree does not shine.");
        }
    }

   
    class SimpleChristmasTree : ChristmasTree
    {
        public override void Show()
        {
            Console.WriteLine("Simple Christmas tree");
        }
    }

 
    abstract class ChristmasTreeDecorator : ChristmasTree
    {
        protected ChristmasTree tree;

        protected ChristmasTreeDecorator(ChristmasTree tree)
        {
            this.tree = tree;
        }

        public override void Show() { tree.Show(); }
        public override void Shine() { tree.Shine(); }
    }

  
    class OrnamentsDecorator : ChristmasTreeDecorator
    {
        private string ornaments;

        public OrnamentsDecorator(ChristmasTree tree, string ornaments) : base(tree)
        {
            this.ornaments = ornaments;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("Ornaments: " + ornaments);
        }
    }

   
    class GarlandDecorator : ChristmasTreeDecorator
    {
        public GarlandDecorator(ChristmasTree tree) : base(tree) { }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("Garland on the tree");
        }

        public override void Shine()
        {
            Console.WriteLine("The garland is shining!");
        }
    }
}