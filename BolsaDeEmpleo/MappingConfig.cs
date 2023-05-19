
using AutoMapper;

namespace BolsaDeEmpleo
{
    //clase para mapear objetos

    //hereda de Profile propio del paquete automapper
    public class MappingConfig : Profile
    {

        public MappingConfig()
        {
            //crear mapeo indicando la fuente y el destino
            //CreateMap<Villa, VillaDto>();

            //hacemos lo inverso del mapeo anterior
            //CreateMap<VillaDto, Villa>();

            //ReverseMap() para ahorrarnos realizar el mapeo inverso y mapear en una sola linea
            //CreateMap<Villa, VillaCreateDto>().ReverseMap();
            //CreateMap<Villa, VillaUpdateDto>().ReverseMap();


        }
    }
}
