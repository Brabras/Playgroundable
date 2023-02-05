namespace ConsolePlaygrouns;

public class Person
{
    public string Gender { get; set; }

    private string FullName { get; set; }
    public Person(string value, string name, string surname)
    {
        Gender = value;
        SetName(name, surname);
    }

    private void SetName(string name, string surname)
    {
        FullName = $"{surname} {name} asdknasfjabksfb";
    }
}