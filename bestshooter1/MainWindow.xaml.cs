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
using System.IO.Compression;
using System.IO;
using System.Security.AccessControl;

namespace bestshooter1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static MyAppPack information { get; set; }
        static string entrance { get; set; }

        public MainWindow(string EnteranceId)
        {
            var info = Utilities.getInfo(EnteranceId);
            entrance = EnteranceId;
            if (info != null)
            {
                information = info;

            }
            InitializeComponent();
        }

        private void first_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                System.Diagnostics.Process.Start("http://bestshooter.ir");
                this.Cursor = null;
            }
            catch (Exception)
            {
            }
        }

        private void GameName_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (information != null)
                {
                    TextBlock tb = sender as TextBlock;
                    tb.Text = "نام بازی : " + information.GameName;
                }
                else
                {
                    TextBlock tb = sender as TextBlock;
                    tb.Text = "مشکل در سیستم : اطلاعاتی از مرجع دریافت نشد.لطفا با مسئول سایت تماس بگیرید";
                }
            }
            catch (Exception)
            {
            }
        }

        private void packs_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ListBox list = sender as ListBox;
                if (information != null)
                {
                    if (information.Package1 != null)
                        list.Items.Add(new ListBoxItem() { Content = "نام : " + " " + information.Package1 + "\t" + "ظرفیت این پکیج : " + information.Pachage1Cap });
                    if (information.Package2 != null)
                        list.Items.Add(new ListBoxItem() { Content = "نام : " + " " + information.Package2 + "\t" + "ظرفیت این پکیج : " + information.Package2Cap });
                    if (information.Package3 != null)
                        list.Items.Add(new ListBoxItem() { Content = "نام : " + " " + information.Package3 + "\t" + "ظرفیت این پکیج : " + information.Package3Cap });
                    if (information.Package4 != null)
                        list.Items.Add(new ListBoxItem() { Content = "نام : " + " " + information.Package4 + "\t" + "ظرفیت این پکیج : " + information.Package4Cap });
                    if (information.Package5 != null)
                        list.Items.Add(new ListBoxItem() { Content = "نام : " + " " + information.Package5 + "\t" + "ظرفیت این پکیج : " + information.Package5Cap });
                    if (information.Package6 != null)
                        list.Items.Add(new ListBoxItem() { Content = "نام : " + " " + information.Package6 + "\t" + "ظرفیت این پکیج : " + information.Package6Cap });
                    if (information.Package7 != null)
                        list.Items.Add(new ListBoxItem() { Content = "نام : " + " " + information.Package7 + "\t" + "ظرفیت این پکیج : " + information.Package7Cap });
                    if (information.Package8 != null)
                        list.Items.Add(new ListBoxItem() { Content = "نام : " + " " + information.Package8 + "\t" + "ظرفیت این پکیج : " + information.Package8Cap });
                    if (information.Package9 != null)
                        list.Items.Add(new ListBoxItem() { Content = "نام : " + " " + information.Package9 + "\t" + "ظرفیت این پکیج : " + information.Package9Cap });
                    if (information.Package10 != null)
                        list.Items.Add(new ListBoxItem() { Content = "نام : " + " " + information.Package10 + "\t" + "ظرفیت این پکیج : " + information.Package10Cap });
                }
                else
                {
                    list.Items.Add(new ListBoxItem() { Content = "هیچ پکیجی یافت نشد", IsEnabled = false });
                }
            }
            catch (Exception)
            {
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                int index = packs.SelectedIndex;
                string Id = "";
                if (index != -1)
                {
                    int? selected = 0;
                    switch (index)
                    {
                        case 1:
                            Id = information.GameName + information.Package1;
                            selected = information.Pachage1Cap;
                            break;
                        case 2:
                            Id = information.GameName + information.Package2;
                            selected = information.Package2Cap;
                            break;
                        case 3:
                            Id = information.GameName + information.Package3;
                            selected = information.Package3Cap;
                            break;
                        case 4:
                            Id = information.GameName + information.Package4;
                            selected = information.Package4Cap;
                            break;
                        case 5:
                            Id = information.GameName + information.Package5;
                            selected = information.Package5Cap;
                            break;
                        case 6:
                            Id = information.GameName + information.Package6;
                            selected = information.Package6Cap;
                            break;
                        case 7:
                            Id = information.GameName + information.Package7;
                            selected = information.Package7Cap;
                            break;
                        case 8:
                            Id = information.GameName + information.Package8;
                            selected = information.Package8Cap;
                            break;
                        case 9:
                            Id = information.GameName + information.Package9;
                            selected = information.Package9Cap;
                            break;
                        case 10:
                            Id = information.GameName + information.Package10;
                            selected = information.Package10Cap;
                            break;
                    }
                    if (Id != "")
                    {
                        if (selected > 0)
                        {
                            byte[] file = Utilities.FetchFiles(Id);
                            if (file != null)
                            {
                                string extractpath = "";
                                string zippath = "";

                                if (Environment.Is64BitOperatingSystem)
                                {
                                    extractpath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Bloody5\\Bloody5\\Data\\RES\\English\\ScriptsMacros\\GunLib";
                                }
                                else
                                {
                                    extractpath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Bloody5\\Bloody5\\Data\\RES\\English\\ScriptsMacros\\GunLib";
                                }
                                if (extractpath != "")
                                {
                                    zippath = extractpath + "\\" + Id;
                                }
                                else
                                {
                                    var res = MessageBox.Show("برنامه در یافتن پوشه اصلی ویندوز مشکل دارد.لطفا پوشه(درایو) اصلی ویندوز را معرفی کنید", "خطا", MessageBoxButton.OKCancel);
                                    if (res == MessageBoxResult.OK)
                                    {
                                        System.Windows.Forms.FolderBrowserDialog fb = new System.Windows.Forms.FolderBrowserDialog() { Description = "انتخاب پوشه اصلی ویندوز", RootFolder = Environment.SpecialFolder.MyComputer, ShowNewFolderButton = false };
                                        var fol = fb.ShowDialog();
                                        if (fol == System.Windows.Forms.DialogResult.OK)
                                        {
                                            string root = fb.SelectedPath;
                                            DirectoryInfo di = new DirectoryInfo(root);
                                            if (di.Parent == null)
                                            {
                                                zippath = root + "ProgramFiles\\Bloody5\\Bloody5\\Data\\RES\\English\\ScriptsMacros\\GunLib" + "\\" + Id;
                                            }
                                            else
                                            {
                                                MBox2 message = new MBox2("خطا", "پوشه معتبر نیست");
                                                message.ShowDialog();
                                                this.Cursor = null;
                                                return;
                                            }
                                        }
                                    }
                                }
                                //check for zip
                                if (zippath != "")
                                {
                                    //we have file and folder
                                    if (Directory.Exists(zippath))
                                    {
                                        // should delete folder
                                        var finfolder = Directory.GetFiles(zippath);
                                        if (finfolder.Length != 0)
                                        {
                                            var res1 = MessageBox.Show("این پکیج هم اکنون در سیستم شما موجود است.آیا مایلید دوباره از این پکیج استفاده کنید؟ \n \n \n نکته:این عمل از ظرفیت شما کم خواهد کرد", "هشدار", MessageBoxButton.YesNo);
                                            if (res1 == MessageBoxResult.Yes)
                                            {
                                                //wanna replace
                                                if (zippath != "")
                                                {
                                                    Utilities.DeleteFilesAndFoldersRecursively(zippath);
                                                }
                                                else
                                                {
                                                    //should break
                                                    MBox2 message1 = new MBox2("خطا", "مشکل در حذف کردن پوشه فعلی.لطفا مجددا امتحان کنید");
                                                    message1.ShowDialog();
                                                    this.Cursor = null;
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                //should break
                                                this.Cursor = null;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            //corrupted folder
                                            if (zippath != "")
                                            {
                                                Utilities.DeleteFilesAndFoldersRecursively(zippath);
                                            }
                                            else
                                            {
                                                //should break
                                                MBox2 message3 = new MBox2("خطا", "مشکل در حذف کردن پوشه فعلی.لطفا مجددا امتحان کنید");
                                                message3.ShowDialog();
                                                this.Cursor = null;
                                                return;
                                            }

                                        }
                                    }
                                    //do add
                                    DirectorySecurity sec = new DirectorySecurity();
                                    sec.AddAccessRule(new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Allow));
                                    Directory.CreateDirectory(zippath, sec);
                                    File.WriteAllBytes(zippath + "\\file.zip", file);
                                    ZipFile.ExtractToDirectory(zippath + "\\file.zip", zippath);
                                    if (File.Exists(zippath + "\\file.zip"))
                                    {
                                        File.Delete(zippath + "\\file.zip");
                                        Utilities.UpdateCap(entrance, Id.Substring(information.GameName.Length));
                                        MBox2 message4 = new MBox2("پیام", "پکیج با موفقیت در سیستم شما قرار گرفت");
                                        message4.ShowDialog();
                                        information = Utilities.getInfo(entrance);
                                        packs.Items.Clear();
                                        ListBox list = packs;
                                        if (information != null)
                                        {
                                            list.Items.Add(new ListBoxItem() { Content = "لطفا پکیج را انتخاب کنید", IsEnabled = false });
                                            if (information.Package1 != null)
                                                list.Items.Add(new ListBoxItem() { Content = "نام : " + " " + information.Package1 + "\t" + "ظرفیت این پکیج : " + information.Pachage1Cap });
                                            if (information.Package2 != null)
                                                list.Items.Add(new ListBoxItem() { Content = "نام : " + " " + information.Package2 + "\t" + "ظرفیت این پکیج : " + information.Package2Cap });
                                            if (information.Package3 != null)
                                                list.Items.Add(new ListBoxItem() { Content = "نام : " + " " + information.Package3 + "\t" + "ظرفیت این پکیج : " + information.Package3Cap });
                                            if (information.Package4 != null)
                                                list.Items.Add(new ListBoxItem() { Content = "نام : " + " " + information.Package4 + "\t" + "ظرفیت این پکیج : " + information.Package4Cap });
                                            if (information.Package5 != null)
                                                list.Items.Add(new ListBoxItem() { Content = "نام : " + " " + information.Package5 + "\t" + "ظرفیت این پکیج : " + information.Package5Cap });
                                            if (information.Package6 != null)
                                                list.Items.Add(new ListBoxItem() { Content = "نام : " + " " + information.Package6 + "\t" + "ظرفیت این پکیج : " + information.Package6Cap });
                                            if (information.Package7 != null)
                                                list.Items.Add(new ListBoxItem() { Content = "نام : " + " " + information.Package7 + "\t" + "ظرفیت این پکیج : " + information.Package7Cap });
                                            if (information.Package8 != null)
                                                list.Items.Add(new ListBoxItem() { Content = "نام : " + " " + information.Package8 + "\t" + "ظرفیت این پکیج : " + information.Package8Cap });
                                            if (information.Package9 != null)
                                                list.Items.Add(new ListBoxItem() { Content = "نام : " + " " + information.Package9 + "\t" + "ظرفیت این پکیج : " + information.Package9Cap });
                                            if (information.Package10 != null)
                                                list.Items.Add(new ListBoxItem() { Content = "نام : " + " " + information.Package10 + "\t" + "ظرفیت این پکیج : " + information.Package10Cap });
                                        }
                                        else
                                        {
                                            list.Items.Add(new ListBoxItem() { Content = "هیچ پکیجی یافت نشد", IsEnabled = false });
                                        }

                                    }
                                    else
                                    {
                                        MBox2 message5 = new MBox2("خطا", "مشکل در ساختن فولدر در پوشه اصلی ویندوز.سطح دسترسی درایو اصلی ویندوز را بررسی کنید");
                                        message5.ShowDialog();
                                    }
                                }
                            }
                            else
                            {
                                MBox2 message6 = new MBox2("خطا", "خطا در سرویس : هیچ فایلی دریافت نشد");
                                message6.ShowDialog();
                            }
                        }
                        else
                        {
                            MBox2 message7 = new MBox2("خطا", "ظرفیت پکیج کافی نیست.برای خرید به سایت مراجعه کنید                                                         " + "http://bestshooter.ir");
                            message7.ShowDialog();
                        }
                    }
                    else
                    {
                        MBox2 message8 = new MBox2("خطا", "خطا در برنامه : مجددا امتحان کنید یا برنامه را دوباره اجرا کنید");
                        message8.ShowDialog();
                    }

                }
                else
                {
                    MBox2 message9 = new MBox2("هشدار", "پکیجی انتخاب نشده است");
                    message9.ShowDialog();
                }
                this.Cursor = null;
            }
            catch (Exception)
            {
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                var exitres = MessageBox.Show("آیا مطمئن هستید؟", "خروج", MessageBoxButton.YesNo);
                if (exitres == MessageBoxResult.Yes)
                {

                    LoginPage lp = new LoginPage();
                    lp.Show();
                    this.Close();
                }
                this.Cursor = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void aboutus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                AboutUs a = new AboutUs();
                a.ShowDialog();
                this.Cursor = null;
            }
            catch (Exception)
            {
            }
        }

        private void howuse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                Help h = new Help();
                h.ShowDialog();
                this.Cursor = null;
            }
            catch (Exception)
            {
            }
        }

        private void movies_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                System.Diagnostics.Process.Start("http://aparat.com/bestshooter");
                this.Cursor = null;
            }
            catch (Exception)
            {
            }
        }
    }
}
