using Utility;

public class InputManager : SingletonBehaviour<InputManager>
{
    public Actions actions;

    public override void Instantiate()
    {
        actions = new Actions();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actions.UI.Pause.Enable(); 
        actions.UI.Inventory.Enable();
    }
}
