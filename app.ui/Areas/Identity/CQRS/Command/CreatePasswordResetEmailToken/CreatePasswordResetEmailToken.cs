﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.ui.Areas.Identity.CQRS.Command.CreatePasswordResetEmailToken
{
    public class CreatePasswordResetEmailToken
    {
        public string Link { get; set; }
    }
}