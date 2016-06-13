using DotNetNuke.Data;
using System.Collections.Generic;
using System.Linq;
using Ventrian.Modules.Subscriptions.Components.Entities;

namespace Ventrian.Modules.Subscriptions.Components.Controllers
{
    public class PlanController
    {
        public int AddPlan(Plan objPlan)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Plan>();
                rep.Insert(objPlan);
            }

            return objPlan.PlanID;
        }

        public void DeletePlan(Plan objPlan)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Plan>();
                objPlan.IsDeleted = true;
                rep.Update(objPlan);
            }
        }

        public Plan GetPlan(int planID, int moduleID)
        {
            Plan plan;

            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Plan>();
                plan = rep.GetById(planID, moduleID);
            }

            return plan;
        }

        public IEnumerable<Plan> GetPlans(int moduleID)
        {
            IEnumerable<Plan> plans;

            using(IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Plan>();
                plans = rep.Get(moduleID);
            }

            return plans.Where(p => !p.IsDeleted);
        }

        public void UpdatePlan(Plan objPlan)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Plan>();
                rep.Update(objPlan);
            }
        }
    }
}