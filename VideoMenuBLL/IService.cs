using System.Collections.Generic;
using VideoMenuEntities;

namespace VideoMenuBLL
{
    public interface IService<TEntity>
    {
        //C
        TEntity CreateVideo(string nameOfVideo);
        
        //R
        List<TEntity> GetVideos();
        TEntity GetVideo(int id);
        List<TEntity> SearchVideos(string searchQuery);

        //U
        void UpdateVideo(TEntity video);

        //D
        TEntity DeleteVideo(int idOfVideo);
    }
}
