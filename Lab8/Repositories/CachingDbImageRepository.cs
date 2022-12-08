using Lab8.DataObjects;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Lab8.Repositories
{
    public class CachingDbImageRepository : DbImageRepository, IImageRepository
    {
        private readonly IMemoryCache _Cache;
        private const string _CacheKey = "ImageList";

        public CachingDbImageRepository(IMemoryCache cache, IConfiguration config) : base(config)
        {
            _Cache = cache;
        }
        public override List<ImageObject> GetImages()
        {
            List<ImageObject> images = (List<ImageObject>)_Cache.Get(_CacheKey);
            if(images == null)
            {
                images = base.GetImages();
                _Cache.Set(_CacheKey, images);
            }
            return images;
        }
        public override void SaveImage(ImageObject image)
        {
            base.SaveImage(image);
            _Cache.Remove(_CacheKey);
        }
    }
}
