using AutoMapper;
using News24.Model;
using News24.Service;
using News24.Web.Areas.Admin.ViewModels.LogViewModels;
using News24.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace News24.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LogController : Controller
    {
        private readonly ILogService _logService;
        private const int _pageSize = 10;
        // GET: Admin/Log

        public LogController(ILogService logService)
        {
            _logService = logService;
        }
        public ActionResult Index(int page = 1 )
        {
            var logs = _logService.GetLogs();
            var logList = logs.Select(Mapper.Map<Log, LogViewModel>).Skip((page - 1) * _pageSize).Take(_pageSize).ToList();
            var pager = new Pager(page, logs.Count, _pageSize);
            var model = new IndexLogViewModel
            {
                Logs = logList,
                Pager = pager
            };
            return View(model);
        }
    }
}