using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ElaboratoDB
{
    /// <summary>
    /// Logica di interazione per NuovoStudio.xaml
    /// </summary>
    public partial class NuovoStudio : Window
    {
        TeleperiziaDataContext db = new TeleperiziaDataContext();

        public NuovoStudio()
        {
            InitializeComponent();
        }

        private void btn_InsertNewStudio_Click(object sender, RoutedEventArgs e)
        {
            //int ID_Nuovo_Studio = db.Studi_Peritali.Count() + 1;
            int ID_Nuovo_Studio = 0;
            if (db.Studi_Peritali.Count() > 0)
                ID_Nuovo_Studio = db.Studi_Peritali.Max(std => std.ID_Studio) + 1;
            Supervisori supervisore = new Supervisori();
            supervisore.ID_Supervisore = 0;
            
            if(db.Supervisori.Count() > 0)
                supervisore.ID_Supervisore = db.Supervisori.Max(s => s.ID_Supervisore) + 1;

            supervisore.Nome = txt_Nome1Supervisore.Text;
            supervisore.Cognome = txt_Cognome1Supervisore.Text;
            supervisore.DataNascita = data1Supervisore.SelectedDate.Value.Date;
            supervisore.Email = txt_Email1Supervisore.Text;
            supervisore.Telefono = txt_Telefono1Supervisore.Text; 
            supervisore.CodiceFiscale = txt_CodiceFiscale1Supervisore.Text;
            supervisore.StudioPeritale = ID_Nuovo_Studio;

            Periti perito = new Periti();
            perito.ID_Perito = 0;
            if (db.Periti.Count() > 0)
                perito.ID_Perito = db.Periti.Max(p => p.ID_Perito) + 1;
            perito.Nome = txt_Nome1Perito.Text;
            perito.Cognome = txt_Cognome1Perito.Text;
            perito.DataNascita = data1Perito.SelectedDate.Value.Date;
            perito.Email = txt_Email1Perito.Text;
            perito.Telefono = txt_Telefono1Supervisore.Text; 
            perito.CodiceFiscale = txt_CodiceFiscale1Perito.Text;
            perito.StudioPeritale = ID_Nuovo_Studio;


            Luoghi luogo = new Luoghi();
            int ID_Luogo = 0;
            if (db.Luoghi.Count() > 0)
                ID_Luogo = db.Luoghi.Max(l => l.ID_Luogo) + 1;
            luogo.ID_Luogo = ID_Luogo;
            luogo.Via = txt_ViaStudio.Text;
            luogo.Citta = txt_CittaStudio.Text;
            luogo.NumeroCivico = txt_CivicoStudio.Text;
            luogo.Provincia = txt_ProvinciaStudio.Text;
            luogo.Comune = txt_ComuneStudio.Text;
            luogo.CAP = txt_StudioCAP.Text;
             
            Studi_Peritali studio = new Studi_Peritali();
            studio.ID_Studio = 0;
            if (db.Studi_Peritali.Count() > 0)
                studio.ID_Studio = ID_Nuovo_Studio;
            studio.Nome = txt_NomeStudio.Text;
            studio.Email = txt_EmailStudio.Text;
            studio.Telefono = txt_TelefonoStudio.Text;
            studio.Luogo = ID_Luogo;

            try
            {
                db.Luoghi.InsertOnSubmit(luogo);
                db.Studi_Peritali.InsertOnSubmit(studio);
                db.Supervisori.InsertOnSubmit(supervisore);
                db.Periti.InsertOnSubmit(perito); 
                db.SubmitChanges();
                MessageBox.Show("Studio inserito correttamente.");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Si è verificato un problema nel caricamento sul database, controllare i dati inseriti e riprovare.");
               // throw;
            }

        }
    }
}
