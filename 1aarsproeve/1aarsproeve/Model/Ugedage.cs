using System.Collections.ObjectModel;

namespace _1aarsproeve.Model
{
    /// <summary>
    /// Ugedage Klasse
    /// </summary>
    public partial class Ugedage
    {
        /// <summary>
        /// Ugedage Konstruktør
        /// </summary>
        /// <param name="ugedagId">ugedagId paramater</param>
        /// <param name="ugedag">ugedag parameter</param>
        public Ugedage(int ugedagId, string ugedag)
        {
            UgedagId = ugedagId;
            Ugedag = ugedag;
        }
        /// <summary>
        /// UgedagId Property
        /// </summary>
        public int UgedagId { get; set; }
        /// <summary>
        /// Ugedag Property
        /// </summary>
        public string Ugedag { get; set; }
        /// <summary>
        /// Viser Ugedag
        /// </summary>
        /// <returns>Returnerer ToString Ugedag</returns>
        public override string ToString()
        {
            return Ugedag;
        }
    }
}