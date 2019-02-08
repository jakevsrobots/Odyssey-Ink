using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
  public TextAsset inkJson;
  public Button visitIslandButton;
  public GameObject textPanel;
  public Text text;
  public ShipMovement shipMovement;
  public Island currentIsland;

  public Button[] buttons;
  public Text[] labels;
  public Button endStoryButton;

  public Text crewDisplay;
  public Text goldDisplay;

  Story story;

  void Start() {
    // Load the story
    story = new Story(inkJson.text);

    // Initialize / hide UI elements.
    text.text = "";

    for(int i=0; i<buttons.Length; i++)
      buttons[i].gameObject.SetActive(false);

    textPanel.SetActive(false);
    visitIslandButton.gameObject.SetActive(false);
    endStoryButton.gameObject.SetActive(false);

    crewDisplay.text = "Crew: " + story.variablesState["crew"];
    goldDisplay.text = "Gold: " + story.variablesState["gold"];
  }

  // Called from Island.cs when we enter the trigger area for an island.
  public void DiscoverIsland(Island island) {
    if(!island.alreadyVisited || island.canRepeatVisit) {
      currentIsland = island;
      visitIslandButton.gameObject.SetActive(true);
    }
  }

  // Called from Island.cs when we leave the trigger area for an island.
  public void LeaveIsland() {
    currentIsland = null;
    visitIslandButton.gameObject.SetActive(false);
  }

  // Called by a button to start a story fragment from the current island.
  public void VisitCurrentIsland() {
    shipMovement.enabled = false;
    visitIslandButton.gameObject.SetActive(false);
    textPanel.SetActive(true);

    // Islands have an "inkPath" property which we set in the inspector in
    // order to use ink knots as story fragments
    story.ChoosePathString(currentIsland.inkPath);
    currentIsland.alreadyVisited = true;

    UpdateStory();
  }

  void UpdateStats() {
    crewDisplay.text = "Crew: " + story.variablesState["crew"];
    goldDisplay.text = "Gold: " + story.variablesState["gold"];
  }

  void UpdateStory() {
    text.text = "";

    // Hide buttons
    for(int i=0; i<buttons.Length; i++)
      buttons[i].gameObject.SetActive(false);

    // Keep printing until there's nothing left to show.
    while(story.canContinue) {
      string nextLine = story.Continue();

      // Any line can change stats, so update every time we've called story.Continue() 
      UpdateStats(); 

      text.text += nextLine + "\n";
    }

    if(story.currentChoices.Count > 0) {
      // Show options.
      for(int i=0; i < story.currentChoices.Count; i++) {
        labels[i].text = story.currentChoices[i].text;
        buttons[i].gameObject.SetActive(true);
      }
    } else {
      // No choices to display here, so the story is over. 
      endStoryButton.gameObject.SetActive(true); 
    }
  }

  // Called from ui buttons 
  public void OnChoice(int index) {
    story.ChooseChoiceIndex(index);
    UpdateStory();
  }

  // Called from the End Story ui button
  public void CloseStory() {
    text.text = "";

    for(int i=0; i<buttons.Length; i++)
      buttons[i].gameObject.SetActive(false);

    shipMovement.enabled = true;
    textPanel.SetActive(false);
    endStoryButton.gameObject.SetActive(false);
    LeaveIsland();

    // See the example Ink script. We use a tag to indicate when the
    // game has reached an ending.
    
    if(story.currentTags.Contains("ENDING")) {
      SceneManager.LoadScene("TheEnd");
    }
  }
}
