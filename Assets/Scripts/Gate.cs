using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [Header("Object")]
    public GameObject UpGate;
    public GameObject DownGate;

    [Header("Value")]
    public float CeilingHeight = 10f;
    public float BarrelMinHeight = 2f;

    public bool isRunning { 
        get {
            return _isRunning;
        }
    }

    SpriteRenderer _upGateSpriteRenderer;
    SpriteRenderer _downGateSpriteRenderer;
    BoxCollider2D _upGateCollider;
    BoxCollider2D _downGateCollider;
    BoxCollider2D _gateCollider;

    Vector2 _defaultPosition;
    float _gateYMin;
    float _gateYMax;

    bool _isRunning;

    void Awake()
    {
        _upGateCollider = UpGate.GetComponent<BoxCollider2D>();
        _downGateCollider = DownGate.GetComponent<BoxCollider2D>();
        _upGateSpriteRenderer = UpGate.GetComponent<SpriteRenderer>();
        _downGateSpriteRenderer = DownGate.GetComponent<SpriteRenderer>();
        _gateCollider = GetComponent<BoxCollider2D>();

        _defaultPosition = transform.position;

        _gateYMin = BarrelMinHeight + _gateCollider.size.y / 2f;
        _gateYMax = CeilingHeight - BarrelMinHeight - _gateCollider.size.y / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isRunning) {
            transform.position += (Vector3)(Vector2.left * GameManager.Instance.Roc.Speed * Time.deltaTime);

            if(transform.localPosition.x <= 0) {
                _isRunning = false;
                transform.position = _defaultPosition;
            }
        }
    }

    public void Init() {
        _isRunning = false;
        transform.position = _defaultPosition;
    }

    public void RandomizeGatePosition() {
        float gateYOffset = Random.Range(_gateYMin, _gateYMax);
        _gateCollider.offset = new Vector2(_gateCollider.offset.x, gateYOffset);

        float downHeight = _gateCollider.bounds.min.y;
        float upHeight = CeilingHeight - _gateCollider.bounds.max.y;

        DownGate.transform.position = new Vector2(DownGate.transform.position.x, downHeight / 2f);
        _downGateCollider.size = new Vector2(_downGateCollider.size.x, downHeight - _downGateCollider.edgeRadius * 2f);
        _downGateSpriteRenderer.size = new Vector2(_downGateSpriteRenderer.size.x, downHeight);

        UpGate.transform.position = new Vector2(UpGate.transform.position.x, CeilingHeight - upHeight / 2f);
        _upGateCollider.size = new Vector2(_upGateCollider.size.x, upHeight - _upGateCollider.edgeRadius * 2f);
        _upGateSpriteRenderer.size = new Vector2(_upGateSpriteRenderer.size.x, upHeight);
    }

    public void Run() {
        _isRunning = true;
    }
}
