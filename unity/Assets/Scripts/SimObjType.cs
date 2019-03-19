// Copyright Allen Institute for Artificial Intelligence 2017
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public enum SimObjManipType : int { //We aren't using these manip types for the Physics Implementation, they are being replaced with the SimObjPrimaryProperty below
	Inventory = 0,
	Static = 1,
	Rearrangeable = 2,
	StaticNoPlacement = 3,
}

[Serializable]
public enum SimObjPrimaryProperty : int // EACH SimObjPhysics MUST HAVE 1 Primary propert, no more no less
{
	//NEVER LEAVE UNDEFINED
	Undefined = 0,

    //PRIMARY PROPERTIES
    Static = 1,
    Moveable = 2,
    CanPickup = 3,

    //these are to identify walls, floor, ceiling - these are not currently being used but might be in the future once
	//all scenes have their walls/floor/ceiling meshes split apart correctly (thanks Eli!)
    Wall = 4,
    Floor = 5,
    Ceiling = 6
}

[Serializable]
public enum SimObjSecondaryProperty : int //EACH SimObjPhysics can have any number of Secondary Properties
{
	//NEVER LEAVE UNDEFINED
	Undefined = 0,

	//CLEANABLE PROPERTIES - this property defines what objects can clean certain objects
    CanBeCleanedFloor = 1,
    CanBeCleanedDishware = 2,
    CanBeCleanedGlass = 3,

    //OTHER SECONDARY PROPERTIES 
    CanCleanFloor = 4,
    CanCleanDishware = 5,
    CanCleanGlass = 6,
    Receptacle = 7,
    CanOpen = 8,
    CanBeSliced = 9,
    CanSlice = 10,
    CanBeCracked = 11,
    CanBeFilledWithWater = 12,
    CanFillWithWater = 13,
    CanBeHeatedCookware = 14,
    CanHeatCookware = 15,
    CanBeStoveTopCooked = 16,
    CanStoveTopCook = 17,
    CanBeMicrowaved = 18,
    CanMicrowave = 19,
    CanBeToasted = 20,
    CanToast = 21,
    CanBeFilledWithCoffee = 22,
    CanFillWithCoffee = 23,
    CanBeWatered = 24,
    CanWater = 25,
    CanBeFilledWithSoap = 26,
    CanFillWithSoap = 27,
    CanBeUnrolled = 28,
    CanToggleOnOff = 29,
    CanBeBedMade = 30,
    CanBeMounted = 31,
    CanMount = 32,
	CanBeHungTowel = 33,
    CanHangTowel = 34,
    CanBeOnToiletPaperHolder = 35,
    CanHoldToiletPaper = 36,
    CanBeClogged = 37,
    CanUnclog = 38,
    CanBeOmelette = 39,
    CanMakeOmelette = 40,
    CanFlush = 41,
    CanTurnOnTV = 42,
    CanMountSmall = 43,
    CanMountMedium = 44,
    CanMountLarge = 45,
    CanBeMountedSmall = 46,
    CanBeMountedMedium = 47,
    CanBeMountedLarge = 48,
    CanBeLitOnFire = 49,
    CanLightOnFire = 50,
    CanSeeThrough = 51,
	ObjectSpecificReceptacle = 52,
}

