using Entities.Abstract;

namespace Entities
{
	public class Category : IStorageble
	{
		public int Id { get; set; }

		public string Name { get; set; }
		
	}
}