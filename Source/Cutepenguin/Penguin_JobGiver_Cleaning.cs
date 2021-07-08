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
            bool validator(Thing t)
            {
                return t.def.category == ThingCategory.Projectile;
            }

            var thing = GenClosest.ClosestThingReachable(pawn.Position, pawn.Map,
                ThingRequest.ForGroup(ThingRequestGroup.Filth), PathEndMode.ClosestTouch, TraverseParms.For(pawn), 300f,
                validator);
            if (thing == null || !pawn.CanReserve(thing))
            {
                return null;
            }

            var job = new Job(JobDefOf.Clean);
            job.AddQueuedTarget(TargetIndex.A, thing);
            return job;
        }
    }
}