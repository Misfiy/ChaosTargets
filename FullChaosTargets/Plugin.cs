namespace FullChaosTargets
{
     using Exiled.API.Features;

     public class Plugin : Plugin<Config>
     {
          public override string Name => "ChaosTargetsCounter";
          public override string Prefix => Name;
          public override string Author => "@misfiy";
          public override Version Version => new(1, 0, 1);

          public static Plugin Instance { get; set; } = null!;

          private EventHandler handler { get; set; } = null!;

          public override void OnEnabled()
          {
               Instance = this;
               handler = new();

               base.OnEnabled();
          }

          public override void OnDisabled()
          {
               handler = null!;
               Instance = null!;
               base.OnDisabled();
          }
     }
}