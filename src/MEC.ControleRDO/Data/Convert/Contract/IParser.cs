namespace MEC.ControleRDO.Data.Convert.Contract
{
    public interface IParser<O, D>
    {
        D Parser(O origin);
        List<D> Parser(List<O> origin);
    }
}
