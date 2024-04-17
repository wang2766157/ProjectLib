using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using ProjectLib.Model;

namespace ProjectLib.Data
{
    #region BaseService
    public class BaseService
    {
        public readonly static string LOCAL_SESSION_KEY = "CURUSE";
        public ProtectedSessionStorage _sessionStorage;
    }
    #endregion
    #region SystemService
    /// <summary>
    /// 系统处理
    /// </summary>
    public class SystemService : BaseService
    {
        #region 菜单临时数据
        /// <summary>
        /// 菜单临时数据
        /// </summary>
        /// <returns></returns>
        public Task<List<NavModel>> GetNavListAsync()
        {
            //根目录
            var path = Environment.CurrentDirectory + "/Documents";
            var mlist = GetNavListByDir(path, path, "", new[] { "*.md" });
            return Task.FromResult(mlist);
        }

        protected List<NavModel> GetNavListByDir(string path, string rootpath, string pid, string[] pattern)
        {
            try
            {
                var list = new List<NavModel>();
                int idx = 1;
                foreach (var p in pattern)
                {
                    var midpath = "";
                    if (!string.IsNullOrEmpty(pid)) midpath = pid + ">";
                    foreach (var dir in Directory.GetDirectories(path))
                    {
                        //目录
                        var tmp = new NavModel();
                        tmp.ID = Path.GetFileName(dir.Replace(rootpath, ""));
                        tmp.Title = Path.GetFileName(dir.Replace(rootpath, ""));
                        tmp.PID = pid;
                        tmp.Idx = idx.ToString();
                        tmp.IsParent = 1;
                        tmp.Icon = "package";
                        idx++;
                        list.Add(tmp);
                        list.AddRange(GetNavListByDir(dir, rootpath, tmp.ID, pattern));
                    }
                    foreach (var file in Directory.GetFiles(path, p))
                    {
                        var tmp = new NavModel();
                        tmp.ID = Path.GetFileNameWithoutExtension(file);
                        tmp.Title = Path.GetFileNameWithoutExtension(file);
                        tmp.Url = "./Md/" + midpath + Path.GetFileNameWithoutExtension(file);
                        tmp.PID = pid;
                        tmp.Idx = idx.ToString();
                        if (string.IsNullOrEmpty(pid))
                            tmp.IsParent = 1;
                        tmp.Icon = "file_minus";
                        idx++;
                        list.Add(tmp);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region 用户菜单
        public Task<List<DropDownModel>> GetUserSetList()
        {
            var uslist = new List<DropDownModel>{
                new DropDownModel { Name = "设置状态", Value = "" },
                new DropDownModel { Name = "个人资料及帐号", Value = "" },
                new DropDownModel { IsDivider=true },
                new DropDownModel { Name = "注销", Value = "", Href="/signin" },
            };
            return Task.FromResult(uslist);
        }
        #endregion
    }

    public enum SystemLayout
    {
        Horizontal,
        Vertical,
        //Fluid,
    }
    #endregion
    //===================纠结的分隔线==================//
}
