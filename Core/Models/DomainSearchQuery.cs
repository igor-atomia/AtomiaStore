﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Atomia.OrderPage.Core.Models
{
    public class DomainSearchQuery
    {
        [Required(ErrorMessage="Required yo!")]
        public string SearchTerm { get; set; }
    }
}
