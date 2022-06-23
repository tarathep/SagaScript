﻿using System;
using System.Collections.Generic;
using System.Text;
using SagaLib;
using SagaDB.Actor;
using SagaMap.Scripting;
using SagaScript.Chinese.Enums;
namespace SagaScript.M30156000
{
    public class S11001066 : Event
    {
        public S11001066()
        {
            this.EventID = 11001066;
        }

        public override void OnEvent(ActorPC pc)
        {
            if (pc.Marionette != null)
            {
                Say(pc, 255, "$R這間房間涼快點吧。$R;" +
                    "我跟前面那位塞爾曼德先生$R正在調溫度。$R;");
                return;
            }
            Say(pc, 255, "……$R;");
        }
    }
}