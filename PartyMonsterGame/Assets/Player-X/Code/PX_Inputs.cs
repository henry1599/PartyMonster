//------------
//... PLayer-X
//... V2.0.1
//... © TheFamousMouse™
//--------------------
//... Support email:
//... thefamousmouse.developer@gmail.com
//--------------------------------------

using UnityEngine;
using UnityEngine.InputSystem;
using PlayerX;
using PartyMonster.Interface;
using NaughtyAttributes;
using PartyMonster;
using UnityEngine.UIElements;

namespace PlayerX
{
	public class PX_Inputs : MonoBehaviour, IPlayerInput
	{
		[Header("Player-X [Inputs]")]
		
		[Space]
		
		[Header("- Input Dependencies")]
		public PX_Dependencies dependencies;
		
		[Header("- AI")]
		public bool simpleAI = false;
		
		//- Hidden Variables
		
		//...
		[HideInInspector]
		public Vector2 
		mouse_Inputs;
		
		//...
		[HideInInspector]
		public bool 
		mouseLeft_input, mouseRight_input,
		keyLook_Input, keyKneel_Input, 
		keyKickRight_Input, keyKickLeft_Input,
		keyEquipLeft_Input, keyEquipRight_Input,
		velocityModeChange_Input,
		slowMotion_Input,
		restart_Input,
		exit_Input;
		public PunchParam Punch {get => this.punch;} private PunchParam punch = new PunchParam(false, false, 0);
		[ReadOnly] protected FrameInput frameInput; 
		public FrameInput Frame => this.frameInput;
		
		//... Simple AI variables
		float actionTime;
		bool actionPerform;
		

		//... Calculate Input ...
	    void Update()
	    {
			this.frameInput = GatherInput();
			
			//... Human Input
			//-
			
			// if(!simpleAI)
			// {
			// 	//... Mouse inputs
			// 	mouseLeft_input = Mouse.current.leftButton.isPressed;
			// 	mouseRight_input = Mouse.current.rightButton.isPressed;
				
			// 	//... Mouse output
			// 	mouse_Inputs = Mouse.current.delta.ReadValue();
				
			// 	keyLook_Input = Keyboard.current.fKey.isPressed;
			// 	keyKneel_Input = Keyboard.current.leftCtrlKey.isPressed;
				
				// this.punch.PunchingLeft = Keyboard.current.qKey.isPressed;
				// this.punch.PunchingRight = Keyboard.current.eKey.isPressed;
			// 	keyKickLeft_Input = Keyboard.current.zKey.isPressed;
			// 	keyKickRight_Input = Keyboard.current.cKey.isPressed;
				
			// 	keyEquipLeft_Input = Keyboard.current.gKey.wasPressedThisFrame;
			// 	keyEquipRight_Input = Keyboard.current.hKey.wasPressedThisFrame;
				
			// 	slowMotion_Input = Keyboard.current.nKey.wasPressedThisFrame;
				
			// 	velocityModeChange_Input = Keyboard.current.mKey.wasPressedThisFrame;
				
			// 	restart_Input = Keyboard.current.rKey.wasPressedThisFrame;
				
			// 	exit_Input = Keyboard.current.escapeKey.wasPressedThisFrame;
				
				
			// 	//... Key Output values
			// 	if(keyForward_Input)
			// 	{
			// 		key_Inputs.y = 1;
			// 	}
				
			// 	else if(keyBackward_Input)
			// 	{
			// 		key_Inputs.y = -1;
			// 	}
				
			// 	else
			// 	{
			// 		key_Inputs.y = 0;
			// 	}
				
				
			// 	if(keyLeft_Input)
			// 	{
			// 		key_Inputs.x = -1;
			// 	}
				
			// 	else if(keyRight_Input)
			// 	{
			// 		key_Inputs.x = 1;
			// 	}
				
			// 	else
			// 	{
			// 		key_Inputs.x = 0;
			// 	}
			// }
			
			
			// //----------------------
			
			
			// //... Simple AI example
			// //-
			// else
			// {
			// 	if(dependencies.state.isAlive && !dependencies.state.isKnockedOut && dependencies.controller.trackObject != null)
			// 	{
			// 		//... Simple AI action example
			// 		if(dependencies.controller.trackObject.transform.root.GetComponent<PX_Dependencies>() && dependencies.controller.trackObject.transform.root.GetComponent<PX_Dependencies>().state.isAlive
			// 		&& !dependencies.controller.trackObject.transform.root.GetComponent<PX_Dependencies>().state.isKnockedOut)
			// 		{
			// 			if(!actionPerform && Vector3.Distance(dependencies.player.rootPhysics.transform.position, dependencies.controller.trackObject.position) < 3f)
			// 			{
			// 				actionPerform = true;
							
			// 				//... Pick a random number that will dictate the action
			// 				var actionRondom = Random.Range(0, 4);
			// 				actionTime = Random.Range(0.5f, 1.5f);
							
			// 				//... Punch left
			// 				if(actionRondom == 0)
			// 				{
			// 					keyPunchLeft_Input = true;
			// 					Invoke(nameof(PunchLeft), actionTime);
			// 				}
							
			// 				//... Punch right
			// 				else if(actionRondom == 1)
			// 				{
			// 					keyPunchRight_Input = true;
			// 					Invoke(nameof(PunchRight), actionTime);
			// 				}
							
			// 				//... Kick left
			// 				else if(actionRondom == 2)
			// 				{
			// 					keyKickLeft_Input = true;
			// 					Invoke(nameof(KickLeft), actionTime);
			// 				}
							
			// 				//... Kick right
			// 				else if(actionRondom == 3)
			// 				{
			// 					keyKickRight_Input = true;
			// 					Invoke(nameof(KickRight), actionTime);
			// 				}
			// 			}
						
			// 			//... Simple AI move & direction example
			// 			if(Vector3.Distance(dependencies.player.rootPhysics.transform.position, dependencies.controller.trackObject.position) > 3f 
			// 			&& Vector3.Distance(dependencies.player.rootPhysics.transform.position, dependencies.controller.trackObject.position) < dependencies.controller.headTrackDistance)
			// 			{
			// 				dependencies.controller.moveDir = (dependencies.player.rootPhysics.transform.forward);
							
			// 				dependencies.controller.moveDir.y = 0f;
			// 				dependencies.controller.moveDir = dependencies.controller.moveDir.normalized;
							
			// 				key_Inputs.y = 1;
			// 			}
						
			// 			//... Stop moving the Ai
			// 			else
			// 			{
			// 				dependencies.controller.moveDir = Vector3.zero;
			// 				key_Inputs.y = 0;
			// 			}
			// 		}
					
			// 		//... Stop moving the Ai
			// 		else
			// 		{
			// 			dependencies.controller.moveDir = Vector3.zero;
			// 			key_Inputs.y = 0;
			// 		}
					
			// 		//... Simple AI weapon check
			// 		if(!dependencies.weapons.simpleAIWeaponCheck)
			// 		{
			// 			if(!dependencies.weapons.weaponAssignedLeft && !dependencies.weapons.weaponAssignedRight)
			// 			{
			// 				dependencies.weapons.simpleAIWeaponCheck = true;
			// 				Invoke(nameof(AttemptWeaponPick), Random.Range(0.1f, 0.3f));
			// 			}
			// 		}
			// 	}
			// }
	    }

