using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour {
  public GameController gameController;
  public string inkPath;
  public bool alreadyVisited = false;
  public bool canRepeatVisit = false;

  void OnTriggerEnter(Collider other) {
    if(other.tag == "Player")
      gameController.DiscoverIsland(this);
  }

  void OnTriggerExit(Collider other) {
    if(other.tag == "Player") 
      gameController.LeaveIsland();
  }
}
