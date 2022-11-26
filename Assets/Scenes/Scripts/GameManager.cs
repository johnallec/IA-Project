using UnityEngine;
using it.unical.mat.embasp.platforms.desktop;
using it.unical.mat.embasp.languages.asp;
using it.unical.mat.embasp.specializations.dlv2.desktop;
using it.unical.mat.embasp.@base;
using progettoIA;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameOverUI;

    void Start()
    {
        GameIsOver = false;
        try
        {
            Handler handler = new DesktopHandler(new DLV2DesktopService("../../../executable/dlv2.win"));

            ASPMapper.Instance.RegisterClass(typeof(Prova));
            ASPMapper.Instance.RegisterClass(typeof(Res));

            InputProgram input = new ASPInputProgram();

            string rules = "res(Y) | notres(Y):- prova(_,Y). :~ res(Y).[Y@1]";

            input.AddProgram(rules);

            input.AddObjectInput(new Prova("1","2"));
            input.AddObjectInput(new Prova("1", "3"));

            handler.AddProgram(input);

            AnswerSets answerSets = (AnswerSets)handler.StartSync();

            foreach (AnswerSet answerSet in answerSets.GetOptimalAnswerSets())
            {

            }
            //Debug.Log(answerSets.GetOptimalAnswerSets().Count);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Source);
            Debug.Log(e.StackTrace);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameIsOver)
            return;

        //Function to manually end the game by pressing "e" for test purpouses
        if(Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }

        if(WaveSpawner.GameCompleted && WaveSpawner.EnemiesAlive == 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        
        gameOverUI.SetActive(true);
    }
}
