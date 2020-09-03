using System;

public static class UserApiHelper
{
    public static bool Login(string username, string password)
    {
        string urlParameter = string.Format("{0}{1}", ApiConstants.GetUserInfo, username);
        var fileFolderResponse = CommonApiHelper.GetData(urlParameter, true);
        return JsonConvert.DeserializeObject<UserModel>(fileFolderResponse);
    }
}
