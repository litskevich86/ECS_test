//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int GameCollisionId = 0;
    public const int GameEntityComponentPosition = 1;
    public const int GameUnityController = 2;

    public const int TotalComponents = 3;

    public static readonly string[] componentNames = {
        "GameCollisionId",
        "GameEntityComponentPosition",
        "GameUnityController"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Game.CollisionIdComponent),
        typeof(Game.EntityComponent.PositionComponent),
        typeof(Game.UnityControllerComponent)
    };
}
