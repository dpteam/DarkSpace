﻿using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using SpeechLib;

namespace DarkSpace
{
	internal class Program {

		[STAThread]
		private static void Main(string[] args)
		{
			{
				try
				{
					for (int i = 0; i < args.Length; i++)
					{
						if (args[i].ToLower() == "-port" || args[i].ToLower() == "-p")
						{
							i++;
							try
							{
								int serverPort = Convert.ToInt32(args[i]);
							}
							catch
							{
							}
						}
						if (args[i].ToLower() == "-join" || args[i].ToLower() == "-j")
						{
							i++;
							try
							{
							}
							catch
							{
							}
						}
						if (args[i].ToLower() == "-pass" || args[i].ToLower() == "-password")
						{
							i++;
						}
						if (args[i].ToLower() == "-host")
						{
						}
						if (args[i].ToLower() == "-loadlib")
						{
							i++;
							string path = args[i];
						}
						if (args[i].ToLower() == "-server")
						{
						}
						if (args[i].ToLower() == "-config")
						{
							i++;
							string path = args[i];
						}
					}
					ProgramClient.MainRun();
				}
				catch (Exception ex)
				{
					try
					{
						using (StreamWriter streamWriter = new StreamWriter("crash_" + DateTime.Now + "_ex.log", append: true))
						{
							streamWriter.WriteLine(DateTime.Now);
							streamWriter.WriteLine(ex);
							streamWriter.WriteLine("");
						}
						MessageBox.Show(ex.ToString(), "DarkSpace: Error");
					}
					catch
					{
					}
				}
			}
		}
	}
}