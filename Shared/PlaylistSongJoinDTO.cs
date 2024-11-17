using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music_manager_starter.Shared
{
    public class PlaylistSongJoinDTO
    {
        public Guid PlaylistId { get; set; } // Foreign key for playlist
        public Playlist Playlist { get; set; } // Get and set the playlist

        public Guid SongId { get; set; } // Foreign key for song
        public Song Song { get; set; } // Get and set the song
    }

}
