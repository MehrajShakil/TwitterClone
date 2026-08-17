using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Domain.Entities;

namespace Twitter.Test
{
    public class Class10Test
    {
        public void Run()
        {
            Tweet likeableTweet = new Tweet("This is another tweet!");

            Console.WriteLine(likeableTweet.CanBeLiked());

            var maxTweetLength = 200;
        }
    }
}
