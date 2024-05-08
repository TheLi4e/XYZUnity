using Scripts.Model.Data;
using Scripts.Model.Definitions;
using Scripts.Utils.Disposables;
using System;

namespace Scripts.Model
{
    public class StatsModel : IDisposable
    {
        private readonly PlayerData _data;
        public event Action OnChanged;

        public StatsModel(PlayerData data)
        {
            _data = data;
        }

        public IDisposable Subscribe(Action call)
        {
            OnChanged += call;
            return new ActionDisposable(() => OnChanged -= call);
        }

        public void LevelUp(StatId id)
        {
        }

        public float GetValue(StatId id)
        {
            return 0f;
        }

        public int GetLevel(StatId id) => _data.Levels.GetLevel(id);

        public void Dispose()
        {

        }
    }
}
