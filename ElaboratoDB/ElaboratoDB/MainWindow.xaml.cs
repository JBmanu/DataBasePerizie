using System;
using System.Collections.Generic;
using System.Data.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Linq.Mapping;

namespace ElaboratoDB { 

    public partial class MainWindow : Window
    {

        TeleperiziaDataContext db = new TeleperiziaDataContext();
        List<myQuery> list = new List<myQuery>();

        struct myQuery
        {
            public string name { get; set; }
            public string description { get; set; }
            public Action action { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
            InitializeDictionary();

        }

        public void InitializeDictionary()
        {

            myQuery query8 = new myQuery();
            query8.name = "Visualizza tutti i supervisori";
            query8.description = "Visualizza tutti i supervisori registrati, quindi coloro che potranno smistare gli incarichi.";
            query8.action = Execute_Query_Supervisori;
            list.Add(query8);

            myQuery query1 = new myQuery();
            query1.name = "Visualizza tutti i periti";
            query1.description = "Visualizza tutti i periti in ordine alfabetico";
            query1.action = Execute_Query_Periti;
            list.Add(query1);

            myQuery query2 = new myQuery();
            query2.name = "Visualizza tutti gli assicurati";
            query2.description = "Visualizza tutti gli assicurati in ordine alfabetico";
            query2.action = Execute_Query_Assicurati;
            list.Add(query2);

            myQuery query3 = new myQuery();
            query3.name = "Visualizza tutti gli studi";
            query3.description = "Visualizza tutti gli studi esistenti";
            query3.action = Execute_Query_Studi;
            list.Add(query3);

            myQuery query4 = new myQuery();
            query4.name = "Visualizza tutti i sinistri";
            query4.description = "Visualizza tutti i sinistri inseriti nel sistema";
            query4.action = Execute_Query_Sinistri;
            list.Add(query4);

            myQuery query5 = new myQuery();
            query5.name = "Visualizza tutti gli incarichi";
            query5.description = "Visualizza tutti gli incarichi creati dal sistema";
            query5.action = Execute_Query_Incarichi;
            list.Add(query5);

            myQuery query6 = new myQuery();
            query6.name = "Visualizza tutte le polizze";
            query6.description = "Visualizza tutte le polizze stipulare da tutte le assicurazioni";
            query6.action = Execute_Query_Polizze;
            list.Add(query6);

            myQuery query7 = new myQuery();
            query7.name = "Visualizza tutte le assicurazioni";
            query7.description = "Visualizza tutte le assicurazioni aderenti al software";
            query7.action = Execute_Query_Assicurazioni;
            list.Add(query7);

            myQuery query9 = new myQuery();
            query9.name = "Visualizza tutte le Video Perizie effettuate";
            query9.description = "Visualizza tutte le Video Perizie effettuate ed inserite nel sistema";
            query9.action = Execute_Query_Video_Perizie;
            list.Add(query9);

            myQuery query10 = new myQuery();
            query10.name = "Visualizza tutti i media";
            query10.description = "Visualizza tutti i media inseriti nel sistema specificando a quale Video Perizia fanno capo";
            query10.action = Execute_Query_Media;
            list.Add(query10);

            myQuery query11 = new myQuery();
            query11.name = "Visualizza tutti i tipi di polizza";
            query11.description = "Visualizza tutti i tipi di polizza che un assicurato può stipulare.";
            query11.action = Execute_Query_Tipo_Polizza;
            list.Add(query11);

            myQuery query12 = new myQuery();
            query12.name = "Visualizza tutte le categoria di sinistri";
            query12.description = "Visualizza tutte le categorie di sinistri che possono essere generati.";
            query12.action = Execute_Query_Categoria_Sinistro;
            list.Add(query12);

            myQuery query13 = new myQuery();
            query13.name = "Visualizza tutti i documenti";
            query13.description = "Visualizza tutti i documenti inseriti nel software con i riferimenti all'incarico e sinistro.";
            query13.action = Execute_Query_Documenti;
            list.Add(query13);








            List<string> keys = new List<string>();
            list.ForEach(elem => keys.Add(elem.name));
            listViewQuery.ItemsSource = keys;
        }
       

        private void ExecuteQueryAction(object sender, RoutedEventArgs e)
        {
            int index = listViewQuery.SelectedIndex;
            if (index >= 0)
            {
                Action a = list.ElementAt(index).action;
                a.Invoke();
            }
            else
            {
                MessageBox.Show("Seleziona una query da eseguire");
            }     
        }

