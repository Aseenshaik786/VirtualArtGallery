﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArtGallery.Exception
{
    public class UserNotFoundException : System.Exception
    {
        public UserNotFoundException(string message) : base(message) { }
    }
}
