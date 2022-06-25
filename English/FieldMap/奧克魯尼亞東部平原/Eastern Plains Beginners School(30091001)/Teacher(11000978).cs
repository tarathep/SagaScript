using System;
using System.Collections.Generic;
using System.Text;

using SagaDB.Actor;
using SagaDB.Item;
using SagaMap.Scripting;

using SagaLib;
using SagaScript.Chinese.Enums;
//所在地圖:東部平原初心者學校(30091001) NPC基本信息:老師(11000978) X:6 Y:1
namespace SagaScript.M30091001
{
    public class S11000978 : Event
    {
        public S11000978()
        {
            this.EventID = 11000978;
        }

        public override void OnEvent(ActorPC pc)
        {
            BitMask<Beginner_02> Beginner_02_mask = new BitMask<Beginner_02>(pc.CMask["Beginner_02"]);
            BitMask<Neko_03> Neko_03_amask = pc.AMask["Neko_03"];
            BitMask<Neko_03> Neko_03_cmask = pc.CMask["Neko_03"];

            int selection;

            //EVT11000978
            Say(pc, 11000978, 131, "Teacher$R;" +
                "$RIs there anything you don't know?$R;", "Teacher");

            if (Neko_03_amask.Test(Neko_03.堇子任務開始) &&
                !Neko_03_amask.Test(Neko_03.堇子任務完成) &&
                Neko_03_cmask.Test(Neko_03.接受下城的優秀阿姨給予的任務) &&
                !Neko_03_cmask.Test(Neko_03.與初心者學校老師對話))
            {
                Neko_03_cmask.SetValue(Neko_03.與初心者學校老師對話, true);
                Say(pc, 0, 131, "I asked the teacher about a little boy$R;");
                Say(pc, 11000978, 131, "Ahh! $R;" +
                    "$RAre you talking about the kid?$R;" +
                    "$P啊，好像是昨天早上…$R有個小男孩問我去東域的路$R;" +
                    "$R我因為咕咕有危險$R所以勸過他不要去，但是…$R一轉眼，他就從學校跑出去了$R;" +
                    "$P…他也很可憐啊，媽媽因病去世了…$R;" +
                    "$R所以在東邊國家的親戚那裡$R寄人籬下了$R;" +
                    "$P可以拜託您一件事嗎?$R對小孩來說，去帕斯特的路$R非常危險呀$R;" +
                    "$R幫忙找一下那孩子吧$R;");
                /*
                if (_7A47)
                {
                    return;
                }//*/
                if (pc.Inventory.Equipments.ContainsKey(EnumEquipSlot.PET))
                {
                    if (pc.Inventory.Equipments[EnumEquipSlot.PET].ItemID == 10017900)
                    {
                        堇子任務(pc);
                        return;
                    }
                }
                if (CountItem(pc, 10017900) >= 1)
                {
                    堇子任務(pc);
                    return;
                }
                return;
            }

            if (!Beginner_02_mask.Test(Beginner_02.已經與老師進行第一次對話))
            {
                初次與老師進行對話(pc);
                return;
            }


            selection = Select(pc, "Want to ask what question?", "", "When starting out, what should I do?", "way to go uptown", "What are the benefits of joining the military?", "Which career is better?", "How to make big money…", "How to open the [wooden box]", "skip to question page", "It's hard...to...", "it doesn't matter");

            while (selection != 9)
            {
                switch (selection)
                {
                    case 1:
                        Say(pc, 11000978, 131, "嗯! 剛開始時，$R;" +
                                               "做3個「任務」左右比較好喔!$R;" +
                                               "$R因為可以獲得經驗值和金幣呢!$R;" +
                                               "$P還有跟城市裡的人聊聊天，$R;" +
                                               "以及可以去的地方都去看看…$R;" +
                                               "$R這兩點也是很重要的呀!$R;" +
                                               "$P小地圖中「紅點」是有NPC的地方，$R;" +
                                               "「藍點」是有傳送點的所在地。$R;" +
                                               "$R參考一下吧!$R;", "老師");
                        break;

                    case 2:
                        Say(pc, 11000978, 131, "在進入「上城」的入口$R;" +
                                               "被警衛阻止了?$R;" +
                                               "$R您一定覺得很奇怪吧?$R;" +
                                               "「阿高普路斯市」是自由貿易城市，$R;" +
                                               "可為什麼無法自由的進出…$R;" +
                                               "$P…去問問在「下城」的$R;" +
                                               "「萬物博士」吧>$R;" +
                                               "$R他會告訴您$R;" +
                                               "得到『阿高普路斯市通行證』的方法。$R;", "老師");
                        break;

                    case 3:
                        Say(pc, 11000978, 131, "是說「奧克魯尼亞混城騎士團」吧?$R;" +
                                               "在「騎士團宮殿」那裡受到勸誘嗎?$R;" +
                                               "$R嗯…說到優點的話，$R;" +
                                               "應該說…$R;" +
                                               "可以自由出入軍隊所屬的國家吧?$R;" +
                                               "$P除此之外，$R;" +
                                               "還可以執行特殊的軍隊「任務」。$R;" +
                                               "在所屬國的話，$R;" +
                                               "好像也會有軍隊專用的特別商店唷!$R;" +
                                               "$P且即使是「騎士團練習」，$R;" +
                                               "也不會禁止所屬軍隊和其他軍隊參加，$R;" +
                                               "也不會無法進入其他國家，$R;" +
                                               "所以放心吧!$R;" +
                                               "$P要說缺點的話…嗯…$R;" +
                                               "$R有些城市裡的居民，$R;" +
                                               "不太喜歡「奧克魯尼亞混城騎士團」呀!$R;", "老師");
                        break;

                    case 4:
                        Say(pc, 11000978, 131, "如果還沒決定職業的話…$R;" +
                                               "$R開始的時候，$R;" +
                                               "還是選擇戰士系的$R;" +
                                               "「劍士」或「騎士」吧!$R;" +
                                               "比較容易熟悉適應環境。$R;", "老師");
                        break;

                    case 5:
                        Say(pc, 11000978, 131, "這麼快就完成3個「任務」啦?$R;" +
                                               "呵呵!$R;" +
                                               "$R先把在「阿高普路斯市」$R;" +
                                               "東、南、西、北平原的『木箱』打破吧!$R;" +
                                               "$P把箱子打破後，將得到『木箱』唷!$R;" +
                                               "只要可以用高價賣給商人的，$R;" +
                                               "一定是好東西啊!$R;", "老師");
                        break;

                    case 6:
                        Say(pc, 11000978, 131, "可能您還沒見過『木箱』吧?$R;" +
                                               "$R但是『寶物箱』和『集裝箱』裡面，$R;" +
                                               "同樣裝有各種道具的喔!$R;" +
                                               "$P拜託「道具精製師」幫忙的話，$R;" +
                                               "他會幫您打開箱子的。$R;" +
                                               "$R往城市的方向走一會，$R;" +
                                               "應該可以看到一個戴著眼鏡。$R;" +
                                               "看起來像工匠的人吧?$R;" +
                                               "$P『木箱』和『寶物箱』$R;" +
                                               "還有『集裝箱』裡，$R;" +
                                               "偶爾也會有很珍貴的道具唷!$R;" +
                                               "$P雖然現在還不知道裡面道具的價值?$R;" +
                                               "$R當您知道可能獲得道具的價值後，$R;" +
                                               "還是別把『木箱』賣掉吧，$R;" +
                                               "說不定找精製師幫您打開會更好呢!$R;", "老師");
                        break;

                    case 7:
                        問題頁(pc);
                        return;

                    case 8:
                        困難頁(pc);
                        return;
                }

                selection = Select(pc, "Want to ask what question?", "", "When starting out, what should I do?", "way to go uptown", "What are the benefits of joining the military?", "Which career is better?", "How to make big money…", "How to open the [wooden box]", "skip to question page", "It's hard...to...", "it doesn't matter");
            }
        }

