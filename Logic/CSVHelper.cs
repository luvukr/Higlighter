using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CSVHelper
    {
        public static string filePath = @"C:\Users\Sumit Kumar\Documents\TrackMouse.csv";
        public static string header = "Id,IdentificationDetail,ProcessName,ApplicationPath,Remarks,HasBeenActedUpon,CreatedAt";
        public static List<TrackedAction> list = new List<TrackedAction>();

      
        public void WriteRecord(TrackedAction record)
        {
            
            var content= Environment.NewLine+record.Id + "," + record.IdentificationDetail + "," + record.ProcessName + "," + record.ApplicationPath + "," + record.Remarks + "," + record.HasBeenActedUpon + "," + record.CreatedAt;
            File.AppendAllText(filePath, content);

            
        }

        public void Update(TrackedAction record)
        {
            List<string> recs = new List<string>();
            recs.Add(header);
            var r = list.Where(x => x.Id == record.Id).FirstOrDefault();
            list.Remove(r);
            list.Add(record);
            recs.AddRange(list.Select(x => x.Id + "," + x.IdentificationDetail + "," + x.ProcessName + "," + x.ApplicationPath + "," + x.Remarks + "," + x.HasBeenActedUpon + "," + x.CreatedAt).ToList());
            File.WriteAllLines(filePath, recs);



        }
        public void Update(List<TrackedAction> records)
        {
            List<string> recs = new List<string>();
            var updatedRecordIds = records.Select(x => x.Id).ToList();
            recs.Add(header);
            list.RemoveAll(x => updatedRecordIds.Contains(x.Id));
            list.AddRange(records);
            recs.AddRange(list.Select(x => x.Id + "," + x.IdentificationDetail + "," + x.ProcessName + "," + x.ApplicationPath + "," + x.Remarks + "," + x.HasBeenActedUpon + "," + x.CreatedAt).ToList());
            File.WriteAllLines(filePath, recs);


        }

        public List<IGrouping<string, TrackedAction>> GetUnActed()
        {
            try
            {
                
                    var res = GetAllRecords().Where(x => !x.HasBeenActedUpon).GroupBy(x => x.ApplicationPath).ToList();
                    return res;
                
            }
            catch (Exception e)
            {

                throw;
            }

        }


        public List<TrackedAction> GetAllRecords()
        {
            int count = 0;
            List<TrackedAction> l = new List<TrackedAction>();
            using (var rd = new StreamReader(filePath))
            {
                while (!rd.EndOfStream)
                {
                    var line = rd.ReadLine();
                    if (count != 0)
                    {
                        var splits =line.Split(',');
                        l.Add(new TrackedAction
                        {
                            Id = new Guid(splits[0]),
                            IdentificationDetail = splits[1],
                            ProcessName = splits[2],
                            ApplicationPath = splits[3],
                            Remarks = splits[4],
                            HasBeenActedUpon = Convert.ToBoolean(splits[5])


                        });
                    }
                    count++;
                }
                
            }

            return l;
        }
    }
}
