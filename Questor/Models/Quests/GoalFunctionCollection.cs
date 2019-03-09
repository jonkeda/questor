using System.Collections.ObjectModel;
using Questor.Models.Prototypes;

namespace Questor.Models.Quests
{
    public class GoalFunctionCollection : ObservableCollection<GoalFunction>
    {

        public static GoalFunctionCollection Default()
        {
            return new GoalFunctionCollection
            {
                new GoalFunction("entities_created", "Entities created", DataType.Entity),
                // new GoalFunction("entities_updated", "Entities updated", DataType.Entity),

                new GoalFunction("items_created", "Items created", DataType.Item),
                new GoalFunction("items_created_per_minute", "Items created per minute", DataType.Item),
                
                new GoalFunction("fluids_created", "Fluids created", DataType.Fluid),
                new GoalFunction("fluids_created_per_minute", "Fluids created per minute", DataType.Fluid),
                
                new GoalFunction("technology_researched", "Technology researched", DataType.Technology),
                new GoalFunction("technologies_researched", "Number of Technologies researched", DataType.Technology),
                
//                new GoalFunction("enemies_killed", "Enemies killed", DataType.Enemies),
//                
//                new GoalFunction("units_recruited", "Units Recruited", DataType.Units)
            };
        }
    }
}