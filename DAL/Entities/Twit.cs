using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Twit
    {
        public int TwitId { get; set; }

        [Required]
        public string TwitText { get; set; }
        public string Username { get; set; }
        public DateTime TwitTime { set; get; }
        public int Likes { get; set; }
    }
}
