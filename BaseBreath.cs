using ConsoleLib.Console;
using System;
using System.Collections.Generic;
using System.Threading;
using XRL.Core;
using XRL.Rules;
using XRL.Messages;
using ConsoleLib.Console;

namespace XRL.World.Parts.Mutation
{
    [Serializable]
    public class ckBreathBase : BaseMutation
    {
        public string BodyPartType = "Face";
        public bool CreateObject = true;
        public GameObject FaceObject;
        public Guid ActivatedAbilityId = Guid.Empty;
        [NonSerialized]
        public string _CommandID;

        public override bool GeneratesEquipment() => this.CreateObject && this.GetFaceObject() != null;

        public ckBreathBase() => this.DisplayName = "[ckBreathBase::ckBreathBase()]";

        public string CommandID
        {
            get
            {
                if(this._CommandID == null)
                    this._CommandID = "ckBreath_" + this.GetType().Name;
                return this._CommandID;
            }
        }

        public virtual string GetFaceObject() => (string) null;

        public virtual string GetCommandDisplayName() => "[ckBreakBase::GetCommandDisplayName]";

        public override void Register(GameObject Object)
        {
            Object.RegisterPartEvent((IPart) this, this.CommandID);
            Object.RegisterPartEvent((IPart) this, "AIGetOffensiveMutationList");
        }
    }
}