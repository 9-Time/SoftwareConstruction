using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConnectionObject : NetworkBehaviour {
	//monoplayer handles start function and update function
	//networkbehaviour is monobehaviour + additional funtions




	// Use this for initialization
	void Start () {
		//Is this actually my own local PlayerObject
		if (isLocalPlayer == false) {
			return;
		}


		//Since the PlayerConnectionObject is invisible and not
		//part of the world, give me something physical to move around!
		Debug.Log("PlayerObject::Start -- Spawning unit");


		//instantiate() only creates an object on the local computer
		//even if it has a networkidentity is still will not exist
		//on the network(and therefore not on any other network) UNLESS
		//NetworkServer.Spawn() is called on this object
		//hence only NetworkServer.Spawn() will call on all servers!!!
		//only the server can run the function

		//Instantiate(PlayerunitPrefab);

		//Command (politely) the server to SPAWN our unit
		CmdSpawnMyUnit();
	}

	public GameObject PlayerunitPrefab;

	//SyncVars are variables where if their value changes on the SERVER, then all clients
	//are automatically informed of the new value
	[SyncVar(hook="OnPlayerNameChanged")]
	public string PlayerName = "Annoymous";



	// Update is called once per frame
	void Update () {
		//Rmb: Update runs on EVERYONE'S COMPUTER, whether or not they own 
		//this particular object


		if (isLocalPlayer == false) {
			return;		
		}

		/*
		if (Input.GetKeyDown (KeyCode.Space)) {
			//Spacebar was hit, we could instruct the server to do something with our unit.
			myPlayerUnit.transform.Translate (0, 1, 0); 
		}
		*/

		if (Input.GetKeyDown (KeyCode.S) ) {
			CmdSpawnMyUnit() ;
		}

		if (Input.GetKeyDown (KeyCode.Q)) {
			string n = "Qull" +Random.Range(1,100);
		
			Debug.Log ( "Sending the Server a request to change our name to: " + n);
			CmdChangePlayerName (n);

		}




	}



	void OnPlayerNameChanged(string newName)
	{
		Debug.Log ("OnPLayerNameChanged: OldName: "+PlayerName+" NewName: "+newName);

		//WARNING: If you use a hook on a SyncVar, then our local value does NOT automatically get updated
		PlayerName=newName; //therefore have to code this line

		gameObject.name="PlayerCOnnectionObject ["+newName+"]" ;


	}





	/////*********************************COMMANDS
	// Commands are special functions that ONLY get executed on the server




	[Command]
	void CmdSpawnMyUnit(){  //Note: all commands function have to start with Cmd
		//We are guaranteed to be on the server right now.

		//you can only call command on players that you have authority

		GameObject go = Instantiate(PlayerunitPrefab);

		//go.GetComponent<NetworkIdentity> ().AssignClientAuthority (connectionToClient);

		//Now that the object exist on the server, propagate it to all
		// the clients (and also wire up the NetworkIdentity)
		NetworkServer.SpawnWithClientAuthority(go,connectionToClient);
	}


	[Command]
	void CmdChangePlayerName(string n)
	{

		Debug.Log ("CmdChangePlayerName: "+n);
		PlayerName = n;  //change in POV of client


		//Maybe we should check that the name doesn't have any blacklisted words
		//If there is vulagrities, do we ignore request and do nothing? or do we still call the Rpc but with the original name?


		//Tell all the client what this player's name now is.
		//1) syncbar - more convenient
		//RpcChangePlayerName(PlayerName);

	}

	/////*********************************RPC
	///  RPCs are special functions that ONYL get executed on the clients.

	/*
	[ClientRpc]   //Have to use CLientRpc. [RPC] is the old network
	void RpcChangePlayerName(string n){  //have to start with RPC. IDK why though

		Debug.Log ("RpcChangePlayerName: we were asked to change the player name on a particular PlayerConnectionObject: "+n);
		PlayerName = n; //Change in POV of server. Totally OK

	}
	*/


}

	