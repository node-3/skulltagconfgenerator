using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace SkulltagConfGenerator.GUI.ViewModel {
	public abstract class FlagViewModel<T> : ViewModelBase {
		public abstract int FlagsValue { get; set; }
		public abstract IEnumerable<T> FlagModel { get; }
	}
}
