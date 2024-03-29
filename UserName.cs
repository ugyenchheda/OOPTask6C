﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTask6C
{
    internal class UserName
    {
        public UserName(int studentId, string username)
        {
            StudentId = studentId;
            Username = username;
        }

        public int StudentId { get; set; }
        public string Username { get; set; }

        public override string? ToString()
        {
            return String.Format("{0, -5} {1, -25}",
                StudentId, Username);
        }
    }
}
