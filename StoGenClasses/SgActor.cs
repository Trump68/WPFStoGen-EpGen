using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes
{
    public class SgActor
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Aliace { set; get; }
        public GenderEnum Gender { set; get; }
        public CountryEnum BornCountry { set; get; }
        public int BornYear { set; get; } = 1900;
        public RaceEnum Race { set; get; }
        public FaceTypeEnum FaceType { set; get; }
        public BodyTypeEnum BodyType { set; get; }
        public ActivityTypeEnum ActivityType { set; get; }
        public int Score { set; get; }
        public string DescriptionShort { set; get; }
        public string DescriptionLong { set; get; }

        public BodyHeightEnum Bd_Height { set; get; } = 0;
        public BodyShouldersEnum Bd_Shoulders { set; get; } = 0;
        public BodyBreastEnum Bd_Breasts { set; get; } = 0;
        public BodyWaistEnum Bd_Waist { set; get; } = 0;
        public BodyHipsEnum Bd_Hips { set; get; } = 0;
        public RoleRelationEnum RoleRelation { set; get; } = 0;
        
        public List<SgMovie> MovieList { set; get; }
        public List<SgPicture> PicList { set; get; }

    }
    public class SgActorRole
    {
        public int Id { set; get; }
        public int ActorId { set; get; }
        public SgActor Actor { set; get; }
        public RoleRelationEnum RoleType { get; internal set; }
        public int ClipId { get; internal set; }
    }
        public class SgPicture
    {
        public string Description { set; get; }
        public Image Picture { set; get; }
    }
}
