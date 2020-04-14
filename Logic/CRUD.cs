using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CRUD
    {
        public void Add(TrackedAction t)
        {
            try
            {
                using (var w = new WindowEvents())
                {
                    w.TrackedActions.Add(t);
                    w.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        public List<IGrouping<string,TrackedAction>> GetUnActed()
        {
            try
            {
                using (var w = new WindowEvents())
                {
                    var res = w.TrackedActions.Where(x => !x.HasBeenActedUpon).GroupBy(x => x.ApplicationPath).ToList();
                    return res;
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }


        public void Update(TrackedAction updated)
        {
            try
            {
                using (var w = new WindowEvents())
                {
                    var res = w.TrackedActions.Where(x => x.Id == updated.Id).FirstOrDefault();
                    res.Remarks = updated.Remarks;
                    res.HasBeenActedUpon = updated.HasBeenActedUpon;
                    w.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }


    }
}
