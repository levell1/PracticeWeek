# PracticeWeek

<BR><BR>

<center><H1> PracticeWeek </H1></center>

<BR><BR>

<H2> 2조. 김종욱 </H2>

<BR><BR>

# 계획
발제를 보고 상점까지를 목표로 대략적인 스크립트와 UI를 만들며 진행 하였습니다.  
객체지향, JSON, 강의에서 배운 내용(ScriptableObject등)을 사용하는 목표로  개인과제를 시작하였습니다.


<br>

> **`필수 과제`**  
> 1. 메인 화면 구성
> 2. Status 보기
> 3. Inventory 보기

<br>

> **`추가 과제`**  
> 1. 아이템 장착 팝업 업그레이드 



<br><br>

# 1. 필수요구사항

## 1. 메인 화면 구성

![image](https://github.com/levell1/levell1.github.io/assets/96651722/49d4bc5b-5d1c-45a6-bdcb-56d3f490f38b)   
> - 좌측 : 이름, 직업, 레벨, exp / maxexp  
> - 우측 : 스텟, 인벤 버튼


**플레이어 정보.JSON**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/efaedff8-1a9a-407c-ad80-dafb6b56f9d9)     


<br><br>

**stat**
<details>
<summary>CharacterStat.cs</summary>

<div class="notice--primary" markdown="1"> 


```c#

[System.Serializable]
public class CharacterStat
{
    public string Id;
    public string Job;
    public int Level;
    public int Gold;
    public int Exp;
    public int MaxExp;
    public int Attack;
    public int Def;
    public int HP;
    public int Cri;
}

```
</div>
</details>

<br><br>

**jsonLoad,Save**

<details>
<summary>SavePlayerData.cs</summary>

<div class="notice--primary" markdown="1"> 

```c#
using System.IO;
using UnityEngine;

public class JsonLoad
{
    public void SavePlayerData(CharacterStat player)
    {
        string jsonData = JsonUtility.ToJson(player, true);
        string path = Path.Combine(Application.dataPath, "PlayerData.json");
        File.WriteAllText(path, jsonData);
    }
    public CharacterStat LoadPlayerData(CharacterStat player, string json)
    {
        string path = Path.Combine(Application.dataPath, json);
        string jsonData = File.ReadAllText(path);
        player = JsonUtility.FromJson<CharacterStat>(jsonData);
        return player;
    }
}


```
</div>
</details>

<br><br><br><br><br>

# Play

<br><br>

# 느낀점

**문제점**  

**궁금한 점**
> - 

**봐주셔서 감사합니다.**




<br><br>
