namespace CodeWF.WebAPI;

/// <summary>
///     ��������
/// </summary>
public class Link
{
    /// <summary>
    ///     ��������ԽСԽ��ǰ
    /// </summary>
    public int Rank { get; set; }

    /// <summary>
    ///     ���⣬һ��Ϊ��վ���ƣ��������罻�˺��ǳ�
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    ///     ����
    /// </summary>

    public string? Remark { get; set; }

    /// <summary>
    ///     ����
    /// </summary>
    public string? LinkUrl { get; set; }

    /// <summary>
    ///     Logo
    /// </summary>
    public string? Logo { get; set; }
}