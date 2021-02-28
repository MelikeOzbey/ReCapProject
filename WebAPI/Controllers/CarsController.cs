using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
       [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }

        [HttpGet("getcardetailbyid")]
        public IActionResult GetCarDetailById(int id)
        {
            var result = _carService.GetCarDetailById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
        [HttpGet("getcarbybrandid")]
        public IActionResult GetCarsByBrandId(int id)
        {
            var result = _carService.GetCarsByBrandId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
        [HttpGet("getcarbycolorid")]
        public IActionResult GetCarsByColorId(int id)
        {
            var result = _carService.GetCarsByBrandId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
    }
}