using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFDigitalCash.OKCoin;

namespace WFDigitalCash
{
    class OKCoinMgr
    {
      private string url_prex = "https://www.okcoin.com"; ///国内站账号配置 为 https://www.okcoin.cn

        /// <summary>
        /// ACCESS_KEY
        /// </summary>
        private readonly string api_key = string.Empty;
        /// <summary>
        /// SECRET_KEY()
        /// </summary>
        private readonly string secret_key = string.Empty;
        public OKCoinMgr(string api_key = "", string secret_key = "")
        {
            this.api_key = api_key;
            this.secret_key = secret_key;

        }

        /// <summary>
        /// 行情
        /// </summary>
        /// <param name="symbol">btc_usd:比特币    ltc_usd :莱特币</param>
        /// <returns></returns>
        public string ticker(string symbol)
        {
            string result = "";
            try
            {
                HttpUtilMgr httpUtil = HttpUtilMgr.Ins;
                string param = "";
                if (!string.IsNullOrWhiteSpace(symbol))
                {
                    if (!param.Equals(""))
                    {
                        param += "&";
                    }
                    param += "symbol=" + symbol;
                }
                result = httpUtil.requestHttpGet(url_prex, OKCoinServerUrl.TICKER_URL,  param);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        /// <summary>
        /// 现货市场深度
        /// </summary>
        /// <param name="symbol">btc_usd:比特币    ltc_usd :莱特币</param>
        /// <param name="size">size:1-200</param>
        /// <returns></returns>
        public string depth(string symbol, string size)
        {
            string result = "";
            try
            {
                HttpUtilMgr httpUtil = HttpUtilMgr.Ins;
                string param = "";
                if (!string.IsNullOrWhiteSpace(symbol))
                {
                    if (!param.Equals(""))
                    {
                        param += "&";
                    }
                    param += "symbol=" + symbol;
                }
                if (!string.IsNullOrWhiteSpace(size))
                {
                    if (!param.Equals(""))
                    {
                        param += "&";
                    }
                    param += "size=" + size;
                }
                result = httpUtil.requestHttpGet(url_prex, OKCoinServerUrl.DEPTH_URL, param);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        /// <summary>
        /// 现货历史交易信息
        /// </summary>
        /// <param name="symbol">btc_usd:比特币    ltc_usd :莱特币</param>
        /// <param name="since">不加since参数时，返回最近的60笔交易</param>
        /// <returns></returns>
        public string trades(string symbol, string since)
        {
            string result = "";
            try
            {
                HttpUtilMgr httpUtil = HttpUtilMgr.Ins;
                string param = "";
                if (!string.IsNullOrWhiteSpace(symbol))
                {
                    if (!param.Equals(""))
                    {
                        param += "&";
                    }
                    param += "symbol=" + symbol;
                }
                if (!string.IsNullOrWhiteSpace(since))
                {
                    if (!param.Equals(""))
                    {
                        param += "&";
                    }
                    param += "since=" + since;
                }
                result = httpUtil.requestHttpGet(url_prex, OKCoinServerUrl.TRADES_URL, param);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        /// <summary>
        /// 现货的K线数据
        /// </summary>
        /// <param name="symbol">btc_usd：比特币， ltc_usd：莱特币 </param>
        /// <param name="type">
        /// 1min : 1分钟 
        /// 3min : 3分钟 
        /// 5min : 5分钟 
        /// 15min : 15分钟 
        /// 30min : 30分钟
        /// 1day : 1日
        /// 3day : 3日
        ///1week : 1周
        ///1hour : 1小时
        ///2hour : 2小时
        ///4hour : 4小时
        ///6hour : 6小时
        ///12hour : 12小时</param>
        /// <param name="size">指定获取数据的条数</param>
        /// <param name="since">时间戳（eg：1417536000000）。 返回该时间戳以后的数据 </param>
        /// <returns></returns>
        public string kline(string symbol, string type, string size, string since)
        {
            string result = "";
            try
            {
                HttpUtilMgr httpUtil = HttpUtilMgr.Ins;
                string param = "";
                if (!string.IsNullOrWhiteSpace(symbol))
                {
                    if (!param.Equals(""))
                    {
                        param += "&";
                    }
                    param += "symbol=" + symbol;
                }
                if (!string.IsNullOrWhiteSpace(type))
                {
                    if (!param.Equals(""))
                    {
                        param += "&";
                    }
                    param += "type=" + type;
                }
                if (!string.IsNullOrWhiteSpace(size))
                {
                    if (!param.Equals(""))
                    {
                        param += "&";
                    }
                    param += "size=" + size;
                }
                if (!string.IsNullOrWhiteSpace(since))
                {
                    if (!param.Equals(""))
                    {
                        param += "&";
                    }
                    param += "since=" + since;
                }
                result = httpUtil.requestHttpGet(url_prex, OKCoinServerUrl.KLINE_URL, param);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public string userinfo()
        {
            string result = "";
            try
            {
                // 构造参数签名
                Dictionary<string, string> paras = new Dictionary<string, string>();
                paras.Add("api_key", api_key);
                string sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);

                // 发送post请求
                HttpUtilMgr httpUtil = HttpUtilMgr.Ins;
                result = httpUtil.requestHttpPost(url_prex, OKCoinServerUrl.USERINFO_URL,
                       paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        /// <summary>
        /// 下单交易
        /// </summary>
        /// <param name="symbol">btc_usd: 比特币 ltc_usd: 莱特币</param>
        /// <param name="type">买卖类型： 限价单（buy/sell） 市价单（buy_market/sell_market）</param>
        /// <param name="price">下单价格 [限价买单(必填)： 大于等于0，小于等于1000000 |  市价买单(必填)： BTC :最少买入0.01个BTC 的金额(金额>0.01*卖一价) / LTC :最少买入0.1个LTC 的金额(金额>0.1*卖一价)]</param>
        /// <param name="amount"> 交易数量 [限价卖单（必填）：BTC 数量大于等于0.01 / LTC 数量大于等于0.1 | 市价卖单（必填）： BTC :最少卖出数量大于等于0.01 / LTC :最少卖出数量大于等于0.1]</param>
        /// <returns></returns>
        public string trade(string symbol, string type,
                string price, string amount)
        {
            string result = "";
            try
            {
                // 构造参数签名
                Dictionary<string, string> paras = new Dictionary<string, string>();
                paras.Add("api_key", api_key);
                if (!string.IsNullOrWhiteSpace(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!string.IsNullOrWhiteSpace(type))
                {
                    paras.Add("type", type);
                }
                if (!string.IsNullOrWhiteSpace(price))
                {
                    paras.Add("price", price);
                }
                if (!string.IsNullOrWhiteSpace(amount))
                {
                    paras.Add("amount", amount);
                }
                string sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);

                // 发送post请求
                HttpUtilMgr httpUtil = HttpUtilMgr.Ins;
                result = httpUtil.requestHttpPost(url_prex, OKCoinServerUrl.TRADE_URL,
                       paras);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
        /// <summary>
        /// 批量下单
        /// </summary>
        /// <param name="symbol">btc_usd: 比特币 ltc_usd: 莱特币</param>
        /// <param name="type">买卖类型： 限价单（buy/sell） 市价单（buy_market/sell_market）</param>
        /// <param name="orders_data">JSON类型的字符串 例：[{price:3,amount:5},{price:3,amount:3}]   最大下单量为5，price和amount参数参考trade接口中的说明</param>
        /// <returns></returns>
        public string batch_trade(string symbol, string type,
                string orders_data)
        {
            string result = "";
            try
            { // 构造参数签名
                Dictionary<string, string> paras = new Dictionary<string, string>();
                paras.Add("api_key", api_key);
                if (!string.IsNullOrWhiteSpace(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!string.IsNullOrWhiteSpace(type))
                {
                    paras.Add("type", type);
                }
                if (!string.IsNullOrWhiteSpace(orders_data))
                {
                    paras.Add("orders_data", orders_data);
                }
                string sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);

                // 发送post请求
                HttpUtilMgr httpUtil = HttpUtilMgr.Ins;
                result = httpUtil.requestHttpPost(url_prex, OKCoinServerUrl.BATCH_TRADE_URL,
                       paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        /// <summary>
        /// 撤销订单
        /// </summary>
        /// <param name="symbol">btc_usd: 比特币 ltc_usd: 莱特币</param>
        /// <param name="order_id">订单ID(多个订单ID中间以","分隔,一次最多允许撤消3个订单)</param>
        /// <returns></returns>
        public string cancel_order(string symbol, string order_id)
        {
            string result = "";
            try
            {// 构造参数签名
                Dictionary<string, string> paras = new Dictionary<string, string>();
                paras.Add("api_key", api_key);
                if (!string.IsNullOrWhiteSpace(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!string.IsNullOrWhiteSpace(order_id))
                {
                    paras.Add("order_id", order_id);
                }

                string sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);

                // 发送post请求
                HttpUtilMgr httpUtil = HttpUtilMgr.Ins;
                result = httpUtil.requestHttpPost(url_prex, OKCoinServerUrl.CANCEL_ORDER_URL,
                       paras);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        /// <summary>
        /// 获取用户的订单信息
        /// </summary>
        /// <param name="symbol">btc_usd: 比特币 ltc_usd: 莱特币</param>
        /// <param name="order_id">订单ID(-1查询全部订单，否则查询相应单号的订单)</param>
        /// <returns></returns>
        public string order_info(string symbol, string order_id)
        {
            string result = "";
            try
            { // 构造参数签名
                Dictionary<string, string> paras = new Dictionary<string, string>();
                paras.Add("api_key", api_key);
                if (!string.IsNullOrWhiteSpace(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!string.IsNullOrWhiteSpace(order_id))
                {
                    paras.Add("order_id", order_id);
                }

                string sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);

                // 发送post请求
                HttpUtilMgr httpUtil = HttpUtilMgr.Ins;
                result = httpUtil.requestHttpPost(url_prex, OKCoinServerUrl.ORDER_INFO_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        /// <summary>
        /// 批量获取用户订单
        /// </summary>
        /// <param name="type">查询类型 0:未成交，未成交 1:完全成交，已撤销</param>
        /// <param name="symbol">btc_usd: 比特币 ltc_usd: 莱特币</param>
        /// <param name="order_id">订单ID(多个订单ID中间以","分隔,一次最多允许查询50个订单)</param>
        /// <returns></returns>
        public string orders_info(string type, string symbol,
                string order_id)
        {
            string result = "";
            try
            {
                // 构造参数签名
                Dictionary<string, string> paras = new Dictionary<string, string>();
                paras.Add("api_key", api_key);
                if (!string.IsNullOrWhiteSpace(type))
                {
                    paras.Add("type", type);
                }
                if (!string.IsNullOrWhiteSpace(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!string.IsNullOrWhiteSpace(order_id))
                {
                    paras.Add("order_id", order_id);
                }

                string sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);

                // 发送post请求
                HttpUtilMgr httpUtil = HttpUtilMgr.Ins;
                result = httpUtil.requestHttpPost(url_prex, OKCoinServerUrl.ORDERS_INFO_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        /// <summary>
        /// 获取历史订单信息，只返回最近七天的信息
        /// </summary>
        /// <param name="symbol">btc_usd: 比特币 ltc_usd: 莱特币</param>
        /// <param name="status">委托状态: 0：未成交 1：已完成(最近七天的数据)</param>
        /// <param name="current_page">当前页数</param>
        /// <param name="page_length">每页数据条数，最多不超过200</param>
        /// <returns></returns>
        public string order_history(string symbol, string status,
                string current_page, string page_length)
        {
            string result = "";
            try
            {
                // 构造参数签名
                Dictionary<string, string> paras = new Dictionary<string, string>();
                paras.Add("api_key", api_key);
                if (!string.IsNullOrWhiteSpace(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!string.IsNullOrWhiteSpace(status))
                {
                    paras.Add("status", status);
                }
                if (!string.IsNullOrWhiteSpace(current_page))
                {
                    paras.Add("current_page", current_page);
                }
                if (!string.IsNullOrWhiteSpace(page_length))
                {
                    paras.Add("page_length", page_length);
                }

                string sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);

                // 发送post请求
                HttpUtilMgr httpUtil = HttpUtilMgr.Ins;
                result = httpUtil.requestHttpPost(url_prex, OKCoinServerUrl.ORDER_HISTORY_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
        /// <summary>
        /// 提币BTC/LTC
        /// </summary>
        /// <param name="symbol">btc_usd: 比特币 ltc_usd: 莱特币 </param>
        /// <param name="chargefee">网络手续费 BTC默认范围 [0.0001，0.01] LTC默认范围 [0.001，0.2],手续费越高，网络确认越快，OKCoin内部提币设置0 </param>
        /// <param name="trade_pwd">交易密码 </param>
        /// <param name="withdraw_address">提币认证地址 </param>
        /// <param name="withdraw_amount">提币数量 BTC>=0.01 LTC>=0.1 </param>
        /// <returns></returns>
        public string withdraw(string symbol, string chargefee, string trade_pwd, string withdraw_address, string withdraw_amount)
        {
            string result = "";
            try
            {
                Dictionary<string, string> paras = new Dictionary<string, string>();
                paras.Add("api_key", api_key);
                if (!string.IsNullOrWhiteSpace(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!string.IsNullOrWhiteSpace(chargefee))
                {
                    paras.Add("chargefee", chargefee);
                }
                if (!string.IsNullOrWhiteSpace(trade_pwd))
                {
                    paras.Add("trade_pwd", trade_pwd);
                }
                if (!string.IsNullOrWhiteSpace(withdraw_address))
                {
                    paras.Add("withdraw_address", withdraw_address);
                }
                if (!string.IsNullOrWhiteSpace(withdraw_amount))
                {
                    paras.Add("withdraw_amount", withdraw_amount);
                }
                string sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);

                // 发送post请求
                HttpUtilMgr httpUtil = HttpUtilMgr.Ins;
                result = httpUtil.requestHttpPost(url_prex, OKCoinServerUrl.WITHDRAW_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        /// <summary>
        /// 取消提币BTC/LTC
        /// </summary>
        /// <param name="symbol">btc_usd: 比特币 ltc_usd: 莱特币 </param>
        /// <param name="withdraw_id">提币申请Id </param>
        /// <returns></returns>
        public string cancel_withdraw(string symbol, string withdraw_id)
        {
            string result = "";
            try
            {
                HttpUtilMgr httpUtil = HttpUtilMgr.Ins;
                Dictionary<string, string> paras = new Dictionary<string, string>();
                paras.Add("api_key", api_key);
                if (!string.IsNullOrWhiteSpace(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!string.IsNullOrWhiteSpace(withdraw_id))
                {
                    paras.Add("withdraw_id", withdraw_id);
                }
                string sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);
                //发送post请求
                result = httpUtil.requestHttpPost(url_prex, OKCoinServerUrl.CANCEL_WITHDRAW_RUL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        /// <summary>
        /// 查询手续费
        /// </summary>
        /// <param name="order_id">订单ID </param>
        /// <param name="symbol">btc_usd:比特币    ltc_usd :莱特币 </param>
        /// <returns></returns>
        public string order_fee(string order_id, string symbol)
        {
            string result = "";
            try
            {
                HttpUtilMgr httpUtil = HttpUtilMgr.Ins;
                Dictionary<string, string> paras = new Dictionary<string, string>();
                paras.Add("api_key", api_key);
                if (!string.IsNullOrWhiteSpace(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!string.IsNullOrWhiteSpace(order_id))
                {
                    paras.Add("order_id", order_id);
                }
                string sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);
                //发送post请求
                result = httpUtil.requestHttpPost(url_prex, OKCoinServerUrl.ORDER_FEE_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        /// <summary>
        ///  获取放款深度前10
        /// </summary>
        /// <param name="symbol">btc_usd: 比特币 ltc_usd: 莱特币 usd: 美元</param>
        /// <returns></returns>
        public string lend_depth(string symbol)
        {
            string result = "";
            try
            {
                HttpUtilMgr httpUtil = HttpUtilMgr.Ins;
                Dictionary<string, string> paras = new Dictionary<string, string>();
                paras.Add("api_key", api_key);
                if (!string.IsNullOrWhiteSpace(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                string sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);
                //发送post请求
                result = httpUtil.requestHttpPost(url_prex, OKCoinServerUrl.LEND_DEPTH_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        /// <summary>
        ///  查询用户借款信息
        /// </summary>
        /// <param name="symbol">btc_usd: 比特币 ltc_usd: 莱特币 usd: 美元 </param>
        /// <returns></returns>
        public string borrows_info(string symbol)
        {
            string result = "";
            try
            {
                HttpUtilMgr httpUtil = HttpUtilMgr.Ins;
                Dictionary<string, string> paras = new Dictionary<string, string>();
                paras.Add("api_key", api_key);
                if (!string.IsNullOrWhiteSpace(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                string sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);
                //发送post请求
                result = httpUtil.requestHttpPost(url_prex, OKCoinServerUrl.BORROWS_INFO_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        /// <summary>
        /// 申请借款
        /// </summary>
        /// <param name="symbol">btc_usd: 比特币 ltc_usd: 莱特币 usd: 美元 </param>
        /// <param name="days">借款天数， three，seven，fifteen，thirty，sixty，ninety </param>
        /// <param name="amount">借入数量 </param>
        /// <param name="rate">借款利率 [0.0001, 0.01] </param>
        /// <returns></returns>
        public string borrow_money(string symbol, string days, string amount, string rate)
        {
            string result = "";
            try
            {
                HttpUtilMgr httpUtil = HttpUtilMgr.Ins;
                Dictionary<string, string> paras = new Dictionary<string, string>();
                paras.Add("api_key", api_key);
                if (!string.IsNullOrWhiteSpace(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!string.IsNullOrWhiteSpace(days))
                {
                    paras.Add("days", days);
                }
                if (!string.IsNullOrWhiteSpace(amount))
                {
                    paras.Add("amount", amount);
                }
                if (!string.IsNullOrWhiteSpace(rate))
                {
                    paras.Add("rate", rate);
                }
                string sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);
                //发送post请求
                result = httpUtil.requestHttpPost(url_prex, OKCoinServerUrl.BORROW_MONEY_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        /// <summary>
        /// 取消借款申请
        /// </summary>
        /// <param name="symbol">btc_usd: 比特币 ltc_usd: 莱特币 usd: 美元 </param>
        /// <param name="borrow_id">借款单ID</param>
        /// <returns></returns>
        public string cancel_borrow(string symbol, string borrow_id)
        {
            string result = "";
            try
            {
                HttpUtilMgr httpUtil = HttpUtilMgr.Ins;
                Dictionary<string, string> paras = new Dictionary<string, string>();
                paras.Add("api_key", api_key);
                if (!string.IsNullOrWhiteSpace(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!string.IsNullOrWhiteSpace(borrow_id))
                {
                    paras.Add("borrow_id", borrow_id);
                }
                string sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);
                //发送post请求
                result = httpUtil.requestHttpPost(url_prex, OKCoinServerUrl.CANCEL_BORROW_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        /// <summary>
        ///  获取借款订单记录
        /// </summary>
        /// <param name="borrow_id">借款单ID</param>
        /// <returns></returns>
        public string borrow_order_info(string borrow_id)
        {
            string result = "";
            try
            {
                HttpUtilMgr httpUtil = HttpUtilMgr.Ins;
                Dictionary<string, string> paras = new Dictionary<string, string>();
                paras.Add("api_key", api_key);
                if (!string.IsNullOrWhiteSpace(borrow_id))
                {
                    paras.Add("borrow_id", borrow_id);
                }
                string sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);
                //发送post请求
                result = httpUtil.requestHttpPost(url_prex, OKCoinServerUrl.BORROW_ORDER_INFO,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        /// <summary>
        /// 用户还全款
        /// </summary>
        /// <param name="borrow_id">借款单ID</param>
        /// <returns></returns>
        public string repayment(string borrow_id)
        {
            string result = "";
            try
            {
                HttpUtilMgr httpUtil = HttpUtilMgr.Ins;
                Dictionary<string, string> paras = new Dictionary<string, string>();
                paras.Add("api_key", api_key);
                if (!string.IsNullOrWhiteSpace(borrow_id))
                {
                    paras.Add("borrow_id", borrow_id);
                }
                string sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);
                //发送post请求
                result = httpUtil.requestHttpPost(url_prex, OKCoinServerUrl.REPAYMENT_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        /// <summary>
        /// 未还款列表
        /// </summary>
        /// <param name="symbol">btc_usd: 比特币 ltc_usd: 莱特币 usd: 美元 </param>
        /// <param name="current_page">当前页数</param>
        /// <param name="page_length">每页数据条数，最多不超过50条</param>
        /// <returns></returns>
        public string unrepayments_info(string symbol, string current_page, string page_length)
        {
            string result = "";
            try
            {
                HttpUtilMgr httpUtil = HttpUtilMgr.Ins;
                Dictionary<string, string> paras = new Dictionary<string, string>();
                paras.Add("api_key", api_key);
                if (!string.IsNullOrWhiteSpace(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!string.IsNullOrWhiteSpace(current_page))
                {
                    paras.Add("current_page", current_page);
                }
                if (!string.IsNullOrWhiteSpace(page_length))
                {
                    paras.Add("page_length", page_length);
                }
                string sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);
                //发送post请求
                result = httpUtil.requestHttpPost(url_prex, OKCoinServerUrl.UNREPAYMENTS_INFO_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        /// <summary>
        /// 获取用户提现/充值记录
        /// </summary>
        /// <param name="symbol">btc_usd: 比特币 ltc_usd: 莱特币 usd: 美元</param>
        /// <param name="type">0：充值 1 ：提现 </param>
        /// <param name="current_page">当前页数</param>
        /// <param name="page_length">每页数据条数，最多不超过50条</param>
        /// <returns></returns>
        public string account_records(string symbol, string type, string current_page, string page_length)
        {
            string result = "";
            try
            {
                HttpUtilMgr httpUtil = HttpUtilMgr.Ins;
                Dictionary<string, string> paras = new Dictionary<string, string>();
                paras.Add("api_key", api_key);
                if (!string.IsNullOrWhiteSpace(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!string.IsNullOrWhiteSpace(type))
                {
                    paras.Add("type", type);
                }
                if (!string.IsNullOrWhiteSpace(current_page))
                {
                    paras.Add("current_page", current_page);
                }
                if (!string.IsNullOrWhiteSpace(page_length))
                {
                    paras.Add("page_length", page_length);
                }
                string sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);
                //发送post请求
                result = httpUtil.requestHttpPost(url_prex, OKCoinServerUrl.ACCOUNT_RECORDS_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        /// <summary>
        ///  获取历史交易信息
        /// </summary>
        /// <param name="symbol">btc_usd:比特币 ltc_usd :莱特币 </param>
        /// <param name="since">从某一tid开始访问600条数据(必填项) </param>
        /// <returns></returns>
        public string trade_history(string symbol, string since)
        {
            string result = "";
            try
            {
                HttpUtilMgr httpUtil = HttpUtilMgr.Ins;
                Dictionary<string, string> paras = new Dictionary<string, string>();
                paras.Add("api_key", api_key);
                if (!string.IsNullOrWhiteSpace(symbol))
                {
                    paras.Add("symbol", symbol);
                }
                if (!string.IsNullOrWhiteSpace(since))
                {
                    paras.Add("since", since);
                }
                string sign = MD5Util.buildMysignV1(paras, this.secret_key);
                paras.Add("sign", sign);
                //发送post请求
                result = httpUtil.requestHttpPost(url_prex, OKCoinServerUrl.TRADE_HISTORY_URL,
                        paras);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
    }
}
