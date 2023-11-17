using System.ComponentModel.DataAnnotations;

namespace RestApiCrudDemo.Models
{
	public class Employee
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
	}
}
