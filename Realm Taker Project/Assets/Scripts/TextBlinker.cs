using UnityEngine;
using TMPro; // Pakai ini kalau teks kamu TextMeshPro
using UnityEngine.UI; // Pakai ini kalau teks kamu UI Text biasa

public class TextBlinker : MonoBehaviour
{
    private TextMeshProUGUI teksTMP;
    private Text teksBiasa;

    [SerializeField] private float kecepatan = 1.0f;

    void Start()
    {
        teksTMP = GetComponent<TextMeshProUGUI>();
        teksBiasa = GetComponent<Text>();
    }

    void Update()
    {
        float alpha = Mathf.Lerp(0.1f, 1.0f, (Mathf.Sin(Time.time * kecepatan) + 1.0f) / 2.0f);

        if (teksTMP != null)
        {
            Color c = teksTMP.color;
            c.a = alpha;
            teksTMP.color = c;
        }
        else if (teksBiasa != null)
        {
            Color c = teksBiasa.color;
            c.a = alpha;
            teksBiasa.color = c;
        }
    }
}