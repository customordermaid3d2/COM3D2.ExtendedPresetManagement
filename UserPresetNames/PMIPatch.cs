using COM3D2.PropMyItem.Plugin;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using UnityEngine;

namespace ExtendedPresetManagement
{
	class PMIPatch3
    {
		[HarmonyPatch("COM3D2.PropMyItem.Plugin.PropMyItem", "Update")]
		[HarmonyPostfix]
		static void Update(bool ____isVisible)
		{
			Main.PMIUIStatus = ____isVisible;
		}
	}	

	class PMIPatch2
    {
		[HarmonyPatch("PropMyItem", "Update")]
		[HarmonyPostfix]
		static void Update(bool ____isVisible)
		{
			Main.PMIUIStatus = ____isVisible;
		}
	}
	class PMIPatch
	{
		//[HarmonyPatch(typeof(PropMyItem), "Update")]
		[HarmonyPatch(typeof(PropMyItem), "Update")]
		[HarmonyPostfix]
		static void Update(bool ____isVisible)
		{
			Main.PMIUIStatus = ____isVisible;
		}

		/*
		[HarmonyPatch(typeof(PropMyItem), "Update")]
		[HarmonyTranspiler]
		static IEnumerable<CodeInstruction> CodeTranspiler(IEnumerable<CodeInstruction> instructions)
		{
			var custominstruc = new CodeMatcher(instructions)
			.MatchForward(true,
			new CodeMatch(OpCodes.Ldarg_0),
			new CodeMatch(OpCodes.Ldarg_0),
			new CodeMatch(OpCodes.Ldfld),
			new CodeMatch(OpCodes.Ldc_I4_0),
			new CodeMatch(OpCodes.Ceq),
			new CodeMatch(OpCodes.Stfld),
			new CodeMatch(OpCodes.Ldarg_0),
			new CodeMatch(OpCodes.Ldarg_0),
			new CodeMatch(OpCodes.Ldfld),
			new CodeMatch(OpCodes.Ldc_I4_0),
			new CodeMatch(OpCodes.Ceq),
			new CodeMatch(OpCodes.Stfld),
			new CodeMatch(OpCodes.Br)
			)
			.Insert(
			new CodeInstruction(OpCodes.Ldarg_0),
			new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PropMyItem), "_isVisible")),
			Transpilers.EmitDelegate<Action<bool>>((vis) => {
				Main.PMIUIStatus = vis;	
			})
			)
			.InstructionEnumeration();

			return custominstruc;
		}
		*/


	}
}
