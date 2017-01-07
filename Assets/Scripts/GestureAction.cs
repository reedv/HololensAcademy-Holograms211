using Academy.HoloToolkit.Unity;
using UnityEngine;

/// <summary>
/// GestureAction performs custom actions based on which gesture is being performed.
/// Calls are mostly activated by messages from GestureManager.cs
/// </summary>
public class GestureAction : MonoBehaviour
{
    [Tooltip("Rotation max speed controls amount of rotation.")]
    public float RotationSensitivity = 10.0f;

    private Vector3 manipulationPreviousPosition;

    private float rotationFactor;

    void Update()
    {
        PerformRotation();
    }

    private void PerformRotation()
    {
        // Perform rotation action when user doing navigation gesture on an expanded model
        if (GestureManager.Instance.IsNavigating &&
            (!ExpandModel.Instance.IsModelExpanded ||
            (ExpandModel.Instance.IsModelExpanded && HandsManager.Instance.FocusedGameObject == gameObject)))
        {
            /* TODO: DEVELOPER CODING EXERCISE 2.c */

            // 2.c: Calculate rotationFactor based on GestureManager's NavigationPosition.X and multiply by RotationSensitivity.
            // This will help control the amount of rotation.
            rotationFactor = GestureManager.Instance.NavigationPosition.x * RotationSensitivity;

            // 2.c: transform.Rotate along the Y axis using rotationFactor.
            // Based on the syntax, I think they are using an implicit 'gameObject' refereing to component GameObject (?)
            // see http://www.completeunitydeveloper.com/blog/this-vs-gameobject
            transform.Rotate(new Vector3(0, -1 * rotationFactor, 0));
        }
    }

    void PerformManipulationStart(Vector3 position)
    {
        manipulationPreviousPosition = position;
    }

    void PerformManipulationUpdate(Vector3 current_position)
    {
        // Perform manipulation action when user doing navigation gesture on an expanded model
        if (GestureManager.Instance.IsManipulating)
        {
            /* TODO: DEVELOPER CODING EXERCISE 4.a */

            Vector3 moveVector = Vector3.zero;
            // 4.a: Calculate the moveVector as position - manipulationPreviousPosition.
            moveVector = current_position - manipulationPreviousPosition;
            // 4.a: Update the manipulationPreviousPosition with the current position.
            manipulationPreviousPosition = current_position;
            // 4.a: Increment this transform's position by the moveVector.
            // By the syntax, I think they are using an implicit 'gameObject' here (?)
            // see http://www.completeunitydeveloper.com/blog/this-vs-gameobject
            transform.position += moveVector;
        }
    }
}