using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed;

    private RawImage _background;
    private float _imagePositionX;

    private void Start()
    {
        _background = GetComponent<RawImage>();
        _imagePositionX = _background.uvRect.x;
    }

    private void Update()
    {
        _imagePositionX += _speed * Time.deltaTime;

        _background.uvRect = new Rect(_imagePositionX, 0, _background.uvRect.width, _background.uvRect.height);
    }
}
