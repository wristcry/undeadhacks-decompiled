using System;

namespace UndeadHacks
{
	// Token: 0x02000057 RID: 87
	public static class MathUtilities
	{
		// Token: 0x0600014E RID: 334 RVA: 0x0000ECD0 File Offset: 0x0000CED0
		public static T RandomEnumValue<T>()
		{
			Array values = Enum.GetValues(typeof(T));
			return (T)((object)values.GetValue(new Random().Next(values.Length)));
		}
	}
}
