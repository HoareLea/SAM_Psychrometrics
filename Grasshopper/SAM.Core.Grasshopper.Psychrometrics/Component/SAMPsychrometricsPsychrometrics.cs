﻿using Grasshopper.Kernel;
using SAM.Core.Grasshopper.Psychrometrics.Properties;
using SAM.Core.Grasshopper;
using System;
using System.Collections.Generic;

namespace SAM.Analytical.Grasshopper
{
    public class SAMPsychrometricsPsychrometrics : GH_SAMVariableOutputParameterComponent
    {
        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid => new Guid("064dc9f2-a368-459a-9e97-b60588a269f1");

        /// <summary>
        /// The latest version of this component
        /// </summary>
        public override string LatestComponentVersion => "1.0.5";

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon => Resources.SAM_Psychrometrics;

        public override GH_Exposure Exposure => GH_Exposure.primary;

        protected override GH_SAMParam[] Inputs
        {
            get
            {
                List<GH_SAMParam> result = new List<GH_SAMParam>();
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_Number() { Name = "_dryBulbTemperature", NickName = "_dryBulbTemperature", Description = "Dry bulb temperature [°C]", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_Number() { Name = "_relativeHumidity_", NickName = "_relativeHumidity_", Description = "Relative humidity (0 - 100) [%] \n Connect only one humidity indication \n relativeHumidity or wetBulbTemperature or dewPointTemperature", Access = GH_ParamAccess.item, Optional = true }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_Number() { Name = "_humidityRatio_", NickName = "_humidityRatio_", Description = "Humidty Ratio [g/kg]", Access = GH_ParamAccess.item, Optional = true }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_Number() { Name = "_wetBulbTemperature_", NickName = "_wetBulbTemperature_", Description = "Wet bulb temperature [°C] \n Connect only one humidity indication \n relativeHumidity or wetBulbTemperature or dewPointTemperature", Access = GH_ParamAccess.item, Optional = true }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_Number() { Name = "_dewPointTemperature_", NickName = "_dewPointTemperature_", Description = "Dew Point Temperature [°C] \n Connect only one humidity indication \n relativeHumidity or wetBulbTemperature or dewPointTemperature", Access = GH_ParamAccess.item, Optional = true }, ParamVisibility.Binding));

                global::Grasshopper.Kernel.Parameters.Param_Number param_Number = new global::Grasshopper.Kernel.Parameters.Param_Number() { Name = "_pressure_", NickName = "_pressure_", Description = "Atmospheric pressure [Pa]", Access = GH_ParamAccess.item, Optional = true };
                param_Number.SetPersistentData(101325);
                result.Add(new GH_SAMParam(param_Number, ParamVisibility.Voluntary));

                return result.ToArray();
            }
        }

