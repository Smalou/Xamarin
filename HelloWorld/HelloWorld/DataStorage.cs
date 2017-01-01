using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Xamarin.Forms;
using System.Collections;

namespace HelloWorld
{
    public class DataStorage
    {
        public MobileServiceClient MobileService { get; set; }
        IMobileServiceSyncTable<userData> userData;

        public async Task Initialize()
        {
            MobileService = new MobileServiceClient("http://treasuresfind.azurewebsites.net");
            const string path = "userData.db";
            var store = new MobileServiceSQLiteStore(path);
            store.DefineTable<userData>();
            await MobileService.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());
            userData=MobileService.GetSyncTable<userData>();
        }

        public async Task AddUser(userData user)
        {
            
            await Initialize();
            await userData.InsertAsync(user);

            await SyncUser();

        }
        public async Task SyncUser()
        {
          //  await userData.PullAsync("allUsers", userData.CreateQuery());
            await MobileService.SyncContext.PushAsync();
        }
    }
}
