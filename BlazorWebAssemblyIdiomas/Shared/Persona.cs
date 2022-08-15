using System.ComponentModel.DataAnnotations;

namespace BlazorWebAssemblyIdiomas.Shared
{
    public class Persona
    {
        [Required(
            ErrorMessageResourceType = typeof(Recursos.Resource),
            ErrorMessageResourceName = nameof(Recursos.Resource.required))]
        public string Nombre { get; set; }
    }
}
