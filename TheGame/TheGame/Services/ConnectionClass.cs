using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace TheGame.Services
{
    public interface IHttpClientHandlerService
    {
        HttpClientHandler GetInsecureHandler();
    }
    public class user
    {
        public string ID { get; set; }

        public string username { get; set; }

        public string Notes { get; set; }

        public string guid { get; set; }
    }
    public class puzzle_peace
    {
        public int ID { get; set; }

        public int fk_task_id { get; set; }

        public string peace_name { get; set; }
    }
    public class tasks
    {
        public int ID { get; set; }

        public int fk_game_id { get; set; }

        public string title { get; set; }

        public List<puzzle_peace> Peaces;

        public string description { get; set; }

        public string fileid { get; set; }

        public string filename { get; set; }
        
        public string filedescrption { get; set; }

        public bool task_solved { get; set; }
    }
    public class game
    {
        public int ID { get; set; }

        public string gameName { get; set; }

        public int fk_creator_id { get; set; }

        public string description { get; set; }
    }
    class ConnectionClass
    {
        string BaseUrl;
        const string Login = "login";
        const string Logout = "LogOut";
        const string GetUser = "GetUser";
        const string GetGame = "GetGame";
        const string GetTask = "GetTask";
        const string GetPuzzelCount = "GetPuzzelCount";
        const string Complete = "Complete";
        
        private HttpClient client;
        public ConnectionClass()
        {
#if DEBUG
            BaseUrl = "Http://10.0.0.2:82/api/";
#else
            BaseUrl = "Http://10.0.0.2:82/api/";
#endif
#if DEBUG
            client = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler());
#else
            client = new HttpClient();
#endif
        }
        public async Task<int> getPuzzelCount(int Game_id)
        {
            int status = -1;
            try
            {
                string url;
                if (Game_id != 0)
                    url = string.Format("{0}{1}", BaseUrl, GetPuzzelCount + "?game_id=" + Game_id);
                else
                    throw new ArgumentNullException(paramName: nameof(Game_id), message: "Game id can not be null. or Zero");
                Uri uri = new Uri(url);
                HttpResponseMessage responseMessage = await client.GetAsync(uri);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string content = await responseMessage.Content.ReadAsStringAsync();
                    status = JsonConvert.DeserializeObject<int>(content);
                }
            }
            catch (Exception e)
            {
                Debug.Write("Exception: " + e.Message);
            }
            return status;
        }
        public async Task<game> getGame(int Game_id, string gamename)
        {
            game g = new game();
            try
            {
                string url;

                if (Game_id != 0 )
                    url = string.Format("{0}{1}",BaseUrl,GetGame+"?game_id="+Game_id);
                else
                    url = string.Format("{0}{1}", BaseUrl, GetGame + "?gamename=" + gamename);
                Uri uri = new Uri(url);
                HttpResponseMessage responseMessage = await client.GetAsync(uri);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string content = await responseMessage.Content.ReadAsStringAsync();
                    g = JsonConvert.DeserializeObject<game>(content);
                }
            }
            catch (Exception e)
            {
                Debug.Write("Exception: " + e.Message);
            }
            return g;
        }
        public async Task<user> login(string username, string password, string guid)
        {
            user u = new user();
            try
            {
                string url = string.Format("{0}{1}",BaseUrl,Login) + "?username=" + username + "&password=" + password;
                Uri uri = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    u = JsonConvert.DeserializeObject<user>(content);
                }

            }
            catch (Exception e)
            {
                u.Notes = "FAILED...";
                u.username = "";
                u.guid = "";
                u.ID = "0";
                Debug.Write("Exception: " + e.Message);
            }
            return u;
        }

    }
}
