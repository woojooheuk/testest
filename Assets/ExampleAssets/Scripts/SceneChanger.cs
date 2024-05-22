using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리 기능을 사용하기 위해 필요

public class SceneChanger : MonoBehaviour
{
    // 로드할 씬의 이름을 인스펙터에서 지정할 수 있도록
    public string sceneName;

    // 이 함수가 버튼 클릭 이벤트로 연결될 것입니다.
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

