using System;
using System.Text.Json.Serialization;

namespace HelloCSharp.Models
{
	public enum Level
	{
		Beginer,
		Amater,
		Professional,
		Expert
	}

	public class Class
	{
		[JsonPropertyName("Name")]
		public string Name { get; set; }

        [JsonPropertyName("Max")]
        public int Max { get; set; }

        [JsonPropertyName("Level")]
        public Level Level { get; set; }

        [JsonPropertyName("Students")]
        public List<Student> Students { get; set; }

		public static List<Class> MockClass()
		{
			return new()
			{
				new Class
				{
					Name = "Lớp Học Nấu Không Ai Ăn",
					Level = Level.Professional,
					Max = 40,
					Students = new List<Student>
					{
						new Student { FullName = "Nguyen Van A", Age = 10, Sex = Sex.Men },
						new Student { FullName = "Trinh Thị C", Age = 20, Sex = Sex.Woman },
						new Student { FullName = "Đỗ Văn B", Age = 99, Sex = Sex.Woman },
					}
				},
                new Class
                {
                    Name = "Lớp Học Code Để Gài Bug",
                    Level = Level.Professional,
                    Max = 40,
                    Students = new List<Student>
                    {
                        new Student { FullName = "Phạm Cẩm D", Age = 33, Sex = Sex.Woman },
                        new Student { FullName = "La Tấn E", Age = 20, Sex = Sex.Men },
                        new Student { FullName = "Phạm G", Age = 99, Sex = Sex.Woman },
                    }
                },
            };
		}

        public override string ToString()
        {
			var info = $"Class : {this.GetHashCode()}" +
				$"\nName : {Name}" +
				$"\nMax: {Max}" +
				$"\nLevel: {Level}" +
				$"\nStudents : " +
				$"{ShowAllStudents()}\n";

			string ShowAllStudents()
			{
				var resultStudents = string.Empty;
				foreach (var student in Students)
				{
                    resultStudents += student.ToString();
                }
				return resultStudents;
            }
			return info;
        }

    }
}

