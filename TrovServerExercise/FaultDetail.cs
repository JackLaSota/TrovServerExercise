using System.Runtime.Serialization;

namespace TrovServerExercise {
	[DataContract] public class FaultDetail {
		[DataMember] public string ComplaintToClient {get; set;}
		[DataMember] public bool ShouldBeLayUserVisible {get; set;}
		public FaultDetail () : this("Unknown error occured.", false) {}
		public FaultDetail (string complaintToClient, bool shouldBeLayUserVisible) {
			ComplaintToClient = complaintToClient;
			ShouldBeLayUserVisible = shouldBeLayUserVisible;
		}
	}
}
