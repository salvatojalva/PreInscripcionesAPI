using System;
using System.Collections.Generic;

namespace PreInscripcionesAPI.Models;

public partial class Carrera
{
    public string IdCarrera { get; set; } = null!;

    public string NomCarrera { get; set; } = null!;

    public virtual ICollection<SedeCarreraJornadum> SedeCarreraJornada { get; } = new List<SedeCarreraJornadum>();
}
