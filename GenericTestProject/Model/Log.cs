using System;
using System.Collections.Generic;
using System.Text;

namespace GenericTestProject.Model
{
    public sealed class Log
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public DateTime TimeOfEvent { get; set; } = DateTime.UtcNow;
    }
}
