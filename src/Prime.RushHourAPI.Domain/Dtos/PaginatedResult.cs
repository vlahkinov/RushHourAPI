﻿using System.Collections.Generic;

namespace Prime.RushHourAPI.Domain.Dtos
{
    public record PaginatedResult<T>(List<T> Result, int TotalCount)
    {
        public static PaginatedResult<T> Empty() => new(new List<T>(), 0);
    }
}
