using System;
using RimWorld;
using Verse;
using Verse.AI;

namespace Penguin
{
	// Token: 0x02000002 RID: 2
	public class Penguin_JobGiver_Cleaning : ThinkNode_JobGiver
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		protected override Job TryGiveJob(Pawn pawn)
		{
            bool validator(Thing t) => t.def.category == ThingCategory.Projectile;
            Thing thing = GenClosest.ClosestThingReachable(pawn.Position, pawn.Map, ThingRequest.ForGroup(ThingRequestGroup.Filth), PathEndMode.ClosestTouch, TraverseParms.For(pawn, Danger.Deadly, TraverseMode.ByPawn, false), 300f, validator, null, 0, -1, false, RegionType.Set_Passable, false);
			if (thing != null && pawn.CanReserve(thing, 1, -1, null, false))
			{
				Job job = new Job(JobDefOf.Clean);
				job.AddQueuedTarget(TargetIndex.A, thing);
				return job;
			}
			return null;
		}
	}
}
