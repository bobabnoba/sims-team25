using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace ZdravoKorporacija.Model
{
    class FeedbackForma
    {

        public FeedbackForma() { }

        public FeedbackForma(string sadrzaj, UlogaEnum uloga)
        {
            this.sadrzaj = sadrzaj;
            this.uloga = uloga;
        }



        public UlogaEnum uloga { get; set; }
        public string sadrzaj { get; set; }
    }
}
