using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        }
        private void BtnAuswerten_Click(object sender, RoutedEventArgs e)
        {
            btnAuswerten.Content = "Erneut Auswerten";
            textBox.Text = "";
            decimal highest = -273;
            var reader = new StreamReader(@"C:\Users\Ege Ata\Downloads\MaxiTemp-main\MaxiTemp-main\MaxTemp\MaxTemp\temps.csv");
            textBox.Text = "Diese Server sind zu heiß: \n";

            int counter = 0;
            while (!reader.EndOfStream)
            {
                var curLine = reader.ReadLine().Split(',');

                if (Convert.ToDecimal(curLine[curLine.Length - 1]) / 10 > highest)
                {
                    highest = Convert.ToDecimal(curLine[curLine.Length - 1]) / 10;

                    if (highest > 35)
                    {
                        textBox.Text += " [" + curLine[0] + " " + curLine[curLine.Length - 1] + "°C]";
                        counter++;
                        if (counter > 3)
                        {
                            counter = 0;
                            textBox.Text += "\n";
                        }
                    }
                }
            }
            reader.Close();
        }
    }
}
