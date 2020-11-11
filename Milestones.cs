using System;
using System.Windows.Controls;

namespace Beatbox
{
	/// <summary>
	/// Factory class to create Milestone objects depending on the value given.
	/// A counter is provided to keep track of milestones already reached.
	/// Use <c>Reset_Counters()</c> method for a new instance.
	/// </summary>
	public class Milestones
	{
		public static int Rate_Count { get; set; }
		public static int Record_Count { get; set; }
		public static int Continuous_Count { get; set; }
		public static int Sum_Count { get; set; }
		public static int Success_Count { get; set; }

		private Milestones()
		{
		}

		public static Milestone Level(int value)
        {
			Milestone milestone = new Milestone();
			milestone.DateTime = DateTime.Now;

			if (value == 100)
			{
				milestone.Name = "Level 100";
				milestone.Description = "You made it to level 100! Now that took a while...";
				return milestone;
			}
			else if (value == 50)
			{
				milestone.Name = "Level 50";
				milestone.Description = "You really have nothing else to do, do you?";
				return milestone;
			}
			else if (value == 25)
			{
				milestone.Name = "Level 25";
				milestone.Description = "Not bad. Not bad at all.";
				return milestone;
			}
			else if (value == 10)
			{
				milestone.Name = "Level 10";
				milestone.Description = "Good job, keep it up.";
				return milestone;
			}
			else return null;
		}
		public static Milestone Rate(double value)
		{
			Milestone milestone = new Milestone();
			milestone.DateTime = DateTime.Now;

			if (value < 0.5 && Rate_Count == 3)
			{
				milestone.Name = "Too fast, definitely!";
				milestone.Description = "How are you going to hit the button in the right moment now, Flash?";
				Rate_Count++;
				return milestone;
			}
			else if (value < 1.0 && Rate_Count == 2)
			{
				milestone.Name = "Swoosh";
				milestone.Description = "Did you see that? I didn't, it was too fast.";
				Rate_Count++;
				return milestone;
			}
			else if (value < 1.5 && Rate_Count == 1)
			{
				milestone.Name = "Turbo Mode";
				milestone.Description = "You might crash into things now... more frequent than usual.";
				Rate_Count++;
				return milestone;
			}
			else if (value < 2.0 && Rate_Count == 0)
			{
				milestone.Name = "Faster";
				milestone.Description = "So you found that button, huh?";
				Rate_Count++;
				return milestone;
			}
			else return null;
		}
		public static Milestone Record(int value)
		{
			Milestone milestone = new Milestone();
			milestone.DateTime = DateTime.Now;

			if (value > 1000000 && Record_Count == 5)
			{
				milestone.Name = "Seriously? WTF!";
				milestone.Description = "Now you can stop...";
				Record_Count++;
				return milestone;
			}
			else if (value > 100000 && Record_Count == 4)
			{
				milestone.Name = "Golden Trophy";
				milestone.Description = "When you concider that you started with like 10...";
				Record_Count++;
				return milestone;
			}
			else if (value > 50000 && Record_Count == 3)
			{
				milestone.Name = "Oh wow!";
				milestone.Description = "I think there is a bit more possible.";
				Record_Count++;
				return milestone;
			}
			else if (value > 10000 && Record_Count == 2)
			{
				milestone.Name = "Silver Medal";
				milestone.Description = "Good one, nice hit!";
				Record_Count++;
				return milestone;
			}
			else if (value > 1000 && Record_Count == 1)
			{
				milestone.Name = "1k Damage";
				milestone.Description = "Yeah, thats the common one.";
				Record_Count++;
				return milestone;
			}
			else if (value > 100 && Record_Count == 0)
			{
				milestone.Name = "Improvable";
				milestone.Description = "Now that you know how it works, you can do more!";
				Record_Count++;
				return milestone;
			}
			else return null;
		}
		public static Milestone Continuous(int value)
		{
			Milestone milestone = new Milestone();
			milestone.DateTime = DateTime.Now;
			if (value == 20 && Continuous_Count == 3)
			{
				milestone.Name = "20 times in a row";
				milestone.Description = "Is that even possible? You cheated!";
				Continuous_Count++;
				return milestone;
			}
			else if (value == 10 && Continuous_Count == 2)
			{
				milestone.Name = "10 crits";
				milestone.Description = "Now that you know how it works, you can do more!";
				Continuous_Count++;
				return milestone;
			}
			else if (value == 5 && Continuous_Count == 1)
			{
				milestone.Name = "5 streak";
				milestone.Description = "That is really impressive!";
				Continuous_Count++;
				return milestone;
			}
			else if (value == 3 && Continuous_Count == 0)
			{
				milestone.Name = "3 crits in a row";
				milestone.Description = "Do you think you can do more than that? Try it.";
				Continuous_Count++;
				return milestone;
			}
			else return null;
		}
		public static Milestone Sum(int value)
		{
			Milestone milestone = new Milestone();
			milestone.DateTime = DateTime.Now;

			if (value > 10000000 && Sum_Count == 0)
			{
				milestone.Name = "10.000.000 Damage Done!";
				milestone.Description = "You are here for hours. Get some fresh air.";
				Sum_Count++;
				return milestone;
			}
			else if (value > 1000000 && Sum_Count == 0)
			{
				milestone.Name = "1 Million";
				milestone.Description = "You beat that box really a lot.";
				Sum_Count++;
				return milestone;
			}
			else if (value > 524288 && Sum_Count == 0)
			{
				milestone.Name = "524288 = 2^19, yes.";
				milestone.Description = "Because 500.000 would be boring.";
				Sum_Count++;
				return milestone;
			}
			else if (value > 100000 && Sum_Count == 0)
			{
				milestone.Name = "That's 100k";
				milestone.Description = "Oh, you are still here? Thanks!";
				Sum_Count++;
				return milestone;
			}
			else if (value > 10000 && Sum_Count == 0)
			{
				milestone.Name = "10.000 damage dealt";
				milestone.Description = "Looks good, continue beating.";
				Sum_Count++;
				return milestone;
			}
			else if (value > 1000 && Sum_Count == 0)
			{
				milestone.Name = "1000 damage dealt";
				milestone.Description = "And that box is still there...";
				Sum_Count++;
				return milestone;
			}
			else return null;
		}
		public static Milestone Success(int value)
		{
			Milestone milestone = new Milestone();
			milestone.DateTime = DateTime.Now;

			if (value == 1000 && Success_Count == 0)
			{
				milestone.Name = "1000 button strikes";
				milestone.Description = "Is that button still working?";
				Success_Count++;
				return milestone;
			}
			else if (value == 500 && Success_Count == 0)
			{
				milestone.Name = "500 times that you hit the button";
				milestone.Description = "Tired already? No? Keep on going.";
				Success_Count++;
				return milestone;
			}
			else if (value == 250 && Success_Count == 0)
			{
				milestone.Name = "250 button strikes";
				milestone.Description = "Did you count?";
				Success_Count++;
				return milestone;
			}
			else if (value == 100 && Success_Count == 0)
			{
				milestone.Name = "100 times succeeded";
				milestone.Description = "Getting better, but improvable.";
				Success_Count++;
				return milestone;
			}
			else if (value == 10 && Success_Count == 0)
			{
				milestone.Name = "10 button strikes";
				milestone.Description = "Yes, that is how often you managed to hit the button in the right moment!";
				Success_Count++;
				return milestone;
			}
			else return null;
		}

		public void Reset_Counters()
		{
            Rate_Count = 0;
            Record_Count = 0;
            Continuous_Count = 0;
            Sum_Count = 0;
            Success_Count = 0;
		}
	}
}
