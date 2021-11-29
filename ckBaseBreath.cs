using ConsoleLib.Console;
using System;
using System.Collections.Generic;
using XRL.Core;
using XRL.Messages;
using XRL.Rules;
using XRL.UI;
using XRL.World.AI.GoalHandlers;

namespace XRL.World.Parts.Mutation
{
  [Serializable]
  public class ck_BaseBreath : BaseMutation
  {
    public Guid myAbilityId = Guid.Empty;
    public ActivatedAbilityEntry myAbility = null;
    public GameObject mySource;
    public int cooldown = 30;
    public string damageRoll = "2d2";
    public string[] attributes = { };

    [NonSerialized]
    protected char[] colors = { 'W', 'g'};

    [NonSerialized]
    protected char[] particles = { '\u00DC', '\u00DD', '\u00DE', '\u00DF' };
  }
}