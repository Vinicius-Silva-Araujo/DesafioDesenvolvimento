using DesafioDesenvolvimento.Models;
//using System.Linq;
//using SolrNet.Utils;
//using System.Collections.Generic;
//using Microsoft.AspNetCore.Mvc;

namespace DesafioDesenvolvimento.Repositorios;

public class UserRepositorios
{
    public static User Get(string name, string password)
    {
        var users = new List<User>();
        users.Add(new User { Id = 1, Name = "Vinicius", Password = "abc", Role = "admin" });
        users.Add(new User { Id = 2, Name = "Silva", Password = "54321", Role = "usuario" });
        return users.FirstOrDefault(User => User.Name.ToLower() == name && User.Password == password);

    }
}
