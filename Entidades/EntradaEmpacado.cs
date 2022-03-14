using System.ComponentModel.DataAnnotations;

namespace Jeremy_Castillo_Ap1_p2.Entidades{
public class EntradaEmpacado
{
    [Key]
    public int Id { get; set; }

    public string ? producto {get; set; }
    public DateTime Fecha { get; set; }
    public string? Concepto { get; set; }

    public int Existencia { get; set; }

    public int CantidadUtilizado { get; set; }

    public int CantidadProducido { get; set; }

    public virtual List<Productos> productos {get;set;}= new List<Productos>();


}
}