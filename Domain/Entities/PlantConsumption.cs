using System.ComponentModel.DataAnnotations;

namespace TEST_TPLUS.Domain.Entities
{
    public class PlantConsumption : Plant
    {
        public PlantConsumption() => DateCreate = DateTime.UtcNow; //При создании нового объекта дата создания равна текущей	

        [DataType(DataType.Time)]
        public DateTime DateCreate { get; set; }

        public float Price { get; set; }
        public float Consumption { get; set; }
    }
}
