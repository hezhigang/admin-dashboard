using System;
namespace admin_dashboard.Models
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public virtual List<Book>? books { get; set; }
	}
}

