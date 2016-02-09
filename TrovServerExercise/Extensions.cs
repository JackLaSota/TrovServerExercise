using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace TrovServerExercise {
	public static partial class Extensions {
		public static IEnumerable<FieldInfo> FieldsOfType<T> (this Type type, BindingFlags bindingAttr) {
			return type.GetFields(bindingAttr).Where(field => field.FieldType == typeof(T));
		}
		public static IEnumerable<FieldInfo> AllInstanceFieldsOfType <T> (this Type type) {
			return type.GetFields(bindingFlagsForAllInstanceFields).Where(field => field.FieldType == typeof(T));
		}
		///<summary>Shallow.</summary>
		///<remarks>Precondition: T is a type whose invariants won't be broken by bitwise duplication.</remarks>
		public static T BitwiseCloned <T> (this T original) where T: IAllowsBitwiseCloning {
			var clone = (T) Activator.CreateInstance(original.GetType());//Okay because uninitialized fields will be overwritten from a valid source.
			typeof(T).AllInstanceFields().Where(x => true)
				.ForEach(field => field.SetValue(clone, field.GetValue(original)));
			return clone;
		}
		const BindingFlags bindingFlagsForAllInstanceFields = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy;
		public static void ForEach <T> (this IEnumerable<T> enumerable, Action<T> action) {
			foreach (var t in enumerable) action(t);
		}
		///<summary>Shallow.</summary>
		public static T WithNormalizedStrings <T> (this T t) where T: IAllowsBitwiseCloning {
			var clone = t.BitwiseCloned();
			clone.NormalizeStrings();
			return clone;
		}
		///<summary>Shallow.</summary>
		public static void NormalizeStrings (this object o) {
			o.GetType().AllInstanceFieldsOfType<string>().ForEach(field => field.SetValue(o, ((string) field.GetValue(o)).NullHandlingNormalize()));
		}
		///<summary>Shallow.</summary>
		public static bool StringsAreNormalized (this object o) {
			return o.GetType().AllInstanceFieldsOfType<string>().All(field => {
				var actual = (string) field.GetValue(o);
				return actual == actual.NullHandlingNormalize();
			});
		}
		public static FieldInfo[] AllInstanceFields (this Type type) {return type.GetFields(bindingFlagsForAllInstanceFields);}
		public static bool FieldwiseSameAs ([CanBeNull] this object o, [CanBeNull] object other) {
			if (o == null || other == null) return o == other;
			var type = o.GetType();
			if (other.GetType() != type) return false;
			return type.AllInstanceFields().All(field => field.GetValue(o).NullHandlingEquals(field.GetValue(other)));
		}
		public static string NullHandlingNormalize ([CanBeNull] this string s) {return s == null ? null : s.Normalize();}
		public static bool NullHandlingEquals ([CanBeNull] this object o, [CanBeNull] object other) {
			if (o == null || other == null) return o == other;
			return o.Equals(other);
		}
	}
}
