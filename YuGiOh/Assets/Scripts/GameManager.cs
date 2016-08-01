﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.BattleHandler.Game;
using System;
using Assets.Scripts.BattleHandler.Cards;

public class GameManager : MonoBehaviour
{
    long frameCounter = long.MaxValue;
    static Player me;
    static Texture CardBackTexture;
    static NetworkManager netManager;

    List<Assets.Scripts.BattleHandler.Cards.Card> hand = new List<Assets.Scripts.BattleHandler.Cards.Card>();

    public static GameManager MakeManager(GameObject toAddTo, Player pMe, Texture CardBack, NetworkManager networkManager)
    {
        GameManager myManager = toAddTo.AddComponent<GameManager>();
        me = pMe;
        CardBackTexture = CardBack;
        netManager = networkManager;
        return myManager;
    }

    // Update is called once per frame
    void Update () {
        //Update every 1400 frames
        if (frameCounter > 5000)
        {
            placeMyHandCardsOnGUI();
            placeMyMonsterCardOnGUI();
            placeMyTrapsOnGUI();
            placeOpponentsMonstersOnGUI();
            placeOpponentsTrapsOnGUI();
            placeOpponentsHandOnGUI();
            frameCounter = 0;
        }
        frameCounter++;
	}

    ///Returns a monster card air tapped by user from his/her monster zone.
    public MonsterCard PromptForOneOfMyMonstersOnField()
    {
        //TODO CODE
        return null;
    }

    ///<summary>
    ///Returns either a face up monster card air tapped by user from his/her opponent's monster zone
    ///OR the index of a face down monster card air tapped by user from his/her opponent's monster zone
    ///</summary>
    public void PromptForOneOfOpponentsMonstersOnField(out MonsterCard faceUpMonster, out int faceDownMonsterIndex)
    {
        //TODO CODE
        faceUpMonster = null;
        faceDownMonsterIndex = -1;
    }

    ///<summary>
    ///Returns either a face up Spell/Trap card air tapped by user from his/her opponent's Spell/Trap zone
    ///OR the index of a face down Spell/Trap card air tapped by user from his/her opponent's Spell/Trap zone
    ///</summary>
    public void PromptForOneOfOpponentsSpellsOrTrapsOnField(out SpellAndTrapCard faceUpSpellOrTrap, out int faceDownSpellOrTrapIndex)
    {
        //TODO CODE
        faceUpSpellOrTrap = null;
        faceDownSpellOrTrapIndex = -1;
    }


    private void placeOpponentsHandOnGUI()
    {
        //throw new NotImplementedException();
    }

    private void placeOpponentsTrapsOnGUI()
    {
       // throw new NotImplementedException();
    }

    private void placeOpponentsMonstersOnGUI()
    {
        //throw new NotImplementedException();
    }

    private void placeMyTrapsOnGUI()
    {
       // throw new NotImplementedException();
    }

    private void placeMyMonsterCardOnGUI()
    {
       // throw new NotImplementedException();
    }

