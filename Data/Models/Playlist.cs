namespace music_manager_starter.Data.Models
{
    public sealed class Playlist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<PlaylistSongJoin> Songs { get; set; }
    }
}
