namespace Luni.Models;

public partial class Lesson : Model
{
	public int Order { get; set; }
	public LessonType Type { get; set; }
	public string Room { get; set; } = string.Empty;
	public int SubjId { get; set; }
}

public partial class Lesson
{
	public Lesson() { }
	public Lesson(int id, int subjId, int order, LessonType type, string room)
	{
		Id = id;
		SubjId = subjId;
		Order = order;
		Type = type;
		Room = room;
	}
}

public partial class Lesson
{
	public static string ToRow(Lesson ls)
	{
		char sep = Parser.ColumnSeparator;
		return $"{ls.Id}{sep}" +
			$"{ls.SubjId}{sep}" +
			$"{ls.Order}{sep}" +
			$"{(int)ls.Type}{sep}" +
			$"{ls.Room}";
	}

	public static Lesson Parse(string row)
	{
		string[] sp = row.Split(Parser.ColumnSeparator);
		int id = int.Parse(sp[0]);
		int sid = int.Parse(sp[1]);
		int order = int.Parse(sp[2]);
		LessonType type = (LessonType)int.Parse(sp[3]);

		return new(id, sid, order, type, sp[4]);
	}

	public static string ToTable(List<Lesson> ls)
		=> Parser.ToTable(ls, ToRow);

	public static List<Lesson> ParseMany(string content)
		=> Parser.ParseMany(content, Parse);
}

public partial class Lesson
{
	private static string TablePath => PathProvider.LessonsTable;

	public static async Task<List<Lesson>> ReadTableAsync()
	{
		string table = await Storage.ReadFileAsync(TablePath);
		return ParseMany(table);
	}

	public static async Task WriteTableAsync(List<Lesson> sbs)
		=> await Storage.WriteFileAsync(TablePath, ToTable(sbs));
}