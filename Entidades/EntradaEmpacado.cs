using System.ComponentModel.DataAnnotations;

namespace Jeremy_Castillo_Ap1_p2.Entidades{
public class EntradaEmpacado
{
    [Key]
    public int Id { get; set; }

    public string ? ProductoUtilizado {get; set; }
    [Required(ErrorMessage = "Campo obligatorio.")]
    public string ? ProductoProducido {get; set; }
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "Campo obligatorio.")]
    public string? Concepto { get; set; }
    [Required(ErrorMessage = "Campo obligatorio.")]

    public int CantidadUtilizado { get; set; }
    [Required(ErrorMessage = "Campo obligatorio.")]
    

    public int CantidadProducido { get; set; }

    public virtual List<Productos> entradaEmpacados {get;set;}= new List<Productos>();


}
}