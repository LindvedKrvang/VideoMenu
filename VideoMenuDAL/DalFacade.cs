using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.Repositories;

namespace VideoMenuDAL
{
    public class DalFacade
    {
        public IVideoRepository VideoRepository => new MockVideoRepository();
    }
}
