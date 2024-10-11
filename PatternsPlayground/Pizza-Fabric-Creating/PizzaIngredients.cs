namespace PatternsPlayground.Pizza_Fabric_Creating;

public abstract class Dough;
public sealed class ThinDough : Dough;
public sealed class ThickDough : Dough;

public abstract class Sauce;
public sealed class MarinaraSauce : Sauce;
public sealed class PineappleSauce : Sauce;

public abstract class Cheese;
public sealed class ReggianoCheese : Cheese;
public sealed class ChedderCheese : Cheese;

public abstract class Veggie;
public sealed class Tomato : Veggie;
public sealed class Onion : Veggie;

public abstract class Clams;
public sealed class Crab : Clams;
public sealed class Shell : Clams;