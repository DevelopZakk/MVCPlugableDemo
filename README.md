# MVCPlugableDemo
MVCPlugableDemo-1
主要的目的是
讓許多網頁系統專案共用某些架構，安全性驗證，Layout...，系統維護上更方便

參考文章：
https://blog.longle.net/2012/03/29/building-a-composite-mvc3-application-with-pluggable-areas/
這個網站的範例程式download有點問題，因此就自己試著弄了一個

新的網頁系統要加在原始的網頁上，就像是熱插拔一樣(當然沒有那麼偉大)
可以把新的網站 Copy 到入口網站的某個目錄，然後就有新的網站
各系統可以自行決定是否要 Share 同一個 _layout View

例如：
我現在有一個網站是  http://myHost/
假如是form驗證 ，沒有權限會從  http://myHost/Account/Logon 進入

新加上一個網站是  http://myHost/WebSite1
如果登入WebSite1 沒有權限，也會從 http://myHost/Account/Logon 進入

在Visual Studio 裡面，網站專案是分開的，因此有一個專案是 myHost，一個專案是 myHost.WebSite1

各自開發各自的，
但是Release的時候，應該是把 myHost.WebSite1 的一些檔案，Copy 到 myHost 就可以執行了

#step 1

myHost 專案下
需要有一個註冊 Dll 的服務，因此會建立一個pluginAreaBootstrapper的類別來處理這件事情

#step2. 

要讓myHost 啟動時候，去註冊別的Dll，需要呼叫 PluginAreaBootstrapper.Init

修改myHost 的 AssemblyInfo.cs
增加
[assembly: PreApplicationStartMethod(typeof(PluginAreaBootstrapper), "Init")]  

#step3. 

在myHost.WebSite1PlugIn的專案

增加一個要註冊Area的class 
重點是這個Class 要繼承 AreaRegistration

#step4. 

complier 整個solution 後

1. 在myHost目錄下，建立 Areas 目錄，並在Areas 目錄下建立 WebSite1 目錄

2. 將myHost.WebSite1PlugIn.dll copy 到 myHost Areas的目錄下
3. 將myHost.WebSite1PlugIn Views下所有的檔案Copy 到 myHost\Areas\WebSite1 下


第2.3個步驟，建議設定在專案的Post Build 後，這樣可以減少每次編譯完還要手動搬檔案的動作


