﻿using Microsoft.AspNetCore.Components.Web;

namespace Landing.PL.Areas.Dashboard.ViewModels
{
    public class ServiceFormVM
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted {  get; set; }
    }
}
