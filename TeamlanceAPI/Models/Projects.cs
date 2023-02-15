namespace TeamlanceAPI.Models
{
    public class Project
    {


        public Guid id { get; set; }

        public int seriNo { get; set; }

        public string projectName { get; set; }

        public string clientName { get; set; }

        public string startDate { get; set; }

        public string projectAmount { get; set; }

        public string headCount { get; set; }

        public string currentStatus { get; set; }

    }
}
