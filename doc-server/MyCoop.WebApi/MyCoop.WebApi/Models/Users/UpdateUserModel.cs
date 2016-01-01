using System;

namespace MyCoop.WebApi.Models.Users
{
    public class UpdateUserModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PermissionLevelId { get; set; }
    }
}