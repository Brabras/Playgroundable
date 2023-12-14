using System.IO.Compression;
using ConsolePlayground;

var draft = new FormDraft();

var form = new Form();


form.Update(draft, true);

public interface IIdentityDocument
{
    string Name { get; }

    string Surname { get; }
}

public class IdentityDocument : IIdentityDocument
{
    public string Name { get; private set; } = null!;

    public string Surname { get; private set; } = null!;

    private IdentityDocument()
    {
    }

    public static IdentityDocument Create(IIdentityDocument identityDocument)
    {
        return new IdentityDocument
        {
            Name    = identityDocument.Name,
            Surname = identityDocument.Surname
        };
    }
}

public class IdentityDocumentDraft : IIdentityDocument
{
    public string Name { get; private set; } = null!;

    public string Surname { get; private set; } = null!;

    private IdentityDocumentDraft()
    {
    }

    public static IdentityDocumentDraft Create(IIdentityDocument identityDocument)
    {
        return new IdentityDocumentDraft
        {
            Name    = identityDocument.Name,
            Surname = identityDocument.Surname
        };
    }
}

public interface IAddress
{
    string City { get; }
    string Country { get; }
}

public class Address : IAddress
{
    public string City { get; private set; } = null!;

    public string Country { get; private set; } = null!;

    private Address()
    {
    }

    public static Address Create(IAddress address)
    {
        return new Address
        {
            City    = address.City,
            Country = address.Country
        };
    }
}

public class AddressDraft : IAddress
{
    public string City { get; private set; } = null!;

    public string Country { get; private set; } = null!;

    private AddressDraft()
    {
    }

    public static AddressDraft Create(IAddress address)
    {
        return new AddressDraft
        {
            City    = address.City,
            Country = address.Country
        };
    }
}

public interface IForm<TId, TA>
    where TId : IIdentityDocument
    where TA : IAddress
{
    TId IdentityDocument { get; set; }
    TA Address { get; set; }
    bool IsSomething { get; set; }
}

public class FormDraft : IForm<IdentityDocumentDraft, AddressDraft>
{
    public IdentityDocumentDraft IdentityDocument { get; set; }

    public AddressDraft Address { get; set; }

    public bool IsSomething { get; set; }
}

public class Form 
{
    public IdentityDocument IdentityDocument { get; set; } = null!;

    public Address Address { get; set; } = null!;

    public bool IsSomething { get; set; }

    public void Update<TIdentityDocument, TAddress>(IForm<TIdentityDocument, TAddress> form, bool isSomething)
        where TIdentityDocument : IIdentityDocument
        where TAddress : IAddress
    {
        IdentityDocument = IdentityDocument.Create(form.IdentityDocument);
        Address          = Address.Create(form.Address);
        IsSomething      = isSomething;
    }
}