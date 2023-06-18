using System.ComponentModel.DataAnnotations.Schema;

namespace KDT.SimpleDiff.Entities;

[Table(name: "Diffs", Schema = "SimpleDiff")]
public class Diff
{
    public int Id { get; set; }

    public string? ObjectData { get; set; }
}