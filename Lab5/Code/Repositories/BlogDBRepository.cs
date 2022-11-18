using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab5.Code.DataModels;
using Lab5.Code.Repositories;
using System.Data;
using System.Data.SqlClient;
using System.Security.AccessControl;

namespace Lab5.Code.Repositories
{
    public class BlogDBRepository : IDataEntityRepository<BlogPost>
    {
        private readonly IConfiguration _Config;
        public BlogDBRepository(IConfiguration configuration)
        {
            _Config = configuration;
        }

        public BlogPost Get(int id)
        {
            BlogPost blogPost = new BlogPost();
            var conString = _Config["ConnectionStrings:DB_BlogPosts"];
            using SqlConnection connection = new SqlConnection(conString);
            connection.Open();

            using SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.CommandText = @"SELECT * FROM BlogPost Where ID=@ID";
            command.Parameters.AddWithValue("ID", id);

            using SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            blogPost.ID = (int)reader["ID"];
            blogPost.Author = reader["Author"].ToString();
            blogPost.Title = reader["Title"].ToString();
            blogPost.Content = reader["Content"].ToString();
            blogPost.Timestamp = (DateTime)reader["Timestamp"];

            return blogPost;
        }

        public List<BlogPost> GetList()
        {
            List<BlogPost> blogPostList = new List<BlogPost>();

            var conString = _Config["ConnectionStrings:DB_BlogPosts"];
            using SqlConnection connection = new SqlConnection(conString);

            using SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.CommandText = @"SELECT * FROM BlogPost";
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                BlogPost blogPost = new BlogPost();
                blogPost.ID = (int)reader["ID"];
                blogPost.Author = reader["Author"].ToString();
                blogPost.Title = reader["Title"].ToString();
                blogPost.Content = reader["Content"].ToString();
                blogPost.Timestamp = (DateTime)reader["Timestamp"];
                blogPostList.Add(blogPost);
            }

            return blogPostList;
        }

        public void Save(BlogPost entity)
        {
            var conString = _Config["ConnectionStrings:DB_BlogPosts"];
            using SqlConnection connection = new SqlConnection(conString);
            using SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.CommandText = @"INSERT INTO BlogPost Values (@Title, @Content, @Author, @Timestamp)";
            connection.Open();

            if (entity.ID != 0) 
            {
                command.CommandText = @"UPDATE BlogPost SET Title=@Title, Content=@Content, Author=@Author, Timestamp=@Timestamp WHERE ID=@ID";
                command.Parameters.AddWithValue("ID", entity.ID);
            }
            command.Parameters.AddWithValue("Title", entity.Title);
            command.Parameters.AddWithValue("Content", entity.Content);
            command.Parameters.AddWithValue("Author", entity.Author);
            command.Parameters.AddWithValue("Timestamp", entity.Timestamp);
            command.ExecuteNonQuery();
        }
    }
}
