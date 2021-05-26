using System;
using System.Collections.Generic;
using System.Text;

namespace ZdravoKorporacija.Konverteri
{
    public interface IKonverter<E, DTO>
        where E : class
        where DTO : class
    {
        DTO KonvertujEntitetUDTO(E entitet);

        E KonvertujDTOuEntitet(DTO dto);

        List<E> KonvertujDTOSuEntitete(IEnumerable<DTO> dtos);

        IEnumerable<DTO> KonvertujEntiteteUDTOS(List<E> entiteti);
    }
}
