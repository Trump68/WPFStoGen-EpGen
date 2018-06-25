Scriptname sslEffectDebug extends ActiveMagicEffect

import PapyrusUtil
import JsonUtil
;SOS_API property sos auto

SexLabFramework property SexLab auto
sslSystemConfig property Config auto
AB_QuestScript property AB_Quest auto


Actor property PlayerRef auto

Actor Ref1
Actor Ref2

float scale1
float scale2

string ActorName
ObjectReference MarkerRef

sslBenchmark function Benchmark(int Tests = 1, int Iterations = 5000, int Loops = 10, bool UseBaseLoop = false)
	return (Quest.GetQuest("SexLabDev") as sslBenchmark).StartBenchmark(Tests, Iterations, Loops, UseBaseLoop)
endFunction


event OnEffectStart(Actor TargetRef, Actor CasterRef)
	;AB_Quest.Test();
	DoAnim(TargetRef, CasterRef)
	;Dispel()
endEvent
		  
bool[] Acycle	  
string[] AbFemaleExpressionList	  
int[] AbFemaleExpressionIndex
string[] AbMaleExpressionList
int[] AbMaleExpressionIndex
int[] Erection
string AbAnimationName
string AbAnimationDescription



function DoAnim(Actor TargetRef, Actor CasterRef) 
  
  ;DoAnim_PlayerSolo() 
  DoAnim_FM_Belenthor() 
  ;DoAnim_FM_Ulfbear() 
  ;DoAnim_FFNihel() 
  ;DoAnim_FM_TEST() 
  
  ;DoAnim_FemSolo("RBD_F000012CB") 
  ;DoAnim_FemSolo("RBD_F0000126AD") 
  ;DoAnim_FemSolo("Iris") 
  ;DoAnim_FemSolo("Nihel") 
endFunction
function DoAnim_PlayerSolo() 
	Actor Anna = Game.GetPlayer();		
	;AddClothing(Anna, "Veil Solid White")
	ObjectReference centerOn =  MoveAndPrepareLocation(Anna, "WhiterunWarmaidens")		
	actor[] positions = sexlabutil.makeactorarray(Anna)	
	SetAnimationMovie0001()
	DoSceneInLocation( Anna, positions, centerOn, "AB01_Shy_Stand");	
endFunction
function DoAnim_FemSolo(string name) 
	Actor Anna = Game.GetPlayer();	
	ObjectReference centerOn =  MoveAndPrepareLocation(Anna, "WhiterunWarmaidens")	
	actor fem   = GetActor(Anna,  name,  "Pubic Hair for Females",  1)	
	actor[] positions = sexlabutil.makeactorarray(fem)	
	SetAnimationMovie0001()
	DoSceneInLocation( Anna, positions, centerOn, "AB01_Shy_Stand");	
endFunction
function DoAnim_FFNihel() 
	Actor Anna = Game.GetPlayer();
	ObjectReference centerOn =  MoveAndPrepareLocation(Anna, "WhiterunWarmaidens")		
	actor Nihel   = GetActor(Anna,    "Nihel",  "VectorPlexus Regular",  0)
    actor[] positions = sexlabutil.makeactorarray(Anna,Nihel)	
	SetAnimationMovie0001()
	DoSceneInLocation( Anna, positions, centerOn, "AB01_Fuck");	
endFunction
function DoAnim_FM_Belenthor() 
	Actor Anna = Game.GetPlayer();	
	;AddClothing(Anna, "Veil Solid White")
	;AddClothing(Anna, "Veil Of Cyan")
	
	ObjectReference centerOn =  MoveAndPrepareLocation(Anna, "WhiterunWarmaidens")	
	actor Belenthor   = GetActor(Anna,    "Belethor",  "Smurf Average",  16)
	actor[] positions = sexlabutil.makeactorarray(Anna,Belenthor)	
	SetAnimationMovie0001()
	DoSceneInLocation( Anna, positions, centerOn, "AB01_Fuck");	
