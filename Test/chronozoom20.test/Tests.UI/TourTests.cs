﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TourTests : TestBase
    {
        public TestContext TestContext { get; set; }

        #region Initialize and Cleanup

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
           
        }

        [TestInitialize]
        public void TestInitialize()
        {
            BrowserStateManager.RefreshState();
            HomePageHelper.OpenPage();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
        }

        [TestCleanup]
        public void TestCleanup()
        {
            CreateScreenshotsIfTestFail(TestContext);
            NavigationHelper.NavigateToCosmos();
        }

        #endregion 

        [TestMethod]
        public void Test_Start_Pause_Tour()
        {
            TourHelper.OpenToursListWindow();
            TourHelper.SelectMayanHistoryTour();
            TourHelper.PauseTour();
            TourHelper.ResumeTour();
        }  
        
        [TestMethod]
        public void Test_Show_Hide_Bookmark_Tour()
        {
            TourHelper.OpenToursListWindow();
            TourHelper.SelectMayanHistoryTour();
            TourHelper.PauseTour();
            Assert.IsTrue(BookmarkHelper.IsBookmarkExpanded());
            BookmarkHelper.HideBookmark();
            Assert.IsFalse(BookmarkHelper.IsBookmarkExpanded());
        }
        
        [TestMethod]
        public void bookmark_should_be_opened_second_time()
        {
            TourHelper.OpenToursListWindow();
            TourHelper.SelectMayanHistoryTour();
            TourHelper.CloseBookmark();
            TourHelper.OpenToursListWindow();
            TourHelper.StartPortusTour();
            Assert.IsTrue(BookmarkHelper.IsBookmarkExpanded());
        }
    }
}