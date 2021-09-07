using System;
using System.Collections.Generic;
using System.Text;

namespace PostDataAccess
{
    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string time_posted { get; set; }
        public string posted_by { get; set; }
        public int upvotes { get; set; }
        public int downvotes { get; set; }
    }
}
