﻿using System;
using System.Collections.Generic;
using System.Text;
using SagaLib;
using SagaDB.Actor;
using SagaMap.Scripting;
using SagaScript.Chinese.Enums;
namespace SagaScript.M30013001
{
    public class S11000277 : Event
    {
        public S11000277()
        {
            this.EventID = 11000277;
        }

        public override void OnEvent(ActorPC pc)
        {
            //int selection;
            if (CountItem(pc, 10015701) >= 1 &&
                CountItem(pc, 10015702) >= 1 &&
                CountItem(pc, 10015800) >= 1)
            {
                Say(pc, 131, "呵呵，$R;" +
                    "是很稀有的鐵呢。$R;" +
                    "有十個的話就可以製做$R;" +
                    "要做嗎？$R;");
                switch (Select(pc, "要做嗎？", "", "製造鹽鐵", "製造鬼鐵", "製造鏡鐵", "算了"))
                {
                    case 1:
                        if (CountItem(pc, 10015701) >= 10)
                        {
                            switch (Select(pc, "要做哪個部分的防具呢？", "", "甲衣", "頭盔", "鞋子", "靴子", "算了"))
                            {
                                case 1:
                                    if (CheckInventory(pc, 60001900, 1))
                                    {
                                        TakeItem(pc, 10015701, 10);
                                        GiveItem(pc, 60001900, 1);
                                        //FADE OUT BLACK
                                        Wait(pc, 1000);
                                        PlaySound(pc, 2216, false, 100, 50);
                                        PlaySound(pc, 2216, false, 100, 50);
                                        PlaySound(pc, 2216, false, 100, 50);
                                        Wait(pc, 1000);
                                        //FADE IN
                                        Say(pc, 131, "來，都搞定了！$R;");
                                        return;
                                    }
                                    Say(pc, 131, "真是！$R;" +
                                        "$R行李太多了，整理後再來吧！$R;");
                                    break;
                                case 2:
                                    if (CheckInventory(pc, 50021700, 1))
                                    {
                                        TakeItem(pc, 10015701, 10);
                                        GiveItem(pc, 50021700, 1);
                                        //FADE OUT BLACK
                                        Wait(pc, 1000);
                                        PlaySound(pc, 2216, false, 100, 50);
                                        PlaySound(pc, 2216, false, 100, 50);
                                        PlaySound(pc, 2216, false, 100, 50);
                                        Wait(pc, 1000);
                                        //FADE IN
                                        Say(pc, 131, "來，都搞定了！$R;");
                                        return;
                                    }
                                    Say(pc, 131, "真是！$R;" +
                                        "$R行李太多了，整理後再來吧！$R;");
                                    break;
                                case 3:
                                    if (CheckInventory(pc, 50061100, 1))
                                    {
                                        TakeItem(pc, 10015701, 10);
                                        GiveItem(pc, 50061100, 1);
                                        //FADE OUT BLACK
                                        Wait(pc, 1000);
                                        PlaySound(pc, 2216, false, 100, 50);
                                        PlaySound(pc, 2216, false, 100, 50);
                                        PlaySound(pc, 2216, false, 100, 50);
                                        Wait(pc, 1000);
                                        //FADE IN
                                        Say(pc, 131, "來，都搞定了！$R;");
                                        return;
                                    }
                                    Say(pc, 131, "真是！$R;" +
                                        "$R行李太多了，整理後再來吧！$R;");
                                    break;
                                case 4:
                                    if (CheckInventory(pc, 50010600, 1))
                                    {
                                        TakeItem(pc, 10015701, 10);
                                        GiveItem(pc, 50010600, 1);
                                        //FADE OUT BLACK
                                        Wait(pc, 1000);
                                        PlaySound(pc, 2216, false, 100, 50);
                                        PlaySound(pc, 2216, false, 100, 50);
                                        PlaySound(pc, 2216, false, 100, 50);
                                        Wait(pc, 1000);
                                        //FADE IN
                                        Say(pc, 131, "來，都搞定了！$R;");
                                        return;
                                    }
                                    Say(pc, 131, "真是！$R;" +
                                        "$R行李太多了，整理後再來吧！$R;");
                                    break;
                            }
                            return;
                        }
                        Say(pc, 131, "製造防具，需要10個『鹽鐵』。$R;" +
                            "$R『鹽鐵』可以在南部地牢得到，$R;" +
                            "是很貴重的鐵阿。$R;");
                        return;
                    case 2:
                        if (CountItem(pc, 10015702) >= 10)
                        {
                            if (CheckInventory(pc, 60002000, 1))
                            {
                                TakeItem(pc, 10015702, 10);
                                GiveItem(pc, 60002000, 1);
                                //FADE OUT BLACK
                                Wait(pc, 1000);
                                PlaySound(pc, 2216, false, 100, 50);
                                PlaySound(pc, 2216, false, 100, 50);
                                PlaySound(pc, 2216, false, 100, 50);
                                Wait(pc, 1000);
                                //FADE IN
                                Say(pc, 131, "來，都搞定了！$R;");
                                return;
                            }
                            Say(pc, 131, "真是！$R;" +
                                "$R行李太多了，整理後再來吧！$R;");
                            return;
                        }
                        Say(pc, 131, "製造防具，需要10個『鬼鐵』。$R;" +
                            "$R『鬼鐵』可以在南部地牢得到，$R;" +
                            "是很貴重的鐵阿。$R;");
                        return;
                    case 3:
                        if (CountItem(pc, 10015800) >= 10)
                        {
                            if (CheckInventory(pc, 60002200, 1))
                            {
                                TakeItem(pc, 10015800, 10);
                                GiveItem(pc, 60002200, 1);
                                //FADE OUT BLACK
                                Wait(pc, 1000);
                                PlaySound(pc, 2216, false, 100, 50);
                                PlaySound(pc, 2216, false, 100, 50);
                                PlaySound(pc, 2216, false, 100, 50);
                                Wait(pc, 1000);
                                //FADE IN
                                Say(pc, 131, "來，都搞定了！$R;");
                                return;
                            }
                            Say(pc, 131, "真是！$R;" +
                                "$R行李太多了，整理後再來吧！$R;");
                            return;
                        }
                        Say(pc, 131, "製造防具需要10個『鏡鐵』。$R;" +
                            "$R『鏡鐵』可以在南部地牢得到，$R;" +
                            "是很貴重的鐵阿。$R;");
                        return;
                }
            }
            Say(pc, 131, "這裡是武器製造所$R;" +
                "店面雖小，但是很有實力的唷。$R;");
            if (Select(pc, "做什麼呢？", "", "訂製武器", "什麼也不做") == 2)
            {
                return;
            }
            switch (Select(pc, "做什麼呢？", "", "製造武器", "製造防具", "煉製金屬", "製造『箭』", "不做"))
            {
                case 1:
                    switch (Select(pc, "想製作什麼?", "", "製作武器", "製作魔杖", "製作弓", "放棄"))
                    {
                        case 1:
                            Synthese(pc, 2010, 10);
                            break;
                        case 2:
                            Synthese(pc, 2021, 5);
                            break;
                        case 3:
                            Synthese(pc, 2034, 5);
                            break;
                    }
                    break;
                case 2:
                    Synthese(pc, 2017, 5);
                    break;
                case 3:
                    Synthese(pc, 2051, 3);
                    break;
                case 4:
                    Synthese(pc, 2035, 5);
                    break;
            }


            /*
            //EVT1100027730
            if (!_2a67)
            {
                Say(pc, 131, "『強化裝備』是提高『武器』和$R;" +
                    "『防具』的能力的技術唷。$R;" +
                    "$R需要手續費5000金幣，$R;" +
                    "要試試嗎？$R;");
                switch (Select(pc, "強化裝備嗎？", "", "好", "不用了"))
                {
                    case 1:
                        Say(pc, 131, "強化裝備需要材料$R;" +
                            "給您一個吧。$R;");
                        Say(pc, 131, "不把身上的裝備脫下來的話$R是不能強化的，記住啊$R;");
                        if (CheckInventory(pc, 90000043, 1))
                        {
                            _2a67 = true;
                            GiveItem(pc, 90000043, 1);
                            Say(pc, 131, "這是『生命的氣息』$R;" +
                                "使用這個的話，可以製造$R;" +
                                "提高HP值的武器或防具唷。$R;" +
                                "$R試一下吧$R;");
                            //ITEM_BOOST 0
                            return;
                        }
                        Say(pc, 131, "您的行李要減少一點才行啊$R;");
                        break;
                }
                return;
            }
            Say(pc, 131, "強化裝備一次5000金幣阿$R;");
            Say(pc, 131, "穿在身上的裝備不脫下來的話$R是不能強化的，記住了$R;");
            //EVT1100027737
            selection = Select(pc, "怎麼辦呢？", "", "強化裝備", "聽取關於強化裝備的提示", "算了");
            while (selection == 2)
            {
                switch (selection)
                {
                    case 1:
                        Say(pc, 131, "未開放$R;");
                        //ITEM_BOOST 0
                        return;
                    case 2:
                        selection = Global.Random.Next(1, 2);
                        switch (selection)
                        {
                            case 1:
                                Say(pc, 131, "強化武器會給道具帶來負擔喔。$R;" +
                                    "$R強化越多次就越容易失敗毀滅，$R;" +
                                    "所以要注意啊。$R;" +
                                    "但是只做一兩次沒有問題，放心吧$R;");
                                break;
                            case 2:
                                Say(pc, 131, "材料道具不同，$R;" +
                                    "強化能力也不同呢。$R;" +
                                    "$R這裡有好幾種道具，$R;" +
                                    "您挑一下吧$R;");
                                break;
                        }
                        break;
                }
                selection = Select(pc, "怎麼辦呢？", "", "強化裝備", "聽取關於強化裝備的提示", "算了");
            }
            */
        }
    }
}