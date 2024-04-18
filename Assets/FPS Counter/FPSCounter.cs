using System.Collections;
using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    public float updateDelay = 0f;
    private float _targetFPS = 72f;
    private float _currentFPS = 0f;
    private float _deltaTime = 0f;

    private TextMeshProUGUI _textFPS;

    private Color acceptedColor = new Color32(0, 177, 215, 255);
    private Color critiqueColor = new Color32(200, 68, 125, 255);

    // Start is called before the first frame update
    void Start()
    {
        _textFPS = GetComponent<TextMeshProUGUI>();
        StartCoroutine(DisplayFramesPerSecond());
    }

    // Update is called once per frame
    void Update()
    {
        GenerateFramesPerSecond();
    }

    private void GenerateFramesPerSecond()
    {
        _deltaTime += (Time.unscaledDeltaTime - _deltaTime) * 0.01f;
        _currentFPS = 1.0f / _deltaTime;
    }

    private IEnumerator DisplayFramesPerSecond()
    {
        while (true)
        {
            if (_currentFPS >= _targetFPS)
            {
                _textFPS.color = acceptedColor;
            }
            else
            {
                _textFPS.color = critiqueColor; 
            }
            _textFPS.text = "FPS: " + _currentFPS.ToString(".0");
            yield return new WaitForSeconds(updateDelay);
        }
    }
}
