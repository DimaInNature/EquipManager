namespace EquipManager.Domain.Builders;

/// <summary> Порождающий класс для <see cref="PPEContractBody"/>.</summary>
/// <remarks>Реализует порождающий паттерн Builder.</remarks>
public class PPEContractBodyBuilder
{
    private readonly PPEContractBody _ppeBody = new();

    /// <summary> Добавить С.И.З.</summary>
    /// <remarks>Данный метод является частью конвейера порождающего класса. 
    /// <para>Максимальное количество С.И.З. - 12шт.</para></remarks>
    /// <param name="idPPE">Идентификатор.</param>
    /// <param name="number">Порядковый номер С.И.З. в договоре.</param>
    /// <returns>Возвращает вызывающий метод объект <see cref="PPEContractBodyBuilder"/>.</returns>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public PPEContractBodyBuilder AppendPPE(int? idPPE, int number)
    {
        switch (number)
        {
            case 1:
                _ppeBody.PPE1Id = idPPE;
                break;
            case 2:
                _ppeBody.PPE2Id = idPPE;
                break;
            case 3:
                _ppeBody.PPE3Id = idPPE;
                break;
            case 4:
                _ppeBody.PPE4Id = idPPE;
                break;
            case 5:
                _ppeBody.PPE5Id = idPPE;
                break;
            case 6:
                _ppeBody.PPE6Id = idPPE;
                break;
            case 7:
                _ppeBody.PPE7Id = idPPE;
                break;
            case 8:
                _ppeBody.PPE8Id = idPPE;
                break;
            case 9:
                _ppeBody.PPE9Id = idPPE;
                break;
            case 10:
                _ppeBody.PPE10Id = idPPE;
                break;
            case 11:
                _ppeBody.PPE11Id = idPPE;
                break;
            case 12:
                _ppeBody.PPE12Id = idPPE;
                break;
            default: throw new IndexOutOfRangeException();
        }

        return this;
    }

    /// <summary>Завершает создание объекта. </summary>
    /// <returns>Созданный объект <see cref="PPEContractBody"/>.</returns>
    public PPEContractBody Build() => _ppeBody;
}