        private void showResults(System.Linq.IQueryable queryResult, string queryDefinition, string querySQL, int removeLastColumns)
        {
            dataGrid.Visibility = Visibility.Visible;
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = queryResult;        
            for (int i=0; i< removeLastColumns; i++)
            {
                if (dataGrid.Columns.Count - 1 >= 0)
                {
                    dataGrid.Columns.RemoveAt(dataGrid.Columns.Count - 1);
                }
            }
            dataGrid.Columns[0].Width = 0;
        }

        private void Execute_Query_Supervisori()
        {
            var query = from supervisore in db.Supervisori
                        select supervisore;

            var queryDefinition = list.FirstOrDefault(elem => elem.action == Execute_Query_Supervisori).name;
            showResults(query, queryDefinition, query.ToString(), 1);
        }

        private void Execute_Query_Periti()
        {
            var query = from perito in db.Periti
                        select perito;

            var queryDefinition = list.FirstOrDefault(elem => elem.action == Execute_Query_Periti).name;  
            showResults(query, queryDefinition, query.ToString(), 2);
        }

        private void Execute_Query_Assicurati()
        {
            var query = from assicurato in db.Assicurati
                        select assicurato;

            var queryDefinition = list.FirstOrDefault(elem => elem.action == Execute_Query_Assicurati).name;
            showResults(query, queryDefinition, query.ToString(), 2);
        }

        private void Execute_Query_Studi()
        {
            var query = from studio in db.Studi_Peritali
                        select studio;

            var queryDefinition = list.FirstOrDefault(elem => elem.action == Execute_Query_Studi).name;
            showResults(query, queryDefinition, query.ToString(), 2);
        }

        private void Execute_Query_Sinistri()
        {
            var query = from sinistro in db.Sinistri
                        select sinistro;

            var queryDefinition = list.FirstOrDefault(elem => elem.action == Execute_Query_Sinistri).name;
            showResults(query, queryDefinition, query.ToString(), 4);
        }

        private void Execute_Query_Incarichi()
        {
            var query = from incarico in db.Incarichi
                        select incarico;

            var queryDefinition = list.FirstOrDefault(elem => elem.action == Execute_Query_Incarichi).name;
            showResults(query, queryDefinition, query.ToString(), 1);
        }

        private void Execute_Query_Polizze()
        {
            var query = from polizza in db.Polizze
                        select polizza;

            var queryDefinition = list.FirstOrDefault(elem => elem.action == Execute_Query_Polizze).name;
            showResults(query, queryDefinition, query.ToString(), 3);
        }

        private void Execute_Query_Assicurazioni()
        {
            var query = from assicurazione in db.Assicurazioni
                        select assicurazione;

            var queryDefinition = list.FirstOrDefault(elem => elem.action == Execute_Query_Assicurazioni).name;
            showResults(query, queryDefinition, query.ToString(), 2);
        }

        
        private void Execute_Query_Video_Perizie()
        {
            var query = from videoperizia in db.Video_Perizie
                        select videoperizia;

            var queryDefinition = list.FirstOrDefault(elem => elem.action == Execute_Query_Video_Perizie).name;
            showResults(query, queryDefinition, query.ToString(), 2);
        }

        private void Execute_Query_Media()
        {
            var query = from media in db.Media
                        select media;

            var queryDefinition = list.FirstOrDefault(elem => elem.action == Execute_Query_Media).name;
            showResults(query, queryDefinition, query.ToString(), 1);
        }

        private void Execute_Query_Tipo_Polizza()
        {
            var query = from tipo_polizza in db.Tipo_Polizze
                        select tipo_polizza;

            var queryDefinition = list.FirstOrDefault(elem => elem.action == Execute_Query_Tipo_Polizza).name;
            showResults(query, queryDefinition, query.ToString(), 1);
        }

        private void Execute_Query_Categoria_Sinistro()
        {
            var query = from categoria in db.Categoria_Sinistri
                        select categoria;

            var queryDefinition = list.FirstOrDefault(elem => elem.action == Execute_Query_Categoria_Sinistro).name;
            showResults(query, queryDefinition, query.ToString(), 1);
        }

