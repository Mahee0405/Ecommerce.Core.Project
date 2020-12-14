using System;
using System.ComponentModel.DataAnnotations;

namespace skinet.API.DTOs
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$",
            ErrorMessage = "Password pattern is not correct")]
        public string Password { get; set; }

        [Required]
      
        public string DisplayName { get; set; }
    }
}
