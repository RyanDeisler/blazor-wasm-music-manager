using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;
using music_manager_starter.Shared;

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
                if (playlists == null)
                {
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
        public async Task<ActionResult<Playlist>> PostPlaylist(PlaylistDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("Playlist cannot be null.");
                }

                var playlistToAdd = new Playlist { Id = dto.Id, Name = dto.Name, Songs = dto.Songs };

                _context.Playlists.Add(playlistToAdd);
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
        [HttpDelete("{playlistId}/deleteSong/{songId}")]
        public async Task<ActionResult> RemoveSongFromPlaylist(Guid playlistId, Guid songId)
        {
            try
            {
                var playlist = await _context.Playlists.FindAsync(playlistId);
                if (playlist == null)
                {
                    return NotFound("Playlist not found");
                }

                var songToBeRemoved = await _context.Songs.FindAsync(songId);
                if (songToBeRemoved == null)
                {
                    return NotFound("Song not found");
                }

                var joinToBeDeleted = await _context.PlaylistSongJoins.FindAsync(playlistId, songId);
                if (joinToBeDeleted == null)
                {
                    return NotFound("Join entity not found");
                }

                _context.PlaylistSongJoins.Remove(joinToBeDeleted);

                playlist.Songs.Remove(joinToBeDeleted);
                songToBeRemoved.Playlists.Remove(joinToBeDeleted);

                await _context.SaveChangesAsync();
                return Ok();

            }
            catch (Exception e)
            {
                return StatusCode(500, "Server error in RemoveSongFromPlaylist: " + e.Message);
            }
        }

        //Add a song to a playlist at the endpoint
        [HttpPost("{playlistId}/addSong/{songId}")]
        public async Task<ActionResult> AddSongToPlaylist(Guid playlistId, Guid songId)
        {
            try
            {
                var playlist = await _context.Playlists.FindAsync(playlistId);
                if (playlist == null)
                {
                    return NotFound("Playlist not found");
                }

                var songToBeAdded = await _context.Songs.FindAsync(songId);
                if (songToBeAdded == null)
                {
                    return NotFound("Song not found");
                }

                var newJoinEntity = new PlaylistSongJoin { Playlist = playlist, PlaylistId = playlistId, Song = songToBeAdded, SongId = songId };

                playlist.Songs.Add(newJoinEntity);
                songToBeAdded.Playlists.Add(newJoinEntity);

                _context.PlaylistSongJoins.Add(newJoinEntity);

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
