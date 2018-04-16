using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedWeiFuApi.Models
{
    public class TestTrack
    {
        public int Id { get; set; }
        public string TestTabClass { get; set; }
        public string TestType { get; set; }
        public string TestTitle { get; set; }
        public string TestProduct { get; set; }
        public string TestContent { get; set; }
        public string TestStatus { get; set; }
        public string TestSource { get; set; }
        public string TestRegister { get; set; }
        public string Tester { get; set; }
        public string TestRemark { get; set; }
        public string TestRegTime { get; set; }
        public string TestModTime { get; set; }
    }
}