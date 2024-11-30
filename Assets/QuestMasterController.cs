using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestMasterController : MonoBehaviour
{
    [SerializeField]
    private List<QuestController> questControllers;

    [SerializeField]
    private Transform packageIconTransform;

    [SerializeField]
    private GameObject packageUIIcon;

    [SerializeField]
    private MenuPanelController gameWonPanelController;

    private int packageIndex = 0;

    private List<GameObject> packageIcons = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(QuestController questController in questControllers) {
            questController.OnQuestComplete += HidePackage;
            GameObject package = Instantiate(packageUIIcon, packageIconTransform);
            packageIcons.Add(package);
        }

        gameWonPanelController.OnPanelOpen += CameraController.Instance.UnlockCursor;
        gameWonPanelController.OnPanelClosed += CameraController.Instance.LockCursor;
    }

    private void HidePackage()
    {
        if(packageIndex >= packageIcons.Count) {
            return;
        }

        packageIcons[packageIndex++].gameObject.SetActive(false);

        if(packageIndex == packageIcons.Count) {
            gameWonPanelController.Open();
        }
    }
}
