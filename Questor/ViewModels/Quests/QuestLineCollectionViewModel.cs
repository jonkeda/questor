using System.Windows;
using Questor.Models.Quests;
using Questor.Views.Quests;

namespace Questor.ViewModels.Quests
{
    public class QuestLineCollectionViewModel : CollectionViewModel<QuestLineCollection, QuestLineViewModel, QuestLine>
    {
        public QuestLineCollectionViewModel(QuestLineCollection models) : base(models)
        {
            IsExpanded = true;
        }

        public override void Create()
        {

            CreateQuestLineWindow window = new CreateQuestLineWindow
            {
                Owner = Application.Current.MainWindow
            };


            if (window.ShowDialog() ==  true)
            {
                string goalFunctionName = window.ViewModel.GoalFunctionName;
                string goalValue = window.ViewModel.GoalValue;
                int goalAmount = window.ViewModel.GoalAmount;
                int goalMultiplier = window.ViewModel.GoalMultiplier;

                string rewardFunctionName = window.ViewModel.RewardFunctionName;
                string rewardValue = window.ViewModel.RewardValue;
                int rewardAmount = window.ViewModel.RewardAmount;
                int rewardMultiplier = window.ViewModel.RewardMultiplier;

                QuestLine questLine = new QuestLine
                {
                    Name = goalValue
                };

                for (int i = 0; i < window.ViewModel.NumberOfQuests; i++)
                {
                    Quest quest = new Quest
                    {
                        Name = $@"{goalValue}_{goalAmount}"
                    };
                    questLine.Quests.Add(quest);
                    
                    quest.Goals.Add(new Goal {FunctionName = goalFunctionName, Amount = goalAmount, Value = goalValue});
                    quest.Rewards.Add(new Reward {FunctionName = rewardFunctionName, Amount = rewardAmount, Value = rewardValue});

                    goalAmount *= goalMultiplier;
                    rewardAmount *= rewardMultiplier;
                }

                Models.Add(questLine);
            }

        }
    }
}