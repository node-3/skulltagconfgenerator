using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkulltagConfGenerator.Domain.Extensions {
	public static class IntExtensions {
		public static bool IsPowerOfTwo(this int value) {
			return (value & (value - 1)) == 0;
		}
	}
}
