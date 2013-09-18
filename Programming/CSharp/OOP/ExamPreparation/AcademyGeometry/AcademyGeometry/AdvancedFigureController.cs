using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometryAPI
{
    public class AdvancedFigureController : FigureController
    {
        public override void ExecuteFigureCreationCommand(string[] splitFigString)
        {
            switch (splitFigString[0])
            {
                case "circle":
                    {
                        Vector3D center = Vector3D.Parse(splitFigString[1]);
                        double radius = double.Parse(splitFigString[2]);
                        currentFigure = new Circle(center, radius);
                        break;
                    }
                case "cylinder":
                    {
                        Vector3D top = Vector3D.Parse(splitFigString[1]);
                        Vector3D bottom = Vector3D.Parse(splitFigString[2]);
                        double radius = double.Parse(splitFigString[3]);
                        currentFigure = new Cylinder(top, bottom, radius);
                        break;
                    }
                default:
                    break;
            }
            base.ExecuteFigureCreationCommand(splitFigString);
            base.EndCommandExecuted = false;
        }

        protected override void ExecuteFigureInstanceCommand(string[] splitCommand)
        {
            switch (splitCommand[0])
            {
                case "area":
                    {
                        var currentAsAreaMeasurable = this.currentFigure as IAreaMeasurable;
                        if (currentAsAreaMeasurable != null)
                        {
                            Console.WriteLine("{0:0.00}", currentAsAreaMeasurable.GetArea());
                        }
                        else
                        {
                            Console.WriteLine("undefined");
                        }
                        break;
                    }
                case "volume":
                    {
                        var currentAsVolumeMeasurable = this.currentFigure as IVolumeMeasurable;
                        if (currentAsVolumeMeasurable != null)
                        {
                            Console.WriteLine("{0:0.00}", currentAsVolumeMeasurable.GetVolume());
                        }
                        else
                        {
                            Console.WriteLine("undefined");
                        }
                        break;
                    }
                case "normal":
                    {
                        var currentAsFlat = this.currentFigure as IFlat;
                        if (currentAsFlat != null)
                        {
                            Console.WriteLine("{0:0.00}", currentAsFlat.GetNormal());
                        }
                        else
                        {
                            Console.WriteLine("undefined");
                        }
                        break;
                    }
                default:
                    break;
            }
            base.ExecuteFigureInstanceCommand(splitCommand);
        }
    }
}
