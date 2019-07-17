using System;

namespace _03_抽象类
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             *   猫咪：会吃鱼 喵喵喵的叫
             *   狗狗：会吃骨头   汪汪汪的叫
             *   --> 抽出一个Animal动物类出来
             *  
             */

            #region 抽象类的一些学习

            //Animal dog = new Dog();
            //Animal cat = new Cat();
            //dog.Eat();
            //dog.Bark();
            //cat.Eat();
            //cat.Bark();

            //Console.WriteLine("======================");
            //Bird egret = new Egret("白鹭");
            //egret.Fly();
            //egret.Color();
            //egret.Bark();
            //egret.Eat();

            //Console.WriteLine(); 

            #endregion
        }
    }

    #region 动物的一些类

    public abstract class Animal   // 抽象类
    {
        public abstract void Eat();
        public abstract void Bark();
    }

    public class Dog : Animal   //继承抽象类
    {
        public override void Bark()
        {
            Console.WriteLine("狗狗吃骨头");
        }

        public override void Eat()
        {
            Console.WriteLine("狗狗会汪汪汪的叫");
        }
    }

    public class Cat : Animal
    {
        public override void Bark()
        {
            Console.WriteLine("猫咪会喵喵喵的叫");
        }

        public override void Eat()
        {
            Console.WriteLine("猫咪吃鱼");
        }
    }

    public abstract class Bird : Animal
    {
        public string BirdKind
        {
            set;
            get;
        }

        public Bird() { }
        public Bird(string birdKind)
        {
            this.BirdKind = birdKind;
        }


        public abstract void Color();

        public void Fly()
        {
            Console.WriteLine("鸟儿会飞，{0}是鸟，所以{0}会飞",this.BirdKind);
        }
    }

    public class Egret : Bird
    {
        public Egret() { }
        public Egret(string birdKind) : base(birdKind) { }

        public override void Bark()
        {
            Console.WriteLine("白鹭的叫声呱呱呱");
        }

        public override void Color()
        {
            Console.WriteLine("白鹭的颜色是白的的");
        }

        public override void Eat()
        {
            Console.WriteLine("白鹭吃小鱼和虾米");
        }
    }



    #endregion
}
