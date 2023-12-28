﻿using System.ComponentModel;

namespace Stock.Domain.Entities.Shared
{
    public class BaseEntity
    {
        public long Id { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
