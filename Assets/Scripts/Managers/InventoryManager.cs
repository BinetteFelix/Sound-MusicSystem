using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    private InputManager inputManager => InputManager.Instance;

    [SerializeField] private GameObject panel;
    [SerializeField] private Animator animator;

    #region PANEL STATES
    public bool InventoryIsAnimating;
    public bool InventoryIsOpen { get; private set; }
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanOpenInv() && inputManager.actions.UI.Inventory.WasPressedThisFrame())
            OpenInventory();
    }
    public void OpenInventory()
    {
        switch (InventoryIsOpen)
        {
            case true:
                {
                    animator.SetTrigger("Open");
                    animator.SetBool("OpenState", InventoryIsOpen);
                    InventoryIsOpen = false;
                    break;
                }
            case false:
                {
                    animator.SetTrigger("Open");
                    animator.SetBool("OpenState", InventoryIsOpen);
                    InventoryIsOpen = true;
                    EventSystem.current.SetSelectedGameObject(null);
                    break;
                }
            default:
        }
    }

    private bool CanOpenInv()
    {
        return !InventoryIsAnimating;
    }
}
