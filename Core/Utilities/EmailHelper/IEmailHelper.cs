﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.EmailHelper
{
    public interface IEmailHelper
    {
         bool SendEmail(string mailAddress, string token, bool bodyHtml);
    }
}
