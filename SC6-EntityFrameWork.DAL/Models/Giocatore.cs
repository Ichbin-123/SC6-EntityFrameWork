using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC6_EntityFrameWork.DAL.Models;

public class Giocatore
{
    public int Id { get; set; }

    [Required]
    public string? Nome { get; set; }

    [Required]
    public int? NumeroMaglia { get; set; }

    [Required]
    public DateTime? DataNascita { get; set; }

    [Required]
    public  int? SquadraId { get; set; } // Foreign key

    [ForeignKey("SquadraId")]
    public virtual Squadra? Squadra { get; set; } // Navigation Property
}
