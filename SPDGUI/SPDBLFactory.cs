using System;
using System.Collections.Generic;
using System.Text;
using SPD.BL.Interfaces;
using SPD.CommonObjects;
using SPD.BL;
//using SPD.WCFClient;
using System.Windows.Forms;
using SPD.OtherObjects;

namespace SPD.GUI.BLFactory {
    /// <summary>
    /// 
    /// </summary>
    public class SPDLFactory{
        /// <summary>
        /// Gets the bussiness logic object.
        /// </summary>
        /// <param name="endpointData">The endpoint data.</param>
        /// <returns></returns>
        public static ISPDBL GetBussinessLogicObject(EndpointData endpointData) {
            ServiceType serviceType = (ServiceType)SPD.GUI.Properties.Settings.Default.service; 

            switch (serviceType) {
                case ServiceType.local:
                    return new SPDBL();
                //case ServiceType.WCF:
                //    return new SPDWCFBL(endpointData);
                default:
                    return null;
            }
            
        }
    }
}
