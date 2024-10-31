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

        //Get all playlists endpoint
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

        //Add a playlist endpoint
        [HttpPost]
        public async Task<ActionResult<Playlist>> PostPlaylist(Playlist playlist)
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

        //Delete a playlist
        [HttpDelete("{playlistId}")]
        public async Task<ActionResult> DeletePlaylist(Guid playlistId)
        {
            try
            {
                var playlist = await _context.Playlists.FindAsync(playlistId);
                if (playlist == null)
                {
                    return NotFound("Could not find this playlist for deletion.");
                }
                _context.Playlists.Remove(playlist);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e) 
            {
                return StatusCode(500, "Server error in DeletePlaylist: " + e.Message);
            }
        }

        //Remove a song from a playlist at the endpoint
        [HttpDelete("{playlistId}/deleteSong/{songName}")]
        public async Task<ActionResult> RemoveSongFromPlaylist(Guid playlistId, string songName)
        {
            try
            {
                var playlist = await _context.Playlists.FindAsync(playlistId);
                if (playlist == null)
                {
                    return NotFound("Playlist not found");
                }
  
                if (playlist.Songs.Remove(songName))
                {
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound("Song not found in playlist");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Server error in RemoveSongFromPlaylist: " + e.Message);
            }
        }

        //Add a song to a playlist at the endpoint
        [HttpDelete("{playlistId}/addSong/{songName}")]
        public async Task<ActionResult> AddSongToPlaylist(Guid playlistId, string songName)
        {
            try
            {
                var playlist = await _context.Playlists.FindAsync(playlistId);
                if (playlist == null)
                {
                    return NotFound("Playlist not found");
                }

                playlist.Songs.Add(songName)                
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, "Server error in RemoveSongFromPlaylist: " + e.Message);
            }
        }

    }
}
