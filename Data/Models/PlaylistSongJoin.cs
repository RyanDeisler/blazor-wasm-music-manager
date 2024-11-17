using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music_manager_starter.Data.Models
{
    [PrimaryKey(nameof(PlaylistId), nameof(SongId))]
    public class PlaylistSongJoin
    {
        public Guid PlaylistId { get; set; } // Foreign key for playlist
        public Playlist Playlist { get; set; } // Get and set the playlist

        public Guid SongId { get; set; } // Foreign key for song
        public Song Song { get; set; } // Get and set the song
    }
}
