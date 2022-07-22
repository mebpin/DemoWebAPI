using DemoWebAPI.Models;

namespace DemoWebAPI.Repositories
{
    public class CollegeRepo:ICollegeRepo
    {
        CollegeContext _context;
        public CollegeRepo(CollegeContext context) 
        {
            _context = context;
        }

        public College AddCollegeData(College colz)
        {
            _context.Add(colz);
            _context.SaveChanges();
            return colz;
        }
        public IEnumerable<College> GetAllCollegeData()
        {
            List<College> colzDataList = _context.Colleges.ToList();
            return colzDataList;
        }
        public College GetCollegeData(int id)
        {
            var colz = _context.Colleges.Find(id);
            return colz;
        }
        public College UpdateCollegeData(int id,College c)
        {
            _context.Colleges.Update(c);
            _context.SaveChanges();
            return c;
        }
        public College DeleteCollegeData(int id)
        {
            var colz = _context.Colleges.Find(id);
            _context.Colleges.Remove(colz);
            _context.SaveChanges();
            return colz;
        }
        
    }
}
