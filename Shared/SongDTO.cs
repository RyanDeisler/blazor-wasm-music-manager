﻿namespace music_manager_starter.Shared
{
    public sealed class SongDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        //public List<PlaylistSongJoin> PlaylistSongJoins { get; set; }
    }
}
