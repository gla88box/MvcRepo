using System;
using System.ComponentModel.DataAnnotations;

namespace DemoProject.Models
{
    public class Contact : ModelBase
    {
        public bool IsMarketable { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DateUsedFrom { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DateUsedTo { get; set; }
    }
}
