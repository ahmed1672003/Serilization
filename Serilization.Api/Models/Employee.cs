using System.ComponentModel.DataAnnotations.Schema;
//using System.Text.Json.Serialization;

namespace Serilization.Api.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public int DepartmentId { get; set; }

    //[JsonIgnore]
    [ForeignKey(nameof(DepartmentId))]
    public virtual Department? Department { get; set; }
}
