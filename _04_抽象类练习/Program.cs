using System;

namespace _04_抽象类练习
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             *  1、计算圆形和正方形的面积和周长
             * 
             */

            Figure square = new Square();
            Figure circle = new Circle();

            bool isEnd = false;
            while (true)
            {
                while (true)
                {
                    Console.Write("请输入正方形的边长：");
                    string input = Console.ReadLine();
                    try
                    {
                        square.Param = double.Parse(input);
                        break;
                    }
                    catch
                    {
                        if (input == "exit" || input == "Exit")
                        {
                            isEnd = true;
                            break;
                        }
                        Console.WriteLine("输入错误，请重新输入正方形边长");
                    }
                }

                if (isEnd)
                {
                    break;
                }

                while (true)
                {
                    Console.Write("请输入圆的半径：");
                    string input2 = Console.ReadLine();
                    try
                    {
                        circle.Param = double.Parse(input2);
                        break;
                    }
                    catch
                    {
                        if (input2 == "exit" || input2 == "Exit")
                        {
                            isEnd = true;
                            break;
                        }
                        Console.WriteLine("输入错误，请重新输入圆的半径");
                    }
                }

                if (isEnd)
                {
                    break;
                }

                Console.WriteLine("边长为{0}的正方形的周长为{1}，面积为{2}", square.Param, square.GetPerimeter(), square.GetArea());
                Console.WriteLine("半径为{0}的圆的周长为{1}，面积为{2}", circle.Param, circle.GetPerimeter(), circle.GetArea());

                Console.WriteLine("\n\n");
                Console.ReadKey();
            }
        }


        public abstract class Figure
        {
            public double Param
            {
                set;
                get;
            }

            public abstract double GetPerimeter(double param);
            public abstract double GetPerimeter();
            public abstract double GetArea(double param);
            public abstract double GetArea();
        }

        public class Square : Figure
        {
            public override double GetArea()
            {
                return GetArea(this.Param);
            }

            public override double GetArea(double side)
            {
                return double.Parse((side * side).ToString("0.00"));
            }

            public override double GetPerimeter()
            {
                return GetPerimeter(this.Param);
            }
            public override double GetPerimeter(double param)
            {
                return double.Parse((4 * param).ToString("0.00"));
            }
        }

        public class Circle : Figure
        {
            public override double GetArea()
            {
                return GetArea(this.Param);
            }
            public override double GetArea(double param)
            {
                return double.Parse((param * param * Math.PI).ToString("0.00"));
            }

            public override double GetPerimeter()
            {
                return GetPerimeter(this.Param);
            }
            public override double GetPerimeter(double param)
            {
                return double.Parse((2 * Math.PI * param).ToString("0.00"));
            }
        }
    }
}
