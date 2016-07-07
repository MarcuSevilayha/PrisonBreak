using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour
{

	public Text text, inventory;
	private enum States {begin, belong,
						cell, cell_return,
						chest_0, chest_1, chest_leg, chest_shard, chest_leg_shard, chest_sharp_leg, chest_open, chest_opened, chest_done,
						mirror_0, mirror_1, mirror_me, mirror_done,
						chair_0, chair_1, chair_done,
						gate_0, gate_1, gate_inspect, gate_open_cut,
						window_0, window_1};

	private enum Items {empty, small_key, chair_leg, sharp_chair_leg, mirror_shard, cut_hand};
	private States myState;
	private Items self_Hand, inv_smallKey, inv_chairLeg, inv_mirrorShard;
	private bool smallKey, chairLeg, sharpChairLeg, mirrorShard, cutHand;

	// Use this for initialization
	void Start ()
	{
		myState = States.begin;
		inv_smallKey = Items.empty;
		inv_chairLeg = Items.empty;
		inv_mirrorShard = Items.empty;
		self_Hand = Items.empty;

		smallKey = false;
		chairLeg = false;
		sharpChairLeg = false;
		mirrorShard = false;
		cutHand = false;
	}

	// Update is called once per frame
	void Update ()
	{
		print ("myState: " + myState);
		print ("Chest key: " + inv_smallKey);
		print ("Chair leg: " + inv_chairLeg);
		print ("Mirror Piece: " + inv_mirrorShard);

		if (Input.GetKeyDown (KeyCode.Escape)) {myState = States.begin;}

		if (inv_chairLeg == Items.chair_leg) {
			chairLeg = true;
		} else if (inv_chairLeg == Items.sharp_chair_leg) {
			sharpChairLeg = true;
		}
		if (inv_mirrorShard == Items.mirror_shard) {
			mirrorShard = true;
		}
		if (self_Hand == Items.cut_hand) {
			cutHand = true;
		}
		if (inv_smallKey == Items.small_key) {
			smallKey = true;
		}

		if (myState == States.begin) {
			begin ();
		} else if (myState == States.cell) {
			cell ();
		} else if (myState == States.cell_return) {
			cell_return ();
		}

		if (myState == States.belong) {
			belongings ();
		}

		if (myState == States.chest_0) {
			chest ();
		} else if (myState == States.chest_1) {
			chest_1 ();
		} else if (myState == States.chest_leg) {
			chest_leg ();
		} else if (myState == States.chest_shard) {
			chest_shard ();
		} else if (myState == States.chest_leg_shard) {
			chest_leg_shard ();
		} else if (myState == States.chest_sharp_leg) {
			chest_sharp_leg ();
		} else if (myState == States.chest_open) {
			chest_open ();
		} else if (myState == States.chest_opened) {
			chest_opened ();
		} else if (myState == States.chest_done) {
			chest_done ();
		}

		if (myState == States.mirror_0) {
			mirror_0 ();
		} else if (myState == States.mirror_1) {
			mirror_1 ();
		} else if (myState == States.mirror_me) {
			mirror_me ();
		} else if (myState == States.mirror_done) {
			mirror_done ();
		}

		if (myState == States.chair_0) {
			chair_0 ();
		} else if (myState == States.chair_1) {
			chair_1 ();
		} else if (myState == States.chair_done) {
			chair_done ();
		}

		if (myState == States.window_0) {
			window ();
		} else if (myState == States.window_1) {
			window ();
		}

		if (myState == States.gate_0) {
			gate_0 ();
		} else if (myState == States.gate_1) {
			gate_1 ();
		} else if (myState == States.gate_inspect) {
			gate_inspect ();
		} else if (myState == States.gate_open_cut) {
			gate_open_cut ();
		}
	}

	void begin ()
	{
		text.text = "You have awaken on a cold concrete floor. You groggily push yourself into a sitting position, feeling patches of grass growing from the lifeless concrete around you. " +
			"Confused, you stand up and notice your entire right leg slightly throbbing.\n " +
			"\n" +
			"Dismissing whatever affliction your leg has contracted for the moment, " +
			"you turn your attention to the tiny room where you have apparently stayed the night. Directly in front of you is a rusty gate, the lock and handle towards the end of the wall. " +
			"You walk over to the gate and try to slide it open; it won't budge.\n" +
			"\n" +
			"You must find a way out of here!\n" +
			"\n" +
			"Press Enter to continue.";

		if (Input.GetKeyDown (KeyCode.Return)) {
			myState = States.cell;
		}
	}

	void cell ()
	{
		text.text = "You scan your surroundings, the only illumination coming from the small window in the wall opposite the Cell gate, which is unfortunately barred and several feet higher than you. " +
		"The cell itself does not look inviting. There are multitudes of cracks and scratch marks on the walls, spider webs are strung carelessly about, and dried blood in all corners of the room; " +
		"the feel of decay and dilapidation is all around you...\n" +
		"\n" +
		"You notice a cracked Mirror propped against what must be the northern wall, a small Chest in the southwest corner of the room, and a wooden Chair " +
		"next to the Chest. Considering your only light is the sunlight, you must find a light source or a way out before dark.\n" +
		"\n" +
		"What will you do?\n" +
		"\n" +
		"Press I to check your Belongings.\n" +
		"\n" +
		"Press C to check the Chest, " +
		"Press M to view the Mirror, " +
		"Press S to inspect the Chair, " +
		"Press W to look at the Window, " +
		"Press G to examine the Gate.";

		//Belongings
		if (Input.GetKeyDown (KeyCode.I)) {
			myState = States.belong;
		}

		//Chest
		if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.chest_0;
		}

		//Mirror
		if (Input.GetKeyDown (KeyCode.M)) {
			myState = States.mirror_0;
		}

		//Chair
		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.chair_0;
		}

		//Window
		if (Input.GetKeyDown (KeyCode.W)) {
			myState = States.window_0;
		}

		//Gate
		if (Input.GetKeyDown (KeyCode.G)) {
			myState = States.gate_0;
		}
	}

	void cell_return ()
	{
		inventory.text = " ";

		text.text = "You continue your search of the cell. What will you do?\n" +
		"\n" +
		"Press I to check your Belongings.\n" +
		"\n" +
		"Press C to check the Chest.\n" +
		"Press M to view the Mirror.\n" +
		"Press S to inspect the Chair.\n" +
		"Press W to look at the Window.\n" +
		"Press G to examine the Gate.\n";

		//Belongings
		if (Input.GetKeyDown (KeyCode.I)) {
			myState = States.belong;
		}

		//Chest
		if (Input.GetKeyDown (KeyCode.C)) {
			if (inv_smallKey == Items.small_key) {
				myState = States.chest_done;
			} else {
				myState = States.chest_0;
			}
		}

		//Mirror
		if (Input.GetKeyDown (KeyCode.M)) {
			if (inv_mirrorShard == Items.mirror_shard) {
				myState = States.mirror_done;
			} else {
				myState = States.mirror_0;
			}
		}

		//Chair
		if (Input.GetKeyDown (KeyCode.S)) {
			if (inv_chairLeg == Items.chair_leg) {
				myState = States.chair_done;
			} else {
				myState = States.chair_0;
			}
		}

		//Window
		if (Input.GetKeyDown (KeyCode.W)) {
			myState = States.window_1;
		}

		//Gate
		if (Input.GetKeyDown (KeyCode.G)) {
			if (inv_smallKey == Items.small_key) {
				myState = States.gate_1;
			} else {
				myState = States.gate_0;
			}
		}
	}

	//****************************************** INVENTORY *************************************************//

	void belongings ()
	{
		if (!chairLeg && !sharpChairLeg && !mirrorShard && !smallKey) {
			text.text = "You've only got the clothes on your back.\n" +
			"\n" +
			"Press R to roam the Cell.\n";

			if (Input.GetKeyDown (KeyCode.R)) {
				myState = States.cell_return;
			}
		} else {
			text.text = "Press R to go back\n" +
			"\n" +
			"Here's the stuff that you've got:\n";

			if (chairLeg == true && mirrorShard == true && smallKey == true) {
				inventory.text = "Wooden Chair Leg\n" +
				"Mirror Shard\n" +
				"Small Key\n";
			} else if (chairLeg == true && mirrorShard == true && smallKey == false) {
				inventory.text = "Wooden Chair Leg\n" +
				"Mirror Shard\n";
			} else if (chairLeg == true && mirrorShard == false && smallKey == true) {
				inventory.text = "Wooden Chair Leg\n" +
				"Small Key\n";
			} else if (chairLeg == true && mirrorShard == false && smallKey == false) {
				inventory.text = "Wooden Chair Leg\n";
			} else if (chairLeg == false && mirrorShard == true && smallKey == false) {
				inventory.text = "Mirror Shard\n";
			} else if (chairLeg == false && mirrorShard == false && smallKey == false) {
				inventory.text = "Small Key\n";
			} else if (sharpChairLeg == true && mirrorShard == true && smallKey == true) {
				inventory.text = "Sharpened Chair Leg\n" +
				"Mirror Shard\n" +
				"Small Key\n";
			} else if (sharpChairLeg == true && mirrorShard == true && smallKey == false) {
				inventory.text = "Sharpened Chair Leg\n" +
				"Mirror Shard\n";
			} else if (sharpChairLeg == true && mirrorShard == false && smallKey == true) {
				inventory.text = "Sharpened Chair Leg\n" +
				"Small Key\n";
			} else if (sharpChairLeg == true && mirrorShard == false && smallKey == false) {
				inventory.text = "Sharpened Chair Leg\n";
			} else if (sharpChairLeg == false && mirrorShard == true && smallKey == false) {
				inventory.text = "Mirror Shard\n";
			} else if (sharpChairLeg == false && mirrorShard == false && smallKey == false) {
				inventory.text = "Small Key\n";
			}

			if (Input.GetKeyDown (KeyCode.R)) {
				myState = States.cell_return;
			}
		}
	}

	//****************************************** CHEST *************************************************//

	void chest ()
	{
		text.text = "Looking closely at the chest, you notice it is slightly ajar.\n" +
		"\n" +
		"Press O to open the Chest.\n" +
		"Press R to roam the Cell.\n";

		if (Input.GetKeyDown (KeyCode.O)) {
			if (chairLeg && !mirrorShard) {
				myState = States.chest_leg;
			} else if (!chairLeg && mirrorShard) {
				myState = States.chest_shard;
			} else if (chairLeg && mirrorShard) {
				myState = States.chest_leg_shard;
			} else if (sharpChairLeg) {
				myState = States.chest_open;
			} else {
				myState = States.chest_1;
			}

		} else if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	void chest_1 ()
	{
		text.text = "The chest seems to be stuck in place and won't give way. You'll need something strong to pry it open.\n" +
		"\n" +
		"Press R to roam the Cell.\n";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	void chest_leg ()
	{
		text.text = "The wooden chair leg does not fit in the opening of the chest.\n" +
		"\n" +
		"Press R to roam the Cell.\n";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	void chest_shard ()
	{
		text.text = "You'd break the glass if you tried using it to open the chest!\n" +
		"\n" +
		"Press R to roam the Cell.\n";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	void chest_leg_shard ()
	{
		text.text = "The wooden chair leg does not fit in the opening of the chest.\n" +
		"\n" +
		"Press S to sharpen the chair leg with the shard of glass.\n" +
		"Press R to roam the Cell.\n";

		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.chest_sharp_leg;
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	void chest_sharp_leg ()
	{
		inv_chairLeg = Items.sharp_chair_leg;

		text.text = "After some careful sharpening, you've flattened one end of the leg.\n" +
			"\n" +
			"Press O to use the sharpened leg to pry open the chest.\n" +
			"Press R to roam the Cell.\n";

		if (Input.GetKeyDown (KeyCode.O)) {
			myState = States.chest_open;
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	void chest_open ()
	{
		text.text = "Using the sharpened chair leg, you are able to fit it inside the opening of the chest and pry it open. Inside is a Key.\n" +
		"\n" +
		"Will you take the Key?\n" +
		"\n" +
		"Press T to take the Key.\n" +
		"Press R to roam the Cell.\n";

		if (Input.GetKeyDown (KeyCode.T)) {
			myState = States.chest_opened;
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	void chest_opened ()
	{
		inv_smallKey = Items.small_key;

		text.text = "You took the Key!\n" +
			"\n" +
			"Press R to roam the Cell.\n";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	void chest_done ()
	{
		text.text = "You've already opened the Small Chest.\n" +
		"\n" +
		"Press R to roam the Cell.\n";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	//****************************************** MIRROR *************************************************//

	void mirror_0 ()
	{
		text.text = "You look at the mirror, its intricate border design seemingly out of place in a derelict cell like this. It stands propped up against the cold concrete wall; " +
		"your reflection muddied and distorted from the several cracks.\n" +
		"\n" +
		"Press T to pick up a shard of glass.\n" +
		"Press F to look at your reflection.\n" +
		"Press R to roam the Cell.\n";

		if (Input.GetKeyDown (KeyCode.T)) {
			myState = States.mirror_1;
		}

		if (Input.GetKeyDown (KeyCode.F)) {
			myState = States.mirror_me;
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	void mirror_1 ()
	{
		inv_mirrorShard = Items.mirror_shard;
		self_Hand = Items.cut_hand;

		text.text = "As you attempt to tear apart a shard of glass from the mirror, the entire mirror shatters. You hastily tear free a shard in the rain of glassware, " +
		"receiving a long cut on your palm of your hand. You grimace at the pain as you carefully put the shard in your back pocket.\n" +
		"\n" +
		"Press R to roam the Cell.\n";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	void mirror_me ()
	{
		text.text = "You look pretty good, despite the bed head. Your plaid, button up shirt and green pants look out of place in your desolate new room.\n" +
		"\n" +
		"Press C to check the mirror again.\n" +
		"Press R to roam the Cell.\n";

		if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.mirror_0;
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	void mirror_done ()
	{
		text.text = "The mirror finally looks like it belongs with this room, broken and all.\n" +
		"\n" +
		"Press R to roam the Cell.\n";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}


	//****************************************** CHAIR *************************************************//

	void chair_0 ()
	{
		text.text = "The chair has sat here for what seems like an eternity; the wood is decayed and it looks close to crumbling apart. " +
		"As you walk closer, one of the chair's legs looks like it can easily be torn apart.\n" +
		"\n" +
		"Press T to take the Chair Leg.\n" +
		"Press R to roam the Cell.\n";

		if (Input.GetKeyDown (KeyCode.T)) {
			myState = States.chair_1;
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	void chair_1 ()
	{
		inv_chairLeg = Items.chair_leg;

		text.text = "You are able to rip the Chair Leg apart with ease. As you inspect the wood, the chair finally succumbs to its old age and clumsily crumbles to the floor.\n" +
		"\n" +
		"Press R to roam the Cell.\n";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	void chair_done ()
	{
		text.text = "Thanks to you, the chair has finally succumbed to its old age.\n" +
		"\n" +
		"Press R to roam the Cell.\n";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	//****************************************** WINDOW *************************************************//

	void window () 
	{
		text.text = "You stare up at the only source of light in this dilapidated cell. Bloodied scratch marks lead their way up to the window, never quite reaching it. " +
		"You shudder and hope that you can find a way out of here before it gets dark.\n" +
		"\n" +
		"Press R to roam the Cell.\n";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	void window_1 ()
	{
		text.text = "You take a brief look back at the window. You find the sunlight reassuring in this foreign place.\n" +
		"\n" +
		"Press R to roam the Cell.";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}
		
	//****************************************** GATE *************************************************//

	void gate_0 ()
	{
		text.text = "Rust has almost completely taken over the metal bars that block you from your corridor. You'll need to find a key to slide open the gate.\n" +
		"\n" +
		"Press P to inspect the handle.\n" +
		"Press R to roam the Cell.\n";

		if (Input.GetKeyDown (KeyCode.P)) {
			myState = States.gate_inspect;
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	void gate_inspect ()
	{
		text.text = "Upon further inspection, you notice an odd sort of fungus on the gate handle.\n" +
		"\n" +
		"Press R to roam the Cell.\n";
		
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	void gate_1 ()
	{
		text.text = "Now that you've got a Key, would you like to try it on the cell gate?\n" +
		"\n" +
		"Press K to use the Key.\n" +
		"Press R to roam the Cell further.\n";

		if (Input.GetKeyDown (KeyCode.K)) {
			if (cutHand) {
				myState = States.gate_open_cut;
			} else {
				myState = States.gate_open_cut;
			}
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	void gate_open_cut ()
	{
		text.text = "The Key works! You take a deep breath and take hold of the handle, sliding the cell gate open  " +
		"as slowly and as quietly as you can, for fear of alerting anyone to your presence. As you step out into the dimly sunlit corridor, your legs throbbing starts " +
		"to throb a bit faster now, and you notice your cut hand, which you used to take hold of the fungus-covered handle, has begun to throb as well. Worried, scared, " +
		"you are filled with determination.\n" +
		"\n" +
		"The game's over! Press Escape to play again!";

		if (Input.GetKeyDown (KeyCode.Escape)) {
			myState = States.begin;
		}
	}
}

