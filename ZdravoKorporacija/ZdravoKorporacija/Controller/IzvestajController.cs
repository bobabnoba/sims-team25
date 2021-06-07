using Service;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Controller
{
    class IzvestajController
    {
        private static IzvestajController _instance;
        IzvestajService izvestajServis = IzvestajService.Instance;
        public static IzvestajController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new IzvestajController();
                }
                return _instance;
            }
        }

        public ObservableCollection<IzvestajDTO> PregledSvihIzvestaja()
        {
            return izvestajServis.PregledSvihIzvestaja();
        }
    }
}
