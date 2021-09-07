using Dapper;
using ForumSiteAPI.Models;
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
                return (List<Post>)connection.Query<Post>("SELECT * FROM Posts WHERE id = @Id", new { Id = id });
            }
        }

        public void AddPost(Post post)
        {
            using (IDbConnection connection = new SqlConnection(CustomConfig.connectionString))
            {
                if (post.posted_by == "")
                {
                    post.posted_by = "anon";
                }

                connection.Query<Post>("INSERT INTO Posts (title, description, posted_by) VALUES (@Title, @Description, @PostedBy);", 
                    new { Title = post.title, Description = post.description, PostedBy = post.posted_by });
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
                connection.Query<Post>("UPDATE Posts SET description = @Description WHERE id = @Id", new { Description = post.description, Id = id });
                return post;
            }
        }

        public void VotePost(int id, Vote vote)
        {
            using (IDbConnection connection = new SqlConnection(CustomConfig.connectionString))
            {
                if (vote.up)
                {
                    connection.Query<Post>("UPDATE Posts SET upvotes = upvotes+1 WHERE id = @Id", new { Id = id });
                } else
                {
                    connection.Query<Post>("UPDATE Posts SET upvotes = upvotes-1 WHERE id = @Id", new { Id = id });
                }
                
            }
        }
    }


}
