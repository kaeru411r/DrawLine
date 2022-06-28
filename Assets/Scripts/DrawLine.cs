using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DrawLine : MonoBehaviour
{
    [SerializeField] LineRenderer _lineRendererPrefab;

    List<LineRenderer> _lineRenderers = new List<LineRenderer>();
    List<Vector3> _positions = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _lineRenderers.Add(Instantiate(_lineRendererPrefab));
        }
        if (Input.GetButton("Fire1"))
        {
            Vector3 pos = Input.mousePosition;
            float near = Camera.main.nearClipPlane;
            _positions.Add(Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y,pos.z + near)));
            _lineRenderers.Last().positionCount = _positions.Count;
            _lineRenderers.Last().SetPositions(_positions.ToArray());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            _positions.Clear();
        }
    }
}
