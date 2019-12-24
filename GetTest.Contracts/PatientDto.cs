using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GetTest.Contracts
{
    public class PatientDto
    {
        [JsonProperty("patientID")]
        public int  PatientID{ get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name should be 100 character or less")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Mobile should be 15 character or less")]
        [JsonProperty("mobileNumber")]
        public string Mobile { get; set; }

        [MaxLength(8, ErrorMessage = "Gender should be 8 character or less")]
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Address should be 200 character or less")]
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("tests")]
        public IEnumerable<TestDto> Test { get; set; }
    }
}
