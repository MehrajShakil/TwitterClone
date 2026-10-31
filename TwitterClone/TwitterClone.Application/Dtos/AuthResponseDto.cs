using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Application.Dtos
{
    public class AuthResponseDto
    {
        public required string AccessToken { get; set; }
        public required DateTime ExpiryAt { get; set; }
        public required UserDto UserDto { get; set; }
    }
}
