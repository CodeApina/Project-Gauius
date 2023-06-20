using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Rendering;

public class Item_Controller : MonoBehaviour
{
    private Item item = new Item();
    public Item_Stats item_stats;
    public Sprite item_sprite;
    public SpriteRenderer item_renderer;
    public List<Item_Tag> tags;
    [SerializeField] public List<Item_Modifier> modifiers;
    public float level;
    public string rarity;
    // Start is called before the first frame update
    void Start()
    {
        item_renderer = gameObject.GetComponent<SpriteRenderer>();
        item_renderer.sprite = item_sprite;
        item_stats = item.Generate_Item(26f);
        tags = item_stats.tags;
        modifiers = item_stats.modifiers;
        level = item_stats.level;
        rarity = item_stats.rarity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
