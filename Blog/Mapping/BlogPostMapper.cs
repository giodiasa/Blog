using Blog.Entities;
using Blog.Interfaces;
using Blog.Models;

namespace Blog.Mapping
{
    public class BlogPostMapper : IMapper<BlogPost, BlogPostModel>
    {
        public BlogPostModel MapFromEntityToModel(BlogPost source)
        {
            return new BlogPostModel
            {
                Id = source.Id,
                Title = source.Title,
                Text = source.Text,
                UserId = source.UserId,
                CreateDate = source.CreateDate
            };
        }

        public BlogPost MapFromModelToEntity(BlogPostModel source)
        {
            var entity = new BlogPost();
            MapFromModelToEntity(source, entity);
            return entity;
        }

        public void MapFromModelToEntity(BlogPostModel source, BlogPost target)
        {
            target.Id = source.Id;
            target.Title = source.Title;
            target.Text = source.Text;
            target.CreateDate = source.CreateDate;
            target.UserId = source.UserId;
        }
    }
}