        private void Execute_Query_Documenti()
        {
            var query = from documento
                        in db.Documenti
                        select documento;

            var queryDefinition = list.FirstOrDefault(elem => elem.action == Execute_Query_Documenti).name;
            showResults(query, queryDefinition, query.ToString(), 1);
        }


        private void listViewQuery_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            if (listViewQuery.SelectedIndex >= 0)
            {
                txtLanguage.Text = list.ElementAt(listViewQuery.SelectedIndex).description;
                dataGrid.ItemsSource = null;
            }
            
        }

        //Qua iniziano le azioni relative all'inserimento e eliminazione di entità.



        private void InsertInDbAction(object sender, RoutedEventArgs e)
        {
            listViewQuery.ItemsSource = null;
            list.Clear();
        }

        private void DeleteInDbAction(object sender, RoutedEventArgs e)
        {

        }


        private void btn_InsertNewPerito_Click(object sender, RoutedEventArgs e)
        {
        
            if (radioSupervisore.IsChecked == true)
            {
                Supervisori supervisore = new Supervisori();
                supervisore.ID_Supervisore = db.Supervisori.Count() + 1;
                supervisore.Nome = txt_NomePerito.Text;
                supervisore.Cognome = txt_CognomePerito.Text;
                supervisore.CodiceFiscale = txt_CodiceFiscalePerito.Text;
                supervisore.Telefono = txt_TelefonoPerito.Text;
                supervisore.Email = txt_EmailPerito.Text;
                supervisore.StudioPeritale = Convert.ToInt32(cmb_StudioPerito.SelectedItem);
                try
                {
                    db.Supervisori.InsertOnSubmit(supervisore);
                    db.SubmitChanges();
                    MessageBox.Show("Supervisore inserito correttamente.");
                }
                catch (Exception)
                {
                    MessageBox.Show("Errore nella creazione del supervisore, riprovare.");
                }
            }
            if (radioPerito.IsChecked == true)
            {
                Periti perito = new Periti();
                perito.ID_Perito = db.Periti.Count() + 1;
                perito.Nome = txt_NomePerito.Text;
                perito.Cognome = txt_CognomePerito.Text;
                perito.CodiceFiscale = txt_CodiceFiscalePerito.Text;
                perito.Telefono = txt_TelefonoPerito.Text;
                perito.Email = txt_EmailPerito.Text;
                perito.StudioPeritale = Convert.ToInt32(cmb_StudioPerito.SelectedItem);
                //su da elim.
                try
                {
                    db.Periti.InsertOnSubmit(perito);
                    db.SubmitChanges();
                    MessageBox.Show("Perito inserito correttamente.");
                }
                catch (Exception)
                {
                    MessageBox.Show("Errore nella creazione del perito, riprovare.");
                }
                
            }

        }


        private void btn_InsertNewAssicurazione_Click(object sender, RoutedEventArgs e)
        {
            Assicurazioni assicurazione = new Assicurazioni();
            assicurazione.Denominazione = txt_NomeAssicurazione.Text;
            assicurazione.Email = txt_EmailAssicurazione.Text;
            assicurazione.NumeroVerde = txt_NumVerdeAssicurazione.Text;
            assicurazione.Telefono = txt_TelefonoAssicurazione.Text;

            try
            {
                db.Assicurazioni.InsertOnSubmit(assicurazione);
                db.SubmitChanges();
                dataGridInsert.ItemsSource = null;
                dataGridInsert.ItemsSource = db.Assicurazioni;
                for (int i = 0; i < 2; i++)
                {
                    if (dataGridInsert.Columns.Count - 1 >= 0)
                        dataGridInsert.Columns.RemoveAt(dataGridInsert.Columns.Count - 1);
                }
                MessageBox.Show("Assicurazione inserita correttamente.");
            }
            catch (Exception)
            {
                MessageBox.Show("Errore nell'inserimento di un nuovo assicurato.");
            }
            
        }

        private void btn_DeleteAssicurato_Click(object sender, RoutedEventArgs e)
        {
            int ID_Assicurato = Int32.Parse(txt_IDAssicurato.Text);
            try
            {
                db.Assicurati.DeleteOnSubmit(db.Assicurati.First(assicurato => assicurato.ID_Assicurato == ID_Assicurato));
                db.SubmitChanges();
                MessageBox.Show("Assicurato eliminato correttamente.");
            }
            catch (Exception)
            {
                MessageBox.Show("Si è verificato un problema nell'eliminazione dell'assicurato, controllare i dati inseriti e riprovare.");
            }
        }

