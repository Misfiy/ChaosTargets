using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using MEC;
using Respawning;

namespace FullChaosTargets
{
     public class EventHandler
     {
          public EventHandler()
          {
               Exiled.Events.Handlers.Server.RespawningTeam += OnRespawningTeam;
               Exiled.Events.Handlers.Player.Spawned += OnSpawned;
          }

          ~EventHandler()
          {
               Exiled.Events.Handlers.Server.RespawningTeam -= OnRespawningTeam;
               Exiled.Events.Handlers.Player.Spawned -= OnSpawned;
          }
          
          private void OnRespawningTeam(RespawningTeamEventArgs ev)
          {
               if (ev.NextKnownTeam == SpawnableTeamType.ChaosInsurgency)
               {
                    Timing.CallDelayed(1f, UpdateCounter);
               }
          }

          private void OnSpawned(SpawnedEventArgs ev)
          {
               if (ev.Reason != SpawnReason.Respawn) 
                    UpdateCounter();
          }
          
          private void UpdateCounter() 
               => Round.ChaosTargetCount = Player.List.Count(p => p.IsCHI) / 100 * Plugin.Instance.Config.ChaosPercent;
     }
}