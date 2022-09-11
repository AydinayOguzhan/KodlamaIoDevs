using Application.Features.SocialLinks.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialLinks.Models
{
    public class SocialLinkListModel:BasePageableModel
    {
        public IList<SocialLinkListDto> Items { get; set; }
    }
}
