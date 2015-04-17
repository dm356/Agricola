using UnityEngine;
using System.Collections;

public class RoundCard : ActionSpace
{

		protected bool _active;
		public MeshRenderer model;
		public Material card_face;

		public virtual void Activate ()
		{
				if (!_active) {
						model.material = card_face;
						_active = true;
				}
		}

		public override void SetupAction ()
		{
				if (_active) {
						base.SetupAction ();
				}
		}

		public override void RoundSetup ()
		{
				if (_active) {
						base.RoundSetup ();
				}
		}
}