        private void btn_DeletePerito_Click(object sender, RoutedEventArgs e)
        {
            int ID_Perito = Int32.Parse(txt_IDPerito.Text);
            try
            {
                db.Periti.DeleteOnSubmit(db.Periti.First(perito => perito.ID_Perito == ID_Perito));
                db.SubmitChanges();
                MessageBox.Show("Perito eliminato correttamente.");
            }
            catch (Exception)
            {
                MessageBox.Show("Si è verificato un problema nell'eliminazione del perito, controllare i dati inseriti e riprovare.");
            }

        }

        private void btn_DeleteSupervisore_Click(object sender, RoutedEventArgs e)
        {
            int ID_Supervisore = Int32.Parse(txt_IDSupervisore.Text);
            try
            {
                db.Supervisori.DeleteOnSubmit(db.Supervisori.First(supervisore => supervisore.ID_Supervisore == ID_Supervisore));
                db.SubmitChanges();
                MessageBox.Show("Supervisore eliminato correttamente.");
            }
            catch (Exception)
            {
                MessageBox.Show("Si è verificato un problema nell'eliminazione del supervisore, controllare i dati inseriti e riprovare.");
            }
        }

        private void btn_DeleteStudio_Click(object sender, RoutedEventArgs e)
        {
            int ID_Studio = Int32.Parse(txt_IDStudio.Text);
            try
            {
                db.Studi_Peritali.DeleteOnSubmit(db.Studi_Peritali.First(studio => studio.ID_Studio == ID_Studio));
                db.SubmitChanges();
                MessageBox.Show("Studio eliminato correttamente.");
            }
            catch (Exception)
            {
                MessageBox.Show("Si è verificato un problema nell'eliminazione dello studio, controllare i dati inseriti e riprovare.");
                //throw;
            }

        }

        private void btn_DeleteAssicurazione_Click(object sender, RoutedEventArgs e)
        {
            string Denominazione = txt_DenominazioneAssicurazione.Text;
            try
            {
                db.Assicurazioni.DeleteOnSubmit(db.Assicurazioni.First(assicurazione => assicurazione.Denominazione == Denominazione));
                db.SubmitChanges();
                MessageBox.Show("Assicurazione eliminata correttamente.");
            }
            catch (Exception)
            {
                MessageBox.Show("Si è verificato un problema nell'eliminazione dell'assicurazione, controllare i dati inseriti e riprovare.");
                
            }

        }

        private void btn_DeleteSinistro_Click(object sender, RoutedEventArgs e)
        {
            int ID_Sinistro = Int32.Parse(txt_IDSinistro.Text);
            try
            {
                db.Sinistri.DeleteOnSubmit(db.Sinistri.First(sinistro => sinistro.ID_Sinistro == ID_Sinistro));
                db.SubmitChanges();

                db.Incarichi.First(inc => inc.ID_Sinistro == ID_Sinistro).ID_Sinistro = null;

                MessageBox.Show("Sinistro eliminato correttamente.");
            }
            catch (Exception)
            {
                MessageBox.Show("Si è verificato un problema nell'eliminazione del sinistro, controllare i dati inseriti e riprovare.");
                //throw;
            }
        }

