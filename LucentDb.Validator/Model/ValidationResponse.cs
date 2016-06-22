using System;

namespace LucentDb.Validator.Model
{
    public class ValidationResponse
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public string TestValue { get; set; }
        public bool IsValid { get; set; }
        public string ResultMessage { get; set; }
        public string RunLog { get; set; }
        public decimal Duration { get; set; }
        public DateTime RunDateTime { get; set; }
    }
}