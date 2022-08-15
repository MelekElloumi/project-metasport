using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

namespace Photon.Pun.Demo.PunBasics
{
    public class ConnectedPlayers : MonoBehaviourPunCallbacks
    {
        //for each player, create a box in the connected players panel
        //listen for players connection and disconnection and update list.
        //TODO: add private chat button, make display on click
        public GameObject playercounter;
        public GameObject dropdownobj;
        TMP_Dropdown playerlist;
        TextMeshProUGUI tmpcounter;
        private void Start() {
            tmpcounter = playercounter.GetComponent<TextMeshProUGUI>();
            playerlist = dropdownobj.GetComponent<TMP_Dropdown>();
            playerlist.ClearOptions();           
        }
    
        public void displayPlayers() {
            foreach (Player player in PhotonNetwork.PlayerList) 
            { 
                playerlist.options.Add(new TMP_Dropdown.OptionData(player.NickName));
            }
            
            updateplayercount(Mathf.Max(1, playerlist.options.Count));
            
        }

        void updateplayercount(int count)
        {
            tmpcounter.text = "Players online: " + count.ToString();
        }
   
       
        public override void OnPlayerEnteredRoom( Player other  )
		    {
                addPlayer(other.NickName, playerlist.options.Count);
            }
        public override void OnPlayerLeftRoom( Player other  )
		    {
                removePlayer(other.NickName, playerlist.options.Count);
		    }

        void addPlayer(string name, int newcount)
        {
            playerlist.options.Add(new TMP_Dropdown.OptionData(name));
            updateplayercount(newcount);

        }
        void removePlayer(string name, int newcount)
        {
            TMP_Dropdown.OptionData toremove =null;
            foreach (TMP_Dropdown.OptionData option in playerlist.options)
            {
                if (option.text == name)
                {
                    toremove = option;
                    break;
                }
            }
            playerlist.options.Remove(toremove);
            updateplayercount(newcount);

        }
    }

}