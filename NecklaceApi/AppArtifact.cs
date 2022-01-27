using System;

namespace Necklace.Api
{
    /// <summary>
    /// The information required to submit a new app version to the Necklace back end.
    /// </summary>
    [Serializable]
    public class AppArtifact
    {
        public string AppName { get; set; }
        public string Version { get; set; }

        // where I got to: I am thinking the "storage layer" will/should be able to surface AppCastItem objects, which I'll just store.

        // this WONT work for mac though right?  will the .net AppCastItem be enough? 

        // in any case - if I can store JSON documents and then rejig those into AppCastItems on the way; that'd be enough too.

        public AppArtifact()
        {

        }
    }
}
