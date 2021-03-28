// File:    Appointment.cs
// Author:  User
// Created: Tuesday, March 23, 2021 10:47:13 PM
// Purpose: Definition of Class Appointment

using System;

public class Termin
{

    public Termin() { }


   public System.Collections.ArrayList izvestaj;
   
   /// <pdGenerated>default getter</pdGenerated>
   public System.Collections.ArrayList GetIzvestaj()
   {
      if (izvestaj == null)
         izvestaj = new System.Collections.ArrayList();
      return izvestaj;
   }
   
   /// <pdGenerated>default setter</pdGenerated>
   public void SetIzvestaj(System.Collections.ArrayList newIzvestaj)
   {
      RemoveAllIzvestaj();
      foreach (Izvestaj oIzvestaj in newIzvestaj)
         AddIzvestaj(oIzvestaj);
   }
   
   /// <pdGenerated>default Add</pdGenerated>
   public void AddIzvestaj(Izvestaj newIzvestaj)
   {
      if (newIzvestaj == null)
         return;
      if (this.izvestaj == null)
         this.izvestaj = new System.Collections.ArrayList();
      if (!this.izvestaj.Contains(newIzvestaj))
      {
         this.izvestaj.Add(newIzvestaj);
         newIzvestaj.SetTermin(this);      
      }
   }
   
   /// <pdGenerated>default Remove</pdGenerated>
   public void RemoveIzvestaj(Izvestaj oldIzvestaj)
   {
      if (oldIzvestaj == null)
         return;
      if (this.izvestaj != null)
         if (this.izvestaj.Contains(oldIzvestaj))
         {
            this.izvestaj.Remove(oldIzvestaj);
            oldIzvestaj.SetTermin((Termin)null);
         }
   }
   
   /// <pdGenerated>default removeAll</pdGenerated>
   public void RemoveAllIzvestaj()
   {
      if (izvestaj != null)
      {
         System.Collections.ArrayList tmpIzvestaj = new System.Collections.ArrayList();
         foreach (Izvestaj oldIzvestaj in izvestaj)
            tmpIzvestaj.Add(oldIzvestaj);
         izvestaj.Clear();
         foreach (Izvestaj oldIzvestaj in tmpIzvestaj)
            oldIzvestaj.SetTermin((Termin)null);
         tmpIzvestaj.Clear();
      }
   }
  private ZdravstveniKarton zdravstveniKarton;
   
   /// <pdGenerated>default parent getter</pdGenerated>
   public ZdravstveniKarton GetZdravstveniKarton()
   {
      return zdravstveniKarton;
   }
   
   /// <pdGenerated>default parent setter</pdGenerated>
   /// <param>newZdravstveniKarton</param>
   public void SetZdravstveniKarton(ZdravstveniKarton newZdravstveniKarton)
   {
      if (this.zdravstveniKarton != newZdravstveniKarton)
      {
         if (this.zdravstveniKarton != null)
         {
            ZdravstveniKarton oldZdravstveniKarton = this.zdravstveniKarton;
            this.zdravstveniKarton = null;
            oldZdravstveniKarton.RemoveTermin(this);
         }
         if (newZdravstveniKarton != null)
         {
            this.zdravstveniKarton = newZdravstveniKarton;
            this.zdravstveniKarton.AddTermin(this);
         }
      }
   }
    private Prostorija prostorija;
    private Doktor doktor;
   
   /// <pdGenerated>default parent getter</pdGenerated>
   public Doktor GetDoktor()
   {
      return doktor;
   }
   
   /// <pdGenerated>default parent setter</pdGenerated>
   /// <param>newDoktor</param>
   public void SetDoktor(Doktor newDoktor)
   {
      if (this.doktor != newDoktor)
      {
         if (this.doktor != null)
         {
            Doktor oldDoktor = this.doktor;
            this.doktor = null;
            oldDoktor.RemoveTermin(this);
         }
         if (newDoktor != null)
         {
            this.doktor = newDoktor;
            this.doktor.AddTermin(this);
         }
      }
   }

   public TipTermina Tip {get; set;}
   public DateTime Pocetak {get; set;}
   public double Trajanje {get; set;}

}