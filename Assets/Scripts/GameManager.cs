using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject HelpPanel;
    public GameObject SettingPanel;
    public GameObject CreditPanel;
   


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
       
        SceneManager.LoadScene("Stage1");
    }

    public void OpenHelpPanel()
    {
        // ���� â�� ����
        AudioManager.Instance.PlaySFX("Button");
        HelpPanel.SetActive(true);
    }

    public void CloseHelpPanel()
    {
        // ���� â�� ����
        AudioManager.Instance.PlaySFX("Close");
        HelpPanel.SetActive(false);
    }
    public void OpenSettingPanel()
    {
        // ���� â�� ����
        AudioManager.Instance.PlaySFX("Button");
        SettingPanel.SetActive(true);
    }
    public void CloseSettingPanel()
    {
        // ���� â�� ����
        AudioManager.Instance.PlaySFX("Close");
        SettingPanel.SetActive(false);
    }

    public void OpenCreditPanel()
    {
        // ���� â�� ����
        AudioManager.Instance.PlaySFX("Button");
        CreditPanel.SetActive(true);
    }

    public void CloseCreditPanel()
    {
        // ���� â�� ����
        AudioManager.Instance.PlaySFX("Close");
        CreditPanel.SetActive(false);
    }

    public void QuitGame()
    {
        // ���� ����
        Application.Quit();
    }

}