using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Throwing_Boxes
{
    public class EnemyModel : CharacterModel, IGrable
    {
        public async void Lay()
        {
            await Task.Delay(500);
            _view.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        public async void Drop()
        {
            await Task.Delay(500);
            
            await Task.Delay(500);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Lay();
        }
        
        public void Grable()
        {
            _view.transform.eulerAngles = new Vector3(0, 0, 90);
        }

        public override void AdditionalActionOnPerformed(InputAction.CallbackContext obj)
        {
            throw new System.NotImplementedException();
        }

        public override void MainActionOnPerformed(InputAction.CallbackContext obj)
        {
            throw new System.NotImplementedException();
        }
    }
}