using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace SoulLand
{
	public class SaveSystem
	{
		public SaveSystem()
		{
		}

		static public GameData LoadGameData()
		{
			string path = Directory.GetCurrentDirectory() + "\\GameSave.bin";
			IFormatter formatter = new BinaryFormatter();  
			Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);  
			GameData obj = (GameData) formatter.Deserialize(stream);  
			stream.Close();
			return obj;
		}

		static public GameData SaveGameData(GameData gd)
		{
			string path = Directory.GetCurrentDirectory() + "\\GameSave.bin";
			IFormatter formatter = new BinaryFormatter();  
			Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);  
			formatter.Serialize(stream, gd);  
			stream.Close();
		}
			
	}
}

