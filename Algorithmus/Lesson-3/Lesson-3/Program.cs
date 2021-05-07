using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Lesson_3
{
    public class PointClass
    {
        public int X;
        public int Y;
    }

    public struct PointStruct
    {
        public int X;
        public int Y;
    }
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

        }
    }
    public class BechmarkClass
    {

        public static float PointDistance(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public static float PointDistanceShort(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }
        public static double PointDistanceDouble(PointStruct pointOne, PointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
        public static float PointDistanceClass(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public static PointClass [] GeneratePointsCl ()
        {
            PointClass pointOne = new PointClass { X = 5, Y = 7 };
            PointClass pointTwo = new PointClass { X = 10, Y = 12 };
            PointClass[] points = { pointOne, pointTwo };
            return points;
        }
        public static PointStruct[] GeneratePointsStr()
        {
            PointStruct pointOne = new PointStruct { X = 5, Y = 7 };
            PointStruct pointTwo = new PointStruct { X = 10, Y = 12 };
            PointStruct[] points = { pointOne, pointTwo };
            return points;
        }
        [Benchmark]
        public void TestPointDistanceClass()
        {
            var points = GeneratePointsCl();
            PointDistanceClass(points[1], points[2]);
        }
        [Benchmark]
        public void TestPointDistance()
        {
            var points = GeneratePointsStr();
            PointDistance(points[1], points[2]);
        }
        [Benchmark]
        public void TestPointDistanceShort()
        {
            var points = GeneratePointsStr();
            PointDistanceShort(points[1], points[2]);
        }
        [Benchmark]
        public void TestPointDistanceDouble()
        {
            var points = GeneratePointsStr();
            PointDistanceDouble(points[1], points[2]);
        }
        
    }
}
    

