using System;

namespace MyCoop.WebApi.Models.Users
{
    public class AddUserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PermissionLevelId { get; set; }
    }
}