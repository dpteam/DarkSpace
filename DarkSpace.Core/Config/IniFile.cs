﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

// Взято с https://habr.com/ru/post/271483/

namespace DarkSpace.Config
{
	public partial class IniFile
	{
        readonly string Path; //Имя файла.

		[LibraryImport("kernel32", EntryPoint = "WritePrivateProfileStringW", StringMarshalling = StringMarshalling.Utf16)] // Подключаем kernel32.dll и описываем его функцию WritePrivateProfilesString
		public static partial long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

		[DllImport("kernel32", CharSet = CharSet.Unicode)] // Еще раз подключаем kernel32.dll, а теперь описываем функцию GetPrivateProfileString
		static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

		// С помощью конструктора записываем пусть до файла и его имя.
		public IniFile(string IniPath)
		{
			Path = new FileInfo(IniPath).FullName.ToString();
		}

		//Читаем ini-файл и возвращаем значение указного ключа из заданной секции.
		public string ReadINI(string Section, string Key)
		{
			var RetVal = new StringBuilder(255);
            _ = GetPrivateProfileString(Section, Key, "", RetVal, 255, Path);
			return RetVal.ToString();
		}
		//Записываем в ini-файл. Запись происходит в выбранную секцию в выбранный ключ.
		public void Write(string Section, string Key, string Value)
		{
			WritePrivateProfileString(Section, Key, Value, Path);
		}

		//Удаляем ключ из выбранной секции.
		public void DeleteKey(string Key, string Section = null)
		{
			Write(Section, Key, null);
		}
		//Удаляем выбранную секцию
		public void DeleteSection(string Section = null)
		{
			Write(Section, null, null);
		}

		internal void Write(string v1, string v2)
		{
			throw new NotImplementedException();
		}

		//Проверяем, есть ли такой ключ, в этой секции
		public bool KeyExists(string Key, string Section = null)
		{
			return ReadINI(Section, Key).Length > 0;
		}
	}
}
