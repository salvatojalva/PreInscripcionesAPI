using System;
using System.Collections.Generic;

namespace PreInscripcionesAPI.Models;

public partial class PreinscripcionAlumno
{
    public string Id { get; set; } = null!;

    public string Nombre1 { get; set; } = null!;

    public string Nombre2 { get; set; } = null!;

    public string Apellido1 { get; set; } = null!;

    public string Apellido2 { get; set; } = null!;

    public string EstadoCivil { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public DateTime Fechanac { get; set; }

    public DateTime FechaPre { get; set; }

    public string Celular { get; set; } = null!;

    public string? CorreoPersonal { get; set; }

    public string Direccion { get; set; } = null!;

    public bool Estado { get; set; }

    public string? Dpi { get; set; }

    public int? IdSedeCarreraJornada { get; set; }

    public virtual SedeCarreraJornadum? IdSedeCarreraJornadaNavigation { get; set; }
}
