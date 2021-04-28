/***********************************************************************
 * Module:  Notifikacija.cs
 * Author:  User
 * Purpose: Definition of the Class Notifikacija
 ***********************************************************************/

using System;
using System.Collections;

namespace Model
{ 
    public class Notifikacija
    {
        public Notifikacija() { }

        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public TipNotifikacije Tip { get; set; }
        public String Sadrzaj { get; set; }
        public String Status { get; set; }

    }
}