using System;

namespace _12_多态总结
{
    class Program
    {
        static void Main(string[] args)
        {
            SuperMan batMan = new BatMan();
            batMan.Fly();
            batMan.Swim();
            Console.ReadKey();
        }
    }



    public interface IFlyable
    {
        void Fly();
    }

    public interface IRun
    {
        void Run();
    }

    public interface ISwim
    {
        void Swim();
    }

    public abstract class SuperMan : IFlyable, IRun, ISwim
    {
        // 以抽象方法实现接口方法
        public abstract void Fly();

        //  显示调用，会成为private，子类无法调用
        void IRun.Run()
        {
            Console.WriteLine("我是超人，我会跑");
        }

        public void Swim()
        {
            Console.WriteLine("我是超人，我会游");
        }
    }

    public class BatMan : SuperMan
    {
        public override void Fly()
        {
            Console.WriteLine("我是蝙蝠侠，我会用翅膀飞");
        }
    }

    public class IronMan : SuperMan
    {
        public override void Fly()
        {
            Console.WriteLine("我是钢铁侠，我有飞行器，可以上天哦");
        }
    }

    public class SpiderMan : SuperMan
    {
        public override void Fly()
        {
            Console.WriteLine("我是蜘蛛侠，我会吐丝飞");
        }
    }
}
