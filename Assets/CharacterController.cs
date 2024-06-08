using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject pantsSlot; // ������ ������ ��ġ
    public GameObject pants1Prefab;
    public GameObject pants2Prefab;

    private GameObject currentPants;

    void Start()
    {
        EquipPants(pants1Prefab); // �⺻ ������ ����
    }

    public void EquipPants(GameObject pantsPrefab)
    {
        if (currentPants != null)
        {
            Destroy(currentPants); // ���� ������ ���� ����
        }
        currentPants = Instantiate(pantsPrefab, pantsSlot.transform);
    }
}
