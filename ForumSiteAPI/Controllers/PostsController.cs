using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ForumSiteAPI.Models;
using PostDataAccess;

namespace ForumSiteAPI.Controllers
{
    public class PostsController : ApiController
    {

        List<Post> posts = new List<Post>();
        DBAccess db = new DBAccess();

        // GET: api/Posts
        [HttpGet]
        public List<Post> Get()
        {
            posts = db.GetPosts();
            return posts;
        }

        // GET: api/Posts/5
        [HttpGet]
        public List<Post> Get(int id)
        {
            posts = db.GetSinglePost(id);
            return posts;
        }

        // POST: api/Posts
        [HttpPost]
        [EnableCors(origins: "http://127.0.0.1:5501", headers: "*", methods: "*")]
        public Post Post(Post post)
        {
            db.AddPost(post);
            return post;
        }

        // PUT: api/Posts/5
        [HttpPut]
        public Post Put(int id, Post post)
        {
            return db.UpdatePost(id, post);
        }

        [Route("api/posts/{id}/vote")]
        [HttpPut]
        [EnableCors(origins: "http://127.0.0.1:5501", headers: "*", methods: "*")]
        public string PutVote(int id, Vote vote)
        {
            db.VotePost(id, vote);
            return "Success";
        }

        // DELETE: api/Posts/5
        [HttpDelete]
        public void Delete(int id)
        {
            db.DeletePost(id);
        }
    }
}
