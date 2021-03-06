﻿using System;
using System.Collections.Generic;
using Tqcsi.Qlkh.Web.Api.Models;

namespace Tqcsi.Qlkh.Web.Api.TypeMappers
{
    public class UserMapper : IUserMapper
    {
        public User CreateUser(string username, string firstname, string lastname, string email, int userId)
        {
            return new User
                       {
                           UserId = userId,
                           Username = username,
                           Email = email,
                           Firstname = firstname,
                           Lastname = lastname,
                           Links = new List<Link>
                                       {
                                           new Link
                                               {
                                                   Title = "self",
                                                   Rel = "self",
                                                   Href = "/api/users/" + userId
                                               },
                                           new Link
                                               {
                                                   Title = "All Users",
                                                   Rel = "all",
                                                   Href = "/api/users"
                                               }
                                       }
                       };
        }

        public User CreateUser(Data.Model.User modelUser)
        {
            return CreateUser(
                modelUser.Username, 
                modelUser.Firstname,
                modelUser.Lastname, 
                modelUser.Email,
                modelUser.UserId);
        }
    }
}