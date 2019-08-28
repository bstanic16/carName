using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using CarRenting.Dtos;
using CarRenting.Models;
using System.Data.Entity;



namespace CarRenting.Controllers.Api
{
    public class CarsController : ApiController
    {
        private ApplicationDbContext _context;
        public CarsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<CarDto> GetCars(string query = null)
        {
            var carsQuery = _context.Cars
                .Include(m => m.Genre)
                .Where(m => m.Available > 0);
            if (!String.IsNullOrWhiteSpace(query)) {
                carsQuery = carsQuery.Where(m => m.Name.Contains(query));
            }
            return carsQuery
                .ToList()
                .Select(Mapper.Map<Car, CarDto>);
                }
        public IHttpActionResult GetCar(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);
            if(car == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Car, CarDto>(car));
        }
        [HttpPost]
        public IHttpActionResult CreateCar(CarDto carDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var car = Mapper.Map<CarDto, Car>(carDto);
            _context.Cars.Add(car);
            _context.SaveChanges();

            carDto.Id = car.Id;
            return Created(new Uri(Request.RequestUri + "/" + car.Id), carDto);
        }
        [HttpPut]
        public IHttpActionResult UpdateCar(int id,CarDto carDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var carInDb = _context.Cars.SingleOrDefault(c => c.Id == id);
            if(carInDb == null)
            {
                return NotFound();
            }
            Mapper.Map(carDto, carInDb);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteCar(int id)
        {
            var carInDb = _context.Cars.SingleOrDefault(c => c.Id == id);
            if(carInDb == null)
            {
                return NotFound();
            }
            _context.Cars.Remove(carInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
