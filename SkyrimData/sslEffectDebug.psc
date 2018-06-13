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

		  
bool[] Acycle	  
string[] AbFemaleExpressionList	  
int[] AbFemaleExpressionIndex
string[] AbMaleExpressionList
int[] AbMaleExpressionIndex
int[] Erection
int RestartStage

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
	RestartStage = 500
endfunction

function DoAnim(Actor TargetRef, Actor CasterRef) 

	;miscutil.setfreecamerastate(true)
	;miscutil.setfreecameraspeed(config.autosucsm)

	Actor Anna = Game.GetPlayer();
	
	ObjectReference centerOn =  MoveAndPrepareLocation(Anna, "WhiterunWarmaidens")	

	;actor Ulfbear     = GetActor(Anna,     "Ulfbear",  "VectorPlexus Muscular",  10)
	actor Belenthor   = GetActor(Anna,    "Belenthor",  "VectorPlexus Regular",  10)
	;actor Belenthor1   = GetActor(Anna,    "Belenthor",  "Smurf Average",  14)
	;actor Nihel       = GetActor(Anna,    "Nihel", "Smurf Average" ,     6)
	
	
	
	actor[] positions = sexlabutil.makeactorarray(Anna,Belenthor)	
	Resetscene()
	
    AbFemaleExpressionList[1] = "AB_FuckDisgust01"
	AbFemaleExpressionList[2] = "AB_FuckDisgust01"
	AbFemaleExpressionList[3] = "AB_FuckDisgust01"
	AbFemaleExpressionList[4] = "AB_FuckPleasured01"
	AbFemaleExpressionList[5] = "AB_FuckDisgust01"
	AbFemaleExpressionList[6] = "AB_FuckDisgust01"
	AbFemaleExpressionList[7] = "AB_FuckDisgust01"
	AbFemaleExpressionList[8] = "AB_FuckDisgust01"
	AbFemaleExpressionList[9] = "AB_FuckDisgust01"
	AbFemaleExpressionList[10] = "AB_FuckDisgust01"
	AbFemaleExpressionIndex[1] = 1
	AbFemaleExpressionIndex[2] = 1
	AbFemaleExpressionIndex[3] = 1
	AbFemaleExpressionIndex[4] = 3
	AbFemaleExpressionIndex[5] = 1
	AbFemaleExpressionIndex[6] = 1
	AbFemaleExpressionIndex[7] = 1
	AbFemaleExpressionIndex[8] = 1
	AbFemaleExpressionIndex[9] = 1
	AbFemaleExpressionIndex[10] = 1
	Erection[1] = -9;
	Erection[2] = -9;
	Erection[3] = 4;
	Erection[4] = 4;
	Erection[5] = 4;
	Erection[6] = 4;
	Erection[7] = 4;
	Erection[8] = 4;
	Erection[9] = 4;
	Erection[10] = 4;
	Acycle[2] = true;
	; Acycle[5] = true;
	; Acycle[6] = true;
	; Acycle[8] = true;
	RestartStage = 8
	
	DoSceneInLocation( Anna, positions, centerOn, "AB01_Fuck");
	;DoSceneInLocation( Anna, positions, centerOn, "AB01_Shy_Stand");
	;oSceneInLocation( Anna, positions, centerOn, "FB_Molag_BJ_Vengance");
	
endfunction




function DoSceneInLocation(actor victim, actor[]positions, ObjectReference centerOn, string animid)     
	  ; play animation
	  sslbaseanimation anim = sexlab.GetAnimationByRegistry(animid)
	  anim.AB_Tag="Test01"
	  sslbaseanimation[] anims = new sslbaseanimation[1]	
	  anims[0] = anim 

   
	  sexlab.Config.InDebugMode = True
	  int scenevar = 1
	  
	  sexlab.AB_StartSex("", scenevar, positions, anims, victim, centerOn ,RestartStage, Acycle, Erection, AbFemaleExpressionList,AbFemaleExpressionIndex,AbMaleExpressionList,AbMaleExpressionIndex) 

