using Entities.Abstract;

namespace Entities
{
	public class CategoryOfNotification : IStorageble
	{
		public int Id { get; set; }

		public string Name { get; set; }
		
	}
}