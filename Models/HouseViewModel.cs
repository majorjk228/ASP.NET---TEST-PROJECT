using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TEST_TPLUS.Domain.Entities;

namespace TEST_TPLUS.Models
{

/*    public class HouseViewModel
    {
        public List<House> Houses { get; set; }
    }*/

    public class HouseViewModel
    {
        public HouseViewModel() { }
        public string? Name { get; set; }


    }


    /*    public class HouseConsumptions
        {
            public HouseConsumption() => DateCreate = DateTime.Now; //При создании нового объекта дата создания равна текущей	

            [Key]
            public int Id { get; set; }

            [JsonProperty("Date")]
            [DataType(DataType.Time)]
            public DateTime DateCreate { get; set; }

            [JsonProperty("Weather")]
            public double Weather { get; set; }

            [JsonProperty("Consumption")]
            public double Consumption { get; set; }

            [ForeignKey("HouseConsumerId")]
            public House? House { get; set; }
        }*/
}
