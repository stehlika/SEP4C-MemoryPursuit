using System.Collections;
using System.Collections.Generic;
using Application;
using UnityEngine;

public class DataManament : MonoBehaviour
{

    public List<string> Cities = new List<string>();
    public List<string> Words = new List<string>();
    public List<string> Names = new List<string>();
    public List<string> Numbers = new List<string>();
    public List<string> Airports = new List<string>();

    [SerializeField] public List<string> elements;
    [SerializeField] public GameType gameType;
    [SerializeField] public double rememberElementsTime;
    [SerializeField] public Difficulty difficulty = Difficulty.Easy;

    [SerializeField] public int easyElementsCount = 6;
    [SerializeField] public int moderateElementsCount = 9;
    [SerializeField] public int hardElementsCount = 11;

    [SerializeField] public int easyElementsCountVerify = 1;
    [SerializeField] public int moderateElementsCountVerify = 3;
    [SerializeField] public int hardElementsCountVerify = 5;
    [SerializeField] public int counter = 0;

    [SerializeField] public int userScore = 0;

    private static DataManament _instance;

    public static DataManament Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
            LoadData();
        }
        else if (_instance != this)
            Destroy(gameObject);
    }

    private void LoadData()
    {
        Cities.Clear();
        Names.Clear();
        Words.Clear();
        Numbers.Clear();
        Airports.Clear();
        LoadNames();
        LoadWords();

        for (int i = 0; i < 60; i++)
        {
            Cities.Add("City" + i);
            Numbers.Add(Helpers.Range(99, 1000).ToString());
            Airports.Add("Airport" + i);
        }

        Cities.Add("Lisabon");
        Cities.Add("Copenhagen");
        Cities.Add("Horsens");
        Cities.Add("Madrid");
        Cities.Add("Belo Horizonte");
        Cities.Add("Zilina");
        Cities.Add("Myjava");

        Numbers.Add("12657");
        Numbers.Add("24134");
        Numbers.Add("534534");
        Numbers.Add("5345");
        Numbers.Add("12657");
        Numbers.Add("33");

        Airports.Add("CPH");
        Airports.Add("CPG");
        Airports.Add("BRA");
        Airports.Add("VIE");
        Airports.Add("FRX");
        Airports.Add("BLL");

    }

    public List<string> GetLevelElements(GameType gameType)
    {
        if (gameType == GameType.Airports)
            return GetElementsForDifficulty(Airports);
        else if (gameType == GameType.Cities)
            return GetElementsForDifficulty(Cities);
        else if (gameType == GameType.Names)
            return GetElementsForDifficulty(Names);
        else if (gameType == GameType.Numbers)
            return GetElementsForDifficulty(Numbers);
        else
            return GetElementsForDifficulty(Words);
    }

    private List<string> GetElementsForDifficulty(List<string> ele)
    {
        List<string> finalElements = new List<string>();

        if (difficulty == Difficulty.Easy)
            for (int i = 0; i <= easyElementsCount; i++)
                finalElements.Add(ele[Helpers.Range(0, ele.Count)]);

        if (difficulty == Difficulty.Moderate)
            for (int i = 0; i <= moderateElementsCount; i++)
                finalElements.Add(ele[Helpers.Range(0, ele.Count)]);

        if (difficulty == Difficulty.Hard)
            for (int i = 0; i <= hardElementsCount; i++)
                finalElements.Add(ele[Helpers.Range(0, ele.Count)]);

        return finalElements;
    }


    public List<string> GetLevelElementsForVerification()
    {
        Debug.LogWarning("sme vosli do funkcie" + elements.Count);

        List<string> finalElements = new List<string>();

        finalElements = elements;
        foreach (string ele in finalElements)
            Debug.Log("element:" + ele);

        if (gameType == GameType.Airports)
            finalElements.AddRange(GetElementsForDifficultyForVerification(Airports));
        else if (gameType == GameType.Cities)
            finalElements.AddRange(GetElementsForDifficultyForVerification(Cities));
        else if (gameType == GameType.Names)
            finalElements.AddRange(GetElementsForDifficultyForVerification(Names));
        else if (gameType == GameType.Numbers)
            finalElements.AddRange(GetElementsForDifficultyForVerification(Numbers));
        else
            finalElements.AddRange(GetElementsForDifficultyForVerification(Words));

        foreach (string ele in finalElements)
            Debug.Log("final element:" + ele);

        return finalElements;
    }

    private List<string> GetElementsForDifficultyForVerification(List<string> ele)
    {
        List<string> finalElements = new List<string>();

        if (difficulty == Difficulty.Easy)
        {
            for (int i = 0; i <= easyElementsCountVerify; i++)
                finalElements.Add(ele[Helpers.Range(0, ele.Count)]);
        }

        if (difficulty == Difficulty.Moderate)
        {
            for (int i = 0; i <= moderateElementsCountVerify; i++)
                finalElements.Add(ele[Helpers.Range(0, ele.Count)]);
        }

        if (difficulty == Difficulty.Hard)
        {
            for (int i = 0; i <= hardElementsCountVerify; i++)
                finalElements.Add(ele[Helpers.Range(0, ele.Count)]);
        }
        return finalElements;
    }

    private void LoadNames()
    {
        Names.Add("Bernie");
        Names.Add("Horace");
        Names.Add("Ferdinand");
        Names.Add("Everette");
        Names.Add("Emory");
        Names.Add("Newton");
        Names.Add("Domingo");
        Names.Add("Eddy");
        Names.Add("Marcos");
        Names.Add("Antwan");
        Names.Add("Diego");
        Names.Add("Sammie");
        Names.Add("Long");
        Names.Add("Bryce");
        Names.Add("Toby");
        Names.Add("Jamie");
        Names.Add("Keven");
        Names.Add("Peter");
        Names.Add("Federico");
        Names.Add("Kristopher");
        Names.Add("Avery");
        Names.Add("Abram");
        Names.Add("Eduardo");
        Names.Add("Luciano");
        Names.Add("Lyman");
        Names.Add("Lyndon");
        Names.Add("Kenton");
        Names.Add("Gerard");
        Names.Add("Chas");
        Names.Add("Stuart");
        Names.Add("Lester");
        Names.Add("Phebe");
        Names.Add("Pok");
        Names.Add("Dia");
        Names.Add("Delmy");
        Names.Add("Caron");
        Names.Add("Raguel");
        Names.Add("Trista");
        Names.Add("Tasha");
        Names.Add("Delfina");
        Names.Add("Cindie");
        Names.Add("Laurena");
        Names.Add("Khadijah");
        Names.Add("Blanca");
        Names.Add("Digna");
        Names.Add("Masako");
        Names.Add("Luci");
        Names.Add("Darci");
        Names.Add("Suk");
        Names.Add("Hedwig");
        Names.Add("Latarsha");
    }

    private void LoadWords()
    {
        Words.Add("obnouncing");
        Words.Add("formational");
        Words.Add("oversalt");
        Words.Add("terr");
        Words.Add("emissary");
        Words.Add("spissatus");
        Words.Add("haltingness");
        Words.Add("bosket");
        Words.Add("notaryship");
        Words.Add("koniology");
        Words.Add("idioplasmic");
        Words.Add("precerebral");
        Words.Add("estrin");
        Words.Add("cimbric");
        Words.Add("scrumptious");
        Words.Add("stagy");
        Words.Add("proprietorship");
        Words.Add("exaggeratory");
        Words.Add("undertribe");
        Words.Add("intensification");
        Words.Add("lexicon");
        Words.Add("mendelian");
        Words.Add("logperches");
        Words.Add("kyanised");
        Words.Add("axially");
        Words.Add("achromatism");
        Words.Add("cranky");
        Words.Add("underhill");
        Words.Add("nonphotographic");
        Words.Add("frigidoreceptor");
        Words.Add("heliograph");
        Words.Add("crackliest");
        Words.Add("rickwood");
        Words.Add("undervillain");
        Words.Add("papyraceous");
        Words.Add("regularize");
        Words.Add("underfeature");
        Words.Add("immanuel");
        Words.Add("hardtop");
        Words.Add("miscoin");
        Words.Add("foy");
        Words.Add("resaddle");
        Words.Add("pacifism");
        Words.Add("shorthand");
        Words.Add("knacker");
        Words.Add("abhenry");
        Words.Add("zikkurat");
        Words.Add("nondepletion");
        Words.Add("seaboard");
        Words.Add("nonfreeman");
    }
}
