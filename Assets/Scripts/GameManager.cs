using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject HelpPanel;
    public GameObject SettingPanel;

    void Start()
    {
        Cursor.visible = true; // Ŀ���� ���̰� ����
        Cursor.lockState = CursorLockMode.None; // Ŀ�� ��� ����
        // ���� ���� �� ���� â�� ��Ȱ��ȭ
        HelpPanel.SetActive(false);
        SettingPanel.SetActive(false);
    }

    public void StartGame()
    {
        // Scene 1�� �ε����� �ҷ��ͼ� �ش� Scene���� ��ȯ
        SceneManager.LoadScene("Stage1");
    }

    public void OpenHelpPanel()
    {
        // ���� â�� ����
        HelpPanel.SetActive(true);
    }

    public void CloseHelpPanel()
    {
        // ���� â�� ����
        HelpPanel.SetActive(false);
    }
    public void OpenSettingPanel()
    {
        // ���� â�� ����
        SettingPanel.SetActive(false);
    }
    public void CloseSettingPanel()
    {
        // ���� â�� ����
        SettingPanel.SetActive(false);
    }

    public void QuitGame()
    {
        // ���� ����
        Application.Quit();
    }

    public void nextStage()
    {
        // Scene 1�� �ε����� �ҷ��ͼ� �ش� Scene���� ��ȯ
        SceneManager.LoadScene("Stage2");
    }
}