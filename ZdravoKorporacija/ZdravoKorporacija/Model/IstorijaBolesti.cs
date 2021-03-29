/***********************************************************************
 * Module:  IstorijaBolesti.cs
 * Author:  tukitaki
 * Purpose: Definition of the Class IstorijaBolesti
 ***********************************************************************/

using System;
using System.Collections;

public class IstorijaBolesti
{
   public System.Collections.ArrayList dijagnoza;

    public IstorijaBolesti(ZdravstveniKarton zdravstveniKarton, DateTime datumPoseteLekaru, string opisPosete)
    {
        this.dijagnoza = new System.Collections.ArrayList();
        this.zdravstveniKarton = zdravstveniKarton;
        DatumPoseteLekaru = datumPoseteLekaru;
        OpisPosete = opisPosete;
    }

    /// <pdGenerated>default getter</pdGenerated>
    public System.Collections.ArrayList GetDijagnoza()
   {
      if (dijagnoza == null)
         dijagnoza = new System.Collections.ArrayList();
      return dijagnoza;
   }
   
   /// <pdGenerated>default setter</pdGenerated>
   public void SetDijagnoza(System.Collections.ArrayList newDijagnoza)
   {
      RemoveAllDijagnoza();
      foreach (Dijagnoza oDijagnoza in newDijagnoza)
         AddDijagnoza(oDijagnoza);
   }
   
   /// <pdGenerated>default Add</pdGenerated>
   public void AddDijagnoza(Dijagnoza newDijagnoza)
   {
      if (newDijagnoza == null)
         return;
      if (this.dijagnoza == null)
         this.dijagnoza = new System.Collections.ArrayList();
      if (!this.dijagnoza.Contains(newDijagnoza))
         this.dijagnoza.Add(newDijagnoza);
   }
   
   /// <pdGenerated>default Remove</pdGenerated>
   public void RemoveDijagnoza(Dijagnoza oldDijagnoza)
   {
      if (oldDijagnoza == null)
         return;
      if (this.dijagnoza != null)
         if (this.dijagnoza.Contains(oldDijagnoza))
            this.dijagnoza.Remove(oldDijagnoza);
   }
   
   /// <pdGenerated>default removeAll</pdGenerated>
   public void RemoveAllDijagnoza()
   {
      if (dijagnoza != null)
         dijagnoza.Clear();
   }
   public ZdravstveniKarton zdravstveniKarton;
   
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
            oldZdravstveniKarton.RemoveIstorijaBolesti(this);
         }
         if (newZdravstveniKarton != null)
         {
            this.zdravstveniKarton = newZdravstveniKarton;
            this.zdravstveniKarton.AddIstorijaBolesti(this);
         }
      }
   }

   public DateTime DatumPoseteLekaru {get; set;}
   public String OpisPosete {get; set;}

}