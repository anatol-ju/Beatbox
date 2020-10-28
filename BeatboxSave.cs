using System;
using System.CodeDom;

public class BeatboxSave
{
    public int currentXP;
    public int currentLevel;
    public int currentAP;
    public int currentCR;
    public int currentHR;
    public int currentDamagePerHit;
    public int currentAttackRate;
    public double currentCritChance;
    public int currentRecord;

    public int availablePoints;
    public int overdraft;
    public int sumDamage;


    public BeatboxSave()
	{
	}

    private static readonly Lazy<BeatboxSave> lazy = new Lazy<BeatboxSave>(() => new BeatboxSave());
    public static BeatboxSave Instance
    {
        get
        {
            return lazy.Value;
        }
    }

}
