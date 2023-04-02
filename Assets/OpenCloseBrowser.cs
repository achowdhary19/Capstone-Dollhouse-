using UnityEngine;

namespace Assets
{
    public class OpenCloseBrowser : MonoBehaviour
    {
        // Start is called before the first frame update
    
        public GameObject Panel ;
        
        public void CloseBrowser()
        {
            Panel.SetActive(false);
        }
    
        public void OpenBrowser()
        {
            Panel.SetActive(true);
        }
    }
}
