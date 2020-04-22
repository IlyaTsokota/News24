using News24.Data.Infrastructure;
using News24.Data.Repositories;
using News24.Model;
using System.Collections.Generic;
using System.Linq;

namespace News24.Service
{
    public interface ILogService
    {
        List<Log> GetLogs();
    }
    public class LogService : ILogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogRepository _logRepository;
        public LogService(ILogRepository logRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logRepository = logRepository;
        }

        public List<Log> GetLogs()
        {
            var logs = _logRepository.GetAll().Reverse().ToList();
            return logs;
        }
    }
}
