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
            base.Register(Object);
        }

        public override string GetDescription() => "[ckBreathBase::GetDescription]";

        public override string GetLevelText(int Level) => "[ckBreathBase::GetLevelText]\n";

        public virtual string GetColorString() => "M";

        public int GetConeLength(int L = -1) => L == -1 ? 2 + this.GetLevelText : 2 + L;

        public int GetConeAngle(int L = -1) => L == -1 ? 15 + 2 * this.GetLevelText : 15 + 2 * L;

        public virtual void BreathInCell(Cell C, ScreenBuffer Buffer, bool doEffect = true)
        {
        }

        public void DrawBreathInCell(Cell C, ScreenBuffer Buffer, string color1, string color2, string color3)
        {
            Buffer.Goto(C.X, C.Y);
            string str = "&G";
            int num1 = Stat.Random(1, 3);
            if (num1 == 1)
                str = "&" + color1;
            if (num1 == 2)
                str = "&" + color2;
            if (num1 == 3)
                str = "&" + color3;

            int num2 = Stat.Random(1, 3);
            if (num2 == 1)
                str = str + "^" + color1;
            if (num2 == 2)
                str = str + "^" + color2;
            if (num2 == 3)
                str = str + "^" + color3;

            if (C.ParentZone != XRLCore.Core.Game.ZoneManager.ActiveZone)
                return;
            Stat.Random(1, 3);
            Buffer.Write(str + ((char) (219 + Stat.Random(0, 4))).ToString());
            Popup._TextConsole.DrawBuffer(Buffer);
            Thread.Sleep(Math.Max(1, 15 - this.Level));
        }
    }
}