using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {

        private readonly ApiContext _context;

        public HotelBookingController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public JsonResult CreateEdit(HotelBooking booking)
        {
            if(booking.Id == 0)
            {
                _context.Booking.Add(booking);
            } else
            {
                var bookingInDb = _context.Booking.Find(booking.Id);

                if (bookingInDb != null)
                    return new JsonResult(NotFound());

                bookingInDb = booking;

            }

            _context.SaveChanges();

            return new JsonResult(Ok(booking));
        }

        [HttpGet("GetAll")]
        public JsonResult GetAll()
        {
            return new JsonResult(Ok(_context.Booking.ToList()));
        }

    }
}
