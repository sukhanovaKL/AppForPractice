using System;
using System.Linq;
using System.Windows;

namespace AppForPractice
{
    class Functions
    {
        practica_5Entities db = new practica_5Entities();

        public void EditTarif(int id, int cost, int preferentialCost_at20to2_, int preferentialCost_at2to6_, DateTime date)
        {
            InternetPrice internetPrice = db.InternetPrice.ToList().Find(x => x.InternetPricesId == id);
            internetPrice.CostMinute = cost;
            internetPrice.PreferentialCost_at20to2_ = preferentialCost_at20to2_;
            internetPrice.PreferentialCost_at2to6_ = preferentialCost_at2to6_;
            internetPrice.Date = date;
            db.SaveChanges();
            MessageBox.Show("Изменения успешно сохранены!");
        }

        public void DeleteTarif(int id)
        {
            InternetPrice internetPrice = db.InternetPrice.ToList().Find(x => x.InternetPricesId == id);
            var haveFK = db.Receipt.ToList().FindAll(x => x.InternetPricesId == id);
            if(haveFK.Any())
                MessageBox.Show("Нельзя удалить данный тариф, так как он используется в квитанциях!");
            else
            {
                db.InternetPrice.Remove(internetPrice);
                db.SaveChanges();
                MessageBox.Show("Удалено!");
            }
        }

        public void CreateTarif(int cost, int preferentialCost_at20to2_, int preferentialCost_at2to6_, DateTime date)
        {
            InternetPrice internetPrice = new InternetPrice
            {
                InternetPricesId = db.InternetPrice.ToList().Count + 1,
                CostMinute = cost,
                PreferentialCost_at20to2_ = preferentialCost_at20to2_,
                PreferentialCost_at2to6_ = preferentialCost_at2to6_,
                Date = date
            };
            db.InternetPrice.Add(internetPrice);
            db.SaveChanges();
            MessageBox.Show("Успешно добавлено!");
        }

        public void CreateKlientInfo(string computerNumer, string ipAddress, DateTime dateStart, DateTime dateEnd)
        {
            KlientsInfo klient = new KlientsInfo
            {
                KlientId = db.KlientsInfo.ToList().Count + 1,
                ComputerNumber = computerNumer,
                IPAddress = ipAddress,
                DateStart = dateStart,
                DateEnd = dateEnd,
                TimeStart = dateStart.TimeOfDay,
                TimeEnd = dateEnd.TimeOfDay
            };
            db.KlientsInfo.Add(klient);
            db.SaveChanges();
            MessageBox.Show("Успешно добавлено!");
        }

        public void DeleteKlientInfo(int id)
        {
            KlientsInfo klientInfo = db.KlientsInfo.ToList().Find(x => x.KlientId == id);
            var haveFK = db.Receipt.ToList().FindAll(x => x.KlientId == id);
            if (haveFK.Any())
                MessageBox.Show("Нельзя удалить данную запись, так как она используется в квитанциях!");
            else
            {
                db.KlientsInfo.Remove(klientInfo);
                db.SaveChanges();
                MessageBox.Show("Удалено!");
            }
        }
    }
}