[Serializable]
public enum SimObjType : int
{
	//undefined is always the first value
	Undefined = 0,
	//ADD NEW VALUES BELOW
	//DO NOT RE-ARRANGE OLDER VALUES
	Apple = 1,
	AppleSliced = 2,
	Tomato = 3,
	TomatoSliced = 4,
	Bread = 5,
	BreadSliced = 6,
	Sink = 7,
	Pot = 8,
	Pan = 9,
	Knife = 10,
	Fork = 11,
	Spoon = 12,
	Bowl = 13,
	Toaster = 14,
	CoffeeMachine = 15,
	Microwave = 16,
	StoveBurner = 17,
	Fridge = 18,
	Cabinet = 19,
	Egg = 20,
	Chair = 21,
	Lettuce = 22,
	Potato = 23,
	Mug = 24,
	Plate = 25,
	TableTop = 26,
	CounterTop = 27,
	GarbageCan = 28,
	Omelette = 29,
	EggShell = 30,
	EggFried = 31,
	StoveKnob = 32,
	Container = 33, //for physics version - see GlassBottle
	Cup = 34,
	ButterKnife = 35,
	PotatoSliced = 36,
	MugFilled = 37, //not used in physics
	BowlFilled = 38, //not used in physics
	Statue = 39,
	LettuceSliced = 40,
	ContainerFull = 41, //not used in physics
	BowlDirty = 42, //not used in physics
	Sandwich = 43, //will need to make new prefab for physics
	Television = 44,
	HousePlant = 45,
	TissueBox = 46,
	VacuumCleaner = 47,
	Painting = 48,//delineated sizes in physics
	WateringCan = 49,
	Laptop = 50,
	RemoteControl = 51,
	Box = 52,
	Newspaper = 53,
	TissueBoxEmpty = 54,//will be a state of TissuBox in physics
	PaintingHanger = 55,//delineated sizes in physics
	KeyChain = 56,
	Dirt = 57, //physics will use a different cleaning system entirely
	CellPhone = 58,
	CreditCard = 59,
	Cloth = 60,
	Candle = 61,
	Toilet = 62,
	Plunger = 63,
	Bathtub = 64,
	ToiletPaper = 65,
	ToiletPaperHanger = 66,
	SoapBottle = 67,
	SoapBottleFilled = 68,//will become a state of SoapBottle in physics
	SoapBar = 69,
	ShowerDoor = 70,
	SprayBottle = 71,
	ScrubBrush = 72,
	ToiletPaperRoll = 73,
	Lamp = 74, //don't use this, use either FloorLamp or DeskLamp
	LightSwitch = 75,
	Bed = 76,
	Book = 77,
	AlarmClock = 78,
	SportsEquipment = 79,//delineated into specific objects in physics - see Basketball etc
	Pen = 80,
	Pencil = 81,
	Blinds = 82,
	Mirror = 83, 
	TowelHolder = 84,
	Towel = 85,
	Watch = 86,
	MiscTableObject = 87,//not sure what this is, not used for physics

    ArmChair = 88,
    BaseballBat = 89,
    BasketBall = 90,
    Faucet = 91,
    Boots = 92,
    Glassbottle = 93,
    DishSponge = 94,
    Drawer = 95,
    FloorLamp= 96,
    Kettle = 97,   
    LaundryHamper = 98,
    LaundryHamperLid = 99,
    Lighter = 100,
    Ottoman = 101,
    PaintingSmall = 102,
    PaintingMedium = 103,
    PaintingLarge = 104,
    PaintingHangerSmall = 105,
    PaintingHangerMedium = 106,
    PaintingHangerLarge = 107,
    PanLid = 108,
    PaperTowelRoll = 109,
    PepperShaker = 110,
    PotLid = 111,
    SaltShaker = 112,
    Safe = 113,
    SmallMirror = 114,//maybe don't use this, use just 'Mirror' instead
    Sofa = 115,
    SoapContainer = 116,
    Spatula = 117,
    TeddyBear = 118,
    TennisRacket = 119,
    Tissue = 120,
    Vase = 121,
    WallMirror = 122, //maybe don't use this, just use 'Mirror' instead?
	MassObjectSpawner = 123,
    MassScale = 124,
    Footstool = 125,
	Shelf = 126,
	Dresser = 127,
	Desk = 128,
	NightStand = 129,
	Pillow = 130,
	Bench = 131,
	Cart = 132, //bathroom cart on wheels
	ShowerGlass = 133,
	DeskLamp = 134,
	Window = 135,
	BathtubBasin = 136,
	SinkBasin = 137,
	CD = 138,
	Curtains = 139,
	Poster = 140,
	HandTowel = 141,

	HandTowelHolder = 142,
	Ladle = 143,
	WineBottle = 144,



	
}

public static class ReceptacleRestrictions
{

	//these objects generate UniqueIDs based on their parent object to show that they are related. ie: "Bathtub|1|1|1|" has a child sim object BathtubBasin with the ID "Bathtub|1|1|1|BathtubBasin"
	//this is specifically used for objects that have distinct zones that should be individually interactable (outer part vs inner part) but share the same geometry, like a bathtub.
	//Objets like a Coffeetable with inset Drawers should NOT be on this list because those objects do not share geometry (table vs drawer)
	public static List<SimObjType> UseParentUniqueIDasPrefix = new List<SimObjType>()
	{SimObjType.BathtubBasin,SimObjType.SinkBasin};

