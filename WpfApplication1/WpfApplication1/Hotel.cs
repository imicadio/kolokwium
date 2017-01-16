using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Hotel : IHotel, IData
    {
        private SortedList<Pokoj, Osoba> lista = new SortedList<Pokoj, Osoba>();      
        private double zysk = -50;
        private DateTime data;

        public void DodajRezerwacje(string imie, string nazwisko, int nr, double cena)
        {
            lista.Add(new Pokoj(nr, cena), new Osoba(imie, nazwisko));
            zysk += cena;
        }

        public void OdwolajRezerwacje()
        {
            if (lista.Count > 0)
                lista.RemoveAt(lista.Count - 1);
        }

        public void UstawDate(DateTime Time)
        {
            data = Time;
        }

        public bool SprawdzDate()
        {
            if (DateTime.Compare(data, DateTime.Today) > 0)
                return true;
            return false; 
        }

        public override string ToString()
        {
            string info = "Rezerwacje:";
            foreach (var element in lista)
            {
                info += Environment.NewLine + "Data: " + data;
                info += Environment.NewLine + element.Key.ToString() + element.Value.ToString();
            }
            return info + Environment.NewLine + Convert.ToString(zysk);
        }
    }
}
