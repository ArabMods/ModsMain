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

    [RequiresSkill(typeof(MechanicsSkill), 0)]
    public partial class BrassGearRecipe : Recipe
    {
        public GearRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BrassGearItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BrassBarItem>(typeof(MechanicsSkill), 3, MechanicsSkill.MultiplicativeStrategy, typeof(MechanicsLavishResourcesTalent)),
            };
            this.ExperienceOnCraft = 1;

            this.CraftMinutes = CreateCraftTimeValue(typeof(BrassGearRecipe), Item.Get<BrassGearItem>().UILink(), 1, typeof(MechanicsSkill), typeof(MechanicsFocusedSpeedTalent), typeof(MechanicsParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Brass Gear"), typeof(BrassGearRecipe));

            CraftingComponent.AddRecipe(typeof(ShaperObject), this);
        }
    }

    [Serialized]
    [Weight(500)]
    [Currency]
    public partial class BrassGearItem :
    Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Brass Gear"); } }
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Brass Gears"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A soft toothed machine part that interlocks with others."); } }
    }
}
