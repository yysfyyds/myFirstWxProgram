// app.js
App({
  onLaunch() {
    // 展示本地存储能力
    const logs = wx.getStorageSync('logs') || []
    logs.unshift(Date.now())
    wx.setStorageSync('logs', logs)

    // 登录
    wx.login({
      success: res => {
        // 发送 res.code 到后台换取 openId, sessionKey, unionId
      }
    })
  },
  globalData: {
    userInfo: null,
    
  },
  /*封装全局网络请求 */
  wxRequest(url,method,data){
    return new Promise((resole,reject)=>{
      wx.request({
        url: url, 
        method:method,
        data:data,
        header: {
          'content-type': 'application/json' 
        },
        success (res) {
          console.log(res.data)
          resolve(res.data);
        },
        fail(err){
          reject(err);
        }

      })
    })
  }
})
