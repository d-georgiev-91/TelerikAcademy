namespace PaintRT
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using Windows.Data.Xml.Dom;
    using Windows.Storage;
    using Windows.Storage.Pickers;
    using Windows.UI;
    using Windows.UI.Core;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Shapes;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        RotateTransform canvasRotation = new RotateTransform();
        Line newLine;
        Rectangle newRectangle;
        Ellipse newEllipse;
        double strokeThickness = 5;
        double x1, x2, y1, y2;
        Color borderColor = Colors.Black;

        DrawingTool currentDrawingTool;

        public MainPage()
        {
            this.InitializeComponent();
            this.DrawingCanvas.PointerMoved += OnCanvasPointerMoved;
            this.DrawingCanvas.PointerReleased += OnCanvasPointerReleased;
            this.DrawingCanvas.PointerPressed += OnCanvasPointerPressed;
            this.DrawingCanvas.PointerExited += OnCanvasPointerExited;
            this.currentDrawingTool = DrawingTool.Line;
        }

        public void OnClickSetGreenColor(object sender, RoutedEventArgs e)
        {
            this.borderColor = Colors.Green;
        }

        public void OnClickSetBlueColor(object sender, RoutedEventArgs e)
        {
            this.borderColor = Colors.Blue;
        }

        public void OnClickSetBlackColor(object sender, RoutedEventArgs e)
        {
            this.borderColor = Colors.Black;
        }

        public void OnClickSetRedColor(object sender, RoutedEventArgs e)
        {
            this.borderColor = Colors.Red;
        }

        public void OnClickClearDrawingCanvas(object sender, RoutedEventArgs e)
        {
            this.DrawingCanvas.Children.Clear();
        }

        public void OnClickSelectRectangleTool(object sender, RoutedEventArgs e)
        {
            this.currentDrawingTool = DrawingTool.Rectangle;
        }

        public void OnClickSelectEllipseTool(object sender, RoutedEventArgs e)
        {
            this.currentDrawingTool = DrawingTool.Ellipse;
        }

        public void OnClickSelectLineTool(object sender, RoutedEventArgs e)
        {
            currentDrawingTool = DrawingTool.Line;
        }

        public async void OnClickOpen(object sender, RoutedEventArgs e)
        {
            var openPicker = new Windows.Storage.Pickers.FileOpenPicker();
            openPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            openPicker.FileTypeFilter.Add(".dxml");

            var file = await openPicker.PickSingleFileAsync();
            
            if (file != null)
            {
                var doc = await XmlDocument.LoadFromFileAsync(file);
                ParseElements(XDocument.Parse(doc.GetXml()));
            }
        }

        private void ParseElements(XDocument doc)
        {
            var shapes = doc.Root.Elements();
            
            foreach (var shape in shapes)
            {
                switch (shape.Name.ToString())
                {
                    case "line":
                        AddLineToDrawing(shape);
                        break;
                    case "rectangle":
                        AddRectangleToDrawing(shape);
                        break;
                    case "ellipse":
                        AddEllipseToDrawing(shape);
                        break;
                    default:
                        break;
                }
            }
        }

        private void AddEllipseToDrawing(XElement shape)
        {
            var newEllipse = new Ellipse();
            double top = double.Parse(shape.Attribute("Top").Value);
            double left = double.Parse(shape.Attribute("Left").Value);
            double bottom = double.Parse(shape.Attribute("Bottom").Value);
            double right = double.Parse(shape.Attribute("Right").Value);
            newEllipse.Margin = new Thickness(left, top, right, bottom);
            newEllipse.Width = double.Parse(shape.Attribute("Width").Value);
            newEllipse.Height = double.Parse(shape.Attribute("Height").Value);
            newEllipse.StrokeThickness = double.Parse(shape.Attribute("StrokeThickness").Value);
            var colorNode = shape.Element("color");
            var color = ParseColor(colorNode);
            newEllipse.Stroke = new SolidColorBrush(color);

            this.DrawingCanvas.Children.Add(newEllipse);
        }

        private void AddRectangleToDrawing(XElement shape)
        {
            var newRectangle = new Rectangle();
            double top = double.Parse(shape.Attribute("Top").Value);
            double left = double.Parse(shape.Attribute("Left").Value);
            double bottom = double.Parse(shape.Attribute("Bottom").Value);
            double right = double.Parse(shape.Attribute("Right").Value);
            newRectangle.Margin = new Thickness(left, top, right, bottom);
            newRectangle.Width = double.Parse(shape.Attribute("Width").Value);
            newRectangle.Height = double.Parse(shape.Attribute("Height").Value);
            newRectangle.StrokeThickness = double.Parse(shape.Attribute("StrokeThickness").Value);
            var colorNode = shape.Element("color");
            var color = ParseColor(colorNode);
            newRectangle.Stroke = new SolidColorBrush(color);

            this.DrawingCanvas.Children.Add(newRectangle);
        }

        private void AddLineToDrawing(XElement shape)
        {
            var newLine = new Line();
            newLine.X1 = double.Parse(shape.Attribute("X1").Value);
            newLine.X2 = double.Parse(shape.Attribute("X2").Value);
            newLine.Y1 = double.Parse(shape.Attribute("Y1").Value);
            newLine.Y2 = double.Parse(shape.Attribute("Y2").Value);
            newLine.StrokeThickness = double.Parse(shape.Attribute("StrokeThickness").Value);
            var colorNode = shape.Element("color");
            var color = ParseColor(colorNode);
            newLine.Stroke = new SolidColorBrush(color);
            this.DrawingCanvas.Children.Add(newLine);
        }
  
        private Color ParseColor(XElement colorNode)
        {
            var colorA = byte.Parse(colorNode.Attribute("A").Value);
            var colorR = byte.Parse(colorNode.Attribute("R").Value);
            var colorG = byte.Parse(colorNode.Attribute("G").Value);
            var colorB = byte.Parse(colorNode.Attribute("B").Value);
            var color = new Color();
            color.A = colorA;
            color.R = colorR;
            color.G = colorG;
            color.B = colorB;

            return color;
        }

        public async void OnClickSave(object sender, RoutedEventArgs e)
        {
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            savePicker.DefaultFileExtension = ".dxml";
            savePicker.FileTypeChoices.Add("DXML", new string[] { ".dxml" });
            savePicker.SuggestedFileName = "MyDrawing";
            StorageFile saveFile = await savePicker.PickSaveFileAsync();

            if (saveFile != null)
            {
                string jsonArray = CanvasShapesToJsonArray(this.DrawingCanvas);

                await FileIO.WriteTextAsync(saveFile, jsonArray);
                await new MessageDialog("File Saved!").ShowAsync();
            }
        }

        private string CanvasShapesToJsonArray(Canvas canvas)
        {
            XmlDocument xmlDoc = new XmlDocument();
            var shapes = xmlDoc.CreateElement("Shapes");

            foreach (var child in canvas.Children)
            {
                var line = child as Line;
                if (line != null)
                {
                    SerializeLine(xmlDoc, line, shapes);
                    continue;
                }

                var rectangle = child as Rectangle;
                if (rectangle != null)
                {
                    SerizlizeRectangle(xmlDoc, rectangle, shapes);
                    continue;
                }

                var ellipse = child as Ellipse;
                if (ellipse != null)
                {
                    SerializeEllipse(xmlDoc, ellipse, shapes);
                    continue;
                }
            }

            xmlDoc.AppendChild(shapes);

            return xmlDoc.GetXml();
        }
  
        private void SerializeEllipse(XmlDocument xmlDoc, Ellipse ellipse, XmlElement shapes)
        {
            var ellipseNode = xmlDoc.CreateElement("ellipse");
            ellipseNode.SetAttribute("Top", ellipse.Margin.Top.ToString());
            ellipseNode.SetAttribute("Left", ellipse.Margin.Left.ToString());
            ellipseNode.SetAttribute("Right", ellipse.Margin.Right.ToString());
            ellipseNode.SetAttribute("Bottom", ellipse.Margin.Bottom.ToString());
            ellipseNode.SetAttribute("Height", ellipse.Height.ToString());
            ellipseNode.SetAttribute("Width", ellipse.Width.ToString());
            ellipseNode.SetAttribute("StrokeThickness", ellipse.StrokeThickness.ToString());
            var colorNode = xmlDoc.CreateElement("color");
            var color = ((SolidColorBrush)ellipse.Stroke).Color;
            colorNode.SetAttribute("A", color.A.ToString());
            colorNode.SetAttribute("B", color.B.ToString());
            colorNode.SetAttribute("R", color.R.ToString());
            colorNode.SetAttribute("G", color.G.ToString());
            ellipseNode.AppendChild(colorNode);
            shapes.AppendChild(ellipseNode);
        }
  
        private void SerizlizeRectangle(XmlDocument xmlDoc, Rectangle rectangle, XmlElement shapes)
        {
            var rectangleNode = xmlDoc.CreateElement("rectangle");
            rectangleNode.SetAttribute("Top", rectangle.Margin.Top.ToString());
            rectangleNode.SetAttribute("Left", rectangle.Margin.Left.ToString());
            rectangleNode.SetAttribute("Right", rectangle.Margin.Right.ToString());
            rectangleNode.SetAttribute("Bottom", rectangle.Margin.Bottom.ToString());
            rectangleNode.SetAttribute("Height", rectangle.Height.ToString());
            rectangleNode.SetAttribute("Width", rectangle.Width.ToString());
            rectangleNode.SetAttribute("StrokeThickness", rectangle.StrokeThickness.ToString());
            var colorNode = xmlDoc.CreateElement("color");
            var color = ((SolidColorBrush)rectangle.Stroke).Color;
            colorNode.SetAttribute("A", color.A.ToString());
            colorNode.SetAttribute("B", color.B.ToString());
            colorNode.SetAttribute("R", color.R.ToString());
            colorNode.SetAttribute("G", color.G.ToString());
            rectangleNode.AppendChild(colorNode);
            shapes.AppendChild(rectangleNode);
        }
  
        private void SerializeLine(XmlDocument xmlDoc, Line line, XmlElement shapes)
        {
            var lineNode = xmlDoc.CreateElement("line");
            lineNode.SetAttribute("X1", line.X1.ToString());
            lineNode.SetAttribute("X2", line.X2.ToString());
            lineNode.SetAttribute("Y1", line.Y1.ToString());
            lineNode.SetAttribute("Y2", line.Y2.ToString());
            lineNode.SetAttribute("StrokeThickness", line.StrokeThickness.ToString());
            var colorNode = xmlDoc.CreateElement("color");
            var color = ((SolidColorBrush)line.Stroke).Color;
            colorNode.SetAttribute("A", color.A.ToString());
            colorNode.SetAttribute("B", color.B.ToString());
            colorNode.SetAttribute("R", color.R.ToString());
            colorNode.SetAttribute("G", color.G.ToString());
            lineNode.AppendChild(colorNode);
            shapes.AppendChild(lineNode);
        }

        private void OnCanvasPointerExited(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.Arrow, 1);
        }

        private void OnCanvasPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            newLine = null;
            newRectangle = null;
            newEllipse = null;
        }

        private void OnCanvasPointerMoved(object sender, PointerRoutedEventArgs e)
        {
            switch (currentDrawingTool)
            {
                case DrawingTool.Line:
                    if (e.GetCurrentPoint(this.DrawingCanvas).Properties.IsLeftButtonPressed == true)
                    {
                        newLine.X2 = e.GetCurrentPoint(this.DrawingCanvas).Position.X;
                        newLine.Y2 = e.GetCurrentPoint(this.DrawingCanvas).Position.Y;
                    }
                    break;
                case DrawingTool.Rectangle:
                    if (e.GetCurrentPoint(this.DrawingCanvas).Properties.IsLeftButtonPressed == true)
                    {
                        x2 = e.GetCurrentPoint(this.DrawingCanvas).Position.X;
                        y2 = e.GetCurrentPoint(this.DrawingCanvas).Position.Y;
                        if ((x2 - x1) > 0 && (y2 - y1) > 0)
                        {
                            newRectangle.Margin = new Thickness(x1, y1, x2, y2);
                        }
                        else if ((x2 - x1) < 0)
                        {
                            newRectangle.Margin = new Thickness(x2, y1, x1, y2);
                        }
                        else if ((y2 - y1) < 0)
                        {
                            newRectangle.Margin = new Thickness(x1, y2, x2, y1);
                        }
                        else if ((x2 - x1) < 0 && (y2 - y1) < 0)
                        {
                            newRectangle.Margin = new Thickness(x2, y1, x1, y2);
                        }
                        newRectangle.Width = Math.Abs(x2 - x1);
                        newRectangle.Height = Math.Abs(y2 - y1);
                    }
                    break;
                case DrawingTool.Ellipse:
                    if (e.GetCurrentPoint(this.DrawingCanvas).Properties.IsLeftButtonPressed == true)
                    {
                        x2 = e.GetCurrentPoint(this.DrawingCanvas).Position.X;
                        y2 = e.GetCurrentPoint(this.DrawingCanvas).Position.Y;
                        if ((x2 - x1) > 0 && (y2 - y1) > 0)
                        {
                            newEllipse.Margin = new Thickness(x1, y1, x2, y2);
                        }
                        else if ((x2 - x1) < 0)
                        {
                            newEllipse.Margin = new Thickness(x2, y1, x1, y2);
                        }
                        else if ((y2 - y1) < 0)
                        {
                            newEllipse.Margin = new Thickness(x1, y2, x2, y1);
                        }
                        else if ((x2 - x1) < 0 && (y2 - y1) < 0)
                        {
                            newEllipse.Margin = new Thickness(x2, y1, x1, y2);
                        }
                        newEllipse.Width = Math.Abs(x2 - x1);
                        newEllipse.Height = Math.Abs(y2 - y1);
                    }
                    break;
                default:
                    break;
            }
        }

        private void OnCanvasPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            switch (currentDrawingTool)
            {
                case DrawingTool.Line:
                    {
                        newLine = new Line();
                        newLine.X1 = e.GetCurrentPoint(this.DrawingCanvas).Position.X;
                        newLine.Y1 = e.GetCurrentPoint(this.DrawingCanvas).Position.Y;
                        newLine.X2 = newLine.X1 + 1;
                        newLine.Y2 = newLine.Y1 + 1;
                        newLine.StrokeThickness = strokeThickness;
                        newLine.Stroke = new SolidColorBrush(borderColor);
                        this.DrawingCanvas.Children.Add(newLine);
                    }
                    break;
                case DrawingTool.Rectangle:
                    { 
                        newRectangle = new Rectangle();
                        x1 = e.GetCurrentPoint(this.DrawingCanvas).Position.X;
                        y1 = e.GetCurrentPoint(this.DrawingCanvas).Position.Y;
                        x2 = x1;
                        y2 = y1;
                        newRectangle.Width = x2 - x1;
                        newRectangle.Height = y2 - y1;
                        newRectangle.StrokeThickness = strokeThickness;
                        newRectangle.Stroke = new SolidColorBrush(borderColor);
                        this.DrawingCanvas.Children.Add(newRectangle);
                    }
                    break;
                case DrawingTool.Ellipse:
                    {
                        newEllipse = new Ellipse();
                        x1 = e.GetCurrentPoint(this.DrawingCanvas).Position.X;
                        y1 = e.GetCurrentPoint(this.DrawingCanvas).Position.Y;
                        x2 = y1;
                        y2 = y1;
                        newEllipse.Width = Math.Abs(x2 - x1);
                        newEllipse.Height = Math.Abs(y2 - y1);
                        newEllipse.StrokeThickness = strokeThickness;
                        newEllipse.Stroke = new SolidColorBrush(borderColor);
                        this.DrawingCanvas.Children.Add(newEllipse);
                    }
                    break;
            }
        }
    }
}