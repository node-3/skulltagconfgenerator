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
				IEnumerable<DMFlags> splitFlags = flag.GetIndividualValues<DMFlags>();
				IEnumerable<string> splitFlagsAlternateNames = splitFlags.Select(x => x.GetFirstAlternateName());

				IEnumerable<DMFlag> enabledFlags = this.flags.Where(dmflag => splitFlagsAlternateNames.Contains(dmflag.Name));

				foreach(DMFlag dmflag in this.flags) {
					dmflag.IsEnabled = false;
				}

				foreach(var item in enabledFlags) {
					item.IsEnabled = true;
				}

				this.RaisePropertyChanged("FlagsValue");
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
