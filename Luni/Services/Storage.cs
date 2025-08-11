namespace Luni.Services;

public class Storage
{
	public static async Task<string> ReadFileAsync(string path)
	{
		if (!File.Exists(path))
			return string.Empty;

		try
		{
			string res = await File.ReadAllTextAsync(path);
			return res;
		}
		catch (Exception ex)
		{
			ErrorCenter.Add(ex);
			return string.Empty;
		}
	}

	public static async Task WriteFileAsync(string path, string context)
	{
		try
		{
			await File.WriteAllTextAsync(path, context);
		}
		catch (Exception ex)
		{
			ErrorCenter.Add(ex);
		}
	}
}