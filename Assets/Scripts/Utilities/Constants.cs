public class Constants
{
    public const string PLAYER_DATA = "PlayerData";
}

public class PooledObjectTags
{
    public const string Bullet = "Bullet";
}
public class ObjectTags
{
    public const string Gun = "Gun";
    public const string Collactable = "Collactable";
    public const string Bullet = "Bullet";
    public const string Barrel = "Barrel";
}

public class PlayerStates
{
    public const string IdleState = "PlayerIdle";
    public const string SuccessState = "SuccessState";
    public const string FailState = "FailState";
    public const string RunState = "RunState";

}

public enum ListOperation
{
    Adding,
    Subtraction
}
public enum CollactableOperation
{
    Adding,
    Multiplication
}

public enum ObjectsLayer
{
    Collactable = 8,
    Collacted = 9,
    Gun = 10
}
public enum UIPanelType
{
    MainMenuPanel = 0,
    HudPanel = 1,
    FinishPanel = 2
}
