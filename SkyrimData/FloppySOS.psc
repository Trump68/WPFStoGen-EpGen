Scriptname FloppySOS

; =============================================================================================================================
; Main Floppy API
; =============================================================================================================================

function toggleFloppiness(Actor target, string preset, bool force=false) global
	string oldPreset = StorageUtil.GetStringValue(target, "floppysos.preset")
	if (preset == oldPreset && !force)
		return
	endIf
	;alert("Changing " + target.getLeveledActorBase().getName() + " to " + preset)
	if (oldPreset != "")
		hdtPhysicsExtensions.removeHDTSystem(target, "floppysos")
	endIf
	if (preset != "")
		int index = getPresets().find(preset) + 1
		hdtPhysicsExtensions.addHDTSystem(target, "floppysos", "Data/SKSE/Plugins/floppysos_" + index + ".xml")
	endIf
	StorageUtil.SetStringValue(target, "floppysos.preset", preset)
endFunction

string function getCurrentPreset(Actor target) global
	return StorageUtil.GetStringValue(target, "floppysos.preset")
endFunction

function reapplyPreset(Actor target) global
	toggleFloppiness(target, getCurrentPreset(target), true)
endFunction

; -----------------------------
; NPC Cloak Effect
; -----------------------------

function registerCloakSpell(Spell cloak) global
	StorageUtil.SetFormValue(None, "floppifyCloak", cloak)
endFunction

function reapplyCloakEffect() global
	Spell cloak = StorageUtil.GetFormValue(None, "floppifyCloak") as Spell
	if (cloak)
		Game.GetPlayer().RemoveSpell(cloak)	
		Utility.Wait(1)
		Game.GetPlayer().AddSpell(cloak, false)	
	endIf
	log("Cloak effect applied")
endFunction

; -----------------------------
; Erection support
; -----------------------------

function handleErectionEvent(Actor akActor, string eventName) global
	;bool presetChanged = false
	; int toggleMode = 0
	; if (akActor == Game.getPlayer())
		; toggleMode = getPreferenceValue("toggleMode.player") as int
	; else
		; toggleMode = getPreferenceValue("toggleMode.npc") as int
	; endIf

	; if (toggleMode == 1)
		; ; ErectionDetection
		; if (eventName == "SOSFlaccid")
			; presetChanged = revertErectionSupport(akActor)
		; else
			; presetChanged = enableErectionSupport(akActor)
		; endIf
	; elseIf (toggleMode == 2)
		; ; ArousalBased
		; int bend = 0
		; if (eventName == "SOSFlaccid")
			; bend = -10
		; elseIf (StringUtil.find(eventName, "SOSBend-") >= 0)
			; bend = -(StringUtil.asOrd(StringUtil.subString(eventName, 8)) - 48)
		; elseIf (StringUtil.find(eventName, "SOSBend") >= 0)
			; bend = StringUtil.asOrd(StringUtil.subString(eventName, 7)) - 48
		; else
			; bend = 10
		; endIf

		; int targetPresetIndex = -1
		; if (bend == -10)
			; targetPresetIndex = 0
		; elseIf (bend < -5)
			; targetPresetIndex = 1
		; elseIf (bend < 0)
			; targetPresetIndex = 2
		; elseIf (bend < 5)
			; targetPresetIndex = 3
		; else
			; targetPresetIndex = 4
		; endIf

		; ;alert("Arousal: bend " + bend + " -> " + getPreset(targetPresetIndex))
		; toggleFloppiness(akActor, getPreset(targetPresetIndex))
	; else
		; return
	; endIf

	; ; Changing floppiness aborts the animation. Send it again.
	; if (presetChanged)
		; Debug.SendAnimationEvent(akActor, eventName)
		; log(akActor.getLeveledActorBase().getName() + "'s preset changed due to SOS animation event: " + eventName)
	; endIf
endFunction

bool function enableErectionSupport(Actor akActor) global
	string preset = getCurrentPreset(akActor)
	if (presetSupportsErection(preset))
		return false
	endIf
	StorageUtil.SetStringValue(akActor, "floppysos.preErectionMode", preset)
	toggleFloppiness(akActor, getPreset(4))
	return true
