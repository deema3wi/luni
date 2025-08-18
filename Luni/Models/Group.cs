namespace Luni.Models;

public partial class Group : Model
{
	public string Name { get; set; } = string.Empty;
	public ShedType ShedType { get; set; }

	public int SettingsId { get; set; }
	public List<int> WeekIds { get; set; } = [];
}

public partial class Group : Model
{
	public Group() { }
	public Group(int id) { Id = id; }
	public Group(int id, string name, ShedType shedType, int settingsId, List<int> weekIds)
	{
		Id = id;
		Name = name;
		ShedType = shedType;
		SettingsId = settingsId;
		WeekIds = weekIds;
	}
	public Group(string row) => Become(row);
}

public partial class Group : Model
{
	public override string ToRow()
	{
		var sep = Parser.ColumnSeparator;
		var itemSep = Parser.ArrayItemSeparator;
		return $"{Id}{sep}" +
			$"{Name}{sep}" +
			$"{(int)ShedType}{sep}" +
			$"{SettingsId}{sep}" +
			$"{string.Join(itemSep, WeekIds)}";
	}

	public override void Become(string row)
	{
		string[] sp = row.Split(Parser.ColumnSeparator, StringSplitOptions.RemoveEmptyEntries);
		if (sp.Length == 5)
			Id = int.Parse(sp[0]);
		else if (sp.Length < 4 || sp.Length > 5)
			ErrorCenter.LengthError("Group.Become", sp.Length, "4-5");

		Name = sp[^4];
		ShedType = (ShedType)int.Parse(sp[^3]);
		SettingsId = int.Parse(sp[^2]);
		WeekIds = [.. sp[^1]
			.Split(Parser.ArrayItemSeparator, StringSplitOptions.RemoveEmptyEntries)
			.Select(x => int.Parse(x))];
	}
}