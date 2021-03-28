// File:    Report.cs
// Author:  User
// Created: Wednesday, March 24, 2021 8:38:47 AM
// Purpose: Definition of Class Report

using System;

public class Izvestaj
{
   public Termin termin;
   
   /// <pdGenerated>default parent getter</pdGenerated>
   public Termin GetTermin()
   {
      return termin;
   }
   
   /// <pdGenerated>default parent setter</pdGenerated>
   /// <param>newTermin</param>
   public void SetTermin(Termin newTermin)
   {
      if (this.termin != newTermin)
      {
         if (this.termin != null)
         {
            Termin oldTermin = this.termin;
            this.termin = null;
            oldTermin.RemoveIzvestaj(this);
         }
         if (newTermin != null)
         {
            this.termin = newTermin;
            this.termin.AddIzvestaj(this);
         }
      }
   }

   public int Id {get; set;}
   public String Opis {get; set;}
   public String Simptomi {get; set;}

}