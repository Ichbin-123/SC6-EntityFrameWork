using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC6_EntityFrameWork.DAL.Models;
public class Squadra
{
    public int Id { get; set; }

    [Required]
    public string? Nome { get; set; }

    [Required]
    [InverseProperty("Squadra")]
    public virtual ICollection<Giocatore>? Giocatori { get; set; } // nome della navigation property in Giocatore

    [Required]
    [InverseProperty("Squadra")]
    public virtual ICollection<Prenotazione>? Prenotazioni { get; set; } // nome della navigation property in Prenotazione
}
