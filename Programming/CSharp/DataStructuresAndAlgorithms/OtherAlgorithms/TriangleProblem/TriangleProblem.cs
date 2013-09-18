/// The sample triangle used  
//            B(10,30)
//               /\
//              /  \
//             /    \
//            /      \
//           /        \      
//          /          \
//   A(0,0) ------------ C(20,0) 

namespace TriangleProblem
{
    using System;

    class TriangleProblem
    {
        static void Main()
        {
            Triange triange = new Triange(new Point2D(0, 0), new Point2D(20, 0), new Point2D(10, 30));
            
            Point2D firstPoint = new Point2D(10, 15);
            Console.WriteLine("First point in triange => {0}", triange.IsPointInside(firstPoint));
            
            Point2D secondPoint = new Point2D(10, 150);
            Console.WriteLine("Second point in triange => {0}", triange.IsPointInside(secondPoint));

            Point2D thirdPoint = new Point2D(0, 1);
            Console.WriteLine("Third point in triange => {0}", triange.IsPointInside(thirdPoint));
        }
    }
}