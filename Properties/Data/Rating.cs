using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantRaterApi.Data;

public class Rating 
{
    [Key] 
    public int Id { get; set; } 

    [Required] 
    [Range(0,5)] 
    public double Score { get; set; } 

    [Required] 
    [ForeignKey(nameof(Restaurant))] 
    public int RestaurantId { get; set; } 
    public virtual Restaurant Restaurant { get; set; } = null;
}