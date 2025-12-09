namespace ProjetDotNet.Models;

public class UserConstants
{
    public static List<UserModel> Users = new List<UserModel>()
    {
        new UserModel()
        {
            Username = "jason admin", EmailAddress = "jason@mail.fr", Password = "password", GivenName = "Jason",
            Surname = "Bryant", Role = "Administrator"
        },
        new UserModel()
        {
            Username = "elyse", EmailAddress = "elys@mail.fr", Password = "azerty", GivenName = "Elyse",
            Surname = "Bryant", Role = "Seller"
        }
    };
}