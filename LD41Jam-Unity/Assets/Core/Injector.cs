using System.Collections.Generic;

public class Injector
{
    private static Injector instance;

    private RecipeManager _recipeManager;
    private WoodenAxeRecipe _woodenAxeRecipe;
    private CopperAxeRecipe _copperAxeRecipe;
    private WoodProcessor _woodProcessor;
    private WoolProcessor _woolProcessor;
    private CopperProcessor _copperProcessor;

    private Injector() { }

    public static Injector Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Injector();
            }
            return instance;
        }
    }

    public WoodenAxeRecipe WoodenAxeRecipe()
    {
        if (_woodenAxeRecipe == null)
        {
            _woodenAxeRecipe = new WoodenAxeRecipe();
        }
        return _woodenAxeRecipe;
    }

    public CopperAxeRecipe CopperAxeRecipe()
    {
        if (_copperAxeRecipe == null)
        {
            _copperAxeRecipe = new CopperAxeRecipe();
        }
        return _copperAxeRecipe;
    }

    public RecipeManager RecipeManager()
    {
        if (_recipeManager == null)
        {
            _recipeManager = new RecipeManager()
            {
                Recipes = new HashSet<Recipe>
                {
                    WoodenAxeRecipe(),
                    CopperAxeRecipe()
                }
            };
        }
        return _recipeManager;
    }

    public WoodProcessor WoodProcessor()
    {
        if (_woodProcessor == null)
        {
            _woodProcessor = new WoodProcessor();
        }
        return _woodProcessor;
    }

    public WoolProcessor WoolProcessor()
    {
        if (_woolProcessor == null)
        {
            _woolProcessor = new WoolProcessor();
        }
        return _woolProcessor;
    }

    public CopperProcessor CopperProcessor()
    {
        if (_copperProcessor == null)
        {
            _copperProcessor = new CopperProcessor();
        }
        return _copperProcessor;
    }

}
