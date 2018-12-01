using Entities.Abstract;

namespace Entities
{
	public class Image : IStorageble
	{
		public int Id { get; set; }

		public string Name { get; set; }
	}
}