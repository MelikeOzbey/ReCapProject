using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : Controller
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int carId )
        {
            var result = _carImageService.GetAll(c=>c.CarId==carId);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(file,carImage);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm(Name=("Image"))] IFormFile file, [FromForm(Name =("Id"))] int id)
        {
            var resultData = _carImageService.GetById(id).Data;
            var result = _carImageService.Update(file, resultData);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm] CarImage carImage)
        {
            var resultData = _carImageService.GetById(carImage.Id).Data;
            var result = _carImageService.Delete(resultData);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getimagesbycar")]
        public IActionResult GetImagesByCar([FromForm(Name =("carId"))] int carId)
        {
            var result = _carImageService.GetImagesByCar(carId);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}