        void 初次與老師進行對話(ActorPC pc)
        {
            BitMask<Beginner_02> Beginner_02_mask = new BitMask<Beginner_02>(pc.CMask["Beginner_02"]);

            Beginner_02_mask.SetValue(Beginner_02.已經與老師進行第一次對話, true);

            Say(pc, 11000978, 131, "您好!$R;" +
                                   "$R您第一次來到這裡吧?$R;" +
                                   "$P這裡是為了幫助$R;" +
                                   "到「阿高普路斯市」的初心者，$R;" +
                                   "而設立的「初心者學校」唷!$R;" +
                                   "$P如果您也需要幫助的話，$R;" +
                                   "就請到這裡來吧!$R;", "老師");
        }

        void 問題頁(ActorPC pc)
        {
            int selection;

            selection = Select(pc, "Want to ask what question?", "", "想交朋友…", "怎麼組成隊伍??", "騎士團練習是什麼?", "我想養寵物!", "我想擁有活動木偶", "回到首頁", "對困難的地方…", "it doesn't matter");

            while (selection != 6)
            {
                switch (selection)
                {
                    case 1:
                        Say(pc, 11000978, 131, "別客氣，安心的說吧!$R;" +
                                               "$P話雖如此，還是挺需要勇氣的吧?$R;" +
                                               "$P如果害怕跟人交談，$R;" +
                                               "我可以給您介紹一個功能喔!$R;" +
                                               "$R可以試試使用$R;" +
                                               "「告示板」和「廣告目錄」呀!$R;" +
                                               "$P「告示板」在「上城」$R;" +
                                               "和各地方都有。$R;" +
                                               "$R告示版裡寫上招募朋友或$R;" +
                                               "提出問題的話，$R;" +
                                               "其他人會親切地回答您喔!$R;" +
                                               "$P而「廣告目錄」呢，$R;" +
                                               "用滑鼠右鍵點自己，就會顯示目錄了，$R;" +
                                               "選擇目錄的中「廣告目錄」就可以了。$R;" +
                                               "$P這時會出現廣告目錄的視窗，$R;" +
                                               "再選擇「招募廣告登陸」，$R;" +
                                               "把自己想要說的話輸入就可以了。$R;", "老師");
                        break;

                    case 2:
                        Say(pc, 11000978, 131, "想邀請對方加入隊伍的話，$R;" +
                                               "用滑鼠右鍵點擊對方，$R;" +
                                               "選擇「邀請加入隊伍」試試吧!$R;" +
                                               "$R對方就會顯示邀請加入的視窗，$R;" +
                                               "如果忽然邀請的話，會嚇著對方的。$R;" +
                                               "所以邀請之前，$R;" +
                                               "先與對方交談得到許可後，$R;" +
                                               "再邀請比較好唷!$R;" +
                                               "$P只要對方接受了邀請，$R;" +
                                               "那麼兩個人就組成了隊伍喔!$R;" +
                                               "$R這個時候提出邀請的一方，$R;" +
                                               "就會變成「隊長」。$R;" +
                                               "那麼，您應該會成為隊長吧?$R;" +
                                               "$P隊長可以$R;" +
                                               "「更改隊伍名稱」和「解散隊伍」喔!$R;" +
                                               "$P如果是收到邀請的話，$R;" +
                                               "您就會成為隊伍的「隊員」。$R;" +
                                               "$P當您不想組隊時，$R;" +
                                               "就可以「退出隊伍」呀!$R;" +
                                               "$R不管是哪一方，$R;" +
                                               "想加入隊伍的話，只要點擊自己，$R;" +
                                               "在目錄裡選擇就可以囉。$R;", "老師");
                        break;

                    case 3:
                        Say(pc, 11000978, 131, "好像聽到了廣播啊?$R;" +
                                               "$R「騎士團練習」$R;" +
                                               "簡單的說，$R;" +
                                               "就是玩家們分為東、南、西、北軍後，$R;" +
                                               "進行的模擬戰鬥。$R;" +
                                               "$P不論您是否參加了騎士團，$R;" +
                                               "都可以在東、南、西、北4個小組中，$R;" +
                                               "任意的選擇一方參加唷!$R;" +
                                               "$P裝備的持久度不會減少，$R;" +
                                               "死亡也不會處罰，$R;" +
                                               "所以別擔心，去玩玩吧!$R;" +
                                               "$P到了「阿高普路斯市」的「下城」$R;" +
                                               "北邊有「占卜店」唷!$R;" +
                                               "$R那「占卜店」右邊的傳送點前，$R;" +
                                               "正接受報名呢!$R;" +
                                               "$R下次聽到廣播的時候，就去看看吧!$R;", "老師");
                        break;

                    case 4:
                        Say(pc, 11000978, 131, "嗯，寵物的種類雖然很多…$R;" +
                                               "$R但是，到「玩家商店」那裡買的話，$R;" +
                                               "是最簡單的。$R;" +
                                               "$P想在商店裡購買的話，$R;" +
                                               "可以去「東方海角」的「寵物店」。$R;" +
                                               "$P那裡有販賣小狗唷!$R;" +
                                               "有些寵物也是很稀有的。$R;" +
                                               "$R如果路上看到別人$R;" +
                                               "帶著您喜歡的寵物類型，$R;" +
                                               "就去問問得到寵物的方法吧!$R;", "老師");
                        break;

                    case 5:
                        Say(pc, 11000978, 131, "聽說「阿高普路斯市」的「上城」$R;" +
                                               "有個分發活動木偶的女孩…$R;" +
                                               "$P好像叫…埃琳娜?$R;" +
                                               "聽說是個可愛的塔尼亞女孩，$R;" +
                                               "$R下次去看看吧!$R;", "老師");
                        break;

                    case 7:
                        困難頁(pc);
                        return;

                    case 8:
                        return;
                }

                selection = Select(pc, "Want to ask what question?", "", "想交朋友…", "怎麼組成隊伍??", "騎士團練習是什麼?", "我想養寵物!", "我想擁有活動木偶", "回到首頁", "對困難的地方…", "it doesn't matter");
            }
        }

