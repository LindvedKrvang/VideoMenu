using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.Context;
using VideoMenuDAL.Repositories;

namespace VideoMenuDAL
{
    public class DalFacade
    {
        //public IVideoRepository VideoRepository => new MockVideoRepository();
        public IVideoRepository VideoRepository => new VideoRepositoryInMemory(new InMemoryContext());
    }
}
