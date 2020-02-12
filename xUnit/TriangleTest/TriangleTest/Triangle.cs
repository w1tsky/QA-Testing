using System;

namespace TriangleLib
{
    public class IsTrianlge
    {
        public static bool IsTriangle(double a, double b, double c)
        {
            return (a > 0 && b > 0 && c > 0 && c <= a+b && a <= c+b && b <= a+c);
        }
    }
}
