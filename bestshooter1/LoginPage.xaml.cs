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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                if (string.IsNullOrEmpty(txtPurchaseCode.Text.Trim()) == false)
                {
                    int res = Utilities.Login(txtPurchaseCode.Text.Trim());
                    switch (res)
                    {
                        case 0:
                            MBox2 message = new MBox2("پیام", "خوش آمدید");
                            message.ShowDialog();
                            MainWindow mw = new MainWindow(txtPurchaseCode.Text.Trim());
                            mw.Show();
                            this.Close();
                            break;
                        case 1:
                            MBox2 message2 = new MBox2("خطا", "چنین شناسه ای معتبر نیست");
                            message2.ShowDialog();
                            break;
                        case 2:
                            MBox2 message3 = new MBox2("خطا", "مشکل در وصل شدن به مرجع.اینترنت خود را چک کنید یا با مسئول سایت تماس بگیرید");
                            message3.ShowDialog();
                            break;
                        case 3:
                            MBox2 message4 = new MBox2("خطا", "مشکل در برنامه.مجددا امتحان کنید");
                            message4.ShowDialog();
                            break;
                    }
                }
                else
                {
                    MBox2 message5 = new MBox2("هشدار", "شناسه را وارد کنید");
                    message5.ShowDialog();
                }
                this.Cursor = null;
            }
            catch (Exception)
            {
            }
        }

        private void txtPurchaseCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                if (e.Key == Key.Enter)
                {
                    if (string.IsNullOrEmpty(txtPurchaseCode.Text.Trim()) == false)
                    {
                        int res = Utilities.Login(txtPurchaseCode.Text.Trim());
                        switch (res)
                        {
                            case 0:
                                MBox2 message = new MBox2("پیام", "خوش آمدید");
                                message.ShowDialog();
                                MainWindow mw = new MainWindow(txtPurchaseCode.Text.Trim());
                                mw.Show();
                                this.Close();
                                break;
                            case 1:
                                MBox2 message2 = new MBox2("خطا", "چنین شناسه ای معتبر نیست");
                                message2.ShowDialog();
                                break;
                            case 2:
                                MBox2 message3 = new MBox2("خطا", "مشکل در وصل شدن به مرجع.اینترنت خود را چک کنید یا با مسئول سایت تماس بگیرید");
                                message3.ShowDialog();
                                break;
                            case 3:
                                MBox2 message4 = new MBox2("خطا", "مشکل در برنامه.مجددا امتحان کنید");
                                message4.ShowDialog();
                                break;
                        }
                    }
                    else
                    {
                        MBox2 message5 = new MBox2("هشدار", "شناسه را وارد کنید");
                        message5.ShowDialog();
                    }
                }
                this.Cursor = null;
            }
            catch (Exception)
            {
            }
        }
    }
}
