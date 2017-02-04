using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes
{
    public class SgClip
    {
        public int Id { set; get; }
        public ProductionTypeEnum SetType { set; get; }
        public int SetId { set; get; }
        public string Path { set; get; }
        public string OldFileName { set; get; }
        public string Description { set; get; }
        public List<SgActorRole> ActorRoleList { set; get; }

        public SgMovie Movie { set; get; }
        public SgActorRole MainRole
        {
            get
            {
                return ActorRoleList?.FirstOrDefault();
            }
        }

        public string Name { get { return Movie?.Name ?? string.Empty; } }
        public int ProductionYear { get { return Movie?.ProductionYear ?? 1900; } }
        public GenreEnum Genre { get { return (GenreEnum)(Movie?.Genre ?? 0); } }
        public GenreTypeEnum GenreType { get { return (GenreTypeEnum)(Movie?.GenreType ?? 0); } }
        public CountryEnum Country { get { return (CountryEnum)(Movie?.Country ?? 0); } }
        public ProductionTypeEnum ProductionType { get { return (ProductionTypeEnum)(Movie?.ProductionType ?? 0); } }
        public string Studio { get { return Movie?.Studio ?? string.Empty; } }
        public string Director { get { return Movie?.Director ?? string.Empty; } }
        public int Score { get { return Movie?.Score ?? 0; } }
        public string SerieName { get { return Movie?.SerieName ?? string.Empty; } }
        public int SerieSeason { get { return Movie?.SerieSeason ?? 0; } }
        public int SerieEpisode { get { return Movie?.SerieEpisode ?? 0; } }
        public string DescriptionShort { get { return Movie?.DescriptionShort ?? string.Empty; } }
        public string DescriptionLong { get { return Movie?.DescriptionLong ?? string.Empty; } }
        public string Aliace { get { return Movie?.Aliace ?? string.Empty; } }

        public string ActorName { get { return MainRole?.Actor?.Name ?? string.Empty; } }
        public string ActorRole
        { get
            {
                if (MainRole == null) return null;
                if (MainRole.RoleType == RoleRelationEnum.Актер) return null;
                return Enum.GetName( typeof(RoleRelationEnum), MainRole.RoleType);                
            }
        }
    }


}
