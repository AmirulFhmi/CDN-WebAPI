using System.Net.Http.Headers;
using System.Net.Http;
using CDN_Web.Models;
using CDN_Web.Helper;
using Newtonsoft.Json;
using CDN_WebAPI.Helper;
using static CDN_Web.Helper.APIHelper.URLs;

namespace CDN_Web.DataServices
{
    public class DataServices : IDataServices
    {
        private readonly HttpClient _httpClient;
        public DataServices()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(APIHelper.URLs.BaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        #region User

        public async Task<bool> CreateUser(UserModel user)
        {
            try
            {
                var response = await RestHelper.PostAsync(APIHelper.URLs.User.CreateUserURL, "", "", user);

                if (response.Item1)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve data from API. Error message: " + ex.Message);
            }
        }


        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var response = await RestHelper.DeleteAsync(string.Format(APIHelper.URLs.User.DeleteUserURL, id), "", "", "");

                if (response.Item1)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve data from API. Error message: " + ex.Message);
            }
        }


        public async Task<List<UserModel>> GetAllUsers()
        {
            try
            {
                var response = await RestHelper.GetAsync(APIHelper.URLs.User.GetAllUsersURL, null, null);

                if (response.Item1)
                {
                    return JsonConvert.DeserializeObject<List<UserModel>>(response.Item2);
                }
                return new List<UserModel>();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve data from API. Error message: " + ex.Message);
            }
        }

        public async Task<UserModel> GetUser(int id)
        {
            try
            {
                var response = await RestHelper.GetAsync(string.Format(APIHelper.URLs.User.GetUserURL, id), "", "");

                if (response.Item1)
                {
                    return JsonConvert.DeserializeObject<UserModel>(response.Item2);
                }
                return new UserModel();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve data from API. Error message: " + ex.Message);
            }
        }


        public async Task<bool> UpdateUser(UserModel user)
        {
            try
            {
                var response = await RestHelper.PatchAsync(APIHelper.URLs.User.UpdateUserURL, "", "", user);

                if (response.Item1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve data from API. Error message: " + ex.Message);
            }
        }
        #endregion

        #region Hobby
        public async Task<bool> CreateHobby(HobbyModel hobby)
        {
            try
            {
                var response = await RestHelper.PostAsync(APIHelper.URLs.Hobby.CreateHobbyURL, "", "", hobby);

                if (response.Item1)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve data from API. Error message: " + ex.Message);
            }
        }

        public async Task<bool> DeleteAllHobbies(int userId)
        {
            try
            {
                var response = await RestHelper.DeleteAsync(string.Format(APIHelper.URLs.Hobby.DeleteAllHobbiesURL, userId), "", "", "");

                if (response.Item1)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve data from API. Error message: " + ex.Message);
            }
        }

        public async Task<bool> DeleteHobby(int hobbyId)
        {
            try
            {
                var response = await RestHelper.DeleteAsync(string.Format(APIHelper.URLs.Hobby.DeleteHobbyURL, hobbyId), "", "", "");

                if (response.Item1)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve data from API. Error message: " + ex.Message);
            }
        }

        public async Task<List<HobbyModel>> GetAllHobbies(int userId)
        {
            try
            {
                var response = await RestHelper.GetAsync(string.Format(APIHelper.URLs.Hobby.GetAllHobbiesURL, userId), "", "");

                if (response.Item1)
                {
                    return JsonConvert.DeserializeObject<List<HobbyModel>>(response.Item2);
                }
                return new List<HobbyModel>();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve data from API. Error message: " + ex.Message);
            }
        }

        public async Task<HobbyModel> GetHobby(int hobbyId)
        {
            try
            {
                var response = await RestHelper.GetAsync(string.Format(APIHelper.URLs.Hobby.GetHobbyURL, hobbyId), "", "");

                if (response.Item1)
                {
                    return JsonConvert.DeserializeObject<HobbyModel>(response.Item2);
                }
                return new HobbyModel();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve data from API. Error message: " + ex.Message);
            }
        }


        public async Task<bool> UpdateHobby(HobbyModel hobby)
        {
            try
            {
                var response = await RestHelper.PatchAsync(APIHelper.URLs.Hobby.UpdateHobbyURL, "", "", hobby);

                if (response.Item1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve data from API. Error message: " + ex.Message);
            }
        }

        #endregion

        #region SkillSet
        public async Task<List<SkillSetModel>> GetAllSkillSets(int userId)
        {
            try
            {
                var response = await RestHelper.GetAsync(string.Format(APIHelper.URLs.SkillSet.GetAllSkillSetURL, userId), "", "");

                if (response.Item1)
                {
                    return JsonConvert.DeserializeObject<List<SkillSetModel>>(response.Item2);
                }
                return new List<SkillSetModel>();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve data from API. Error message: " + ex.Message);
            }
        }

        public async Task<SkillSetModel> GetSkillSet(int skillSetId)
        {
            try
            {
                var response = await RestHelper.GetAsync(string.Format(APIHelper.URLs.SkillSet.GetSkillSetURL, skillSetId), "", "");

                if (response.Item1)
                {
                    return JsonConvert.DeserializeObject<SkillSetModel>(response.Item2);
                }
                return new SkillSetModel();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve data from API. Error message: " + ex.Message);
            }
        }
        public async Task<bool> CreateSkillSet(SkillSetModel skillset)
        {
            try
            {
                var response = await RestHelper.PostAsync(APIHelper.URLs.SkillSet.CreateSkillSetURL, "", "", skillset);

                if (response.Item1)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve data from API. Error message: " + ex.Message);
            }
        }
        public async Task<bool> UpdateSkillSet(SkillSetModel skillset)
        {
            try
            {
                var response = await RestHelper.PatchAsync(APIHelper.URLs.SkillSet.UpdateSkillSetURL, "", "", skillset);

                if (response.Item1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve data from API. Error message: " + ex.Message);
            }
        }
        public async Task<bool> DeleteSkillSet(int skillsetId)
        {
            try
            {
                var response = await RestHelper.DeleteAsync(string.Format(APIHelper.URLs.SkillSet.DeleteSkillSetURL, skillsetId), "", "", "");

                if (response.Item1)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve data from API. Error message: " + ex.Message);
            }
        }
        public async Task<bool> DeleteAllSkillSets(int userId)
        {
            try
            {
                var response = await RestHelper.DeleteAsync(string.Format(APIHelper.URLs.SkillSet.DeleteAllSkillSetsURL, userId), "", "", "");

                if (response.Item1)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve data from API. Error message: " + ex.Message);
            }
        }
        #endregion
    }
}
