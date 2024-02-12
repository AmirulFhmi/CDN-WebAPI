namespace CDN_Web.Helper
{
    public class APIHelper
    {
        internal static class URLs
        {
            internal static string BaseUrl = "https://localhost:7104/api/";

            internal static class User
            {
                internal static string GetAllUsersURL = BaseUrl + "User";
                internal static string GetUserURL = BaseUrl + "User/{0}";
                internal static string CreateUserURL = BaseUrl + "User/CreateUser";
                internal static string UpdateUserURL = BaseUrl + "User/UpdateUser";
                internal static string DeleteUserURL = BaseUrl + "User/DeleteUser/{0}";
            }

            internal static class Hobby
            {
                internal static string GetAllHobbiesURL = BaseUrl + "Hobby/GetHobbies/{0}";
                internal static string GetHobbyURL = BaseUrl + "Hobby/GetHobby/{0}";
                internal static string CreateHobbyURL = BaseUrl + "Hobby/CreateHobby";
                internal static string UpdateHobbyURL = BaseUrl + "Hobby/UpdateHobby/{0}";
                internal static string DeleteHobbyURL = BaseUrl + "Hobby/DeleteHobby/{0}";
                internal static string DeleteAllHobbiesURL = BaseUrl + "Hobby/DeleteAllHobbies/{0}";
            }
            internal static class SkillSet
            {
                internal static string GetAllSkillSetURL = BaseUrl + "SkillSet/GetSkillSets/{0}";
                internal static string GetSkillSetURL = BaseUrl + "SkillSet/GetSkillSet/{0}";
                internal static string CreateSkillSetURL = BaseUrl + "SkillSet/CreateSkillSet";
                internal static string UpdateSkillSetURL = BaseUrl + "SkillSet/UpdateSkillSet";
                internal static string DeleteSkillSetURL = BaseUrl + "SkillSet/DeleteSkillSet/{0}";
                internal static string DeleteAllSkillSetsURL = BaseUrl + "SkillSet/DeleteAllSkillSets/{0}";
            }
        }
    }
}
