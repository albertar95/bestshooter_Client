using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bestshooter1
{
    class Utilities
    {
        public static int Login(string PurchaseCode)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://bestshooter.ir/");
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/Package/Login/" + PurchaseCode).Result;
                if (response.IsSuccessStatusCode)
                {
                    var exists = response.Content.ReadAsAsync<bool>().Result;
                    if (exists == true)
                        return 0;
                    else
                        return 1;
                }
                else
                {
                    return 2;
                }
            }
            catch (Exception)
            {
                return 3;
            }
        }
        public static MyAppPack getInfo(string PurchaseCode)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://bestshooter.ir/");
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/Package/Athenticate/" + PurchaseCode).Result;
                if (response.IsSuccessStatusCode)
                {
                    var Info = response.Content.ReadAsAsync<MyAppPack>().Result;
                    if (Info != null)
                        return Info;
                    else
                        return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static byte[] FetchFiles(string NameId)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://bestshooter.ir/");
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/Package/Deploy/" + NameId).Result;
                if (response.IsSuccessStatusCode)
                {
                    var Info = response.Content.ReadAsAsync<byte[]>().Result;
                    if (Info != null)
                        return Info;
                    else
                        return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static bool UpdateCap(string PurchaseId,string Package)
        {
            try
            {
                string inp = PurchaseId + "-" + Package;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://bestshooter.ir/");
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/Package/UpdatePack/" + inp).Result;
                if (response.IsSuccessStatusCode)
                {
                    var Info = response.Content.ReadAsAsync<bool>().Result;
                    if (Info)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            }
        public static void DeleteFilesAndFoldersRecursively(string target_dir)
        {
            try
            {
                foreach (string file in Directory.GetFiles(target_dir))
                {
                    File.Delete(file);
                }

                foreach (string subDir in Directory.GetDirectories(target_dir))
                {
                    DeleteFilesAndFoldersRecursively(subDir);
                }

                Thread.Sleep(1); // This makes the difference between whether it works or not. Sleep(0) is not enough.
                Directory.Delete(target_dir);
            }
            catch (Exception)
            {
            }
        }
    }
}