        private void btn_DeleteIncarico_Click(object sender, RoutedEventArgs e)
        {
            int ID_Incarico = Int32.Parse(txt_NumeroIncarico.Text);

            try
            {
                db.Incarichi.DeleteOnSubmit(db.Incarichi.First(incarico => incarico.ID_Incarico == ID_Incarico));
                db.SubmitChanges();
                MessageBox.Show("Incarico eliminato correttamente.");
            }
            catch (Exception)
            {
                MessageBox.Show("Si è verificato un problema nell'eliminazione dell'incarico, controllare i dati inseriti e riprovare.");
                //throw;
            }

        }
        private void cmb_Delete_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmb_Delete.SelectedIndex)
            {
                case 0://"Assicurato"
                    DeleteAssicuratoCanvas.Visibility = Visibility.Visible;
                    DeleteSupervisoreCanvas.Visibility = Visibility.Hidden;
                    DeletePeritoCanvas.Visibility = Visibility.Hidden;
                    DeleteStudioCanvas.Visibility = Visibility.Hidden;
                    DeleteAssicurazioneCanvas.Visibility = Visibility.Hidden;
                    DeleteIncaricoCanvas.Visibility = Visibility.Hidden;
                    DeleteSinistroCanvas.Visibility = Visibility.Hidden;
                    break;
                case 1://"Perito"
                    DeletePeritoCanvas.Visibility = Visibility.Visible;
                    DeleteSupervisoreCanvas.Visibility = Visibility.Hidden;
                    DeleteStudioCanvas.Visibility = Visibility.Hidden;
                    DeleteAssicurazioneCanvas.Visibility = Visibility.Hidden;
                    DeleteAssicuratoCanvas.Visibility = Visibility.Hidden;
                    DeleteIncaricoCanvas.Visibility = Visibility.Hidden;
                    DeleteSinistroCanvas.Visibility = Visibility.Hidden;
                    break;

                case 2://"Supervisore"
                    DeletePeritoCanvas.Visibility = Visibility.Hidden;
                    DeleteSupervisoreCanvas.Visibility = Visibility.Visible;
                    DeleteStudioCanvas.Visibility = Visibility.Hidden;
                    DeleteAssicurazioneCanvas.Visibility = Visibility.Hidden;
                    DeleteAssicuratoCanvas.Visibility = Visibility.Hidden;
                    DeleteIncaricoCanvas.Visibility = Visibility.Hidden;
                    DeleteSinistroCanvas.Visibility = Visibility.Hidden;
                    break;
                case 3://"Studio"
                    DeleteStudioCanvas.Visibility = Visibility.Visible;
                    DeleteSupervisoreCanvas.Visibility = Visibility.Hidden;
                    DeletePeritoCanvas.Visibility = Visibility.Hidden;
                    DeleteAssicurazioneCanvas.Visibility = Visibility.Hidden;
                    DeleteAssicuratoCanvas.Visibility = Visibility.Hidden;
                    DeleteIncaricoCanvas.Visibility = Visibility.Hidden;
                    DeleteSinistroCanvas.Visibility = Visibility.Hidden;
                    break;
                case 4://"Assicurazione"
                    DeleteAssicurazioneCanvas.Visibility = Visibility.Visible;
                    DeleteSupervisoreCanvas.Visibility = Visibility.Hidden;
                    DeletePeritoCanvas.Visibility = Visibility.Hidden;
                    DeleteStudioCanvas.Visibility = Visibility.Hidden;
                    DeleteAssicuratoCanvas.Visibility = Visibility.Hidden;
                    DeleteIncaricoCanvas.Visibility = Visibility.Hidden;
                    DeleteSinistroCanvas.Visibility = Visibility.Hidden;
                    break;
                case 6://"Sinistro"
                    DeleteIncaricoCanvas.Visibility = Visibility.Visible;
                    DeleteSupervisoreCanvas.Visibility = Visibility.Hidden;
                    DeletePeritoCanvas.Visibility = Visibility.Hidden;
                    DeleteStudioCanvas.Visibility = Visibility.Hidden;
                    DeleteAssicuratoCanvas.Visibility = Visibility.Hidden;
                    DeleteAssicurazioneCanvas.Visibility = Visibility.Hidden;
                    DeleteSinistroCanvas.Visibility = Visibility.Hidden;
                    break;
                case 5://"Incarico"
                    DeleteSinistroCanvas.Visibility = Visibility.Visible;
                    DeleteSupervisoreCanvas.Visibility = Visibility.Hidden;
                    DeletePeritoCanvas.Visibility = Visibility.Hidden;
                    DeleteStudioCanvas.Visibility = Visibility.Hidden;
                    DeleteAssicuratoCanvas.Visibility = Visibility.Hidden;
                    DeleteIncaricoCanvas.Visibility = Visibility.Hidden;
                    DeleteAssicurazioneCanvas.Visibility = Visibility.Hidden;
                    break;

            }
        }

        
        private void tabControl_SelectionChanged(object  sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("Input DELLA SELEZIONE TAB CONTROL" + control.SelectedIndex);
            switch (control.SelectedIndex)
            {
                case 0://VISUALIZZA    
                    break;
                case 1://INSERISCI
                    break;
                case 2://ELIMINA
                    break;
                case 3://POLIZZE
                    cmb_Assicurazione.ItemsSource = db.Assicurazioni.Select(assicurazione => assicurazione.Denominazione);
                    cmb_Categoria.ItemsSource = db.Tipo_Polizze.Select(tipo => tipo.Tipo);

                    break;
                case 4://SINISTRO
                    GetInformazioniSinistri();
                    cmb_SinistroDaIncaricare.ItemsSource = db.Studi_Peritali.Select(studio => studio.ID_Studio);

                    break;
                case 5://INCARICHI

                    cmb_StudioDaCercareIncarichi.ItemsSource = db.Studi_Peritali.Select(studio => studio.ID_Studio);
                    InitializeIncarichi();
                    break;
            }
        }


        private void cmb_Insert_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            switch (cmb_Insert.SelectedIndex)
            {
                case 0://Dipendente
                    PeritoCanvas.Visibility = Visibility.Visible;
                    AssicurazioneCanvas.Visibility = Visibility.Hidden;
                    dataGridInsert.ItemsSource = db.Periti;
                    cmb_StudioPerito.ItemsSource = db.Studi_Peritali.Select(studio => studio.ID_Studio);
                    break;
                case 1://Assicurrazione
                    PeritoCanvas.Visibility = Visibility.Hidden;
                    AssicurazioneCanvas.Visibility = Visibility.Visible;
                    dataGridInsert.ItemsSource = db.Assicurazioni;
                    break;
            }

            for (int i = 0; i < 2; i++)
            {
                if (dataGridInsert.Columns.Count - 1 >= 0)
                    dataGridInsert.Columns.RemoveAt(dataGridInsert.Columns.Count - 1);
            }
            dataGridInsert.Columns[0].Width = 0;
        }

        private void btn_Nuova_Categoria_Polizza_Click(object sender, RoutedEventArgs e)
        {
            string Tipo = txt_TipoNuovaCategoria.Text;
            string Descrizione = txt_DescrizioneNuovaCategoria.Text;

            Tipo_Polizze tipo_polizza = new Tipo_Polizze();
            tipo_polizza.Descrizione = Descrizione;
            tipo_polizza.Tipo = Tipo;


            try
            {
                db.Tipo_Polizze.InsertOnSubmit(tipo_polizza);
                db.SubmitChanges();

                cmb_Categoria.ItemsSource = db.Tipo_Polizze.Select(tipo_pol => tipo_pol.Tipo);
                MessageBox.Show("Categoria inserita correttamente.");

            }
            catch (Exception)
            {
                MessageBox.Show("Si è verificato un problema nella creazione della categoria polizza, controllare i dati inseriti e riprovare.");
                //throw;
            }
            
        }

        private void btn_Visualizza_Polizza_Click(object sender, RoutedEventArgs e)
        {
            int ID_Assicurato = Int32.Parse(txt_NumeroAssicurato.Text);
            var query = from polizza in db.Polizze
                        where polizza.Assicurato == ID_Assicurato
                        select polizza;

            dataGridPolizze.ItemsSource = query;
            for (int i = 0; i < 4; i++)
            {
                if (dataGridPolizze.Columns.Count - 1 >= 0)              
                    dataGridPolizze.Columns.RemoveAt(dataGridPolizze.Columns.Count - 1);
            }
        }

        private void btn_Nuova_Polizza_Click(object sender, RoutedEventArgs e)
        {
            Polizze polizza = new Polizze();

            polizza.Numero = db.Polizze.Count(p => p.Assicurazione == cmb_Assicurazione.Text && p.Assicurato == Int32.Parse(txt_NumeroAssicuratoNuovaPolizza.Text)) + 1;

            polizza.Assicurato = Int32.Parse(txt_NumeroAssicuratoNuovaPolizza.Text);
            polizza.Assicurazione = cmb_Assicurazione.Text;
            polizza.Tipo = cmb_Categoria.Text;
            polizza.Costo = Int32.Parse(txt_CostoPolizza.Text);
            polizza.Scadenza = dateScadenza.SelectedDate.Value.Date;
            polizza.Massimale = Int32.Parse(txt_MassimalePolizza.Text);

            try
            {
                db.Polizze.InsertOnSubmit(polizza);
                db.SubmitChanges();
                MessageBox.Show("Polizza creata correttamente.");

            }
            catch (Exception)
            {
                MessageBox.Show("Si è verificato un problema nella creazione della polizza, controllare i dati inseriti e riprovare.");
                //throw;
            }
        }


        private void GetInformazioniSinistri()
        {

            dataGridSinistriDelegati.ItemsSource = null;
            dataGridSinistriDelegati.ItemsSource = db.Sinistri;
            for (int i = 0; i < 5; i++)
            {
                if (dataGridSinistriDelegati.Columns.Count - 1 >= 0)
                    dataGridSinistriDelegati.Columns.RemoveAt(dataGridSinistriDelegati.Columns.Count - 1);
            }

            var queryVideoperizia = from videoperizia in db.Video_Perizie
                                    select videoperizia.Durata;
            lbl_TempoVideoPeriziaMedio.Content = "0";
            if (db.Video_Perizie.Count() > 0)
            {
                double durataMedia = queryVideoperizia.Average();
                lbl_TempoVideoPeriziaMedio.Content = Math.Round(durataMedia, 2).ToString() + " sec.";
            }

        }

        private void btn_NuovoSinistro_Click(object sender, RoutedEventArgs e)
        {
            NuovoSinistro sinistro = new NuovoSinistro();
            sinistro.Show();
        }

        private void btn_CercaIncarico_Click(object sender, RoutedEventArgs e)
        {
            int ID_Studio = Int32.Parse(cmb_StudioDaCercareIncarichi.SelectedItem.ToString());
            var queryPeriti = from perito in db.Periti
                              where perito.StudioPeritale == ID_Studio
                              select perito.ID_Perito;


            var queryIncarichi = from incarico in db.Incarichi
                                 where queryPeriti.Contains(incarico.Perito)
                                 select incarico;

            dataGridIncarichi.ItemsSource = queryIncarichi;
            for (int i = 0; i < 4; i++)
            {
                if (dataGridIncarichi.Columns.Count - 1 >= 0)
                    dataGridIncarichi.Columns.RemoveAt(dataGridIncarichi.Columns.Count - 1);
            }

        }

        private void InitializeIncarichi()
        {
            cmb_SupervisoreIncarico.ItemsSource = db.Supervisori.Select(supervisore => supervisore.ID_Supervisore);
        }

        private void btn_GeneraIncarico_Click(object sender, RoutedEventArgs e)
        {
            Incarichi incarico = new Incarichi();
            incarico.ID_Incarico = 0;
            if(db.Incarichi.Count() > 0)
                incarico.ID_Incarico = (db.Incarichi.Max(i => i.ID_Incarico)) + 1;
            incarico.Stato = "Aperto";
            incarico.Supervisore = Convert.ToInt32(cmb_SupervisoreIncarico.SelectedItem);     
            incarico.Perito = Convert.ToInt32(cmb_PeritoIncarico.SelectedItem);
            incarico.ID_Sinistro = Convert.ToInt32(cmb_SinistroIncarico.SelectedItem);

            try
            {
                db.Incarichi.InsertOnSubmit(incarico);
                db.SubmitChanges();
                MessageBox.Show("Incarico generato correttamente.");
            }
            catch (Exception)
            {
                MessageBox.Show("Si è verificato un errore nella creazione dell'incarico, controllare i dati e riprovare.");
            }
            
        }

        private void cmb_SupervisoreIncarico_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Supervisori supervisore = db.Supervisori.First(supervisor => supervisor.ID_Supervisore == Convert.ToInt32(cmb_SupervisoreIncarico.SelectedItem));
            cmb_PeritoIncarico.ItemsSource = db.Periti.Where(perito => perito.StudioPeritale == supervisore.StudioPeritale).Select(perito => perito.ID_Perito);
            
        }

        private void cmb_PeritoIncarico_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Supervisori supervisore = db.Supervisori.First(supervisor => supervisor.ID_Supervisore == Convert.ToInt32(cmb_SupervisoreIncarico.SelectedItem));
            cmb_SinistroIncarico.ItemsSource = db.Sinistri.Where(sinistro => sinistro.StudioPeritale == supervisore.StudioPeritale).Select(sinistro => sinistro.ID_Sinistro);

        }

        private void btn_DelegaSinistro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Sinistri updateSinistro = db.Sinistri.Single(sinistro => sinistro.ID_Sinistro == Convert.ToInt32(txt_IdSinistroDaIncaricare.Text));

                updateSinistro.StudioPeritale = null;
                Console.WriteLine(Convert.ToInt32(cmb_SinistroDaIncaricare.SelectedItem));
                db.SubmitChanges();
                updateSinistro.StudioPeritale = Int32.Parse(cmb_SinistroDaIncaricare.SelectedValue.ToString());
                db.SubmitChanges();

                MessageBox.Show("Sinitro delegato.");
            }
            catch (Exception)
            {
                
                MessageBox.Show("Errore nella delegazione del sinistro, controllare i dati inseriti e riprovare. Il sinistro " + txt_IdSinistroDaIncaricare.Text + " potrebbe essere già stato assegnato ad uno studio.");
            }
            
        }

        private void btn_NuovoStudio_Click(object sender, RoutedEventArgs e)
        {
            NuovoStudio nuovoStudio = new NuovoStudio();
            nuovoStudio.Show();
        }

        private void btn_NuovoAssicurato_Click(object sender, RoutedEventArgs e)
        {
            NuovoAssicurato nuovoAssicurato = new NuovoAssicurato();
            nuovoAssicurato.Show();
        }

        private void NewVideoperizia_Click(object sender, RoutedEventArgs e)
        {
            Video_Perizie videoperizia = new Video_Perizie();
            int ID_Incarico = Convert.ToInt32(txt_IncaricoVideoperizia.Text);
            videoperizia.ID_Incarico = ID_Incarico;
            videoperizia.NumeroPerizia = db.Video_Perizie.Count(v => v.ID_Incarico == ID_Incarico) + 1;
            videoperizia.Durata = float.Parse(txt_DurataVideoperizia.Text);
            videoperizia.Data = dateVideoperizia.SelectedDate.Value.Date;

            try
            {
                db.Video_Perizie.InsertOnSubmit(videoperizia);
                db.SubmitChanges();
                MessageBox.Show("Videoperizia inserita con successo.");
            }
            catch (Exception)
            {
                MessageBox.Show("Errore nel caricamento della videoperizia, controlla i dati e riprova.");
            }
            
        }

        private void NewMedia_Click(object sender, RoutedEventArgs e)
        {
            Media media = new Media();

            media.Incarico = Convert.ToInt32(txt_IncaricoMedia.Text);
            media.NumeroPerizia = Convert.ToInt32(txt_NumeroVideoperiziaMedia.Text);
            media.NumeroMedia = db.Media.Count(m => m.Incarico == Convert.ToInt32(txt_IncaricoMedia.Text) && m.NumeroPerizia == Convert.ToInt32(txt_NumeroVideoperiziaMedia.Text)) + 1;

            if (radio_Foto.IsChecked == true)
            {
                media.Tipo = "Foto";
            }
            if (radio_Video.IsChecked == true)
            {
                media.Tipo = "Video";
            }
            media.Nome = txt_NomeMedia.Text;
            media.Estensione = txt_EstensioneMedia.Text;
            media.Metadati = txt_MetadatiMedia.Text;
            media.Dimensione = float.Parse(txt_DimensioneMedia.Text);
            media.Directory = txt_DirectoryMedia.Text;

            try
            {
                db.Media.InsertOnSubmit(media);
                db.SubmitChanges();
                MessageBox.Show("Media inserito con successo.");
            }
            catch (Exception)
            {
                MessageBox.Show("Errore nel caricamento del media, controlla i dati e riprova.");
            }
        }

        private void btn_NewDocumento_Click(object sender, RoutedEventArgs e)
        {
            Documenti documento = new Documenti();
            int ID_Documento = 0;

            if (db.Documenti.Count() > 0)
                ID_Documento = db.Documenti.Max(d => d.ID_Documento) + 1;

            documento.ID_Documento = ID_Documento;
            documento.Incarico = Convert.ToInt32(txt_DocumentoIncarico.Text);
            documento.ID_Assicurato = Convert.ToInt32(txt_DocumentoAssicurato.Text);
            documento.Tipo = txt_TipoDocumento.Text;
            documento.Nome = txt_NomeDocumento.Text;
            documento.Estensione = txt_EstensioneDocumento.Text;
            documento.Dimensione = float.Parse(txt_DimensioneDocumento.Text);
            documento.Directory = txt_DirectoryDocumento.Text;

            try
            {
                db.Documenti.InsertOnSubmit(documento);
                db.SubmitChanges();
                MessageBox.Show("Documento inserito con successo.");

            }
            catch (Exception)
            {
                MessageBox.Show("Errore nell'inserimento del documento, controllare i dati inseriti e riprovare");
            }
            
        }
    }
    
}
