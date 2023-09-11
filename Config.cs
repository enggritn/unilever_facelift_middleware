using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceliftMW
{
    class Config
    {
        public List<string> ReaderIPs { get; set; }
        public string ApiAddress { get; set; }
        public string BuzzerIP { get; set; }

        public string Location = "CRMS"; //WAREHOUSE NAME

        public string LocationAlias = "CRMS"; //WAREHOUSE ALIAS
        public bool IsConfigured { get; set; }


        public Config()
        {
            IsConfigured = true;
            //load config file
            try
            {
                // deserialize JSON directly from a file
                using (StreamReader file = File.OpenText(@"settings.json"))
                {
                    WebService webService = new WebService();
                    JsonSerializer serializer = new JsonSerializer();
                    FileConfig fileConfig = (FileConfig)serializer.Deserialize(file, typeof(FileConfig));
                    Helper helper = new Helper();
                    string EncryptionKey = "DKPFACELIFTULI";
                    //decrypt value
                    List<string> list_reader = fileConfig.ReaderIPs;
                    ApiAddress = string.IsNullOrEmpty(fileConfig.ApiAddress) ? "" : helper.Decrypt(fileConfig.ApiAddress, EncryptionKey);
                    BuzzerIP = string.IsNullOrEmpty(fileConfig.BuzzerIP) ? "" : helper.Decrypt(fileConfig.BuzzerIP, EncryptionKey);

                    if(list_reader.Count() > 0)
                    {
                        if (list_reader[0].Equals(""))
                        {
                            IsConfigured = false;
                        }
                        else
                        {
                            ReaderIPs = new List<string>();
                            foreach (string ReaderIP in list_reader)
                            {
                                string val = helper.Decrypt(ReaderIP, EncryptionKey);
                                ReaderIPs.Add(val);
                            }
                        }                       
                    }

                    if (ApiAddress.Equals(""))
                    {
                        IsConfigured = false;
                    }
                }
               
            }
            catch (Exception e)
            {
                IsConfigured = false;
            }
           
        }

        public static String GetVersion()
        {
            Version version = typeof(Program).Assembly.GetName().Version;
            String vers = String.Format("Version : {0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
            return vers;
        }

        public void SaveConfig(FileConfig fileConfig)
        {
            string configJson = JsonConvert.SerializeObject(fileConfig);
            File.WriteAllText(@"settings.json", configJson);
        }

        //public bool ApiConnected()
        //{
        //    bool IsConnected = true;
        //    var ping = new System.Net.NetworkInformation.Ping();

        //    var result = ping.Send(string.Format("http://{0}", ApiAddress));

        //    if (result.Status != System.Net.NetworkInformation.IPStatus.Success)
        //        IsConnected = false;

        //    return IsConnected;
        //}
    }
}