        public FrameInput GatherInput()
        {
			FrameInput result = new FrameInput()
			{
				KeyInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")),
				JumpDown = Input.GetKeyDown(KeyCode.X),
				AttackDown = Input.GetKey(KeyCode.C),
				RunHold = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift),
				PickupDown = Input.GetKeyDown(KeyCode.F)
			};

			this.punch.SetCurrentPunch(result.AttackDown);
			return result; 
        }
		
		//... Simple AI Functions
		//... AI Release left punch
		void PunchLeft()
		{
			this.punch.PunchingLeft = false;
			Invoke(nameof(actionCoolDown), actionTime);
		}
		
		//... AI Release right punch
		void PunchRight()
		{
			this.punch.PunchingRight = false;
			Invoke(nameof(actionCoolDown), actionTime);
		}
		
		//... AI Release left kick
		void KickLeft()
		{
			keyKickLeft_Input = false;
			Invoke(nameof(actionCoolDown), actionTime);
		}
		
		//... AI Release right kick
		void KickRight()
		{
			keyKickRight_Input = false;
			Invoke(nameof(actionCoolDown), actionTime);
		}
		
		//... AI Attempt to pickup weapon
		void AttemptWeaponPick()
		{
			//... AI Weapon left hand pickup
			if(!dependencies.weapons.weaponAssignedLeft)
			{
				keyEquipLeft_Input = true;
				Invoke(nameof(EquipedLeft), Time.smoothDeltaTime);
			}
			
			//... AI Weapon right hand pickup
			else if(!dependencies.weapons.weaponAssignedRight)
			{
				keyEquipRight_Input = true;
				Invoke(nameof(EquipedRight), Time.smoothDeltaTime);
			}
			
			dependencies.weapons.simpleAIWeaponCheck = false;
		}
		
		//... AI Release equip weapon left
		void EquipedLeft()
		{
			keyEquipLeft_Input = false;
		}
		
		//... AI Release equip weapon right
		void EquipedRight()
		{
			keyEquipRight_Input = false;
		}
		
		//... AI Allow next action
		void actionCoolDown()
		{
			actionPerform = false;
		}
		[System.Serializable]
		public class PunchParam
		{
			public bool PunchingLeft;
			public bool PunchingRight;
			public int CurrentPunchIndex;
			public PunchParam(bool punchingLeft, bool punchingRight, int initIndex)
			{
				this.PunchingLeft = punchingLeft;
				this.PunchingRight = punchingRight;
				this.CurrentPunchIndex = initIndex;
			}
			public bool GetCurrentPunch() => this[this.CurrentPunchIndex];
			public void SetCurrentPunch(bool isPunching) => this[this.CurrentPunchIndex] = isPunching;
			public void UpdatePunchIndex()
			{
				++ this.CurrentPunchIndex;
				this.CurrentPunchIndex %= 2;
			}
			public bool this[int i]
			{
				get => i switch
				{
					0 => this.PunchingLeft,
					1 => this.PunchingRight,
					_ => false
				};
				set
				{
					switch (i)
					{
						case 0:
							this.PunchingLeft = value;
							break;
						case 1:
							this.PunchingRight = value;
							break;
					}
				}
			}
		}
    }
}
