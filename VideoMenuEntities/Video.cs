namespace VideoMenuEntities
{
    public class Video
    {
        public int Id { get; }
        public string Name { get; set; }
        public EGenre Genre { get; }

        public Video(int id, string name, EGenre genre)
        {
            Id = id;
            Name = name;
            Genre = genre;
        }
    }
}
