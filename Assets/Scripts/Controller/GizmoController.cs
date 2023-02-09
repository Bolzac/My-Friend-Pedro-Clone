using System;
using UnityEngine;

namespace Controller
{
    public class GizmoController : MonoBehaviour
    {
        [SerializeField] private PlayerModel playerModel;

        private void OnDrawGizmos()
        {
            Gizmos.color = playerModel.isOnGround ? Color.green : Color.red;
            Gizmos.DrawWireCube(new Vector2(playerModel.ground.position.x,playerModel.ground.position.y - 0.05f), new Vector3(playerModel.coll.bounds.size.x - 0.5f, 0.1f));
            if (playerModel.isAscending)
                Gizmos.DrawIcon(transform.position + new Vector3(2, 0.5f), "AscendIcon.png", true);
            if (playerModel.isDescending)
                Gizmos.DrawIcon(transform.position + new Vector3(2, -0.5f), "DescendIcon.png", true);
        }
    }
}