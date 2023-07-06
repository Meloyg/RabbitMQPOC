namespace Model.Interfaces;

public interface PayRunClosed
{
    int PayRunId { get; set; }
    DateTime PayRunClosedDate { get; set; }
    string PayGroupName { get; set; }
}