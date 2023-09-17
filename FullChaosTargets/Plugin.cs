namespace FullChaosTargets
{
     using Exiled.API.Features;

    public class Plugin : Plugin<Config>
    {
          public override string Name => "ChaosTargets";
          public override string Prefix => Name;
          public override string Author => "@misfiy";
          
          public static Plugin Instance;

          private EventHandler handler;

          public override void OnEnabled()
          {
               Instance = this;
               handler = new();

               Exiled.Events.Handlers.Server.RespawningTeam += handler.OnRespawningTeam;

               base.OnEnabled();
          }

          public override void OnDisabled()
          {
               Exiled.Events.Handlers.Server.RespawningTeam -= handler.OnRespawningTeam;

               handler = null!;
               Instance = null!;
               base.OnDisabled();
          }
     }
}