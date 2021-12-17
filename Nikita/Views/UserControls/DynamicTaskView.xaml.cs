using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Nikita.Views.UserControls
{
    /// <summary>
    /// Логика взаимодействия для DynamicTaskView.xaml
    /// </summary>
    public partial class DynamicTaskView : UserControl
    {
        double FirstXPos, FirstYPos, FirstArrowXPos, FirstArrowYPos;
        object MovingObject;
        Line Path1, Path2, Path3, Path4;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(string.Format("{}"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Button> buttons = new List<Button>();
            List<ButtonS> buttonS1 = new List<ButtonS>();
            foreach (UIElement uiEle in DesigningCanvas.Children)
            {
                if (uiEle is Button /*|| uiEle is TextBox*/)
                {
                    ButtonS buttonS = new ButtonS();
                    buttonS.Content = (uiEle as Button).Content;
                    buttonS.Margin = (uiEle as Button).Margin;
                    buttonS1.Add(buttonS);
                    //MessageBox.Show((uiEle as Button).Margin.ToString()) ;
                }

            }
            Button button = buttons.FirstOrDefault();
            string output = JsonConvert.SerializeObject(buttonS1);
            File.WriteAllText(@"C:\Users\lenovo\Desktop\er.json", output);
            MessageBox.Show("Ok");
        }

        Rectangle FirstPosition, CurrentPosition;
        public DynamicTaskView()
        {
            InitializeComponent();
           DesigningCanvas.Children.Add(new Button { Content = "Button", Width = 100, Height = 35 });

            foreach (var item in new f().Buttons)
            {
                Label button = new Label();
                button.Margin = item.Margin;
                button.Content = item.Content.ToString();
                button.Width = item.Width;
                button.Height = item.Height;

                DesigningCanvas.Children.Add(button);

            }
            /*
             * Assigning PreviewMouseLeftButtonDown, PreviewMouseMove and PreviewMouseLeftButtonUp
             * events to each controls on our canvas control.
             * Some controls events like TextBox's MouseLeftButtonDown doesn't fire, because of that
             * we use Preview events.
             */
            foreach (Control control in DesigningCanvas.Children)
            {
                control.PreviewMouseLeftButtonDown += this.MouseLeftButtonDown;
                control.PreviewMouseLeftButtonUp += this.PreviewMouseLeftButtonUp;
                control.Cursor = Cursors.Hand;
            }

            // Setting the MouseMove event for our parent control(In this case it is DesigningCanvas).
            DesigningCanvas.PreviewMouseMove += this.MouseMove;

            // Setting up the Lines that we want to show the path of movement
            List<Double> Dots = new List<double>();
            Dots.Add(1);
            Dots.Add(2);
            Path1 = new Line();
            Path1.Width = DesigningCanvas.Width;
            Path1.Height = DesigningCanvas.Height;
            Path1.Stroke = Brushes.DarkGray;
            Path1.StrokeDashArray = new DoubleCollection(Dots);

            Path2 = new Line();
            Path2.Width = DesigningCanvas.Width;
            Path2.Height = DesigningCanvas.Height;
            Path2.Stroke = Brushes.DarkGray;
            Path2.StrokeDashArray = new DoubleCollection(Dots);

            Path3 = new Line();
            Path3.Width = DesigningCanvas.Width;
            Path3.Height = DesigningCanvas.Height;
            Path3.Stroke = Brushes.DarkGray;
            Path3.StrokeDashArray = new DoubleCollection(Dots);

            Path4 = new Line();
            Path4.Width = DesigningCanvas.Width;
            Path4.Height = DesigningCanvas.Height;
            Path4.Stroke = Brushes.DarkGray;
            Path4.StrokeDashArray = new DoubleCollection(Dots);

            FirstPosition = new Rectangle();
            FirstPosition.Stroke = Brushes.DarkGray;
            FirstPosition.StrokeDashArray = new DoubleCollection(Dots);

            CurrentPosition = new Rectangle();
            CurrentPosition.Stroke = Brushes.DarkGray;
            CurrentPosition.StrokeDashArray = new DoubleCollection(Dots);

            // Adding Lines to main designing panel(Canvas)
            DesigningCanvas.Children.Add(Path1);
            DesigningCanvas.Children.Add(Path2);
            DesigningCanvas.Children.Add(Path3);
            DesigningCanvas.Children.Add(Path4);
            DesigningCanvas.Children.Add(FirstPosition);
            DesigningCanvas.Children.Add(CurrentPosition);
        }
        void PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // In this event, we should set the lines visibility to Hidden
            MovingObject = null;
            Path1.Visibility = System.Windows.Visibility.Hidden;
            Path2.Visibility = System.Windows.Visibility.Hidden;
            Path3.Visibility = System.Windows.Visibility.Hidden;
            Path4.Visibility = System.Windows.Visibility.Hidden;
            FirstPosition.Visibility = System.Windows.Visibility.Hidden;
            CurrentPosition.Visibility = System.Windows.Visibility.Hidden;
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            /*
             * In this event, at first we check the mouse left button state. If it is pressed and 
             * event sender object is similar with our moving object, we can move our control with
             * some effects.
             */
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // We start to moving objects with setting the lines positions.
                Path1.X1 = FirstArrowXPos;
                Path1.Y1 = FirstArrowYPos;
                Path1.X2 = e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).X - FirstXPos;
                Path1.Y2 = e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).Y - FirstYPos;

                Path2.X1 = Path1.X1 + (MovingObject as FrameworkElement).ActualWidth;
                Path2.Y1 = Path1.Y1;
                Path2.X2 = Path1.X2 + (MovingObject as FrameworkElement).ActualWidth;
                Path2.Y2 = Path1.Y2;

                Path3.X1 = Path1.X1;
                Path3.Y1 = Path1.Y1 + (MovingObject as FrameworkElement).ActualHeight;
                Path3.X2 = Path1.X2;
                Path3.Y2 = Path1.Y2 + (MovingObject as FrameworkElement).ActualHeight;

                Path4.X1 = Path1.X1 + (MovingObject as FrameworkElement).ActualWidth;
                Path4.Y1 = Path1.Y1 + (MovingObject as FrameworkElement).ActualHeight;
                Path4.X2 = Path1.X2 + (MovingObject as FrameworkElement).ActualWidth;
                Path4.Y2 = Path1.Y2 + (MovingObject as FrameworkElement).ActualHeight;

                FirstPosition.Width = (MovingObject as FrameworkElement).ActualWidth;
                FirstPosition.Height = (MovingObject as FrameworkElement).ActualHeight;
                FirstPosition.SetValue(Canvas.LeftProperty, FirstArrowXPos);
                FirstPosition.SetValue(Canvas.TopProperty, FirstArrowYPos);

                CurrentPosition.Width = (MovingObject as FrameworkElement).ActualWidth;
                CurrentPosition.Height = (MovingObject as FrameworkElement).ActualHeight;
                CurrentPosition.SetValue(Canvas.LeftProperty, Path1.X2);
                CurrentPosition.SetValue(Canvas.TopProperty, Path1.Y2);

                Path1.Visibility = System.Windows.Visibility.Visible;
                Path2.Visibility = System.Windows.Visibility.Visible;
                Path3.Visibility = System.Windows.Visibility.Visible;
                Path4.Visibility = System.Windows.Visibility.Visible;
                FirstPosition.Visibility = System.Windows.Visibility.Visible;
                CurrentPosition.Visibility = System.Windows.Visibility.Visible;

                /*
                 * For changing the position of a control, we should use the SetValue method to setting
                 * the Canvas.LeftProperty and Canvas.TopProperty dependencies.
                 * 
                 * For calculating the currect position of the control, we should do :
                 *      Current position of the mouse cursor on the object parent - 
                 *      Mouse position on the control at the start of moving -
                 *      position of the control's parent.
                 */
                (MovingObject as FrameworkElement).SetValue(Canvas.LeftProperty,
                    e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).X - FirstXPos);

                (MovingObject as FrameworkElement).SetValue(Canvas.TopProperty,
                    e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).Y - FirstYPos);
                
            }
        }

        private void MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //In this event, we get current mouse position on the control to use it in the MouseMove event.
            FirstXPos = e.GetPosition(sender as Control).X;
            FirstYPos = e.GetPosition(sender as Control).Y;
            FirstArrowXPos = e.GetPosition((sender as Control).Parent as Control).X - FirstXPos;
            FirstArrowYPos = e.GetPosition((sender as Control).Parent as Control).Y - FirstYPos;
            MovingObject = sender;
        }
    }
}
