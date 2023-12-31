﻿using System.ComponentModel.DataAnnotations;

namespace Nicesleeping.Domain.Entities.Categories;

public class Category : Auditable
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
