using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FaceliftMW
{
    class WebService
    {
        public BaseResponse CheckWarehouse(string WarehouseName)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                HttpClient client = new HttpClient();
                Config config = new Config();
                Uri uri = new Uri(config.ApiAddress + "/Warehouse?WarehouseName=" + WarehouseName);
                HttpResponseMessage response = client.GetAsync(uri).Result;
                string body = response.Content.ReadAsStringAsync().Result;
                baseResponse = JsonConvert.DeserializeObject<BaseResponse>(body);
            }
            catch (Exception e)
            {

            }

            return baseResponse;
        }

        public BaseResponse FindDeliveryNote(string TransactionCode)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                HttpClient client = new HttpClient();
                Config config = new Config();
                client.DefaultRequestHeaders.Add("warehouseName", config.LocationAlias);
                Uri uri = new Uri(config.ApiAddress + "/Shipment?TransactionCode=" + TransactionCode);
                HttpResponseMessage response = client.GetAsync(uri).Result;
                string body =  response.Content.ReadAsStringAsync().Result;
                baseResponse = JsonConvert.DeserializeObject<BaseResponse>(body);
            }
            catch (Exception e)
            {

            }

            return baseResponse;
        }

        public BaseResponse PostData(Shipment shipment)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                var json = JsonConvert.SerializeObject(shipment);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                Config config = new Config();
                client.DefaultRequestHeaders.Add("warehouseName", config.LocationAlias);
                Uri uri = new Uri(config.ApiAddress + "/Shipment");
                HttpResponseMessage response = client.PostAsync(uri, data).Result;
                string body = response.Content.ReadAsStringAsync().Result;
                baseResponse = JsonConvert.DeserializeObject<BaseResponse>(body);
            }
            catch (Exception e)
            {

            }

            return baseResponse;
        }


        public void SendBuzzer(string value, string control)
        {
            try
            {
                HttpClient client = new HttpClient();
                Config config = new Config();
                string url = string.Format("http://{0}/L?{1}={2}", config.BuzzerIP, value, control);
                Uri uri = new Uri(url);
                HttpResponseMessage response = client.GetAsync(uri).Result;
            }
            catch (Exception e)
            {

            }
        }

        public bool CheckBuzzer()
        {
            bool status = false;
            try
            {
                HttpClient client = new HttpClient();
                Config config = new Config();
                string url = string.Format("http://{0}", config.BuzzerIP);
                Uri uri = new Uri(url);
                HttpResponseMessage response = client.GetAsync(uri).Result;
                status = true;
            }
            catch (Exception e)
            {

            }
            return status;
        }


    }
}
