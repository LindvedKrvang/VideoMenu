using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.Context;
using VideoMenuDAL.Repositories;
using VideoMenuDAL.UnitOfWork;

namespace VideoMenuDAL
{
    public class DalFacade
    {
        //public IVideoRepository VideoRepository => new MockVideoRepository();
        //public IVideoRepository VideoRepository => new VideoRepositoryInMemory(new InMemoryContext());
        public IUnitOfWork UnitOfWork => new UnitOfWorkMemory();
    }
}
