using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_API.BL.DTOs
{
    public record RegisterDto( string UserName, string Email, string Password, string PhoneNumber);
}
