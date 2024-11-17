
using music_manager_starter.Data.Models;
namespace music_manager_starter.Shared
{
    public sealed class PlaylistDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<PlaylistSongJoin> Songs { get; set; }
    }
}
