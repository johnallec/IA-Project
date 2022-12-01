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
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return;

        //Function to manually end the game by pressing "e" for test purpouses
        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }

        if (WaveSpawner.GameCompleted && WaveSpawner.EnemiesAlive == 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;

        gameOverUI.SetActive(true);
    }

    void EmbASP()
    {
        try
        {
            Handler handler = new DesktopHandler(new DLV2DesktopService(Application.dataPath + "/dlv-2.1.1-win64.exe"));

            ASPMapper.Instance.RegisterClass(typeof(Torre));
            ASPMapper.Instance.RegisterClass(typeof(Res));
            ASPMapper.Instance.RegisterClass(typeof(NotRes));

            InputProgram input = new ASPInputProgram();

            //string rules = "res(Y) | notres(Y):- prova(_,Y). :~ res(Y).[Y@1]";

            string rules = "livelloTorretta(L,T):- torre(1,T,L,_,_,_)." +
                   "moneteSpese(MS):- #sum{CostoTorre,Piattaforma : attivata(Piattaforma), torre(_,Piattaforma,_,_,CostoTorre,_)} = MS1."
                   +
                   "attivata(Piattaforma) | nonAttivata(Piattaforma):- torre(0,Piattaforma,_,_,CostoTorre,_), monete(M), CostoTorre <= M."
                   +
                   ":- monete(M), moneteSpese(MS), MS > M.";

            input.AddProgram(rules);

            input.AddObjectInput(new Prova(1, 2));
            input.AddObjectInput(new Prova(1, 3));

            handler.AddProgram(input);

            AnswerSets answerSets = (AnswerSets)handler.StartSync();

            foreach (AnswerSet answerSet in answerSets.GetOptimalAnswerSets())
            {
                foreach (object obj in answerSet.Atoms)
                {
                    //Debug.Log(typeof(obj));
                    if (obj is NotRes)
                    {
                        NotRes res = (NotRes)obj;
                        Debug.Log(res.toString());
                    }
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.Log("------------------------------------------ ERROR ------------------------------------------");
            Debug.Log(e.Source);
            Debug.Log(e.StackTrace);
        }
    }
}
