namespace music_manager_starter.Shared
{
    public sealed class PlaylistDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> Songs { get; set; }
    }
}
