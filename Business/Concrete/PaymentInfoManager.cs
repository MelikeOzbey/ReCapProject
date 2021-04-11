using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentInfoManager : IPaymentInfoService
    {
        IPaymentInfoDal _paymentInfoDal;

        public PaymentInfoManager(IPaymentInfoDal paymentInfoDal)
        {
            _paymentInfoDal = paymentInfoDal;
        }

        public IResult Add(PaymentInfo payment)
        {
            _paymentInfoDal.Add(payment);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(PaymentInfo payment)
        {
            _paymentInfoDal.Delete(payment);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<PaymentInfo>> GetAll()
        {
            return new SuccessDataResult<List<PaymentInfo>>(_paymentInfoDal.GetAll());
        }
        public IDataResult<PaymentInfo> GetById(int paymentId)
        {
            return new SuccessDataResult<PaymentInfo>(_paymentInfoDal.Get(x => x.Id == paymentId));
        }

        public IResult Update(PaymentInfo payment)
        {
            _paymentInfoDal.Update(payment);
            return new SuccessResult(Messages.Updatetd);
        }
    }
}
