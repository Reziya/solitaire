using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockSpriteController : MonoBehaviour
{
    public Sprite resetPile;
    public Sprite cardBack;
    
    private SolitaireManager _solitaireManager;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _solitaireManager = GameObject
            .FindGameObjectWithTag("GameController")
            .GetComponent<SolitaireManager>();

        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ToggleSprite()
    {
        if (_solitaireManager.isStockEmpty)
            _spriteRenderer.sprite = resetPile;
        else
            _spriteRenderer.sprite = cardBack;
    }
}
