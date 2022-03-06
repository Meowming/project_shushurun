using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 被相机跟随 : MonoBehaviour
{
    private Transform cameraTransform;
    private bool isFollow = false;

    #region Unity

    private void Awake()
    {
        isFollow = true;
        cameraTransform = Camera.main.transform;
    }

    void LateUpdate()
    {
        Follow();
    }

    private void OnDestroy()
    {
        isFollow = false;
    }

    #endregion

    #region 私有函数

    void Follow()
    {
        if(cameraTransform != null && isFollow)
        {
            cameraTransform.position = new Vector3(this.transform.position.x, this.transform.position.y, cameraTransform.position.z);
        }
    }

    #endregion
}
