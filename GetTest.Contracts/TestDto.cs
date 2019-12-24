using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GetTest.Contracts
{
    public class TestDto
    {
        [JsonProperty("testID")]
        public int TestID { get; set; }

        [Required]
        [JsonProperty("patientID")]
        public int PatientID { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Test name should be 50 character or less")]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
