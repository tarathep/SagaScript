using System;
using System.Collections.Generic;
using System.Text;

using SagaDB.Actor;
using SagaMap.Scripting;
//所在地圖:行會宮殿4樓(30113000) NPC基本信息:技能商店(12001073) X:11 Y:24
namespace SagaScript.M30113000
{
    public class S12001073 : Event
    {
        public S12001073()
        {
            this.EventID = 12001073;
        }

        public override void OnEvent(ActorPC pc)
        {

        }
    }
}
