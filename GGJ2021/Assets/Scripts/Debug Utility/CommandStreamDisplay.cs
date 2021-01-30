using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* This is a pretty weak implementation for this. Ideally I'd like to use sprites
 * for the input. Would also be nice if we could colour the input a bit.
 * 
 * Also not sure about having to attach it to it's own input manager. Is it worth it?
 * Maybe we should adjust the Input Manager to be able to subscribe to the command stream
 * itself separate from the input frames?
 * 
 * A string does let us use the immediate mode GUI for the debug stuff at the moment. 
 * 
 */
public class CommandStreamDisplay : Actor, DebugListener
{
	public string playerExtension;
	public int menuYOffset;

	private Queue<Command> commandStream;
	private int commandQueueMax;
	private float screenSideBuffer = 5f;
	private float streamY;
	private float streamWidth;
	private bool debugEnabled;

	void Start()
	{
		debugEnabled = false;
		streamWidth = Screen.width - screenSideBuffer;
		streamY = Screen.height - menuYOffset;
		InputManager[] inputManagers = GameObject.Find("InputManager").GetComponents<InputManager>();
		for (int i = 0; i < inputManagers.Length; ++i)
		{
			if (inputManagers[i].PlayerInputExtension.Equals(playerExtension))
			{
				inputManagers[i].JoinInputFocus(this);
				commandQueueMax = inputManagers[i].GetCommandStreamEventMax();
			}
		}
		commandStream = new Queue<Command>();

		GameObject.Find("GameManager").GetComponent<DebugNotifier>().SubscribeToDebugNotifications(this);
	}
	void Update()
	{

	}

	void OnGUI()
	{
		if (!debugEnabled)
		{
			return;
		}
		if (commandStream != null && commandStream.Count != 0)
		{
			float rectWidth = (streamWidth - (2 * screenSideBuffer)) / commandQueueMax;
			//Just grab the images from each command and display them
			Command[] commands = commandStream.ToArray();
			for (int i = 0; i < commands.Length; ++i)
			{
				float wholeImageWidth = commands[i].GetImage().width;
				float xPos = screenSideBuffer + (i * (rectWidth));

				Rect screenPos = new Rect(xPos, streamY, rectWidth, commands[i].GetImage().height);
				GUI.Box(screenPos, commands[i].GetImage());
			}
		}
	}

	#region Actor implementation

	public override void OnCommandQueueUpdated(Queue<Command> commandQueue, int countThisFrame)
	{
		for (int i = commandQueue.Count - countThisFrame; i < commandQueue.Count; ++i)
		{
			Command command = commandQueue.ToArray()[i];
			if (command.GetImage() != null)
			{
				commandStream.Enqueue(command);
				if (commandStream.Count > commandQueueMax)
				{
					commandStream.Dequeue();
				}
			}
		}
	}

	#endregion

	#region DebugListener implementation

	public void OnDebugModeEnabled()
	{
		debugEnabled = true;
	}

	public void OnDebugModeDisabled()
	{
		debugEnabled = false;
	}

	#endregion
}
