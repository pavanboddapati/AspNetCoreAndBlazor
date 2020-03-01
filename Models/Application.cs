using System;
namespace AppAssessment.Models
{
    public class Application
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ShortAppId { get; set; }
        public string RemedyId { get; set; }
        public string Description { get; set; }
        public DateTime InstallDate { get; set; }
        public string Status { get; set; }
        public bool IsHighRisk { get; set; }
    }
}
