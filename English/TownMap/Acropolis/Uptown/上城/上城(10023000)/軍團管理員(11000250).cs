using System;
using System.Collections.Generic;
using System.Text;

using SagaDB.Actor;
using SagaMap.Scripting;

using SagaLib;
using SagaScript.Chinese.Enums;

using SagaDB.Ring;
//所在地圖:上城(10023000) NPC基本信息:軍團管理員(11000250) X:73 Y:170
namespace SagaScript.M10023000
{
    public class S11000250 : Event
    {
        public S11000250()
        {
            this.EventID = 11000250;
        }

        public override void OnEvent(ActorPC pc)
        {
            BitMask<Acropolisut_01> Acropolisut_01_mask = pc.CMask["Acropolisut_01"];                                                                                   //一般：阿高普路斯市

            if (!Acropolisut_01_mask.Test(Acropolisut_01.已經與軍團管理員進行第一次對話))
            {
                初次與軍團管理員進行對話(pc);
            }

            if (pc.Ring == null)
            {
                switch (Select(pc, "歡迎來到軍團登記處，請問您想做什麼?", "", "組織軍團 (1萬金幣)", "軍團登記處的使用方法", "什麼也不做"))
                {
                    case 1:
                        創立新的軍團(pc);
                        return;

                    case 2:
                        軍團相關說明(pc);
                        return;

                    case 3:
                        return;
                }
            }
            /*
            if (pc.CharID == pc.Ring.Leader.CharID)
            {
                軍團總管模式(pc);
            }
            */
            if (pc.CharID == pc.Ring.Leader.CharID)
            {
                軍團總管模式(pc);
            }
            else
            {
                軍團團員模式(pc);
            }
        }

        void 軍團總管模式(ActorPC pc)
        {
            Say(pc, 11000250, 111, "軍團總管歡迎呀!!$R;" +
                                   "$P我正等著您呢!$R;", "軍團管理員");

            switch (Select(pc, "歡迎來到軍團登記處，請問您想做什麼?", "", "解散軍團", "變更軍團總管", "軍團登記處使用方法", "什麼也不做"))
            {
                case 1:
                    switch (Select(pc, "真的要解散軍團嗎?", "", "是的，我確定要解散軍團", "放棄"))
                    {
                        case 1:
                            Say(pc, 0, 65535, "目前尚未實裝$R;", " ");

                            ////解散軍團


                            ////例外判斷

                            ////伺服器中斷
                            //Say(pc, 0, 65535, "軍團管理跟伺服器的通信中斷了喔!$R;" +
                            //                  "$R請稍後再重試吧!!$R;", " ");

                            ////進行投票中
                            //Say(pc, 0, 65535, "現在正在進行軍團總管選舉，$R;" +
                            //                  "不能進行解散軍團唷。$R;", " ");

                            ////預備中
                            //Say(pc, 0, 65535, "現在不能進行解散軍團唷$R;" +
                            //                  "$R請稍後再來吧!$R;", " ");
                            break;

                        case 2:
                            break;
                    }
                    break;

                case 2:
                    Say(pc, 0, 65535, "目前尚未實裝$R;", " ");

                    ////變更軍團總管


                    ////例外判斷

                    ////伺服器中斷
                    //Say(pc, 0, 65535, "軍團管理跟伺服器的通信中斷了喔!$R;" +
                    //                  "$R請稍後再重試吧!!$R;", " ");

                    ////周りにリングメンバーがいない,
                    //Say(pc, 0, 65535, "如果要變更總管的話，$R;" +
                    //                  "請在下一次軍團總管選舉時，$R;" +
                    //                  "一起來過來吧!$R;", " ");

                    ////伺服器中斷
                    //Say(pc, 0, 65535, "軍團管理跟伺服器的通信中斷了喔!$R;" +
                    //                  "$R請稍後再重試吧!!$R;", " ");

                    ////相手が忙しいのでダメ,
                    //Say(pc, 0, 65535, "現在對方不能進行變更唷!!$R;" +
                    //                  "$R稍後再來吧!$R;", " ");
                    break;

                case 3:
                    軍團相關說明(pc);
                    break;

                case 4:
                    break;
            }        
        }

