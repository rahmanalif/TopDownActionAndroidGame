using UnityEngine;
using UnityEngine.UI;

public class upgradeMenu : MonoBehaviour
{
    public GameObject gunPrefab;
    public Transform GunContainer;
    private GUNS[] guns;

    private void Start()
    {
        guns = Resources.LoadAll<GUNS>("Gun");
        populateShop();
    }

    private void populateShop()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            int index = i;

            GameObject go = Instantiate(gunPrefab, GunContainer);

            go.GetComponent<Button>().onClick.AddListener(() => onGunClick(index));

            go.transform.GetChild(0).GetComponent<Image>().sprite = guns[index].Thumbnail;

            go.transform.GetChild(1).GetComponent<Text>().text = guns[index].ItemName;

            go.transform.GetChild(2).GetComponent<Text>().text = guns[index].ItemPrice.ToString();
        }
    }

    private void onGunClick(int i)
    {
        Debug.Log("hat bal sal");
    }
}