endFunction
function DoAnim_FM_TEST() 
	Actor Anna = Game.GetPlayer();	
	;AddClothing(Anna, "Veil Solid White")
	AddClothing(Anna, "Veil Of Cyan")
	
	ObjectReference centerOn =  MoveAndPrepareLocation(Anna, "WhiterunWarmaidens")	
	actor Belenthor   = GetActor(Anna,    "Belethor",  "Smurf Average",  16)
	actor[] positions = sexlabutil.makeactorarray(Anna)	
	SetAnimationMovie0001()
	DoSceneInLocation( Anna, positions, centerOn, "AB01_Shy_Stand");	
endFunction
function DoAnim_FM_Ulfbear() 
	Actor Anna = Game.GetPlayer();	
	ObjectReference centerOn =  MoveAndPrepareLocation(Anna, "WhiterunWarmaidens")	
	actor Ulfbear     = GetActor(Anna,     "Ulfbear",  "VectorPlexus Muscular",  10)
	actor[] positions = sexlabutil.makeactorarray(Anna,Ulfbear)	
	SetAnimationMovie0001()
	DoSceneInLocation( Anna, positions, centerOn, "AB01_Fuck");	
endFunction

function DoSceneInLocation(actor victim, actor[]positions, ObjectReference centerOn, string animid)     
	  ; play animation
	  sslbaseanimation anim = sexlab.GetAnimationByRegistry(animid)
	  anim.AB_Tag="Test01"
	  sslbaseanimation[] anims = new sslbaseanimation[1]	
	  anims[0] = anim 
	  sexlab.Config.InDebugMode = True
	  int scenevar = 1	  
	  sexlab.AB_StartSex("", scenevar, positions, anims, none, centerOn ) 

EndFunction


actor function GetActor(actor player, string acName,string schlong, int sossize = 0, float height = 0.0)
        
		actor result = none
		Actorbase an = none
		if     (acName == "Ulfbear")
		         an = Game.GetFormFromFile(0x00013b9f,"Skyrim.esm") as Actorbase
				 result = player.PlaceActorAtMe(an)	
		elseIf (acName == "Belethor")
		         result = FindActor(acName)
				 if (result == none)				     
		             an = Game.GetFormFromFile(0x00013ba1,"Skyrim.esm") as Actorbase
					 result = player.PlaceActorAtMe(an)	
                 else
				     return result
				 endif		
				 
		elseIf (acName == "RBD_F000012CB")
		         an = Game.GetFormFromFile(0x000012CB,"[kiki]kkFollowers2.esp") as Actorbase
				 result = player.PlaceActorAtMe(an)	
		elseIf (acName == "RBD_F0000126AD")
		         an = Game.GetFormFromFile(0x0000126AD,"[kiki]kkFollowers2.esp") as Actorbase
				 result = player.PlaceActorAtMe(an)					 
				 
				 
				 
		elseIf (acName == "Iris")
		         an = Game.GetFormFromFile(0x00003890,"R.B Standalone Follower.esp") as Actorbase	
                 result = player.PlaceActorAtMe(an)					 
				 result.GetActorBase().SetHeight(0.96)
		elseIf (acName == "Nihel")
		         an = Game.GetFormFromFile(0x00000D70,"Nihel.esp") as Actorbase
                 result = player.PlaceActorAtMe(an)	
		endIf		
		if (an != none)		   
		   
		   
		   LockActor(result)
		   Utility.Wait(2.0)
		   result.RemoveAllItems()
		   Utility.Wait(2.0)
		   SetSchlong(result, schlong, sossize)
		   if (height > 0)
		      ;result.SetHei
		   endif
		endif		
		return result
EndFunction

