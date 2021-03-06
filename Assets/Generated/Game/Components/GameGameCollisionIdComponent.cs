//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.CollisionIdComponent gameCollisionId { get { return (Game.CollisionIdComponent)GetComponent(GameComponentsLookup.GameCollisionId); } }
    public bool hasGameCollisionId { get { return HasComponent(GameComponentsLookup.GameCollisionId); } }

    public void AddGameCollisionId(int newID) {
        var index = GameComponentsLookup.GameCollisionId;
        var component = (Game.CollisionIdComponent)CreateComponent(index, typeof(Game.CollisionIdComponent));
        component.Id = newID;
        AddComponent(index, component);
    }

    public void ReplaceGameCollisionId(int newID) {
        var index = GameComponentsLookup.GameCollisionId;
        var component = (Game.CollisionIdComponent)CreateComponent(index, typeof(Game.CollisionIdComponent));
        component.Id = newID;
        ReplaceComponent(index, component);
    }

    public void RemoveGameCollisionId() {
        RemoveComponent(GameComponentsLookup.GameCollisionId);
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

    static Entitas.IMatcher<GameEntity> _matcherGameCollisionId;

    public static Entitas.IMatcher<GameEntity> GameCollisionId {
        get {
            if (_matcherGameCollisionId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameCollisionId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameCollisionId = matcher;
            }

            return _matcherGameCollisionId;
        }
    }
}
