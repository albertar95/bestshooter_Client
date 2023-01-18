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
using System.Windows.Shapes;

namespace bestshooter1
{
    /// <summary>
    /// Interaction logic for MBox2.xaml
    /// </summary>
    public partial class MBox2 : Window
    {
        string b = "";
        string h = "";
        public MBox2(string header,string body)
        {
            b = body;
            h = header;
            InitializeComponent();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                this.Close();
                this.Cursor = null;
            }
            catch (Exception)
            {
            }
        }

        private void MBody_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = sender as TextBlock;
            tb.Text = b;
        }

        private void MHeader_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = sender as TextBlock;
            tb.Text = h;
        }
    }
}
