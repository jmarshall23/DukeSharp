public partial class ConScript
{
    private void PrecacheModels()
    {
        traps.precachemodel(21, "models/pickups/pistol.obj");
        traps.precachemodel(28, "models/pickups/shotgun.obj");
        traps.precachemodel(51, "models/pickups/healthbox.obj");
        traps.precachemodel(52, "models/pickups/healthbottle.obj");
        traps.precachemodel(53, "models/pickups/firstaid.obj");
        traps.precachemodel(981, "models/enviro/hydrant.obj");
    }
}