using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class MainMenu : MonoBehaviour 
{
    public bool mainMenuOpen = false;
    public GameObject mainMenu;
    public UnityEvent onMenuOpen;
    public UnityEvent onMenuClose;


    private void Start()
    {
        mainMenu.SetActive(mainMenuOpen);
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            OpenCloseMainMenu();
        }

    }

    public void OpenCloseMainMenu()
    {
        
            mainMenuOpen = !mainMenuOpen;
            mainMenu.SetActive(mainMenuOpen);
            if (mainMenuOpen)
            {
                onMenuOpen?.Invoke();
            }
            else
            {
                onMenuClose?.Invoke();
            }
    }
}
