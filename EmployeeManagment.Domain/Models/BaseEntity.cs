using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment.Domain.Models
{
    public class BaseEntity<TKey> where TKey : struct
    {
        [Key]
        public TKey Id { get; set; }
    }
}