        void 困難頁(ActorPC pc)
        {
            int selection;

            selection = Select(pc, "Want to ask what question?", "", "無法使用技能", "因為石像和告示板無法走路…", "裝備壞掉了", "寵物進入了睡眠狀態", "行李太多無法搬運", "回到首頁", "到問題頁", "it doesn't matter");

            while (selection != 6)
            {
                switch (selection)
                {
                    case 1:
                        Say(pc, 11000978, 131, "無法使用技能?$R;" +
                                               "$R原因可能有三個。$R;" +
                                               "$P第一是$R;" +
                                               "使用技能需要的MP值或SP值不足。$R;" +
                                               "$P第二是$R;" +
                                               "不符合技能的「使用條件」。$R;" +
                                               "$R比如說，連武器都沒有，$R;" +
                                               "要使用「旋風劍」這樣的技能，$R;" +
                                               "當然是不可能吧!$R;" +
                                               "$P最後是第三個，$R;" +
                                               "沒有使用技能時的必備品「催化道具」。$R;" +
                                               "$R技能中，有些技能每次使用時，$R;" +
                                               "都需要一個「催化道具」。$R;" +
                                               "「催化道具」中，$R;" +
                                               "有『毒藥』、『定時炸彈』等幾種。$R;" +
                                               "$P關於「使用條件」或「催化道具」，$R;" +
                                               "用滑鼠右鍵點擊技能圖示的話，$R;" +
                                               "在「技能視窗」會有說明唷，$R;" +
                                               "有時間去看看吧?$R;", "老師");
                        break;

                    case 2:
                        Say(pc, 11000978, 131, "啊…!$R;" +
                                               "「奧克魯尼亞東部平原」$R;" +
                                               "石像和告示板特別多呀，$R;" +
                                               "所以非常難走。$R;" +
                                               "$P這時只要在系統是瘡的第三個項目中的$R;" +
                                               "「石像顯示」把顯示狀態設定為「不顯示」即可。$R;" +
                                               "$P再把告示板設定為不顯示，$R;" +
                                               "或用滑鼠設定別人的告示板，$R;" +
                                               "或廣告顯示與否。$R;" +
                                               "$P或把寵物說話的話，$R;" +
                                               "設定成在紀錄中不顯示等等。$R;" +
                                               "$R按照自己的喜好設定就可以了!$R;", "老師");
                        break;

                    case 3:
                        Say(pc, 11000978, 131, "裝備得持久度降到0的話，$R;" +
                                               "圖示會變成半透明，就無法裝備了。$R;" +
                                               "$R那是道具「損壞」的意思。$R;" +
                                               "$P但是不代表，$R;" +
                                               "永遠不能使用那道具。$R;" +
                                               "因為道具「損壞」了，$R;" +
                                               "只要用『維修工具』修理就可以了。$R;" +
                                               "$P依照裝備不同，$R;" +
                                               "也有幾種不同的『維修工具』。$R;" +
                                               "$R而且又根據「裝備等級」，$R;" +
                                               "分為「金」「銀」「銅」，$R;" +
                                               "注意不要弄錯啊?$R;" +
                                               "$P在裝備的「道具資料」視窗裡，$R;" +
                                               "「詳細」說明了$R;" +
                                               "可以修理道具的維修工具名稱，$R;" +
                                               "請確認看看吧?$R;", "老師");
                        break;

                    case 4:
                        Say(pc, 11000978, 131, "什麼…寵物的圖示$R;" +
                                               "要是變成半透明的話，$R;" +
                                               "就不能帶牠出去了?$R;" +
                                               "$R請放心吧，那個不是指寵物死了。$R;" +
                                               "$R只是「親密度」跌到0而已!$R;" +
                                               "$P親密度跌至0的話，$R;" +
                                               "寵物會進入「休眠」狀態呀!$R;" +
                                               "$R只要恢復親密度，$R;" +
                                               "就可以像以前一樣，一起冒險了。$R;" +
                                               "$P想要恢復氣密洞的話，$R;" +
                                               "餵寵物吃『四葉草糖果』或$R;" +
                                               "『四葉草豆』吧!$R;" +
                                               "$R雙擊道具後，$R;" +
                                               "選擇寵物就可以了。$R;" +
                                               "$P或者可以恢復寵物親密度的，$R;" +
                                               "「寵物醫生」那裡診察也可以。$R;", "老師");
                        break;

                    case 5:
                        Say(pc, 11000978, 131, "「重量」和「體積」$R;" +
                                               "總會覺得不足的。$R;" +
                                               "$R「重量」和「體積」$R;" +
                                               "是根據職業、種族而定啊!$R;" +
                                               "$P要搬運的物品，$R;" +
                                               "比限制數量多的時候。$R;" +
                                               "$R裝備「背囊」$R;" +
                                               "或者帶著可以戴型裡的「寵物」，$R;" +
                                               "就可以了。$R;" +
                                               "$P職業中也有可以運用「技能」，$R;" +
                                               "搬運大量行李的職業唷!$R;" +
                                               "$P還有，您有在使用「倉庫」嗎?$R;" +
                                               "$R跟商人說話時，$R;" +
                                               "可以請他幫您用個人倉庫，$R;" +
                                               "來保管道具唷!$R;", "老師");
                        break;

                    case 7:
                        問題頁(pc);
                        return;

                    case 8:
                        return;
                }

                selection = Select(pc, "Want to ask what question?", "", "無法使用技能", "因為石像和告示板無法走路…", "裝備壞掉了", "寵物進入了睡眠狀態", "行李太多無法搬運", "回到首頁", "到問題頁", "it doesn't matter");
            }
        }

