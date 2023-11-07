namespace Nicesleeping.Domain.Exceptions.Characteristics;

public class CharacteristicNotFoundException : NotFoundException
{
    public CharacteristicNotFoundException()
    {
        this.TitleMessage = "Characteristic not found!";
    }
}
