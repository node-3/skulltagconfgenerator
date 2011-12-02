using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections;
using System.Reflection;
using System.Runtime.Serialization;
using SkulltagConfGenerator.Enumerations;
using SkulltagConfGenerator.Enumerations.Utils;
using SkulltagConfGenerator.Domain.Extensions;

namespace SkulltagConfGenerator.Domain.Model {

	[Serializable]
	public class SkulltagConfig : INotifyPropertyChanged, ISerializable {

		#region Events

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		#region Fields

		private Dictionary<Type, object> dictionaryTypes;

		#endregion

		#region Properties

		public Dictionary<DMFlags, bool> DMFlags { get; private set; }
		public Dictionary<DMFlags2, bool> DMFlags2 { get; private set; }
		public Dictionary<DMFlags3, bool> DMFlags3 { get; private set; }
		public Dictionary<CompatFlags, bool> CompatFlags { get; private set; }
		public Dictionary<CompatFlags2, bool> CompatFlags2 { get; private set; }
		public Dictionary<string, string> StringValues { get; private set; }

		#endregion

		public SkulltagConfig() {
			this.dictionaryTypes = new Dictionary<Type, object>();
			this.LoadTypes();
		}

		//private void ScanTypes() {
		//    Type thisType = this.GetType();
		//    foreach(PropertyInfo property in thisType.GetProperties()) {
		//        Type propertyType = property.GetType();
		//        Type firstGenericArgument = property.PropertyType.GetGenericArguments().FirstOrDefault();

		//        if(firstGenericArgument != null) {
		//            this.dictionaryTypes.AddOrSetValue(firstGenericArgument, property.GetValue(this, null));
		//        }
		//    }
		//}

		#region Populate Flags

		private void LoadTypes() {
			this.PopulateDMFlags();
			this.PopulateDMFlags2();
			this.PopulateDMFlags3();
			this.PopulateCompatFlags();
			this.PopulateCompatFlags2();
			this.LoadString();
		}

		private void LoadString() {
			this.StringValues = new Dictionary<string, string>();
			this.dictionaryTypes.AddOrSetValue(typeof(string), this.StringValues);
		}

		public void PopulateDMFlags() {
			this.DMFlags = new Dictionary<DMFlags, bool>();
			foreach(DMFlags dmflag in Enum.GetValues(typeof(DMFlags))) {
				this.DMFlags.Add(dmflag, false);
			}

			this.dictionaryTypes.AddOrSetValue(typeof(DMFlags), this.DMFlags);
		}

		public void PopulateDMFlags2() {
			this.DMFlags2 = new Dictionary<DMFlags2, bool>();
			foreach(DMFlags2 dmflag in Enum.GetValues(typeof(DMFlags2))) {
				this.DMFlags2.Add(dmflag, false);
			}

			this.dictionaryTypes.AddOrSetValue(typeof(DMFlags2), this.DMFlags2);
		}

		public void PopulateDMFlags3() {
			this.DMFlags3 = new Dictionary<DMFlags3, bool>();
			foreach(DMFlags3 dmflag in Enum.GetValues(typeof(DMFlags3))) {
				this.DMFlags3.Add(dmflag, false);
			}

			this.dictionaryTypes.AddOrSetValue(typeof(DMFlags3), this.DMFlags3);
		}

		public void PopulateCompatFlags() {
			this.CompatFlags = new Dictionary<CompatFlags, bool>();
			foreach(CompatFlags compatflag in Enum.GetValues(typeof(CompatFlags))) {
				this.CompatFlags.Add(compatflag, false);
			}

			this.dictionaryTypes.AddOrSetValue(typeof(CompatFlags), this.CompatFlags);
		}

		public void PopulateCompatFlags2() {
			this.CompatFlags2 = new Dictionary<CompatFlags2, bool>();
			foreach(CompatFlags2 compatflag in Enum.GetValues(typeof(CompatFlags2))) {
				this.CompatFlags2.Add(compatflag, false);
			}

			this.dictionaryTypes.AddOrSetValue(typeof(CompatFlags2), this.CompatFlags2);
		}
		#endregion

		public void SetValue<K, V>(K key, V value) {
			Dictionary<K, V> dictionary = this.dictionaryTypes[typeof(K)] as Dictionary<K, V>;

			dictionary.AddOrSetValue(key, value);
		}

		protected SkulltagConfig(SerializationInfo info, StreamingContext context) {

		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			throw new NotImplementedException();
		}
	}
}