endFunction

bool function revertErectionSupport(Actor akActor) global
	if (StorageUtil.HasStringValue(akActor, "floppysos.preErectionMode"))
		toggleFloppiness(akActor, StorageUtil.GetStringValue(akActor, "floppysos.preErectionMode"))
		StorageUtil.UnsetStringValue(akActor, "floppysos.preErectionMode")
		return true
	elseIf (!presetSupportsErection(getCurrentPreset(akActor)))
		return false
	else
		string targetPreset = getPreferenceStrValue("preset.npc")
		if (akActor == Game.GetPlayer())
			targetPreset = getPreferenceStrValue("preset.player")
		endIf
		toggleFloppiness(akActor, targetPreset)
		return true
	endIf	
endFunction

bool function presetSupportsErection(string preset) global
	return (preset == getPreset(4) || preset == getPreset(5))
	;TODO This is more accurate, but causes a CTD when called during NPC undress
	;string[] presetKeys = initPresetArray()
	;string[] presetValues = initPresetArray()
	;loadPresetFile(preset, presetKeys, presetValues)
	;bool hdtSchlong = getPresetValue(presetKeys, presetValues, "schlongEnabled") as bool
	;return !hdtSchlong
endFunction

; =============================================================================================================================
; Preset API
; =============================================================================================================================

function updateAllPresets() global
	log("Preset(s) changed. Refreshing actors...")

	string[] presets = getPresets()
	int i = 0
	while i < presets.length
		; Write the preset to XML
		int targetXML = getPresets().find(presets[i]) + 1
		presetToXML(presets[i], targetXML)
		i += 1
	endWhile

	; Refresh the preset wherever it is being worn
	reapplyPreset(Game.GetPlayer())
	reapplyCloakEffect()
endFunction

