using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    public Sprite cardBack;
    
    private SolitaireManager _solitaireManager;
    private CardItem _cardItem;

    private Sprite _cardFace;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        // The deck generated by SolitaireManager.GenerateDeck() 
        // is always in a specific order
        // cardFaces[] also corresponds to that order, 
        // so we can match the sprite to its object
        List<string> deck = SolitaireManager.GenerateDeck();
        
        _solitaireManager = GameObject
            .FindGameObjectWithTag("GameController")
            .GetComponent<SolitaireManager>();

        int i = 0;

        foreach (string card in deck)
        {
            if (this.name == card)
            {
                _cardFace = _solitaireManager.cardFaces[i];
                break;
            }

            i++;
        }

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _cardItem = GetComponent<CardItem>();
    }

    void Update()
    {
        if (_cardItem.isFaceUp)
            _spriteRenderer.sprite = _cardFace;
        else
            _spriteRenderer.sprite = cardBack;
    }

    public void ToggleHighlight(GameObject clickedObject)
    {
        SpriteRenderer clickedSR = clickedObject.GetComponent<SpriteRenderer>();

        if (clickedSR.color != Color.yellow)
            clickedSR.color = Color.yellow;
        else
            clickedSR.color = Color.white;
    }
}
