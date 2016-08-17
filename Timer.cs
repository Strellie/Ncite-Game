using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	private float startTime;
	private float endTime;
	private float currentTime;
	private bool isStart = true;
	private bool timerEnded = false;

	/**
		Sets:
		startTime = 0
		endTime = 0
		currentTime = 0
	 */
	public Timer(){
		startTime = 0;
		endTime = 0;
		currentTime = 0;
	}

	/**
		Counts down from input time to zero
	 */
	public Timer(float time){
		if(time > 0)
			CountDown(0,time);
	}
	/**
		Counts down or up based on first input value to second input value. 
	 */
	public Timer(float firstTime, float secondTime){
		if(firstTime < secondTime)
			CountUp(firstTime,secondTime);
		else if(firstTime > secondTime)
			CountDown(firstTime,secondTime);

	}

	/**
		Counts up from first input value to second input value.
		Returns: true when timer ends
	 */
	public bool CountUp(float startTime, float endTime){
		this.startTime = startTime;
		this.endTime = endTime;
		if(isStart){
			currentTime = this.startTime;
			isStart = false;
			timerEnded = false;
		}
		if(currentTime <= endTime){
			currentTime += Time.deltaTime;
		}else
			timerEnded = true;
		return timerEnded;
	}
	/**
		Counts up from zero to input value.
		Returns: true when timer ends
	 */
	public bool CountUp(float endTime){
		this.startTime = 0;
		this.endTime = endTime;
		if(isStart){
			currentTime = this.startTime;
			isStart = false;
			timerEnded = false;
		}
		if(currentTime <= endTime){
			currentTime += Time.deltaTime;
		}else
			timerEnded = true;
		return timerEnded;
	}
	/**
		Counts down from first input value to second input value.
		Returns: true when timer ends
	 */
	public bool CountDown(float startTime, float endTime){
		this.startTime = startTime;
		this.endTime = endTime;
		if(isStart){
			currentTime = this.startTime;
			isStart = false;
			timerEnded = false;
		}
		if(currentTime >= endTime){
			currentTime -= Time.deltaTime;
		}else
			timerEnded = true;
		return timerEnded;
	}
	/**
		Counts down from input value to zero.
		Returns: true when timer ends
	 */
	public bool CountDown(float startTime){
		this.startTime = startTime;
		this.endTime = 0;
		if(isStart){
			currentTime = this.startTime;
			isStart = false;
			timerEnded = false;
		}
		if(currentTime >= endTime){
			currentTime -= Time.deltaTime;
		}else
			timerEnded = true;
		return timerEnded;
	}
		
	/**
	 	Resets the timer
	 */
	public void ResetTimer(){
		isStart = true;
	}

	public void SetStartTime(float newStartTime){
		this.startTime = newStartTime;
	}
	public float GetStartTime(){
		return currentTime;
	}
	public void SetEndTime(float newEndTime){
		this.endTime = newEndTime;
	}
	public float GetEndTime(){
		return currentTime;
	}
	public void SetCurrentTime(float newCurrentTime){
		this.currentTime = newCurrentTime;
	}
	public float GetCurrentTime(){
		return currentTime;
	}

	/**
		Returns: ("Start Time" "End Time" "Current Time")
	 */
	public override string ToString (){
		return ("{Start Time: " + startTime + "} {End Time: " + endTime + "} {Current Time: " + currentTime + "}");
	}

	public bool equals(float input, float currentTime){
		if(input == currentTime)
			return true;
		else
			return false;
	}

}
