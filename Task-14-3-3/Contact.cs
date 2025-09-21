internal class Contact(string name, string last_name, long phone_number, string email)
{
    public string Name { get; } = name;
    public string LastName { get; } = last_name;
    public long PhoneNumber { get; } = phone_number;
    public string Email { get; } = email;
}