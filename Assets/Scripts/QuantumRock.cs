using UnityEngine;

//Hecho por chatGPT, puesto a revision
public class QuantumRock : MonoBehaviour
{
    // The two possible states of the quantum rock
    public GameObject stateA;
    public GameObject stateB;

    // Whether the rock is currently in a superposition of states
    private bool inSuperposition;

    void Start()
    {
        // Initialize the quantum rock to be in a superposition of states
        inSuperposition = true;
        stateA.SetActive(false);
        stateB.SetActive(false);
    }

    void Update()
    {
        // Check if the player is looking at the rock
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2.0f))
        {
            // If the player is looking at the rock, collapse the superposition
            if (inSuperposition)
            {
                CollapseSuperposition();
            }
        }
        else
        {
            // If the player is not looking at the rock, put it back into a superposition
            if (!inSuperposition)
            {
                RestoreSuperposition();
            }
        }
    }

    // Collapses the superposition of the quantum rock
    private void CollapseSuperposition()
    {
        // Randomly choose one of the two states to collapse to
        bool chooseA = Random.Range(0, 2) == 0;

        // Set the chosen state to be active and the other state to be inactive
        if (chooseA)
        {
            stateA.SetActive(true);
            stateB.SetActive(false);
        }
        else
        {
            stateA.SetActive(false);
            stateB.SetActive(true);
        }

        // The rock is no longer in a superposition
        inSuperposition = false;
    }

    // Puts the quantum rock back into a superposition
    private void RestoreSuperposition()
    {
        // Set both states to be inactive
        stateA.SetActive(false);
        stateB.SetActive(false);

        // The rock is back in a superposition
        inSuperposition = true;
    }
}

