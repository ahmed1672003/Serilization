//using System.Text.Json.Serialization;

namespace Serilization.Api.Models;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }

    //[JsonIgnore]
    public virtual IEnumerable<Employee>? Employees { get; set; }
    public Department() => Employees = new HashSet<Employee>();

}
