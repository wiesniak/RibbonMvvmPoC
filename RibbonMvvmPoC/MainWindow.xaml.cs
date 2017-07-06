using GalaSoft.MvvmLight.CommandWpf;
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
using GalaSoft.MvvmLight.Messaging;

namespace RibbonMvvmPoC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<string>(this, ShowWindow);
            Messenger.Default.Register<string>(this, "PrintCanvas", (x) => PrintCanvas());
        }

        private void PrintCanvas()
        {
            PrintDialog prnt = new PrintDialog();
            if (prnt.ShowDialog() == true)
            {
                var controlToPrint = WorkingAreaGrid; // LabelCanvas
                Size pageSize = new Size(prnt.PrintableAreaWidth, prnt.PrintableAreaHeight);
                controlToPrint.Measure(pageSize);
                controlToPrint.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));

                prnt.PrintVisual(controlToPrint, "Printing Canvas");
            }
        }

        private void ShowWindow(string message)
        {
            MessageBox.Show(message);
        }

        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {
            // we don't like events anymore ;-)
            MessageBox.Show("Old way event!");
        }
    }
}
