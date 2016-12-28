﻿/*
 * Author: Isaiah Mann
 * Description: Modifies AI Behaviour / Abilities
 */

[System.Serializable]
public class AICardMechanic : CardMechanic {

	public AICardMechanic (MechanicStats stats, LexCard owner) :
	base (MechanicVariant.AI, stats, owner) {

	}

	public AICardMechanic (MechanicStats stats) : base (MechanicVariant.AI, stats) {

	}

	public override bool ApplyEffect (GameController game) {
		if (base.ApplyEffect(game)) {
			return true;
		} else {
			return false;
		}
	}
}
