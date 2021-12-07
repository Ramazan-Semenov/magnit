using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nikita.Views.UserControls
{
    /// <summary>
    /// Логика взаимодействия для SVCRTS.xaml
    /// </summary>
    public partial class SVCRTS : Window
    {

        public SVCRTS()
        {
            InitializeComponent();
            ItemsControl itemsControl = new ItemsControl();
         
            DataContext = new f();

            foreach (UIElement uiEle in LayoutRoot.Children)
            {
                if (uiEle is Button || uiEle is TextBox)
                {
                    uiEle.AddHandler(Button.MouseLeftButtonDownEvent, new MouseButtonEventHandler(Element_MouseLeftButtonDown), true);
                    uiEle.AddHandler(Button.MouseMoveEvent, new MouseEventHandler(Element_MouseMove), true);
                    uiEle.AddHandler(Button.MouseLeftButtonUpEvent, new MouseButtonEventHandler(Element_MouseLeftButtonUp), true);
                    continue;
                }
                uiEle.MouseMove += new MouseEventHandler(Element_MouseMove);
                uiEle.MouseLeftButtonDown += new MouseButtonEventHandler(Element_MouseLeftButtonDown);
                uiEle.MouseLeftButtonUp += new MouseButtonEventHandler(Element_MouseLeftButtonUp);
            }
        }

        bool isDragDropInEffect = false;
        Point pos = new Point();

        void Element_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragDropInEffect)
            {
                FrameworkElement currEle = sender as FrameworkElement;
                double xPos = e.GetPosition(null).X - pos.X + currEle.Margin.Left;
                double yPos = e.GetPosition(null).Y - pos.Y + currEle.Margin.Top;
                currEle.Margin = new Thickness(xPos, yPos, 0, 0);
                pos = e.GetPosition(null);
            }
        }


        void Element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            FrameworkElement fEle = sender as FrameworkElement;
            isDragDropInEffect = true;
            pos = e.GetPosition(null);
            fEle.CaptureMouse();
            fEle.Cursor = Cursors.Hand;
        }

        void Element_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isDragDropInEffect)
            {
                FrameworkElement ele = sender as FrameworkElement;
                isDragDropInEffect = false;
                ele.ReleaseMouseCapture();
            }
        }

        private void label1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
         
        }
    }
    class f
    {
        public f()
        {
            Buttons.Add(new ButtonS { Content = "safsd", Background = Brushes.Red, Width = 100, Height = 35 });
            Buttons.Add(new ButtonS { Content = "ccc", Background = Brushes.Green, Width = 100, Height = 35 });
            Buttons.Add(new ButtonS { Content = "safsd", Background = Brushes.DarkBlue, Width = 100, Height = 35 });
            Buttons.Add(new ButtonS { Content = "asdvas", Background = Brushes.Black, Width = 100, Height = 35 });
            Buttons.Add(new ButtonS { Content = "safsd", Background = Brushes.Azure, Width = 100, Height = 35 });

            Combobox.Add(new ComboBox { Text = "sdfs", Background = Brushes.Red, Width = 100, Height = 35  });
        }
        public List<ButtonS> Buttons { get; set; } = new List<ButtonS>();
        public List<ComboBox> Combobox { get; set; } = new List<ComboBox>();
    }

    class ButtonS
    {
       public string Content { get; set; }
     public   Brush Background { get; set; }
     public int   Width { get; set; }
        public int Height  { get; set; }
    }

}

