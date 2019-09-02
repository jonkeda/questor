using System.Collections.ObjectModel;
using System.Linq;
using Questor.Models.Prototypes;

namespace Questor.Models.Quests
{
    public class GoalFunctionCollection : ObservableCollection<GoalFunction>
    {

        private static readonly GoalFunctionCollection Goals = new GoalFunctionCollection
        {
            new GoalFunction("entities_created", "Entities created", DataType.Entity, "entity-name", "create_entity_quest"),
            // new GoalFunction("entities_updated", "Entities updated", DataType.Entity, "entity-name"),

            new GoalFunction("items_created", "Items created", DataType.Item, "item-name", "create_item_quest"),
            new GoalFunction("items_created_per_minute", "Items created per minute", DataType.Item, "item-name", "create_item_per_minute_quest"),
                
            new GoalFunction("fluids_created", "Fluids created", DataType.Fluid, "fluid-name", "create_fluid_quest"),
            new GoalFunction("fluids_created_per_minute", "Fluids created per minute", DataType.Fluid, "fluid-name", "create_fluid_per_minute_quest"),
                
            new GoalFunction("technology_researched", "Technology researched", DataType.Technology, "technology-name", "research_technology_quest"),
            new GoalFunction("technologies_researched", "Number of Technologies researched", DataType.Technology, "technology-name", "technologies_researched_quest"),
                
//                new GoalFunction("enemies_killed", "Enemies killed", DataType.Enemies),
//                
//                new GoalFunction("units_recruited", "Units Recruited", DataType.Units)
        };

        public static GoalFunctionCollection Default()
        {
            return Goals;
        }

        public static GoalFunction GetByName(string functionName)
        {
            return Goals.FirstOrDefault(g => g.Name == functionName);
        }
    }
}