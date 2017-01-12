using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public interface DialogInterface
{
    void OnOkButtonClicked();
    void OnNoButtonClicked();
    void OnYesButtonClicked();
}

public class DialogUI : MonoBehaviour
{

    public GameObject yesButton;
    public GameObject okButton;
    public GameObject noButton;
    public Text messageText;

    DialogInterface dialog;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetMessage(string message)
    {
        messageText.text = message;
    }

    public void SetDialogType(bool isConfirmationDialog)
    {
        if (isConfirmationDialog)
        {
            okButton.SetActive(false);
            yesButton.SetActive(true);
            noButton.SetActive(true);
        }
        else
        {
            okButton.SetActive(true);
            yesButton.SetActive(false);
            noButton.SetActive(false);
        }
    }

    public void SetInterface(DialogInterface dialog)
    {
        this.dialog = dialog;
    }

    public void OnOkButtonClicked()
    {
        gameObject.SetActive(false);
        if (dialog != null)
            dialog.OnOkButtonClicked();
    }

    public void OnNoButtonClicked()
    {
        gameObject.SetActive(false);
        dialog.OnNoButtonClicked();
    }

    public void OnYesButtonClicked()
    {
        gameObject.SetActive(false);
        dialog.OnYesButtonClicked();
    }
}
