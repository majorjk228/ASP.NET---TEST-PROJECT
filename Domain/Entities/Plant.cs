using System.ComponentModel.DataAnnotations;

namespace TEST_TPLUS.Domain.Entities
{
	public class Plant : EntityBase
	{
        public IReadOnlyCollection<PlantConsumption> Consumptionss { get; set; }
    }
}
