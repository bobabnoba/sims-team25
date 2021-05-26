using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Controller
{
    class ReceptController
    {
        ReceptServis rs = ReceptServis.Instance;
        private static ReceptController _instance;

        public static ReceptController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReceptController();
                }
                return _instance;
            }
        }
        public ObservableCollection<ReceptDTO> PregledSvihRecepata()
        {
            return rs.PregledSvihRecepata();
        }
    }
}
