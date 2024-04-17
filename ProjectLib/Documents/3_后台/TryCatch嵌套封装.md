# TryCatch嵌套封装

---

## 方式

利用 **泛型委托类型** Func

![cs](https://skillicons.dev/icons?i=cs)

```
        //原写法
        public JsonResult RepairItemDataDeleteData()
        {
            AjaxMsg msg = new AjaxMsg();
            DbTrans dbTrans = dao.BeginTransaction(IsolationLevel.ReadUncommitted);
            try
            {
                . . .
            }
            catch (Exception ex)
            {
                dbTrans.Rollback();
                WriteLogTextNs.WriteLogText.LogPgmExOper(MethodBase.GetCurrentMethod().Name, ex);
                throw ex;
            }
        }

        //变更后

        //在base中增加此方法
        protected JsonResult TryCatch(string funname, Func<DbTrans, JsonResult> fun)
        {
            var tran = dao.BeginTransaction(IsolationLevel.ReadUncommitted);
            try
            {
                return fun(tran);
            }
            catch (Exception ex)
            {
                tran.Rollback();
                WriteLogTextNs.WriteLogText.LogPgmExOper(funname, ex);
                throw ex;
            }
            finally { tran.Dispose(); }
        }

        //修改后方法
        public JsonResult RepairItemDataDeleteData()
        {
            AjaxMsg msg = new AjaxMsg();
            return TryCatch(MethodBase.GetCurrentMethod().Name, (tran) => {
                . . .
            });
        }
```
---

