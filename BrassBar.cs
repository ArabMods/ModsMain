//Blackhat Modding 2020
namespace Eco.Mods.TechTree
{
    // [DoNotLocalize]
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class BrassIngotRecipe : Recipe
    {
        public IronIngotRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BrassIngotItem>(2)

            };
            this.Ingredients = new CraftingElement[]
            {
              new CraftingElement<ZincBarItem>(1),
              new CraftingElement<CopperIngotItem>(1)
            };
            this.ExperienceOnCraft = 2;

            this.CraftMinutes = CreateCraftTimeValue(typeof(BrassBarRecipe), Item.Get<BrassBarItem>().UILink(), 4, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Brass Bar"), typeof(BrassBarRecipe));

            CraftingComponent.AddRecipe(typeof(BloomeryObject), this);
        }
    }

    [Serialized]
    [Weight(2500)]
    [Currency]
    public partial class BrassBarItem :
    Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Brass Bar"); } }
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Brass Bars"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Alloy of Zinc and Copper"); } }
    }
}