        void 軍團團員模式(ActorPC pc)
        {
            switch (Select(pc, "歡迎來到軍團登記處，請問您想做什麼?", "", "變更軍團總管", "軍團登記處的使用方法", "什麼也不做"))
            {
                case 1:
                    //申請變更軍團總管(pc);
                    軍團總管變更投票(pc);
                    break;

                case 2:
                    軍團相關說明(pc);
                    break;

                case 3:
                    break;
            }
        }

        void 初次與軍團管理員進行對話(ActorPC pc)
        {
            BitMask<Acropolisut_01> Acropolisut_01_mask = pc.CMask["Acropolisut_01"];                                                                                   //一般：阿高普路斯市

            Acropolisut_01_mask.SetValue(Acropolisut_01.已經與軍團管理員進行第一次對話, true);

            Say(pc, 11000250, 111, "歡迎來到軍團登記處呀!$R;" +
                                   "$R請問您了解『軍團』嗎?$R;" +
                                   "$P『軍團』就像是半永久性的隊伍一樣，$R;" +
                                   "一開始最多可以登記16個人唷。$R;" +
                                   "$P在不久的將來，$R;" +
                                   "軍團之間也可以結盟，$R;" +
                                   "日後可能會形成龐大的團體呢，$R;" +
                                   "真是期待呀!$R;" +
                                   "$P對了!$R;" +
                                   "$R相同軍團的成員，$R;" +
                                   "還可以透過軍團的聊天系統，$R;" +
                                   "一起聊天唷!$R;" +
                                   "$P您隨時可以跟軍團成員進行對話的，$R;" +
                                   "所以一定要試試看啊!!$R;", "軍團管理員");
        }

        void 創立新的軍團(ActorPC pc)
        {
            string Ring_Name;

            if (pc.Gold >= 10000)
            {
                Ring_Name = InputBox(pc, "請輸入軍團名稱", InputType.PetRename);

                if (Ring_Name != "")
                {
                    if (Ring_Name.Length > 24)
                    {
                        Say(pc, 11000250, 131, "不能使用這個名字呀!$R;" +
                                               "$R請確認字數以後，再來申請吧!$R;" +
                                               "（最多中文12個字/英文24個字）$R;", "軍團管理員");

                        創立新的軍團(pc);
                    }

                    if (CreateRing(pc, Ring_Name))
                    {
                        PlaySound(pc, 4006, false, 100, 50);
                        pc.Gold -= 10000;

                        Say(pc, 11000250, 111, "成功創立新的軍團了!!$R;" +
                                               "$P從現在開始，$R;" +
                                               "您就是這個軍團的『軍團總管』唷!$R;" +
                                               "$R一定要成為出色的軍團喔，$R;" +
                                               "加油吧!!$R;", "軍團管理員");
                    }
                    else
                    {
                        Say(pc, 11000250, 131, "抱歉，已經有同名的軍團了。$R;", "軍團管理員");

                        創立新的軍團(pc);
                    }
                }
            }
            else
            {
                Say(pc, 11000250, 131, "想要組成軍團的話，需要1萬金幣呀!$R;", "軍團管理員");
            }
        }

