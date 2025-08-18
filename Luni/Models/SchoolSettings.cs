namespace Luni.Models;

public sealed partial class SchoolSettings : Settings
{
	public DateTime SemesterEndDate { get; set; }

	public override DateTime EndDate()
		=> SemesterEndDate;
}