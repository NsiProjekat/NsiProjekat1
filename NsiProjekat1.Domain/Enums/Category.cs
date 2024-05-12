using Ardalis.SmartEnum;

namespace NsiProjekat1.Domain.Enums;

public abstract class Category : SmartEnum<Category>
{
    public static Category Tech = new TechCategory();
    public static Category Phone = new PhoneCategory();
    public static Category Laptop = new LaptopCategory();
    public static Category Desktop = new Desktop();
    public static Category Sports = new SportsCategory();
    public static Category FPS = new FPSCategory();

    public abstract string Description { get; }
    public abstract List<Category> Subcategories { get; }

    public Category(string name, int value) : base(name,
        value)
    {
    }

    private sealed class TechCategory : Category
    {
        public TechCategory() : base(nameof(TechCategory),
            1)
        {
        }

        public override string Description => "Opis o tech kategoriji!";

        public override List<Category> Subcategories => new()
        {
            Phone,Laptop,Desktop
        };
    }

    private sealed class MultiplayerCategory : Category
    {
        public MultiplayerCategory() : base(nameof(Multiplayer),
            2)
        {
        }

        public override string Description => "Opis o multiplayer igrama!";

        public override List<Category> Subcategories => new()
        {
            Sports, FPS
        };
    }

    private sealed class RPGCategory : Category
    {
        public RPGCategory() : base(nameof(RPG),
            3)
        {
        }

        public override string Description => "Opis o RPG igrama!";

        public override List<Category> Subcategories => new();
    }

    private sealed class SimulationCategory : Category
    {
        public SimulationCategory() : base(nameof(Simulation),
            4)
        {
        }

        public override string Description => "Opis o simulacijama!";

        public override List<Category> Subcategories => new();
    }
    
    private sealed class SportsCategory : Category
    {
        public SportsCategory() : base(nameof(Sports),
            5)
        {
        }

        public override string Description => "Opis o sportskim igrama!";

        public override List<Category> Subcategories => new();
    }
    
    private sealed class FPSCategory : Category
    {
        public FPSCategory() : base(nameof(FPS),
            6)
        {
        }

        public override string Description => "Opis o FPS igrama!";

        public override List<Category> Subcategories => new();
    }
}
