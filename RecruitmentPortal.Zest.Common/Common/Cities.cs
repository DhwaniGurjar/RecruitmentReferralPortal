namespace RecruitmentPortal.Zest.Common.Common
{
    public class Cities
    {
        public short ID { get; set; }
        public string Name { get; set; }
        public short StateID { get; set; }
        public string StateNumber { get; set; }
        public virtual States States { get; set; }
    }
}
