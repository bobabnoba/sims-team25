﻿// File:    Patient.cs
// Author:  User
// Created: Tuesday, March 23, 2021 10:47:17 PM
// Purpose: Definition of Class Patient

using System;
using System.Collections;

public class Pacijent : Korisnik
{
    public Pregled ZakaziPregled()
    {
        // TODO: implement
        return null;
    }

    public void AzurirajPregled(Termin pregled)
    {
        // TODO: implement
    }

    public bool OtkaziPregled(Termin pregled)
    {
        // TODO: implement
        return false;
    }

    public ArrayList UvidUPreglede()
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
            this.termin.Add(newTermin);
    }

    /// <pdGenerated>default Remove</pdGenerated>
    public void RemoveTermin(Termin oldTermin)
    {
        if (oldTermin == null)
            return;
        if (this.termin != null)
            if (this.termin.Contains(oldTermin))
                this.termin.Remove(oldTermin);
    }

    /// <pdGenerated>default removeAll</pdGenerated>
    public void RemoveAllTermin()
    {
        if (termin != null)
            termin.Clear();
    }
    public ZdravstveniKarton ZdravstveniKarton { get; set; }

    public bool Guest {get; set;}

}