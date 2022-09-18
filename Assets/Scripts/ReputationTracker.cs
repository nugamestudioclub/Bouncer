using UnityEngine;

public class ReputationTracker : MonoBehaviour {
	public int Rep { get; private set; }

	public void AdjustReputation(RepEffect repEffect) {
		Rep += CalcReputation(repEffect);
	}

	public bool IsReputationBad => Rep < -100;

	private static int CalcReputation(RepEffect repEffect) {
		return repEffect switch {
			RepEffect.MajorProblem => -20,
			RepEffect.MinorProblem => -5,
			RepEffect.MinorGood => 5,
			RepEffect.MajorGood => 20,
			_ => 0
		};
	}
}
