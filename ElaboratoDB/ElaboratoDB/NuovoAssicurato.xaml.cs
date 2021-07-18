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
    /// Logica di interazione per NuovoAssicurato.xaml
    /// </summary>
    public partial class NuovoAssicurato : Window
    {

        TeleperiziaDataContext db = new TeleperiziaDataContext();
        public NuovoAssicurato()
        {
            InitializeComponent();
            cmb_Assicurazione1Polizza.ItemsSource = db.Assicurazioni.Select(assicurazione => assicurazione.Denominazione);
            cmb_Categoria1Polizza.ItemsSource = db.Tipo_Polizze.Select(tipo => tipo.Tipo);
        }

        private void btn_InsertNewAssicurato_Click(object sender, RoutedEventArgs e)
        {
            Assicurati assicurato = new Assicurati();
            int ID_NuovoAssicurato = 0;
            if (db.Assicurati.Count() > 0)
                ID_NuovoAssicurato = db.Assicurati.Max(ass => ass.ID_Assicurato) + 1;
            
            assicurato.ID_Assicurato = ID_NuovoAssicurato;
            assicurato.Nome = txt_Nome1Assicurato.Text;
            assicurato.Cognome = txt_Cognome1Assicurato.Text;
            assicurato.Telefono = txt_Telefono1Assicurato.Text;
            assicurato.Email = txt_Email1Assicurato.Text;
            assicurato.DataNascita = data1Assicurato.SelectedDate.Value.Date;
            assicurato.CodiceFiscale = txt_CodiceFiscale1Assicurato.Text;

            Polizze polizza = new Polizze();
            polizza.Assicurato = ID_NuovoAssicurato;
            polizza.Assicurazione = cmb_Assicurazione1Polizza.SelectedItem.ToString();
            polizza.Tipo = cmb_Categoria1Polizza.SelectedItem.ToString();
            polizza.Costo = Convert.ToInt32(txt_Costo1Polizza.Text);
            polizza.Massimale = Convert.ToInt32(txt_Massimale1Polizza.Text);
            polizza.Scadenza = dateScadenza1Polizza.SelectedDate.Value.Date;

            try
            {
                
                db.Assicurati.InsertOnSubmit(assicurato);
                db.Polizze.InsertOnSubmit(polizza);
                db.SubmitChanges();
                MessageBox.Show("Assicurato inserito correttamente.");
                this.Close();
            }
            catch (Exception)
            {
                //throw;
                MessageBox.Show("Si è verificato un errore durante l'inserimento di un nuovo assicurato, controllare i dati inseriti e riprovare");
            }
            

        }
    }
}
