// index.js
// 获取应用实例
const app = getApp()
let pageIndex=1;
let pageSize=10;
Page({
  data: {
    motto: 'Hello World',
    userInfo: {},
    hasUserInfo: false,
    imgUrls: [ {
      imageUrl: "https://cdn.pixabay.com/photo/2023/06/08/13/04/fichtelbergbahn-8049565_640.jpg",
      toUrl: ""
  }, {
      imageUrl: "https://cdn.pixabay.com/photo/2023/06/29/12/22/snow-leopard-8096293_640.png",
      toUrl: ""
  } ],
    canIUse: wx.canIUse('button.open-type.getUserInfo'),
    canIUseGetUserProfile: false,
    canIUseOpenData: wx.canIUse('open-data.type.userAvatarUrl') && wx.canIUse('open-data.type.userNickName'), // 如需尝试获取用户信息可改为false
    articles: [],
    classifyList:[],
    articleList:[],
    classifyId:0,
  },
  getArticleListPageMod(){
    const that=this;
    wx.request({
      url: 'https://localhost:7285/api/MiniApp/GetArticleListPage',
      method:"GET",
      data:{
        keyWord:"1",
        pageIndex:1,
        pageSize:10
      },
      success(res){
        that.setData({
          articleList:res.data.list
        })
        console.log("获取分页数据成功-------------",that.data.articleList);
      },
      fail(err){
        console.log("获取分类数据失败",err);
        reject(err);
      }
    })
  },
  // 事件处理函数
  bindViewTap() {
    wx.navigateTo({
      url: '../logs/logs'
    })
  },
  onLoad(options) {
    const that=this;
    wx.request({
      url: 'https://localhost:7285/api/MiniApp/GetClassifyList',
      method:"GET",
      data:{
        key:"1"
      },
      success(res){
        
        that.setData({
          classifyList:res.data.data
        })
        console.log("获取的data的值-------------",that.data.classifyList);
      },
      fail(err){
        console.log("获取分类列表失败",err);
        reject(err);
      }
    })
    wx.request({
      url: 'https://localhost:7285/api/MiniApp/GetArticleListPage',
      method:"GET",
      data:{
        keyWord:"1",
        classifyId:1,
        pageIndex:1,
        pageSize:10
      },
      success(res){
        that.setData({
          articleList:res.data.data
        })
        console.log("获取分页数据成功-------------",that.data.articleList);
      },
      fail(err){
        console.log("获取分类数据失败",err);
        reject(err);
      }
    })


    // wx.request("/api/MiniApp/GetClassify","Get",{
    //   key:"1"
    // }).then(res=>{
    //   console.log("获取分类列表：",res);
    // }).catch(err=>{
    //   console.log("调用分类列表出现错误",err);
    // })
  },
  /*用于解决导航栏乱变色问题作用机制不明，而且有bug */
  onshow(){
    if(typeof this.getTabBar==="function" && this.getTabBar()){
      this.getTabBar().setData({
        active:0
      })
    }
  },
})
