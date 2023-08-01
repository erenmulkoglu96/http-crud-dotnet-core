using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Room
{
    public int Id { get; set; }
    public string Category { get; set; }
    public int Number { get; set; }
    public int Floor { get; set; }
    public bool IsAvailable { get; set; }
    public long AddedDate { get; set; } // Unix zaman INTEGER için long kullanın
}
