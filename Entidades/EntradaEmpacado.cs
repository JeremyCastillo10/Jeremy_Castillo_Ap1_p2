using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jeremy_Castillo_Ap1_p2.Entidades{
public class EntradaEmpacado
{
    [Key]
    public int EntradaId { get; set; }
    public int ProductoId { get; set; }

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

    [ForeignKey("ProductoId")]

    public virtual List<Productos> productos {get; set;} = new List<Productos>(); 



}
}