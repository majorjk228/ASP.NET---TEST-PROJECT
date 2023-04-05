using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TEST_TPLUS.Domain.Entities;

namespace TEST_TPLUS.Models
{
    public class HouseViewModel
    {
        public HouseViewModel() 
        {
            HouseConsumptions = new List<HouseConsumption>();
        }

        public List<HouseConsumption> HouseConsumptions { get; set; }

        // Кол-во ошибок при импорте
        public int ErrorsTotal { get; set; } 
    }
}
