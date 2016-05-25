using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void ConsoleFunction (string[] command);

public class Console : Singleton<Console>
{
	class CommandEntry
	{
		public string command = "";
		public string timeTag = "";
	}

	List<CommandEntry> entries;
	Dictionary<string,ConsoleFunction> functions;
	Vector2 currentScrollPos = new Vector2 ();
	string inputField = "";
	bool consoleInFocus = false;
	string inputFieldFocus = "CIFT";
	int previousCommandIndex = 0;

	void Awake ()
	{
		entries = new List<CommandEntry> ();
		functions = new Dictionary<string,ConsoleFunction> ();
		unfocusConsole ();
	}
	
	//draw the chat box in size relative to your GUIlayout
	void OnGUI ()
	{
		if (consoleInFocus) {
			GUI.Box (new Rect (5f, 5f, Screen.width * 0.3f + 8, Screen.width * 0.25f + 8), "");
			GUILayout.BeginArea (new Rect (5f, 5f, Screen.width * 0.3f + 5, Screen.width * 0.25f + 5));
			CommandWindow (Screen.width * 0.3f);
			GUILayout.EndArea ();
		} else {
			checkForInput ();
		}
	}

	void CommandWindow (float width)
	{
		
		GUILayout.BeginVertical ();
		currentScrollPos = GUILayout.BeginScrollView (currentScrollPos, GUILayout.MaxWidth (width), GUILayout.MinWidth (width)); //limits the chat window size to max 1000x1000, remove the restraints if you want
		
		foreach (CommandEntry ent in entries) {
			GUILayout.BeginHorizontal ();
			GUI.skin.label.wordWrap = true;
			GUILayout.Label (ent.timeTag + "> " + ent.command);
			GUILayout.EndHorizontal ();
			GUILayout.Space (3);
		}
		
		GUILayout.EndScrollView ();
//			bool send = false;

		if (Event.current.type == EventType.KeyDown) {
			if (Event.current.character == '`') {
				unfocusConsole ();
				return;
			} else if (Event.current.keyCode == KeyCode.UpArrow) {
			
				if (entries.Count < 1)
					return;
				previousCommandIndex -= 1;
				if (previousCommandIndex < 0)
					previousCommandIndex = 0;
				inputField = entries [previousCommandIndex].command;
			} else if (Event.current.keyCode == KeyCode.DownArrow) {
				if (entries.Count < 1)
					return;
				previousCommandIndex += 1;
				if (previousCommandIndex > entries.Count - 1)
					previousCommandIndex = entries.Count - 1;
				inputField = entries [previousCommandIndex].command;
			}
		}
		GUILayout.BeginHorizontal ();
		GUI.SetNextControlName (inputFieldFocus);
		inputField = GUILayout.TextField (inputField, GUILayout.MaxWidth (width), GUILayout.MinWidth (width));
//			send = GUILayout.Button ("Send");
		GUI.FocusControl (inputFieldFocus);
		GUILayout.EndHorizontal ();
		
		GUILayout.EndVertical ();

		HandleNewEntries ();
	}

	void unfocusConsole ()
	{
		//Debug.Log("unfocusing chat");
		inputField = "";
		consoleInFocus = false;
	}

	void checkForInput ()
	{
		if (Event.current.type == EventType.KeyDown && Event.current.character == '`') {
			GUI.FocusControl (inputFieldFocus);
			consoleInFocus = true;
			currentScrollPos.y = float.PositiveInfinity;
		}
	}

	void HandleNewEntries ()
	{
		if (Event.current.type == EventType.KeyDown && Event.current.character == '\n') {
			if (inputField.Length <= 0) {
				unfocusConsole ();
				Debug.Log ("unfocusing chat (empty entry)");
				return;
			}
			executeCommand (inputField);
			inputField = "";
			previousCommandIndex = entries.Count;
//			if (Network.isServer) {
//				AddChatEntry (playerName, inputField); //for offline testing
//				networkView.RPC ("AddChatEntry", RPCMode.Others, playerName, inputField);
//			} else
//				networkView.RPC ("AddChatEntry", RPCMode.All, playerName, inputField);
//			unfocusConsole ();
			//Debug.Log("unfocusing chat and entry sent");
		}
	}

	public static void addConsoleFunction (string name, ConsoleFunction function)
	{
		Instance.functions [name] = function;
	}


	//	[RPC]
	//	void AddChatEntry (string name, string msg)
	//	{
	//		ChatEntry newEntry = new ChatEntry ();
	//		newEntry.name = name;
	//		newEntry.message = msg;
	//		newEntry.timeTag = "[" + System.DateTime.Now.Hour.ToString () + ":" + System.DateTime.Now.Minute.ToString () + "]";
	//		entries.Add (newEntry);
	//		currentScrollPos.y = float.PositiveInfinity;
	//	}

	void executeCommand (string msg)
	{
		CommandEntry newEntry = new CommandEntry ();
		newEntry.command = msg;
		newEntry.timeTag = "[" + System.DateTime.Now.Hour.ToString () + ":" + System.DateTime.Now.Minute.ToString () + "]";
		entries.Add (newEntry);
		currentScrollPos.y = float.PositiveInfinity;

		// Execute command
		string[] command = msg.Split (' ');
		string[] sub = new string[command.Length - 1];
		for (int i = 1; i < command.Length; i++) {
			sub [i - 1] = command [i];
		}
		if (functions.ContainsKey (command [0])) {
			functions [command [0]] (sub);
		}
	}
}