using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWA.Shared.DTOs
{
    public sealed class UserDto
    {
        public Guid Id { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get;set; }
        public string Password { get; set; }

        public string Token { get; set; }
    }
}
