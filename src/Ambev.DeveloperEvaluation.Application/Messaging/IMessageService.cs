﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Messaging
{
    public interface IMessageService
    {
        Task SendMessageAsync(string message);
    }
}
