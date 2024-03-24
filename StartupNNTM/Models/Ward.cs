namespace StartupNNTM.Models
{
    public class Ward
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string FullName { get; set; }
        public string FullNameEn { get; set; }
        public string CodeName { get; set; }
        public int DistrictCode { get; set; }
        public int AdministrativeUnitId { get; set; }
        public AdministrativeUnit AdministrativeUnit { get; set; }
    }
}
