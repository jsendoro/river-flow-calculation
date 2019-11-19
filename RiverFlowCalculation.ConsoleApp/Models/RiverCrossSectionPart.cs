namespace RiverFlowCalculation.ConsoleApp.Models
{
    public class RiverCrossSectionPart
    {
        #region Constructor

        /// <summary>
        ///     Constructor for RiverCrossSectionPart
        /// </summary>
        /// <param name="width">Width of the part</param>
        /// <param name="depth">Depth of the part</param>
        /// <param name="velocity">Velocity of the part</param>
        /// <param name="velocityCorrectionFactor">Area correcction factor. This value should be between 1 and 0</param>
        /// <param name="areaCorrectionFactor">Area correcction factor. This value should be between 1 and 0</param>
        public RiverCrossSectionPart(double width, double depth, double velocity, double velocityCorrectionFactor = 1.0, double areaCorrectionFactor = 1.0)
        {
            Width = width;
            Depth = depth;
            Velocity = velocity;
            VelocityCorrectionFactor = AdjustBoundaryValues(velocityCorrectionFactor, 0.0, 1.0);
            AreaCorrectionFactor = AdjustBoundaryValues(areaCorrectionFactor, 0.0, 1.0);
        }

        #endregion

        #region Private Functions

        /// <summary>
        ///     Adjust the value based on the maximim value and minimum value
        /// </summary>
        /// <param name="value">vvalue to be adjusted</param>
        /// <param name="minValue">minimum value</param>
        /// <param name="maxValue">maximum value</param>
        /// <returns>minValue if value is less that minValue, maxValue if value is bigger than maxValue, otherwise return value</returns>
        private double AdjustBoundaryValues(double value, double minValue, double maxValue)
        {
            if (value > maxValue)
                return maxValue;
            if (value < minValue)
                return minValue;
            return value;
        }

        #endregion

        #region Public Properties

        public double Width { get; set; }
        public double Depth { get; set; }
        public double Velocity { get; set; }

        /// <summary>
        ///     Velocity correction factor can be used to adjust the velocity depending on how rocky-bottom or muddy-bottom is the stream
        ///     For example, set the value to 0.8 for rocy-bottom stream or 0.9 for muddy-bottom stream.
        /// </summary>
        public double VelocityCorrectionFactor { get; set; }

        /// <summary>
        ///     Area correction factor can be used to adjust the area of the river cross section part.
        ///     For example, set the value to 1 if it's perfectly rectangular or 0.5 if it's half rectangular.
        /// </summary>
        public double AreaCorrectionFactor { get; set; }

        #endregion

        #region Public Functions

        /// <summary>
        ///     Get the area value
        /// </summary>
        /// <returns>area</returns>
        public double GetArea()
        {
            return Width * Depth * AreaCorrectionFactor;
        }

        /// <summary>
        ///     Get the discharge value
        /// </summary>
        /// <returns>discharge</returns>
        public double GetDischarge()
        {
            return GetArea() * Velocity * VelocityCorrectionFactor;
        }

        #endregion
    }
}