using System;
using System.Collections.Generic;

namespace PreInscripcionesAPI.Models;

public partial class Jornadum
{
    public int IdJornada { get; set; }

    public string NombreJornada { get; set; } = null!;

    public virtual ICollection<SedeCarreraJornadum> SedeCarreraJornada { get; } = new List<SedeCarreraJornadum>();
}
