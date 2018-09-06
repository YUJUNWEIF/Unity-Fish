using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using System.Xml;
namespace Assets.myScript.Bag
{

    public class ALLLoad:MonoBehaviour
    {
        XmlElement root = null;
        void Start()
        {
            Debug.Log(">>>>>>>>>>>...............................");
            //LoadManager.startLoad(this, "file:///" + Application.dataPath + "/StreamingAssets/myweapon_windows",LoadComplete);
            //WWWLoad.Instance() .startLoad(this, "file:///" + Application.dataPath + "/StreamingAssets/myweapon_windows", LoadComplete);
			//WWWLoad.Instance() .startLoad(this, "file:///" + Application.dataPath + "/StreamingAssets/myweapon_windows", Launchpad.Instance.createWeapon);
            LoadManager.startLoad(this,"file:///" + Application.dataPath +"/StreamingAssets/myweapon_windows",LoadComplete);
            LoadManager.startLoad(this, "file:///" + Application.dataPath + "/StreamingAssets/mywp_windows", LoadComplete);
        }
        public void LoadComplete()
        {
            //Texture t = WWWLoad.Instance().getTexture("j-001");
            //this.GetComponent<RawImage>().texture = t;

            Texture t = LoadManager.getTexture("j-001");
            this.GetComponent<RawImage>().texture = t;
            Debug.Log("hhhhhhhhhhhh：：：ok"+t.texelSize);
            Debug.Log("资源加载成功");
            XMLManager.LoadXML("file:///"+Application.dataPath+"/File/Weapon.xml");
            XMLManager.LoadXML("file:///" + Application.dataPath + "/File/Monster.xml");
           
        }
    }
}
