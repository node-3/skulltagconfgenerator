using System.Configuration;
using System.Reflection;
using SkulltagConfGenerator.Domain.Parse;
using GalaSoft.MvvmLight;

namespace SkulltagConfGenerator.ViewModel {
	public class ViewModelLocator {
		private static MainViewModel _main;

		
		public ViewModelLocator() {
			if(ViewModelBase.IsInDesignModeStatic) {
				// Create design time view models
			} else {
				// Create run time view models
				CreateMain();
			}
		}

		public static MainViewModel MainStatic {
			get {
				if(_main == null) {
					CreateMain();
				}

				return _main;
			}
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
			"CA1822:MarkMembersAsStatic",
			Justification = "This non-static member is needed for data binding purposes.")]
		public MainViewModel Main {
			get {
				return MainStatic;
			}
		}
		
		public static void ClearMain() {
			_main.Cleanup();
			_main = null;
		}
		
		public static void CreateMain() {
			if(_main == null) {
				string assemblyName = ConfigurationManager.AppSettings["EnumerationsDll"];
				string namespaceName = ConfigurationManager.AppSettings["EnumerationsNamespace"];

				_main = new MainViewModel(
					new SkulltagConfigParser(
						new SkulltagConfigParserMetaData(
							Assembly.Load(assemblyName), 
							namespaceName
						)
					)
				);
			}
		}

		public static void Cleanup() {
			ClearMain();
		}
	}
}