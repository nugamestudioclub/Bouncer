﻿using System;
using UnityEngine.Events;

public class TextMessage {
	public int SpeakerId { get; private set; }
	public string Text { get; private set; }

	public UnityAction OnReceive { get; private set; }

	public UnityAction OnEmotion { get; private set; }

	public TextMessage(
		int speakerId,
		string text,
		UnityAction onReceive = null,
		UnityAction onEmotion = null
	) {
		SpeakerId = speakerId;
		Text = text;
		OnReceive = onReceive;
		OnEmotion = onEmotion;
	}
}