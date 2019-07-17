using System;

namespace _08_接口
{
    class Program
    {
        static void Main(string[] args)
        {
            IKouLanable teacher = new Teacher();
            IKouLanable student = new Student();

            teacher.KouLan();
            student.KouLan();

            Console.ReadKey();
        }
    }

    public class Person
    {
        public void CHLSS()
        {
            Console.WriteLine("人类可以吃喝拉撒睡");
        }
    }

    public class Student : Person,IKouLanable
    {
        public void KouLan()
        {
            Console.WriteLine("学生说：我扣篮贼叼");
        }

        public void Study()
        {
            Console.WriteLine("学生可以学习");
        }
    }

    public class Teacher : Person, IKouLanable
    {
        public void KouLan()
        {
            Console.WriteLine("老师说：年纪老了，扣不动了");
        }
    }

    public interface IKouLanable
    {
        void KouLan();
    }
}
