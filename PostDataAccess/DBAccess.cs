using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PostDataAccess
{
    public class DBAccess
    {
        public List<Post> GetPosts()
        {
            using (IDbConnection connection = new SqlConnection(CustomConfig.connectionString))
            {
                return (List<Post>)connection.Query<Post>("SELECT * FROM Posts");
            }
        }

        public List<Post> GetSinglePost(int id)
        {
            using (IDbConnection connection = new SqlConnection(CustomConfig.connectionString))
            {
                return (List<Post>)connection.Query<Post>("SELECT * FROM Posts WHERE id = @id", new { id = id });
            }
        }

        public void AddPost(Post post)
        {
            using (IDbConnection connection = new SqlConnection(CustomConfig.connectionString))
            {
                connection.Query<Post>("INSERT INTO Posts (title, description) VALUES (@Title, @Description);", new { Title = post.title, Description = post.description });
            }
        }

        public void DeletePost(int id)
        {
            using (IDbConnection connection = new SqlConnection(CustomConfig.connectionString))
            {
                connection.Query<Post>("DELETE FROM Posts WHERE id = @Id", new { Id = id });
            }
        }

        public Post UpdatePost(int id, Post post)
        {
            using (IDbConnection connection = new SqlConnection(CustomConfig.connectionString))
            {
                connection.Query<Post>($"UPDATE Posts SET description = @Description WHERE id = @Id", new { Description = post.description, Id = id });
                return post;
            }
        }
    }


}