function AddClothing(actor npc, string clothName)
		Form cloth
        If     (clothName   == "Veil Solid Black")
		        cloth = Game.GetFormFromFile(0x00003DDB,"Veil Recoloring.esp")	
        ElseIf (clothName   == "Veil Of Black")
		        cloth = Game.GetFormFromFile(0x00004E0A,"Veil Recoloring.esp")					
        ElseIf (clothName   == "Veil Solid White")
		        cloth = Game.GetFormFromFile(0x00005E4B,"Veil Recoloring.esp")
		ElseIf (clothName   == "Veil Of White")
		        cloth = Game.GetFormFromFile(0x00004E06,"Veil Recoloring.esp")		
	    ElseIf (clothName   == "Veil Of Emerald")
		        cloth = Game.GetFormFromFile(0x000058E4,"Veil Recoloring.esp")
		ElseIf (clothName   == "Veil Of Purple")
		        cloth = Game.GetFormFromFile(0x00005E50,"Veil Recoloring.esp")
		ElseIf (clothName   == "Veil Of Lavender")
		        cloth = Game.GetFormFromFile(0x000063B7,"Veil Recoloring.esp")
		ElseIf (clothName   == "Veil Of Cyan")
		        cloth = Game.GetFormFromFile(0x00000D63,"Veil Recoloring.esp")
		ElseIf (clothName   == "Veil Of Royal Blue")
		        cloth = Game.GetFormFromFile(0x00005372,"Veil Recoloring.esp")		
		ElseIf (clothName   == "Veil Of Baby Blue")
		        cloth = Game.GetFormFromFile(0x00005378,"Veil Recoloring.esp")	
		ElseIf (clothName   == "Veil Of Red")
		        cloth = Game.GetFormFromFile(0x0000058F,"Veil Recoloring.esp")					
		endIf		
		if (cloth == none)
		             Debug.Notification("Not found "+clothName)
		else
					 npc.AddItem(cloth, 1, true)
                     ;Utility.Wait(1)
                     npc.EquipItem(cloth)
		endif
EndFunction


actor function FindActor(string name)
Cell kCell = Game.GetPlayer().GetParentCell()
Int iIndex = kCell.GetNumRefs(62)
while (iIndex)
    iIndex -= 1
    actor ac = kCell.GetNthRef(iIndex, 62) as actor
	actorBase abf = ac.GetActorBase()
	;int fid = abf.GetFormID()
	string an = abf.Getname();
	;Debug.Notification("FID:"+an)
	if (name == an)
	   ;Debug.Notification("!!!!!! Found " + an)
	   return  ac
	endif
endwhile
return none
endFunction


ObjectReference function MoveAndPrepareLocation(actor player, string LocationID)
       ; move to cell
	   ;victim.MoveTo(LocRef)	
       ; Cell kCell = player.GetParentCell()
	   ; Int iIndex = kCell.GetNumRefs(62) ; kCharacter  = 62
	   ; While iIndex
		  ; iIndex -= 1
		  ; kCell.GetNthRef(iIndex, 62).Disable(false) 
	   ; EndWhile
	   	   
	   ObjectReference centerOn = none
	   if (LocationID == "WhiterunWarmaidens"); 0001DB4E
	      ;remove char
	      ObjectReference obstacle = Game.GetForm(0x000bbb27) as ObjectReference
	      obstacle.Disable(false) 
		  ;remove baba
		  obstacle= Game.GetForm(0x0001a67c) as Actor
	      obstacle.Disable(false) 
		  ;remove Ulfbear
		  obstacle= Game.GetForm(0x000d15b0) as Actor
	      obstacle.Disable(false) 
		  ; centerOn
		  centerOn = Game.GetForm(0x000bbb49) as ObjectReference ; ковпик в холле у камина
		  ;centerOn = Game.GetForm(0x0001db55) as ObjectReference ; кровать на 2 эттаже
		  
	   endIf 
	   return centerOn;
EndFunction


function SetSchlong(Actor NPCActor, string schlong, int size)
	;Form cock = sos.FindSchlongByName("VectorPlexus Regular")
	;Form cock = sos.FindSchlongByName("VectorPlexus Muscular")
	;Form cock = sos.FindSchlongByName("Smurf Average")  
    if (size < 1)
	   return
    endif	
    SOS_API sos = SOS_API.Get()
	Form cock = sos.GetSchlong(NPCActor);
	if (cock == none)
	   cock = sos.FindSchlongByName(schlong)
       if (cock == none)	   
	         Debug.Notification("Cock not found: " + schlong)
	   endif
	endif
    if (sos.GetSize(NPCActor) != size)
	    sos.SetSize(NPCActor, size)		
		Debug.Notification("set size: " + size)
	endif
	Game.UpdateHairColor()

EndFunction


event OnUpdate()
endEvent

