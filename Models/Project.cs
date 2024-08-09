﻿namespace GraphQl.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Activity> Tasks { get; set; }
    }
}
