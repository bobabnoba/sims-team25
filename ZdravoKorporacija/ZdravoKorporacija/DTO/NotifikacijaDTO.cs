using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace ZdravoKorporacija.DTO
{
    class NotifikacijaDTO
    {
        public NotifikacijaDTO() { }

        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public TipNotifikacije Tip { get; set; }
        public String Sadrzaj { get; set; }
        public String Status { get; set; }

    }
}
