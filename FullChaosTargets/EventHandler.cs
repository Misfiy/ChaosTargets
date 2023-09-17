using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using MEC;
using Respawning;

namespace FullChaosTargets
{
     public class EventHandler
     {
          public void OnRespawningTeam(RespawningTeamEventArgs ev)
          {
               if (ev.NextKnownTeam == SpawnableTeamType.ChaosInsurgency)
               {
                    Timing.CallDelayed(1f, () =>
                    {
                         int amount = (Player.List.Count(p => p.IsCHI) / 100) * Plugin.Instance.Config.ChaosPercent;

                         RoundSummary.singleton.ChaosTargetCount = amount;
                    });
               }
          }
     }
}