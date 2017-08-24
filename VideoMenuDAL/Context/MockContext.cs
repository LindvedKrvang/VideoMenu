using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VideoMenuEntities;

namespace VideoMenuDAL.Context
{
    internal class MockContext
    {
        public readonly List<Video> Videos = new List<Video>()
        {
            new Video()
            {
                Id = 1,
                Name = "Scary Movie 4",
                Genre = EGenre.Comedy
            },

            new Video()
            {
                Id = 2,
                Name = "The Good. The Bad. The Ugly.",
                Genre = EGenre.Western
            },
            new Video()
            {
                Id = 3,
                Name = "The NoteBook",
                Genre = EGenre.Romantic
            },
            new Video()
            {
                Id = 4,
                Name = "Skyfall",
                Genre = EGenre.Action
            }
        };
    }
}
