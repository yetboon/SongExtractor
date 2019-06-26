using System;
using System.IO;

namespace SongExtractor
{
	class Program
	{
		public static void Main(string[] args)
		{
			string finalDestinationFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\EXAMPLE\";
			
			string[] paths = Directory.GetDirectories(Directory.GetCurrentDirectory());
			
			
			for (int i = 0; i < paths.Length; i++) {
				string[] filesInside = Directory.GetFiles(paths[i]);
				
				FileInfo a = new FileInfo(paths[i]);
				Console.WriteLine("In:"+a.Name);
				
				foreach (var element in filesInside) {
					
					FileInfo f = new FileInfo(element);
					if(f.Extension == ".mp3")
					{
						Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine(f.Name); Console.ForegroundColor = ConsoleColor.Gray;
						DirectoryInfo d = new DirectoryInfo(paths[i]);
						if(!Directory.Exists(finalDestinationFolder))
							Directory.CreateDirectory(finalDestinationFolder);
						File.Copy(f.FullName,finalDestinationFolder + d.Name + ".mp3",true);
					}
					
				}
				Console.WriteLine();
			}
			
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("==DONE==");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.ReadKey();
		}
	}
}