namespace Jumper.Domain.Base;

/// <summary>
/// Sabit olan verilerde IsConstant alanı true set edilir. Bu veriler üzerinde hiç bir zaman update delete işlemi gerçekleştirilemez.
/// Base Business rulesta ThrowExceptionIsConstant metodu tetiklenmelidir. Db seviyesinde işlem yapılmaz.
/// </summary>
public interface IConstantEntity
{
    bool IsConstant { get; set; }
}
