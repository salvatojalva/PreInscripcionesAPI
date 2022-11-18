using System;
using System.Collections.Generic;

namespace PreInscripcionesAPI.Models;

public partial class SedeCarreraJornadum
{
    public int IdSedeCarreraJornada { get; set; }

    public string IdSede { get; set; } = null!;

    public string IdCarrera { get; set; } = null!;

    public int IdJornada { get; set; }

    public virtual Carrera IdCarreraNavigation { get; set; } = null!;

    public virtual Jornadum IdJornadaNavigation { get; set; } = null!;

    public virtual Sede IdSedeNavigation { get; set; } = null!;

    public virtual ICollection<PreinscripcionAlumno> PreinscripcionAlumnos { get; } = new List<PreinscripcionAlumno>();
}
