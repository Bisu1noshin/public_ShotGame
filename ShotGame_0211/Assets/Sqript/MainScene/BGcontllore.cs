using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BGcontllore : MonoBehaviour
{
    [SerializeField] GameObject BG;

    private GameObject[] _Bg = new GameObject[5];
    private Vector3 createPos = new(-2.37f, 7.21f, 0f);
    private Vector3 lengh = new(0, 3.73f, 0f);

    private void Start()
    {
        for (int i = 0; i < _Bg.Length; i++) {
            Vector3 vec = createPos - lengh * i;
            _Bg[i] = InstanceBG(vec);
        }
    }

    private void Update()
    {
        // BG‚ÌÄ\’z
        {
            for (int i = 0; i < _Bg.Length; i++)
            {

                if (_Bg[i].transform.position.y <= -7.7f)
                {
                    Destroy(_Bg[i]);
                    _Bg[i] = InstanceBG(createPos);
                }
            }
        }

        // BG‚ð“®‚©‚·
        {
            for (int i = 0; i < _Bg.Length; i++)
            {
                _Bg[i].transform.position += lengh * -0.05f; ;
            }
        }
    }

    private GameObject InstanceBG(Vector3 v) {
        Quaternion q = transform.rotation;

        return Instantiate(BG, v, q);
    }
}
