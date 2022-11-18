using System;
using System.Collections.Generic;

namespace PreInscripcionesAPI.Models;

public partial class Sede
{
    public string IdSede { get; set; } = null!;

    public string NombreSede { get; set; } = null!;

    public virtual ICollection<SedeCarreraJornadum> SedeCarreraJornada { get; } = new List<SedeCarreraJornadum>();
}
