using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Twit
    {
        int TwitId { get; }

        [Required]
        string TwitText { get; set; }
        string Username { get; set; }
        DateTime TwitTime { get { return DateTime.Now; } }
        int Likes { get; set; }
    }
}
