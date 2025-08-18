namespace Luni.Utils;

public class PathProvider
{
	private static string _saveFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AppNameFolder);

	public static string AppNameFolder => "MUni";
	public static string SaveFolder
	{
		get => _saveFolder;
		set => _saveFolder = value;
	}

	public static string GetPath<T>()
	{
		string file = typeof(T).Name.ToLower() + ".txt";
		string path = Path.Combine(SaveFolder, file);
		return path;
	}

	public static string EnvironmentFolder()
		=> Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
}