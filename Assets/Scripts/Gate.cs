using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject UpSide;
    public GameObject DownSide;

    public bool isRunning { 
        get {
            return _isRunning;
        }
    }

    SpriteRenderer _upSideSpriteRenderer;
    SpriteRenderer _downSideSpriteRenderer;
    BoxCollider2D _upSideCollider;
    BoxCollider2D _downSideCollider;
    BoxCollider2D _gateCollider;

    Vector2 _defaultPosition;
    bool _isRunning;

    void Awake()
    {
        _defaultPosition = transform.position;

        _upSideCollider = UpSide.GetComponent<BoxCollider2D>();
        _downSideCollider = DownSide.GetComponent<BoxCollider2D>();
        _upSideSpriteRenderer = UpSide.GetComponent<SpriteRenderer>();
        _downSideSpriteRenderer = DownSide.GetComponent<SpriteRenderer>();
        _gateCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_isRunning) {
            transform.position += (Vector3)(Vector2.left * GameManager.Instance.Roc.Speed * Time.deltaTime);

            if(transform.position.x <= -5f) {
                _isRunning = false;
                transform.position = _defaultPosition;
            }
        }
    }

    public void Init() {
        _isRunning = false;
        transform.position = _defaultPosition;
    }

    public void SetGateHeight() {
        float fullHeight = 9f;
        float gateHeight = 2.5f;

        float downSideHeight = Random.Range(2f, fullHeight - gateHeight - 2f);
        float landHeight = -4f;
        float upSideHeight = fullHeight - gateHeight - downSideHeight;

        DownSide.transform.position = new Vector2(DownSide.transform.position.x, landHeight + downSideHeight / 2f);
        _downSideCollider.size = new Vector2(_downSideCollider.size.x, downSideHeight);
        _downSideSpriteRenderer.size = new Vector2(_downSideSpriteRenderer.size.x, downSideHeight);

        _gateCollider.offset = new Vector2(0, landHeight + downSideHeight + gateHeight / 2f);

        UpSide.transform.position = new Vector2(UpSide.transform.position.x, landHeight + downSideHeight + gateHeight + upSideHeight / 2f);
        _upSideCollider.size = new Vector2(_upSideCollider.size.x, upSideHeight);
        _upSideSpriteRenderer.size = new Vector2(_upSideSpriteRenderer.size.x, upSideHeight);
    }

    public void Run() {
        _isRunning = true;
    }
}
