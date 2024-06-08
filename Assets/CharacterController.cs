using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject pantsSlot; // 바지가 장착될 위치
    public GameObject pants1Prefab;
    public GameObject pants2Prefab;

    private GameObject currentPants;

    void Start()
    {
        EquipPants(pants1Prefab); // 기본 바지로 시작
    }

    public void EquipPants(GameObject pantsPrefab)
    {
        if (currentPants != null)
        {
            Destroy(currentPants); // 현재 장착된 바지 삭제
        }
        currentPants = Instantiate(pantsPrefab, pantsSlot.transform);
    }
}
