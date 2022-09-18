public class TextMessage {
	public int SpeakerId { get; private set; }
	public string Text { get; private set; }

	public TextMessage(int speakerId, string text) {
		SpeakerId = speakerId;
		Text = text;
	}
}