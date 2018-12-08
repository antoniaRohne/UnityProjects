using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Shims;
using UnityEngine;

[Serializable]
public class GameData
{
   public GameData()
   {
      Shafts = new List<Shaft>();
   }

   public List<Shaft> Shafts;
}


