using System;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace HelloCSharp.Models
{
	public enum Sex
	{
		Men = 0,
		Woman = 1
	}

	public class Student
	{
		[JsonPropertyName("fullName")]
		public string FullName { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("sex")]
        public Sex Sex { get; set; }

        public override string ToString()
        {
            var info = $"\n\tStudent : {this.GetHashCode()}" +
                $" ➜ FullName : {FullName}" +
                $" ➜ Age: {Age}" +
                $" ➜ Sex: {Sex}";
            return info;
        }
    }
}

