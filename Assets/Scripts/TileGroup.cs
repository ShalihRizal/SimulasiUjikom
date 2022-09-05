using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class TileGroup : MonoBehaviour
{
    [SerializeField]
    private Transform gridPanel;

    [SerializeField]
    private Sprite bg;

    [SerializeField]
    private GameObject tileObject;

    [SerializeField]
    public string theme = "food";

    public RaycastManager raycastManager;

    [SerializeField]
    private Sprite[] puzzles;

    public List<Sprite> GamePuzzle = new List<Sprite>();

    public List<GameObject> TileList = new List<GameObject>();

    private bool firstGuess, secondGuess;

    private int countGuesses;

    private int countCorrectGuesses;

    private int gameGuesses;

    private string firstGuessPuzzle, secondGuessPuzzle;

    private int firstGuessIndex, secondGuessIndex;

    public string name;

    private void Start()
    {
        GetButtons();
        AddPairs();
        gameGuesses = GamePuzzle.Count / 2;
        Shuffle(GamePuzzle);
    }

    private void Awake()
    {
        puzzles = Resources.LoadAll<Sprite>("Sprites/" + theme);
    }

    void AddPairs()
    {
        int amount = TileList.Count;
        int index = 0;

        for (int i = 0; i < amount; i++)
        {
            if (index == amount / 2)
            {
                index = 0;
            }

            GamePuzzle.Add(puzzles[index]);
            index ++;
        }

    }

    public void SetName(string newName)
    {
        name = newName;
    }

    void OnEnable()
    {
        raycastManager.OnClicked += OnClicked;
    }

    void OnDisable()
    {
        raycastManager.OnClicked -= OnClicked;
    }

    void OnClicked()
    {
        int i;

        if (!firstGuess)
        {
            firstGuess = true;
            if (int.TryParse(name, out i))
            {
                firstGuessIndex = i;
            }

            firstGuessPuzzle = GamePuzzle[firstGuessIndex].name;

            TileList[firstGuessIndex].GetComponent<SpriteRenderer>().sprite = GamePuzzle[firstGuessIndex];
        }
        else if (!secondGuess)
        {
            secondGuess = true;
            if (int.TryParse(name, out i))
            {
                secondGuessIndex = i;
            }

            secondGuessPuzzle = GamePuzzle[secondGuessIndex].name;

            TileList[secondGuessIndex].GetComponent<SpriteRenderer>().sprite = GamePuzzle[secondGuessIndex];

            countGuesses++;

            StartCoroutine(CheckIfThePuzzleMatches());
        }
    }


    void GetButtons()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("TileObject");

        for (int i = 0; i < tiles.Length; i++)
        {
            TileList.Add(tiles[i].gameObject);
            TileList[i].GetComponent<SpriteRenderer>().sprite = bg;
        }
    }

    IEnumerator CheckIfThePuzzleMatches()
    {
        yield return new WaitForSeconds(.3f);

        if (firstGuessPuzzle == secondGuessPuzzle)
        {

            Destroy(TileList[firstGuessIndex].gameObject);
            Destroy(TileList[secondGuessIndex].gameObject);

            ChekIfTheGameFinishes();
        }
        else
        {
            yield return new WaitForSeconds(.3f);
            TileList[firstGuessIndex].GetComponent<SpriteRenderer>().sprite = bg;
            TileList[secondGuessIndex].GetComponent<SpriteRenderer>().sprite = bg;
        }

        firstGuess = secondGuess = false;

    }

    void ChekIfTheGameFinishes()
    {
        countCorrectGuesses++;

        if (countCorrectGuesses == gameGuesses)
        {
            Debug.Log("Game Finished");
            Debug.Log("You took " + countGuesses + " guesses to finish the game");
        }
    }

    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
