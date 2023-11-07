using System.ComponentModel.DataAnnotations;

namespace Nicesleeping.Domain.Entities.Categories;

public class Category : Auditable
{
    [MaxLength(20)]
    [MinLength(3)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(1000)]
    [MinLength(5)]
    public string Description { get; set; } = string.Empty;
}
