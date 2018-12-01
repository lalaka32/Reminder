using Entities.Abstract;

namespace Entities
{
	public class Doing : IStorageble
	{
		public int Id { get; set; }

		public string Name { get; set; }
	}
}