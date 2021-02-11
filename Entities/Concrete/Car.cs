
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public int? BrandId { get; set; }
        public int? ColorId { get; set; }
        public DateTime? ModelYear { get; set; }
        public double? DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