EndFunction



 
actor function GetActor(actor player, string acName,string schlong, int sossize = 0, float height = 0.0)
		actor result = none
		Actorbase an = none
		if     (acName == "Ulfbear")
		         an = Game.GetFormFromFile(0x00013b9f,"Skyrim.esm") as Actorbase
		elseIf (acName == "Belenthor")
		         an = Game.GetFormFromFile(0x00013ba1,"Skyrim.esm") as Actorbase
		elseIf (acName == "Nihel")
		         an = Game.GetFormFromFile(0x00000D70,"Nihel.esp") as Actorbase
		
				 
				 ;Actor function FindAvailableCreature(string RaceKey, ObjectReference CenterRef, float Radius = 5000.0, int FindGender = 2, Actor IgnoreRef1 = none, Actor IgnoreRef2 = none, Actor IgnoreRef3 = none, Actor IgnoreRef4 = none)
		endIf		
		if (an != none)
		   result = player.PlaceActorAtMe(an)
		   if (sossize > 0)
		      SLV_SchlongSize(result, schlong, sossize)
		   endif
		   LockActor(result)
		   result.RemoveAllItems()
		   
		   if (height > 0)
		      ;result.SetHei
		   endif
		endif		
		return result
EndFunction


ObjectReference function MoveAndPrepareLocation(actor player, string LocationID)
       ; move to cell
	   ;victim.MoveTo(LocRef)	
       Cell kCell = player.GetParentCell()
	   Int iIndex = kCell.GetNumRefs(62) ; kCharacter  = 62
	   While iIndex
		  iIndex -= 1
		  kCell.GetNthRef(iIndex, 62).Disable(false) 
	   EndWhile
	   
	   
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


function SLV_SchlongSize(Actor NPCActor, string schlong, int size)

    SOS_API sos = SOS_API.Get()
    int oldmaxsize = sos.GetMaxSchlongSize()    
	sos.SetMaxSchlongSize(20)
	Form cock = sos.FindSchlongByName(schlong)	
	if (sos.IsSchlonged(NPCActor))
	    sos.SetSize(NPCActor, size)
	else
	sos.SetSchlong(NPCActor, cock)	
    sos.SetSize(NPCActor, size)	
	endif
	
	     ;Form cock = sos.FindSchlongByName("VectorPlexus Regular")
		 ;Form cock = sos.FindSchlongByName("VectorPlexus Muscular")
	     ;Form cock = sos.FindSchlongByName("Smurf Average")
    	 
	;endIf
	
    Utility.wait(1.0)
    
	
	;sos.SetMaxSchlongSize(oldmaxsize)
EndFunction


event OnUpdate()
endEvent

event OnEffectFinish(Actor TargetRef, Actor CasterRef)
    ;Log("MAGIC FINISHED !!!!!!!!!!!!!!!!!!!!!!!!!!!")	                    
	;/ if MarkerRef
		TargetRef.SetVehicle(none)
		MarkerRef.Disable()
		MarkerRef.Delete()
		MarkerRef = none
	endIf /;
	Log("---- MAGIC FINISHED ----")
endEvent



;/-----------------------------------------------\;
;|	Debug Utility Functions                      |;
;\-----------------------------------------------/;

function Log(string log)
	Debug.Trace(log)
	Debug.TraceUser("SexLabDebug", log)
	SexLabUtil.PrintConsole(log)
endfunction

string function GetActorNames(Actor[] Actors)
	string names
	int i = Actors.Length
	while i
		i -= 1
		names += "["+Actors[i].GetLeveledActorBase().GetName()+"]"
	endWhile
	return names
endFunction

string function GetObjNames(ObjectReference[] Objects)
	string names
	int i = Objects.Length
	while i
		i -= 1
		names += "["+Objects[i].GetName()+"]"
	endWhile
	return names
endFunction

float[] function GetCoords(Actor ActorRef)
	float[] coords = new float[6]
	coords[0] = ActorRef.GetPositionX()
	coords[1] = ActorRef.GetPositionY()
	coords[2] = ActorRef.GetPositionZ()
	coords[3] = ActorRef.GetAngleX()
	coords[4] = ActorRef.GetAngleY()
	coords[5] = ActorRef.GetAngleZ()
	return coords
endFunction

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
