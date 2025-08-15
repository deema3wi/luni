namespace Luni.Utils;

public class PathProvider
{
	private static string AppNameFolder => "MUni";
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

	public static string SubjectsTable => Path.Combine(LocalDataFolder, "subj.txt");
	public static string LessonsTable => Path.Combine(LocalDataFolder, "lesson.txt");
	public static string DaysTable => Path.Combine(LocalDataFolder, "day.txt");
	public static string WeeksTable => Path.Combine(LocalDataFolder, "week.txt");

	public static string GetPath<T>()
	{
		string file = typeof(T).Name.ToLower() + ".txt";
		string path = Path.Combine(LocalDataFolder, file);
		return path;
	}
}