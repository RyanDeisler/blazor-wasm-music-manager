using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music_manager_starter.Shared
{
    public sealed class PlaylistDTO
{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> Songs { get; set; }
    }
}
