﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BussinessObject.Objects;
using DataAccessLayer.DataModels;
namespace DataAccessLayer.Dao
{
   public class NotificationsDao
    {
       public List<NotificationsObjects> GetAll()
       {
           List<NotificationsObjects> lis = new List<NotificationsObjects>();
           var da = new eTrainingScheduleEntities().sp_tbl_Notifications_GetAll();
           foreach (var item in da)
           {
               NotificationsObjects obj = new NotificationsObjects();

               obj.notificationsID = item.notificationsID;
               obj.Account1 = new AccountObject
               {
                   FullName=item.FullNameUser1
               };
               obj.title = item.title;
               obj.Content = item.Content;
               obj.status = item.status;
               obj.Account2 = new AccountObject
                   {
                       FullName=item.FullNameUser2
                   };
               obj.StartDate = item.StartDate;
               obj.Isdeleted = item.Isdeleted;

               lis.Add(obj);
           }
           return lis;
       }
       public NotificationsObjects GetByID(Guid ID)
       {
           NotificationsObjects obj = new NotificationsObjects();
           var da = new eTrainingScheduleEntities().sp_tbl_Notifications_GetByID(ID);
           foreach (var item in da)
            {
               
                obj.notificationsID = item.notificationsID;
                obj.UserId = item.UserId;
                obj.UserId2 = item.UserId2;
                obj.Account1 = new AccountObject
                {
                    FullName = item.FullNameUser1
                };
                obj.title = item.title;
                obj.Content = item.Content;
                obj.status = item.status;
                obj.Account2 = new AccountObject
                {
                    FullName = item.FullNameUser2
                };
                obj.StartDate = item.StartDate;
                obj.Isdeleted = item.Isdeleted;

            }
           return obj;
       }
       public List<NotificationsObjects> GetByUserID(Guid UserID)
       {
           var da = new eTrainingScheduleEntities().sp_tbl_Notifications_GetByUserID(UserID);
           List<NotificationsObjects> lis = new List<NotificationsObjects>();
           foreach(var item in da)
           {
               NotificationsObjects obj = new NotificationsObjects();
               obj.notificationsID = item.notificationsID;
               obj.UserId = item.UserId;
               obj.Account1 = new AccountObject
               {
                   FullName = item.FullNameUser1
               };
               obj.title = item.title;
               obj.Content = item.Content;
               obj.status = item.status;
               obj.UserId2 = item.UserId2;
               obj.Account2 = new AccountObject
               {
                   FullName = item.FullNameUser2
               };
               obj.StartDate = item.StartDate;
               obj.Isdeleted = item.Isdeleted;

               lis.Add(obj);
           }
           return lis;

       }
       public List<NotificationsObjects> GetByUserID2(Guid UserID2)
       {
           var da = new eTrainingScheduleEntities().sp_tbl_Notifications_GetByUserID2(UserID2);
           List<NotificationsObjects> lis = new List<NotificationsObjects>();
           foreach (var item in da)
           {
               NotificationsObjects obj = new NotificationsObjects();
               obj.notificationsID = item.notificationsID;
               obj.UserId = item.UserId;
               obj.Account1 = new AccountObject
               {
                   FullName = item.FullNameUser1
               };
               obj.title = item.title;
               obj.Content = item.Content;
               obj.status = item.status;
               obj.UserId2 = item.UserId2;
               obj.Account1 = new AccountObject
               {
                   FullName = item.FullNameUser1
               };
               obj.StartDate = item.StartDate;
               obj.Isdeleted = item.Isdeleted;

               lis.Add(obj);
           }
           return lis;

       }
       public bool INSERT(NotificationsObjects obj)
       {
           var da=new eTrainingScheduleEntities().sp_tbl_Notifications_INSERT(obj.notificationsID,obj.UserId,obj.title,
                                                                              obj.Content,obj.status,obj.UserId2,obj.StartDate,obj.Isdeleted
                                                                             );
           return true;
       }
       public bool UPDATE(NotificationsObjects obj)
       {
           var da = new eTrainingScheduleEntities().sp_tbl_Notifications_UPDATE(obj.notificationsID, obj.UserId, obj.title,
                                                                                obj.Content, obj.status, obj.UserId2, obj.StartDate, obj.Isdeleted
                                                                               );
           return true;
       }
       public bool DELETE(Guid id)
       {
           new eTrainingScheduleEntities().sp_tbl_Notifications_DELETE(id);
           return true;
       }
    }
}