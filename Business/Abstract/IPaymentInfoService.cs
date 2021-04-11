using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPaymentInfoService
    {
        IDataResult<List<PaymentInfo>> GetAll();
        IDataResult<PaymentInfo> GetById(int paymentId);
        IResult Add(PaymentInfo payment);
        IResult Update(PaymentInfo payment);
        IResult Delete(PaymentInfo payment);
    }
}
