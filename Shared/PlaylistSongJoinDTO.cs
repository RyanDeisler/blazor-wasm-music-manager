namespace music_manager_starter.Shared
{
    public class PlaylistSongJoinDTO
    {
        public Guid PlaylistId { get; set; } // Foreign key for playlist
        public PlaylistDTO Playlist { get; set; } // Get and set the playlist

        public Guid SongId { get; set; } // Foreign key for song
        public SongDTO Song { get; set; } // Get and set the song
    }

}
