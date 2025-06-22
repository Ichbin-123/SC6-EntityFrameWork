using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC6_EntityFrameWork.DAL.Models;
public class Prenotazione
{
    [Required]
    public DateTime? DataPrenotazione { get; set; }

    [Required]
    public  int? SquadraId { get; set; } // FK

    [ForeignKey("SquadraId")]
    public virtual Squadra? Squadra { get; set; } // Navigation Property

    [Required]
    public int? TorneoId { get; set; } // FK


    [ForeignKey("TorneoId")]
    public virtual Torneo? Torneo { get; set; } // Navigation Prorperty


}
