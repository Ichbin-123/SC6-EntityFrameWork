using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC6_EntityFrameWork.DAL.Models;
public class Torneo
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string? Nome { get; set; }

    [Required]
    public DateTime DataInizio { get; set; }

    [Required]
    public int? NumeroSquadre { get; set; }

    [Required]
    public int? LocationId { get; set; } // Foreign Key Property


    [ForeignKey("LocationId")]
    public virtual Location? Location { get; set; } // Navigation property

    [InverseProperty("Torneo")]
    public virtual ICollection<Prenotazione>? Prenotazioni { get; set; } // Nome della navigation property in Prenotazione

}
