using System;

namespace _05_密封类
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             *   可以继承父类
             *   但没有子类，不能被继承
             */
        }
    }


    public class Person
    {

    }

    public sealed class Student : Person {

    }
}
