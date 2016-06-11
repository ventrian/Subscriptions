using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Ventrian.Modules.Subscriptions.Components.Types;

namespace Ventrian.Modules.Subscriptions.Components.Data
{
    public class DataService
    {
        private static readonly DataProvider provider = DataProvider.Instance();
        private static string moduleQualifier = "Ventrian_Subscriptions_";

        #region Private Methods

        private static string GetFullyQualifiedName(string name)
        {
            return String.Concat(moduleQualifier, name);
        }

        private static object GetNull(object field)
        {
            return Null.GetNull(field, DBNull.Value);
        }

        #endregion

        public static int AddPlan(int moduleID, string name, decimal serviceFee, bool autoRecurring, FrequencyType billingFrequency, int billingPeriod)
        {
            return provider.ExecuteScalar<int>(GetFullyQualifiedName("AddPlan"), moduleID, name, serviceFee, autoRecurring, (int)billingFrequency, billingPeriod);
        }

        public static void DeletePlan(int planID)
        {
            provider.ExecuteNonQuery(GetFullyQualifiedName("DeletePlan"), planID);
        }

        public static IDataReader GetPlans(int moduleID)
        {
            return provider.ExecuteReader(GetFullyQualifiedName("GetPlans"), moduleID);
        }

        public static void UpdatePlan(int planID, int moduleID, string name, decimal money, bool autoRecurring, FrequencyType billingFrequency, int billingPeriod, int viewOrder)
        {
            provider.ExecuteNonQuery(GetFullyQualifiedName("UpdatePlan"), planID, moduleID, name, money, autoRecurring, (int)billingFrequency, billingPeriod);
        }
    }
}