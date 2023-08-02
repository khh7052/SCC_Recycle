using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : Singleton<Fading>
{

    public Texture2D fadeOutTexture;   // 화면을 오버레이하는 텍스처. 검은 색 이미지 또는 로딩 그래픽 일 수 있습니다.
    public float fadeSpeed = 0.8f;     // 페이딩 속도

    private int drawDeath = -10000;    // 그리기 계층 구조에서 텍스처의 순서입니다.숫자가 낮으면 맨 위에 렌더링됩니다.
    private float alpha = 1.0f;        // 0에서 1 사이의 텍스처의 알파 값
    private int fadeDir = -1;          // 페이드하는 방향 : in = -1 또는 out = 1

    void OnGUI()
    {
        // 페이드 아웃 / 알파 값에서 방향, 속도 및 Time.deltatime을 사용하여 작업을 초 단위로 변환합니다.
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        // GUI.color가 0과 1 사이의 알파 값을 사용하기 때문에 0과 1 사이의 수를 강제로(클램프)합니다.
        alpha = Mathf.Clamp01(alpha);

        // GUI의 색상을 설정합니다(이 경우 텍스처).모든 색상 값은 동일하게 유지되고 알파는 알파 변수로 설정됩니다.
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);               // 알파 값을 설정합니다.
        GUI.depth = drawDeath;                                                             // 검은 색 텍스처를 맨 위에 렌더링합니다(마지막에 그려야 함).
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);      // 전체 화면 영역에 맞게 텍스처를 그립니다.
    }

    // fadeDIr을 방향 매개 변수로 설정하여 -1이면 장면이 희미해지며 1이면 출력됩니다.
    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return 1.0f / fadeSpeed;    // fadeSpeed ​​변수를 반환하여 Application.LoadLevel()에 사용;
    }

    // OnLevelWasLoaded는 레벨이로드 될 때 호출됩니다. 매개 변수로로드 된 수준 인덱스 (int)를 사용하여 특정 장면으로 페이드 인을 제한 할 수 있습니다.
    void OnLevelWasLoaded()
    {
        alpha = 1; //alpha가 기본적으로 1로 설정되지 않은 경우 // 사용
        BeginFade(-1); // 페이드 인 함수를 호출합니다.
    }


    public void Morning_Stage1_down(string sceneName)
    {
        SoundManager.Instance.StopBGM();
        StartCoroutine(Morning_Stage1(sceneName));
    }

    public IEnumerator Morning_Stage1(string sceneName)
    {
        // fade out the game and load new level
        // float fadeTime = GameObject.Find("Fading").GetComponent<Fading>().BeginFade(1);
        BeginFade(1);
        float fadeTime = 1.0f / fadeSpeed;
        yield return new WaitForSeconds(fadeTime);
        LoadingSceneManager.LoadScene(sceneName);
    }
}
