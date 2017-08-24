using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.UnitOfWork;

namespace VideoMenuDAL
{
    public class MockDalFacade : IDalFacade
    {
        public IUnitOfWork UnitOfWork => new MockUnitOfWork();
    }
}
