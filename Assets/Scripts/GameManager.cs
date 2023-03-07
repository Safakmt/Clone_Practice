using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField] private FinishLine finishLine;
    [SerializeField] public UiManager uiManager;
    [SerializeField] private PlayerMove player;
    [SerializeField] private CameraFollow followCam;
    [SerializeField] private BackBorder backBorder;

    [Header("Time Settings")]
    [SerializeField] private float slowTimeAmount;
    [Header("Levels")]
    [SerializeField] private List<GameObject> Levels;
    [SerializeField] private Transform instantiatePlace;

    private Vector3 playerTransform;
    private Vector3 camTransform;
    private Vector3 borderTransform;

    private GameObject currentLevel;
    private int currentLevelIndex = 0;

    public static GameManager Instance;


    private void Awake()
    {
        SingletonInstanceGeneration();
        InitialPositionSave();
        uiManager.ProgresBarValues(player.transform.position.z, finishLine.transform.position.z, player.transform.position.z);
    }

    private void SingletonInstanceGeneration()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    void Start()
    {
        player.isGameStarted = false;
        currentLevel = Instantiate(Levels[currentLevelIndex], instantiatePlace);
    }

    void Update()
    {
        uiManager.ProgresBarUpdate(player.transform.position.z);
    }

    public void PlayerDeadOperations()
    {
        SlowTimeToggle(true);
        StartCoroutine(PlayerDeadCoroutine());
    }

    private IEnumerator PlayerDeadCoroutine()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        uiManager.RestartCanvasToggle(true);
    }

    void SlowTimeToggle(bool state)
    {
        if (state)
        {
            Time.timeScale = slowTimeAmount;
            Time.fixedDeltaTime = 0.02f * slowTimeAmount;

        }
        else
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
        }
    }

    public void GameStartBtn()
    {
        uiManager.StartCanvasToggle(false);
        player.isGameStarted = true;
        backBorder.StartMove(true);
        followCam.StartMove(true);
    }

    public void GameRestartBtn()
    {
        uiManager.RestartCanvasToggle(false);
        Destroy(currentLevel);
        currentLevel = Instantiate(Levels[currentLevelIndex], instantiatePlace);
        player.isDead = false;
        player.ZeroVelocity();
        BackToInitialPositions();
        player.isGameStarted = true;
        backBorder.StartMove(true);
        followCam.StartMove(true);
        SlowTimeToggle(false);
    }
    public void ButtonWorking()
    {
        Debug.Log("works");
    }
    public void NextLevelBtn()
    {
        uiManager.FinishCanvasToggle(false);
        Destroy(currentLevel);
        currentLevelIndex++;
        currentLevel = Instantiate(Levels[currentLevelIndex], instantiatePlace);
        player.ZeroVelocity();
        BackToInitialPositions();
        SlowTimeToggle(false);
    }

    public void GameFinish()
    {
        uiManager.FinishCanvasToggle(true);
        SlowTimeToggle(true);
    }

    public void BackToInitialPositions()
    {
        player.transform.position = playerTransform;
        backBorder.transform.position = borderTransform;
        followCam.transform.position = camTransform;
    }

    public void InitialPositionSave()
    {
        playerTransform = player.transform.position;
        borderTransform = backBorder.transform.position;
        camTransform = followCam.transform.position;
    }
}
