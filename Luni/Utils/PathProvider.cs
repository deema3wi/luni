namespace Luni.Utils;

public class PathProvider
{
	public static string AppNameFolder => "MUni";
	public static string LocalDataFolder
	{
		get
		{
			string appLoc = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			string path = Path.Combine(appLoc, AppNameFolder);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			return path;
		}
	}

	public static string GetPath<T>()
	{
		string file = typeof(T).Name.ToLower() + ".txt";
		string path = Path.Combine(LocalDataFolder, file);
		return path;
	}
}