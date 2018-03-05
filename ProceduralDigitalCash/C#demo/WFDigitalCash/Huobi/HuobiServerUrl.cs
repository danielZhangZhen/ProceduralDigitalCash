using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFDigitalCash
{
    public static class HuobiServerUrl
    {
        #region HuoBiApi接口地址
        //GET 获取K线数据 
        public static string API_MARKET_KLINE ="/market/history/kline";
        //GET  获取聚合行情(Ticker)
        public static string API_DETAIL_MERGED = "/market/detail/merged";
        //GET 获取Market Depth 数据
        public static string API_MARKET_DEPTH = "/market/depth";
        //GET  获取 Trade Detail 数据
        public static string API_MARKET_TRADE = "/market/trade";
        //GET   批量获取最近的交易记录
        public static string API_MARKET_HISTORY_TRADE ="/market/history/trade";
        //GET  获取 Market Detail 24小时成交量数据
        public static string API_MARKET_DETAIL ="/market/history/trade";
        //GET 查询系统支持的所有交易对及精度
        public   static string API_COMMON_SYMBOLS ="/v1/common/symbols";
        //GET  查询系统支持的所有币种
        public static string API_COMMON_CURRENCYS ="/v1/common/currencys";
        //GET  查询系统当前时间
        public static string API_COMMON_TIMES ="/v1/common/timestamp";
        //GET查询Pro站指定账户的余额
        public static string API_ACCOUNBT_BALANCE ="/v1/account/accounts/{0}/balance";
        //GET查询当前用户的所有账户(即account-id)，Pro站和HADAX account-id通用
        public static string API_ACCOUNBT_ALL ="/v1/account/accounts";
        //POST Pro站下单
        public static string API_ORDERS_PLACE ="/v1/order/orders/place";
        //POST申请撤销一个订单请求
        public static string API_ORDERS_SUBMITCANCEL ="/v1/order/orders/{0}/submitcancel";
        //POST  批量撤销订单
        public static string API_ORDERS_BATCHCANCEL ="/v1/order/orders/batchcancel";
        //GET 查询某个订单详情
        public static string API_ORDERS_ORDERID ="/v1/order/orders/{0}";
        //GET 查询某个订单的成交明细
        public static string API_ORDERS_ID_MATCHRESULTS ="/v1/order/orders/{0}/matchresults";
        //GET查询当前委托、历史委托
        public static string API_ORDER_ORDERS ="/v1/order/orders";
        //GET查询当前成交、历史成交
        public static string API_ORDER_MATCHRESULTS ="/v1/order/matchresults";

        #endregion
    }
}
