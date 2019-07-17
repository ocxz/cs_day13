using System;

namespace _11_显示实现接口举例
{
    class Program
    {
        static void Main(string[] args)
        {
            M1 stu1 = new Student();
            stu1.Fly();
            M2 stu2 = new Student();
            stu2.Fly();
            M3 stu3 = new Student();
            stu3.Fly();
            Console.ReadKey();
        }
    }


    public interface M1
    {
        void Fly();
    }
    public interface M2
    {
        void Fly();
    }
    public interface M3
    {
        void Fly();
    }

    public class Student : M1, M2, M3
    {
        void M1.Fly()
        {
            Console.WriteLine("这是M1调用的方法");
        }

        void M2.Fly()
        {
            Console.WriteLine("这是M2调用的方法");
        }

        void M3.Fly()
        {
            Console.WriteLine("这是M3调用的方法");
        }
    }
}
