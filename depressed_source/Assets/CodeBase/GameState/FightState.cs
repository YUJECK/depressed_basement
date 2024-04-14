using CodeBase.FightMiner;

namespace CodeBase.GameState
{
    public class FightState : GameState
    {
        private Miner _miner;

        public override void OnAdded()
        {
            _miner = new Miner();
            _miner.Start();
        }

        public override void OnExit()
        {
            _miner.Stop();
        }
    }
}