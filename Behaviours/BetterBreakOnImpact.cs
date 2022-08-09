using System;
using System.Collections.Generic;
using MonomiPark.SlimeRancher.Regions;
using SRML.Utils;
using UnityEngine;

public class BetterBreakOnImpact : SRBehaviour
{

	public virtual void Awake()
	{
		this.body = base.GetComponent<Rigidbody>();
	}

	public void OnCollisionEnter(Collision col)
	{
		if (!col.collider.isTrigger && !this.body.isKinematic)
		{
			float num = 0f;
			foreach (ContactPoint contactPoint in col.contacts)
			{
				num = Mathf.Max(num, Vector3.Dot(contactPoint.normal, col.relativeVelocity));
			}
			if (num > 14f)
			{
				this.BreakOpen();
			}
		}
	}

	private void BreakOpen()
	{
		if (this.breaking)
		{
			return;
		}
		this.breaking = true;
		Destroyer.DestroyActor(base.gameObject, "BetterBreakOnImpact.BreakOpen", false);
	}

	// Token: 0x04002368 RID: 9064
	private Rigidbody body;

	// Token: 0x04002369 RID: 9065
	private bool breaking;
}
