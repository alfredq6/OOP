using _2lab13.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2lab13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<ShapeFactory> shapes;
        private List<UIElement> Shapes;

        public MainWindow()
        {
            InitializeComponent();
            Shapes = new List<UIElement>();
            shapes = new List<ShapeFactory>();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var win = new CreateWin();
            var list = new List<ShapeFactory>();
            if (win.ShowDialog() == true)
            {
                var i = 0;
                var num = win.ShapesNumber.SelectedIndex + 1;
                switch (win.ShapesType.SelectedIndex)
                {
                    case 0:
                        {
                            while (i < num)
                            {
                                var shape = new Shapes.Ellipse();
                                shapes.Add(shape);
                                list.Add(shape);
                                i++;
                            }
                            break;
                        }
                    case 1:
                        {
                            while (i < num)
                            {
                                var shape = new Shapes.Rectangle();
                                shapes.Add(shape);
                                list.Add(shape);
                                i++;
                            }
                            break;
                        }
                }
                ShowShapes(list);
            }

        }   

        private void ShowShapes(List<ShapeFactory> _shapes)
        {
            var list = new List<Shape>();
            foreach (var el in _shapes)
            {
                if (el is Shapes.Ellipse)
                    list.Add(new System.Windows.Shapes.Ellipse()
                    {
                        Fill = el.FillColor,
                        Width = el.Width,
                        Height = el.Height
                    });
                if (el is Shapes.Rectangle)
                    list.Add(new System.Windows.Shapes.Rectangle()
                    {
                        Fill = el.FillColor,
                        Width = el.Width,
                        Height = el.Height
                    });
            }
            foreach (var el in list)
            {
                el.MouseLeftButtonDown += new MouseButtonEventHandler(Element_MouseLeftButtonDown);
                el.MouseLeftButtonUp += new MouseButtonEventHandler(Element_MouseLeftButtonUp);
                el.MouseMove += new MouseEventHandler(Element_MouseMove);
                ShapesCanvas.Children.Add(el);
            }
            Shapes.AddRange(list);
        }

        private void Clone_Click(object sender, RoutedEventArgs e)
        {
            var clone = shapes.LastOrDefault()?.Clone();
            Shape shape = null;
            if (clone is Shapes.Ellipse)
                shape = new System.Windows.Shapes.Ellipse()
                {
                    Fill = (clone as Shapes.Ellipse).FillColor,
                    Width = (clone as Shapes.Ellipse).Width,
                    Height = (clone as Shapes.Ellipse).Height
                };
            if (clone is Shapes.Ellipse || clone is Shapes.SingletonEllipse)
                shape = new System.Windows.Shapes.Ellipse()
                {
                    Fill = (clone as Shapes.SingletonEllipse).FillColor,
                    Width = (clone as Shapes.SingletonEllipse).Width,
                    Height = (clone as Shapes.SingletonEllipse).Height
                };
            if (clone is Shapes.Rectangle)
                shape = new System.Windows.Shapes.Rectangle()
                {
                    Fill = (clone as Shapes.Rectangle).FillColor,
                    Width = (clone as Shapes.Rectangle).Width,
                    Height = (clone as Shapes.Rectangle).Height
                };
            if (shape != null)
            {
                shape.MouseLeftButtonDown += new MouseButtonEventHandler(Element_MouseLeftButtonDown);
                shape.MouseLeftButtonUp += new MouseButtonEventHandler(Element_MouseLeftButtonUp);
                shape.MouseMove += new MouseEventHandler(Element_MouseMove);
                ShapesCanvas.Children.Add(shape);
                Shapes.Add(shape);
            }
        }

        private void Singleton_Click(object sender, RoutedEventArgs e)
        {
            var singletonEllipse = SingletonEllipse.Get();
            var ellipse = new System.Windows.Shapes.Ellipse()
            {
                Fill = singletonEllipse.FillColor,
                Width = singletonEllipse.Width,
                Height = singletonEllipse.Height
            };
            ellipse.MouseLeftButtonDown += new MouseButtonEventHandler(Element_MouseLeftButtonDown);
            ellipse.MouseLeftButtonUp += new MouseButtonEventHandler(Element_MouseLeftButtonUp);
            ellipse.MouseMove += new MouseEventHandler(Element_MouseMove);
            ShapesCanvas.Children.Add(ellipse);
            Shapes.Add(ellipse);
            shapes?.Add(singletonEllipse);
        }

        private void Complex_Click(object sender, RoutedEventArgs e)
        {
            SingletonEllipseInEllipse complexShape = new SingletonEllipseInEllipse();
            complexShape.CreateComplexShape();
            complexShape.SetOuterShape();
            complexShape.SetInnerShape();
            var grid = new Grid();
            var outEllipse = new System.Windows.Shapes.Ellipse()
            {
                Fill = complexShape.ComplexShape.Ellipse.FillColor,
                Width = complexShape.ComplexShape.Ellipse.Width,
                Height = complexShape.ComplexShape.Ellipse.Height,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            var inEllipse = new System.Windows.Shapes.Ellipse()
            {
                Fill = complexShape.ComplexShape.SingletonEllipse.FillColor,
                Width = complexShape.ComplexShape.SingletonEllipse.Width,
                Height = complexShape.ComplexShape.SingletonEllipse.Height,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            grid.Children.Add(outEllipse);
            grid.Children.Add(inEllipse);
            grid.MouseLeftButtonDown += new MouseButtonEventHandler(Element_MouseLeftButtonDown);
            grid.MouseLeftButtonUp += new MouseButtonEventHandler(Element_MouseLeftButtonUp);
            grid.MouseMove += new MouseEventHandler(Element_MouseMove);
            Shapes.Add(grid);
            ShapesCanvas.Children.Add(grid);
        }

        #region DragShape

        private bool isDragging;
        private Point clickPosition;

        private void Element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            var draggableControl = sender as UIElement;
            clickPosition = e.GetPosition(draggableControl);
            draggableControl.CaptureMouse();
        }

        private void Element_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            var draggable = sender as UIElement;
            draggable.ReleaseMouseCapture();
        }

        private void Element_MouseMove(object sender, MouseEventArgs e)
        {
            var draggableControl = sender as FrameworkElement;

            if (isDragging && draggableControl != null)
            {
                Point currentPosition = e.GetPosition(draggableControl.Parent as UIElement);
                

                Canvas.SetLeft(draggableControl, currentPosition.X - clickPosition.X);
                Canvas.SetTop(draggableControl, currentPosition.Y - clickPosition.Y);
            }
        }

        #endregion

    }
}
