using static webApi_Net8.Helper.SqlHelper;

namespace webApi_Net8.request
{
    public class testStudent
    {
        [ColumnName("id")]
        public int Id { get; set; }
        [ColumnName("sname")]

        public string? Name { get; set; }
        [ColumnName("id")]

        public int age { get; set; }



    }

    public class listStudent
    {
        public List<testStudent> students { get; set; }

    }
}
