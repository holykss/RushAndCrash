using UnityEngine;
using System.Collections;

public class Minion : MonoBehaviour {

	public AnimationClip idle;
	public AnimationClip walk;
	public AnimationClip attack;
	public AnimationClip damaged;
	public AnimationClip dead;

	public Animation animationBody;

	// Use this for initialization
	void Start () {
		animationBody.clip = damaged;
		animationBody.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
