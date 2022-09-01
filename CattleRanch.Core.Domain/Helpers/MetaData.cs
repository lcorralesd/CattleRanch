namespace CattleRanch.Core.Domain.Helpers;
public class MetaData
{
    /// <summary>
    /// Página devuelta por la consulta actual.
    /// </summary>
    public int CurrentPage { get; set; }
    /// <summary>
    /// Total de páginas de la consulta.
    /// </summary>
    public int TotalPages { get; set; }
    /// <summary>
    /// Número de registros de la página devuelta.
    /// </summary>
    public int? PageSize { get; set; }
    /// <summary>
    /// Total de registros de consulta.
    /// </summary>
    public int TotalCount { get; set; }
    /// <summary>
    /// Registros devueltos por la consulta actual.
    /// </summary>
    public int CurrentCount { get; set; }


    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
}
