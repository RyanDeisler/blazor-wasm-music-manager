using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music_manager_starter.Shared
{
    public sealed class Playlist
{
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public List<PlaylistSongJoin> PlaylistSongJoins { get; set; }
    }
}
