using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int ImpressionScore = 0;
    [SerializeField]
    private int ImpressionGauge = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ImpressionGauge >= 100)
        {
            ImpressionGauge = ImpressionGauge - 100;
            ImpressionScore += 1;
        }
        else if(ImpressionGauge < 0)
        {
            ImpressionGauge = 100 + ImpressionGauge;
            ImpressionScore -= 1;
        }
    }
}
