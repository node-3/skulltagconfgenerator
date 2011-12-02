using System.IO;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using SkulltagConfGenerator.Domain.Model;
using SkulltagConfGenerator.Domain.Parse;

namespace SkulltagConfGenerator.ViewModel {
	/// <summary>
	/// This class contains properties that the main View can data bind to.
	/// <para>
	/// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
	/// </para>
	/// <para>
	/// You can also use Blend to data bind with the tool's support.
	/// </para>
	/// <para>
	/// See http://www.galasoft.ch/mvvm/getstarted
	/// </para>
	/// </summary>
	public class MainViewModel : ViewModelBase {

		#region Fields

		private IParser<SkulltagConfig, TextReader> parser;
		private SkulltagConfig config;

		#endregion

		#region Commands

		public RelayCommand<MainViewModel> OpenFile {
			get {
				return new RelayCommand<MainViewModel>(p => this.OpenFileCommand());
			}
		}

		public RelayCommand<MainViewModel> SaveFile {
			get {
				return new RelayCommand<MainViewModel>(p => this.SaveFileCommand());
			}
		}

		#endregion

		#region Properties

		public SkulltagConfig Config {
			get {
				return this.config;
			}

			set {
				this.config = value;
				this.RaisePropertyChanged("Config");
			}
		}

		#endregion

		public MainViewModel(IParser<SkulltagConfig, TextReader> parser) {
		}

		public void OpenFileCommand() {
			OpenFileDialog dlg = new OpenFileDialog() {
				AddExtension = true,
				Filter = "",
				Multiselect = false,

			};

			bool? result = dlg.ShowDialog();

			if(result.Value) {
				
			}
		}

		public void SaveFileCommand() {

		}
	}
}