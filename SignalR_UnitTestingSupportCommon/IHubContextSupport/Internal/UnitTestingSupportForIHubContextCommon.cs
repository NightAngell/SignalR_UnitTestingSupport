using SignalR_UnitTestingSupportCommon.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalR_UnitTestingSupportCommon.IHubContextSupport.Internal
{
    /// <summary>
    /// Internal class which provide common features for IHubContext support.
    /// </summary>
    public abstract class UnitTestingSupportForIHubContextCommon : SignalRUnitTestingSupportCommon
    {
        public UnitTestingSupportForIHubContextCommon()
        {
            SetUp();
        }

        /// <summary>
        /// Only for internal classes implementation. Do not use it in tests directly.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override void SetUp()
        {
            base.SetUp();
            _setUpClientsMock();
        }

        private void _setUpClientsMock()
        {
            SetUpClients();
            SetUpClientsAll();
            SetUpClientsAllExcept();
            SetUpClientsClient();
            SetUpClientsClients();
            SetUpClientsGroup();
            SetUpClientsGroupExcept();
            SetUpClientsGroups();
            SetUpClientsUser();
            SetUpClientsUsers();
        }
    }
}
