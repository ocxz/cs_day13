using System;

namespace _09_接口
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             *   三个鸭子：真鸭子、木头鸭子、橡皮鸭子
             *   叫：嘎嘎叫、吱吱叫、呱呱叫
             *   游泳：自己游泳、不会游泳、发动机游泳
             * 
             */

            Swimmable realDuck = new RealDuck();
            realDuck.Swim();
            Swimmable rubberDuck = new RubberDuck();
            rubberDuck.Swim();
            Console.ReadKey();
        }
    }

    #region 几个鸭子类 及接口
    // 可以叫的接口
    public interface Yellable
    {
        void Yell();
    }

    // 可游泳的接口
    public interface Swimmable
    {
        void Swim();
    }

    public class RealDuck : Yellable, Swimmable
    {
        public void Swim()
        {
            Console.WriteLine("我是真鸭子，我自己就会游泳");
        }

        public void Yell()
        {
            Console.WriteLine("我是真鸭子，我的叫声是嘎嘎嘎");
        }
    }

    public class WoodDuck : Yellable
    {
        public void Yell()
        {
            Console.WriteLine("我是木头鸭子，我的叫声是吱吱吱");
        }
    }

    public class RubberDuck : Yellable, Swimmable
    {
        public void Swim()
        {
            Console.WriteLine("我是橡皮鸭子，我可以靠发动机游泳");
        }

        public void Yell()
        {
            Console.WriteLine("我是橡皮鸭子，我的叫声是呱呱呱");
        }
    } 
    #endregion
}
