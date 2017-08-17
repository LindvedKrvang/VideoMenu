using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenu.be
{
    class Video
    {
        public int Id { get; }
        public string Name { get; }
        public EGenre Genre { get; }

        public Video(int id, string name, EGenre genre)
        {
            Id = id;
            Name = name;
            Genre = genre;
        }
    }
}
