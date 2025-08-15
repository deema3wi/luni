using System.Data;

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
	public override string ToRow()
	{
		char sep = Parser.ColumnSeparator;
		return $"{Id}{sep}" +
			$"{SubjId}{sep}" +
			$"{Order}{sep}" +
			$"{(int)Type}{sep}" +
			$"{Room}";
	}

	public override void Become(string row)
	{
		string[] sp = row.Split(Parser.ColumnSeparator);
		Id = int.Parse(sp[0]);
		SubjId = int.Parse(sp[1]);
		Order = int.Parse(sp[2]);
		Type = (LessonType)int.Parse(sp[3]);
	}
}