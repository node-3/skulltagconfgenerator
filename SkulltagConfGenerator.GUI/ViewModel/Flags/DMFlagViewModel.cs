using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using SkulltagConfGenerator.GUI.Model;
using SkulltagConfGenerator.Enumerations;
using SkulltagConfGenerator.Enumerations.Utils;
using SkulltagConfGenerator.Domain.Extensions;

namespace SkulltagConfGenerator.GUI.ViewModel.Flags {
	public class DMFlagViewModel : FlagViewModel<DMFlag> {
		#region Fields

		private IEnumerable<DMFlag> flags;

		#endregion

		#region Properties

		public override int FlagsValue {
			get {
				int flag = 0;

				foreach(DMFlag dmflag in this.FlagModel.Where(x => x.IsEnabled)) {
					flag += dmflag.Value;
				}

				return flag;
			}

			set {
				DMFlags flag = (DMFlags)value;

				IEnumerable<DMFlags> flags = flag.GetIndividualValues<DMFlags>();
				//var mergedFlags = this.flags.Join(flags, flagValue => flagValue.Value, dmflags => (int)dmflags, (flagValue, dmflags) => new { });
				var selectedFlags = flags.Join(this.flags, flagName => flagName.GetFirstAlternateName(), x => x.Name, (flagName, x) => new { SelectedFlagName = flagName, FlagName = x });
				foreach(var item in this.flags) {
					item.IsEnabled = true;
				}
			}
		}

		public override IEnumerable<DMFlag> FlagModel {
			get {
				return this.flags;
			}
		}

		#endregion

		#region Commands

		#endregion

		public DMFlagViewModel() {
			List<DMFlag> flags = new List<DMFlag>();

			foreach(DMFlags item in Enum.GetValues(typeof(DMFlags))) {
				DMFlag flag = new DMFlag(item);
				flag.PropertyChanged += new PropertyChangedEventHandler(flag_PropertyChanged);
				flags.Add(flag);
			}

			this.flags = flags;
		}

		public void flag_PropertyChanged(object sender, PropertyChangedEventArgs e) {
			this.RaisePropertyChanged("FlagsValue");
		}
	}
}
