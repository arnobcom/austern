//Makhlaqur Arnob//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Austern.Model.ClientModel
{
    [Serializable]
    public class News
    {
        
        public int NewsId { get; set; }
        public int UserId { get; set; }
        public EdgeCorpUser CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string Title { get; set; }
        [Display(Name="Article")]
        public string Details { get; set; }
        public string ShortDescription { get { return !string.IsNullOrWhiteSpace(Details) ? (Details.Length > 250 ? Details.Substring(0, 250) + "..." : Details) : string.Empty; } }
        public List<Media> Medias { get; set; }
        public string DisplayImage { get { return Medias != null && Medias.Any() ? string.Format("/images/media/ForNews/{0}.jpg", Medias.FirstOrDefault().MediaId) : string.Empty; } }
       
    }
}
