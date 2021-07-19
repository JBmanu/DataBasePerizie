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
    /// Logica di interazione per NuovoSinistro.xaml
    /// </summary>
    public partial class NuovoSinistro : Window
    {
        TeleperiziaDataContext db = new TeleperiziaDataContext();
        public NuovoSinistro()
        {
            InitializeComponent();
            InitializeComboBoxes();
        }

        public void InitializeComboBoxes()
        {
            cmb_AssicurazioneNuovoSinistro.ItemsSource = db.Assicurazioni.Select(assicurazione => assicurazione.Denominazione);
            cmb_CategoriaNuovoSinistro.ItemsSource = db.Categoria_Sinistri.Select(sinistro => sinistro.Appellativo);
            cmb_StudioNuovoSinistro.ItemsSource = db.Studi_Peritali.Select(studio => studio.ID_Studio);
        }

        private void btn_NuovoSinistro_Click(object sender, RoutedEventArgs e)
        {
            Sinistri sinistro = new Sinistri();
            if(db.Sinistri.Count() > 0)
                sinistro.ID_Sinistro = db.Sinistri.Max(s=>s.ID_Sinistro) + 1;

            Luoghi luogo = new Luoghi();
            int ID_Luogo = 0;
            if(db.Luoghi.Count() > 0)
                ID_Luogo = db.Luoghi.Max(l => l.ID_Luogo);
            luogo.ID_Luogo = ID_Luogo;
            luogo.Via = txt_ViaNuovoSinistro.Text;
            luogo.NumeroCivico = txt_CivicoNuovoSinistro.Text;
            luogo.Provincia = txt_ProvinciaNuovoSinistro.Text;
            luogo.Comune = txt_ComuneNuovoSinistro.Text;
            luogo.CAP = txt_CAPNuovoSinistro.Text;
            luogo.Citta = txt_CittaNuovoSinistro.Text;

            sinistro.Categoria = cmb_CategoriaNuovoSinistro.Text;
            sinistro.Assicurazione = cmb_AssicurazioneNuovoSinistro.Text;

            sinistro.Descrizione = txt_DescrizioneNuovoSinistro.Text;
            sinistro.Assicurato = Convert.ToInt32(txt_IdAssicuratoNuovoSinistro.Text);
            sinistro.Luogo = ID_Luogo;
            //sinistro.ID_Studio = db.Studi_Peritali.First(studio => studio.Nome == cmb_StudioNuovoSinistro.Text);
            
            if (cmb_StudioNuovoSinistro.Text != "")
            {
                Console.WriteLine("SI");
                sinistro.StudioPeritale = Convert.ToInt32(cmb_StudioNuovoSinistro.Text);
            }

           

            try
            {
                db.Luoghi.InsertOnSubmit(luogo);
                db.Sinistri.InsertOnSubmit(sinistro);
                db.SubmitChanges();
                MessageBox.Show("Inserimento avvenuto con successo.");
                this.Close();
            }
            catch (Exception)
            {
               // throw;
                MessageBox.Show("Errore nel caricamento dei dati relativi al sinistro, riprovare.");
            }

        }
    }
}
