﻿using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections;
using System.Runtime.InteropServices;

public class DictationScript : MonoBehaviour
{
	[DllImport("WindowsVoice")]
	public static extern void initSpeech();
	[DllImport("WindowsVoice")]
	public static extern void destroySpeech();
	[DllImport("WindowsVoice")]
	public static extern void addToSpeechQueue(string s);

	public AudioSource audioSource;

	private static DictationRecognizer m_DictationRecognizer;
	private string aliceUrl = "http://ml.cer.auckland.ac.nz/alice/";

	private IEnumerator AskAlice(string text)
	{
		string url = aliceUrl + WWW.EscapeURL(text).Replace("+", "%20");
		Debug.Log(url);
		var www = new WWW(url);
		yield return www;
		var result = www.text;
		Debug.Log(result);
		addToSpeechQueue(result);
	}

	void Start()
	{
		initSpeech();
		m_DictationRecognizer = new DictationRecognizer();
		Debug.Log("Dictation engine ready");

		m_DictationRecognizer.DictationResult += (text, confidence) =>
		{
			Debug.LogFormat("Dictation result: {0}", text);
			StartCoroutine(AskAlice(text));
		};

		m_DictationRecognizer.DictationHypothesis += (text) =>
		{
			Debug.LogFormat("Dictation hypothesis: {0}", text);
		};

		m_DictationRecognizer.DictationComplete += (completionCause) =>
		{
			if (completionCause != DictationCompletionCause.Complete)
				Debug.LogErrorFormat("Dictation completed unsuccessfully: {0}.", completionCause);
		};

		m_DictationRecognizer.DictationError += (error, hresult) =>
		{
			Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
		};
		
	}

	public void OnButtonPush(GameObject go)
	{
		Debug.Log("player hit " + go.name);
		if (go.name == "spacebar")
		{
			m_DictationRecognizer.Start();
			audioSource.mute = true;
		} else if (go.name == "esc")
		{
			m_DictationRecognizer.Stop();
			audioSource.mute = false;
		}
	}

	private void OnDestroy()
	{
		destroySpeech();
		m_DictationRecognizer.Dispose();
	}
}