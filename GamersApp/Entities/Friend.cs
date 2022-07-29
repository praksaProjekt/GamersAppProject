namespace GamersApp.Entities
{
    public class Friend
    {
        public int Id { get; set; }
        public int UserID1 { get; set; }
        public virtual User User1 { get; set; }
        public int UserID2 { get; set; }
        public virtual User User2 { get; set; }
    }
}