function presetToXML(string preset, int targetXML) global
	string[] presetKeys = initPresetArray()
	string[] presetValues = initPresetArray()
	loadPresetFile(preset, presetKeys, presetValues)

	; Translate the preset into a template key-value map
	string[] prefixes = new string[7]
	prefixes[0] = "gen01"
	prefixes[1] = "gen02"
	prefixes[2] = "gen03"
	prefixes[3] = "gen04"
	prefixes[4] = "gen05"
	prefixes[5] = "gen06"
	prefixes[6] = "genScrot"

	string[] modifiers = new string[12]
	modifiers[0] = "angDamping"
	modifiers[1] = "tauFactor"
	modifiers[2] = "inertiaMassInv"
	modifiers[3] = "timeFactor"
	modifiers[4] = "coneMaxAngle"
	modifiers[5] = "motionType"
	modifiers[6] = "constraintClass"
	modifiers[7] = "motors"
	modifiers[8] = "transformA"
	modifiers[9] = "transformB"
	modifiers[10] = "shapeRadius"
	modifiers[11] = "collisionFilter"

	string[] keys = new string[84]
	string[] values = new string[84]

	; Loop over all the bones (prefixes) and set the parameters (modifiers) for each bone.
	int i = 0
	while i < prefixes.length
		int j = 0
		while j < modifiers.length
			keys[i*modifiers.length+j] = "$" + prefixes[i] + "." + modifiers[j]
			j = j + 1
		endWhile

		string settingPrefix = "schlong"
		if (i == 6)
			settingPrefix = "balls"
		endIf

		; Bounciness (angular damping): same formula for all bones
		values[i*modifiers.length] = (0.9 - (0.008 * getPresetValue(presetKeys, presetValues, settingPrefix + "Bounciness")))

		; Jellyness (tau factor): same formula for all bones
		values[i*modifiers.length+1] = (0.8 - (0.007 * getPresetValue(presetKeys, presetValues, settingPrefix + "Jellyness")))
		
		; Weight (inertia and mass): separate weight for scrotum
		float massInv = 10.0
		if (i == 6)
			massInv = 1.0
		endIf
		float inertia = 0.02 + (0.003 * getPresetValue(presetKeys, presetValues, settingPrefix + "Weight"))
		values[i*modifiers.length+2] = "(" + inertia + " " + inertia + " " + inertia + " " + massInv + ")"

		; Speed (time factor): same formula for all bones
		values[i*modifiers.length+3] = (0.1 + (0.009 * getPresetValue(presetKeys, presetValues, settingPrefix + "Speed")))

		; Constraint on cone of movement: depends on schlong state
		if (i < 5 && !getPresetValue(presetKeys, presetValues, "schlongNearErect"))
			values[i*modifiers.length+4] = "0.11" ; For Gen01-05
		elseIf (i == 5)
			values[i*modifiers.length+4] = "0.0" ; For Gen06
		else
			values[i*modifiers.length+4] = "0.44" ; For GenScrot
		endIf
		if (!getPresetValue(presetKeys, presetValues, "schlongHalfErect") && !getPresetValue(presetKeys, presetValues, "schlongNearErect"))
			values[4] = "0.5" ;	For Gen01
			values[4+modifiers.length] = "0.2" ; For Gen02
		endIf

		; Motion type: set to KEYFRAMED if HDT is disabled
		string motionType = "MOTION_KEYFRAMED"
		if (getPresetValue(presetKeys, presetValues, settingPrefix + "Enabled"))
			motionType = "MOTION_SPHERE_INERTIA"
		endIf
		values[i*modifiers.length+5] = motionType

		; Constraint class: set to FIXED for Gen02-06 if schlong is near-erect
		string constraintClass = "hkpRagdollConstraintData"
		if (getPresetValue(presetKeys, presetValues, "schlongNearErect") && i != 0)
			constraintClass = "hkpFixedConstraintData"
		endIf
		values[i*modifiers.length+6] = constraintClass

		; Motors: enable motors if schlong is near-erect
		if (getPresetValue(presetKeys, presetValues, "schlongNearErect"))
			values[i*modifiers.length+7] = "null #0107 #0108"
		else
			values[i*modifiers.length+7] = "null null null"
		endIf
		
		; TransformA/B: depends on the SOS Racemenu sliders
		if (i == 0)
			if (getPresetValue(presetKeys, presetValues, "schlongHalfErect") || getPresetValue(presetKeys, presetValues, "schlongNearErect"))
				values[8] = toMatrixString(-90, 0, 0, 0, -2, 0)
				values[9] = toMatrixString(-90, -40, 0, 0, 0, 0)
			else
				;values[8] = toMatrixString(-90, 0, 30, 0, 0, 0) -- This should be equivalent, but somehow gives a different result
				values[8] = "(0.0 -0.8660 0.5)(1.0 0.0 0.0)(0.0 -0.5 0.8660)(0.0 0.0 0.0)"
				values[9] = toMatrixString(-90, -40, 0, 0, 2, 0)
			endIf
		elseIf (i < 6)
			float[] ty = new float[6]
			ty[0] = 1.8753 ; Not used: gen00
			ty[1] = 1.7057
			ty[2] = 1.5023
			ty[3] = 1.4687
			ty[4] = 1.3548
			ty[5] = 1.0323
			float tyScaled = -ty[i]*getPreferenceValue("scale.corr.factor")
			if (tyScaled == 0.0)
				tyScaled = -ty[i]
			endIf
			values[i*modifiers.length+8] = toMatrixString(-90, 0, 0, 0, tyScaled, 0)

			float[] t = toYPRArray(0,0,0)
			float[] ypr = toYPRArray(0,0,0)

			; Check presence of Racemenu and NiOverride
			if (SKSE.GetPluginVersion("NiOverride") >= 3 && NiOverride.GetScriptVersion() >= 2)
				bool isFemale = Game.GetPlayer().GetActorBase().GetSex() as bool
				string nodeName = "CME Genitals0" + i + " [Gen0" + i + "]"
				t = NiOverride.GetNodeTransformPosition(Game.GetPlayer(), false, isFemale, nodeName, "SoSPlugin")				
				ypr = NiOverride.GetNodeTransformRotation(Game.GetPlayer(), false, isFemale, nodeName, "SoSPlugin", 0)
				ypr = toYPRArray(ypr[1], ypr[2], ypr[0]) ; CME to NPC: switch order!
			endIf

			if (getPresetValue(presetKeys, presetValues, "schlongNearErect"))
				; Include racemenu rotation (i.e. the yaw, pitch, roll sliders)
				float[] baseRot = toRotationMatrix(toYPRArray(-90,0,0))
				float[] rot = matrixMult(baseRot, toRotationMatrix(ypr))
				values[i*modifiers.length+9] = matrixToString(rot) + "(" + t[0] + " " + t[1] + " " + t[2] + ")"
			else
				values[i*modifiers.length+9] = toMatrixString(-90, 0, 0, t[0], t[1], t[2])
			endIf
		else
			float droopY = (0.0 - (0.1 * getPresetValue(presetKeys, presetValues, settingPrefix + "Droop")))
			values[i*modifiers.length+8] = toMatrixString(90, 0, 90, 0, droopY, 0)
			values[i*modifiers.length+9] = toMatrixString(90, -30, 90, 0, 0, 0)
		endIf

		; Shape Radius: increase for proper vagina collision (when HDT schlong is disabled).
		float shapeRadius = 1.5
		if (!getPresetValue(presetKeys, presetValues, settingPrefix + "Enabled"))
			shapeRadius = 4.0
		endIf
		values[i*modifiers.length+10] = shapeRadius

		; Collision filter: if HDT schlong is disabled, change balls collision to reduce chance of stretching issue
		; 117440544 -> ignore 5 (thighs)
		; 117440640 -> ignore 7 (vagina)
		; 117440672 -> ignore 5 and 7 (thighs and vagina)
		; 117440673 -> ignore 0, 5 and 7 (schlong, thighs and vagina)
		string collisionFilter = "117440672"
		if (!getPresetValue(presetKeys, presetValues, "schlongEnabled"))
			collisionFilter = "117440673"
		endIf
		values[i*modifiers.length+11] = collisionFilter

		i = i + 1
	endWhile

	string templateFile = "Data/SKSE/Plugins/floppysos_template.xml"
	string targetFile = "Data/SKSE/Plugins/floppysos_" + targetXML + ".xml"
	generateXML(templateFile, targetFile, keys, values)
