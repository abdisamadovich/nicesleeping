﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nicesleeping.Domain.Exceptions.Auth;

public class VerificationCodeExpiredException : ExpiredException
{
    public VerificationCodeExpiredException()
    {
        TitleMessage = "Verification code is expired!";
    }
}
