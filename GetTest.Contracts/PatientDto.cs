using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GetTest.Contracts
{
    public class PatientDto
    {
        [JsonProperty("PatientID")]
        public int  PatientID{ get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name should be 100 character or less")]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Mobile should be 15 character or less")]
        [JsonProperty("MobileNumber")]
        public string Mobile { get; set; }

        [MaxLength(8, ErrorMessage = "Gender should be 8 character or less")]
        [JsonProperty("Gender")]
        public string Gender { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Address should be 200 character or less")]
        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("Tests")]
        public IEnumerable<TestDto> Test { get; set; }
    }
}
