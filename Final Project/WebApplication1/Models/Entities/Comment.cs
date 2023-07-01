﻿namespace WebApplication1.Models.Entities
{
    public class Comment
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public int Votes { get; set; }
        public DateTime Date { get; set; }
        //public int ChapterID { get; set; }
        public virtual Chapter Chapter { get; set; }
        public virtual ICollection<User> Users { get; set;}
    }
}
