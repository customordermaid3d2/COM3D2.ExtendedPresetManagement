﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using UnityEngine;

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace ExtendedPresetManagement
{
	class MyUI
	{
		private static Rect windowRect = new Rect(Screen.width / 2.10f, Screen.height / 1.5f, (Screen.width / 12) * Main.UIWidthMult.Value, (Screen.height / 6) * Main.UIHeightMult.Value);
		private static Rect windowRectPMI = new Rect(Screen.width * .275f, Screen.height * 0f, (Screen.width / 12) * Main.UIWidthMult.Value, (Screen.height / 6) * Main.UIHeightMult.Value);
		private const int WindowID = 7777777;
		private static Vector2 scrollPosition = Vector2.zero;

		public static void Start(bool PMI = false) 
		{
			if (PMI)
			{
				windowRectPMI = GUILayout.Window(WindowID, windowRectPMI, GuiWindowControls, "Preset Directory Changer");
			}
			else
			{
				windowRect = GUILayout.Window(WindowID, windowRect, GuiWindowControls, "Preset Directory Changer");
			}

		}

		public static void GuiWindowControls(int windowID = WindowID) 
		{
			GUI.DragWindow(new Rect(0, 0, 10000, 20));

			scrollPosition = GUILayout.BeginScrollView(scrollPosition);

			GUILayout.BeginHorizontal();

			if (Main.CustomPresetDirectory != null)
			{
				if (GUILayout.Button("Root"))
				{
					Main.CustomPresetDirectory = null;

					if (Main.this3 != null)
					{
						Main.this3.UpdatePresetList();
					}
				}
				//GUILayout.Label("Root");
			}
			else
			{
				GUILayout.Toggle(true, "Root");
			}

			GUILayout.EndHorizontal();

			string shortpath;

			foreach (string path in Main.PresetFolders) 
			{
				shortpath = path.Replace(Main.OriginalPresetDirectory + "\\", "");

				GUILayout.BeginHorizontal();

				if (Main.CustomPresetDirectory != path)
				{
					//if (GUILayout.Button("Select"))
					if (GUILayout.Button(shortpath))
					{
						Main.CustomPresetDirectory = path;
						if (Main.this3 != null)
						{
							Main.this3.UpdatePresetList();
						}
					}
					//GUILayout.Label(shortpath);
				} else 
				{
					GUILayout.Toggle(true, shortpath); ;
				}

				GUILayout.EndHorizontal();
			}

			GUILayout.EndScrollView();

			if (GUILayout.Button("Open Current Folder"))
			{
				Process.Start(Main.this4.PresetDirectory);
			}
			if (GUILayout.Button("Refresh"))
			{
				Main.RunOnce = true;
				if (Main.this3 != null)
				{
					Main.this3.UpdatePresetList();
				}
			}
		}
	}
}
