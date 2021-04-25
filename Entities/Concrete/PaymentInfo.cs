using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class PaymentInfo : IEntity
    {
        public int Id { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserAddress { get; set; }
        public string StCreditType { get; set; }
        public string CardUserName { get; set; }
        public string CardNumber { get; set; }
        public int? CardExpMonth { get; set; }
        public int? CardExpYear { get; set; }
        public int? CardCvv { get; set; }
        public int? UserId { get; set; }
    }
}
