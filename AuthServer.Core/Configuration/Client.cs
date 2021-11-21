﻿using System;
using System.Collections.Generic;

namespace AuthServer.Core.Configuration
{
    public class Client
    {
        public string Id { get; set; }

        public string Secret { get; set; }

        public List<String> Audiences { get; set; }
    }
}
