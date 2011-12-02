using System.Windows;
using SkulltagConfGenerator.ViewModel;

namespace SkulltagConfGenerator {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
			this.DataContext = ViewModelLocator.MainStatic;

			Closing += (s, e) => ViewModelLocator.Cleanup();
		}
	}
}
