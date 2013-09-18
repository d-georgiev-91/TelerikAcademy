using System;

namespace SizeCalculator
{
    class SizeCalculator
    {
        static void Main()
        {

        }

        public static Figure GetRotatedSize(Figure figure, double angleOfRotation)
        {
            double cosOfAngleOfRotation = Math.Cos(angleOfRotation);
            double sinOfAngleOfRotation = Math.Sin(angleOfRotation);

            double widthAfterRotation = Math.Abs(cosOfAngleOfRotation) * figure.Width + Math.Abs(sinOfAngleOfRotation) * figure.Height;
            double heightAfterRotattion = Math.Abs(sinOfAngleOfRotation) * figure.Width + Math.Abs(cosOfAngleOfRotation) * figure.Height;

            Figure figureAfterRotation = new Figure(widthAfterRotation, heightAfterRotattion);

            return figureAfterRotation;
        }
    }
}