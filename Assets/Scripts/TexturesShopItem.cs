using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Item", menuName = "Shop/Shop Item")]
public class TexturesShopItem : ScriptableObject
{
    public List<BodyPartTexturePair> formParts = new List<BodyPartTexturePair>();
}

[Serializable]
public struct BodyPartTexturePair
{
    public BodyPart bodyPart;
    public Texture texture;
}

[Serializable]
public enum BodyPart
{
    Head,
    Body,
    Handle_L,
    Handle_R,
    Leg_L,
    Leg_R
}