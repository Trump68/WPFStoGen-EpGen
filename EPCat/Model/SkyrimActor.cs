using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPCat.Model
{
    public enum ActorEnumeration
    {
        Player,
        Ulfbear, //0x00013b9f,"Skyrim.esm"
        Belentor, //0x00013ba1,"Skyrim.esm"
    }

    public class SkyrimActor
    {
        public ActorEnumeration ActorBase { get; set; }
        public string ID { set; get; }
        public string Storage { set; get; }
        public string Name { get; internal set; }
        public string SchlongName { get; internal set; }
        public int SchlongSize { get; internal set; }

        public SkyrimActor(
            ActorEnumeration actorbase,
            string id,
            string storage,
            string name,
            string schlongName,
            int schlongSize)
        {
            ActorBase = actorbase;
            ID = id;
            Storage = storage;
            Name = name;
            SchlongName = schlongName;
            SchlongSize = schlongSize;
        }
        public List<string> Game_PlaceAtMe(string placeAtMe)
        {
            List<string> result = new List<string>();
            result.Add($@"  Actorbase {Name}base = Game.GetFormFromFile({ID}, ""{Storage}"") as Actorbase");
            result.Add($@"  Actor {Name} = {placeAtMe}.PlaceActorAtMe({Name}base)");
            result.Add($@"  AB_SetActorSchlong({Name}, ""{SchlongName}"", {SchlongSize})");
            return result;
        }
        public static List<string> GetPlayer()
        {
            List<string> result = new List<string>();
            result.Add("  Actor Player = Game.GetPlayer()");
            return result;
        }

        //        public static List<string> Game_Lock()
        //        {
        //            List<string> result = new List<string>();
        //            result.Add("function LockActor(actor ActorRef)");
        //            result.Add("  ActorRef.StopCombat()");
        //            result.Add("  ; Disable movement");
        //            result.Add("  if ActorRef == SexLab.PlayerRef");
        //            result.Add("     Game.DisablePlayerControls(false, false, false, false, false, false, true, false, 0)");
        //            result.Add("     Game.ForceThirdPerson()");
        //            result.Add("     ; Game.SetPlayerAIDriven()");
        //            result.Add("  else");
        //            result.Add("     ActorRef.SetRestrained(true)");
        //            result.Add("     ActorRef.SetDontMove(true)");
        //            result.Add("  endIf");
        //            result.Add("  ; Start DoNothing package");
        //            result.Add("  ActorUtil.AddPackageOverride(ActorRef, SexLab.ActorLib.DoNothing, 100)");
        //            result.Add("  ActorRef.SetFactionRank(SexLab.AnimatingFaction, 1)");
        //            result.Add("  ActorRef.EvaluatePackage()");
        //            result.Add("endFunction");
        //            return result;
        //        }
        //        public static List<string> Game_SetSchlong()
        //        {
        //            //; Form cock = sos.FindSchlongByName("VectorPlexus Regular")
        //            //; Form cock = sos.FindSchlongByName("VectorPlexus Muscular")
        //            //; Form cock = sos.FindSchlongByName("Smurf Average")
        //            List<string> result = new List<string>();
        //            result.Add("function SetSchlong(Actor NPCActor, string schlong, int size)");
        //            result.Add("  if (size < 1)");
        //            result.Add("     return");
        //            result.Add("  endif");
        //            result.Add("  SOS_API sos = SOS_API.Get()");
        //            result.Add("  Form cock = sos.GetSchlong(NPCActor);");
        //            result.Add("  if (cock == none)");
        //            result.Add("      cock = sos.FindSchlongByName(schlong)");
        //            result.Add("  if (cock == none)");
        //            result.Add(@"      Debug.Notification(""Cock not found: "" + schlong)""");
        //            result.Add("  endif");
        //            result.Add("endif");
        //            result.Add("");
        //            result.Add("");
        //            result.Add("");
        //            result.Add("");
        //            result.Add("");
        //            result.Add("endFunction");
        //            return result;















        //    if (sos.GetSize(NPCActor) != size)
        //                sos.SetSize(NPCActor, size)

        //    endif

        //    Game.UpdateHairColor()

        //EndFunction

        //        }

    }
    public static class ActorFactory
    {
        public static SkyrimActor Get(ActorEnumeration actorbase)
        {
            if (actorbase == ActorEnumeration.Player) return Player;
            else if (actorbase == ActorEnumeration.Ulfbear) return Ulfbear;
            else if (actorbase == ActorEnumeration.Belentor) return Belentor;
            return null;
        }
        static SkyrimActor _Ulfbear;
        public static SkyrimActor Ulfbear
        {
            get
            {
                if (_Ulfbear == null)
                {
                    _Ulfbear = new SkyrimActor(
                        ActorEnumeration.Ulfbear,
                        "0x00013b9f",
                        "Skyrim.esm",
                        "Ulfbear",
                        "VectorPlexus Regular", 13);
                }
                return _Ulfbear;
            }
        }
        static SkyrimActor _Belentor;
        public static SkyrimActor Belentor
        {
            get
            {
                if (_Belentor == null)
                {
                    _Belentor = new SkyrimActor(ActorEnumeration.Belentor,
                        "0x00013ba1",
                        "Skyrim.esm",
                        "Belentor",
                        "Smurf Average", 14);
                }
                return _Belentor;
            }
        }
        static SkyrimActor _Player;
        public static SkyrimActor Player
        {
            get
            {
                if (_Player == null)
                {
                    _Player = new SkyrimActor(ActorEnumeration.Player, null, null, "Player", null, 0);
                }
                return _Player;
            }
        }

    }
}
