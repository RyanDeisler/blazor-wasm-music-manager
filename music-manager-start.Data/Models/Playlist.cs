﻿using music_manager_starter.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music_manager_start.Data.Models
{
    public sealed class Playlist
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required List<Song> Songs { get; set; }
    }
}
