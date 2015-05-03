﻿using System;
using System.Collections.Generic;

using GameWindow = OpenTK.GameWindow;
using GameWindowFlags = OpenTK.GameWindowFlags;
using OpenTK.Graphics;

using Duality;
using Duality.Resources;

namespace Duality.VisualStudio
{
	public class DualityDebuggingTester : GameWindow
	{
		public DualityDebuggingTester(int w, int h, GraphicsMode mode, string title, GameWindowFlags flags) : base(w, h, mode, title, flags) {}

		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		public static void Main()
		{
			DualityApp.Init(DualityApp.ExecutionEnvironment.Launcher, DualityApp.ExecutionContext.Game);
			using (DualityDebuggingTester launcherWindow = new DualityDebuggingTester(
				DualityApp.UserData.GfxWidth, 
				DualityApp.UserData.GfxHeight, 
				DualityApp.DefaultMode, 
				DualityApp.AppData.AppName,
				GameWindowFlags.Default))
			{
				// Initialize default content
				launcherWindow.MakeCurrent();
				DualityApp.TargetResolution = new Vector2(launcherWindow.Width, launcherWindow.Height);
				DualityApp.TargetMode = launcherWindow.Context.GraphicsMode;
				DualityApp.InitGraphics();

				// Run tests
				BitmapDebuggerVisualizer.TestShow(Pixmap.DualityIcon.Res);
				BitmapDebuggerVisualizer.TestShow(Pixmap.DualityIcon.Res.MainLayer);
				BitmapDebuggerVisualizer.TestShow(Texture.DualityIcon.Res);
				BitmapDebuggerVisualizer.TestShow(Font.GenericMonospace10.Res.Material.MainTexture.Res);
			}
			DualityApp.Terminate();
		}
	}
}
