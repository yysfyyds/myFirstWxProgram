// 获取应用实例
const app = getApp()
//计数器
var interval = null;
//值越大旋转时间越长  即旋转速度
var intime = 50;
Page({
  data: {
    resultList:[],
    luckPosition:5,
    drawLuck:true,
    list:[
      {phone: "188****3434", name: "时间简史"},
      {phone: "188****3434", name: "C# 从入门到精通"},
      {phone: "188****3434", name: "C 从入门到精通"},
      {phone: "188****3434", name: "Java 从入门到精通"},
      {phone: "188****3434", name: "C++ 编程"},
      {phone: "188****3434", name: "python 语言入门"},
      {phone: "188****3434", name: "深入浅出 Vue.js"},
      {phone: "188****3434", name: ".NET 架构设计"},
      {phone: "188****3434", name: "Java 从入门到精通"},
      {phone: "188****3434", name: "C++ 编程"},
      {phone: "188****3434", name: "时间简史"},
      {phone: "188****3434", name: "python 语言入门"},
      
    ],
    turnplateList:[
      {id: "1", name: "时间简史", img:'../../images/picture_0.png',is_tunplateList:'1',status:false},
      {id: "2", name: "C# 从入门到精通", img:'../../images/picture_1.png',is_turnplateList:'1',status:false},
      {id: "3", name: "Java 从入门到精通", img:'../../images/picture_2.png',is_turnplateList:'1',status:false},
      {id: "4", name: "C 从入门到精通", img:'../../images/picture_3.png',is_turnplateList:'0',status:false},
      {id: "5", name: "C++ 编程", img:'../../images/picture_4.png',is_turnplateList:'1',status:false},
      {id: "6", name: "python 语言入门", img:'../../images/picture_5.png',is_turnplateList:'1',status:false},
      {id: "7", name: ".NET 架构设计", img:'../../images/picture_6.png',is_turnplateList:'1',status:false},
      {id: "8", name: "深入浅出 Vue.js", img:'../../images/picture_7.png',is_turnplateList:'0',status:false},
    ],
    draw_count:'1',
   
  },
  // 事件处理函数
 
  onLoad() {
    
  },
  drawLuck(){
    if(this.data.draw_count==0){
      wx.showToast({
        title: '您的抽奖次数已经用光了',
        icon:'none'
      })
      return false
    }
    this.setData({
      drawLuck:false
    })
    let that=this;
    //定时器
    clearInterval(interval)
    var index=0;
    interval=setInterval(function(){
      if(index>7){
        index=0;
        that.data.turnplateList[7].status = false
      }else if (index != 0) {
        that.data.turnplateList[index - 1].status = false
      }
      that.data.turnplateList[index].status = true
      that.setData({
        turnplateList: that.data.turnplateList,
      })
      index++;
    },intime)
    console.log(this.data.turnplateList)
     //模拟网络请求时间  设为两秒
     var stoptime = 2000;
     setTimeout(function () {
       that.stop(that.data.luckPosition);
     }, stoptime)
  },
  stop: function (which){
    var e = this;
    //清空计数器
    clearInterval(interval);
    //初始化当前位置
    var current = -1;
    var turnplateList = e.data.turnplateList;
    for (var i = 0; i < turnplateList.length; i++) {
      if (turnplateList[i] == 1) {
        current = i;
      }
    }
    //下标从1开始
    var index = current + 1;
    e.stopLuck(which, index, intime, 10);
  },
  stopLuck: function (which, index, time, splittime) {
    var that = this;
    //值越大出现中奖结果后减速时间越长
    var turnplateList = that.data.turnplateList;
    setTimeout(function () {
      //重置前一个位置
      if (index > 7) {
        index = 0;
        turnplateList[7].status = false
      } else if (index != 0) {
        turnplateList[index - 1].status = false
      }
      //当前位置为选中状态
      turnplateList[index].status = true
      that.setData({
        turnplateList: turnplateList,
      })
      //如果旋转时间过短或者当前位置不等于中奖位置则递归执行
      //直到旋转至中奖位置
      if (time < 400 || index != which) {
        //越来越慢
        splittime++;
        time += splittime;
        //当前位置+1
        index++;
        that.stopLuck(which, index, time, splittime);
      } else {
        //1秒后显示弹窗
        setTimeout(function () {
          let turnplateList_info = that.data.turnplateList[which];
          let title = '';
          if (turnplateList_info.is_turnplateList == 1) {
            title = '恭喜你抽中了' + turnplateList_info.name;
            let resultList=[]
            resultList.push(turnplateList_info)
            that.setData({
              resultList:that.data.resultList.concat(resultList)
            })
            console.log(that.data.resultList)
          } else {
            title = '很遗憾未中奖';
          }
          wx.showModal({
            title: '提示',
            content: title,
            showCancel: false,
            success: function (res) {
              if (res.confirm) {
                let draw_count=that.data.draw_count;
                draw_count--;
                console.log(draw_count)
                that.setData({
                  drawLuck: true,
                  luckPosition: 0,
                  draw_count:draw_count
                })
              }
            }
          })
        }, 1000);
      }
    }, time);
  },

  upper(e) {
    console.log(e)
  },

  lower(e) {
    console.log(e)
  },

  scroll(e) {
    console.log(e)
  },

  scrollToTop() {
    this.setAction({
      scrollTop: 0
    })
  },
})

