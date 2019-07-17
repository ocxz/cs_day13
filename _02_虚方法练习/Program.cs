using System;

namespace _02_虚方法练习
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 第一个练习 鸭子叫 虚方法练习

            /**
             *  多态之虚方法实现：
             *  真实的鸭子：嘎嘎叫
             *  木头鸭子：吱吱叫
             *  橡皮鸭子：呱呱叫
            */

            //Duck duck = new Duck();
            //RealDuck realDuck = new RealDuck();
            //WoodDuck woodDuck = new WoodDuck();
            //RubberDuck rubberDuck = new RubberDuck();

            //Duck[] ducks = { duck, realDuck, woodDuck, rubberDuck };
            //foreach (var item in ducks)
            //{
            //    item.DuckYell();
            //}
            //Console.ReadKey();

            #endregion

            #region 第二个练习 多态之虚方法实现：工种不同，打卡时间不同

            //Staff staff = new Staff();
            //Staff manager = new Manager();
            //Staff programmer = new Programmer();

            //Staff[] staffs = { staff, manager, programmer };

            //foreach (var item in staffs)
            //{
            //    item.ClockIn();
            //}

            #endregion
        }
    }

    #region 鸭子类
    public class Duck
    {
        public virtual void DuckYell()
        {
            Console.WriteLine("鸭子会叫，不同的鸭子叫声不同");
        }
    }

    public class RealDuck : Duck
    {
        public override void DuckYell()
        {
            Console.WriteLine("真实的鸭子，嘎嘎叫");
        }
    }

    public class WoodDuck : Duck
    {
        public override void DuckYell()
        {
            Console.WriteLine("木头鸭子，吱吱叫");
        }
    }

    public class RubberDuck : Duck
    {
        public override void DuckYell()
        {
            Console.WriteLine("橡皮鸭子，呱呱叫");
        }
    }
    #endregion

    #region 工种类

    public class Staff
    {
        public virtual void ClockIn()
        {
            Console.WriteLine("普通员工，九点打卡");
        }
    }

    public class Manager : Staff
    {
        public override void ClockIn()
        {
            Console.WriteLine("我是经理，我早上十一点打卡");
        }
    }

    public class Programmer : Staff
    {
        public override void ClockIn()
        {
            Console.WriteLine("程序猿不用打卡");
        }
    }

    #endregion
}