event OnEffectFinish(Actor TargetRef, Actor CasterRef)                    
	;/ if MarkerRef
		TargetRef.SetVehicle(none)
		MarkerRef.Disable()
		MarkerRef.Delete()
		MarkerRef = none
	endIf /;
endEvent


function SetAnimationMovie0001()
    Resetscene()
    SetAnimationScene0001(1)
    SetAnimationScene0002(2)
	SetAnimationScene0003(3)
	SetAnimationScene0004(4)
	SetAnimationScene0005(5)
	Erection[1] = 4;
	Erection[2] = 4;
	Erection[3] = 4;
	Erection[4] = 4;
	Erection[5] = 4;
EndFunction
function SetAnimationScene0001(int stage)
    SetAnimationF0001a("AB01_Fuck_A1_S1", stage)
	SetAnimationM0002("AB01_Fuck_A2_S1", stage)
EndFunction
function SetAnimationScene0002(int stage)
    SetAnimationF0002a("AB01_Fuck_A1_S2", stage)
	SetAnimationM0003("AB01_Fuck_A2_S2", stage)	
EndFunction
function SetAnimationScene0003(int stage)
    SetAnimationF0003("AB01_Fuck_A1_S3", stage)
	SetAnimationM0004("AB01_Fuck_A2_S3", stage)	
EndFunction
function SetAnimationScene0004(int stage)
    SetAnimationF0004("AB01_Fuck_A1_S4", stage)
	SetAnimationM0005("AB01_Fuck_A2_S4", stage)	
EndFunction
function SetAnimationScene0005(int stage)
    SetAnimationF0005("AB01_Fuck_A1_S5", stage)
	SetAnimationM0006("AB01_Fuck_A2_S5", stage)	
EndFunction

function SetAnimationF0001a(string AnimationCode, int stage)
    AbAnimationName = "[AnimationsByLeito]-Leito_69-Stage01-Female Handjob ver 001a"
    AbAnimationDescription = "Same as orig, but speed reduced 400"	
	AbFemaleExpressionList[stage] = "AB_FuckDisgust01"
	AbFemaleExpressionIndex[stage] = 1
EndFunction
function SetAnimationF0001a1(string AnimationCode, int stage)
    AbAnimationName = "[AnimationsByLeito]-Leito_69-Stage01-Female Handjob ver 001a"
    AbAnimationDescription = "Same as F0001a, but head pose changed"	
	AbFemaleExpressionList[stage] = "AB_Shy01"
	AbFemaleExpressionIndex[stage] = 1
EndFunction
function SetAnimationF0001a2(string AnimationCode, int stage)
    AbAnimationName = "[AnimationsByLeito]-Leito_69-Stage01-Female Handjob ver 001a2"
    AbAnimationDescription = "Same as F0001a1, but head pose changed again"	
	AbFemaleExpressionList[stage] = "AB_Shy01"
	AbFemaleExpressionIndex[stage] = 1
EndFunction
function SetAnimationF0001a3(string AnimationCode, int stage)
    AbAnimationName = "[AnimationsByLeito]-Leito_69-Stage01-Female Handjob ver 001a3"
    AbAnimationDescription = "Same as F0001a1, but head pose changed again"	
	AbFemaleExpressionList[stage] = "AB_Shy01"
	AbFemaleExpressionIndex[stage] = 1
EndFunction


function SetAnimationF0002a(string AnimationCode, int stage)
    AbAnimationName = "[AnimationsByLeito]-Leito_69-Stage01-Female Handjob ver 002a"
    AbAnimationDescription = "Same as orig, but speed reduced 400"	
	AbFemaleExpressionList[stage] = "AB_FuckDisgust01"
	AbFemaleExpressionIndex[stage] = 1
EndFunction
function SetAnimationF0002a1(string AnimationCode, int stage)
    AbAnimationName = "[AnimationsByLeito]-Leito_69-Stage01-Female Handjob ver 002a1"
    AbAnimationDescription = "Same as F0002a, but head pose changed"	
	AbFemaleExpressionList[stage] = "AB_Shy01"
	AbFemaleExpressionIndex[stage] = 1
