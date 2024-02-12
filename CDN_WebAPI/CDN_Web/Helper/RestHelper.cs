using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace CDN_WebAPI.Helper
{
    public class RestHelper
    {
        public async static Task<string> GetAsync(string baseURL)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(baseURL);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }

        public async static Task<(bool, string)> GetAsync(string baseURL, string authMethod, string authValue)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    if (!string.IsNullOrEmpty(authMethod))
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authMethod, authValue);

                    var response = await client.GetAsync(baseURL);

                    return (response.IsSuccessStatusCode, await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                return (false, "EXCEPTION");
            }
        }

        public async static Task<string> PostAsync(string url, string authMethod, string username, string password, object body)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authMethod, Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password)));

                    StringContent httpContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(url, httpContent);

                    if (response.IsSuccessStatusCode)
                        return await response.Content.ReadAsStringAsync();

                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public async static Task<(bool, string)> PostAsync(string url, string authMethod, string authValue, object body)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    if (!string.IsNullOrEmpty(authMethod))
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authMethod, authValue);

                    StringContent httpContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(url, httpContent);

                    return (response.IsSuccessStatusCode, await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                return (false, "EXCEPTION");
            }
        }

        public async static Task<(bool, string)> DeleteAsync(string url, string authMethod, string username, string password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authMethod, Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password)));

                var response = await client.DeleteAsync(url);

                return (response.IsSuccessStatusCode, await response.Content.ReadAsStringAsync());
            }
        }

        public async static Task<(bool, string)> PatchAsync(string url, string authMethod, string authValue, object body)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    if (!string.IsNullOrEmpty(authMethod))
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authMethod, authValue);

                    StringContent httpContent = new StringContent(body == null ? string.Empty : JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

                    var response = await client.PatchAsync(url, httpContent);

                    return (response.IsSuccessStatusCode, await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                return (false, "EXCEPTION");
            }
        }
    }

}