    private void placeMyHandCardsOnGUI()
    {
        hand = me.Hand;
        me.myGm = this;
        for(int i=0; i<hand.Count; i++)
        {
            if(i==0)
            {
                GameObject spawnPoint = GameObject.Find("Player1Hand1");
                //Destroy the Old Card
                var children = new List<GameObject>();
                foreach (Transform child in spawnPoint.transform) children.Add(child.gameObject);
                children.ForEach(child => Destroy(child));

                //Add The new Card
                GameObject cardGO = Resources.Load("Card") as GameObject;
                GameObject myCardGO = Instantiate(cardGO);
                myCardGO.transform.parent = spawnPoint.transform;
                myCardGO.transform.position = spawnPoint.transform.position;
                Debug.Log("Found Card GameObject, Loading specific Card");
                Card card = cardGO.GetComponent<Card>();
                if(me.Hand[i] is MonsterCard)
                {
                    card.attack = (me.Hand[i] as MonsterCard).AttackPoints;
                    card.defense = (me.Hand[i] as MonsterCard).DefensePoints;
                    card.CardType = "Monster";
                    card.level = (me.Hand[i] as MonsterCard).Level;
                    myCardGO.GetComponent<Renderer>().material.mainTexture = hand[i].CardImage;
                    myCardGO.transform.Find("CardBack").GetComponent<Renderer>().material.mainTexture = CardBackTexture;
                }
                else if(me.Hand[i] is SpellAndTrapCard)
                {
                    card.CardType = "Spell";
                    myCardGO.GetComponent<Renderer>().material.mainTexture = hand[i].CardImage;
                    myCardGO.transform.Find("CardBack").GetComponent<Renderer>().material.mainTexture = CardBackTexture;
                }
                /*
                GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                plane.transform.Rotate(90, 180, 0);
                Vector3 scale = new Vector3(0.035f, 0.05f, 0.05f);
                plane.transform.localScale = scale;
                plane.transform.position = spawnPoint.transform.position;
                plane.GetComponent<Renderer>().material.mainTexture = hand[0].CardImage;
                plane.transform.parent = spawnPoint.transform;
                plane.AddComponent<BoxCollider>();
                GameObject planeBack = GameObject.CreatePrimitive(PrimitiveType.Plane);
                planeBack.transform.Rotate(90, 0, 0);
                planeBack.transform.position = spawnPoint.transform.position;
                planeBack.transform.localScale = scale;
                planeBack.GetComponent<Renderer>().material.mainTexture = CardBackTexture;
                planeBack.transform.parent = spawnPoint.transform;*/
            }
            else if(i==1)
            {
                GameObject spawnPoint = GameObject.Find("Player1Hand2");
                //Destroy the Old Card
                var children = new List<GameObject>();
                foreach (Transform child in spawnPoint.transform) children.Add(child.gameObject);
                children.ForEach(child => Destroy(child));

                //Add The new Card
                GameObject cardGO = Resources.Load("Card") as GameObject;
                GameObject myCardGO = Instantiate(cardGO);
                myCardGO.transform.parent = spawnPoint.transform;
                myCardGO.transform.position = spawnPoint.transform.position;
                Debug.Log("Found Card GameObject, Loading specific Card");
                Card card = cardGO.GetComponent<Card>();
                if (me.Hand[i] is MonsterCard)
                {
                    card.attack = (me.Hand[i] as MonsterCard).AttackPoints;
                    card.defense = (me.Hand[i] as MonsterCard).DefensePoints;
                    card.CardType = "Monster";
                    card.level = (me.Hand[i] as MonsterCard).Level;
                    myCardGO.GetComponent<Renderer>().material.mainTexture = hand[i].CardImage;
                    myCardGO.transform.Find("CardBack").GetComponent<Renderer>().material.mainTexture = CardBackTexture;
                }
                else if (me.Hand[i] is SpellAndTrapCard)
                {
                    card.CardType = "Spell";
                    myCardGO.GetComponent<Renderer>().material.mainTexture = hand[i].CardImage;
                    myCardGO.transform.Find("CardBack").GetComponent<Renderer>().material.mainTexture = CardBackTexture;
                }
            }
            else if (i == 2)
            {
                GameObject spawnPoint = GameObject.Find("Player1Hand3");
                //Destroy the Old Card
                var children = new List<GameObject>();
                foreach (Transform child in spawnPoint.transform) children.Add(child.gameObject);
                children.ForEach(child => Destroy(child));

                //Add The new Card
                GameObject cardGO = Resources.Load("Card") as GameObject;
                GameObject myCardGO = Instantiate(cardGO);
                myCardGO.transform.parent = spawnPoint.transform;
                myCardGO.transform.position = spawnPoint.transform.position;
                Debug.Log("Found Card GameObject, Loading specific Card");
                Card card = cardGO.GetComponent<Card>();
                if (me.Hand[i] is MonsterCard)
                {
                    card.attack = (me.Hand[i] as MonsterCard).AttackPoints;
                    card.defense = (me.Hand[i] as MonsterCard).DefensePoints;
                    card.CardType = "Monster";
                    card.level = (me.Hand[i] as MonsterCard).Level;
                    myCardGO.GetComponent<Renderer>().material.mainTexture = hand[i].CardImage;
                    myCardGO.transform.Find("CardBack").GetComponent<Renderer>().material.mainTexture = CardBackTexture;
                }
                else if (me.Hand[i] is SpellAndTrapCard)
                {
                    card.CardType = "Spell";
                    myCardGO.GetComponent<Renderer>().material.mainTexture = hand[i].CardImage;
                    myCardGO.transform.Find("CardBack").GetComponent<Renderer>().material.mainTexture = CardBackTexture;
                }
            }
            else if (i == 3)
            {
                GameObject spawnPoint = GameObject.Find("Player1Hand4");
                //Destroy the Old Card
                var children = new List<GameObject>();
                foreach (Transform child in spawnPoint.transform) children.Add(child.gameObject);
                children.ForEach(child => Destroy(child));

                //Add The new Card
                GameObject cardGO = Resources.Load("Card") as GameObject;
                GameObject myCardGO = Instantiate(cardGO);
                myCardGO.transform.parent = spawnPoint.transform;
                myCardGO.transform.position = spawnPoint.transform.position;
                Debug.Log("Found Card GameObject, Loading specific Card");
                Card card = cardGO.GetComponent<Card>();
                if (me.Hand[i] is MonsterCard)
                {
                    card.attack = (me.Hand[i] as MonsterCard).AttackPoints;
                    card.defense = (me.Hand[i] as MonsterCard).DefensePoints;
                    card.CardType = "Monster";
                    card.level = (me.Hand[i] as MonsterCard).Level;
                    myCardGO.GetComponent<Renderer>().material.mainTexture = hand[i].CardImage;
                    myCardGO.transform.Find("CardBack").GetComponent<Renderer>().material.mainTexture = CardBackTexture;
                }
                else if (me.Hand[i] is SpellAndTrapCard)
                {
                    card.CardType = "Spell";
                    myCardGO.GetComponent<Renderer>().material.mainTexture = hand[i].CardImage;
                    myCardGO.transform.Find("CardBack").GetComponent<Renderer>().material.mainTexture = CardBackTexture;
                }
            }
            else if (i == 4)
            {
                GameObject spawnPoint = GameObject.Find("Player1Hand5");
                //Destroy the Old Card
                var children = new List<GameObject>();
                foreach (Transform child in spawnPoint.transform) children.Add(child.gameObject);
                children.ForEach(child => Destroy(child));

                //Add The new Card
                GameObject cardGO = Resources.Load("Card") as GameObject;
                GameObject myCardGO = Instantiate(cardGO);
                myCardGO.transform.parent = spawnPoint.transform;
                myCardGO.transform.position = spawnPoint.transform.position;
                Debug.Log("Found Card GameObject, Loading specific Card");
                Card card = cardGO.GetComponent<Card>();
                if (me.Hand[i] is MonsterCard)
                {
                    card.attack = (me.Hand[i] as MonsterCard).AttackPoints;
                    card.defense = (me.Hand[i] as MonsterCard).DefensePoints;
                    card.CardType = "Monster";
                    card.level = (me.Hand[i] as MonsterCard).Level;
                    myCardGO.GetComponent<Renderer>().material.mainTexture = hand[i].CardImage;
                    myCardGO.transform.Find("CardBack").GetComponent<Renderer>().material.mainTexture = CardBackTexture;
                }
                else if (me.Hand[i] is SpellAndTrapCard)
                {
                    card.CardType = "Spell";
                    myCardGO.GetComponent<Renderer>().material.mainTexture = hand[i].CardImage;
                    myCardGO.transform.Find("CardBack").GetComponent<Renderer>().material.mainTexture = CardBackTexture;
                }
            }
            else if (i == 5)
            {
                GameObject spawnPoint = GameObject.Find("Player1Hand6");
                //Destroy the Old Card
                var children = new List<GameObject>();
                foreach (Transform child in spawnPoint.transform) children.Add(child.gameObject);
                children.ForEach(child => Destroy(child));

                //Add The new Card
                GameObject cardGO = Resources.Load("Card") as GameObject;
                GameObject myCardGO = Instantiate(cardGO);
                myCardGO.transform.parent = spawnPoint.transform;
                myCardGO.transform.position = spawnPoint.transform.position;
                Debug.Log("Found Card GameObject, Loading specific Card");
                Card card = cardGO.GetComponent<Card>();
                if (me.Hand[i] is MonsterCard)
                {
                    card.attack = (me.Hand[i] as MonsterCard).AttackPoints;
                    card.defense = (me.Hand[i] as MonsterCard).DefensePoints;
                    card.CardType = "Monster";
                    card.level = (me.Hand[i] as MonsterCard).Level;
                    myCardGO.GetComponent<Renderer>().material.mainTexture = hand[i].CardImage;
                    myCardGO.transform.Find("CardBack").GetComponent<Renderer>().material.mainTexture = CardBackTexture;
                }
                else if (me.Hand[i] is SpellAndTrapCard)
                {
                    card.CardType = "Spell";
                    myCardGO.GetComponent<Renderer>().material.mainTexture = hand[i].CardImage;
                    myCardGO.transform.Find("CardBack").GetComponent<Renderer>().material.mainTexture = CardBackTexture;
                }
            }
        }
    }
}
