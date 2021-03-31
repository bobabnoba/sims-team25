/***********************************************************************
 * Module:  Prostorija.cs
 * Author:  tukitaki
 * Purpose: Definition of the Class Prostorija
 ***********************************************************************/

using System;

public class Prostorija
{
    public System.Collections.ArrayList inventar;


    public Prostorija(int id, string naziv, TipProstorijeEnum tip, bool slobodna, int sprat)
    {
        this.inventar = new System.Collections.ArrayList(); ;
        Id = id;
        Naziv = naziv;
        Tip = tip;
        Slobodna = slobodna;
        Sprat = sprat;
    }


    /// <pdGenerated>default getter</pdGenerated>
    public System.Collections.ArrayList GetInventar()
    {
        if (inventar == null)
            inventar = new System.Collections.ArrayList();
        return inventar;
    }

    /// <pdGenerated>default setter</pdGenerated>
    public void SetInventar(System.Collections.ArrayList newInventar)
    {
        RemoveAllInventar();
        foreach (Inventar oInventar in newInventar)
            AddInventar(oInventar);
    }

    /// <pdGenerated>default Add</pdGenerated>
    public void AddInventar(Inventar newInventar)
    {
        if (newInventar == null)
            return;
        if (this.inventar == null)
            this.inventar = new System.Collections.ArrayList();
        if (!this.inventar.Contains(newInventar))
            this.inventar.Add(newInventar);
    }

    /// <pdGenerated>default Remove</pdGenerated>
    public void RemoveInventar(Inventar oldInventar)
    {
        if (oldInventar == null)
            return;
        if (this.inventar != null)
            if (this.inventar.Contains(oldInventar))
                this.inventar.Remove(oldInventar);
    }

    /// <pdGenerated>default removeAll</pdGenerated>
    public void RemoveAllInventar()
    {
        if (inventar != null)
            inventar.Clear();
    }

    public int Id { get; set; }
    public String Naziv { get; set; }
    public TipProstorijeEnum Tip { get; set; }
    public bool Slobodna { get; set; }
    public int Sprat { get; set; }

}