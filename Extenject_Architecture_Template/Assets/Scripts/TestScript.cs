using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class TestScript : ITickable
    {
        public TestScript()
        {
            
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                
            }
        }
    }
}