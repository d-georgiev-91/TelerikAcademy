using System;
using System.Linq;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PaintRT
{
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
            currentDrawingTool = DrawingTool.Rectangle;
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
                        newEllipse.Width = x2 - x1;
                        newEllipse.Height = y2 - y1;
                        newEllipse.StrokeThickness = strokeThickness;
                        newEllipse.Stroke = new SolidColorBrush(borderColor);
                        this.DrawingCanvas.Children.Add(newEllipse);
                    }
                    break;
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RotatingCanvas.RenderTransform = canvasRotation;
        }

        private void RotatingCanvasManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            canvasRotation.CenterX = this.DrawingCanvas.Width / 2;
            canvasRotation.CenterY = this.DrawingCanvas.Height / 2 ;
            canvasRotation.Angle += e.Delta.Rotation >= 0 ? 90 : -90;
        }
    }
}