EndFunction
function SetAnimationF0002a2(string AnimationCode, int stage)
    AbAnimationName = "[AnimationsByLeito]-Leito_69-Stage01-Female Handjob ver 002a2"
    AbAnimationDescription = "Same as F0002a1, but head pose changed again"	
	AbFemaleExpressionList[stage] = "AB_Shy01"
	AbFemaleExpressionIndex[stage] = 1
EndFunction
function SetAnimationF0003(string AnimationCode, int stage)
    AbAnimationName = "[AnimationsByLeito]-Leito_69-Stage02-Female Handjob ver 001"
    AbAnimationDescription = "Same as original, but speed reduced 400, hand pose fixed for Smurf Average 10"	
	AbFemaleExpressionList[stage] = "AB_FuckDisgust01"
	AbFemaleExpressionIndex[stage] = 1
EndFunction
function SetAnimationF0004(string AnimationCode, int stage)
    AbAnimationName = "[AnimationsByLeito]-Leito_69-Stage03-Female BJ ver 001"
    AbAnimationDescription = "Same as original, but hand pose fixed for Smurf Average 10"	
	AbFemaleExpressionList[stage] = "AB_BJ01"
	AbFemaleExpressionIndex[stage] = 1
EndFunction
function SetAnimationF0005(string AnimationCode, int stage)
    AbAnimationName = "[AnimationsByLeito]-Leito_69-Stage04-Female BJ ver 001"
    AbAnimationDescription = "Same as original, but hand pose fixed for Smurf Average 10"	
	AbFemaleExpressionList[stage] = "AB_BJ01"
	AbFemaleExpressionIndex[stage] = 1
EndFunction
function SetAnimationF0007(string AnimationCode, int stage)
    AbAnimationName = "[AnimationsByLeito]-Leito_69-Stage04-Female BJ ver 002"
    AbAnimationDescription = "Same as SetAnimationF0005, but kissing cok"	
	AbFemaleExpressionList[stage] = "AB_BJ01"
	AbFemaleExpressionIndex[stage] = 1
EndFunction
function SetAnimationF0006(string AnimationCode, int stage)
    AbAnimationName = "[AnimationsByLeito]-Leito_69-Stage05-Female BJ orgazm ver 001"
    AbAnimationDescription = "Same as original, but hand pose fixed for Smurf Average 10"	
	AbFemaleExpressionList[stage] = "AB_BJ01"
	AbFemaleExpressionIndex[stage] = 1
EndFunction


function SetAnimationM0002(string AnimationCode, int stage)
    AbAnimationName = "[AnimationsByLeito]-Leito_69-Stage01-Male Kuni ver 002"
    AbAnimationDescription = "Same as M0001, but speed reduced 400"	
	AbMaleExpressionList[stage] = "Pained"
	AbMaleExpressionIndex[stage] = 1
	Erection[stage] = 0;
EndFunction
function SetAnimationM0003(string AnimationCode, int stage)
    AbAnimationName = "[AnimationsByLeito]-Leito_69-Stage02-Male Kuni ver 001"
    AbAnimationDescription = "Same as original, but speed reduced 400, hand pose fixed"	
	AbMaleExpressionList[stage] = "Pained"
	AbMaleExpressionIndex[stage] = 1
	Erection[stage] = 0;
EndFunction
function SetAnimationM0004(string AnimationCode, int stage)
    AbAnimationName = "[AnimationsByLeito]-Leito_69-Stage03-Male Kuni ver 001"
    AbAnimationDescription = "Same as original, but speed reduced 400, hand pose fixed"	
	AbMaleExpressionList[stage] = "Pained"
	AbMaleExpressionIndex[stage] = 1
	Erection[stage] = 0;
EndFunction
function SetAnimationM0005(string AnimationCode, int stage)
    AbAnimationName = "[AnimationsByLeito]-Leito_69-Stage04-Male Kuni ver 001"
    AbAnimationDescription = "Same as original, but speed reduced 400, hand pose fixed"	
	AbMaleExpressionList[stage] = "Pained"
	AbMaleExpressionIndex[stage] = 1
	Erection[stage] = 0;
