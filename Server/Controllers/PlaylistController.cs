using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;
using System;

namespace music_manager_starter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly DataDbContext _context;

        public PlaylistsController(DataDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
        {
            try
            {
                var playlists = await _context.Playlists.ToListAsync();
                if (playlists == null) {
                    return NotFound("No playlists found");
                }
                return await _context.Playlists.ToListAsync();
            }
            catch (Exception e)
            { 
                return StatusCode(500, "Server error in GetPlaylists: " + e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Song>> PostPlaylist(Playlist playlist)
        {
            try
            {


                if (playlist == null)
                {
                    return BadRequest("Playlist cannot be null.");
                }


                _context.Playlists.Add(playlist);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, "Server error in PostPlaylist: " + e.Message);
            }
        }
    }
}
