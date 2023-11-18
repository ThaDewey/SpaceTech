using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Example_StringEvent : MonoBehaviour
{

	[SerializeField] private StringEventChannelSO _channel = default;
	public StringEvent OnEventRaised;


	private void OnEnable() {
		if (_channel != null)
			_channel.OnEventRaised += Respond;
	}

	private void OnDisable() {
		if (_channel != null)
			_channel.OnEventRaised -= Respond;
	}

	private void Respond(string value) {
		if (OnEventRaised != null) OnEventRaised.Invoke(value);
	}

	public void Test(string s) {
		Debug.Log(s);
	}




}