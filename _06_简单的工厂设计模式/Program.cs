using System;

namespace _06_简单的工厂设计模式
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             *   设计模式就是解决问题思维
             *   简单工厂设计模式
             *   
             */

            while (true)
            {
                Console.WriteLine("请输入你需要的笔记本电脑的品牌：");
                string brand = Console.ReadLine();
                if (brand == "exit" || brand == "Exit")
                {
                    break;
                }
                Laptop laptop = CreateLaptop(brand);
                laptop.ShowBrand();
                Console.ReadKey();
            }
        }

        public static Laptop CreateLaptop(string brand)
        {
            Laptop laptop = null;

            switch (brand)
            {
                case "Acer":
                case "宏基":
                    laptop = new Acer();
                    break;
                case "Dell":
                case "戴尔":
                    laptop = new Dell();
                    break;
                case "Lenovo":
                case "联想":
                    laptop = new Lenovo();
                    break;
                default:
                    laptop = new OtherBrand();
                    break;
            }

            return laptop;
        }
    }


    #region 几个电脑类

    public abstract class Laptop
    {
        public abstract void ShowBrand();
    }

    public class Acer : Laptop
    {
        public override void ShowBrand()
        {
            Console.WriteLine("我是宏基笔记本，垃圾中的战斗机");
        }
    }

    public class Lenovo : Laptop
    {
        public override void ShowBrand()
        {
            Console.WriteLine("我是联想笔记本，你联想也别想");
        }
    }

    public class Dell : Laptop
    {
        public override void ShowBrand()
        {
            Console.WriteLine("我是戴尔笔记本，买我吧");
        }
    }

    public class OtherBrand : Laptop
    {
        public override void ShowBrand()
        {
            Console.WriteLine("我是杂牌笔记本，说了你也不知道");
        }
    }

    #endregion
}
