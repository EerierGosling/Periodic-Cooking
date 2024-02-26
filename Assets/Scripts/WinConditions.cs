using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System;


public class WinConditions : MonoBehaviour
{
    public int numClones = 0;

    public List<string> addedIngredients = new List<string>();

    private List<string> neededIngredients = new List<string>();

    public Dictionary<string, string> symbols = new Dictionary<string, string>{ {"salt", "Sa"}, {"avocado", "Av"}, {"banana", "Ba"}, {"blueberries", "Bl"}, {"brocoli", "Br"}, {"carrots", "Ca"}, {"corn", "Co"}, {"cucumber", "Cu"}, {"egg", "Eg"}, {"flour", "Fl"}, {"garlic", "Ga"}, {"milk", "Mi"}, {"mushroom", "Mu"}, {"oil", "Oi"}, {"peas", "Pa"}, {"potato", "Po"}, {"squash", "Sq"}, {"sugar", "Su"}, {"tomato", "To"}, {"watermelon", "Wa"}, {"water", "Wt"}, {"yam", "Ya"}, {"zucchini", "Zu"}};

    public GameObject[] recipies;

    public List<string>[] recipie_ingredients = {
        new List<string>{"brocoli", "brocoli", "mushrooms", "brocoli", "brocoli", "mushrooms", "brocoli", "brocoli", "mushrooms", "pepper", "oil", "salt"}, 
        new List<string>{"flour", "flour", "salt", "flour", "flour", "salt", "sugar", "tomato", "tomato", "oil"}, 
        new List<string>{"flour", "sugar", "flour", "sugar", "flour", "sugar", "carrots", "carrots", "eggs", "oil", "oil", "eggs", "oil", "oil"}, 
        new List<string>{"flour", "flour", "sugar", "flour", "flour", "sugar", "flour", "flour", "sugar", "banana", "eggs", "banana", "eggs"}, 
        new List<string>{"tomato", "sugar", "tomato", "sugar", "pepper", "salt", "water", "water", "water"},
        new List<string>{"potato", "potato", "potato", "flour", "oil", "oil", "salt", "oil", "oil", "salt"}
    };

    // Start is called before the first frame update
    void Start()
    {
        ChooseRecipie();

        neededIngredients = neededIngredients.OrderBy(x => x).ToList();
    }

    // Update is called once per frame
    void Update()
    {

        if (addedIngredients.SequenceEqual(neededIngredients)) {
            SceneManager.LoadScene("Win Screen");
        }

    }

    public void OrderIngredients() {
        addedIngredients = addedIngredients.OrderBy(x => x).ToList();
    }

    public void ChooseRecipie() {

        int randomInt = (int)(recipies.Length*(new System.Random().NextDouble()));

        neededIngredients = recipie_ingredients[randomInt];

        Instantiate(recipies[randomInt]);

    }
}
