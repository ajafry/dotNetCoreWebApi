using System;
using System.Text.Json.Serialization;

namespace MonitorTestApi.Models {
    public class Employee {
        private int id;
        [JsonIgnore]
        public int Id {
            get {
                return id;
            }
        }
        [JsonPropertyName("ID")]

        public string textID { 
            get {
                return id.ToString();
            } 
            set {
                if (!int.TryParse(value, out id)) {
                    id = -1;
                }
            }
        }
        public string JobTitle { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
    }

}
