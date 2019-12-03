using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Comandos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Etiqueta> Etiquetas { get; set; }
        private Etiqueta EtiquetaPortapapeles { get; set; }
        public Etiqueta EtiquetaSeleccionada { get; set; }
        public HoraActual Hora { get; set; }

        public MainWindow()
        {
            Etiquetas = new ObservableCollection<Etiqueta>();
            InitializeComponent();
            Hora = new HoraActual();
            ListBox.DataContext = Etiquetas;
            EtiquetaSeleccionada = null;
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Etiquetas.Add(new Etiqueta($"Item añadido a las {Hora.Hora}"));
        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Etiquetas.Count < 10;
        }

        private void CopyCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            EtiquetaPortapapeles = (Etiqueta) ListBox.SelectedItem;
        }

        private void CopyCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = EtiquetaSeleccionada != null;
        }

        private void PasteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Etiquetas.Add(new Etiqueta(EtiquetaPortapapeles.Contenido));
            EtiquetaPortapapeles = null;
        }

        private void PasteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = EtiquetaPortapapeles != null && Etiquetas.Count < 10;
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void ClearCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Etiquetas.Clear();
        }

        private void ClearCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Etiquetas.Count > 0;
        }
    }
}
