using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SocialLink: Entity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public User User { get; set; }

        public SocialLink() : base()
        {

        }

        public SocialLink(int userId, string name, string url)
        {
            UserId = userId;
            Name = name;
            Url = url;
        }
    }
}
