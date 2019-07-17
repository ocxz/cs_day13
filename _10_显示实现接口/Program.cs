using System;

namespace _10_显示实现接口
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             *  显示接口就是为了解决，多个接口中方法重名的问题
             * 
             */

            IFlyable fPerson = new Person();
            fPerson.Fly();
            Console.ReadKey();
            ISupperMan Sperson = new Person();
            Sperson.Fly();
            Console.ReadKey();
        }
    }

    public interface IFlyable
    {
        void Fly();
    }

    public interface ISupperMan
    {
        void Fly();
    }


    public class Person : IFlyable,ISupperMan
    {
        // 实现接口
        public void Fly()
        {
            Console.WriteLine("人类会飞");
        }

        // 显示实现
        void ISupperMan.Fly()
        {
            Console.WriteLine("我是超人，我会飞");
        }
    }


    public class Student
    {

    }

    public class Teacher
    {

    }
}
