using System;
using System.Windows.Controls;

namespace Beatbox
{
	public class Milestones
	{
		private Milestones()
		{
		}

		public static Milestone Level(int value, TextBlock textBlock)
        {
			Milestone milestone = new Milestone();
			milestone.DateTime = DateTime.Now;

			if (value > 100)
			{
				milestone.Name = "Level 100";
				milestone.Description = "You made it to level 100! Now that took a while...";
				return milestone;
			}
			else if (value > 50)
			{
				milestone.Name = "Level 50";
				milestone.Description = "You really have nothing else to do, do you?";
				return milestone;
			}
			else if (value > 25)
			{
				milestone.Name = "Level 25";
				milestone.Description = "Not bad. Not bad at all.";
				return milestone;
			}
			else if (value > 10)
			{
				milestone.Name = "Level 10";
				milestone.Description = "Good job, keep it up.";
				return milestone;
			}
			else return null;
		}
		public static Milestone Rate(double value, TextBlock textBlock)
		{
			Milestone milestone = new Milestone();
			milestone.DateTime = DateTime.Now;

			if (value < 0.5)
			{
				milestone.Name = "Too fast, definitely!";
				milestone.Description = "How are you going to hit the button in the right moment now, Flash?";
				return milestone;
			}
			else if (value < 1.0)
			{
				milestone.Name = "Swoosh";
				milestone.Description = "Did you see that? I didn't, it was too fast.";
				return milestone;
			}
			else if (value < 1.5)
			{
				milestone.Name = "Turbo Mode";
				milestone.Description = "You might crash into things now... more frequent than usual.";
				return milestone;
			}
			else if (value < 2.0)
			{
				milestone.Name = "Faster";
				milestone.Description = "So you found that button, huh?";
				return milestone;
			}
			else return null;
		}
		public static Milestone Record(int value, TextBlock textBlock)
		{
			Milestone milestone = new Milestone();
			milestone.DateTime = DateTime.Now;

			if (value > 1000000)
			{
				milestone.Name = "Seriously? WTF!";
				milestone.Description = "Now you can stop...";
				return milestone;
			}
			else if (value > 100000)
			{
				milestone.Name = "Golden Trophy";
				milestone.Description = "When you concider that you started with like 10...";
				return milestone;
			}
			else if (value > 50000)
			{
				milestone.Name = "Oh wow!";
				milestone.Description = "I think there is a bit more possible.";
				return milestone;
			}
			else if (value > 10000)
			{
				milestone.Name = "Silver Medal";
				milestone.Description = "Good one, nice hit!";
				return milestone;
			}
			else if (value > 1000)
			{
				milestone.Name = "1k Damage";
				milestone.Description = "Yeah, thats the common one.";
				return milestone;
			}
			else if (value > 100)
			{
				milestone.Name = "Improvable";
				milestone.Description = "Now that you know how it works, you can do more!";
				return milestone;
			}
			else return null;
		}
		public static Milestone Continuous(int value, TextBlock textBlock)
		{
			Milestone milestone = new Milestone();
			milestone.DateTime = DateTime.Now;
			if (value > 100)
			{
				milestone.Name = "100 times in a row";
				milestone.Description = "Is that even possible? You cheated!";
				return milestone;
			}
			else if (value > 50)
			{
				milestone.Name = "50 crits";
				milestone.Description = "Now that you know how it works, you can do more!";
				return milestone;
			}
			else if (value > 25)
			{
				milestone.Name = "25 streak";
				milestone.Description = "That is really impressive!";
				return milestone;
			}
			else if (value > 10)
			{
				milestone.Name = "10 crits in a row";
				milestone.Description = "Do you think you can do more than that? Try it.";
				return milestone;
			}
			else return null;
		}
		public static Milestone Sum(int value, TextBlock textBlock)
		{
			Milestone milestone = new Milestone();
			milestone.DateTime = DateTime.Now;

			if (value > 10000000)
			{
				milestone.Name = "10.000.000 Damage Done!";
				milestone.Description = "You are here for hours. Get some fresh air.";
				return milestone;
			}
			else if (value > 1000000)
			{
				milestone.Name = "1 Million";
				milestone.Description = "You beat that box really a lot.";
				return milestone;
			}
			else if (value > 524288)
			{
				milestone.Name = "524288 = 2^19, yes.";
				milestone.Description = "Because 500.000 would be boring.";
				return milestone;
			}
			else if (value > 100000)
			{
				milestone.Name = "That's 100k";
				milestone.Description = "Oh, you are still here? Thanks!";
				return milestone;
			}
			else if (value > 10000)
			{
				milestone.Name = "10.000 damage dealt";
				milestone.Description = "Looks good, continue beating.";
				return milestone;
			}
			else if (value > 1000)
			{
				milestone.Name = "1000 damage dealt";
				milestone.Description = "And that box is still there...";
				return milestone;
			}
			else return null;
		}
		public static Milestone Success(int value, TextBlock textBlock)
		{
			Milestone milestone = new Milestone();
			milestone.DateTime = DateTime.Now;

			if (value > 1000)
			{
				milestone.Name = "1000 button strikes";
				milestone.Description = "Is that button still working?";
				return milestone;
			}
			else if (value > 500)
			{
				milestone.Name = "500 times that you hit the button";
				milestone.Description = "Tired already? No? Keep on going.";
				return milestone;
			}
			else if (value > 250)
			{
				milestone.Name = "250 button strikes";
				milestone.Description = "Did you count?";
				return milestone;
			}
			else if (value > 100)
			{
				milestone.Name = "100 times succeeded";
				milestone.Description = "Yes, that is how often you managed to hit the button in the right moment!";
				return milestone;
			}
			else return null;
		}
	}
}
