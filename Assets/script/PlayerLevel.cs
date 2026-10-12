using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [Header("Level & EXP")]
    public int currentLevel = 1;
    public int currentExp = 0;
    public int expToNextLevel = 100; // EXP ที่ต้องการเพื่อขึ้นเลเวลถัดไป

    public void AddExp(int amount)
    {
        currentExp += amount;
        Debug.Log("ได้รับ EXP: " + amount + " | EXP ปัจจุบัน: " + currentExp + "/" + expToNextLevel);

        // ตรวจสอบว่า EXP ถึงเกณฑ์เลเวลอัปหรือยัง
        while (currentExp >= expToNextLevel)
        {
            currentExp -= expToNextLevel;
            LevelUp();
        }
    }

    void LevelUp()
    {
        currentLevel++;
        // เพิ่มความยากในการอัปเลเวลครั้งต่อไป (เช่น คูณ 1.5 เท่า)
        expToNextLevel = Mathf.RoundToInt(expToNextLevel * 1.5f);

        Debug.Log("🎉 Level Up! ตอนนี้เลเวล: " + currentLevel);

        // ตรงนี้สามารถเพิ่มโค้ดเพิ่มพลังชีวิตผู้เล่น หรือเพิ่มดาเมจได้ในอนาคต
    }
}