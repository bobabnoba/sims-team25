/***********************************************************************
 * Module:  Notifikacija.cs
 * Author:  User
 * Purpose: Definition of the Class Notifikacija
 ***********************************************************************/

using System;
using System.Collections;

namespace Model
{ 
    public class Anketa
    {
        public Anketa() { }

        public int Id { get; set; }
        public long IdAutora { get; set; }
        public DateTime Datum { get; set; }
        public TipAnkete Tip { get; set; }
        public int Ocena { get; set; }
        public String Komentar { get; set; }
        public Termin Termin { get; set; }
    }
}