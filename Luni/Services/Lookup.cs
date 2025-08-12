namespace Luni.Services;

public class Lookup
{
	public static (bool, List<Model>) AddIfOtherContainsId(List<Model> dest, List<Model> other, Model model)
	{
		if (other.Select(x => x.Id).Contains(model.Id))
		{
			dest = [.. dest, model];
			return (true, dest);
		}

		return (false, dest);
	}
}