    //Objects are "placed into/placed in" these receptacles
    //The object placed must have the entirety of it's object oriented bounding box (all 8 corners) enclosed within the Receptacle's Box
    public static List<SimObjType> InReceptacles = new List<SimObjType>() 
    {SimObjType.Drawer, SimObjType.Cabinet, SimObjType.Fridge, SimObjType.Microwave, SimObjType.LaundryHamper};

    //Objects are "placed on top of/placed on" these receptacles
    //the object placed only needs the bottom most 4 corners within the Receptacle Box to be placed validly, this allows
    //things like a tall cup to have the top half of it sticking out of the receptacle box when placed on a table without requiring the table's receptacle box to be gigantic and unweildy
    public static List<SimObjType> OnReceptacles = new List <SimObjType>()
    {SimObjType.TableTop, SimObjType.Dresser, SimObjType.CounterTop, SimObjType.Shelf, SimObjType.ArmChair,
     SimObjType.Sofa, SimObjType.Ottoman, SimObjType.StoveBurner,SimObjType.Bathtub, SimObjType.Plate};

    //Objects are "placed into/placed in" to these receptacles
    //while these receptacles have things placed "in" them, they use the logic of OnReceptacles - Only the bottom 4 corners must be within the
    //receptacle box for the placement to be valid. This means we can have a Spoon placed IN a cup, but the top half of the spoon is still allowed to stick out
	//this distinction is made in case we ever want to do some sort of semantic tests with placing things in/on instead of a generic "place" as the action descriptor
    public static List<SimObjType> InReceptaclesThatOnlyCheckBottomFourCorners = new List <SimObjType>()
    { SimObjType.Cup, SimObjType.Bowl, SimObjType.GarbageCan, SimObjType.Box, SimObjType.Sink, SimObjType.BathtubBasin, SimObjType.Pan, SimObjType.Pot, };


	public static List<SimObjType> SpawnOnlyOutsideReceptacles = new List <SimObjType>()
	{
		SimObjType.TableTop, SimObjType.Dresser, SimObjType.CounterTop, SimObjType.Sofa, SimObjType.Bench, SimObjType.Bed,
		SimObjType.Ottoman, SimObjType.Desk, SimObjType.StoveBurner, SimObjType.Shelf, SimObjType.Bathtub, SimObjType.Sink, SimObjType.BathtubBasin, SimObjType.SinkBasin,
		SimObjType.NightStand, SimObjType.CoffeeMachine, SimObjType.ToiletPaperHanger, SimObjType.Toilet,
	};

	//objects in this list should always return all spawn points inside of it when trying to place an object from the hand into the object
	//this elminiates the need for visibly seeing the bottommost point on the object, which would restrict the valid placement positions greatly due to these objects being viewed at extreme angles
	public static List<SimObjType> ReturnAllPoints = new List<SimObjType>()
	{
		SimObjType.Pot, SimObjType.Pan, SimObjType.Bowl, SimObjType.GarbageCan, SimObjType.Plate, SimObjType.Box, SimObjType.Drawer, SimObjType.Mug, SimObjType.Cup,
	};

	//These receptacle sim objects MUST be in the open state before objects can be placed in them
	public static List<SimObjType> MustBeOpenToPlaceObjectsIn = new List<SimObjType>()
	{
		SimObjType.Drawer, SimObjType.Cabinet, SimObjType.LaundryHamper, SimObjType.Microwave, SimObjType.Fridge //XXX add box to this once we have openable boxes
	};

	//these objects should always be placed upright and not in weird angles. For example, you wouldn't place a pot sideways, you would always place
	//it with the opening facing up!
	public static List<SimObjType> AlwaysPlaceUpright = new List<SimObjType>()
	{
		SimObjType.Pot, SimObjType.Pan, SimObjType.Bowl, SimObjType.Plate, SimObjType.Bread, SimObjType.Cup, SimObjType.Mug, SimObjType.Laptop,
		SimObjType.SaltShaker, SimObjType.PepperShaker, SimObjType.AlarmClock, SimObjType.Box, SimObjType.SoapBottle, SimObjType.SoapBottleFilled, SimObjType.Kettle,
		SimObjType.Glassbottle, SimObjType.CreditCard, SimObjType.RemoteControl, SimObjType.Candle, SimObjType.SprayBottle, SimObjType.Statue, SimObjType.Vase, 
		SimObjType.KeyChain, SimObjType.CD, 
	};

