﻿namespace Landing.PL.Areas.Dashbord.ViewModels
{
    public class ServiceDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
