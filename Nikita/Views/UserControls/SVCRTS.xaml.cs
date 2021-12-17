using Newtonsoft.Json;
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
            UIElement uI = new UIElement();
            foreach (var item in new f().Buttons)
            {
                Label button = new Label();
                button.Margin = item.Margin;
                button.Content = item.Content.ToString();
                button.Width = item.Width;
                button.Height = item.Height;

                LayoutRoot.Children.Add(button);

            }
            Paint();
        }

        private void Paint()
        {
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
                //FrameworkElement currEle = sender as FrameworkElement;
                //double xPos = e.GetPosition(null).X - (pos.X) + currEle.Margin.Left;
                //double yPos = e.GetPosition(null).Y - (pos.Y) + currEle.Margin.Top;
                //currEle.Margin = new Thickness(xPos, yPos, 0, 0);
                //pos = e.GetPosition(null);
                FrameworkElement currEle = sender as FrameworkElement;
                double xPos = e.GetPosition(LayoutRoot).X - (pos.X) + currEle.Margin.Left;
                double yPos = e.GetPosition(LayoutRoot).Y - (pos.Y) + currEle.Margin.Top;
                currEle.Margin = new Thickness(xPos, yPos, 0, 0);
                pos = e.GetPosition(LayoutRoot);
            }
        }


        void Element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            FrameworkElement fEle = sender as FrameworkElement;
            isDragDropInEffect = true;
            pos = e.GetPosition(LayoutRoot);
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
        private void AddButton(object sender, RoutedEventArgs e)
        {
            LayoutRoot.Children.Add(new Button { Content = "Button", Width = 100, Height = 35 });
            Paint();
        }
        private void AddLable(object sender, RoutedEventArgs e)
        {
            LayoutRoot.Children.Add(new Label { Content = "Label", Width = 100, Height = 35 });
            Paint();

        }
        private void AddTextBox(object sender, RoutedEventArgs e)
        {
            LayoutRoot.Children.Add(new TextBox { Text = "",  Width = 100, Height = 35 });
            Paint();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Button> buttons = new List<Button>();
            List<ButtonS> buttonS1 = new List<ButtonS>();
            foreach (UIElement uiEle in LayoutRoot.Children)
            {
                if (uiEle is TextBox /*|| uiEle is TextBox*/)
                {
                    ButtonS buttonS = new ButtonS();
                    buttonS.Content = (uiEle as TextBox).Text;
                    buttonS.Margin = (uiEle as TextBox).Margin;
                    buttonS1.Add(buttonS);
                    //MessageBox.Show((uiEle as Button).Margin.ToString()) ;
                }
          
            }
            Button button = buttons.FirstOrDefault();
            string output = JsonConvert.SerializeObject(buttonS1);
            File.WriteAllText(@"C:\Users\lenovo\Desktop\er.json", output);
          //  MessageBox.Show(button.Margin.ToString()) ;
        }
    }
    class f
    {
        public f()
        {
            //Buttons.Add(new ButtonS { Content = "safsd", Background = Brushes.Red, Margin= new Thickness(127, 60, 0, 0) });
            //Buttons.Add(new ButtonS { Content = "ccc", Background = Brushes.Green, });
            //Buttons.Add(new ButtonS { Content = "safsd", Background = Brushes.DarkBlue,  });
            //Buttons.Add(new ButtonS { Content = "asdvas", Background = Brushes.Black, });
            //Buttons.Add(new ButtonS { Content = "safsd", Background = Brushes.Azure,  });
            string txt = File.ReadAllText(@"C:\Users\lenovo\Desktop\er.json");
            Buttons = JsonConvert.DeserializeObject<List<ButtonS>>(txt); ;
            Combobox.Add(new ComboBox { Text = "sdfs", Background = Brushes.Red, Width = 100, Height = 35  });
        }
        public List<ButtonS> Buttons { get; set; } = new List<ButtonS>();
        public List<ComboBox> Combobox { get; set; } = new List<ComboBox>();
    }

    class ButtonS
    {
       public Object Content { get; set; }
     public   Brush Background { get; set; }
     public Thickness Margin { get; set; }
        public int Width { get; set; } = 100;
        public int Height { get; set; } = 35; 
    }

}

