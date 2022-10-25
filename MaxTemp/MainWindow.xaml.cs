using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace MaxTemp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //lblAusgabe.Content = "a";
        }

        private void BtnAuswerten_Click(object sender, RoutedEventArgs e)
        {
            decimal highest = -273;
            var reader = new StreamReader(@"H:\Jahr1\BfK-S\MaxTemp\MaxTemp\temps.csv");

            while (!reader.EndOfStream)
            {
                var curLine = reader.ReadLine().Split(',');

                
                if (Convert.ToDecimal(curLine[curLine.Length-1]) / 10 > highest)
                {
                    highest = Convert.ToDecimal(curLine[curLine.Length - 1]) / 10;
                }

            }
            reader.Close();

            //MessageBox.Show("Highest value in data: " + highest);
            lblAusgabe.Content = highest;
        }
    }
}
