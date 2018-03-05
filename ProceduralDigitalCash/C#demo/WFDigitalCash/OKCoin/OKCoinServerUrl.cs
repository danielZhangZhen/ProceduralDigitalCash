using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFDigitalCash
{
    public static class OKCoinServerUrl
    {
        /// <summary>
        /// 现货行情URL
        /// </summary>
        public static string TICKER_URL = "/api/v1/ticker.do";

        /// <summary>
        /// 现货市场深度URL
        /// </summary>
        public static string DEPTH_URL = "/api/v1/depth.do";

        /// <summary>
        /// 现货历史交易信息URL
        /// </summary>
        public static string TRADES_URL = "/api/v1/trades.do";
        /// <summary>
        /// 现货的K线数据
        /// </summary>
        public static string KLINE_URL = "/api/v1/kline.do";
        /// <summary>
        /// 现货获取用户信息URL
        /// </summary>
        public static string USERINFO_URL = "/api/v1/userinfo.do";

        /// <summary>
        /// 现货 下单交易URL
        /// </summary>
        public static string TRADE_URL = "/api/v1/trade.do";

        /// <summary>
        /// 现货 批量下单URL
        /// </summary>
        public static string BATCH_TRADE_URL = "/api/v1/batch_trade.do";

        /// <summary>
        /// 现货 撤销订单URL
        /// </summary>
        public static string CANCEL_ORDER_URL = "/api/v1/cancel_order.do";

        /// <summary>
        /// 现货 获取用户订单URL
        /// </summary>
        public static string ORDER_INFO_URL = "/api/v1/order_info.do";

        /// <summary>
        /// 现货 批量获取用户订单URL
        /// </summary>
        public static string ORDERS_INFO_URL = "/api/v1/orders_info.do";

        /// <summary>
        /// 现货 获取历史订单信息，只返回最近七天的信息URL
        /// </summary>
        public static string ORDER_HISTORY_URL = "/api/v1/order_history.do";
        /// <summary>
        /// 提币BTC/LTCD的URL
        /// </summary>
        public static string WITHDRAW_URL = "/api/v1/withdraw.do";
        /// <summary>
        /// 取消提币BTC/LTC
        /// </summary>
        public static string CANCEL_WITHDRAW_RUL = "/api/v1/cancel_withdraw.do";
        /// <summary>
        /// 查询手续费
        /// </summary>
        public static string ORDER_FEE_URL = "/api/v1/order_fee.do";
        /// <summary>
        ///  获取放款深度前10
        /// </summary>
        public static string LEND_DEPTH_URL = "/api/v1/lend_depth.do";
        public static string BORROWS_INFO_URL = "/api/v1/borrows_info.do";
        /// <summary>
        ///  申请借款
        /// </summary>
        public static string BORROW_MONEY_URL = "/api/v1/borrow_money.do";
        /// <summary>
        /// 取消借款申请
        /// </summary>
        public static string CANCEL_BORROW_URL = "/api/v1/cancel_borrow.do";
        /// <summary>
        /// 获取借款订单记录
        /// </summary>
        public static string BORROW_ORDER_INFO = "/api/v1/borrow_order_info.do";
        /// <summary>
        /// 用户还全款
        /// </summary>
        public static string REPAYMENT_URL = "/api/v1/repayment.do";
        /// <summary>
        /// 未还款列表
        /// </summary>
        public static string UNREPAYMENTS_INFO_URL = "/api/v1/unrepayments_info.do";
        /// <summary>
        /// 获取用户提现/充值记录
        /// </summary>
        public static string ACCOUNT_RECORDS_URL = "/api/v1/account_records.do";
        /// <summary>
        ///  获取历史交易信息
        /// </summary>
        public static string TRADE_HISTORY_URL = "/api/v1/trade_history.do";
    }
}
