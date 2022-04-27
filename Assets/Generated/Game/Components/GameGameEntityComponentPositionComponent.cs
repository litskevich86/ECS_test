//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.EntityComponent.PositionComponent gameEntityComponentPosition { get { return (Game.EntityComponent.PositionComponent)GetComponent(GameComponentsLookup.GameEntityComponentPosition); } }
    public bool hasGameEntityComponentPosition { get { return HasComponent(GameComponentsLookup.GameEntityComponentPosition); } }

    public void AddGameEntityComponentPosition(UnityEngine.Vector3 newPosition) {
        var index = GameComponentsLookup.GameEntityComponentPosition;
        var component = (Game.EntityComponent.PositionComponent)CreateComponent(index, typeof(Game.EntityComponent.PositionComponent));
        component.Position = newPosition;
        AddComponent(index, component);
    }

    public void ReplaceGameEntityComponentPosition(UnityEngine.Vector3 newPosition) {
        var index = GameComponentsLookup.GameEntityComponentPosition;
        var component = (Game.EntityComponent.PositionComponent)CreateComponent(index, typeof(Game.EntityComponent.PositionComponent));
        component.Position = newPosition;
        ReplaceComponent(index, component);
    }

    public void RemoveGameEntityComponentPosition() {
        RemoveComponent(GameComponentsLookup.GameEntityComponentPosition);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGameEntityComponentPosition;

    public static Entitas.IMatcher<GameEntity> GameEntityComponentPosition {
        get {
            if (_matcherGameEntityComponentPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameEntityComponentPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameEntityComponentPosition = matcher;
            }

            return _matcherGameEntityComponentPosition;
        }
    }
}