        void 軍團相關說明(ActorPC pc)
        {
            int selection;

            Say(pc, 11000250, 111, "在我這裡可以組織軍團，$R;" +
                                   "或者是變更軍團總管的相關手續唷!$R;" +
                                   "$P另外，$R;" +
                                   "您可以隨時設定朋友清單裡的軍團目錄，$R;" +
                                   "有空就參考一下吧!$R;", "軍團管理員");

            selection = Select(pc, "想要詢問有關什麼的情報呢?", "", "組織軍團 (收費)", "解散軍團", "變更軍團總管", "設定軍團標誌", "什麼也不做");

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        Say(pc, 11000250, 111, "只要是軍團以外的人，$R;" +
                                               "不論是誰都不能設定軍團的。$R;" +
                                               "$R組成軍團的人，$R;" +
                                               "會立即成為軍團的領袖。$R;" +
                                               "$P領袖又被稱為『軍團總管』唷!!$R;" +
                                               "$R享有各種管理以及設定軍團的權利。$R;" +
                                               "$P還有一件事情要特別注意，$R;" +
                                               "組成軍團時必須要收取一定的手續費，$R;" +
                                               "一共需要1萬金幣的手續費唷!!$R;", "軍團管理員");
                        break;

                    case 2:
                        Say(pc, 11000250, 111, "顧名思義就是解散軍團呀!$R;" +
                                               "$R不過這是軍團總管的權利，$R;" +
                                               "其他成員是無法進行的啦!$R;", "軍團管理員");
                        break;

                    case 3:
                        Say(pc, 11000250, 111, "如果想要進行總管的變更，$R;" +
                                               "所需手續則會根據總管本人的設定而改變。$R;" +
                                               "$R要是由別的成員來申請變更，$R;" +
                                               "申請的步驟將會不一樣喔。$R;" +
                                               "$P現任總管本人申請的話，$R;" +
                                               "只要跟新總管人選一起來到這裡，$R;" +
                                               "進行職位的轉讓就可以了。$R;" +
                                               "$P如果不是總管，$R;" +
                                               "而是其他成員申請變更的話，$R;" +
                                               "會先成為總管的選舉候選人，$R;" +
                                               "再由全體成員投贊成或反對票，$R;" +
                                               "只要贊成票過半數的話，$R;" +
                                               "候選人就當選為新一任總管唷!!$R;", "軍團管理員");
                        break;

                    case 4:
                        Say(pc, 11000250, 111, "有一定聲望的軍團，$R;" +
                                               "可以設定象徵軍團的標誌。$R;" +
                                               "$P只有作為軍團總管的您，$R;" +
                                               "才可以設定標誌唷!!$R;" +
                                               "$R想要設定軍團標誌，$R;" +
                                               "軍團的聲望必須達300以上，$R;:" +
                                               "就可以設定ECO遊戲跟目錄下的$R;" +
                                               "data/sprite/emblem 資料夾內設定。$R;" +
                                               "使用空白圖像，$R;" +
                                               "做一個獨特的軍團標誌，$R;" +
                                               "然後直接登記就可以了。$R;" +
                                               "$P那麼就來做一個漂亮的標誌，$R;" +
                                               "試試看吧!!$R;", "軍團管理員");
                        break;
                }

                selection = Select(pc, "想打聽什麼呢?", "", "組織軍團 (收費)", "解散軍團", "變更軍團總管", "設定軍團標誌", "什麼也不做");
            }
        }

        void 軍團總管變更投票(ActorPC pc)
        {
            Say(pc, 11000250, 111, "一般成員申請變更軍團總管時，$R;" +
                                   "必須要有成員參加總管選舉喔!!$R;" +
                                   "$R您要參加總管選舉嗎?$R;", "軍團管理員");

            switch (Select(pc, "想要參加總管選舉嗎?", "", "參加選舉", "放棄"))
            {
                case 1:
                    Say(pc, 0, 65535, "目前尚未實裝$R;", " ");

                    //Say(pc, 11000250, 111, "想要成功當選為軍團總管，$R;" +
                    //                       "就必須得到大多數軍團成員的同意才行喔!!$R;" +
                    //                       "$R那麼現在就準備開始進行，$R;" +
                    //                       "為期3天的投票吧!!$R;", "軍團管理員");

                    ////選舉開始


                    ////例外判斷

                    ////伺服器中斷
                    //Say(pc, 0, 65535, "軍團管理跟伺服器的通信中斷了喔!$R;" +
                    //                "$R請稍後再重試吧!!$R;", " ");

                    ////進行投票中
                    //Say(pc, 0, 65535, "您已經成為軍團總管了。$R;", " ");

                    ////進行投票中
                    //Say(pc, 0, 65535, "現在正在進行軍團總管選舉，$R;" +
                    //                "不能進行解散軍團唷。$R;", " ");
                    break;

                case 2:
                    break;
            }
        }
    }
}
