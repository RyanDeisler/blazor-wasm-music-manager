using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;
using System;

namespace music_manager_starter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly DataDbContext _context;

        public SongsController(DataDbContext context)
        {
            _context = context;
        }

        //Get a song endpoint
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            try
            {
                return await _context.Songs.ToListAsync();
            }
            catch (Exception e)
            {
                return StatusCode(500, "Server error in GetSongs: " + e.Message);
            }
        }

        //Add a song endpoint
        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            try
            {
                if (song == null)
                {
                    return BadRequest("Song cannot be null.");
                }
                _context.Songs.Add(song);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e) { 
                return StatusCode(500, "Server error in PostSong: " + e.Message);
            }
        }
    }
}
