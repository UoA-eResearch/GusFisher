using UnityEngine;
using UnityEngine.Windows.Speech;
using HoloToolkit.Unity;
using System.Collections;

public class DictationScript : MonoBehaviour
{
	private TextToSpeechManager tts;

	private DictationRecognizer m_DictationRecognizer;
	private string aliceUrl = "http://ml.cer.auckland.ac.nz/alice/";

	private IEnumerator AskAlice(string text)
	{
		string url = aliceUrl + WWW.EscapeURL(text).Replace("+", "%20");
		Debug.Log(url);
		var www = new WWW(url);
		yield return www;
		var result = www.text;
		Debug.Log(result);
		tts.SpeakText(result);
	}

	void Start()
	{
		m_DictationRecognizer = new DictationRecognizer();
		tts = gameObject.GetComponent<TextToSpeechManager>();

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
			m_DictationRecognizer.Start();
		};

		m_DictationRecognizer.DictationError += (error, hresult) =>
		{
			Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
		};

		m_DictationRecognizer.Start();
	}
}