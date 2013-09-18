namespace TriangleProblem
{
    using System;

    public class Triange
    {
        public Triange(Point2D vertexA, Point2D vertexB, Point2D vertexC)
        {
            this.VertexA = vertexA;
            this.VertexB = vertexB;
            this.VertexC = vertexC;
        }

        private Point2D VertexA { get; set; }

        private Point2D VertexB { get; set; }

        private Point2D VertexC { get; set; }

        public bool IsPointInside(Point2D point)
        {
            // Let ABC is the area of the triangle formed by vertex A, vertex B, vertex C
            double areaOfABC = CalculateArea();

            // Let PBC is the area of the triangle formed by point P, vertex B, vertex C
            double areaOfPBC = CalculateArea(point, this.VertexB, this.VertexC);

            // Let APC is the area of the triangle formed by vertex A, point P, vertex C
            double areaOfAPC = CalculateArea(this.VertexA, point, this.VertexC);

            // Let ABP is the area of the triangle formed by vertex A, vertex B, point p
            double areaOfABP = CalculateArea(this.VertexA, this.VertexB, point);

            // Check if sum of the areas of PBC, APC and ABP is same as ABC
            return (areaOfABC == areaOfPBC + areaOfAPC + areaOfABP);
        }

        private double CalculateArea()
        {
            double area = CalculateArea(this.VertexA, this.VertexB, this.VertexC);

            return area;
        }

        private double CalculateArea(Point2D vertexA, Point2D vertexB, Point2D vertexC)
        {
            double area = Math.Abs((
                                    vertexA.X * (vertexB.Y - vertexC.Y) +
                                    vertexB.X * (vertexC.Y - vertexA.Y) +
                                    vertexC.X * (vertexA.Y - vertexB.Y)) /
                                   2);
            return area;
        }
    }
}