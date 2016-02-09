using System.ServiceModel;
using NUnit.Framework;

namespace TrovServerExercise {
	public static partial class Global {
		[TestFixture] public class Tests {
			[Test] public void GetWrappingExceptionsForClient () {
				Assert.AreEqual(1, Global.GetWrappingExceptionsForClient(() => 1));
				Assert.Throws<FaultException<FaultDetail>>(() => Global.GetWrappingExceptionsForClient<int>(() => {throw new FaultException<FaultDetail>(new FaultDetail("Threw", false));}));
			}
			//todo test other exception wrapping code. (Or not. It was written back when I manually tested things, and it seems to work. And I'm short on time.)
		}
	}
}
