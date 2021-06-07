using Model;
using System;

namespace ZdravoKorporacija.DTO
{
    public class NotifikacijaDTO
    {
        public NotifikacijaDTO() { }

        public NotifikacijaDTO(int id, DateTime datum, TipNotifikacije tip, string sadrzaj, string status)
        {
            Id = id;
            Datum = datum;
            Tip = tip;
            Sadrzaj = sadrzaj;
            Status = status;
        }

        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public TipNotifikacije Tip { get; set; }
        public String Sadrzaj { get; set; }
        public String Status { get; set; }
    }
}
