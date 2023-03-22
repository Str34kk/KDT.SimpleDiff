using KDT.SimpleDiff.Attributes;

namespace KDT.Web.Entities;

[Versioned]
public class SmallItemVersioned
{
    public int Id { get; set; }
    public string? Name { get; set; } = "string";
}