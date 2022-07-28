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

namespace Task_003
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            new Presenter(this);
        }

        private EventHandler start;
        private EventHandler stop;
        private EventHandler reset;

        public event EventHandler Start 
        {
            add { start += value; }
            remove { start -= value; }
        }

        public event EventHandler Stop
        {
            add { stop += value; }
            remove { stop -= value; }
        }

        public event EventHandler Reset
        {
            add { reset += value; }
            remove { reset -= value; }
        }

        private void Button_Click_Start(object sender, RoutedEventArgs e)
            => start.Invoke(sender, e);

        private void Button_Click_Stop(object sender, RoutedEventArgs e)
            => stop.Invoke(sender, e);

        private void Button_Click_Reset(object sender, RoutedEventArgs e)
            => reset.Invoke(sender, e);
    }
}
