using System;

namespace _01_多态之虚方法
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             *  多态的三种实现方法:虚方法、抽象类、接口
             *  
             *  如果子类方法与父类方法重名，会默认将父类方法隐藏
             *  解决方法：1、new 关键字 故意隐藏 父类方法
             *           2、使用虚方法
             * 
             *  使用虚方法步骤：1、将父类方法标记为virtual 虚方法 让子类可以重写
             *                 2、将子类方法标记为override 重写父类方法
             *                 3、一种类型，表现为多种形式，这就是多态
             */

            #region 片头
            //Person person = new Person("人类");
            //person.SayHello();

            //Chinese cn = new Chinese("钱老其");
            //cn.SayHello(); 
            #endregion

            #region 一些实例，已经父类数组，子类对象
            Person p1 = new Person("亚当");
            Person p2 = new Person("夏娃");
            Chinese cn1 = new Chinese("张三");
            Chinese cn2 = new Chinese("李四");
            Korea k1 = new Korea("金针菇");
            Korea k2 = new Korea("金城武");
            Japanese j1 = new Japanese("苍井空");
            Japanese j2 = new Japanese("熊心");
            American a1 = new American("格林");
            American a2 = new American("乔治");

            Person[] pers = { p1, p2, cn1, cn2, k1, k2, j1, j2, a1, a2 };
            #endregion

            #region 第一：不用多态，判断强转后，调用方法

            //foreach (var item in pers)
            //{
            //    if (item is Chinese)
            //    {
            //        ((Chinese)item).SayHello();
            //    }
            //    else if (item is Korea)
            //    {
            //        ((Korea)item).SayHello();
            //    }
            //    else if (item is Japanese)
            //    {
            //        ((Japanese)item).SayHello();
            //    }
            //    else
            //    {
            //        ((American)item).SayHello();
            //    }
            //}
            //Console.ReadKey();

            #endregion

            #region 利用虚方法 实现多态 父类方法virtual标识  子类override重写父类方法

            //foreach (var item in pers)
            //{
            //    item.SayHello();
            //}
            //Console.ReadKey();

            #endregion


        }
    }

    #region 一些类
    public class Person
    {
        public string Name
        {
            get;
            set;
        }

        public Person() { }
        public Person(string name)
        {
            this.Name = name;
        }

        public virtual void SayHello()   // 标记为虚方法
        {
            Console.WriteLine("大家好，我叫{0}，我是人类", this.Name);
        }
    }

    public class Chinese : Person
    {
        public Chinese(string name) : base(name) { }

        public override void SayHello()    // 子类重写父类方法
        {
            Console.WriteLine("大家好，我叫{0}，我是中国人", this.Name);
        }
    }

    public class Korea : Person
    {
        public Korea(string name) : base(name) { }

        public override void SayHello()
        {
            Console.WriteLine("大家好，我叫{0}，我是韩国棒子", this.Name);
        }
    }

    public class Japanese : Person
    {
        public Japanese(string name) : base(name) { }

        public override void SayHello()
        {
            Console.WriteLine("大家好，我叫{0}，我是脚盆国人", this.Name);
        }
    }

    public class American : Person
    {
        public American(string name) : base(name) { }

        public override void SayHello()
        {
            Console.WriteLine("大家好，我叫{0}，我是米国人", this.Name);
        }
    } 
    #endregion
}
