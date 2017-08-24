using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.Context;
using VideoMenuDAL.Repositories;

namespace VideoMenuDAL.UnitOfWork
{
    internal class MockUnitOfWork : IUnitOfWork
    {
        public IVideoRepository VideoRepository { get; internal set; }

        private readonly MockContext _mockContext;

        public MockUnitOfWork()
        {
            _mockContext = new MockContext();
            VideoRepository = new MockVideoRepository(_mockContext);
        }
        public int Complete()
        {
            return 0;
        }

        public void Dispose()
        {
            //Doesn't need to be disposed.
        }
    }
}
