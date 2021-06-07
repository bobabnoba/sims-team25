using Model;
using Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;

namespace Service
{
    public class IzvestajService
    {
        IzvestajRepozitorijum ir = IzvestajRepozitorijum.Instance;
        IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapIzvestaj");
        ObservableCollection<Izvestaj> izvestaji = IzvestajRepozitorijum.Instance.DobaviSve();
        private static IzvestajService _instance;
        Dictionary<int, int> id_map = new Dictionary<int, int>();

        public static IzvestajService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new IzvestajService();
                }
                return _instance;
            }
        }

        public bool DodajIzvestaj(IzvestajDTO izvestaj, Dictionary<int, int> id_map)
        {

            foreach (Izvestaj iz in izvestaji)
            {
                if (iz.Id.Equals(izvestaj.Id))
                {
                    return false;
                }
            }
            izvestaji.Add(convertToModel(izvestaj));
            //Trace.WriteLine(convertToModel(izvestaj).Id);
            ir.Sacuvaj(izvestaji);
            datotekaID.sacuvaj(id_map);
            return true;
        }

        public bool ObrisiIzvestaj(IzvestajDTO izvestaj, Dictionary<int, int> id_map)
        {
            foreach (Izvestaj iz in izvestaji)
            {
                if (iz.Id.Equals(izvestaj.Id))
                {
                    izvestaji.Remove(iz);
                    ir.Sacuvaj(izvestaji);
                    return true;
                }
            }
            return false;
        }

        public bool AzurirajIzvestaj(IzvestajDTO izvestaj)
        {
            ObservableCollection<Izvestaj> izvestaji = ir.DobaviSve();
            foreach (Izvestaj iz in izvestaji)
            {
                if (iz.Id.Equals(izvestaj.Id))
                {
                    izvestaji.Remove(iz);
                    izvestaji.Add(convertToModel(izvestaj));
                    ir.Sacuvaj(izvestaji);
                    return true;
                }
            }
            return false;
        }

        public IzvestajDTO PregledIzvestaj(string id)
        {
            ObservableCollection<Izvestaj> izvestaji = ir.DobaviSve();
            foreach (Izvestaj iz in izvestaji)
            {
                if (iz.Id.Equals(id))
                {
                    return new IzvestajDTO(iz);
                }
            }
            return null;
        }

        public ObservableCollection<IzvestajDTO> PregledSvihIzvestaja()
        {
            ObservableCollection<Izvestaj> izvestaji = ir.DobaviSve();
            ObservableCollection<IzvestajDTO> izvestajDTOs = new ObservableCollection<IzvestajDTO>();
            foreach (Izvestaj i in izvestaji)
            {
                izvestajDTOs.Add(convertToDTO(i));
            }
            return izvestajDTOs;
        }

        public Izvestaj convertToModel(IzvestajDTO izvestaj)
        {
            return new Izvestaj(izvestaj);
        }

        public IzvestajDTO convertToDTO(Izvestaj izvestaj)
        {
            return new IzvestajDTO(izvestaj);
        }

    }
}