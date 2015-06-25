using System;

namespace LucentDb.Domain.Model
{
    public class ValidationResponse
    {
        public bool IsValid { get; set; }
        public string ResultMessage { get; set; }
        public string RunLog { get; set; }
        public double Duration { get; set; }
        public DateTime RunDateTime { get; set; }
    }
}