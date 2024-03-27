using RimWorld;
using Verse;
using Verse.AI;

namespace Penguin;

public class Penguin_JobGiver_Cleaning : ThinkNode_JobGiver
{
    protected override Job TryGiveJob(Pawn pawn)
    {
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

        bool validator(Thing t)
        {
            return t.def.category == ThingCategory.Projectile;
        }
    }
}