using SC6_EntityFrameWork.DAL;
using SC6_EntityFrameWork.DAL.Models;

namespace SC6_EntityFrameWork;
public class Program
{
    static void Main(string[] args)
    {
        using var dc = new TournamentContext();

        try
        {
            if (dc.Locations.Count()==0)
            {
                #region 4 - Inserire una location
                Location location1 = new Location
                {
                    Nome = "Stadio Luigi Ferraris - Marassi",
                    Indirizzo = "Via Giovanni De Prà 1, 16139 Genova"
                };
                dc.Locations.Add(location1);
                #endregion

                if (dc.Tornei.Count()==0)
                {
                    #region 5 - Inserire un Torneo che si svolge nella Location appena inserita
                    Torneo torneo1 = new Torneo
                    {
                        DataInizio = new DateTime(2025, 8, 10),
                        Nome = "Coppa Italia",
                        NumeroSquadre = 16,
                        Location = location1
                        //LocationId = location1.Id
                    };
                    dc.Tornei.Add(torneo1);
                    #endregion

                    if (dc.Squadre.Count()==0)
                    {
                        #region 6 - Crea 4 squadre con almeno 2 giocatori

                        Squadra cesena = new Squadra { Nome = "AC Cesena" };

                        Giocatore falcoFilippo = new Giocatore
                        {
                            Nome ="Filippo Falco",
                            NumeroMaglia = 10,
                            DataNascita = new DateTime(1992, 4, 11),
                            Squadra = cesena
                        };

                        Giocatore dellOrcoFrancesco = new Giocatore
                        {
                            Nome ="Francesco Dell'Orco",
                            NumeroMaglia = 8,
                            DataNascita = new DateTime(1994, 5, 16),
                            Squadra = cesena
                        };

                        Squadra sassuolo = new Squadra { Nome = "US Sassuolo Calcio" };

                        Giocatore bernardiDomenico = new Giocatore
                        {
                            Nome ="Domenico Bernardi",
                            NumeroMaglia = 25,
                            DataNascita = new DateTime(1994, 8, 1),
                            Squadra = sassuolo
                        };

                        Giocatore raspadoriGiacomo = new Giocatore
                        {
                            Nome ="Giacomo Raspadori",
                            NumeroMaglia = 25,
                            DataNascita = new DateTime(1994, 8, 1),
                            Squadra = sassuolo
                        };

                        Squadra bologna = new Squadra { Nome = "Bologna FC 1909" };

                        Giocatore arnautovicMarko = new Giocatore
                        {
                            Nome ="Marko Arnautovic",
                            NumeroMaglia = 9,
                            DataNascita = new DateTime(1989, 4, 19),
                            Squadra = bologna
                        };

                        Giocatore orsoliniRiccardo = new Giocatore
                        {
                            Nome ="Riccardo Orsolini",
                            NumeroMaglia = 7,
                            DataNascita = new DateTime(1997, 7, 24),
                            Squadra = bologna
                        };

                        Squadra modena = new Squadra { Nome = "Modena FC 2018" };

                        Giocatore razzittiAndrea = new Giocatore
                        {
                            Nome ="Andrea Razzitti",
                            NumeroMaglia = 11,
                            DataNascita = new DateTime(1984, 12, 7),
                            Squadra = modena
                        };

                        Giocatore bocalonRiccardo = new Giocatore
                        {
                            Nome ="Riccardo Bocalon",
                            NumeroMaglia = 9,
                            DataNascita = new DateTime(1989, 4, 18),
                            Squadra = modena
                        };

                        dc.Squadre.AddRange(cesena, sassuolo, bologna, modena);
                        dc.Giocatori.AddRange(falcoFilippo, dellOrcoFrancesco, bernardiDomenico, raspadoriGiacomo, arnautovicMarko, orsoliniRiccardo, razzittiAndrea, bocalonRiccardo);

                        dc.SaveChanges();
                        #endregion
                    }
                }
            }


            #region 7 - Slezionare tutte le Squadre del DB
            // var squadreTorneo = dc.Squadre.Where(x => true);
            var squadreTorneo = dc.Squadre;
            #endregion



            if (squadreTorneo.Count()!=0 && dc.Prenotazioni.Count()==0)
            {
                #region 8 - Iscrivere le Squadre di cui sopra al Torneo

                var torneoCoppaItalia = dc.Tornei.FirstOrDefault(t => t.Nome == "Coppa Italia");
                if(torneoCoppaItalia != null)
                {
                    foreach (Squadra squad in squadreTorneo)
                    {
                        Prenotazione iscrizioneCoppaItalia = new Prenotazione
                        {
                            Squadra = squad,
                            Torneo = torneoCoppaItalia,
                            DataPrenotazione = DateTime.Now
                        };
                        dc.Prenotazioni.Add(iscrizioneCoppaItalia);
                    }
                    dc.SaveChanges();
                }
                #endregion
            }

            if (dc.Tornei.Count()!=0)
            {
                var torneoInDB = dc.Tornei.FirstOrDefault(t => t.Nome == "Coppa Italia");

                if (torneoInDB != null)
                {
                    #region 9 - Interrogare il DB per avere le info sul Torneo, compresa la Location
                    Printer.PrinterColor(torneoInDB, ConsoleColor.Green);
                    Printer.PrinterColor(torneoInDB.Location!, ConsoleColor.Yellow);
                    #endregion

                    #region 10 - Interrogare il DB per sapere, a partire dal Torneo di cuis sopra, l'elenco delle Sqadre iscritte (con data di iscrizione)
                    foreach (var prenotazione in torneoInDB.Prenotazioni!)
                    {
                        Console.Write($"Data di iscrizione: {prenotazione.DataPrenotazione} - ");
                        Printer.PrinterColor(prenotazione.Squadra!, ConsoleColor.Blue);
                    }
                    #endregion

                }
            }
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
            dc.Dispose();
        }
        

        


    }
}
