using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GetTest.Contracts
{
    public class AuthDto
    {
        [Required]
        [MaxLength(15, ErrorMessage = "Mobile should be 15 character or less")]
        [JsonProperty("MobileNumber")]
        public string Mobile { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Password should be 15 character or less")]
        [JsonProperty("Password")]
        public string Password { get; set; }
    }
}
