using System;
using System.Globalization;
using UnityEngine;

public class TrajectoryPath : MonoBehaviour
{
    [SerializeField] private ScreenModel screenModel;
    private void Start()
    {
        screenModel.allPoints = new Vector3[screenModel.pointCount];
    }

    public void CreateTrajectoryLine()
    {
        if (screenModel.playerModel.isInAir) return;
        
        screenModel.time = (screenModel.force.y / screenModel.mass / Physics2D.gravity.magnitude) * 2;

        var per = screenModel.time / (screenModel.pointCount - 1);
        
        for (var i = 0; i < screenModel.allPoints.Length; i++)
        {
            if (i == 0)
            {
                screenModel.allPoints[0] = (screenModel.playerModel.currentPosition);
            }
            else
            {
                var x = screenModel.playerModel.currentPosition.x + screenModel.force.x / screenModel.mass * per * i;
                var y = screenModel.playerModel.currentPosition.y + screenModel.force.y / screenModel.mass * per * i -
                        Physics2D.gravity.magnitude * (float)Math.Pow(per * i, 2) / 2;
                screenModel.allPoints[i] = new Vector3(x, y);   
            }
        }

        screenModel.trajectoryLine.positionCount = screenModel.pointCount;
        screenModel.trajectoryLine.SetPositions(screenModel.allPoints);
    }
}