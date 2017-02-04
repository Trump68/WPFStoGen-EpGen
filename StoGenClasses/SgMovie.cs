using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes
{
    public class SgMovie
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int ProductionYear { set; get; } = 1900;
        public GenreEnum Genre { set; get; }
        public GenreTypeEnum GenreType { set; get; }
        public CountryEnum Country { set; get; }
        public string Studio { set; get; }
        public string Director { set; get; }
        public int Score { set; get; }
        public ProductionTypeEnum ProductionType { set; get; }
        public string SerieName { set; get; }
        public int SerieSeason { set; get; }
        public int SerieEpisode { set; get; }
        public string DescriptionShort { set; get; }
        public string DescriptionLong { set; get; }
        public string Aliace { get; internal set; }
        public List<SgActor> ActorList { set; get; }
    }


}
