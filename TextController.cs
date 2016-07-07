using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour
{

	public Text text, inventory;
	private enum States {begin, belong,
						cell, cell_return,
						chest_0, chest_1, chest_leg, chest_leg_shard, chest_sharp_leg, chest_open, chest_opened, chest_done,
						mirror_0, mirror_1, mirror_me, mirror_done,
						chair_0, chair_1, chair_done,
						door_0, door_1, door_inspect, freedom,
						window_0, window_1};

	private enum Items {empty, small_key, chair_leg, sharp_chair_leg, mirror_shard, cut_hand};
	private States myState;
	private Items self_Hand, inv_smallKey, inv_chairLeg, inv_mirrorShard;

	// Use this for initialization
	void Start ()
	{
		myState = States.begin;
		inv_smallKey = Items.empty;
		inv_chairLeg = Items.empty;
		inv_mirrorShard = Items.empty;
	}

	// Update is called once per frame
	void Update ()
	{
		print ("myState: " + myState);
		print ("Chest key: " + inv_smallKey);
		print ("Chair leg: " + inv_chairLeg);
		print ("Mirror Piece: " + inv_mirrorShard);

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
			window_1 ();
		}

		if (myState == States.door_0) {
			door_0 ();
		} else if (myState == States.door_1) {
			door_1 ();
		} else if (myState == States.door_inspect) {
			door_inspect ();
		} else if (myState == States.freedom) {
			freedom ();
		}
	}

	void begin ()
	{
		text.text = "You have awaken on a cold concrete floor. You groggily push yourself into a sitting position, feeling patches of grass growing from the lifeless concrete around you. " +
			"Confused, you stand up and notice your entire right leg throb ever so slightly. Dismissing whatever affliction your leg has contracted for the moment, " +
			"you turn your attention to the tiny room where you have apparently stayed the night, though with no recollection of this whatsoever.\n" +
			"\n" +
			"As you scan your surroundings, it appears that you have been taken to a prison cell. The rusty bars blocking your freedom offer you " +
			"no sympathy as you stare at them in bewilderment.\n" +
			"\n" +
			"You must find a way out of here before the kidnappers get back to you!\n" +
			"\n" +
			"Press Enter to continue.";

		if (Input.GetKeyDown (KeyCode.Return)) {
			myState = States.cell;
		}
	}

	void cell ()
	{
		text.text = "Continuing your search of the room, you notice a Cracked Mirror propped against the western wall, a Small Chest in the southeast corner of the room, and a Wooden Chair " +
			"next to the Small Chest. Looking at the bars again, you must have missed the handle of the Cell Door. It is, however, locked. There is also a " +
			"Window in the southern wall a ways above you, allowing the only illumination into your cell. You must find a light source or a way out before dark.\n" +
			"\n" +
			"What will you do?\n" +
			"\n" +
			"Press I to check your Belongings.\n" +
			"\n" +
			"Press C to check the Small Chest.\n" +
			"Press M to view the Cracked Mirror.\n" +
			"Press S to inspect the Wooden Chair.\n" +
			"Press D to examine the Cell Door.\n" +
			"Press W to look at the Barred Window that's out of your reach.\n";

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

		//Door
		if (Input.GetKeyDown (KeyCode.D)) {
			myState = States.door_0;
		}
	}

	void cell_return ()
	{
		inventory.text = " ";

		text.text = "You continue your search of the cell. What will you do?\n" +
		"\n" +
		"Press I to check your Belongings.\n" +
		"\n" +
		"Press C to check the Small Chest.\n" +
		"Press M to view the Cracked Mirror.\n" +
		"Press S to inspect the Wooden Chair.\n" +
		"Press D to examine the Cell Door.\n" +
		"Press W to look at the Barred Window that's out of your reach.\n";

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

		//Door
		if (Input.GetKeyDown (KeyCode.D)) {
			if (inv_smallKey == Items.small_key) {
				myState = States.door_1;
			} else {
				myState = States.door_0;
			}
		}
	}

	//****************************************** INVENTORY *************************************************//

	void belongings ()
	{
		bool chairLeg = false, sharpChairLeg = false, mirrorShard = false, smallKey = false;

		if (inv_chairLeg == Items.chair_leg) {
			chairLeg = true;
		} else if (inv_chairLeg == Items.sharp_chair_leg) {
			sharpChairLeg = true;
		}
		if (inv_mirrorShard == Items.mirror_shard) {
			mirrorShard = true;
		}
		if (inv_smallKey == Items.small_key) {
			smallKey = true;
		}

		if (!chairLeg && !sharpChairLeg && !mirrorShard && !smallKey) {
			text.text = "You've only got the clothes on your back.\n" +
			"\n" +
			"Press R to roam the Cell.\n";

			if (Input.GetKeyDown (KeyCode.R)) {
				myState = States.cell_return;
			}
		} else {
			text.text = "Here's the stuff that you've got: \n\n" +
				"Press R to go back\n";

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
		text.text = "As you inspect the small, wooden chest, it appears to be unlocked.\n" +
		"\n" +
		"Press O to open the chest.\n" +
		"Press R to roam the cell.\n";

		if (Input.GetKeyDown (KeyCode.O)) {
			if (inv_chairLeg == Items.chair_leg && inv_mirrorShard == Items.empty) {
				myState = States.chest_leg;
			} else if (inv_chairLeg == Items.chair_leg && inv_mirrorShard == Items.mirror_shard) {
				myState = States.chest_leg_shard;
			} else if (inv_chairLeg == Items.sharp_chair_leg ) {
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
		text.text = "Even though the chest is unlocked, it won't budge. You'll need something strong to pry it open.\n" +
		"\n" +
		"Press R to roam the Cell.\n";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	void chest_leg ()
	{
		text.text = "The wooden chair leg does not seem to fit in the opening of the chest. Maybe if you could sharpen it somehow...\n" +
		"\n" +
		"Press R to roam the Cell.\n";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	void chest_leg_shard ()
	{
		text.text = "The wooden chair leg does not seem to fit in the opening of the chest. Maybe if you could sharpen it somehow...\n" +
		"\n" +
		"Press S to sharpen the wooden chair leg with the shard of glass.\n" +
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
			"Press O to use the sharpened leg to open the chest.\n" +
			"Press R to roam the Cell.\n";

		if (Input.GetKeyDown (KeyCode.O)) {
			myState = States.chest_opened;
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
			"Press R to roam the cell.\n";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	void chest_done ()
	{
		text.text = "You've already opened the Small Chest.\n" +
		"\n" +
		"Press R to roam the cell.\n";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	//****************************************** MIRROR *************************************************//

	void mirror_0 ()
	{
		text.text = "You look at the mirror, its intricate border design seemingly out of place in a rotting cell like this. It stands propped up against the cold concrete wall; " +
		"your reflection muddied and distorted from the many cracks. There are some shards of glass laying around the mirror as well.\n" +
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

		text.text = "As you attempt to tear apart a shard of glass from the mirror, the entire mirror shatters. As you hastily tear free a shard in the rain of glassware, " +
		"you receive a long cut on your palm of your hand. You grimace at the pain as you carefully put the shard in your back pocket.\n" +
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
			"Upon further inspection, the chair leg doesn't look like it belongs with the rest of the chair; the wood looks to be in a much healthier state than it's other parts. Strange...\n" +
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
		text.text = "You take a brief look back at the window. You find the sunlight reassuring in this nightmarish place.\n" +
		"\n" +
		"Press R to roam the Cell.";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}
		
	//****************************************** DOOR *************************************************//

	void door_0 ()
	{
		text.text = "The rust has almost completely taken over the metal bars that block you from your freedom. The cell door is placed in the middle of the bars, " +
		"and is just big enough for you to fit through.\n" +
		"\n" +
		"Press P to inspect the door.\n" +
		"Press R to roam the Cell.\n";

		if (Input.GetKeyDown (KeyCode.P)) {
			myState = States.door_inspect;
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	void door_inspect ()
	{
		text.text = "Upon further inspection, you notice an odd sort of fungus on the door handle.\n" +
		"\n" +
		"Press R to roam the Cell.\n";
		
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	void door_1 ()
	{
		text.text = "Now that you've got a Key, would you like to try it on the cell door?\n" +
		"\n" +
		"Press K to use the Key.\n" +
		"Press R to roam the Cell further.\n";

		if (Input.GetKeyDown (KeyCode.K)) {
			myState = States.freedom;
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_return;
		}
	}

	void freedom ()
	{
		text.text = "They Key works! Trembling with fear yet filled with determination, you take hold of the handle and slowly turn it. " +
		"You push open the cell door as slowly and as quietly as you can, for fear of alerting your jailers. As you step out into the sunlit hallway, your legs throbbing starts " +
		"to throb a bit faster now, and you notice your cut hand, which you used to turn the rusty handle, has begun to throb as well. Worried, scared, you are determined to find " +
		"a way out of this nightmare.\n";
	}
}

