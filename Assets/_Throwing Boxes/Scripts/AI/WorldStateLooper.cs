using System.Collections;
using UnityEngine;

namespace Throwing_Boxes
{
    public class WorldStateLooper : MonoBehaviour
    {
        [Space]
        [SerializeField]
        private bool _playOnStart = true;

        [Space]
        [SerializeField]
        private float _minUpdatePeriod = 0.1f;

        [SerializeField]
        private float _maxUpdatePeriod = 0.2f;

        [SerializeField]
        private WorldState _worldState;
        
        private Coroutine _coroutine;

        protected virtual void Start()
        {
            if (this._playOnStart)
            {
                this.Play();
            }
        }

        public void Play()
        {
            if (this._coroutine == null)
            {
                this._coroutine = this.StartCoroutine(this.UpdateLoop());
            }
        }

        public void Stop()
        {
            if (this._coroutine != null)
            {
                this.StopCoroutine(this._coroutine);
                this._coroutine = null;
            }
        }

        private IEnumerator UpdateLoop()
        {
            while (true)
            {
                var period = Random.Range(this._minUpdatePeriod, this._maxUpdatePeriod);
                yield return new WaitForSeconds(period);
                _worldState.UpdateFacts();
            }
        }
    }
}