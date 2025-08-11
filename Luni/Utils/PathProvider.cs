namespace Luni.Utils;

public class PathProvider
{
	private static string AppNameFolder => "muniw";
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

	public static string SubjectsTable => LocalDataFolder + "subj.txt";
	public static string LessonsTable => LocalDataFolder + "lesson.txt";
	public static string DaysTable => LocalDataFolder + "day.txt";
	public static string WeeksTable => LocalDataFolder + "week.txt";
}