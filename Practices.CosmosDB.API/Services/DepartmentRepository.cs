//using Practices.CosmosDB.API.App_Code;
//using Practices.CosmosDB.API.Infrastructure;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Practices.CosmosDB.API.Services
//{
//    public class DepartmentRepository : IDepartmentRepository
//    {
//        private readonly PracticeDbContext _dbContext;

//        public DepartmentRepository(PracticeDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public IEnumerable<Department> GetAll()
//        {
//            return _dbContext.Departments
//                    .AsEnumerable();
//        }

//        public IEnumerable<Department> GetAllActiveDepartments()
//        {
//            return _dbContext.Departments
//                .Where(x => x.IsActive == true)
//                .AsEnumerable();
//        }

//        public Department GetById(int id)
//        {
//            return _dbContext.Departments
//                .Where(x => x.DepartmentId == id)
//                .FirstOrDefault();
//        }
//        public void Insert(Department entity)
//        {
//            _dbContext.Departments.Add(entity);
//        }
//        public void Update(Department entity)
//        {
//            _dbContext.Departments.Update(entity);
//        }
//        public void Delete(Department entity)
//        {
//            _dbContext.Departments.Remove(entity);
//        }
//    }
//}