        protected override GH_SAMParam[] Outputs
        {
            get
            {
                List<GH_SAMParam> result = new List<GH_SAMParam>();
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_Number() { Name = "dryBulbTemperature", NickName = "dryBulbTemperature", Description = "Dry bulb temperature [°C]", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_Number() { Name = "relativeHumidity", NickName = "relativeHumidity", Description = "Relative humidity (0 - 100) [%]", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_Number() { Name = "humidityRatio", NickName = "humidityRatio", Description = "Humidty Ratio [g/kg]", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_Number() { Name = "saturationHumidityRatio", NickName = "saturationHumidityRatio", Description = "Saturation Humidty Ratio [g/kg]", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_Number() { Name = "wetBulbTemperature", NickName = "wetBulbTemperature", Description = "Wet bulb temperature [°C]", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_Number() { Name = "dewPointTemperature", NickName = "dewPointTemperature", Description = "Dew Point Temperature [°C]", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_Number() { Name = "saturationVapourPressure", NickName = "saturationVapourPressure", Description = "Saturation Vapour Pressure [Pa]", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_Number() { Name = "partialVapourPressure", NickName = "partialVapourPressure", Description = "Partial Vapour Pressure [Pa]", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_Number() { Name = "partialDryAirPressure", NickName = "partialDryAirPressure", Description = "Partial Dry Air Pressure [Pa]", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_Number() { Name = "enthalpy", NickName = "enthalpy", Description = "Enthalpy [kJ/kg]", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_Number() { Name = "specificVolume", NickName = "specificVolume", Description = "Specific Volume [m³/kg]", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_Number() { Name = "density", NickName = "density", Description = "Density [kg/m3]", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_Number() { Name = "degreeSaturation", NickName = "degreeSaturation", Description = "Degree of saturation [unitless]", Access = GH_ParamAccess.item, Optional = true }, ParamVisibility.Voluntary));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_Number() { Name = "pressure", NickName = "pressure", Description = "Atmospheric pressure [Pa]", Access = GH_ParamAccess.item, Optional = true }, ParamVisibility.Voluntary));

                return result.ToArray();
            }
        }

        /// <summary>
        /// Updates PanelTypes for AdjacencyCluster
        /// </summary>
        public SAMPsychrometricsPsychrometrics()
          : base("SAMPsychrometrics.Psychrometrics", "SAMPsychrometrics.Psychrometrics",
              "Utility function to calculate relative humidity, humidity ratio, wet - bulb temperature, dew - point temperature, \npartial vapour pressure, moist air enthalpy, moist air volume, and degree of saturation of air given \ndry-bulb temperature, (relative humidity or humidity ratio or wet bulb temperature) and pressure. \n*The degree of saturation (i.e humidity ratio of the air / humidity ratio of the air at saturationat the same temperature and pressure)\n Connect only one humidity indication",
              "SAM", "Psychrometrics")
        {
        }

        protected override void SolveInstance(IGH_DataAccess dataAccess)
        {
            int index;

            index = Params.IndexOfInputParam("_dryBulbTemperature");
            if (index == -1)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            double dryBulbTemperature = double.NaN;
            double relativeHumidity = double.NaN;
            double humidityRatio = double.NaN;
            double saturationHumidityRatio = double.NaN;
            double wetBulbTemperature = double.NaN;
            double dewPointTemperature = double.NaN;
            double saturationVapourPressure = double.NaN;
            double partialVapourPressure = double.NaN;
            double enthalpy = double.NaN;
            double specificVolume = double.NaN;
            double degreeSaturation = double.NaN;
            double pressure = double.NaN;
            double density = double.NaN;


            index = Params.IndexOfInputParam("_dryBulbTemperature");
            if (!dataAccess.GetData(index, ref dryBulbTemperature) || double.IsNaN(dryBulbTemperature))
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            index = Params.IndexOfInputParam("_relativeHumidity_");
            if (index == -1 || !dataAccess.GetData(index, ref relativeHumidity) || double.IsNaN(relativeHumidity))
            {
                relativeHumidity = double.NaN;
            }

            if(!double.IsNaN(relativeHumidity))
            {
                if(relativeHumidity < 0 || relativeHumidity > 100)
                {
                    AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                    return;
                }
            }

            index = Params.IndexOfInputParam("_humidityRatio_");
            if (index == -1 || !dataAccess.GetData(index, ref humidityRatio) || double.IsNaN(humidityRatio))
            {
                humidityRatio = double.NaN;
            }

            if(!double.IsNaN(humidityRatio) && !double.IsNaN(relativeHumidity))
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            index = Params.IndexOfInputParam("_wetBulbTemperature_");
            if (index == -1 || !dataAccess.GetData(index, ref wetBulbTemperature) || double.IsNaN(wetBulbTemperature))
            {
                wetBulbTemperature = double.NaN;
            }

            index = Params.IndexOfInputParam("_dewPointTemperature_");
            if (index == -1 || !dataAccess.GetData(index, ref dewPointTemperature) || double.IsNaN(dewPointTemperature))
            {
                dewPointTemperature = double.NaN;
            }

            if(double.IsNaN(relativeHumidity) && double.IsNaN(wetBulbTemperature) && double.IsNaN(dewPointTemperature) && double.IsNaN(humidityRatio))
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            index = Params.IndexOfInputParam("_pressure_");
            if (index == -1 || !dataAccess.GetData(index, ref pressure) || double.IsNaN(pressure))
            {
                pressure = 101325;
            }

            if (!double.IsNaN(relativeHumidity) && double.IsNaN(wetBulbTemperature) && double.IsNaN(dewPointTemperature))
            {
                 Core.Psychrometrics.Query.CalcPsychrometrics_ByRelativeHumidity(dryBulbTemperature, relativeHumidity, pressure, 
                     out humidityRatio,
                     out saturationHumidityRatio,
                     out wetBulbTemperature,
                     out dewPointTemperature,
                     out saturationVapourPressure,
                     out partialVapourPressure,
                     out enthalpy,
                     out specificVolume,
                     out degreeSaturation,
                     out density);
            }
            else if (double.IsNaN(relativeHumidity) && !double.IsNaN(wetBulbTemperature) && double.IsNaN(dewPointTemperature))
            {
                Core.Psychrometrics.Query.CalcPsychrometrics_ByWetBulbTemperature(dryBulbTemperature, wetBulbTemperature, pressure,
                     out humidityRatio,
                     out saturationHumidityRatio,
                     out relativeHumidity,
                     out dewPointTemperature,
                     out saturationVapourPressure,
                     out partialVapourPressure,
                     out enthalpy,
                     out specificVolume,
                     out degreeSaturation,
                     out density);
            }
            else if (double.IsNaN(relativeHumidity) && double.IsNaN(wetBulbTemperature) && !double.IsNaN(dewPointTemperature))
            {
                Core.Psychrometrics.Query.CalcPsychrometrics_ByDewPointTemperature(dryBulbTemperature, dewPointTemperature, pressure,
                     out humidityRatio,
                     out saturationHumidityRatio,
                     out wetBulbTemperature,
                     out relativeHumidity,
                     out saturationVapourPressure,
                     out partialVapourPressure,
                     out enthalpy,
                     out specificVolume,
                     out degreeSaturation,
                     out density);
            }
            else if (!double.IsNaN(humidityRatio) && double.IsNaN(wetBulbTemperature) && double.IsNaN(dewPointTemperature))
            {
                Core.Psychrometrics.Query.CalcPsychrometrics_ByHumidityRatio(dryBulbTemperature, humidityRatio/1000, pressure,
                    out saturationHumidityRatio,
                    out relativeHumidity,
                    out wetBulbTemperature,
                    out dewPointTemperature,
                    out saturationVapourPressure,
                    out partialVapourPressure,
                    out enthalpy,
                    out specificVolume,
                    out degreeSaturation,
                    out density);
            }
            else if (double.IsNaN(humidityRatio) && !double.IsNaN(wetBulbTemperature) && double.IsNaN(dewPointTemperature))
            {
                Core.Psychrometrics.Query.CalcPsychrometrics_ByDewPointTemperature(dryBulbTemperature, dewPointTemperature, pressure,
                     out humidityRatio,
                     out saturationHumidityRatio,
                     out wetBulbTemperature,
                     out relativeHumidity,
                     out saturationVapourPressure,
                     out partialVapourPressure,
                     out enthalpy,
                     out specificVolume,
                     out degreeSaturation,
                     out density);
            }
            else if (double.IsNaN(humidityRatio) && double.IsNaN(wetBulbTemperature) && !double.IsNaN(dewPointTemperature))
            {
                Core.Psychrometrics.Query.CalcPsychrometrics_ByDewPointTemperature(dryBulbTemperature, dewPointTemperature, pressure,
                     out humidityRatio,
                     out saturationHumidityRatio,
                     out wetBulbTemperature,
                     out relativeHumidity,
                     out saturationVapourPressure,
                     out partialVapourPressure,
                     out enthalpy,
                     out specificVolume,
                     out degreeSaturation,
                     out density);
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            double partialDryAirPressure = pressure - partialVapourPressure;


            index = Params.IndexOfOutputParam("dryBulbTemperature");
            if(index != -1)
            {
                dataAccess.SetData(index, dryBulbTemperature);
            }

            index = Params.IndexOfOutputParam("relativeHumidity");
            if(index != -1)
            {
                dataAccess.SetData(index, relativeHumidity);
            }

            index = Params.IndexOfOutputParam("humidityRatio");
            if (index != -1)
            {
                dataAccess.SetData(index, humidityRatio);
            }

            index = Params.IndexOfOutputParam("saturationHumidityRatio");
            if (index != -1)
            {
                dataAccess.SetData(index, saturationHumidityRatio * 1000);
            }

            index = Params.IndexOfOutputParam("wetBulbTemperature");
            if (index != -1)
            {
                dataAccess.SetData(index, wetBulbTemperature);
            }

            index = Params.IndexOfOutputParam("dewPointTemperature");
            if (index != -1)
            {
                dataAccess.SetData(index, dewPointTemperature);
            }

            index = Params.IndexOfOutputParam("saturationVapourPressure");
            if (index != -1)
            {
                dataAccess.SetData(index, saturationVapourPressure);
            }

            index = Params.IndexOfOutputParam("partialVapourPressure");
            if (index != -1)
            {
                dataAccess.SetData(index, partialVapourPressure);
            }

            index = Params.IndexOfOutputParam("partialDryAirPressure");
            if (index != -1)
            {
                dataAccess.SetData(index, partialDryAirPressure);
            }

            index = Params.IndexOfOutputParam("enthalpy");
            if (index != -1)
            {
                dataAccess.SetData(index, enthalpy/1000);
            }

            index = Params.IndexOfOutputParam("specificVolume");
            if (index != -1)
            {
                dataAccess.SetData(index, specificVolume);
            }

            index = Params.IndexOfOutputParam("density");
            if (index != -1)
            {
                dataAccess.SetData(index, density);
            }

            index = Params.IndexOfOutputParam("degreeSaturation");
            if (index != -1)
            {
                dataAccess.SetData(index, degreeSaturation);
            }

            index = Params.IndexOfOutputParam("pressure");
            if (index != -1)
            {
                dataAccess.SetData(index, pressure);
            }
        }
    }
}