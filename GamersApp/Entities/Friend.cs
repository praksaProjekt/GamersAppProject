﻿namespace GamersApp.Entities
{
    public class Friend
    {
        public virtual int Id { get; set; }
        public virtual int UserID1 { get; set; }
        public virtual User User1 { get; set; }
        public virtual int UserID2 { get; set; }
        public virtual User User2 { get; set; }
    }
}
