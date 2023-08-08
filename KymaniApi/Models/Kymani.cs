using System.ComponentModel.DataAnnotations;

namespace KymaniApi.Models
{
  public class Kymani
  {
    public int KymaniId { get; set; }
    [Required] 
    public string Mood { get; set; }
     [Range(1, 9999, ErrorMessage = "Power level must be between 1 and 9999.")]
    public int PowerLevel { get; set; }
  }
}