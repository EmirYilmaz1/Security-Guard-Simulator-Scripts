using UnityEngine;

[CreateAssetMenu(fileName = "New People", menuName = "People")]

public class People : ScriptableObject
{
    public int peopleId;
    public Names peopleName;
    public int peopleAge;
    public Works peopleWork;
}
public enum Works {Chef,DJ,Athlete,Doctor,Waiter}
public enum Names{Mike,Olivia,Charlote,Oliver,Ethan,Chloe}