endFunction

float function getPresetValue(string[] keys, string[] values, string keyToSearch) global
	int index = keys.find(keyToSearch)
	if (index < 0)
		return 0
	endIf
	return values[index] as float
endFunction

string function getPreset(int index) global
	return getPresets()[index]
endFunction

string[] function getPresets() global
	string[] presets = new string[6]
	presets[0] = "FullFloppy"
	presets[1] = "LowArousal"
	presets[2] = "MedArousal"
	presets[3] = "HighArousal"
	presets[4] = "BallsOnly"
	presets[5] = "Disabled"
	;string[] presets = new string[128]
	;listPresets(getPresetPath(), presets)
	return presets
endFunction

string[] function initPresetArray() global
	return new string[13]
endFunction

function generateNewPreset(string[] keys, string[] values) global
	keys[0] = "schlongEnabled"
	values[0] = "1.0"
	keys[1] = "schlongHalfErect"
	values[1] = "0.0"
	keys[2] = "schlongNearErect"
	values[2] = "0.0"
	keys[3] = "schlongBounciness"
	values[3] = "1.0"
	keys[4] = "schlongJellyness"
	values[4] = "1.0"
	keys[5] = "schlongWeight"
	values[5] = "20.0"
	keys[6] = "schlongSpeed"
	values[6] = "100.0"
	keys[7] = "ballsEnabled"
	values[7] = "1.0"
	keys[8] = "ballsBounciness"
	values[8] = "1.0"
	keys[9] = "ballsJellyness"
	values[9] = "1.0"
	keys[10] = "ballsWeight"
	values[10] = "20.0"
	keys[11] = "ballsSpeed"
	values[11] = "100.0"
	keys[12] = "ballsDroop"
	values[12] = "50.0"
