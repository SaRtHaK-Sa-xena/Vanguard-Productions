using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Attached to player
/// Locates Objective
/// </summary>
public class ArrowTest : MonoBehaviour
{

    [SerializeField]  private Camera uiCam;
    
    public GameObject Target;
    public GameObject arrow;

    public Vector3 targetPosition;
    public RectTransform pointerRectTransform;


    private void Awake()
    {
        targetPosition = new Vector3(3.16f, 12.82f);
        Target.transform.position = new Vector3(3.16f, 12.82f);
        pointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = Target.transform.position;
        Vector3 toPosition = targetPosition;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.x = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;
        float angle = Mathf.Atan2(dir.y, dir.z) * Mathf.Rad2Deg;
        if (angle < 0) angle += 360f;
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);

        Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);
        bool isOffScreen = targetPositionScreenPoint.z <= 0 || targetPositionScreenPoint.z >= Screen.width || targetPositionScreenPoint.y <= 0 || targetPositionScreenPoint.y >= Screen.height;
        Debug.Log(isOffScreen + " " + targetPositionScreenPoint);

        if(isOffScreen)
        {
            Vector3 cappedTargetScreenPosition = targetPositionScreenPoint;
            if (cappedTargetScreenPosition.z <= 0) cappedTargetScreenPosition.z = 0f;
            if (cappedTargetScreenPosition.z >= Screen.width) cappedTargetScreenPosition.z = Screen.width;
            if (cappedTargetScreenPosition.y <= 0) cappedTargetScreenPosition.y = 0f;
            if (cappedTargetScreenPosition.y >= Screen.height) cappedTargetScreenPosition.y = Screen.height;

            Vector3 pointerWorldPostition = uiCam.ScreenToWorldPoint(cappedTargetScreenPosition);
            pointerRectTransform.position = pointerWorldPostition;
            pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.z, pointerRectTransform.localPosition.y, 0f);
        }
    }

    void PositionArrow()
    {
        Vector3 v3Pos = Camera.main.WorldToViewportPoint(Target.transform.position);

    }
}
