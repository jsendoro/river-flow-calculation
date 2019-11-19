using System.Collections.Generic;
using System.Linq;

namespace RiverFlowCalculation.ConsoleApp.Models
{
    public class RiverCrossSection
    {
        #region Public Properties

        public IEnumerable<RiverCrossSectionPart> Parts;

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor for RiverCrossSection
        /// </summary>
        /// <param name="data"></param>
        public RiverCrossSection(IEnumerable<RiverCrossSectionPart> data)
        {
            Parts = data;
        }

        #endregion

        #region Public Function

        /// <summary>
        ///     Get TotalDischarge of the river cross section
        /// </summary>
        /// <returns>Total discharge for the river cross section</returns>
        public double GetTotalDischarge()
        {
            return Parts.Sum(d => d.GetDischarge());
        }

        #endregion
    }
}