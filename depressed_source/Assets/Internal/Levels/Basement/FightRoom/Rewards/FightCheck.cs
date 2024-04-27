using destructive_code.Scenes;

namespace FightRoomCode
{
    public class FightCheck : Check
    {
        public readonly int Money;

        public FightCheck(int money)
        {
            Money = money;
        }

        public override string GetName()
        {
            return "Check";
        }

        public override string GetDescription()
        {
            return Money.ToString();
        }

        public override void OnReceive()
        {
            SceneSwitcher.BasementScene.Wallet.TopUp(Money);
        }
    }
}