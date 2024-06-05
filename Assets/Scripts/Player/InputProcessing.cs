using UnityEngine;

public class InputProcessing : MonoBehaviour
{
    private void Update()
    {
        TryJump();
        TryShoot();
    }

    public bool TryJump()
    {
        bool canJump = false;

        if (Input.GetKeyDown(KeyCode.Space))
            canJump = true;

        return canJump;
    }

    public bool TryShoot()
    {
        bool canShoot = false;

        if (Input.GetKeyDown(KeyCode.F))
            canShoot = true;

        return canShoot;
    }
}