	//Each sim object type keeps track of what sort of Receptacles it can be placed in
	//add to this as more pickupable sim objects are created
	public static Dictionary<SimObjType, List<SimObjType>> PlacementRestrictions = new Dictionary<SimObjType, List<SimObjType>>()
	{
		//ALARM CLOCK
		{SimObjType.AlarmClock, new List<SimObjType>()
		{SimObjType.Box, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Shelf}},

		//APPLE
		{SimObjType.Apple, new List<SimObjType>()
		{SimObjType.Pot, SimObjType.Pan, SimObjType.Bowl, SimObjType.Microwave, SimObjType.Fridge, SimObjType.Plate, SimObjType.Sink, SimObjType.SinkBasin, SimObjType.TableTop,
		 SimObjType.CounterTop, SimObjType.GarbageCan}},

		//BASEBALL BAT
		{SimObjType.BaseballBat, new List<SimObjType>()
		{SimObjType.Bed, SimObjType.TableTop, SimObjType.CounterTop,}}, ///place on floor? 

		//BASKETBALL
		{SimObjType.BasketBall, new List<SimObjType>()
		{SimObjType.Sofa, SimObjType.ArmChair, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.Bed, SimObjType.TableTop, SimObjType.CounterTop}},

		//BOOK - Need to alter this later so that Open Books are no longer their own prefabs, combine into one once we have state change
		{SimObjType.Book, new List<SimObjType>()
		{SimObjType.Sofa, SimObjType.ArmChair, SimObjType.Box, SimObjType.Ottoman, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.Bed, SimObjType.Cabinet, SimObjType.TableTop,
		 SimObjType.CounterTop, SimObjType.Shelf, SimObjType.Drawer}},

		//BOOTS
		{SimObjType.Boots, new List<SimObjType>()
		{
			//nothing yet? put on floor?
		}},

		//BOTTLE (Glassbottle)
		{SimObjType.Glassbottle, new List<SimObjType>()
		{SimObjType.Fridge, SimObjType.Box, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.Sink, SimObjType.SinkBasin, SimObjType.Cabinet, SimObjType.TableTop,
		 SimObjType.CounterTop, SimObjType.Shelf, SimObjType.GarbageCan,
		}},

		//BOWL
		{SimObjType.Bowl, new List<SimObjType>()
		{SimObjType.Microwave, SimObjType.Fridge, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.Sink, SimObjType.SinkBasin, SimObjType.Cabinet, SimObjType.TableTop,
		 SimObjType.CounterTop, SimObjType.Shelf,
		}},

		//BOX
		{SimObjType.Box, new List<SimObjType>()
		{SimObjType.Sofa, SimObjType.ArmChair, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.Cabinet, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Shelf, 
		}},

		//BREAD
		{SimObjType.Bread, new List<SimObjType>()
		{SimObjType.Microwave, SimObjType.Fridge, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.GarbageCan}},

		//BUTTER KNIFE
		{SimObjType.ButterKnife, new List<SimObjType>()
		{SimObjType.Pot, SimObjType.Pan, SimObjType.Bowl, SimObjType.Mug, SimObjType.Plate, SimObjType.Cup, SimObjType.Sink, SimObjType.SinkBasin, SimObjType.TableTop, SimObjType.CounterTop,
		 SimObjType.Drawer}},

		//CANDLE
		{SimObjType.Candle, new List <SimObjType>()
		{SimObjType.Box, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.Toilet, SimObjType.Cart, SimObjType.Bathtub, SimObjType.Cabinet, SimObjType.TableTop, SimObjType.CounterTop,
		 SimObjType.Shelf, SimObjType.Drawer,
		}},

		//CD
		{SimObjType.CD, new List<SimObjType>()
		{SimObjType.Box, SimObjType.Ottoman, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.Cabinet, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Shelf, SimObjType.Drawer,
		 SimObjType.GarbageCan, SimObjType.Safe}},

		//CELL PHONE
		{SimObjType.CellPhone, new List<SimObjType>()
		{SimObjType.Sofa, SimObjType.ArmChair, SimObjType.Box, SimObjType.Ottoman, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.Bed, SimObjType.TableTop, SimObjType.CounterTop,
		 SimObjType.Shelf, SimObjType.Drawer, SimObjType.Safe,
		 }},

		//CLOTH
		{SimObjType.Cloth, new List<SimObjType>()
		{SimObjType.Sofa, SimObjType.ArmChair, SimObjType.Box, SimObjType.Ottoman, SimObjType.Dresser, SimObjType.LaundryHamper, SimObjType.Desk, SimObjType.NightStand, SimObjType.Toilet, SimObjType.Cart,
		 SimObjType.BathtubBasin, SimObjType.Bathtub, SimObjType.Sink, SimObjType.SinkBasin, SimObjType.Cabinet, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Shelf, SimObjType.Drawer, SimObjType.GarbageCan}},

		//CREDIT CARD
		{SimObjType.CreditCard, new List<SimObjType>()
		{SimObjType.Sofa, SimObjType.ArmChair, SimObjType.Box, SimObjType.Ottoman, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Shelf, SimObjType.Drawer,
		 SimObjType.Shelf}},

		//CUP
		{SimObjType.Cup, new List<SimObjType>()
		{SimObjType.Microwave, SimObjType.Fridge, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.Sink, SimObjType.SinkBasin, SimObjType.Cabinet, SimObjType.TableTop,
		 SimObjType.CounterTop, SimObjType.Shelf }}, //might want to add this to coffee machines later, but right now they don't fit, only mugs were created to fit coffee machines initially

		//DISH SPONGE
		{SimObjType.DishSponge, new List<SimObjType>()
		{SimObjType.Pot, SimObjType.Pan, SimObjType.Bowl, SimObjType.Plate, SimObjType.Box, SimObjType.Toilet, SimObjType.Cart, SimObjType.Cart, SimObjType.BathtubBasin, SimObjType.Bathtub, SimObjType.Sink, 
		 SimObjType.SinkBasin, SimObjType.Cabinet, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Shelf, SimObjType.Drawer, SimObjType.GarbageCan}},

		//EGG
		{SimObjType.Egg, new List<SimObjType>()
		{SimObjType.Pot, SimObjType.Pan, SimObjType.Bowl, SimObjType.Microwave, SimObjType.Fridge, SimObjType.Plate, SimObjType.Sink, SimObjType.SinkBasin, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.GarbageCan}},

		//FORK
		{SimObjType.Fork, new List<SimObjType>()
		{SimObjType.Pot, SimObjType.Pan, SimObjType.Bowl, SimObjType.Mug, SimObjType.Plate, SimObjType.Cup, SimObjType.Sink, SimObjType.SinkBasin, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Drawer, }},

		//HAND TOWEL- small hand towel
		{SimObjType.HandTowel, new List<SimObjType>()
		{SimObjType.HandTowelHolder,}},

		//KETTLE
		{SimObjType.Kettle, new List<SimObjType>()
		{SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Sink, SimObjType.SinkBasin, SimObjType.Cabinet, SimObjType.StoveBurner, SimObjType.Shelf}},

		//KEYCHAIN
		{SimObjType.KeyChain, new List<SimObjType>()
		{SimObjType.Sofa, SimObjType.ArmChair, SimObjType.Box, SimObjType.Ottoman, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Shelf, SimObjType.Drawer,
		 SimObjType.Safe,}},

		//KNIFE - Big chef's knife
		{SimObjType.Knife, new List<SimObjType>()
		{SimObjType.Pot, SimObjType.Pan, SimObjType.Bowl, SimObjType.Mug, SimObjType.Plate, SimObjType.Sink, SimObjType.SinkBasin, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Drawer, }},

		//LADLE
		{SimObjType.Ladle, new List<SimObjType>()
		{SimObjType.Pot, SimObjType.Pan, SimObjType.Bowl, SimObjType.Plate, SimObjType.Sink, SimObjType.SinkBasin, SimObjType.Cabinet, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Drawer}},

		//LAPTOP
		{SimObjType.Laptop, new List<SimObjType>()
		{SimObjType.Sofa, SimObjType.ArmChair, SimObjType.Ottoman, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.Bed, SimObjType.TableTop, SimObjType.CounterTop}},

		//LETTUCE
		{SimObjType.Lettuce, new List<SimObjType>()
		{SimObjType.Pot, SimObjType.Pan, SimObjType.Bowl, SimObjType.Fridge, SimObjType.Plate, SimObjType.Sink, SimObjType.SinkBasin, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.GarbageCan}},

		//MUG
		{SimObjType.Mug, new List<SimObjType>()
		{SimObjType.CoffeeMachine, SimObjType.Microwave, SimObjType.Fridge, SimObjType.Plate, SimObjType.Box, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.Cart, SimObjType.Sink,
		 SimObjType.SinkBasin, SimObjType.Cabinet, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Shelf, 
		}},

		//NEWSPAPER
		{SimObjType.Newspaper, new List<SimObjType>()
		{SimObjType.Sofa, SimObjType.ArmChair, SimObjType.Ottoman, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.Bed, SimObjType.Toilet, SimObjType.Cabinet, SimObjType.TableTop, 
		 SimObjType.CounterTop, SimObjType.Shelf, SimObjType.Drawer, SimObjType.GarbageCan
		}},

		//PAN
		{SimObjType.Pan, new List<SimObjType>()
		{SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Sink, SimObjType.SinkBasin, SimObjType.Cabinet, SimObjType.StoveBurner, SimObjType.Fridge}},

		//PAPER TOWEL
		{SimObjType.PaperTowelRoll, new List<SimObjType>()
		{SimObjType.Box, SimObjType.Toilet, SimObjType.Cart, SimObjType.Bathtub, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Shelf, SimObjType.GarbageCan}},


		//PEN
		{SimObjType.Pen, new List<SimObjType>()
		{SimObjType.Mug, SimObjType.Box, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Shelf, SimObjType.Drawer, SimObjType.GarbageCan}},

		//PENCIL
		{SimObjType.Pencil, new List<SimObjType>()
		{SimObjType.Mug, SimObjType.Box, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Shelf, SimObjType.Drawer, SimObjType.GarbageCan}},

		//PEPPER SHAKER
		{SimObjType.PepperShaker, new List<SimObjType>()
		{SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Drawer, SimObjType.Cabinet, SimObjType.Shelf}},

		//PILLOW
		{SimObjType.Pillow, new List<SimObjType>()
		{SimObjType.Sofa, SimObjType.ArmChair, SimObjType.Ottoman, SimObjType.Bed,}},

		//Plate
		{SimObjType.Plate, new List<SimObjType>()
		{SimObjType.Microwave, SimObjType.Fridge, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.Sink,SimObjType.Sink, SimObjType.SinkBasin, SimObjType.Cabinet, SimObjType.TableTop,
		 SimObjType.CounterTop, SimObjType.Shelf
		}},

		//PLUNGER
		{SimObjType.Plunger, new List<SimObjType>()
		{SimObjType.Cart, SimObjType.Cabinet}},

		//POT
		{SimObjType.Pot, new List<SimObjType>()
		{SimObjType.StoveBurner, SimObjType.Fridge, SimObjType.Sink, SimObjType.SinkBasin, SimObjType.Cabinet, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Shelf}},

		//POTATO
		{SimObjType.Potato, new List<SimObjType>()
		{SimObjType.Pot, SimObjType.Pan, SimObjType.Bowl, SimObjType.Microwave, SimObjType.Fridge, SimObjType.Plate, SimObjType.Sink, SimObjType.SinkBasin, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.GarbageCan}},


		//REMOTE CONTROL
		{SimObjType.RemoteControl, new List<SimObjType>()
		{SimObjType.Sofa, SimObjType.ArmChair, SimObjType.Box, SimObjType.Ottoman, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Shelf, 
		 SimObjType.Drawer, }},

		//SALT SHAKER
		{SimObjType.SaltShaker, new List<SimObjType>()
		{SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Drawer, SimObjType.Cabinet, SimObjType.Shelf}},

		//SOAP BAR
		{SimObjType.SoapBar, new List <SimObjType>()
		{SimObjType.Toilet, SimObjType.Cart, SimObjType.Bathtub, SimObjType.BathtubBasin, SimObjType.Sink, SimObjType.SinkBasin, SimObjType.Cabinet, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Shelf,
		 SimObjType.Drawer, SimObjType.GarbageCan,
		}},

		//SOAP BOTTLE
		{SimObjType.SoapBottle, new List <SimObjType>()
		{SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.Toilet, SimObjType.Cart, SimObjType.Bathtub, SimObjType.Sink, SimObjType.Cabinet, SimObjType.TableTop, SimObjType.CounterTop, 
		 SimObjType.Shelf, SimObjType.Drawer, SimObjType.GarbageCan,
		}},

		//SPATULA
		{SimObjType.Spatula, new List<SimObjType>()
		{SimObjType.Pot, SimObjType.Pan, SimObjType.Bowl, SimObjType.Plate, SimObjType.Sink, SimObjType.SinkBasin, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Drawer,}},

		//SPOON
		{SimObjType.Spoon, new List<SimObjType>()
		{SimObjType.Pot, SimObjType.Pan, SimObjType.Bowl, SimObjType.Mug, SimObjType.Plate, SimObjType.Cup, SimObjType.Sink, SimObjType.SinkBasin, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Drawer, }},

		//SPRAY BOTTLE
		{SimObjType.SprayBottle, new List <SimObjType>()
		{SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.Toilet, SimObjType.Cart, SimObjType.Cabinet, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Shelf, SimObjType.Drawer, 
		 SimObjType.GarbageCan
		}},
		
		//STATUE
		{SimObjType.Statue, new List<SimObjType>()
		{SimObjType.Box, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.Cart, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Shelf, SimObjType.Safe, }},

		//TEDDY BEAR
		{SimObjType.TeddyBear, new List<SimObjType>()
		{SimObjType.Bed, SimObjType.Sofa, SimObjType.ArmChair, SimObjType.Ottoman, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Safe}},

		//TENNIS RACKET
		{SimObjType.TennisRacket, new List<SimObjType>()
		{SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.Bed, SimObjType.TableTop, SimObjType.CounterTop}}, ///place on floor? 
	
		//TISSUE BOX
		{SimObjType.TissueBox, new List<SimObjType>()
		{SimObjType.Box, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.Toilet, SimObjType.Cart, SimObjType.Cabinet, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Shelf, 
		 SimObjType.Drawer, SimObjType.GarbageCan}},

		//TOILET PAPER
		{SimObjType.ToiletPaper, new List <SimObjType>()
		{SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.Toilet, SimObjType.ToiletPaperHanger, SimObjType.Cart, SimObjType.Bathtub, SimObjType.Cabinet, SimObjType.TableTop, 
		 SimObjType.CounterTop, SimObjType.Shelf, SimObjType.Drawer, SimObjType.GarbageCan,
		}},

		//TOILET PAPER ROLL - should be same as Toilet Paper's list
		{SimObjType.ToiletPaperRoll, new List <SimObjType>()
		{SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.Toilet, SimObjType.ToiletPaperHanger, SimObjType.Cart, SimObjType.Bathtub, SimObjType.Cabinet, SimObjType.TableTop, 
		 SimObjType.CounterTop, SimObjType.Shelf, SimObjType.Drawer, SimObjType.GarbageCan,
		}},

		//TOMATO
		{SimObjType.Tomato, new List<SimObjType>()
		{SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Sink, SimObjType.SinkBasin, SimObjType.Pot,
		 SimObjType.Bowl, SimObjType.Fridge, SimObjType.GarbageCan, SimObjType.Plate}},

		//TOWEL - large bath towel
		{SimObjType.Towel, new List<SimObjType>()
		{SimObjType.TowelHolder,}},

		//VASE
		{SimObjType.Vase, new List<SimObjType>()
		{SimObjType.Box, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.Cart, SimObjType.Cabinet, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Shelf, SimObjType.Safe}},

		//WATCH
		{SimObjType.Watch, new List<SimObjType>()
		{SimObjType.Box, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Shelf, SimObjType.Drawer, SimObjType.Safe}},

		//WATERING CAN
		{SimObjType.WateringCan, new List<SimObjType>()
		{SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.Cabinet, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Shelf, SimObjType.Drawer,}},

		//WINE BOTTLE
		{SimObjType.WineBottle, new List<SimObjType>()
		{SimObjType.Fridge, SimObjType.Dresser, SimObjType.Desk, SimObjType.NightStand, SimObjType.Cabinet, SimObjType.TableTop, SimObjType.CounterTop, SimObjType.Shelf, SimObjType.GarbageCan}},

	};

}

