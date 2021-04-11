using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentDetailDto:IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string CarName { get; set; }
        public string CompanyName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string StFirstCarImage { get; set; }
        public string UserName { get; set; }
        public double? DailyPrice { get; set; }
        public int InTotalDays { get; set; }
        public double? FlTotalPrice { get; set; }
        public bool BoPaid { get; set; }
        public int? FindexNo { get; set; }
        public string BrandName { get; set; }

    }
}