endFunction

function loadPresetFile(string name, string[] keys, string[] values) global
	loadPreset(getPresetPath(), name + ".preset", keys, values)
endFunction

function writePresetFile(string name, string[] keys, string[] values) global
	writePreset(getPresetPath(), name + ".preset", keys, values)
endFunction

string function getPresetPath() global
	return "Data/SKSE/Plugins/floppysos_presets"
endFunction

function generateXML(string templatePath, string outputPath, string[] keys, string[] values) native global

function listPresets(string path, string[] presets) native global
function loadPreset(string path, string name, string[] keys, string[] values) native global
function writePreset(string path, string name, string[] keys, string[] values) native global

; =============================================================================================================================
; Preference API
; =============================================================================================================================

function resetPreferences() global
	setPreferenceValue("toggleMode.player",		getPreferenceDefaultValue("toggleMode.player"))
	setPreferenceValue("toggleMode.npc",		getPreferenceDefaultValue("toggleMode.npc"))
	setPreferenceValue("keycode.modifier",	getPreferenceDefaultValue("keycode.modifier"))
	setPreferenceValue("keycode.self",		getPreferenceDefaultValue("keycode.self"))
	setPreferenceValue("keycode.target",	getPreferenceDefaultValue("keycode.target"))
	setPreferenceValue("disable.hdtm",		getPreferenceDefaultValue("disable.hdtm"))
	setPreferenceValue("scale.corr.factor",	getPreferenceDefaultValue("scale.corr.factor"))
	setPreferenceStrValue("preset.player",	getPreferenceStrDefaultValue("preset.player"))
	setPreferenceStrValue("preset.npc",		getPreferenceStrDefaultValue("preset.npc"))
	log("Preference defaults initialized")
endFunction

float function getPreferenceValue(string prefName) global
	return StorageUtil.GetFloatValue(None, "floppysos." + prefName)
endFunction

string function getPreferenceStrValue(string prefName) global
	return StorageUtil.GetStringValue(None, "floppysos." + prefName)
endFunction

float function getPreferenceDefaultValue(string prefName) global
	if (prefName == "toggleMode.player")
		return 1 ; 0 = Manual, 1 = ErectionDetection, 2 = ArousalBased
	elseIf (prefName == "toggleMode.npc")
		return 1
	elseIf (prefName == "keycode.modifier")
		return 42 ; 42 = Left Shift
	elseIf (prefName == "keycode.self")
		return 211 ; 211 = Delete
	elseIf (prefName == "keycode.target")
		return 210 ; 210 = Insert
	elseIf (prefName == "disable.hdtm")
		return 1
	elseIf (prefName == "scale.corr.factor")
		return 1.0
	endIf
endFunction

string function getPreferenceStrDefaultValue(string prefName) global
	if (prefName == "preset.player")
		return "FullFloppy"
	elseIf (prefName == "preset.npc")
		return "Disabled"
	endIf
endFunction

function setPreferenceValue(string prefName, float value) global
	StorageUtil.SetFloatValue(None, "floppysos." + prefName, value)
endFunction

function setPreferenceStrValue(string prefName, string value) global
	StorageUtil.SetStringValue(None, "floppysos." + prefName, value)
endFunction

; =============================================================================================================================
; Misc utility functions
; =============================================================================================================================

function checkModDependencies() global
	checkFileDependency("RCAE", "Data/SKSE/Plugins/RCAE.dll")
	checkFileDependency("PapyrusUtil", "Data/SKSE/Plugins/StorageUtil.dll")
	checkFileDependency("SkyUI", "Data/SkyUI.esp")

	float hdtPEVersion = hdtPhysicsExtensions.getPatchVersion()
	if (hdtPEVersion != 1.3)
		alert("Wrong hdtPhysicsExtensions.dll! Check installation instructions.")
	endIf

	if (getPreferenceValue("disable.hdtm") && fileExists("Data/SKSE/Plugins/hdtm.xml"))
		renameFile("Data/SKSE/Plugins/hdtm.xml", "Data/SKSE/Plugins/hdtm.xml.disabled")
		alert("hdtm.xml detected. To avoid conflict, it has been renamed to hdtm.xml.disabled")
		reapplyPreset(Game.GetPlayer())
		reapplyCloakEffect()
 	endIf
