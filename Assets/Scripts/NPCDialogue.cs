using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewNPCDialogue", menuName ="NPC Dialogue")]

public class NPCDialogue : ScriptableObject
{

    public string npcName;
    public Sprite npcPortrait;
    public string[] dialogueLines;
    public bool[] autoProgressLines;
    public bool[] endDialogueLines;
    public float autoProgressDelay = 1.5f;
    public float typingSpeed = 0.05f;
    public AudioClip voiceSound;
    public float voicePitch = 1f;
    
    public DialogueChoice[] choices;

    public int questInProgressIndex; //What does he say while quest in progress
    public int questCompletedIndex; //What does he say when quest completed
    public Quest quest; //Quest NPC gives
}
[System.Serializable]

public class DialogueChoice
{
    public int dialogueIndex; //Dialogue line where choices appear
    public string[] choices; //Player response options
    public int[] nextDialogueIndexes; //Where choice leads
    public bool[] givesQuest; //Does this choice give the quest?
}