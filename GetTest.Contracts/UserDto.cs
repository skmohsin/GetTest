using GetTest.Entities.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GetTest.Contracts
{
    public class UserDto 
    {
        [JsonProperty("userID")]
        public int UserID { get; set; }
        
        [Required]
        [MaxLength(100, ErrorMessage = "Registration Number should be 100 character or less")]
        [JsonProperty("registrationNumber")]
        public string RegistrationNumber { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "UserName should be 100 character or less")]
        [JsonProperty("userName")]
        public string Name { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Mobile should be 15 character or less")]
        [JsonProperty("mobileNumber")]
        public string Mobile { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Password should be 15 character or less")]
        [JsonProperty("password")]
        public string Password { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Address should be 200 character or less")]
        [JsonProperty("address")]
        public string Address { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Degree should be 50 character or less")]
        [JsonProperty("degree")]
        public string Degree { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }
}
