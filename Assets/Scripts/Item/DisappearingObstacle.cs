using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingObstacle : MonoBehaviour
{
    public int requiredFlashlightColor; // ������� ���� �ʿ��� ������ ���� �ε���
    public float fadeDuration = 2f; // ���ع��� ������� �� �ɸ��� �ð� (��)
    private Renderer objectRenderer; // ������Ʈ�� ������
    private Color originalColor; // ���� ����
    private bool isFading = false; // ���̵� ������ ����

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color;
        }
    }

    public void lightFlashed(int flashLightColor)
    {
        if (flashLightColor == requiredFlashlightColor && !isFading) // Ư�� ���� ������ ���� ���̵� �ƿ� ����
        {
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        isFading = true;
        float elapsedTime = 0f;
        Color fadeColor = originalColor;

        // Renderer�� ���� ���� Material�� ���� �� �����Ƿ� ��� Material�� ���� ���İ� ����
        Material[] materials = objectRenderer.materials;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            
            //���� ������鼭 ��������� �޽��������� ���İ� ����
            foreach (Material mat in materials)
            {
                fadeColor = mat.color;
                fadeColor.a = alpha;
                mat.color = fadeColor;
            }
            yield return null;
        }

        Destroy(gameObject); // ������Ʈ ����
    }
}