EndFunction
function SetAnimationM0006(string AnimationCode, int stage)
    AbAnimationName = "[AnimationsByLeito]-Leito_69-Stage05-Male Kuni orgazm ver 001"
    AbAnimationDescription = "Same as original, but speed reduced 400, hand pose fixed"	
	AbMaleExpressionList[stage] = "Pained"
	AbMaleExpressionIndex[stage] = 1
	Erection[stage] = 0;
EndFunction


function SetPhotoF0001(int stage)
    AbAnimationName = "[AnimationsByLeito]-Leito_69-Female Naughty ver 001"
    AbAnimationDescription = ""	
	AbFemaleExpressionList[stage] = "AB_Naughty06"	
EndFunction
function SetPhotoF0002(int stage)
    AbAnimationName = "[AnimationsByLeito]-Leito_69-Female Naughty ver 002"
    AbAnimationDescription = ""	
	AbFemaleExpressionList[stage] = "AB_NaughtyKiss01"	
EndFunction
function SetPhotoF0003(int stage)
    AbAnimationName = "[AnimationsByLeito]-Leito_69-Female Naughty ver 002"
    AbAnimationDescription = ""	
	AbFemaleExpressionList[stage] = "AB_NaughtyKiss02"	
EndFunction

;/-----------------------------------------------\;
;|	Debug Utility Functions                      |;
;\-----------------------------------------------/;


float[] function OffsetCoords(float[] Loc, float[] CenterLoc, float[] Offsets)
	Loc[0] = CenterLoc[0] + ( Math.sin(CenterLoc[5]) * Offsets[0] ) + ( Math.cos(CenterLoc[5]) * Offsets[1] )
	Loc[1] = CenterLoc[1] + ( Math.cos(CenterLoc[5]) * Offsets[0] ) + ( Math.sin(CenterLoc[5]) * Offsets[1] )
	Loc[2] = CenterLoc[2] + Offsets[2]
	Loc[3] = CenterLoc[3]
	Loc[4] = CenterLoc[4]
	Loc[5] = CenterLoc[5] + Offsets[3]
	if Loc[5] >= 360.0
		Loc[5] = Loc[5] - 360.0
	elseIf Loc[5] < 0.0
		Loc[5] = Loc[5] + 360.0
	endIf
	return Loc
endFunction

float function Scale(Actor ActorRef)
	float display = ActorRef.GetScale()
	ActorRef.SetScale(1.0)
	float base = ActorRef.GetScale()
	float ActorScale = ( display / base )
	ActorRef.SetScale(ActorScale)
	float AnimScale = (1.0 / base)
	return AnimScale
endFunction

function LockActor(actor ActorRef)
	ActorRef.StopCombat()
	; Disable movement
	if ActorRef == SexLab.PlayerRef
		Game.DisablePlayerControls(false, false, false, false, false, false, true, false, 0)
		Game.ForceThirdPerson()
		; Game.SetPlayerAIDriven()
	else
		ActorRef.SetRestrained(true)
		ActorRef.SetDontMove(true)
	endIf
	; Start DoNothing package
	ActorUtil.AddPackageOverride(ActorRef, SexLab.ActorLib.DoNothing, 100)
	ActorRef.SetFactionRank(SexLab.AnimatingFaction, 1)
	ActorRef.EvaluatePackage()
endFunction

function UnlockActor(actor ActorRef)
	; Enable movement
	if ActorRef == SexLab.PlayerRef
		Game.EnablePlayerControls(false, false, false, false, false, false, true, false, 0)
		; Game.SetPlayerAIDriven(false)
	else
		ActorRef.SetRestrained(false)
		ActorRef.SetDontMove(false)
	endIf
	; Remove from animation faction
	ActorUtil.RemovePackageOverride(ActorRef, SexLab.ActorLib.DoNothing)
	ActorRef.RemoveFromFaction(SexLab.AnimatingFaction)
	ActorRef.EvaluatePackage()
	; Detach positioning marker
	ActorRef.StopTranslation()
	ActorRef.SetVehicle(none)
endFunction

