using System;

/// <summary>
/// AnmodningerView Klasse
/// </summary>
public partial class AnmodningerView
{
    /// <summary>
    /// AnmodningerView konstruktør
    /// </summary>
    /// <param name="vagtId">vagtId parameter</param>
    /// <param name="anmodningBrugernavn">anmodningBrugernavn parameter</param>
    public AnmodningerView(int vagtId, string anmodningBrugernavn)
    {
        VagtId = vagtId;
        AnmodningBrugernavn = anmodningBrugernavn;
    }
    /// <summary>
    /// AnmodningId property
    /// </summary>
    public int AnmodningId { get; set; }
    /// <summary>
    /// AnmodningBrugernavn property
    /// </summary>
    public string AnmodningBrugernavn { get; set; }
    /// <summary>
    /// Starttidspunkt property
    /// </summary>
    public TimeSpan Starttidspunkt { get; set; }
    /// <summary>
    /// Sluttidspunkt property
    /// </summary>
    public TimeSpan Sluttidspunkt { get; set; }
    /// <summary>
    /// UgedagId property
    /// </summary>
    public int UgedagId { get; set; }
    /// <summary>
    /// Ugenummer property
    /// </summary>
    public int Ugenummer { get; set; }
    /// <summary>
    /// Brugernavn property
    /// </summary>
    public string Brugernavn { get; set; }
    /// <summary>
    /// VagtId property
    /// </summary>
    public int VagtId { get; set; }
    /// <summary>
    /// Ugedag property
    /// </summary>
    public string Ugedag { get; set; }
}