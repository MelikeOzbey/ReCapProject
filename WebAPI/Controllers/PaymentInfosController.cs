using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentInfosController : Controller
    {
        IPaymentInfoService _paymentInfoService;

        public PaymentInfosController(IPaymentInfoService paymentInfoService)
        {
            _paymentInfoService = paymentInfoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _paymentInfoService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _paymentInfoService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(PaymentInfo payment)
        {
            var result = _paymentInfoService.Add(payment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(PaymentInfo payment)
        {
            var result = _paymentInfoService.Delete(payment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(PaymentInfo payment)
        {
            var result = _paymentInfoService.Delete(payment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