        void 堇子任務(ActorPC pc)
        {
            Say(pc, 0, 131, "媽…$R媽…媽媽…$R;", "\"凱堤（桃）\"");
            if (pc.Inventory.Equipments.ContainsKey(EnumEquipSlot.PET))
            {
                if (pc.Inventory.Equipments[EnumEquipSlot.PET].ItemID == 10017902)
                {
                    Say(pc, 0, 131, "桃子…$R你對媽媽還有記憶嗎?$R;", "\"凱堤（菫）\"");
                    Say(pc, 0, 131, "嗯，非常模糊$R;" +
                        "$R大大的…軟軟的…$R真的很溫暖阿…$R;" +
                        "$R只能想到這些$R;", "\"凱堤（桃）\"");
                    return;
                }
            }
            if (CountItem(pc, 10017902) >= 1)
            {
                Say(pc, 0, 131, "桃子…$R你對媽媽還有記憶嗎?$R;", "\"凱堤（菫）\"");
                Say(pc, 0, 131, "嗯，非常模糊$R;" +
                    "$R大大的…軟軟的…$R真的很溫暖阿…$R;" +
                    "$R只能想到這些$R;", "\"凱堤（桃）\"");
                return;
            }
            if (pc.Inventory.Equipments.ContainsKey(EnumEquipSlot.PET))
            {
                if (pc.Inventory.Equipments[EnumEquipSlot.PET].ItemID == 10017905)
                {
                    Say(pc, 0, 131, "桃子…$R你對媽媽還有記憶嗎?$R;" +
                        "$R我什麼都想不起來$R;", "\"凱堤（山吹）\"");
                    Say(pc, 0, 131, "嗯，緑那時候還很小$R;" +
                        "$R大大的…軟軟的…$R真的很溫暖阿…$R;" +
                        "$R只能想到這些$R;", "\"凱堤（桃）\"");
                    return;
                }
            }
            if (CountItem(pc, 10017905) >= 1)
            {
                Say(pc, 0, 131, "桃子…$R你對媽媽還有記憶嗎?$R;" +
                    "$R我什麼都想不起來$R;", "\"凱堤（山吹）\"");
                Say(pc, 0, 131, "嗯，緑那時候還很小$R;" +
                    "$R大大的…軟軟的…$R真的很溫暖阿…$R;" +
                    "$R只能想到這些$R;", "\"凱堤（桃）\"");
                return;
            }
            if (pc.Inventory.Equipments.ContainsKey(EnumEquipSlot.PET))
            {
                if (pc.Inventory.Equipments[EnumEquipSlot.PET].ItemID == 10017903)
                {
                    Say(pc, 0, 131, "…桃子$R還記得有關媽媽的事情嗎？$R;", "\"凱堤（藍）\"");
                    Say(pc, 0, 131, "嗯，非常模糊$R;" +
                        "$R大大的…軟軟的…$R真的很溫暖阿…$R;" +
                        "$R只能想到這些$R;", "\"凱堤（桃）\"");
                    return;
                }
            }
            if (CountItem(pc, 10017903) >= 1)
            {
                Say(pc, 0, 131, "…桃子$R還記得有關媽媽的事情嗎？$R;", "\"凱堤（藍）\"");
                Say(pc, 0, 131, "嗯，非常模糊$R;" +
                    "$R大大的…軟軟的…$R真的很溫暖阿…$R;" +
                    "$R只能想到這些$R;", "\"凱堤（桃）\"");
                return;
            } 
        }
    }
}
