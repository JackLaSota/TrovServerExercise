using System.Linq;
using NUnit.Framework;

namespace TrovServerExercise {
	public static partial class Extensions {
		[TestFixture] public class Tests {
			public class ExampleType : IAllowsBitwiseCloning {
#pragma warning disable 169
				public string stringField;
				public int intField;
#pragma warning restore 169
			}
			public class AnotherExampleType : IAllowsBitwiseCloning {
#pragma warning disable 169
				public string stringField;
				public int intField;
#pragma warning restore 169
			}
			[Datapoint] public IAllowsBitwiseCloning example = new ExampleType();
			[Test] public void AllInstanceFieldsOfTypeTest () {
				CollectionAssert.AreEquivalent(new[]{"stringField"}, typeof(ExampleType).AllInstanceFieldsOfType<string>().Select(field => field.Name));
				CollectionAssert.IsEmpty(typeof(ExampleType).AllInstanceFieldsOfType<char>().Select(field => field.Name));
			}
			[Test] public void ClonedByFieldsTest () {
				var original = new ExampleType {stringField = "a"};
				Assert.AreEqual(original.stringField, original.BitwiseCloned().stringField);
			}
			[Test] public void StringsNormalizedTest () {
				Assert.That(new ExampleType {stringField = ""}.StringsAreNormalized);
				Assert.That(new ExampleType {stringField = null}.StringsAreNormalized);
				Assert.That(!new ExampleType {stringField = ohmSymbol}.StringsAreNormalized());
			}
			const string ohmSymbol = "\u2126", capitalOmega = "\u03A9";//Canonically equivalent. See: http://unicode.org/reports/tr15/
			[Theory] public void WithNormalizedStringsTheory (IAllowsBitwiseCloning toClone) {
				Assume.That(toClone != null);
				// ReSharper disable once PossibleNullReferenceException
				var stringFields = toClone.GetType().AllInstanceFieldsOfType<string>();
				
				var toBecomeOhmClone = toClone.BitwiseCloned(); var toBecomeOmegaClone = toClone.BitwiseCloned();
				stringFields.ForEach(field => {
					field.SetValue(toBecomeOhmClone, ohmSymbol);
					field.SetValue(toBecomeOmegaClone, capitalOmega);
				});
				var ohmClone = toBecomeOhmClone; var omegaClone = toBecomeOmegaClone;
				Assert.That(ohmClone.WithNormalizedStrings().FieldwiseSameAs(omegaClone.WithNormalizedStrings()));
			}
			[Theory] public void ClonedHasEqualFieldsTheory (IAllowsBitwiseCloning toClone) {
				Assume.That(toClone != null);
				Assert.That(toClone.FieldwiseSameAs(toClone.BitwiseCloned()));
			}
			[Test] public void FieldwiseSameTest () {
				Assert.That(((object) null).FieldwiseSameAs(null));
				Assert.That(!new AnotherExampleType().FieldwiseSameAs(new ExampleType()));//If they don't have the same fields, then they aren't the same. Two fields aren't the same if they are declared in different types.
				Assert.That(new ExampleType().FieldwiseSameAs(new ExampleType()));
				Assert.That(!new ExampleType().FieldwiseSameAs(null));
				Assert.That(!((object) null).FieldwiseSameAs(new ExampleType()));
			}
		}
	}
}
