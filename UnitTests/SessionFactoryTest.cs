﻿using System.Collections.Generic;
using NUnit.Framework;
using QuickFix;

namespace UnitTests
{
    [TestFixture]
    public class SessionFactoryTest
    {
        [Test]
        public void ValidConfiguration()
        {
            Application app = new NullApplication();
            MessageStoreFactory storeFactory = new MemoryStoreFactory();
            SessionFactory factory = new SessionFactory(app, storeFactory);

            SessionID sessionID = new SessionID("FIX.4.2", "SENDER", "TARGET");
            Dictionary settings = new Dictionary();
            settings.SetString(SessionSettings.CONNECTION_TYPE, "initiator");
            settings.SetString(SessionSettings.USE_DATA_DICTIONARY, "N");
            settings.SetString(SessionSettings.START_TIME, "12:00:00");
            settings.SetString(SessionSettings.END_TIME, "12:00:00");
            settings.SetString(SessionSettings.HEARTBTINT, "30");

            Assert.DoesNotThrow(delegate { factory.Create(sessionID, settings); });
        }

        [Test]
        public void StartDayAndEndDayAreDifferent()
        {
            Application app = new NullApplication();
            MessageStoreFactory storeFactory = new MemoryStoreFactory();
            SessionFactory factory = new SessionFactory(app, storeFactory);

            SessionID sessionID = new SessionID("FIX.4.2", "SENDER", "TARGET");
            Dictionary settings = new Dictionary();
            settings.SetString(SessionSettings.CONNECTION_TYPE, "initiator");
            settings.SetString(SessionSettings.USE_DATA_DICTIONARY, "N");
            settings.SetString(SessionSettings.START_TIME, "12:00:00");
            settings.SetString(SessionSettings.END_TIME, "12:00:00");
            settings.SetString(SessionSettings.START_DAY, "Sun");
            settings.SetString(SessionSettings.END_DAY, "Mon");
            settings.SetString(SessionSettings.HEARTBTINT, "30");

            Assert.DoesNotThrow(delegate { factory.Create(sessionID, settings); });
        }
    }
}
