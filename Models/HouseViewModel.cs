using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TEST_TPLUS.Domain.Entities;

namespace TEST_TPLUS.Models
{
    public class HouseViewModel
    {
        public HouseViewModel() { }
        public string? Name { get; set; }


    }
}
