using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoomService.WebAPI.Data;
using RoomService.WebAPI.Services;
using System.Collections.Generic;


namespace RoomService.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomsService _roomsService;

        public RoomsController(IRoomsService roomsService)
        {
            _roomsService = roomsService;
        }

        // GET: api/rooms/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            {
            var user = (await _roomsService.Get(new[] { id }, null)).FirstOrDefault();
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // GET: api/rooms
        [HttpGet("")]
        public async Task<IActionResult> GetAll([FromQuery] Filters filters)
        {
            var newsItems = await _roomsService.Get(null, filters);
            return Ok(newsItems);
        }

        // POST: api/rooms
        [HttpPost]
        public async Task<IActionResult> Add(Room room)
        {
            await _roomsService.Add(room);
            return Ok(room);
        }

        // GET: api/rooms?Floors={floor1}&Floors={floor2}
        [HttpGet]
        public IActionResult GetRoomsByFloors([FromQuery] int[] Floors)
        {
            var newsRooms = _rooms.FindAll(r => Floors.Contains(r.Floor));
            return Ok(newsRooms);
        }
    }
}
