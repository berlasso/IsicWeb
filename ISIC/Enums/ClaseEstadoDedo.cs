using System.ComponentModel;

namespace ISIC.Enums
{
    public enum ClaseEstadoDedo
    {
        [Description("Normal")]
        Normal=1,
        [Description("Amputado")]
        Faltante=3,
        [Description("Lastimado/Enyesado")]
        Lastimado=2,
        [Description("Huella No Apta")]
        HuellaNoApta = 4
       
    }
}   

  