function Resetscene()
	Acycle = new bool[128];
    Erection = new int[128];
	Erection[1] = 0;
	Erection[2] = 0;
	Erection[3] = 0;
	Erection[4] = 0;
	Erection[5] = 0;
	Erection[6] = 0;
	Erection[7] = 0;
	Erection[8] = 0;
	Erection[9] = 0;
	Erection[10] = 0;
	AbFemaleExpressionList = new string[128];
    AbFemaleExpressionList[1] = "AB_FuckDisgust01"
	AbFemaleExpressionList[2] = "AB_FuckDisgust01"
    AbFemaleExpressionList[3] = "AB_FuckDisgust01"
    AbFemaleExpressionList[4] = "AB_FuckDisgust01"
    AbFemaleExpressionList[5] = "AB_FuckDisgust01"
    AbFemaleExpressionList[6] = "AB_FuckDisgust01"
    AbFemaleExpressionList[7] = "AB_FuckDisgust01"
    AbFemaleExpressionList[8] = "AB_FuckDisgust01"
    AbFemaleExpressionList[9] = "AB_FuckDisgust01"
    AbFemaleExpressionList[10] = "AB_FuckDisgust01"
    AbFemaleExpressionIndex = new int[128];
    AbFemaleExpressionIndex[1] = 1
	AbFemaleExpressionIndex[2] = 1
	AbFemaleExpressionIndex[3] = 1
	AbFemaleExpressionIndex[4] = 1
	AbFemaleExpressionIndex[5] = 1	
	AbFemaleExpressionIndex[6] = 1
	AbFemaleExpressionIndex[7] = 1
	AbFemaleExpressionIndex[8] = 1
	AbFemaleExpressionIndex[9] = 1
	AbFemaleExpressionIndex[10] = 1
	AbMaleExpressionList = new string[128];
    AbMaleExpressionList[1] = "Pained"
	AbMaleExpressionList[2] = "Pained"
    AbMaleExpressionList[3] = "Pained"
    AbMaleExpressionList[4] = "Pained"
    AbMaleExpressionList[5] = "Pained"
    AbMaleExpressionList[6] = "Pained"
    AbMaleExpressionList[7] = "Pained"
    AbMaleExpressionList[8] = "Pained"
    AbMaleExpressionList[9] = "Pained"
    AbMaleExpressionList[10] = "Pained"
    AbMaleExpressionIndex = new int[128];
    AbMaleExpressionIndex[1] = 1
	AbMaleExpressionIndex[2] = 1
	AbMaleExpressionIndex[3] = 1
	AbMaleExpressionIndex[4] = 1
	AbMaleExpressionIndex[5] = 1	
	AbMaleExpressionIndex[6] = 1
	AbMaleExpressionIndex[7] = 1
	AbMaleExpressionIndex[8] = 1
	AbMaleExpressionIndex[9] = 1
	AbMaleExpressionIndex[10] = 1
	
endFunction
		  ;expression = Config.ExpressionSlots.GetByName("AB_Pained01")		  		  
		  ;expression = Config.ExpressionSlots.GetByName("AB_Silly01") 
		  ;actAlias.AB_EmotionLevel = 1		;Silly		  
		  ;actAlias.AB_EmotionLevel = 2		;fucksilly 		  
		  ;actAlias.AB_EmotionLevel = 3		;fucksilly2			  
		  ;actAlias.AB_EmotionLevel = 4		;fucksilly3			  
		  ;actAlias.AB_EmotionLevel = 5		;fucksilly4		
		  ;expression = Config.ExpressionSlots.GetByName("AB_FuckDisgust01") 
		  ;emotionStage = 1		;fuckdisgust 
          ;emotionStage = 2		;fucksnuffground
          ;emotionStage = 3		;fucksnufffear
		  ;emotionStage = 4		;fucksnuffed
		  ;emotionStage = 5		;fuckhitbelow		  
		  ;expression = Config.ExpressionSlots.GetByName("AB_FuckReluctant01") 
		  ;emotionStage = 1		;fuckunreluctant 
		  ;emotionStage = 2		;fuckunreluctorgasm
		  ;emotionStage = 3		;fuckpuzzle1
		  ;emotionStage = 4		;fuckunreluct2
		  ;emotionStage = 5		;fuckunreluct2alt		  
		  ;expression = Config.ExpressionSlots.GetByName("AB_FuckPleasured01") 
		  ;emotionStage = 1		;pleasured1 
