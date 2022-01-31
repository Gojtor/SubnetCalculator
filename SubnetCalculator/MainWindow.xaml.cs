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

namespace SubnetCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                outputBin.Content = ToBin(int.Parse(input.Text));
            }
            if (e.Key == Key.RightShift)
            {
                outputDec.Content = ToDec(input.Text);
            }
            if (e.Key == Key.Tab)
            {
                outputMaskBin.Content = ToBinMask(int.Parse(input.Text));
                outputMaskDec.Content = ToDecMask(int.Parse(input.Text));
            }
        }
         public string ToBin(int inputDec)
            {
                string binaryValue = Convert.ToString(inputDec, 2);
                return binaryValue;
            }
        public int ToDec(string inputBin)
            {
                int decimalValue = Convert.ToInt32(inputBin, 2);
                return decimalValue;
            }
        public string ToBinMask(int maskLength)
        {
            string binaryForm = "";
            for (int i = 0; i < maskLength; i++)
            {
                binaryForm += "1";
            }
            while (binaryForm.Length < 32)
            {
                binaryForm += "0";
            }
            binaryForm = binaryForm.Insert(8, ".");
            binaryForm = binaryForm.Insert(17, ".");
            binaryForm = binaryForm.Insert(26, ".");

            return binaryForm;
        }
        public string ToDecMask(int maskLength)
        {
            string maskInBin = ToBinMask(maskLength);
            string[] octetValues = maskInBin.Split('.');
            string maskInDec = "";
            for (int i = 0; i < octetValues.Length; i++)
            {
                if (i == octetValues.Length - 1)
                {
                    maskInDec += Convert.ToString(ToDec(octetValues[i]));
                }
                else
                {
                    maskInDec+=Convert.ToString(ToDec(octetValues[i]))+'.';
                }
            }
            return maskInDec;
        }
    }
}
