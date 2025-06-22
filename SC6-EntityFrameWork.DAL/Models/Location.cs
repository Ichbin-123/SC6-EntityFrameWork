using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC6_EntityFrameWork.DAL.Models;
public class Location
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string? Nome { get; set; }

    [Required]
    [MaxLength(250)]
    public string? Indirizzo { get; set; }

    [Required]
    [InverseProperty("Location")]
    public virtual ICollection<Torneo>? Tornei { get; set; }

}
