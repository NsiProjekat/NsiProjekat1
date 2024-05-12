using Ardalis.SmartEnum;

namespace NsiProjekat1.Domain.Enums;

public abstract class Category : SmartEnum<Category>
{
    public static Category Tech = new TechCategory();
    public static Category Phone = new PhoneCategory();
    public static Category Laptop = new LaptopCategory();
    public static Category Desktop = new DesktopCategory();
    public static Category Clothes = new ClothesCategory();
    public static Category Shirt = new ShirtCategory();
    public static Category Cap = new CapCategory();

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

    private sealed class ClothesCategory : Category
    {
        public ClothesCategory() : base(nameof(Clothes),
            2)
        {
        }

        public override string Description => "Opis o clothes kategoriji!";

        public override List<Category> Subcategories => new()
        {
            Shirt
        };
    }

    private sealed class PhoneCategory : Category
    {
        public PhoneCategory() : base(nameof(Phone),
            3)
        {
        }

        public override string Description => "Opis o Phone kategoriji!";

        public override List<Category> Subcategories => new();
    }

    private sealed class LaptopCategory : Category
    {
        public LaptopCategory() : base(nameof(Laptop),
            4)
        {
        }

        public override string Description => "Opis o Laptop kategoriji!";

        public override List<Category> Subcategories => new();
    }
    
    private sealed class DesktopCategory : Category
    {
        public DesktopCategory() : base(nameof(Desktop),
            5)
        {
        }

        public override string Description => "Opis o Desktop kategoriji!";

        public override List<Category> Subcategories => new();
    }
    
    private sealed class ShirtCategory : Category
    {
        public ShirtCategory() : base(nameof(Shirt),
            6)
        {
        }

        public override string Description => "Opis o Shirt kategoriji!";

        public override List<Category> Subcategories => new();
    }
    private sealed class CapCategory : Category
    {
        public CapCategory() : base(nameof(Cap),
            7)
        {
        }

        public override string Description => "Opis o Cap kategoriji!";

        public override List<Category> Subcategories => new();
    }
}