endFunction

function checkFileDependency(string modName, string fileName) global
 	if (!fileExists(fileName))
 		alert("Mod dependency missing! Please install " + modName)
 	endIf
endFunction

function log(string msg) global
	string fullMsg = "[FloppySOS] " + msg
	;fullMsg += " [Actor " + target.getLeveledActorBase().getName() + "]"
	Debug.Trace(fullMsg)
endFunction

function alert(string msg) global
	string fullMsg = "[FloppySOS] " + msg
	Debug.Notification(fullMsg)
	Debug.Trace(fullMsg)
endFunction

bool function fileExists(string path) native global

function renameFile(string fromPath, string toPath) native global

; =============================================================================================================================
; Matrix helper functions
; =============================================================================================================================

float[] function toYPRArray(float yaw, float pitch, float roll) global
	float[] ypr = new float[3]
	ypr[0] = yaw
	ypr[1] = pitch
	ypr[2] = roll
	return ypr
endFunction

float[] function toRotationMatrix(float[] ypr) global
	float[] yaw = new float[9]
	yaw[0] = Math.cos(ypr[0])
	yaw[1] = Math.sin(ypr[0])
	yaw[2] = 0
	yaw[3] = -Math.sin(ypr[0])
	yaw[4] = Math.cos(ypr[0])
	yaw[5] = 0
	yaw[6] = 0
	yaw[7] = 0
	yaw[8] = 1
	float[] pitch = new float[9]
	pitch[0] = Math.cos(ypr[1])
	pitch[1] = 0
	pitch[2] = -Math.sin(ypr[1])
	pitch[3] = 0
	pitch[4] = 1
	pitch[5] = 0
	pitch[6] = Math.sin(ypr[1])
	pitch[7] = 0
	pitch[8] = Math.cos(ypr[1])
	float[] roll = new float[9]
	roll[0] = 1
	roll[1] = 0
	roll[2] = 0
	roll[3] = 0
	roll[4] = Math.cos(ypr[2])
	roll[5] = Math.sin(ypr[2])
	roll[6] = 0
	roll[7] = -Math.sin(ypr[2])
	roll[8] = Math.cos(ypr[2])
	return matrixMult(yaw, matrixMult(pitch, roll))
endFunction

float[] function matrixMult(float[] a, float[] b) global
	float[] res = new float[9]
	res[0] = a[0]*b[0] + a[3]*b[1] + a[6]*b[2]
	res[1] = a[1]*b[0] + a[4]*b[1] + a[7]*b[2]
	res[2] = a[2]*b[0] + a[5]*b[1] + a[8]*b[2]
	res[3] = a[0]*b[3] + a[3]*b[4] + a[6]*b[5]
	res[4] = a[1]*b[3] + a[4]*b[4] + a[7]*b[5]
	res[5] = a[2]*b[3] + a[5]*b[4] + a[8]*b[5]
	res[6] = a[0]*b[6] + a[3]*b[7] + a[6]*b[8]
	res[7] = a[1]*b[6] + a[4]*b[7] + a[7]*b[8]
	res[8] = a[2]*b[6] + a[5]*b[7] + a[8]*b[8]
	return res
endFunction

string function matrixToString(float[] m) global
	return "(" + m[0] + " " + m[1] + " " + m[2] + ")" + "(" + m[3] + " " + m[4] + " " + m[5] + ")" + "(" + m[6] + " " + m[7] + " " + m[8] + ")"
endFunction

string function toMatrixString(float y, float p, float r, float tx, float ty, float tz) global
	return matrixToString(toRotationMatrix(toYPRArray(y, p, r))) + "(" + tx + " " + ty + " " + tz + ")"
endFunction