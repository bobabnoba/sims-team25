// File:    Doctor.cs
// Author:  User
// Created: Tuesday, March 23, 2021 10:47:16 PM
// Purpose: Definition of Class Doctor

using System;
using System.Collections;
public class Doktor : Korisnik
{
   public Pregled ZakaziTermin()
   {
      // TODO: implement
      return null;
   }
   
   public void AzurirajTermin(Termin pregled)
   {
      // TODO: implement
   }
   
   public bool OtkaziTermin(Termin pregled)
   {
      // TODO: implement
      return false;
   }
   
   public ArrayList UvidUTermine()
   {
      // TODO: implement
      return null;
   }

   public System.Collections.ArrayList termin;
   
   /// <pdGenerated>default getter</pdGenerated>
   public System.Collections.ArrayList GetTermin()
   {
      if (termin == null)
         termin = new System.Collections.ArrayList();
      return termin;
   }
   
   /// <pdGenerated>default setter</pdGenerated>
   public void SetTermin(System.Collections.ArrayList newTermin)
   {
      RemoveAllTermin();
      foreach (Termin oTermin in newTermin)
         AddTermin(oTermin);
   }
   
   /// <pdGenerated>default Add</pdGenerated>
   public void AddTermin(Termin newTermin)
   {
      if (newTermin == null)
         return;
      if (this.termin == null)
         this.termin = new System.Collections.ArrayList();
      if (!this.termin.Contains(newTermin))
      {
         this.termin.Add(newTermin);
         newTermin.SetDoktor(this);      
      }
   }
   
   /// <pdGenerated>default Remove</pdGenerated>
   public void RemoveTermin(Termin oldTermin)
   {
      if (oldTermin == null)
         return;
      if (this.termin != null)
         if (this.termin.Contains(oldTermin))
         {
            this.termin.Remove(oldTermin);
            oldTermin.SetDoktor((Doktor)null);
         }
   }
   
   /// <pdGenerated>default removeAll</pdGenerated>
   public void RemoveAllTermin()
   {
      if (termin != null)
      {
         System.Collections.ArrayList tmpTermin = new System.Collections.ArrayList();
         foreach (Termin oldTermin in termin)
            tmpTermin.Add(oldTermin);
         termin.Clear();
         foreach (Termin oldTermin in tmpTermin)
            oldTermin.SetDoktor((Doktor)null);
         tmpTermin.Clear();
      }
   }

}