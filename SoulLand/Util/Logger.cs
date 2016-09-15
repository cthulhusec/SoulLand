using System;
using System.IO;
namespace SoulLand
{
	public class Logger
	{
		//Store path for log file
		string logFilePath;
		string errorFilePath;

		//Initialize Logger, write startup message to log file and console
		public Logger()
		{
			logFilePath = Directory.GetCurrentDirectory() + "\\Log.txt";
			errorFilePath = Directory.GetCurrentDirectory() + "\\ErrorLog.txt";
			string startUp = String.Format("Soul Land Log File {0}" + Environment.NewLine, DateTime.Now.ToString());
			File.WriteAllText(logFilePath, startUp);
			startUp = String.Format("Soul Land Error Log File {0}" + Environment.NewLine, DateTime.Now.ToString());
			File.WriteAllText(errorFilePath, startUp);
			Log("Soul Land Starting Up");

		}

		//Log standard message with timestamp to log file and console
		public void Log(string message)
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("[{0}] Log Message: ", DateTime.Now.ToString("h:mm:ss tt"));
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(message);

			string msg = string.Format("[{0}] Log Message: {1}" + Environment.NewLine, DateTime.Now.ToString("h:mm:ss tt"), message);
			File.AppendAllText(logFilePath, msg);
		}

		//Log warning message with timestamp to log file and console
		public void LogWarning(string message)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write("[{0}] Warning Message: ", DateTime.Now.ToString("h:mm:ss tt"));
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(message);

			string msg = string.Format("[{0}] Log Message: {1}" + Environment.NewLine, DateTime.Now.ToString("h:mm:ss tt"), message);
			File.AppendAllText(logFilePath, msg);
		}

		//Log error message with timestamp to log file and console
		public void LogError(string message)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("[{0}] Error Message: ", DateTime.Now.ToString("h:mm:ss tt"));
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(message);

			string msg = string.Format("[{0}] Log Message: {1}" + Environment.NewLine, DateTime.Now.ToString("h:mm:ss tt"), message);
			File.AppendAllText(errorFilePath, msg);
		}
	}
}

